using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.DotNetAddonCSharpEditor;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl, IProductSample {

	private int _documentNumber;
	private bool _hasPendingParseData;
	private System.Threading.Timer? _refreshReferencesTimer;

	// A project assembly (similar to a Visual Studio project) contains source files and assembly references for reflection
	private readonly IProjectAssembly _projectAssembly;

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

		//
		// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
		//   since it tells you how to set up an ambient parse request dispatcher and an ambient
		//   code repository within your application startup code, and add related cleanup in your
		//   application OnExit code.  These steps are essential to having the add-on perform well.
		//

		// Initialize the project assembly (enables support for automated IntelliPrompt features)
		_projectAssembly = new CSharpProjectAssembly("SampleBrowser");
		_projectAssembly.AssemblyReferences.ItemAdded += OnAssemblyReferencesChanged;
		_projectAssembly.AssemblyReferences.ItemRemoved += OnAssemblyReferencesChanged;
		var assemblyLoader = new BackgroundWorker();
		assemblyLoader.DoWork += DotNetProjectAssemblyReferenceLoader;
		assemblyLoader.RunWorkerAsync();

		// Load the .NET Languages Add-on C# language and register the project assembly on it
		var language = new CSharpSyntaxLanguage();
		language.RegisterProjectAssembly(_projectAssembly);
		codeEditor.Document.Language = language;

		// Update the lexer to recognize some custom preprocessor directive names
		CSharpLexer.OtherPreprocessorDirectives.Clear();
		CSharpLexer.OtherPreprocessorDirectives.Add("load");
		CSharpLexer.OtherPreprocessorDirectives.Add("r");
	}

	private void DotNetProjectAssemblyReferenceLoader(object? sender, DoWorkEventArgs e) {
		// Add some common assemblies for reflection (any custom assemblies could be added using various Add overloads instead)
		SyntaxEditorHelper.AddCommonDotNetSystemAssemblyReferences(_projectAssembly);
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates a new file.
	/// </summary>
	private void NewFile()
		=> OpenFile(string.Format("Document{0}.cs", ++_documentNumber), stream: null);

	/// <summary>
	/// Occurs when the assembly references have changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnAssemblyReferencesChanged(object? sender, Text.Utility.CollectionChangeEventArgs<IProjectAssemblyReference> e) {
		// Assemblies can be added/removed quickly, especially during initial discovery.
		//   Throttle UI refreshing until no "change" events have been received for a given time.
		_refreshReferencesTimer ??= new System.Threading.Timer(RefreshReferenceListCallback);

		// Reset the timer each time a new event is raised (without auto-restart)
		_refreshReferencesTimer.Change(dueTime: 250, period: System.Threading.Timeout.Infinite);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnAddReferenceToolStripButtonClick(object sender, EventArgs e) {
		// Show a file open dialog
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Multiselect = false,
			Filter = "Assemblies (*.dll)|*.dll|All files (*.*)|*.*"
		};
		if (dialog.ShowDialog() == DialogResult.OK) {
			try {
				// Add to references
				_projectAssembly.AssemblyReferences.AddFrom(dialog.FileName);
			}
			catch (Exception ex) {
				MessageBox.Show("An exception occurred: " + ex.Message, "Error Loading Assembly", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	/// <summary>
	/// Occurs when the document's parse data has changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCodeEditorDocumentParseDataChanged(object sender, EventArgs e) {
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
	private void OnCodeEditorUserInterfaceUpdate(object sender, EventArgs e) {
		// If there is a pending parse data change...
		if (_hasPendingParseData) {
			// Clear flag
			_hasPendingParseData = false;

			if (codeEditor.Document.ParseData is ILLParseData parseData) {
				if (codeEditor.Document.CurrentSnapshot.Length < 10000) {
					// Show the AST
					astOutputEditor.Text = parseData.Ast?.ToTreeString(indentLevel: 0);
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
				codeEditor.ActiveView.Selection.StartPosition = error.PositionRange.Value.StartPosition;

			codeEditor.Focus();
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
				codeEditor.ActiveView.TextChangeActions.CommentLines();
				break;
			case nameof(formatDocumentToolStripButton):
				codeEditor.ActiveView.TextChangeActions.FormatDocument();
				break;
			case nameof(formatSelectionToolStripButton):
				codeEditor.ActiveView.TextChangeActions.FormatSelection();
				break;
			case nameof(newDocumentToolStripButton):
				NewFile();
				break;
			case nameof(openDocumentToolStripButton):
				OpenFile();
				break;
			case nameof(requestIntelliPromptAutoCompleteToolStripButton):
				codeEditor.ActiveView.IntelliPrompt.RequestAutoComplete();
				break;
			case nameof(requestIntelliPromptCompletionSessionToolStripButton):
				codeEditor.ActiveView.IntelliPrompt.RequestCompletionSession();
				break;
			case nameof(requestIntelliPromptParameterInfoSessionToolStripButton):
				codeEditor.ActiveView.IntelliPrompt.RequestParameterInfoSession();
				break;
			case nameof(requestIntelliPromptQuickInfoSessionToolStripButton):
				codeEditor.ActiveView.IntelliPrompt.RequestQuickInfoSession();
				break;
			case nameof(uncommentLinesToolStripButton):
				codeEditor.ActiveView.TextChangeActions.UncommentLines();
				break;
		}
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnRemoveReferenceToolStripButtonClick(object sender, EventArgs e) {
		if (referencesListBox.SelectedIndex == -1) {
			MessageBox.Show("Select a reference first.", "No Reference Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}

		// Remove the selected reference
		_projectAssembly.AssemblyReferences.RemoveAt(referencesListBox.SelectedIndex);
	}

	/// <summary>
	/// Opens a file.
	/// </summary>
	private void OpenFile() {
		// Show a file open dialog
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Multiselect = false,
			Filter = "C# files (*.cs)|*.cs|All files (*.*)|*.*"
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
			codeEditor.Document.LoadFile(stream, Encoding.UTF8);
		else
			codeEditor.Document.SetText(string.Empty);

		// Set the filename
		codeEditor.Document.FileName = filename;
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

	/// <summary>
	/// Refreshes the list.
	/// </summary>
	private void RefreshReferenceListCallback(object? stateInfo) {
		if (InvokeRequired) {
			BeginInvoke(() => RefreshReferenceListCallback(stateInfo));
			return;
		}

		referencesListBox.Items.Clear();
		foreach (var assemblyName in _projectAssembly.AssemblyReferences.Select(r => r.Assembly.Name).Where(n => n is not null))
			referencesListBox.Items.Add(assemblyName!);
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Notifies the UI that it has been loaded.
	/// </summary>
	public void NotifyLoaded() { }

	/// <summary>
	/// Notifies the UI that it has been unloaded.
	/// </summary>
	public void NotifyUnloaded() {
		// Clear .NET Languages Add-on project assembly references when the sample unloads
		_projectAssembly.AssemblyReferences.Clear();
	}

	/// <inheritdoc/>
	protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
		base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

		if (!Program.IsControlFontScalingHandledByRuntime) {
			// Manually scale control fonts
			var manualFontControls = new Control[] {
				astOutputEditor,
				errorListView,
				mainToolStrip,
				referencesListBox,
				referencesToolStrip,
				symbolSelector
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
