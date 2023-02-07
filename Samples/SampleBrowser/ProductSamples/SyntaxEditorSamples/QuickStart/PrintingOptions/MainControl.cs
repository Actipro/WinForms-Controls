using System;
using System.Diagnostics;
using System.Windows.Forms;
using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted15;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrintingOptions {

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

			// Configure a column guide
			editor.ColumnGuides.Add(80);

			// Set a syntax language
			editor.Document.Language = new SimpleSyntaxLanguage();

			// Initialize view based on default print settings properties
			documentTitleCheckBox.Checked = editor.PrintSettings.IsDocumentTitleMarginVisible;
			lineNumberCheckBox.Checked = editor.PrintSettings.IsLineNumberMarginVisible;
			pageNumbersCheckBox.Checked = editor.PrintSettings.IsPageNumberMarginVisible;
			wordWrapCheckBox.Checked = editor.PrintSettings.IsWordWrapGlyphMarginVisible;
			whitespaceCheckBox.Checked = editor.PrintSettings.IsWhitespaceVisible;
			highlightingCheckBox.Checked = editor.PrintSettings.IsSyntaxHighlightingEnabled;
			collapsedNodesCheckBox.Checked = editor.PrintSettings.AreCollapsedOutliningNodesAllowed;
			columnGuidesCheckBox.Checked = editor.PrintSettings.AreColumnGuidesVisible;
			indentationGuidesCheckBox.Checked = editor.PrintSettings.AreIndentationGuidesVisible;
			squiggleLinesCheckBox.Checked = editor.PrintSettings.AreSquiggleLinesVisible;
			documentTitleTextBox.Text = editor.PrintSettings.DocumentTitle;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnCollapsedNodesCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.AreCollapsedOutliningNodesAllowed = collapsedNodesCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnColumnGuidesCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.AreColumnGuidesVisible = columnGuidesCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnDocumentTitleCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsDocumentTitleMarginVisible = documentTitleCheckBox.Checked;
		}
		
		/// <summary>
		/// Occurs when the text is changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnDocumentTitleTextBoxTextChanged(object sender, EventArgs e) {
			editor.PrintSettings.DocumentTitle = documentTitleTextBox.Text;
		}
		
		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnHighlightingCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsSyntaxHighlightingEnabled = highlightingCheckBox.Checked;
		}
		
		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnIndentationGuidesCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.AreIndentationGuidesVisible = indentationGuidesCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnLineNumberCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsLineNumberMarginVisible = lineNumberCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnPageNumbersCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsPageNumberMarginVisible = pageNumbersCheckBox.Checked;
		}
		
		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnShowPrintPreviewDialogButtonClick(object sender, EventArgs e) {
			try {
				editor.ShowPrintPreviewDialog();
			}
			catch (Exception ex) {
				Debug.WriteLine($"Error executing command.  {ex}");
				MessageBox.Show($"Error executing command.  {ex.Message}", "Error Executing Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSquiggleLinesCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.AreSquiggleLinesVisible = squiggleLinesCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnWhitespaceCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsWhitespaceVisible = whitespaceCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnWordWrapCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.PrintSettings.IsWordWrapGlyphMarginVisible = wordWrapCheckBox.Checked;
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
					collapsedNodesCheckBox,
					columnGuidesCheckBox,
					documentTitleCheckBox,
					documentTitleLabel,
					documentTitleTextBox,
					highlightingCheckBox,
					indentationGuidesCheckBox,
					lineNumberCheckBox,
					pageNumbersCheckBox,
					showPrintPreviewDialogButton,
					squiggleLinesCheckBox,
					wordWrapCheckBox,
					whitespaceCheckBox,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					documentTitleTextBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
