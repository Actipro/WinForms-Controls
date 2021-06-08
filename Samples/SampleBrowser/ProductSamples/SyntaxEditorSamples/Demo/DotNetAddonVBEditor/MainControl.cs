using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using ActiproSoftware.Text.Languages.VB.Implementation;
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

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.DotNetAddonVBEditor {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl, IProductSample {

		private int documentNumber;
		private bool hasPendingParseData;

		// A project assembly (similar to a Visual Studio project) contains source files and assembly references for reflection
		private IProjectAssembly projectAssembly;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Set the AST output tab stop width
			astOutputEditor.SetTabStopWidth(1);

			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher and an ambient
			//   code repository within your application startup code, and add related cleanup in your
			//   application OnExit code.  These steps are essential to having the add-on perform well.
			//

			// Initialize the project assembly (enables support for automated IntelliPrompt features)
			projectAssembly = new VBProjectAssembly("SampleBrowser");
			projectAssembly.AssemblyReferences.ItemAdded += OnAssemblyReferencesChanged;
			projectAssembly.AssemblyReferences.ItemRemoved += OnAssemblyReferencesChanged;
			var assemblyLoader = new BackgroundWorker();
			assemblyLoader.DoWork += DotNetProjectAssemblyReferenceLoader;
			assemblyLoader.RunWorkerAsync();

			// Load the .NET Languages Add-on VB language and register the project assembly on it
			var language = new VBSyntaxLanguage();
			language.RegisterProjectAssembly(projectAssembly);
			codeEditor.Document.Language = language;
		}

		private void DotNetProjectAssemblyReferenceLoader(object sender, DoWorkEventArgs e) {
			// Add some common assemblies for reflection (any custom assemblies could be added using various Add overloads instead)
			projectAssembly.AssemblyReferences.AddMsCorLib();
			#if !NETCORE
			projectAssembly.AssemblyReferences.Add("System");
			projectAssembly.AssemblyReferences.Add("System.Core");
			#endif
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Creates a new file.
		/// </summary>
		private void NewFile() {
			this.OpenFile(String.Format("Document{0}.vb", ++documentNumber), null);
		}
		
		/// <summary>
		/// Occurs when the assembly references have changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>CollectionChangeEventArgs</c> that contains data related to this event.</param>
		private void OnAssemblyReferencesChanged(object sender, Text.Utility.CollectionChangeEventArgs<IProjectAssemblyReference> e) {
			this.RefreshReferenceList();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnAddReferenceToolStripButtonClick(object sender, EventArgs e) {
			// Show a file open dialog
			var dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Assemblies (*.dll)|*.dll|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (var stream = dialog.OpenFile()) {
					// Read the file
					var buffer = new byte[stream.Length];
					stream.Read(buffer, 0, buffer.Length);

					// Create an assembly
					try {
						var assembly = Assembly.ReflectionOnlyLoad(buffer);
						if (assembly != null) {
							// Add to references
							projectAssembly.AssemblyReferences.Add(assembly);

							// Reset list
							this.RefreshReferenceList();
						}
					}
					catch (FileLoadException ex) {
						MessageBox.Show("A file load exception occurred: " + ex.Message, "Error Loading Assembly", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					catch (SecurityException) {
						MessageBox.Show("Sorry but this application must be run in full trust for this to work.", "Error Loading Assembly", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
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
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnRemoveReferenceToolStripButtonClick(object sender, EventArgs e) {
			if (referencesListBox.SelectedIndex == -1) {
				MessageBox.Show("Select a reference first.", "No Reference Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Remove the selected reference
			projectAssembly.AssemblyReferences.RemoveAt(referencesListBox.SelectedIndex);

			// Reset list
			this.RefreshReferenceList();
		}
		
		/// <summary>
		/// Opens a file.
		/// </summary>
		private void OpenFile() {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Visual Basic files (*.vb)|*.vb|All files (*.*)|*.*";
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

		/// <summary>
		/// Refreshes the list.
		/// </summary>
		private void RefreshReferenceList() {
			referencesListBox.Items.Clear();
			foreach (var assemblyRef in projectAssembly.AssemblyReferences)
				referencesListBox.Items.Add(assemblyRef.Assembly.Name);
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Notifies the UI that it has been loaded.
		/// </summary>
		public void NotifyLoaded() {}

		/// <summary>
		/// Notifies the UI that it has been unloaded.
		/// </summary>
		public void NotifyUnloaded() {
			// Clear .NET Languages Add-on project assembly references when the sample unloads
			projectAssembly.AssemblyReferences.Clear();
		}
		
	}

}
