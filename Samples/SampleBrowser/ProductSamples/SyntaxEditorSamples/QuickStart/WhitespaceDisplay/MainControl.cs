using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03c;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WhitespaceDisplay {

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

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnIsWhitespaceVisibleCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsWhitespaceVisible = isWhiteSpaceVisibleCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the value changes in the track bar.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnTabSizeTrackBarValueChanged(object sender, EventArgs e) {
			editor.Document.TabSize = tabSizeTrackBar.Value;
			tabSizeCurrentValueLabel.Text = editor.Document.TabSize.ToString();
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
					isWhiteSpaceVisibleCheckBox,                
					tabSizeCurrentValueLabel,
					tabSizeLabel,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					tabSizeTrackBar             
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
