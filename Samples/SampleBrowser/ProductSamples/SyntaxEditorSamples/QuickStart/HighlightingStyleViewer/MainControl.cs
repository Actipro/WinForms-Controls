using ActiproSoftware.Text;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
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
			foreach (var classificationType in AmbientHighlightingStyleRegistry.Instance.ClassificationTypes)
				classificationTypeListView.Items.Add(new ListViewItem(classificationType.Description) { Tag = classificationType });
			classificationTypeListView.Items[0].Selected = true;
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

			if (classificationTypeListView.SelectedItems.Count == 0)
				return;

			try {
				ignoreUpdateRequest = true;
			
				// Update controls
				selectedClassificationType = (IClassificationType)classificationTypeListView.SelectedItems[0].Tag;
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

	}
}
