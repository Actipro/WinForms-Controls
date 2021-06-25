using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrinterViewMarginsCustom {

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

			// Add a custom margin factory
			editor.PrintSettings.ViewMarginFactories.Add(new CustomMarginFactory());
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

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
	}
}
