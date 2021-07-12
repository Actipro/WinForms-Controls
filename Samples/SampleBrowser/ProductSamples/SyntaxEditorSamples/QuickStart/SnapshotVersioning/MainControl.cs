using ActiproSoftware.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotVersioning {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private List<ITextSnapshot> snapshotList;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			snapshotList = new List<ITextSnapshot>();

			// Finalize component initialization
			ResizeControls();

			// Load a language from a language definition
			topEditor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
			bottomEditor.Document.Language = topEditor.Document.Language;

			// Append the first snapshot
			this.AppendSnapshot(topEditor.Document.CurrentSnapshot);
			snapshotListBox.SelectedIndex = 0;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Appends a snapshot to the list.
		/// </summary>
		/// <param name="snapshot">The <see cref="ITextSnapshot"/> to append.</param>
		private void AppendSnapshot(ITextSnapshot snapshot) {
			snapshotList.Add(snapshot);
			snapshotListBox.SelectedIndex = snapshotListBox.Items.Add("Version " + snapshot.Version.Number + " (" + snapshot.Version.Length + ")");
		}

		/// <summary>
		/// Occurs when the selection has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSnapshotListBoxSelectedIndexChanged(object sender, EventArgs e) {
			var index = snapshotListBox.SelectedIndex;
			if (0 <= index && index < snapshotList.Count) {
				var snapshot = snapshotList[index];
				bottomEditor.Document.SetText(snapshot.Text);
			}
		}

		/// <summary>
		/// Occurs after the editor's document text has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorSnapshotChangedEventArgs"/> that contains the event data.</param>
		private void OnTopEditorDocumentTextChanged(object sender, UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangedEventArgs e) {
			this.AppendSnapshot(e.NewSnapshot);
		}

		/// <summary>
		/// Occurs when the control is resized.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUpperPanelResize(object sender, EventArgs e) {
			ResizeControls();
		}

		/// <summary>
		/// Resizes controls on the form based on current conditions.
		/// </summary>
		private void ResizeControls() {
			// Adjust label maximimum width to allow for proper word-wrapping when auto-sized and docked
			foreach (var label in upperPanel.Controls.OfType<Label>()) {
				label.MaximumSize = new System.Drawing.Size(upperPanel.Width, 0);
			}
		}

	}
}
