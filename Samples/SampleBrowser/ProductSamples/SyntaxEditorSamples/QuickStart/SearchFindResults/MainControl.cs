using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Searching;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SearchFindResults;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private ISearchResultSet? _lastResultSet;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Load a language from a language definition
		editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

		// Ensure all classification types and related styles have been registered
		//   since classification types are used for the search result highlight display
		new BuiltInClassificationTypeProvider().RegisterAll();

		// Set the default search options
		editor.SearchOptions.FindText = @"/// \s \< .+ \>";
		editor.SearchOptions.ReplaceText = "$&123";
		editor.SearchOptions.PatternProvider = SearchPatternProviders.RegularExpression;

		// Show the search overlay pane
		editor.ActiveView.OverlayPanes.AddSearch(true);
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when an overlay pane is opened.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditorOverlayPaneOpened(object sender, OverlayPaneEventArgs e) {
		if (e.Pane is SearchOverlayPane pane)
			pane.IsFindAllButtonVisible = true;
	}

	/// <summary>
	/// Occurs when the user executes a view search.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditorViewSearch(object sender, EditorViewSearchEventArgs e)
		=> UpdateResults(e.ResultSet);

	/// <summary>
	/// Occurs when the mouse is double-clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnResultsTextBoxMouseDoubleClick(object sender, MouseEventArgs e) {
		// Quit if there is not result set stored yet
		if (_lastResultSet is null)
			return;

		int charIndex = resultsTextBox.GetCharIndexFromPosition(e.Location);
		int lineIndex = resultsTextBox.GetLineFromCharIndex(charIndex);

		int resultIndex = lineIndex - 1;  // Account for first line in results displaying search info
		if ((0 <= resultIndex) && (resultIndex < _lastResultSet.Results.Count)) {
			// A valid result was clicked
			var result = _lastResultSet.Results[resultIndex];
			TextSnapshotRange? selectionSnapshotRange;
			if (result.ReplaceSnapshotRange.HasValue) {
				// Replace result
				selectionSnapshotRange = result.ReplaceSnapshotRange.Value.TranslateTo(editor.ActiveView.CurrentSnapshot, TextRangeTrackingModes.Default);
			}
			else {
				// Find result
				selectionSnapshotRange = result.FindSnapshotRange.TranslateTo(editor.ActiveView.CurrentSnapshot, TextRangeTrackingModes.Default);
			}

			// Select the range
			if (selectionSnapshotRange.HasValue)
				editor.ActiveView.Selection.SelectRange(selectionSnapshotRange.Value.TextRange);

			// Focus the editor
			editor.Focus();
		}
	}

	/// <summary>
	/// Updates the results.
	/// </summary>
	/// <param name="resultSet">The <see cref="ISearchResultSet"/> containing results.</param>
	private void UpdateResults(ISearchResultSet resultSet) {
		// Show the results
		resultsToolWindow.TitleBarText = string.Format("Find Results - {0} match{1}", resultSet.Results.Count, (resultSet.Results.Count == 1 ? string.Empty : "es"));
		resultsTextBox.Text = resultSet.ToString();

		// Save the result set
		_lastResultSet = resultSet;
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
				resultsTextBox,
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}

		if (!Program.IsControlSizeScalingHandledByRuntime) {
			// Manually scale sizes
			var manualSizeControl = new Control[] {
				resultsTextBox,
			};
			foreach (var control in manualSizeControl)
				control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
		}
	}

}
