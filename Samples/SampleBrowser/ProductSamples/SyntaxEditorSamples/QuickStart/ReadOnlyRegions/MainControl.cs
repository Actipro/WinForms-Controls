﻿using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ReadOnlyRegions {

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

			// Load a language from a language definition
			ISyntaxLanguage language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

			// Attach a custom read-only region tagger to the language (use a singleton key so it can be retrieved later)
			language.RegisterService(new CodeDocumentTaggerProvider<CustomReadOnlyRegionTagger>(typeof(CustomReadOnlyRegionTagger)));

			// Assign the language to the document
			editor.Document.Language = language;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnHighlightRegionsCheckBoxChecked(object sender, EventArgs e) {
			CustomReadOnlyRegionTagger tagger;
			if ((editor != null) && (editor.Document.Properties.TryGetValue(typeof(CustomReadOnlyRegionTagger), out tagger)))
				tagger.HighlightReadOnlyRegions = highlightRegionsCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnMakeSelectionReadOnlyButtonClick(object sender, EventArgs e) {
			CustomReadOnlyRegionTagger tagger;
			if ((editor != null) && (editor.Document.Properties.TryGetValue(typeof(CustomReadOnlyRegionTagger), out tagger))) {
				tagger.Clear();
				if (editor.ActiveView.Selection.Length > 0)
					tagger.Add(editor.ActiveView.Selection.SnapshotRange, new ReadOnlyRegionTag());
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
					highlightRegionsCheckBox,
					makeSelectionReadOnlyButton,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
