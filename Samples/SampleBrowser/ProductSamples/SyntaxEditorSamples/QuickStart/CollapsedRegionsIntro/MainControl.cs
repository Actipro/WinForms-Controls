using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsIntro {

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

			// Load the custom language from this sample
			editor.Document.Language = new CollapsedRegionSyntaxLanguage();

			// Use the document text and language in both editors
			readOnlyEditor.Document.SetText(editor.Document.CurrentSnapshot.Text);
			readOnlyEditor.Document.Language = editor.Document.Language;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnCollapseButtonClick(object sender, EventArgs e) {
			if (editor.ActiveView.Selection.IsZeroLength) {
				MessageBox.Show("Please select at least one character to collapse.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Get the tagger that was created by the language and has been persisted in the document's properties
			//   while the language is active on the document
			CollapsedRegionTagger tagger = null;
			if (editor.Document.Properties.TryGetValue(typeof(CollapsedRegionTagger), out tagger)) {
				// Create a version range
				ITextVersionRange versionRange = editor.ActiveView.Selection.SnapshotRange.ToVersionRange(TextRangeTrackingModes.DeleteWhenZeroLength);

				// Add the tag to the tagger
				tagger.Add(new TagVersionRange<ICollapsedRegionTag>(versionRange, new CollapsedRegionTag()));

				// Collapse the selection
				editor.ActiveView.Selection.Collapse();
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the text of a document changes.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnDocumentTextChanged(object sender, EditorSnapshotChangedEventArgs e) {
			readOnlyEditor.Document.SetText(editor.Document.CurrentSnapshot.Text);
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
					collapseButton
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}
}
