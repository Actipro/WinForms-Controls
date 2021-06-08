using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted13 {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private bool hasPendingParseData;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load the custom Simple language defined in this sample
			editor.Document.Language = new SimpleSyntaxLanguage();

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

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

				var parseData = editor.Document.ParseData as ILLParseData;
				if (parseData != null) {
					// Output errors
					this.RefreshErrorList(parseData.Errors);
				}
				else {
					// Clear UI
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
					editor.ActiveView.Selection.StartPosition = error.PositionRange.StartPosition;
					editor.Focus();
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
				case nameof(commentLinesToolStripButton):
					editor.ActiveView.TextChangeActions.CommentLines();
					break;
				case nameof(formatDocumentToolStripButton):
					editor.ActiveView.TextChangeActions.FormatDocument();
					break;
				case nameof(formatSelectionToolStripButton):
					editor.ActiveView.TextChangeActions.FormatSelection();
					break;
				case nameof(requestIntelliPromptAutoCompleteToolStripButton):
					editor.ActiveView.IntelliPrompt.RequestAutoComplete();
					break;
				case nameof(requestIntelliPromptCompletionSessionToolStripButton):
					editor.ActiveView.IntelliPrompt.RequestCompletionSession();
					break;
				case nameof(requestIntelliPromptParameterInfoSessionToolStripButton):
					editor.ActiveView.IntelliPrompt.RequestParameterInfoSession();
					break;
				case nameof(requestIntelliPromptQuickInfoSessionToolStripButton):
					editor.ActiveView.IntelliPrompt.RequestQuickInfoSession();
					break;
				case nameof(uncommentLinesToolStripButton):
					editor.ActiveView.TextChangeActions.UncommentLines();
					break;
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
		
	}

}
