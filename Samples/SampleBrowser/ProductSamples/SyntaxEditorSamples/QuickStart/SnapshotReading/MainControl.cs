using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotReading;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private readonly ITextSnapshotReader reader;

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

		// Create a reader
		reader = editor.Document.CurrentSnapshot.GetReader(0);
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Appends a message to the results editor and updates the UI.
	/// </summary>
	/// <param name="message">The message to append.</param>
	/// <param name="isTokenSearch">Whether the search was for a token.</param>
	private void AppendMessageAndUpdateUI(string message, bool isTokenSearch) {
		var token = reader.Token;

		// Get token message portion
		string tokenMessage = "<null>";
		if (token is not null)
			tokenMessage = string.Format("{0} (TextRange={1})", token.Key, token.TextRange);

		// Append message
		resultsTextBox.AppendText(string.Format("{0}: Offset={1}, Position={2}, Token={3}{4}", message, reader.Offset, reader.Position, tokenMessage, Environment.NewLine));

		// Focus the editor
		editor.Focus();

		// Select the text that was read (select in reverse so the caret is at the actual "current" offset)
		if ((isTokenSearch) && (token is not null))
			editor.ActiveView.Selection.SelectRange(new TextRange(token.EndOffset, token.StartOffset));
		else if (!reader.IsAtSnapshotEnd)
			editor.ActiveView.Selection.SelectRange(new TextRange(reader.Offset + 1, reader.Offset));
		else
			editor.ActiveView.Selection.StartOffset = reader.Offset;
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToCurrentLineEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToCurrentSnapshotLineEnd();
		AppendMessageAndUpdateUI("Current line end", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToCurrentLineStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToCurrentSnapshotLineStart();
		AppendMessageAndUpdateUI("Current line start", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToCurrentWordEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToCurrentWordEnd();
		AppendMessageAndUpdateUI("Current word end", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToCurrentWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToCurrentWordStart();
		AppendMessageAndUpdateUI("Current word start", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextCharacterLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.ReadCharacter();
		AppendMessageAndUpdateUI("Next character", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextDocumentationCommentLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToNextTokenWithKey("XmlCommentStartTag");
		AppendMessageAndUpdateUI("Next documentation comment", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextLineStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToNextSnapshotLineStart();
		AppendMessageAndUpdateUI("Next line start", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextThirdTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToNextToken(3);
		AppendMessageAndUpdateUI("Next third token", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToNextToken();
		AppendMessageAndUpdateUI("Next token", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToNextWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToNextWordStart();
		AppendMessageAndUpdateUI("Next word start", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousCharacterLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.ReadCharacterReverse();
		AppendMessageAndUpdateUI("Previous character", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousDocumentationCommentLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToPreviousTokenWithKey("XmlCommentStartTag");
		AppendMessageAndUpdateUI("Previous documentation comment", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousLineEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToPreviousSnapshotLineEnd();
		AppendMessageAndUpdateUI("Previous line end", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousThirdTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToPreviousToken(3);
		AppendMessageAndUpdateUI("Previous third token", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToPreviousToken();
		AppendMessageAndUpdateUI("Previous token", isTokenSearch: true);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToPreviousWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToPreviousWordStart();
		AppendMessageAndUpdateUI("Previous word start", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToSnapshotEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToSnapshotEnd();
		AppendMessageAndUpdateUI("Snapshot end", isTokenSearch: false);
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToSnapshotStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		reader.Offset = editor.ActiveView.Selection.EndOffset;
		reader.GoToSnapshotStart();
		AppendMessageAndUpdateUI("Snapshot start", isTokenSearch: false);
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
				navigationPanel
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}
	}

}
