using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
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
			RefreshWordWrapModeComboBoxSelections();
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
		private void OnWordWrapModeComboBoxSelectedValueChanged(object sender, EventArgs e) {
			if (wordWrapModeComboBox.SelectedItem is ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode) {
				editor.WordWrapMode = (ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode)wordWrapModeComboBox.SelectedItem;
			}
		}


		/// <summary>
		/// Updates the UI controls which represent the current status of the outlining configuration.
		/// </summary>
		private void RefreshWordWrapModeComboBoxSelections() {
			wordWrapModeComboBox.SelectedItem = editor.WordWrapMode;
		}

	}
}
