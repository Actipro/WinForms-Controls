using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
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

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted04b {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

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

			// Set the AST output tab stop width
			astOutputEditor.SetTabStopWidth(1);

			// Load the EBNF language
			ebnfEditor.Document.Language = SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Ebnf.langdef");

			// Show the EBNF
			var parser = editor.Document.Language.GetParser() as ILLParser;
			if (parser != null)
				ebnfEditor.Document.SetText(parser.Grammar.ToEbnfString());
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
			//         back in the UI thread though so any processing done below could slow down UI if 
			//         the processing is lengthy
			//

			var parseData = editor.Document.ParseData as ILLParseData;
			if (parseData != null) {
				// Show the AST
				if (parseData.Ast != null)
					astOutputEditor.Text = parseData.Ast.ToTreeString(0);
				else
					astOutputEditor.Text = null;

				// Output errors
				RefreshErrorList(parseData.Errors);
			}
			else {
				// Clear UI
				astOutputEditor.Text = null;
				this.RefreshErrorList(null);
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
