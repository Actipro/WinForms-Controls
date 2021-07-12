using ActiproSoftware.Text.Undo;
using System;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.UndoRedo {

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

			// Listen for changes in undo/redo stacks
			editor.Document.UndoHistory.UndoStack.StackChanged += this.OnSyntaxEditorDocumentUndoStackChanged;
			editor.Document.UndoHistory.RedoStack.StackChanged += this.OnSyntaxEditorDocumentRedoStackChanged;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////


		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnAppendButtonClick(object sender, EventArgs e) {
			editor.Document.AppendText(CustomChangeType.Instance, "\nAppended with custom change type.");
			editor.Focus();
		}

		/// <summary>
		/// Occurs when a mouse is double-clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnRedoStackListBoxDoubleClick(object sender, EventArgs e) {
			int index = redoStack.SelectedIndex;
			if (0 <= index && index < editor.Document.UndoHistory.RedoStack.Count) {
				editor.Document.UndoHistory.Redo(index + 1);
				editor.Focus();
			}
		}

		/// <summary>
		/// Occurs when the items in the stack are changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorDocumentRedoStackChanged(object sender, EventArgs e) {
			SyncUndoableTextChangeStackToListbox((IUndoableTextChangeStack)sender, redoStack);
		}

		/// <summary>
		/// Occurs when the items in the stack are changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorDocumentUndoStackChanged(object sender, EventArgs e) {
			SyncUndoableTextChangeStackToListbox((IUndoableTextChangeStack)sender, undoStack);
		}

		/// <summary>
		/// Occurs when a mouse is double-clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUndoStackListBoxDoubleClick(object sender, EventArgs e) {
			int index = undoStack.SelectedIndex;
			if (0 <= index && index < editor.Document.UndoHistory.UndoStack.Count) {
				editor.Document.UndoHistory.Undo(index + 1);
				editor.Focus();
			}
		}

		/// <summary>
		/// Updates the given list box to include the entries corresponding to the given undo/redo stack.
		/// </summary>
		/// <param name="stack">The undo/redo stack whose entries will be populated in the <paramref name="listBox"/>.</param>
		/// <param name="listBox">The <see cref="ListBox"/> control where entries will be displayed.</param>
		private void SyncUndoableTextChangeStackToListbox(IUndoableTextChangeStack stack, ListBox listBox) {
			listBox.Items.Clear();
			for (int i = 0; i < stack.Count; i++) {
				listBox.Items.Add(stack.GetTextChange(i).Description);
			}
		}
	}
}
