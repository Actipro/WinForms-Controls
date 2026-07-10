using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.HighlightingStyleViewer;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private bool _ignoreUpdateRequest;
	private IClassificationType? _selectedClassificationType;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Load a language from a language definition
		editor.Document.Language = new CSharpSyntaxLanguage();

		// Register the default built-in classification types on the ambient registry
		new BuiltInClassificationTypeProvider().RegisterAll();

		// Set the registry on the preview
		textStylePreview.HighlightingStyleRegistry = AmbientHighlightingStyleRegistry.Instance;

		// Populate the classification types list
		classificationTypeListBox.DisplayMember = nameof(IClassificationType.Description);
		foreach (var classificationType in AmbientHighlightingStyleRegistry.Instance.ClassificationTypes)
			classificationTypeListBox.Items.Add(classificationType);
		if (classificationTypeListBox.Items.Count > 0)
			classificationTypeListBox.SelectedItem = classificationTypeListBox.Items[0];
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Returns a resolved nullable color.
	/// </summary>
	/// <param name="color">The color to examine.</param>
	private static Color? GetResolvedColor(Color color)
		=> ((color.IsEmpty) || (color == Color.Transparent)) ? null : color;

	/// <summary>
	/// Occurs when a highlighting style update is needed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnUpdateHighlightingStyle(object sender, EventArgs e) {
		this.UpdateHighlightingStyle();
	}

	/// <summary>
	/// Updates the selected style with the current settings and updates the controls.
	/// </summary>
	private void UpdateHighlightingStyle() {
		if (_ignoreUpdateRequest)
			return;

		// Update old selected style
		if (_selectedClassificationType is not null) {
			var selectedHighlightingStyle = AmbientHighlightingStyleRegistry.Instance[_selectedClassificationType];
			if (selectedHighlightingStyle is not null) {
				selectedHighlightingStyle.Foreground = GetResolvedColor(foreColorButton.Color);
				selectedHighlightingStyle.Background = GetResolvedColor(backColorButton.Color);
				selectedHighlightingStyle.BorderColor = GetResolvedColor(borderColorButton.Color);
				selectedHighlightingStyle.Bold = boldCheckBox.Checked;
				selectedHighlightingStyle.Italic = italicCheckBox.Checked;
			}
		}

		if (classificationTypeListBox.SelectedItems.Count == 0)
			return;

		try {
			_ignoreUpdateRequest = true;

			// Update controls
			_selectedClassificationType = (IClassificationType)classificationTypeListBox.SelectedItems[0]!;
			var selectedHighlightingStyle = AmbientHighlightingStyleRegistry.Instance[_selectedClassificationType];
			if (selectedHighlightingStyle is not null) {
				foreColorButton.Color = selectedHighlightingStyle.Foreground ?? Color.Empty;
				foreColorButton.Enabled = selectedHighlightingStyle.IsForegroundEditable;
				backColorButton.Color = selectedHighlightingStyle.Background ?? Color.Empty;
				backColorButton.Enabled = selectedHighlightingStyle.IsBackgroundEditable;
				borderColorButton.Color = selectedHighlightingStyle.BorderColor ?? Color.Empty;
				borderColorButton.Enabled = selectedHighlightingStyle.IsBorderEditable;
				boldCheckBox.Checked = (selectedHighlightingStyle.Bold == true);
				boldCheckBox.Enabled = selectedHighlightingStyle.IsBoldEditable;
				italicCheckBox.Checked = (selectedHighlightingStyle.Italic == true);
				italicCheckBox.Enabled = selectedHighlightingStyle.IsItalicEditable;

				// Update preview
				textStylePreview.HighlightingStyle = selectedHighlightingStyle;
			}
			else
				textStylePreview.HighlightingStyle = null;
		}
		finally {
			_ignoreUpdateRequest = false;
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
				introLabel,
				itemForegroundLabel,
				foreColorButton,
				itemBackgroundLabel,
				backColorButton,
				itemBorderLabel,
				borderColorButton,
				sampleEditorLabel,
				displayItemsLabel,
				classificationTypeListBox,
				boldCheckBox,
				italicCheckBox
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}

		if (!Program.IsControlSizeScalingHandledByRuntime) {
			// Manually scale sizes
			var manualSizeControl = new Control[] {
				textStylePreview,
				foreColorButton,
				backColorButton,
				borderColorButton
			};
			foreach (var control in manualSizeControl)
				control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
		}
	}

}
