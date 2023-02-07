using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptCompletionFiltering {

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
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

			// Register a custom completion provider on the language used by the editor
			editor.Document.Language.RegisterService<ICompletionProvider>(new CustomCompletionProvider());

			// Update the completion provider options.
			this.UpdateCompletionProviderOptions();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnCompleteWordButtonClick(object sender, EventArgs e) {
			// Ensure the editor has focus
			editor.Focus();

			// Request the auto-complete session which will use the custom completion provider registered on the language.
			editor.ActiveView.IntelliPrompt.RequestAutoComplete();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnShowCompletionListButtonClick(object sender, EventArgs e) {
			// Ensure the editor has focus
			editor.Focus();

			// Request the completion session which will use the custom completion provider registered on the language.
			editor.ActiveView.IntelliPrompt.RequestCompletionSession();
		}

		/// <summary>
		/// Invoked when the checked state changes for any of the <see cref="CheckBox"/> controls in the sample.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnCheckedChanged(object sender, EventArgs e) {
			this.UpdateCompletionProviderOptions();
		}

		/// <summary>
		/// Updates the completion provider settings.
		/// </summary>
		private void UpdateCompletionProviderOptions() {
			if (editor == null)
				return;

			var provider = editor.Document.Language.GetService<ICompletionProvider>() as CustomCompletionProvider;
			if (provider == null)
				return;

			provider.FilterTabsVisible = filterTabsVisibleCheckBox.Checked;
			provider.FilterUnmatchedItems = filterUnmatchedItemsCheckBox.Checked;
			provider.InheritedFilterButtonVisible = inheritedFilterButtonVisibleCheckBox.Checked;
			provider.MemberTypeFilterButtonsVisible = memberTypeFilterButtonsVisibleCheckBox.Checked;
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
					completeWordButton,
					filterTabsVisibleCheckBox,
					filterUnmatchedItemsCheckBox,
					inheritedFilterButtonVisibleCheckBox,
					memberTypeFilterButtonsVisibleCheckBox,
					showCompletionListButton,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
