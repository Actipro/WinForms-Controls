using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptParameterInfo {

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
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Simple-Advanced.langdef");

			// Register an IParameterInfoProvider service with the language so that the language can automatically generate
			//   parameter info popups
			editor.Document.Language.RegisterService<IParameterInfoProvider>(new CustomParameterInfoProvider());
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnShowParameterInfoButtonClick(object sender, EventArgs e) {
			// Focus the editor
			editor.ActiveView.Focus();

			// Get the IParameterInfoProvider that is registered with the language
			IParameterInfoProvider provider = editor.Document.Language.GetService<IParameterInfoProvider>();
			if (provider != null) {
				// Request that a session is created 
				provider.RequestSession(editor.ActiveView);
			}
		}

	}
}
