using ActiproSoftware.Text;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotTranslation {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private ITextSnapshot originalSnapshot;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize component initialization
			ResizeControls();

			// Load a language from a language definition
			topEditor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
			bottomEditor.Document.Language = topEditor.Document.Language;

			// Store the original snapshot of the bottom document
			originalSnapshot = bottomEditor.Document.CurrentSnapshot;

			// Update the top document with the same content as the bottom
			topEditor.Document.SetText(originalSnapshot.Text);

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUpdateSelectionButtonClick(object sender, EventArgs e) {
			ITextSnapshot currentSnapshot = bottomEditor.ActiveView.CurrentSnapshot;
			TextRange textRange = topEditor.ActiveView.Selection.TextRange.Translate(originalSnapshot, currentSnapshot, TextRangeTrackingModes.Default);
			bottomEditor.ActiveView.Selection.TextRange = textRange;
			bottomEditor.Focus();
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
