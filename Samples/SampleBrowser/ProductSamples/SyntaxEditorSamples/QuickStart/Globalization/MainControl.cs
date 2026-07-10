using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03c;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.Globalization;

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

		// Load a simple syntax language definition form the getting started series
		editor.Document.Language = new SimpleSyntaxLanguage();
	}

}
