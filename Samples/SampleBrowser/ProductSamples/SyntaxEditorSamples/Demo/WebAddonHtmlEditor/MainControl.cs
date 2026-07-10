using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Reflection;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonHtmlEditor;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private int _documentNumber;
	private bool _hasPendingParseData;

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

		// Configure additional events for the editor for loading parse errors in the error list
		xmlEditor.DocumentParseDataChanged += OnCodeEditorDocumentParseDataChanged;
		xmlEditor.UserInterfaceUpdate += OnCodeEditorUserInterfaceUpdate;

		//
		// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
		//   since it tells you how to set up an ambient parse request dispatcher within your 
		//   application startup code, and add related cleanup in your application OnExit code.  
		//   These steps are essential to having the add-on perform well.
		//

		// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
		var resolver = new XmlSchemaResolver();
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.xsd")) {
			if (stream is not null)
				resolver.AddSchemaFromStream(stream);
		}

		// Xml.xsd is also required for Xhtml.xsd
		using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
			if (stream is not null)
				resolver.AddSchemaFromStream(stream);
		}

		// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
		var language = new XmlSyntaxLanguage();
		language.RegisterXmlSchemaResolver(resolver);
		xmlEditor.Document.Language = language;
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates a new file.
	/// </summary>
	private void NewFile()
		=> OpenFile(string.Format("Document{0}.xhtml", ++_documentNumber), stream: null);

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

			if (xmlEditor.Document.ParseData is ILLParseData parseData) {
				// Output errors
				RefreshErrorList(parseData.Errors);
			}
			else {
				// Clear UI
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
				xmlEditor.ActiveView.Selection.StartPosition = error.PositionRange.Value.StartPosition;

			xmlEditor.Focus();
		}
	}

	/// <summary>
	/// Occurs when the toolstrip item is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnMainToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e) {
		switch (e.ClickedItem?.Name) {
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
				NewFile();
				break;
			case nameof(openDocumentToolStripButton):
				OpenFile();
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
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Multiselect = false,
			Filter = "XHTML files (*.html;*.xhtml)|*.html;*.xhtml|All files (*.*)|*.*"
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
			xmlEditor.Document.LoadFile(stream, Encoding.UTF8);
		else
			xmlEditor.Document.SetText(string.Empty);

		// Set the filename
		xmlEditor.Document.FileName = filename;
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
