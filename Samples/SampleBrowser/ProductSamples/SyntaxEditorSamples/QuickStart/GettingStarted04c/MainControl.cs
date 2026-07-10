using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted04c;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

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

		// Load the custom Simple language defined in this sample
		editor.Document.Language = new SimpleSyntaxLanguage();

		// Set the AST output tab stop width
		astOutputEditor.SetTabStopWidth(1);

		// Load the EBNF language
		ebnfEditor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Ebnf.langdef");

		// Show the EBNF
		var parser = editor.Document.Language.GetParser() as ILLParser;
		if (parser is not null)
			ebnfEditor.Document.SetText(parser.Grammar.ToEbnfString());
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the document's parse data has changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCodeEditorDocumentParseDataChanged(object sender, EventArgs e) {

		//
		// NOTE: The parse data here is generated in a worker thread... this event handler is called 
		//   back in the UI thread though so any processing done below could slow down UI if 
		//   the processing is lengthy
		//

		var parseData = editor.Document.ParseData as ILLParseData;
		if (parseData is not null) {
			// Show the AST
			astOutputEditor.Text = parseData.Ast?.ToTreeString(indentLevel: 0);

			// Output errors
			RefreshErrorList(parseData.Errors);
		}
		else {
			// Clear UI
			astOutputEditor.Text = null;
			RefreshErrorList(errors: null);
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
				editor.ActiveView.Selection.StartPosition = error.PositionRange.Value.StartPosition;

			editor.Focus();
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
				errorListView
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}

		// Resize the width of ListView columns
		DpiHelper.RescaleListViewColumns(errorListView, deviceDpiOld, deviceDpiNew);
	}

}
