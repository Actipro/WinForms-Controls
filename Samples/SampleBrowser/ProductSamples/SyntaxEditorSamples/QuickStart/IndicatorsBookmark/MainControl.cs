using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsBookmark {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("JavaScript.langdef");

			// Add some indicators
			this.ToggleIndicator(editor.ActiveView.CurrentSnapshot.Lines[15]);
			editor.Document.IndicatorManager.Bookmarks.ToggleEnabledState(this.ToggleIndicator(editor.ActiveView.CurrentSnapshot.Lines[17]).Tag);
			this.ToggleIndicator(editor.ActiveView.CurrentSnapshot.Lines[24]);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnClearIndicatorsToolStripButtonClick(object sender, EventArgs e) {
			// Clear the tags
			editor.Document.IndicatorManager.Bookmarks.Clear();

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnGoToNextIndicatorToolStripButtonClick(object sender, EventArgs e) {
			// Create search options (only find enabled bookmarks)
			var options = new TagSearchOptions<BookmarkIndicatorTag>();
			options.CanWrap = true;
			options.SearchUp = false;
			options.Filter = (tr => tr.Tag.IsEnabled);

			// Find the next indicator
			var tagRange = editor.Document.IndicatorManager.Bookmarks.FindNext(editor.ActiveView.Selection.EndSnapshotOffset.Line, options);
			if (tagRange != null) {
				// Move the caret
				editor.ActiveView.Selection.CaretOffset = tagRange.VersionRange.Translate(editor.ActiveView.CurrentSnapshot).StartOffset;
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousIndicatorToolStripButtonClick(object sender, EventArgs e) {
			// Create search options (only find enabled bookmarks)
			var options = new TagSearchOptions<BookmarkIndicatorTag>();
			options.CanWrap = true;
			options.SearchUp = true;
			options.Filter = (tr => tr.Tag.IsEnabled);

			// Find the previous indicator
			var tagRange = editor.Document.IndicatorManager.Bookmarks.FindNext(editor.ActiveView.Selection.EndSnapshotOffset.Line, options);
			if (tagRange != null) {
				// Move the caret
				editor.ActiveView.Selection.CaretOffset = tagRange.VersionRange.Translate(editor.ActiveView.CurrentSnapshot).StartOffset;
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnToggleIndicatorToolStripButtonClick(object sender, EventArgs e) {
			// Toggle an indicator
			this.ToggleIndicator(editor.ActiveView.Selection.EndSnapshotOffset.Line);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnToggleBookmarkEnabledToolStripButtonClick(object sender, EventArgs e) {
			// Get the bookmarks at the caret and toggle their enabled states
			var tagRanges = editor.Document.IndicatorManager.Bookmarks.GetInstances(editor.ActiveView.Selection.EndSnapshotOffset.Line);
			var count = 0;
			foreach (var tagRange in tagRanges) {
				if (editor.Document.IndicatorManager.Bookmarks.ToggleEnabledState(tagRange.Tag))
					count++;
			}

			if (count == 0)
				MessageBox.Show("No bookmarks were found at the caret.", "Toggle Bookmark Enabled State", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Toggles an indicator.
		/// </summary>
		/// <param name="snapshotLine">The <see cref="ITextSnapshotLine"/> of the indicator.</param>
		/// <returns>The tagged range that was created, if any.</returns>
		private TagVersionRange<BookmarkIndicatorTag> ToggleIndicator(ITextSnapshotLine snapshotLine) {
			return editor.Document.IndicatorManager.Bookmarks.Toggle(snapshotLine);
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
					mainToolStrip,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}
}
