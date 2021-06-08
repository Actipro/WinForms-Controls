using ActiproSoftware.Text;
using ActiproSoftware.Text.Lexing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotReading {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private ITextSnapshotReader reader;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

			// Create a reader
			reader = editor.Document.CurrentSnapshot.GetReader(0);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Appends a message to the results editor and updates the UI.
		/// </summary>
		/// <param name="message">The message to append.</param>
		/// <param name="isTokenSearch">Whether the search was for a token.</param>
		private void AppendMessageAndUpdateUI(string message, bool isTokenSearch) {
			IToken token = reader.Token;

			// Get token message portion
			string tokenMessage = "<null>";
			if (token != null)
				tokenMessage = String.Format("{0} (TextRange={1})", token.Key, token.TextRange);

			// Append message
			resultsTextBox.AppendText(String.Format("{0}: Offset={1}, Position={2}, Token={3}\r\n", message, reader.Offset, reader.Position, tokenMessage));

			// Focus the editor
			editor.Focus();

			// Select the text that was read (select in reverse so the caret is at the actual "current" offset)
			if ((isTokenSearch) && (token != null))
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
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToCurrentLineEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToCurrentSnapshotLineEnd();
			this.AppendMessageAndUpdateUI("Current line end", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToCurrentLineStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToCurrentSnapshotLineStart();
			this.AppendMessageAndUpdateUI("Current line start", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToCurrentWordEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToCurrentWordEnd();
			this.AppendMessageAndUpdateUI("Current word end", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToCurrentWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToCurrentWordStart();
			this.AppendMessageAndUpdateUI("Current word start", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextCharacterLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.ReadCharacter();
			this.AppendMessageAndUpdateUI("Next character", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextDocumentationCommentLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToNextTokenWithKey("XmlCommentStartTag");
			this.AppendMessageAndUpdateUI("Next documentation comment", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextLineStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToNextSnapshotLineStart();
			this.AppendMessageAndUpdateUI("Next line start", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextThirdTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToNextToken(3);
			this.AppendMessageAndUpdateUI("Next third token", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToNextToken();
			this.AppendMessageAndUpdateUI("Next token", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToNextWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToNextWordStart();
			this.AppendMessageAndUpdateUI("Next word start", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousCharacterLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.ReadCharacterReverse();
			this.AppendMessageAndUpdateUI("Previous character", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousDocumentationCommentLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToPreviousTokenWithKey("XmlCommentStartTag");
			this.AppendMessageAndUpdateUI("Previous documentation comment", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousLineEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToPreviousSnapshotLineEnd();
			this.AppendMessageAndUpdateUI("Previous line end", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousThirdTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToPreviousToken(3);
			this.AppendMessageAndUpdateUI("Previous third token", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousTokenLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToPreviousToken();
			this.AppendMessageAndUpdateUI("Previous token", true);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToPreviousWordStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToPreviousWordStart();
			this.AppendMessageAndUpdateUI("Previous word start", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToSnapshotEndLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToSnapshotEnd();
			this.AppendMessageAndUpdateUI("Snapshot end", false);
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="LinkLabelLinkClickedEventArgs"/> that contains the event data.</param>
		private void OnGoToSnapshotStartLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			reader.Offset = editor.ActiveView.Selection.EndOffset;
			reader.GoToSnapshotStart();
			this.AppendMessageAndUpdateUI("Snapshot start", false);
		}

	}

}
