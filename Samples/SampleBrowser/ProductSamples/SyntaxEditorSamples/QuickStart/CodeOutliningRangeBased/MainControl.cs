using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Outlining;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CodeOutliningRangeBased {

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

			// Load the Javascript language defined in this sample
			editor.Document.Language = new JavascriptSyntaxLanguage();

			// Define available outlining modes
			allowedModeToolStripComboBox.Items.AddRange(Enum.GetValues(typeof(OutliningMode)).OfType<object>().ToArray());
			RefreshOutliningStatus();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnAllowedModeComboBoxSelectedIndexChanged(object sender, EventArgs e) {
			if (allowedModeToolStripComboBox.SelectedItem is OutliningMode) {
				editor.Document.OutliningMode = (OutliningMode)allowedModeToolStripComboBox.SelectedItem;
				RefreshOutliningStatus();
			}
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnHighlightsEnabledToggleButtonCheckedChanged(object sender, EventArgs e) {
			editor.IsCollapsibleRegionHighlightingEnabled = toggleHighlightsToolStripButton.Checked;
		}

		/// <summary>
		/// Occurs when the toolstrip item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnMainToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			switch (e.ClickedItem.Name) {
				case nameof(openToolStripButton):
					PromptOpenFile();
					break;
			}
		}

		/// <summary>
		/// Occurs when the item in the drop down menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnOutliningToolStripButtonDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			var editAction = ResolveEditActionForToolStripItem(e.ClickedItem);
			if (editAction != null && editAction.CanExecute(editor.ActiveView)) {
				editAction.Execute(editor.ActiveView);
				RefreshOutliningStatus();
			}
		}

		/// <summary>
		/// Occurs when the drop down of the tool strip drop down button is opening.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnOutliningToolStripButtonDropDownOpening(object sender, EventArgs e) {
			// Set the enabled state of each command
			foreach (var toolStripItem in outliningToolStripDropDownButton.DropDownItems.OfType<ToolStripMenuItem>()) {
				var editAction = ResolveEditActionForToolStripItem(toolStripItem);
				if (editAction != null)
					toolStripItem.Enabled = editAction.CanExecute(editor.ActiveView);
			}
		}

		/// <summary>
		/// Prompts the user to open a file and load the selected file into the editor.
		/// </summary>
		private void PromptOpenFile() {
			var dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Code files (*.js)|*.js|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				editor.Document.LoadFile(dialog.FileName);
			}

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Updates the UI controls which represent the current status of the outlining configuration.
		/// </summary>
		private void RefreshOutliningStatus() {
			allowedModeToolStripComboBox.SelectedItem = editor.Document.OutliningMode;
			activeModeValueToolStripLabel.Text = editor.Document.OutliningManager.ActiveMode.ToString();
		}

		/// <summary>
		/// Returns the editor command associated with a <see cref="ToolStripItem"/>.
		/// </summary>
		/// <param name="menuItem">The menu item.</param>
		/// <returns>Returns the corresponding command if found; otherwise null.</returns>
		private IEditAction ResolveEditActionForToolStripItem(ToolStripItem menuItem) {
			switch (menuItem.Name) {
				case (nameof(collapseToDefinitionsMenuItem)):
					return EditorCommands.CollapseToDefinitions;
				case (nameof(expandAllOutliningMenuItem)):
					return EditorCommands.ExpandAllOutlining;
				case (nameof(hideSelectionMenuItem)):
					return EditorCommands.HideSelection;
				case (nameof(toggleOutliningExpansionMenuItem)):
					return EditorCommands.ToggleOutliningExpansion;
				case (nameof(toggleAllOutliningMenuItem)):
					return EditorCommands.ToggleAllOutliningExpansion;
				case (nameof(stopOutliningMenuItem)):
					return EditorCommands.StopOutlining;
				case (nameof(stopHidingCurrentMenuItem)):
					return EditorCommands.StopHidingCurrent;
				case (nameof(startAutomaticOutliningMenuItem)):
					return EditorCommands.StartAutomaticOutlining;
				case (nameof(applyDefaultOutliningExpansionMenuItem)):
					return EditorCommands.ApplyDefaultOutliningExpansion;
			}
			return null;
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
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
				var manualFontToolStripItems = new ToolStripItem[] {
					allowedModeToolStripComboBox,
					activeModeValueToolStripLabel
				};
				foreach (var toolStripItem in manualFontToolStripItems)
					toolStripItem.Font = DpiHelper.RescaleFont(toolStripItem.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}
}
