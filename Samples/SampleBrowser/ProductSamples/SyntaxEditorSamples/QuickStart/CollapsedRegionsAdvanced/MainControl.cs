using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced;

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

		// Load the custom language from this sample
		editor.Document.Language = new CollapsedRegionSyntaxLanguage();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCollapseButtonClick(object sender, EventArgs e) {
		if (editor.ActiveView.Selection.IsZeroLength) {
			MessageBox.Show("Please select at least one character to collapse.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}

		// Get the tagger that was created by the language and has been persisted in the document's properties
		//   while the language is active on the document
		if (editor.Document.Properties.TryGetValue<CollapsedRegionTagger>(out var tagger)) {
			// Create a version range
			var versionRange = editor.ActiveView.Selection.SnapshotRange.ToVersionRange(TextRangeTrackingModes.DeleteWhenZeroLength);

			// Create a tag that will be used to both collapse text and drive an intra-text placeholder...
			//   Since the tags in this sample are persisted in a collection while active,
			//   the tag will use itself as the key (set using the CollapsedRegionTag constructor).
			// The key is used to retrieve the bounds of the spacer later on so adornments can be rendered
			//   in it, thus is must be unique
			var tag = new CollapsedRegionTag {
				Text = "...",
				Baseline = editor.ActiveView.VisibleViewLines[0].Baseline
			};

			// Measure the adornment
			using var g = editor.CreateGraphics();
			using var fontFamily = new FontFamily(editor.ActiveView.DefaultFontFamilyName);
			using var font = new Font(fontFamily, editor.ActiveView.DefaultFontSize, FontStyle.Regular);
			using var format = DrawingHelper.GetStringFormat(StringAlignment.Center, StringAlignment.Center);
			tag.Size = DrawingHelper.MeasureString(g, tag.Text, font, format);

			// Add the tag to the tagger
			tagger!.Add(new TagVersionRange<ICollapsedRegionTag>(versionRange, tag));
		}

		// Focus the editor
		editor.Focus();
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnUncollapseAllButtonClick(object sender, EventArgs e) {
		// Get the tagger that was created by the language and has been persisted in the document's properties
		//   while the language is active on the document
		if (editor.Document.Properties.TryGetValue<CollapsedRegionTagger>(out var tagger)) {
			// Clear all tags from the tagger
			tagger!.Clear();
		}
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
				collapseButton,
				uncollapseAllButton
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}
	}

}
