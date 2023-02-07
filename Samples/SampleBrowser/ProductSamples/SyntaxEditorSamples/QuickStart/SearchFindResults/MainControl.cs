using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Searching;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SearchFindResults {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private ISearchResultSet lastResultSet;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
			
			// Ensure all classification types and related styles have been registered
			//   since classification types are used for the search result highlight display
			new DisplayItemClassificationTypeProvider().RegisterAll();

			// Set the default search options
			editor.SearchOptions.FindText = @"/// \s \< .+ \>";
			editor.SearchOptions.ReplaceText = "$&123";
			editor.SearchOptions.PatternProvider = SearchPatternProviders.RegularExpression;

			// Show the search overlay pane
			editor.ActiveView.OverlayPanes.AddSearch(true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when an overlay pane is opened.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="OverlayPaneEventArgs"/> that contains the event data.</param>
		private void OnEditorOverlayPaneOpened(object sender, OverlayPaneEventArgs e) {
			var pane = e.Pane as SearchOverlayPane;
			if (pane != null)
				pane.IsFindAllButtonVisible = true;
		}

		/// <summary>
		/// Occurs when the user executes a view search.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EditorViewSearchEventArgs"/> that contains the event data.</param>
		private void OnEditorViewSearch(object sender, EditorViewSearchEventArgs e) {
			this.UpdateResults(e.ResultSet);
		}
		
		/// <summary>
		/// Occurs when the mouse is double-clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="MouseButtonEventArgs"/> that contains the event data.</param>
		private void OnResultsTextBoxMouseDoubleClick(object sender, MouseEventArgs e) {
			// Quit if there is not result set stored yet
			if (lastResultSet == null)
				return;

			int charIndex = resultsTextBox.GetCharIndexFromPosition(e.Location);
			int lineIndex = resultsTextBox.GetLineFromCharIndex(charIndex);

			int resultIndex = lineIndex - 1;  // Account for first line in results displaying search info
			if ((resultIndex >= 0) && (resultIndex < lastResultSet.Results.Count)) {
				// A valid result was clicked
				ISearchResult result = lastResultSet.Results[resultIndex];
				if (result.ReplaceSnapshotRange.IsDeleted) {
					// Find result
					editor.ActiveView.Selection.SelectRange(result.FindSnapshotRange.TranslateTo(editor.ActiveView.CurrentSnapshot, TextRangeTrackingModes.Default).TextRange);
				}
				else {
					// Replace result
					editor.ActiveView.Selection.SelectRange(result.ReplaceSnapshotRange.TranslateTo(editor.ActiveView.CurrentSnapshot, TextRangeTrackingModes.Default).TextRange);
				}

				// Focus the editor
				editor.Focus();
			}
		}

		/// <summary>
		/// Updates the results.
		/// </summary>
		/// <param name="resultSet">The <see cref="ISearchResultSet"/> containing results.</param>
		private void UpdateResults(ISearchResultSet resultSet) {
			// Show the results
			resultsToolWindow.TitleBarText = String.Format("Find Results - {0} match{1}", resultSet.Results.Count, (resultSet.Results.Count == 1 ? String.Empty : "es"));
			resultsTextBox.Text = resultSet.ToString();

			// Save the result set
			lastResultSet = resultSet;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale control fonts
				var manualFontControls = new Control[] {
					resultsTextBox,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					resultsTextBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
