using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ScrollBarVisibility {

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
			editor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("JavaScript.langdef");

			// Define available scrollbar options
			var visibilityOptions = Enum.GetValues(typeof(ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.ScrollBarVisibility)).OfType<object>().ToArray();
			horizontalScrollBarComboBox.Items.AddRange(visibilityOptions);
			verticalScrollBarComboBox.Items.AddRange(visibilityOptions);
			RefreshScrollBarVisibilityComboBoxSelections();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnHorizontalScrollBarComboBoxSelectedValueChanged(object sender, EventArgs e) {
			if (horizontalScrollBarComboBox.SelectedItem is ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.ScrollBarVisibility) {
				editor.HorizontalScrollBarVisibility = (ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.ScrollBarVisibility)horizontalScrollBarComboBox.SelectedItem;
			}
		}

		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnVerticalScrollBarComboBoxSelectedValueChanged(object sender, EventArgs e) {
			if (verticalScrollBarComboBox.SelectedItem is ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.ScrollBarVisibility) {
				editor.VerticalScrollBarVisibility = (ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.ScrollBarVisibility)verticalScrollBarComboBox.SelectedItem;
			}
		}

		/// <summary>
		/// Updates the UI controls which represent the current status of the outlining configuration.
		/// </summary>
		private void RefreshScrollBarVisibilityComboBoxSelections() {
			horizontalScrollBarComboBox.SelectedItem = editor.HorizontalScrollBarVisibility;
			verticalScrollBarComboBox.SelectedItem = editor.VerticalScrollBarVisibility;
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
					horizontalScrollBarComboBox,
					horizontalScrollBarLabel,
					verticalScrollBarComboBox,
					verticalScrollBarLabel,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					horizontalScrollBarComboBox,
					verticalScrollBarComboBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
