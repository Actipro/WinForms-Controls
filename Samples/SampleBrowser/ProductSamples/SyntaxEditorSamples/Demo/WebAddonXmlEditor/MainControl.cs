using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonXmlEditor {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private int						documentNumber;
		private bool					hasPendingParseData;
		private DocumentWindow			schemaDocumentWindow;
		private SyntaxEditor			schemaEditor;
		private XmlSchemaResolver		schemaResolver = new XmlSchemaResolver();
		private NavigableSymbolSelector	symbolSelector;
		private DocumentWindow			xmlDocumentWindow;
		private SyntaxEditor			xmlEditor;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize initialization
			DpiHelper.RescaleListViewColumns(errorListView, DpiHelper.DefaultDeviceDpi, DpiHelper.GetSystemDeviceDpi());

			// Set the AST output tab stop width
			astOutputEditor.SetTabStopWidth(1);

			// Add the XML editor
			var xmlPanel = new Panel();
			xmlEditor = new SyntaxEditor() { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill };
			xmlEditor.DocumentParseDataChanged += this.OnCodeEditorDocumentParseDataChanged;
			xmlEditor.UserInterfaceUpdate += this.OnCodeEditorUserInterfaceUpdate;
			xmlPanel.Controls.Add(xmlEditor);
			symbolSelector = new NavigableSymbolSelector() { Dock = DockStyle.Top, SyntaxEditor = xmlEditor };
			xmlPanel.Controls.Add(symbolSelector);
			xmlDocumentWindow = new DocumentWindow(dockManager, "xmlDocumentWindow", "Document1.xml", -1, xmlPanel);
			xmlDocumentWindow.Activate();

			// Add the schema editor
			schemaEditor = new SyntaxEditor() { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill };
			schemaEditor.Document.IsReadOnly = true;
			schemaEditor.Document.Language = new XmlSyntaxLanguage();
			schemaDocumentWindow = new DocumentWindow(dockManager, "schemaDocumentWindow", "Schema1.xsd", -1, schemaEditor);
			schemaDocumentWindow.Activate(false);
			
			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher within your 
			//   application startup code, and add related cleanup in your application OnExit code.  
			//   These steps are essential to having the add-on perform well.
			//
			
			// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
			var language = new XmlSyntaxLanguage();
			language.RegisterXmlSchemaResolver(schemaResolver);
			xmlEditor.Document.Language = language;

			// Initialize
			this.NewFile();
			this.OpenMammalsSchema();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Closes the schema.
		/// </summary>
		private void CloseSchema() {
			// Clear the schema
			schemaResolver.SchemaSet = null;

			// Set the title
			schemaDocumentWindow.Text = "NoSchema.xsd";

			// Clear the text
			schemaEditor.Document.SetText(null);

			// Queue a new parse since the schema data changed
			xmlEditor.Document.QueueParseRequest();
		}

		/// <summary>
		/// Creates a new file.
		/// </summary>
		private void NewFile() {
			this.OpenFile(String.Format("Document{0}.xml", ++documentNumber), null);
		}
		
		/// <summary>
		/// Occurs when the document's parse data has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to this event.</param>
		private void OnCodeEditorDocumentParseDataChanged(object sender, EventArgs e) {
			//
			// NOTE: The parse data here is generated in a worker thread... this event handler is called 
			//         back in the UI thread immediately when the worker thread completes... it is best
			//         practice to delay UI updates until the end user stops typing... we will flag that
			//         there is a pending parse data change, which will be handled in the 
			//         UserInterfaceUpdate event
			//

			hasPendingParseData = true;
		}

		/// <summary>
		/// Occurs after a brief delay following any document text, parse data, or view selection update, allowing consumers to update the user interface during an idle period.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains data related to this event.</param>
		private void OnCodeEditorUserInterfaceUpdate(object sender, EventArgs e) {
			// If there is a pending parse data change...
			if (hasPendingParseData) {
				// Clear flag
				hasPendingParseData = false;

				var parseData = xmlEditor.Document.ParseData as ILLParseData;
				if (parseData != null) {
					if (xmlEditor.Document.CurrentSnapshot.Length < 10000) {
						// Show the AST
						if (parseData.Ast != null)
							astOutputEditor.Text = parseData.Ast.ToTreeString(0);
						else
							astOutputEditor.Text = null;
					}
					else
						astOutputEditor.Text = "(Not displaying large AST for performance reasons)";

					// Output errors
					this.RefreshErrorList(parseData.Errors);
				}
				else {
					// Clear UI
					astOutputEditor.Text = null;
					this.RefreshErrorList(null);
				}
			}
		}
		
		/// <summary>
		/// Occurs when the control is double-clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnErrorListViewMouseDoubleClick(object sender, MouseEventArgs e) {
			var item = errorListView.HitTest(e.X, e.Y).Item;
			if (item != null) {
				var error = item.Tag as IParseError;
				if (error != null) {
					xmlEditor.ActiveView.Selection.StartPosition = error.PositionRange.StartPosition;
					xmlEditor.Focus();
				}
			}
		}

		/// <summary>
		/// Occurs when the toolstrip item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnMainToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			switch (e.ClickedItem.Name) {
				case nameof(closeSchemaToolStripButton):
					this.CloseSchema();
					break;
				case nameof(commentLinesToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.CommentLines();
					break;
				case nameof(formatDocumentToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.FormatDocument();
					break;
				case nameof(formatSelectionToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.FormatSelection();
					break;
				case nameof(newDocumentToolStripButton):
					this.NewFile();
					break;
				case nameof(openDocumentToolStripButton):
					this.OpenFile();
					break;
				case nameof(openSchemaToolStripButton):
					this.OpenSchema();
					break;
				case nameof(openXhtmlSchemaToolStripButton):
					this.OpenXhtmlSchema();
					break;
				case nameof(openXsdSchemaToolStripButton):
					this.OpenXsdSchema();
					break;
				case nameof(openXsltSchemaToolStripButton):
					this.OpenXsltSchema();
					break;
				case nameof(requestIntelliPromptAutoCompleteToolStripButton):
					xmlEditor.ActiveView.IntelliPrompt.RequestAutoComplete();
					break;
				case nameof(requestIntelliPromptCompletionSessionToolStripButton):
					xmlEditor.ActiveView.IntelliPrompt.RequestCompletionSession();
					break;
				case nameof(requestIntelliPromptQuickInfoSessionToolStripButton):
					xmlEditor.ActiveView.IntelliPrompt.RequestQuickInfoSession();
					break;
				case nameof(uncommentLinesToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.UncommentLines();
					break;
			}
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		private void OpenFile() {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					this.OpenFile(Path.GetFileName(dialog.FileName), stream);
				}
			}
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="stream">The <see cref="Stream"/> to load.</param>
		private void OpenFile(string filename, Stream stream) {
			// Load the file
			if (stream != null)
				xmlEditor.Document.LoadFile(stream, Encoding.UTF8);
			else
				xmlEditor.Document.SetText(null);

			// Set the filename
			xmlEditor.Document.FileName = filename;
		}
		
		/// <summary>
		/// Opens the mammals schema.
		/// </summary>
		private void OpenMammalsSchema() {
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Mammals.xsd")) {
				this.OpenSchema("Mammals.xsd", "http://ActiproSoftware/Mammals", stream);
			}

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Mammals-Dog.xml")) {
				this.OpenFile("Mammals-Dog.xml", stream);
			}
		}
		
		/// <summary>
		/// Opens a schema.
		/// </summary>
		private void OpenSchema() {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					this.OpenSchema(Path.GetFileName(dialog.FileName), null, stream);
				}
			}
		}

		/// <summary>
		/// Opens a schema.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="defaultNamespace">The optional default namespace.</param>
		/// <param name="stream">The <see cref="Stream"/> to load.</param>
		/// <param name="additionalStreams">The additional streams to load.</param>
		private void OpenSchema(string filename, string defaultNamespace, Stream stream, params Stream[] additionalStreams) {
			// Load the schema
			schemaEditor.Document.LoadFile(stream, Encoding.UTF8);

			// This allows the rich editing functionality to continue working, even when there is no xmlns in the root element
			schemaResolver.DefaultNamespace = defaultNamespace;

			// Load the schema
			schemaResolver.LoadSchemaFromString(schemaEditor.Document.CurrentSnapshot.Text);

			// Load any additional streams that are required
			if (additionalStreams != null) {
				foreach (Stream additionalStream in additionalStreams)
					schemaResolver.AddSchemaFromStream(additionalStream);
			}
			
			// Set the title
			schemaDocumentWindow.Text = filename;

			// Queue a new parse since the schema data changed
			xmlEditor.Document.QueueParseRequest();
		}
		
		/// <summary>
		/// Opens the XHTML schema.
		/// </summary>
		private void OpenXhtmlSchema() {
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.xsd")) {
				// Xml.xsd is also required for Xhtml.xsd
				using (Stream stream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
					this.OpenSchema("Xhtml.xsd", null, stream, stream2);
				}
			}

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.html")) {
				this.OpenFile("Xhtml.html", stream);
			}
		}
		
		/// <summary>
		/// Opens the XSD schema.
		/// </summary>
		private void OpenXsdSchema() {
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
				this.OpenSchema("XmlSchema.xsd", null, stream);
			}

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
				this.OpenFile("XmlSchema.xsd", stream);
			}
		}
		
		/// <summary>
		/// Opens the XSLT schema.
		/// </summary>
		private void OpenXsltSchema() {
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XSLT.xsd")) {
				// XmlSchema.xsd is required for Xslt.xsd
				using (Stream stream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
					// Xml.xsd is also required for Xslt.xsd
					using (Stream stream3 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
						this.OpenSchema("Xslt.xsd", null, stream, stream2, stream3);
					}
				}
			}

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XSLT.xslt")) {
				this.OpenFile("Xslt.xslt", stream);
			}
		}
		
		/// <summary>
		/// Refreshes the list.
		/// </summary>
		/// <param name="errors">The error collection.</param>
		private void RefreshErrorList(IEnumerable<IParseError> errors) {
			errorListView.Items.Clear();

			if (errors != null) {
				foreach (var error in errors) {
					var item = new ListViewItem(new string[] { 
						error.PositionRange.StartPosition.DisplayLine.ToString(), error.PositionRange.StartPosition.DisplayCharacter.ToString(), error.Description
					});
					item.Tag = error;
					errorListView.Items.Add(item);
				}
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
					astOutputEditor,
					errorListView,
					mainToolStrip,
					symbolSelector
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);

				// Manually scale the buttons/images on the tool strip
				mainToolStrip.SuspendLayout();
				mainToolStrip.ImageScalingSize = DpiHelper.RescaleSize(mainToolStrip.ImageScalingSize, deviceDpiOld, deviceDpiNew);
				var imageButtonSize = DpiHelper.ScaleSize(new Size(23, 22), DpiHelper.GetDpiScale(deviceDpiNew));
				foreach (var toolStripItem in mainToolStrip.Items) {
					if (toolStripItem is ToolStripButton toolStripButton) {
						if (toolStripButton.DisplayStyle == ToolStripItemDisplayStyle.Image) {
							toolStripButton.AutoSize = false;
							toolStripButton.Size = imageButtonSize;
						}
					}
				}
				mainToolStrip.ResumeLayout();
			}

			DpiHelper.RescaleListViewColumns(errorListView, deviceDpiOld, deviceDpiNew);

		}


	}

}
