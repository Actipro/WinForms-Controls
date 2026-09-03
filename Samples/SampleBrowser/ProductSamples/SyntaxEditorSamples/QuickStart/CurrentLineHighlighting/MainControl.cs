using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CurrentLineHighlighting;

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

		// Load a language from a language definition
		editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Css.langdef");

		// Register the default built-in classification types on the ambient registry
		var provider = new BuiltInClassificationTypeProvider();
		provider.RegisterAll();

		// This is how the style for the current line or line number highlights can be retrieved for color customization
		//
		// using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
		// ...
		//
		// var currentLineStyle = AmbientHighlightingStyleRegistry.Instance[provider.CurrentLine];
		// var currentLineNumberStyle = AmbientHighlightingStyleRegistry.Instance[provider.LineNumberCurrent];

		// Initialize the UI to match the default editor properties
		isHighlightingEnabledCheckBox.Checked = editor.IsCurrentLineHighlightingEnabled;
		isLineNumberHighlightingEnabledCheckBox.Checked = editor.IsCurrentLineNumberHighlightingEnabled;
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the checkbox is checked or unchecked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnIsHighlightingEnabledCheckBoxCheckedChanged(object sender, EventArgs e) {
		editor.IsCurrentLineHighlightingEnabled = isHighlightingEnabledCheckBox.Checked;
	}

	/// <summary>
	/// Occurs when the checkbox is checked or unchecked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnIsLineNumberHighlightingEnabledCheckBoxCheckedChanged(object sender, EventArgs e) {
		editor.IsCurrentLineNumberHighlightingEnabled = isLineNumberHighlightingEnabledCheckBox.Checked;
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
				isHighlightingEnabledCheckBox,
				isLineNumberHighlightingEnabledCheckBox
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}
	}

}
