using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SingleLineMode {

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

			// Finalize component initialization
			xmlEditor.Font = xmlEditorLabel.Font;
			ResizeControls();

			// Load a language from a language definition
			xmlEditor.Document.Language = new XmlSyntaxLanguage();
			cSharpEditor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

			// For the HTML text box that uses the Web Languages Add-on, the following code is needed:

			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher within your 
			//   application OnStartup code, and add related cleanup in your application OnExit code.  
			//   These steps are essential to having the add-on perform well.
			//

			// Register the schema resolver service with the XML language (needed to support IntelliPrompt for HTML)
			var resolver = new XmlSchemaResolver();
			resolver.DefaultNamespace = "http://www.w3.org/1999/xhtml";
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.xsd")) {
				resolver.AddSchemaFromStream(stream);
			}
			// Xml.xsd is also required for Xhtml.xsd
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XML.xsd")) {
				resolver.AddSchemaFromStream(stream);
			}
			xmlEditor.Document.Language.RegisterXmlSchemaResolver(resolver);

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the control is resized.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnContentPanelResize(object sender, EventArgs e) {
			ResizeControls();
		}

		/// <summary>
		/// Resizes controls on the form based on current conditions.
		/// </summary>
		private void ResizeControls() {
			// Adjust label maximimum width to allow for proper word-wrapping when auto-sized and docked
			foreach (var label in contentPanel.Controls.OfType<Label>()) {
				label.MaximumSize = new System.Drawing.Size(contentPanel.Width, 0);
			}
		}

	}
}
