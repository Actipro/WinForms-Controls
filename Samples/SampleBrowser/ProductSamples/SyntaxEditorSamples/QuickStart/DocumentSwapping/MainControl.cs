using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSwapping {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private readonly List<EditorDocument> editorDocuments;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			editorDocuments = new List<EditorDocument>();

			// Create the first document
			var document1 = new EditorDocument();
			document1.FileName = "Document #1";
			document1.Text = @"This is the first document.

When you select a different IEditorDocument in the ComboBox above, the newly selected IEditorDocument will be swapped into the SyntaxEditor.  This is all accomplished in this sample via XAML bindings.

Try typing in some of the documents and then switching to others and switching back.  You'll see your changes when a previously-modified document is restored into the editor.  This shows how you can hold multiple documents in memory and easily swap them in and out of a SyntaxEditor instance.";
			editorDocuments.Add(document1);

			// Create the second document
			var document2 = new EditorDocument();
			document2.FileName = "Document #2";
			document2.Text = "This is the second document.";
			editorDocuments.Add(document2);

			// Create the third document
			var document3 = new EditorDocument();
			document3.FileName = "Document #3";
			document3.Text = "This is the third document.";
			editorDocuments.Add(document3);

			// Load the file names in the document combo box based on their index in the list
			foreach (var document in editorDocuments)
				documentComboBox.Items.Add(document.FileName);
			documentComboBox.SelectedIndex = 0;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the selected index of the combo box changes.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnDocumentComboBoxSelectedIndexChanged(object sender, EventArgs e) {
			// Swap in the document that corresponds to the current index
			editor.Document = editorDocuments[documentComboBox.SelectedIndex];
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
					documentComboBox,
					documentLabel
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					documentComboBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);

				// Correct auto-scale, auto-size issue by sizing the document panel to match the combobox
				documentPanel.Size = documentComboBox.Size;
			}

		}

	}

}
