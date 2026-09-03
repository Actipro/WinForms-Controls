using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Reflection;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonXmlEditor;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private int _documentNumber;
	private bool _hasPendingParseData;
	private readonly DocumentWindow _schemaDocumentWindow;
	private readonly SyntaxEditor _schemaEditor;
	private readonly XmlSchemaResolver _schemaResolver = new();
	private readonly NavigableSymbolSelector _symbolSelector;
	private readonly DocumentWindow _xmlDocumentWindow;
	private readonly SyntaxEditor _xmlEditor;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Finalize initialization
		DpiHelper.RescaleListViewColumns(errorListView, DpiHelper.DefaultDeviceDpi, DpiHelper.GetSystemDeviceDpi());

		// Set the AST output tab stop width
		astOutputEditor.SetTabStopWidth(1);

		// Add the XML editor
		var xmlPanel = new Panel();
		_xmlEditor = new SyntaxEditor() { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill };
		_xmlEditor.DocumentParseDataChanged += OnCodeEditorDocumentParseDataChanged;
		_xmlEditor.UserInterfaceUpdate += OnCodeEditorUserInterfaceUpdate;
		xmlPanel.Controls.Add(_xmlEditor);
		_symbolSelector = new NavigableSymbolSelector() { Dock = DockStyle.Top, SyntaxEditor = _xmlEditor };
		xmlPanel.Controls.Add(_symbolSelector);
		_xmlDocumentWindow = new DocumentWindow(dockManager, "xmlDocumentWindow", "Document1.xml", childControl: xmlPanel);
		_xmlDocumentWindow.Activate();

		// Add the schema editor
		_schemaEditor = new SyntaxEditor() { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill };
		_schemaEditor.Document.IsReadOnly = true;
		_schemaEditor.Document.Language = new XmlSyntaxLanguage();
		_schemaDocumentWindow = new DocumentWindow(dockManager, "schemaDocumentWindow", "Schema1.xsd", childControl: _schemaEditor);
		_schemaDocumentWindow.Activate(focus: false);

		//
		// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
		//   since it tells you how to set up an ambient parse request dispatcher within your 
		//   application startup code, and add related cleanup in your application OnExit code.  
		//   These steps are essential to having the add-on perform well.
		//

		// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
		var language = new XmlSyntaxLanguage();
		language.RegisterXmlSchemaResolver(_schemaResolver);
		_xmlEditor.Document.Language = language;

		// Initialize
		NewFile();
		OpenMammalsSchema();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Closes the schema.
	/// </summary>
	private void CloseSchema() {
		// Clear the schema
		_schemaResolver.SchemaSet = null;

		// Set the title
		_schemaDocumentWindow.Text = "NoSchema.xsd";

		// Clear the text
		_schemaEditor.Document.SetText(string.Empty);

		// Queue a new parse since the schema data changed
		_xmlEditor.Document.QueueParseRequest();
	}

	/// <summary>
	/// Creates a new file.
	/// </summary>
	private void NewFile()
		=> OpenFile(string.Format("Document{0}.xml", ++_documentNumber), stream: null);

	/// <summary>
	/// Occurs when the document's parse data has changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCodeEditorDocumentParseDataChanged(object? sender, EventArgs e) {
		//
		// NOTE: The parse data here is generated in a worker thread... this event handler is called 
		//   back in the UI thread immediately when the worker thread completes... it is best
		//   practice to delay UI updates until the end user stops typing... we will flag that
		//   there is a pending parse data change, which will be handled in the 
		//   UserInterfaceUpdate event
		//

		_hasPendingParseData = true;
	}

	/// <summary>
	/// Occurs after a brief delay following any document text, parse data, or view selection update, allowing consumers to update the user interface during an idle period.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCodeEditorUserInterfaceUpdate(object? sender, EventArgs e) {
		// If there is a pending parse data change...
		if (_hasPendingParseData) {
			// Clear flag
			_hasPendingParseData = false;

			if (_xmlEditor.Document.ParseData is ILLParseData parseData) {
				if (_xmlEditor.Document.CurrentSnapshot.Length < 10000) {
					// Show the AST
					astOutputEditor.Text = parseData.Ast?.ToTreeString(0);
				}
				else
					astOutputEditor.Text = "(Not displaying large AST for performance reasons)";

				// Output errors
				RefreshErrorList(parseData.Errors);
			}
			else {
				// Clear UI
				astOutputEditor.Text = null;
				RefreshErrorList(errors: null);
			}
		}
	}

	/// <summary>
	/// Occurs when the control is double-clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnErrorListViewMouseDoubleClick(object sender, MouseEventArgs e) {
		var item = errorListView.HitTest(e.X, e.Y).Item;
		if (item?.Tag is IParseError error) {
			if (error.PositionRange.HasValue)
				_xmlEditor.ActiveView.Selection.StartPosition = error.PositionRange.Value.StartPosition;

			_xmlEditor.Focus();
		}
	}

	/// <summary>
	/// Occurs when the toolstrip item is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnMainToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e) {
		switch (e.ClickedItem?.Name) {
			case nameof(closeSchemaToolStripButton):
				CloseSchema();
				break;
			case nameof(commentLinesToolStripButton):
				_xmlEditor.ActiveView.TextChangeActions.CommentLines();
				break;
			case nameof(formatDocumentToolStripButton):
				_xmlEditor.ActiveView.TextChangeActions.FormatDocument();
				break;
			case nameof(formatSelectionToolStripButton):
				_xmlEditor.ActiveView.TextChangeActions.FormatSelection();
				break;
			case nameof(newDocumentToolStripButton):
				NewFile();
				break;
			case nameof(openDocumentToolStripButton):
				OpenFile();
				break;
			case nameof(openSchemaToolStripButton):
				OpenSchema();
				break;
			case nameof(openXhtmlSchemaToolStripButton):
				OpenXhtmlSchema();
				break;
			case nameof(openXsdSchemaToolStripButton):
				OpenXsdSchema();
				break;
			case nameof(openXsltSchemaToolStripButton):
				OpenXsltSchema();
				break;
			case nameof(requestIntelliPromptAutoCompleteToolStripButton):
				_xmlEditor.ActiveView.IntelliPrompt.RequestAutoComplete();
				break;
			case nameof(requestIntelliPromptCompletionSessionToolStripButton):
				_xmlEditor.ActiveView.IntelliPrompt.RequestCompletionSession();
				break;
			case nameof(requestIntelliPromptQuickInfoSessionToolStripButton):
				_xmlEditor.ActiveView.IntelliPrompt.RequestQuickInfoSession();
				break;
			case nameof(uncommentLinesToolStripButton):
				_xmlEditor.ActiveView.TextChangeActions.UncommentLines();
				break;
		}
	}

	/// <summary>
	/// Opens a file.
	/// </summary>
	private void OpenFile() {
		// Show a file open dialog
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Multiselect = false,
			Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
		};
		if (dialog.ShowDialog() == DialogResult.OK) {
			// Open a document
			using var stream = dialog.OpenFile();

			// Read the file
			OpenFile(Path.GetFileName(dialog.FileName), stream);
		}
	}

	/// <summary>
	/// Opens a file.
	/// </summary>
	/// <param name="filename">The filename.</param>
	/// <param name="stream">The <see cref="Stream"/> to load.</param>
	private void OpenFile(string filename, Stream? stream) {
		// Load the file
		if (stream is not null)
			_xmlEditor.Document.LoadFile(stream, Encoding.UTF8);
		else
			_xmlEditor.Document.SetText(string.Empty);

		// Set the filename
		_xmlEditor.Document.FileName = filename;
	}

	/// <summary>
	/// Opens the mammals schema.
	/// </summary>
	private void OpenMammalsSchema() {
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Mammals.xsd")) {
			OpenSchema("Mammals.xsd", "http://ActiproSoftware/Mammals", stream);
		}

		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Mammals-Dog.xml")) {
			OpenFile("Mammals-Dog.xml", stream);
		}
	}

	/// <summary>
	/// Opens a schema.
	/// </summary>
	private void OpenSchema() {
		// Show a file open dialog
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Multiselect = false,
			Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*"
		};
		if (dialog.ShowDialog() == DialogResult.OK) {
			// Open a document
			using var stream = dialog.OpenFile();

			// Read the file
			OpenSchema(Path.GetFileName(dialog.FileName), defaultNamespace: null, stream);
		}
	}

	/// <summary>
	/// Opens a schema.
	/// </summary>
	/// <param name="filename">The filename.</param>
	/// <param name="defaultNamespace">The optional default namespace.</param>
	/// <param name="stream">The <see cref="Stream"/> to load.</param>
	/// <param name="additionalStreams">The additional streams to load.</param>
	private void OpenSchema(string filename, string? defaultNamespace, Stream? stream, params Stream?[]? additionalStreams) {
		// Load the schema
		if (stream is not null)
			_schemaEditor.Document.LoadFile(stream, Encoding.UTF8);
		else
			_schemaEditor.Document.SetText(string.Empty);

		// This allows the rich editing functionality to continue working, even when there is no xmlns in the root element
		_schemaResolver.DefaultNamespace = defaultNamespace;

		// Load the schema
		_schemaResolver.LoadSchemaFromString(_schemaEditor.Document.CurrentSnapshot.Text);

		// Load any additional streams that are required
		if (additionalStreams is not null) {
			foreach (var additionalStream in additionalStreams) {
				if (additionalStream is not null)
					_schemaResolver.AddSchemaFromStream(additionalStream);
			}
		}

		// Set the title
		_schemaDocumentWindow.Text = filename;

		// Queue a new parse since the schema data changed
		_xmlEditor.Document.QueueParseRequest();
	}

	/// <summary>
	/// Opens the XHTML schema.
	/// </summary>
	private void OpenXhtmlSchema() {
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.xsd")) {
			// Xml.xsd is also required for Xhtml.xsd
			using (var stream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
				OpenSchema("Xhtml.xsd", defaultNamespace: null, stream, stream2);
			}
		}

		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.html")) {
			OpenFile("Xhtml.html", stream);
		}
	}

	/// <summary>
	/// Opens the XSD schema.
	/// </summary>
	private void OpenXsdSchema() {
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
			OpenSchema("XmlSchema.xsd", null, stream);
		}

		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
			OpenFile("XmlSchema.xsd", stream);
		}
	}

	/// <summary>
	/// Opens the XSLT schema.
	/// </summary>
	private void OpenXsltSchema() {
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XSLT.xsd")) {
			// XmlSchema.xsd is required for Xslt.xsd
			using (var stream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XmlSchema.xsd")) {
				// Xml.xsd is also required for Xslt.xsd
				using (var stream3 = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
					OpenSchema("Xslt.xsd", defaultNamespace: null, stream, stream2, stream3);
				}
			}
		}

		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XSLT.xslt")) {
			OpenFile("Xslt.xslt", stream);
		}
	}

	/// <summary>
	/// Refreshes the list.
	/// </summary>
	/// <param name="errors">The error collection.</param>
	private void RefreshErrorList(IEnumerable<IParseError>? errors) {
		errorListView.Items.Clear();

		if (errors is not null) {
			foreach (var error in errors) {
				if (error.PositionRange.HasValue) {
					var item = new ListViewItem([
						error.PositionRange.Value.StartPosition.DisplayLine.ToString(),
						error.PositionRange.Value.StartPosition.DisplayCharacter.ToString(),
						error.Description ?? string.Empty
					]);
					item.Tag = error;
					errorListView.Items.Add(item);
				}
			}
		}
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
		base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

		if (!Program.IsControlFontScalingHandledByRuntime) {
			// Manually scale control fonts
			var manualFontControls = new Control[] {
				astOutputEditor,
				errorListView,
				mainToolStrip,
				_symbolSelector
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);

			// Manually scale the buttons/images on the tool strip
			mainToolStrip.SuspendLayout();
			mainToolStrip.ImageScalingSize = DpiHelper.RescaleSize(mainToolStrip.ImageScalingSize, deviceDpiOld, deviceDpiNew);
			var imageButtonSize = DpiHelper.ScaleSize(new Size(23, 22), DpiHelper.GetDpiScale(deviceDpiNew));
			foreach (var toolStripButton in mainToolStrip.Items.OfType<ToolStripButton>()) {
				if (toolStripButton.DisplayStyle == ToolStripItemDisplayStyle.Image) {
					toolStripButton.AutoSize = false;
					toolStripButton.Size = imageButtonSize;
				}
			}
			mainToolStrip.ResumeLayout();
		}

		DpiHelper.RescaleListViewColumns(errorListView, deviceDpiOld, deviceDpiNew);

	}

}
