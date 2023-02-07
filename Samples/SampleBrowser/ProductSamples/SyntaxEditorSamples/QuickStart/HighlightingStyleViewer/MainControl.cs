using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.HighlightingStyleViewer {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {
		
		private bool						ignoreUpdateRequest;
		private IClassificationType			selectedClassificationType;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = new CSharpSyntaxLanguage();

			// Register the default display item classification types on the ambient registry
			new DisplayItemClassificationTypeProvider().RegisterAll();

			// Set the registry on the preview
			textStylePreview.HighlightingStyleRegistry = AmbientHighlightingStyleRegistry.Instance;

			// Populate the classification types list
			classificationTypeListBox.DisplayMember = nameof(IClassificationType.Description);
			foreach (var classificationType in AmbientHighlightingStyleRegistry.Instance.ClassificationTypes)
				classificationTypeListBox.Items.Add(classificationType);
			if (classificationTypeListBox.Items.Count > 0)
				classificationTypeListBox.SelectedItem = classificationTypeListBox.Items[0];
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Returns a resolved nullable color.
		/// </summary>
		/// <param name="color">The color to examine.</param>
		/// <returns>The resolved nullable color.</returns>
		private static Color? GetResolvedColor(Color color) {
			if (color.IsEmpty)
				return null;
			else if (color == Color.Transparent)
				return null;
			else
				return color;
		}

		/// <summary>
		/// Occurs when a highlighting style update is needed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUpdateHighlightingStyle(object sender, EventArgs e) {
			this.UpdateHighlightingStyle();
		}

		/// <summary>
		/// Updates the selected style with the current settings and updates the controls.
		/// </summary>
		private void UpdateHighlightingStyle() {
			if (ignoreUpdateRequest)
				return;

			// Update old selected style
			if (selectedClassificationType != null) {
				var selectedHighlightingStyle = AmbientHighlightingStyleRegistry.Instance[selectedClassificationType];
				if (selectedHighlightingStyle != null) {
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
				ignoreUpdateRequest = true;

				// Update controls
				selectedClassificationType = (IClassificationType)classificationTypeListBox.SelectedItems[0];
				var selectedHighlightingStyle = AmbientHighlightingStyleRegistry.Instance[selectedClassificationType];
				if (selectedHighlightingStyle != null) {
					foreColorButton.Color = selectedHighlightingStyle.Foreground.HasValue ? selectedHighlightingStyle.Foreground.Value : Color.Empty;
					foreColorButton.Enabled = selectedHighlightingStyle.IsForegroundEditable;
					backColorButton.Color = selectedHighlightingStyle.Background.HasValue ? selectedHighlightingStyle.Background.Value : Color.Empty;
					backColorButton.Enabled = selectedHighlightingStyle.IsBackgroundEditable;
					borderColorButton.Color = selectedHighlightingStyle.BorderColor.HasValue ? selectedHighlightingStyle.BorderColor.Value : Color.Empty;
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
				ignoreUpdateRequest = false;
			}
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

}
