﻿using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptQuickInfo {

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

			// Use Javascript language defined in Code Outlining Range Based QuickStart
			editor.Document.Language = new CodeOutliningRangeBased.JavascriptSyntaxLanguage();

			// Register an IQuickInfoProvider service with the language so that the language can automatically generate
			//   quick info popups based on mouse/keyboard input
			editor.Document.Language.RegisterService(new CustomQuickInfoProvider());
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnShowQuickInfoButtonClick(object sender, EventArgs e) {
			// Ensure the editor has focus
			editor.Focus();

			// Get the IQuickInfoProvider that is registered with the language
			IQuickInfoProvider provider = editor.Document.Language.GetService<CustomQuickInfoProvider>();
			if (provider != null) {
				// Create a context
				object context = provider.GetContext(editor.ActiveView, editor.ActiveView.Selection.CaretOffset);

				if (context != null) {
					// Request that a session is created based on the context, and disable mouse tracking since
					//   this request is initiated from a button click
					provider.RequestSession(editor.ActiveView, context, false);
				}
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
					showQuickInfoButton
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
