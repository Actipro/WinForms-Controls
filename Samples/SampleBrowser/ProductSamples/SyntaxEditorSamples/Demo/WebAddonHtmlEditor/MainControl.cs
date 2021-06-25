using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonHtmlEditor {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private int					documentNumber;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher within your 
			//   application startup code, and add related cleanup in your application OnExit code.  
			//   These steps are essential to having the add-on perform well.
			//
			
			// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
			XmlSchemaResolver resolver = new XmlSchemaResolver();
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "XHTML.xsd")) {
				resolver.AddSchemaFromStream(stream);
			}

			// Xml.xsd is also required for Xhtml.xsd
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SyntaxEditorHelper.XmlSchemasPath + "Xml.xsd")) {
				resolver.AddSchemaFromStream(stream);
			}
			
			// Register the schema resolver service with the XML language (needed to support IntelliPrompt)
			var language = new XmlSyntaxLanguage();
			language.RegisterXmlSchemaResolver(resolver);
			xmlEditor.Document.Language = language;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Creates a new file.
		/// </summary>
		private void NewFile() {
			this.OpenFile(String.Format("Document{0}.xhtml", ++documentNumber), null);
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
					xmlEditor.ActiveView.Selection.StartPosition = error.PositionRange.StartPosition;
					xmlEditor.Focus();
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
					xmlEditor.ActiveView.TextChangeActions.CommentLines();
					break;
				case nameof(formatDocumentToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.FormatDocument();
					break;
				case nameof(formatSelectionToolStripButton):
					xmlEditor.ActiveView.TextChangeActions.FormatSelection();
					break;
				case nameof(newDocumentToolStripButton):
					this.NewFile();
					break;
				case nameof(openDocumentToolStripButton):
					this.OpenFile();
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
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "XHTML files (*.html;*.xhtml)|*.html;*.xhtml|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					this.OpenFile(Path.GetFileName(dialog.FileName), stream);
				}
			}
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="stream">The <see cref="Stream"/> to load.</param>
		private void OpenFile(string filename, Stream stream) {
			// Load the file
			if (stream != null)
				xmlEditor.Document.LoadFile(stream, Encoding.UTF8);
			else
				xmlEditor.Document.SetText(null);

			// Set the filename
			xmlEditor.Document.FileName = filename;
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
