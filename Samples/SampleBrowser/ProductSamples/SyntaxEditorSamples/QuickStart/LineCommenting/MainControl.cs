using ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03c;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.LineCommenting {

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

			// Load the sample language from the getting started series
			editor.Document.Language = new SimpleSyntaxLanguage();

			// Select the first line commenter
			lineCommentersComboBox.SelectedIndex = 0;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnCommentLinesButtonClick(object sender, EventArgs e) {
			// Comment the lines
			editor.ActiveView.ExecuteEditAction(EditorCommands.CommentLines);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the selection changes in a <see cref="ComboBox"/>.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnLineCommentersComboBoxSelectedValueChanged(object sender, EventArgs e) {
			if (lineCommentersComboBox.SelectedIndex == 0)
				editor.Document.Language.RegisterLineCommenter(new LineBasedLineCommenter() { StartDelimiter = "//" });
			else
				editor.Document.Language.RegisterLineCommenter(new RangeLineCommenter() { StartDelimiter = "/*", EndDelimiter = "*/" });
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUncommentLinesButtonClick(object sender, EventArgs e) {
			// Uncomment the lines
			editor.ActiveView.ExecuteEditAction(EditorCommands.UncommentLines);

			// Focus the editor
			editor.Focus();
		}

	}
}
