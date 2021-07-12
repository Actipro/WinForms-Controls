using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03c;
using ActiproSoftware.Text;
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
	}
}
