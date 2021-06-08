using System;
using System.Windows.Forms;
using ActiproSoftware.Text.Languages.JavaScript.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WebAddonJsonGettingStarted {

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
			
			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher within your 
			//   application OnStartup code, and add related cleanup in your application OnExit code.  
			//   These steps are essential to having the add-on perform well.
			//
			
			// Load the syntax language
			editor.Document.Language = new JsonSyntaxLanguage();
		}

	}
}
