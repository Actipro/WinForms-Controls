using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Python;
using ActiproSoftware.Text.Languages.Python.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Security;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.PythonAddonPythonEditor;

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

		// Set the AST output tab stop width
		astOutputEditor.SetTabStopWidth(1);

		//
		// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
		//   since it tells you how to set up an ambient parse request dispatcher and an ambient
		//   code repository within your application startup code, and add related cleanup in your
		//   application OnExit code.  These steps are essential to having the add-on perform well.
		//

		// Load the Web Languages Add-on Python language
		var language = new PythonSyntaxLanguage();
		codeEditor.Document.Language = language;
		codeEditor.Document.FileName = "mymodule.py";
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates a new file.
	/// </summary>
	private void NewFile()
		=> OpenFile(string.Format("Document{0}.py", ++_documentNumber), stream: null);

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
			case nameof(locateStandardLibraryToolStripButton):
				OpenStandardLibrary();
				break;
			case nameof(newDocumentToolStripButton):
				NewFile();
				break;
			case nameof(openDocumentToolStripButton):
				OpenFile();
				break;
			case nameof(uncommentLinesToolStripButton):
				codeEditor.ActiveView.TextChangeActions.UncommentLines();
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
			Filter = "Python files (*.py)|*.py|All files (*.*)|*.*"
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
	/// Opens the standard library.
	/// </summary>
	private void OpenStandardLibrary() {
		// Show a file open dialog
		var dialog = new OpenFileDialog {
			CheckFileExists = true,
			Title = "Select a file from the Lib folder of your Python standard library",
			Multiselect = false,
			Filter = "Python files (*.py)|*.py|All files (*.*)|*.*"
		};
		if (dialog.ShowDialog() == DialogResult.OK) {
			try {
				var directoryPath = Path.GetDirectoryName(dialog.FileName);
				if (Directory.Exists(directoryPath)) {
					// Add the containing directory as a search path
					if (codeEditor.Document.Language.GetProject() is { } project) {
						project.SearchPaths.Clear();
						project.SearchPaths.Add(directoryPath);

						// Add the site-packages child folder, if present
						var sitePackagesPath = Path.Combine(directoryPath, "site-packages");
						if (Directory.Exists(sitePackagesPath))
							project.SearchPaths.Add(sitePackagesPath);

						MessageBox.Show("Standard library location set to '" + directoryPath + "'.");
					}
				}
			}
			catch (ArgumentException) { }
			catch (IOException) { }
			catch (SecurityException) { }
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
