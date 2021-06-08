using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SearchResultHighlighting {

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
			editor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("JavaScript.langdef");

			// Ensure all classification types and related styles have been registered
			//   since classification types are used for the highlight display
			new DisplayItemClassificationTypeProvider().RegisterAll();

			// Refresh highlights
			this.RefreshHighlights();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////


		/// <summary>
		/// Occurs when the control becomes the active control on the form.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFindWhatTextBoxEnter(object sender, EventArgs e) {
			this.RefreshHighlights();
		}

		/// <summary>
		/// Occurs when the text is changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFindWhatTextBoxTextChanged(object sender, EventArgs e) {
			this.RefreshHighlights();
		}

		/// <summary>
		/// Refreshes the highlights.
		/// </summary>
		private void RefreshHighlights() {
			if (editor == null)
				return;

			var options = new EditorSearchOptions();
			options.FindText = findWhatTextBox.Text;
			editor.ActiveView.HighlightedResultSearchOptions = options;
		}

	}
}
