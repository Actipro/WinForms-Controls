using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotTranslation {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private ITextSnapshot originalSnapshot;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			topEditor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
			bottomEditor.Document.Language = topEditor.Document.Language;

			// Store the original snapshot of the bottom document
			originalSnapshot = bottomEditor.Document.CurrentSnapshot;

			// Update the top document with the same content as the bottom
			topEditor.Document.SetText(originalSnapshot.Text);

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUpdateSelectionButtonClick(object sender, EventArgs e) {
			ITextSnapshot currentSnapshot = bottomEditor.ActiveView.CurrentSnapshot;
			TextRange textRange = topEditor.ActiveView.Selection.TextRange.Translate(originalSnapshot, currentSnapshot, TextRangeTrackingModes.Default);
			bottomEditor.ActiveView.Selection.TextRange = textRange;
			bottomEditor.Focus();
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
					bottomEditorLabel,
					heading1Label,
					heading2Label,
					heading3Label,
					topEditorLabel,
					updateSelectionButton,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
