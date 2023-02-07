using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.MacroRecording {

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

			// Initialize which commands are enabled
			RefreshCommandEnabledState();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnPauseRecordingToolStripButtonClick(object sender, EventArgs e) {
			// Execute the command
			editor.ActiveView.ExecuteEditAction(EditorCommands.PauseResumeMacroRecording);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnCancelRecordingToolStripButtonClick(object sender, EventArgs e) {
			// Execute the command
			editor.ActiveView.ExecuteEditAction(EditorCommands.CancelMacroRecording);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnRunRecordedMacroToolStripButtonClick(object sender, EventArgs e) {
			// Execute the command
			editor.ActiveView.ExecuteEditAction(EditorCommands.RunMacro);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnRecordMacroToolStripButtonClick(object sender, EventArgs e) {
			// Execute the command
			editor.ActiveView.ExecuteEditAction(EditorCommands.ToggleMacroRecording);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the <see cref="SyntaxEditor.MacroRecordingStateChanged" /> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorMacroRecordingStateChanged(object sender, EventArgs e) {
			string statusMessage;
			switch (editor.MacroRecording.State) {
				case MacroRecordingState.Recording:
					statusMessage = "Macro recording is active";
					recordMacroToolStripButton.Image = Resources.IconMacroRecordingStop16;
					recordMacroToolStripButton.Text = "Stop Recording";
					pauseRecordingToolStripButton.Checked = false;
					pauseRecordingToolStripButton.Text = "Pause Recording";
					break;
				case MacroRecordingState.Paused:
					statusMessage = "Macro recording is paused";
					pauseRecordingToolStripButton.Checked = true;
					pauseRecordingToolStripButton.Text = "Resume Recording";
					break;
				default:
					statusMessage = null;
					recordMacroToolStripButton.Image = Resources.IconMacroRecordingRecord16;
					recordMacroToolStripButton.Text = "Record Macro";
					pauseRecordingToolStripButton.Checked = false;
					pauseRecordingToolStripButton.Text = "Pause Recording";
					break;
			}

			if (string.IsNullOrWhiteSpace(statusMessage))
				statusMessage = "Ready";
			statusLabel.Text = statusMessage;

			RefreshCommandEnabledState();
		}

		/// <summary>
		/// Refreshes which toolbar commands are enabled based on current application state.
		/// </summary>
		private void RefreshCommandEnabledState() {
			runRecordedMacroToolStripButton.Enabled = EditorCommands.RunMacro.CanExecute(editor.ActiveView);
			recordMacroToolStripButton.Enabled = EditorCommands.ToggleMacroRecording.CanExecute(editor.ActiveView);
			pauseRecordingToolStripButton.Enabled = EditorCommands.PauseResumeMacroRecording.CanExecute(editor.ActiveView);
			cancelRecordingToolStripButton.Enabled = EditorCommands.CancelMacroRecording.CanExecute(editor.ActiveView);
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
					mainToolStrip,
					statusLabel
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
