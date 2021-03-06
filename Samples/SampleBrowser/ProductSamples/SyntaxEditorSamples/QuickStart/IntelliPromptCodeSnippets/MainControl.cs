using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptCodeSnippets {

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

			// Register a code snippet provider that has several snippets available
			ICodeSnippetFolder snippetFolder = SyntaxEditorHelper.LoadSampleJavascriptCodeSnippetsFromResources();
			editor.Document.Language.RegisterService(new CodeSnippetProvider() { RootFolder = snippetFolder });

			// Ensure all classification types and related styles have been registered
			//   since classification types are used for code snippet field display
			new DisplayItemClassificationTypeProvider().RegisterAll();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnInsertSnippetButtonClick(object sender, EventArgs e) {
			editor.ActiveView.IntelliPrompt.RequestInsertSnippetSession();
		}

	}
}
