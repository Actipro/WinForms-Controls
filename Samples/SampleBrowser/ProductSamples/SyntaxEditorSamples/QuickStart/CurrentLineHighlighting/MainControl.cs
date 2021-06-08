using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CurrentLineHighlighting {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Css.langdef");

			// Register the default display item classification types on the ambient registry
			DisplayItemClassificationTypeProvider provider = new DisplayItemClassificationTypeProvider();
			provider.RegisterAll();

			// This is how the style for the current line highlight can be retrieved for color customization
			// var style = AmbientHighlightingStyleRegistry.Instance[provider.CurrentLine];

			// Initialize the UI to match the default editor properties
			isHighlightingEnabledCheckBox.Checked = editor.IsCurrentLineHighlightingEnabled;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnIsHighlightingEnabledCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsCurrentLineHighlightingEnabled = isHighlightingEnabledCheckBox.Checked;
		}

	}
}
