using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSwapping;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private readonly List<EditorDocument> _editorDocuments = [];

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Create the first document
		var document1 = new EditorDocument { FileName = "Document #1" };
		document1.SetText(@"This is the first document.

When you select a different IEditorDocument in the ComboBox above, the newly selected IEditorDocument will be swapped into the SyntaxEditor.  This is all accomplished in this sample via XAML bindings.

Try typing in some of the documents and then switching to others and switching back.  You'll see your changes when a previously-modified document is restored into the editor.  This shows how you can hold multiple documents in memory and easily swap them in and out of a SyntaxEditor instance.");
		_editorDocuments.Add(document1);

		// Create the second document
		var document2 = new EditorDocument { FileName = "Document #2" };
		document2.SetText("This is the second document.");
		_editorDocuments.Add(document2);

		// Create the third document
		var document3 = new EditorDocument { FileName = "Document #3" };
		document3.SetText("This is the third document.");
		_editorDocuments.Add(document3);

		// Load the file names in the document combo box based on their index in the list
		foreach (var document in _editorDocuments)
			documentComboBox.Items.Add(document.FileName!);
		documentComboBox.SelectedIndex = 0;
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the selected index of the combo box changes.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDocumentComboBoxSelectedIndexChanged(object sender, EventArgs e) {
		// Swap in the document that corresponds to the current index
		editor.Document = _editorDocuments[documentComboBox.SelectedIndex];
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

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
