using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WordWrap {

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

			// Define available word wrap options
			var wordWrapOptions = Enum.GetValues(typeof(ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode)).OfType<object>().ToArray();
			wordWrapModeComboBox.Items.AddRange(wordWrapOptions);
			RefreshComboBoxSelections();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnAreGlyphsVisibleCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.AreWordWrapGlyphsVisible = areGlyphsVisibleCheckBox.Checked;
		}
		
		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnIndentAmountComboBoxSelectedValueChanged(object sender, EventArgs e) {
			editor.WrappedLineIndentAmount = indentAmountComboBox.SelectedIndex - 1;
		}

		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnWordWrapModeComboBoxSelectedValueChanged(object sender, EventArgs e) {
			if (wordWrapModeComboBox.SelectedItem is ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode) {
				editor.WordWrapMode = (ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode)wordWrapModeComboBox.SelectedItem;
			}
		}

		/// <summary>
		/// Updates the UI controls which represent the current status of the configuration.
		/// </summary>
		private void RefreshComboBoxSelections() {
			wordWrapModeComboBox.SelectedItem = editor.WordWrapMode;
			indentAmountComboBox.SelectedIndex = editor.WrappedLineIndentAmount + 1;
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
					areGlyphsVisibleCheckBox,
					wordWrapModeComboBox,               
					wordWrapModeLabel,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					wordWrapModeComboBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
