using ActiproSoftware.Text;
using ActiproSoftware.Text.Parsing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted02 {

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
			// Invoke the handler logic since the parse data change event is raised from a parser worker thread
			this.Invoke(new Action(() => {
				var parseData = editor.Document.ParseData as SimpleParseData;
				if (parseData != null) {
					// Update function count based on reported parse data
					UpdateFunctionCount(parseData.Functions.Count);
				}
				else {
					// Invalid parse data
					UpdateFunctionCount(0);
				}
			}));
		}

		/// <summary>
		/// Update the function count displayed in the header.
		/// </summary>
		/// <param name="functionCount">The number of functions to be displayed.</param>
		private void UpdateFunctionCount(int functionCount) {
			functionCountLabel.Text = functionCount.ToString();
		}
	}
}
