namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsLocations;

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

		// Add a custom margin factory
		editor.ViewMarginFactories.Add(new CustomMarginFactory());
	}

}
