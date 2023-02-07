﻿using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
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

			// Load a language from a language definition
			xmlEditor.Document.Language = new XmlSyntaxLanguage();
			cSharpEditor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
			formulaEditor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CustomFormula.langdef");

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
			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
				resolver.AddSchemaFromStream(stream);
			}
			xmlEditor.Document.Language.RegisterXmlSchemaResolver(resolver);

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
					cSharpEditorLabel,
					formulaEditorLabel,
					headerLabel,
					xmlEditorLabel,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
