﻿using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsHighlightRange {

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
			editor.Document.Language = new HighlightRangeSyntaxLanguage();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnHighlightSelectionButtonClick(object sender, EventArgs e) {
			// Get the current tagger
			if (TryGetTagger(out HighlightRangeTagger tagger)) {
				// Instruct the tagger to highlight the selected range
				tagger.HighlightRange(editor.ActiveView.Selection.SnapshotRange);
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnClearButtonClick(object sender, EventArgs e) {
			if (TryGetTagger(out HighlightRangeTagger tagger)) {
				// Remove all tags to clear the highlights
				tagger.Clear();
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Tries to get the <see cref="HighlightRangeTagger"/> from the active editor document.
		/// </summary>
		/// <param name="tagger">When successful, outputs the <see cref="HighlightRangeTagger"/>.</param>
		/// <returns><c>true</c> if the tagger was successfully located and output through <paramref name="tagger"/>; otherwise <c>false</c>.</returns>
		private bool TryGetTagger(out HighlightRangeTagger tagger) {

			// Implementation Note:
			//
			// When associated with an ICodeDocument, the ISyntaxLanguage will use the registered
			// CodeDocumentTaggerProvider<HighlightRangeTagger> service to create a new instance of HighlightRangeTagger
			// and persist that instance in the ICodeDocument.Properties collection as long as the language
			// is active on the document.

			// Try to get the tagger that was created for the active document
			return editor.Document.Properties.TryGetValue(typeof(HighlightRangeTagger), out tagger);
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
					highlightSelectionButton,
					clearButton
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
