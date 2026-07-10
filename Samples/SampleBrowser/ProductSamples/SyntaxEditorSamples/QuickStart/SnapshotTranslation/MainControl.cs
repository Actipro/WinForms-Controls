using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotTranslation;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private readonly ITextSnapshot _originalSnapshot;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Load a language from a language definition
		topEditor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
		bottomEditor.Document.Language = topEditor.Document.Language;

		// Store the original snapshot of the bottom document
		_originalSnapshot = bottomEditor.Document.CurrentSnapshot;

		// Update the top document with the same content as the bottom
		topEditor.Document.SetText(_originalSnapshot.Text);

	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnUpdateSelectionButtonClick(object sender, EventArgs e) {
		var currentSnapshot = bottomEditor.ActiveView.CurrentSnapshot;
		var textRange = topEditor.ActiveView.Selection.TextRange.Translate(_originalSnapshot, currentSnapshot, TextRangeTrackingModes.Default);
		if (textRange.HasValue)
			bottomEditor.ActiveView.Selection.TextRange = textRange.Value;
		bottomEditor.Focus();
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
				bottomEditorLabel,
				heading1Label,
				heading2Label,
				heading3Label,
				topEditorLabel,
				updateSelectionButton,
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}
	}

}
