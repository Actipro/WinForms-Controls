namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ClassificationLineStart;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Load the custom syntax language defined in this sample
		editor.Document.Language = new CustomSyntaxLanguage();
	}

}
