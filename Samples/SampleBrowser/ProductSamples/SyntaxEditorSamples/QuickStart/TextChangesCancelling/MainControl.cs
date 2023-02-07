using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03c;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.TextChangesCancelling {

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

			// Load the simple syntax language from the getting started series
			editor.Document.Language = new SimpleSyntaxLanguage();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		private void OnEditorDocumentTextChanging(object sender, UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangingEventArgs e) {
			e.Cancel = (cancelCheckBox.Checked);

			if (e.Cancel) {
				if (alternateTextCheckBox.Checked) {
					// Temporarily turn off cancel and insert date/time instead
					cancelCheckBox.Checked = false;
					editor.ActiveView.ReplaceSelectedText(TextChangeTypes.Custom, DateTime.Now.ToString());
					cancelCheckBox.Checked = true;
					MessageBox.Show("Text change canceled, current date/time inserted instead.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else {
					// Simple cancel
					MessageBox.Show("Text change canceled.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
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
					alternateTextCheckBox,
					cancelCheckBox,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
