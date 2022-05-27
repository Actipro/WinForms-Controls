using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet.Resolution;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.Implementation;
using ActiproSoftware.UI.WinForms;
using ActiproSoftware.UI.WinForms.Input;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DotNetAddonGoToDefinition {
	
	/// <summary>
	/// A custom tagger that adds a custom <see cref="IClassificationTag"/> over tokens that might be
	/// valid for "Go To Definition" functionality and provides special handling for clicking over
	/// those tags.
	/// </summary>
	public class GoToDefinitionTagger : TaggerBase<IClassificationTag> {

		private TextSnapshotRange						currentTaggedSnapshotRange;
		private readonly GoToDefinitionService			goToDefinitionService;
		private bool									isCustomCursorActive;
		private Point?									lastMouseLocation;
		private readonly IEditorView					view;

		private static readonly IClassificationType		goToDefinitionClassificationType = new ClassificationType("GoToDefinition", "Go To Definition");

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes the <c>WordHighlightTagger</c> class.
		/// </summary>
		static GoToDefinitionTagger() {
			// Define a style that will be applied to recognized identifiers
			var style = new HighlightingStyle(Color.Blue, null) {  UnderlineKind = LineKind.Solid };
			AmbientHighlightingStyleRegistry.Instance.Register(goToDefinitionClassificationType, style);
		}

		/// <summary>
		/// Initializes a new instance of the <c>WordHighlightTagger</c> class.
		/// </summary>
		/// <param name="view">The view to which this manager is attached.</param>
		public GoToDefinitionTagger(IEditorView view) : base(nameof(GoToDefinitionTagger),
			new Ordering[] { new Ordering(TaggerKeys.Token, OrderPlacement.Before) }, view.SyntaxEditor.Document) {

			this.view = view;

			// Get the required service
			goToDefinitionService = view.SyntaxEditor.Document.Language.GetService<GoToDefinitionService>();
			Debug.Assert(goToDefinitionService != null);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Configures the view with a custom cursor to indicate the tag can be clicked.
		/// </summary>
		private void ApplyCustomCursor() {
			if (!isCustomCursorActive) {
				this.view.SyntaxEditor.OverrideCursor = Cursors.Hand;
				isCustomCursorActive = true;
			}
		}

		/// <summary>
		/// Clears the custom cursor configuration from the view.
		/// </summary>
		private void ClearCustomCursor() {
			if (isCustomCursorActive) {
				this.view.SyntaxEditor.OverrideCursor = null;
				isCustomCursorActive = false;
			}
		}

		/// <summary>
		/// Tests if the given key is one that could impact the tagging process.
		/// </summary>
		/// <param name="key">The key to be tested.</param>
		/// <returns><c>true</c> if the key could impact the tagging process; otherwise <c>false</c>.</returns>
		private bool DoesKeyImpactTagging(Keys key) {
			// Any of the modifier keys can impact the tagging process
			return key.HasFlag(Keys.ControlKey)
				|| key.HasFlag(Keys.Menu)
				|| key.HasFlag(Keys.ShiftKey);
		}

		/// <summary>
		/// Invaliates any previously defined tags.
		/// </summary>
		/// <param name="snapshotRange">The invalidated snapshot range.</param>
		private void InvalidateTags(TextSnapshotRange snapshotRange) {
			// Quit if the range is undefined or zero-length
			if (snapshotRange.IsDeleted || snapshotRange.IsZeroLength)
				return;

			// Notify that tags have changed for this range
			this.OnTagsChanged(new TagsChangedEventArgs(snapshotRange));
		}

		/// <summary>
		/// Gets whether tagging is currently active.
		/// </summary>
		/// <value>
		/// <c>true</c> if tagging is active; otherwise, <c>false</c>.
		/// </value>
		//private bool IsTaggingActive { get; set; }
		private bool IsTaggingActive {
			// Tagging is only performed when just the CTRL key is pressed
			get => Control.ModifierKeys == Keys.Control;
		}

		/// <summary>
		/// Updates the tagged range for a "Go To Definition" tag.
		/// </summary>
		/// <param name="cursorLocation">The current cursor location.</param>
		/// <returns><c>true</c> if a valid tagged range was detected; otherwise <c>false</c>.</returns>
		private bool UpdateTaggedRange(Point cursorLocation) {
			return UpdateTaggedRange(cursorLocation, out var _);
		}

		/// <summary>
		/// Updates the tagged range for a "Go To Definition" tag.
		/// </summary>
		/// <param name="cursorLocation">The current cursor location.</param>
		/// <param name="resolverResult">Outputs the result of a resolver operation, if any, that was found for a successfully tagged range.</param>
		/// <returns><c>true</c> if a valid tagged range was detected; otherwise <c>false</c>.</returns>
		private bool UpdateTaggedRange(Point cursorLocation, out IResolverResult resolverResult) {
			// Initialize output argument
			resolverResult = null;

			// Cache the current snapshot range
			var oldSnapshotRange = currentTaggedSnapshotRange;

			// Reset the snapshot range
			currentTaggedSnapshotRange = TextSnapshotRange.Deleted;

			// Only perform additional testing if tagging is active
			if (IsTaggingActive) {

				// Check if the mouse is currently positioned a character in the text area of the view
				IHitTestResult hitTestResult = view.SyntaxEditor.HitTest(cursorLocation);
				if (hitTestResult.Type == HitTestResultType.ViewTextAreaOverCharacter) {

					// Find the token whose range can be tagged and ensure it's for an identifier or keyword
					var currentToken = hitTestResult.Snapshot.GetReader(hitTestResult.Offset).Token;
					if (
						(currentToken != null)
						&& (CSharpTokenId.IsIdentifierClassificationType(currentToken.Id) || CSharpTokenId.IsKeywordClassificationType(currentToken.Id))
						) {

						// Attempt to resolve the item at this position so tags are only placed over items which can be resolved
						var snapshotOffset = new TextSnapshotOffset(hitTestResult.Snapshot, hitTestResult.Offset);
						var resolutionResultSet = goToDefinitionService.PerformResolution(snapshotOffset);
						if (resolutionResultSet.Results.Count > 0) {

							// Update the currently tagged snapshot range to match the token
							currentTaggedSnapshotRange = new TextSnapshotRange(hitTestResult.Snapshot, currentToken.StartOffset, currentToken.EndOffset);

							// Output the resolver result
							resolverResult = resolutionResultSet.Results[0];

						}

					}

				}

			}

			if (oldSnapshotRange != currentTaggedSnapshotRange) {
				// Notify tags have changed
				InvalidateTags(oldSnapshotRange);
				InvalidateTags(currentTaggedSnapshotRange);
			}

			if (resolverResult is null) {
				// Clear any custom cursor when the pointer is not over a successfully tagged range
				ClearCustomCursor();
				return false;
			}
			else {
				// Apply a custom cursor when the pointer is over a successfully tagged range
				ApplyCustomCursor();
				return true;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Returns the tag ranges that intersect with the specified normalized snapshot ranges.
		/// </summary>
		/// <param name="snapshotRanges">The collection of normalized snapshot ranges.</param>
		/// <param name="parameter">An optional parameter that provides contextual information about the tag request.</param>
		/// <returns>The tag ranges that intersect with the specified normalized snapshot ranges.</returns>
		public override IEnumerable<TagSnapshotRange<IClassificationTag>> GetTags(NormalizedTextSnapshotRangeCollection snapshotRanges, object parameter) {
			// Quit if the range is undefined or zero-length
			if (currentTaggedSnapshotRange.IsDeleted || currentTaggedSnapshotRange.IsZeroLength)
				yield break;

			// Loop through the requested snapshot ranges...
			foreach (var snapshotRange in snapshotRanges) {
				if (!snapshotRange.IsZeroLength
					&& snapshotRange.Contains(currentTaggedSnapshotRange)) {

					// Yield a tag for the current range
					yield return new TagSnapshotRange<IClassificationTag>(
						currentTaggedSnapshotRange,
						new ClassificationTag(goToDefinitionClassificationType)
						);

					// There is only ever a single tag, so no additional processing is necessary
					yield break;
				}
			}
		}

		/// <summary>
		/// Notifies when a key is pressed down while focus is in the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <c>KeyEventArgs</c> that contains the event data.</param>
		public void NotifyKeyDown(KeyEventArgs e) {
			if (DoesKeyImpactTagging(e.KeyData)
				&& lastMouseLocation.HasValue) {
				// The state of the modifier key has changed, so tagging should be updated
				UpdateTaggedRange(lastMouseLocation.Value);
			}
		}

		/// <summary>
		/// Notifies when a key is released while focus is in the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <c>KeyEventArgs</c> that contains the event data.</param>
		public void NotifyKeyUp(KeyEventArgs e) {
			if (DoesKeyImpactTagging(e.KeyData)
				&& lastMouseLocation.HasValue) {
				// The state of the modifier key has changed, so tagging should be updated
				UpdateTaggedRange(lastMouseLocation.Value);
			}
		}

		/// <summary>
		/// Occurs when the pointer leaves the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <see cref="InputPointerEventArgs"/> that contains the event data.</param>
		public void NotifyPointerExited(InputPointerEventArgs e) {
			// Clear the previously cached mouse location
			lastMouseLocation = null;

			// Make sure tags and custom cursors are cleared when the mouse leaves
			if (!currentTaggedSnapshotRange.IsDeleted) {
				InvalidateTags(currentTaggedSnapshotRange);
				currentTaggedSnapshotRange = TextSnapshotRange.Deleted;
			}
			ClearCustomCursor();
		}

		/// <summary>
		/// Occurs when the pointer is moved over the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <see cref="InputPointerEventArgs"/> that contains the event data.</param>
		public void NotifyPointerMoved(InputPointerEventArgs e) {
			// Cache the current mouse location
			lastMouseLocation = e.GetPosition(view.SyntaxEditor);

			// Update the tagged range for the current mouse position
			UpdateTaggedRange(lastMouseLocation.Value);
		}

		/// <summary>
		/// Occurs when a pointer button is pressed over the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <see cref="InputPointerButtonEventArgs"/> that contains the event data.</param>
		public void NotifyPointerPressed(InputPointerButtonEventArgs e) {
			if (e.ButtonKind == InputPointerButtonKind.Primary && UpdateTaggedRange(e.GetPosition(view.SyntaxEditor))) {
				// Block the editor from picking up the click over the URL
				e.Handled = true;
			}
		}

		/// <summary>
		/// Occurs when a pointer button is released over the <see cref="IEditorView"/> for this tagger.
		/// </summary>
		/// <param name="e">The <see cref="InputPointerButtonEventArgs"/> that contains the event data.</param>
		public void NotifyPointerReleased(InputPointerButtonEventArgs e) {
			if (e.ButtonKind == InputPointerButtonKind.Primary
				&& UpdateTaggedRange(e.GetPosition(view.SyntaxEditor), out var resolverResult)) {
				// The user has performed a single left-click on an item, so attempt to go to definition
				e.Handled = true;
				goToDefinitionService.NavigateToDefinition(resolverResult);

				// Set focus to the view since the click event was not allowed to be processed by SyntaxEditor
				view.Focus(FocusState.Programmatic);
			}

		}

		/// <summary>
		/// Occurs when the tagger is closed.
		/// </summary>
		protected override void OnClosed() {
			// Clear any custom cursor that might be in effect
			ClearCustomCursor();

			base.OnClosed();
		}

	}

}
