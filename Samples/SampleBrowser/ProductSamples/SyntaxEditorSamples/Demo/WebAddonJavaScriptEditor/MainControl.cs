using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.JavaScript.Implementation;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonJavaScriptEditor {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private int documentNumber;
		private bool hasPendingParseData;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize initialization
			DpiHelper.RescaleListViewColumns(errorListView, DpiHelper.DefaultDeviceDpi, DpiHelper.GetSystemDeviceDpi());

			// Set the AST output tab stop width
			astOutputEditor.SetTabStopWidth(1);

			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher
			//   within your application startup code, and add related cleanup in your
			//   application OnExit code.  These steps are essential to having the add-on perform well.
			//

			// Load the Web Languages Add-on JavaScript language
			var language = new JavaScriptSyntaxLanguage();
			codeEditor.Document.Language = language;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Creates a new file.
		/// </summary>
		private void NewFile() {
			this.OpenFile(String.Format("Document{0}.js", ++documentNumber), null);
		}
		
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

				var parseData = codeEditor.Document.ParseData as ILLParseData;
				if (parseData != null) {
					if (codeEditor.Document.CurrentSnapshot.Length < 10000) {
						// Show the AST
						if (parseData.Ast != null)
							astOutputEditor.Text = parseData.Ast.ToTreeString(0);
						else
							astOutputEditor.Text = null;
					}
					else
						astOutputEditor.Text = "(Not displaying large AST for performance reasons)";

					// Output errors
					this.RefreshErrorList(parseData.Errors);
				}
				else {
					// Clear UI
					astOutputEditor.Text = null;
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
					codeEditor.ActiveView.Selection.StartPosition = error.PositionRange.StartPosition;
					codeEditor.Focus();
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
					codeEditor.ActiveView.TextChangeActions.CommentLines();
					break;
				case nameof(formatDocumentToolStripButton):
					codeEditor.ActiveView.TextChangeActions.FormatDocument();
					break;
				case nameof(formatSelectionToolStripButton):
					codeEditor.ActiveView.TextChangeActions.FormatSelection();
					break;
				case nameof(newDocumentToolStripButton):
					this.NewFile();
					break;
				case nameof(openDocumentToolStripButton):
					this.OpenFile();
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
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "JavaScript files (*.js)|*.js|All files (*.*)|*.*";
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
				codeEditor.Document.LoadFile(stream, Encoding.UTF8);
			else
				codeEditor.Document.SetText(null);

			// Set the filename
			codeEditor.Document.FileName = filename;
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

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale control fonts				
				var manualFontControls = new Control[] {
					errorListView,
					mainToolStrip,
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

}
