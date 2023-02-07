using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using ActiproSoftware.Products.Bars;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features {

	/// <summary>
	/// Provides a <see cref="Form"/> for performing run-time bar customization.
	/// </summary>
	internal partial class BarCustomizeForm : DpiAwareForm {

		private readonly BarManager barManager;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// INNER CLASSES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Represents a comparer for commands based on their customize list text.
		/// </summary>
		private class BarCommandTextComparer : IComparer {

			/// <summary>
			/// Compares two objects and returns a value indicating whether one is less than, equal to or greater than the other.
			/// </summary>
			/// <param name="x">First object to compare.</param>
			/// <param name="y">Second object to compare.</param>
			/// <returns>A value indicating whether one is less than, equal to or greater than the other.</returns>
			public int Compare(object x, object y) {
				string xText = (((BarCommand)x).CustomizeListText != null ? ((BarCommand)x).CustomizeListText : 
					(((BarCommand)x).Text != null ? ((BarCommand)x).Text.Replace("&", String.Empty) : null));
				string yText = (((BarCommand)y).CustomizeListText != null ? ((BarCommand)y).CustomizeListText : 
					(((BarCommand)y).Text != null ? ((BarCommand)y).Text.Replace("&", String.Empty) : null));
				return String.Compare(xText, yText);
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>BarCustomizeForm</c> class.
		/// </summary>
		/// <param name="barManager">The manager being edited.</param>
		public BarCustomizeForm(BarManager barManager) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Add any constructor code after InitializeComponent call
			//

			// Initialize parameters
			this.barManager = barManager;

			// Set the bar manager to the command listbox
			barCommandListBox.BarManager = barManager;

			// Initialize the form
			this.OnInitForm();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT CALLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the form needs to be initialized.
		/// </summary>
		private void OnInitForm() {
			// Update the colors for themes
			if (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported) {
				foreach (TabPage tabPage in tabStrip.TabPages)
					tabPage.BackColor = SystemColors.Window;
			}

			// Rebind listboxes
			this.RebindToolBarListBox(0);
			this.RebindCommandCategoryListBox();

			// Populate the drop-down list
			useNewShortcutInDropDownList.Items.Add("Global");
			if (barManager.Modes.Count > 0)
				useNewShortcutInDropDownList.Items.AddRange(barManager.Modes.ToArray());
			useNewShortcutInDropDownList.SelectedIndex = 0;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void assignShortcutButton_Click(object sender, System.EventArgs e) {
			// Get the command
			BarCommand command = barManager.Commands[showCommandsContainingListBox.Text];

			// Get the shortcut
			BarKeyboardShortcut shortcut = new BarKeyboardShortcut(
				(useNewShortcutInDropDownList.Text != "Global" ? useNewShortcutInDropDownList.Text : null), 
				shortcutTextBox.ChordKey,
				shortcutTextBox.Key
				);

			// Quit if the shortcut is already in the list
			if (command.KeyboardShortcuts.Contains(shortcut))
				return;

			// Ensure that the shortcut is not protected
			if (barManager.IsShortcutProtected(shortcut)) {
				MessageBox.Show(this, String.Format("Sorry but the key '{0}' is protected and cannot be assigned or removed.", shortcut.ToString()), 
					"Protected Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (shortcut.ChordKey != Keys.None) {
				// Ensure that the chord start key is not already a standalone key
				if (barManager.IsKeyStandalone(shortcut.Mode, shortcut.ChordKey)) {
					MessageBox.Show(this, String.Format("Sorry but the key combination '{0}' is already in use as a standalone key.  Please remove that keyboard shortcut first.", BarKeyboardShortcut.GetKeyString(shortcut.ChordKey)), 
						"Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			else {
				// Ensure that the key is not already a chord start key
				if (barManager.IsKeyAChordStart(shortcut.Mode, shortcut.Key)) {
					MessageBox.Show(this, String.Format("Sorry but the key combination '{0}' is already in use as a chord start key in one or more keyboard shortcuts.  Please remove those keyboard shortcuts first.", BarKeyboardShortcut.GetKeyString(shortcut.Key)), 
						"Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			// Add the shortcut
			command.KeyboardShortcuts.Add(shortcut);		

			// Update the list
			this.UpdateShortcutsForSelectedCommandDropDownList();
			shortcutsForSelectedCommandDropDownList.SelectedItem = shortcut;

			// Clear the shortcut textbox
			shortcutTextBox.ClearKeys();

			// Update the shortcut currently used by list
			this.UpdateShortcutCurrentlyUsedBy();
		}

		/// <summary>
		/// Occurs when the selected index of the drop-down list changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void barCommandCategoryListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			this.RebindBarCommandListBox(0);
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void modifySelectionButton_Click(object sender, System.EventArgs e) {
			barManager.ShowCustomizeModifySelectionMenu(this, barManager.CustomizeSelectedCommandLink, 
				modifySelectionButton.RectangleToScreen(modifySelectionButton.ClientRectangle));
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void okButton_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void removeShortcutButton_Click(object sender, System.EventArgs e) {
			// Get the shortcut
			BarKeyboardShortcut shortcut = (BarKeyboardShortcut)shortcutsForSelectedCommandDropDownList.SelectedItem;

			// Ensure that the shortcut is not protected
			if (barManager.IsShortcutProtected(shortcut)) {
				MessageBox.Show(this, String.Format("Sorry but the key '{0}' is protected and cannot be assigned or removed.", shortcut.ToString()), 
					"Protected Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Remove the shortcut
			BarCommand command = barManager.Commands[showCommandsContainingListBox.Text];
			command.KeyboardShortcuts.Remove(shortcut);

			// Rebuild the list
			this.UpdateShortcutsForSelectedCommandDropDownList();		

			// Update the shortcut currently used by list
			this.UpdateShortcutCurrentlyUsedBy();
		}

		/// <summary>
		/// Occurs when the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void showCommandsContainingListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			this.UpdateShortcutsForSelectedCommandDropDownList();
		}

		/// <summary>
		/// Occurs when the text is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void shortcutTextBox_TextChanged(object sender, System.EventArgs e) {
			// Update the enabled state of the assign button
            assignShortcutButton.Enabled = (shortcutTextBox.Text.Length > 0);		

			// Update the shortcut currently used by list
			this.UpdateShortcutCurrentlyUsedBy();
		}

		/// <summary>
		/// Occurs when the text is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void showCommandsContainingTextBox_TextChanged(object sender, System.EventArgs e) {
			this.UpdateShowCommandsContainingList();		
		}

		/// <summary>
		/// Occurs when the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void tabStrip_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (tabStrip.SelectedTab == keyboardTab)
				this.UpdateShowCommandsContainingList();				
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void toolBarDeleteButton_Click(object sender, System.EventArgs e) {
			// Get the selected index
			int selectedIndex = toolBarListBox.SelectedIndex;
			DockableToolBar toolBar = (DockableToolBar)toolBarListBox.SelectedItem;

			// Confirm with user
			if (MessageBox.Show(this, String.Format("Are you sure you want to delete the '{0}' toolbar?", toolBar.TitleBarText), "Customize",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				return;

			// Remove the toolbar
			barManager.DockableToolBars.Remove(toolBar);
			this.RebindToolBarListBox(selectedIndex);
		}

		/// <summary>
		/// Occurs when an item is checked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>ItemCheckEventArgs</c> that contains the event data.</param>
		private void toolBarListBox_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e) {
			// Get the selected toolbar
			int selectedIndex = toolBarListBox.SelectedIndex;
			DockableToolBar toolBar = (DockableToolBar)toolBarListBox.SelectedItem;

			if (toolBar != null) {
				// Prevent toolbars from being closed that are not permitted to close
				if ((!toolBar.CanCloseResolved) && (e.NewValue == CheckState.Unchecked)) {
					e.NewValue = CheckState.Checked;
					MessageBox.Show(this, String.Format("The toolbar '{0}' cannot be closed.", toolBar.TitleBarText), "Cannot Close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				// Update the active property on the toolbar
				toolBar.Active = (e.NewValue == CheckState.Checked);

				// Remove the toolbar from the list if it has been disposed
				if ((!toolBar.Active) && (!barManager.DockableToolBars.Contains(toolBar))) {
					if (e.Index + 1 < toolBarListBox.Items.Count)
						e.NewValue = toolBarListBox.GetItemCheckState(e.Index + 1);
					toolBarListBox.Items.Remove(toolBar);
					if (toolBarListBox.SelectedIndex == -1)
						toolBarListBox.SelectedIndex = Math.Min(selectedIndex, toolBarListBox.Items.Count - 1);
				}
			}
		}

		/// <summary>
		/// Occurs when the selected index of the listbox changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void toolBarListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			this.UpdateToolBarButtons();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void toolBarNewButton_Click(object sender, System.EventArgs e) {
			// Show the form
			using (var form = new BarCustomizeNewToolBarForm(barManager, "New Toolbar")) {
				form.ShowDialog(this);
				if (form.DialogResult == DialogResult.Cancel)
					return;

				// Add the toolbar
				var toolBar = new DockableToolBar(form.ToolBarKey);
				barManager.DockableToolBars.Add(toolBar);
				toolBar.CreationStyle = DockableToolBarCreationStyle.Custom;
				toolBar.DockTo(DockableToolBarPosition.Top, 1000, 0, true);
				this.RebindToolBarListBox(-1);
			}
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void toolBarRenameButton_Click(object sender, System.EventArgs e) {
			// Get the selected index
			int selectedIndex = toolBarListBox.SelectedIndex;
			var toolBar = (DockableToolBar)toolBarListBox.SelectedItem;

			// Show the form
			using (var form = new BarCustomizeNewToolBarForm(barManager, "Rename Toolbar")) {
				form.ToolBarKey = toolBar.Key;
				form.ShowDialog(this);
				if (form.DialogResult == DialogResult.Cancel)
					return;

				// Update the key
				toolBar.Key = form.ToolBarKey;
				this.RebindToolBarListBox(selectedIndex);
			}
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void toolBarResetButton_Click(object sender, System.EventArgs e) {
			// Get the selected index
			int selectedIndex = toolBarListBox.SelectedIndex;
			DockableToolBar toolBar = (DockableToolBar)toolBarListBox.SelectedItem;
			
			// Confirm with user
			if (MessageBox.Show(this, String.Format("Are you sure you want to reset the changes made to the '{0}' toolbar?", toolBar.TitleBarText), "Customize",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
				return;

			// Reset the toolbar
			toolBar.Reset();
		}
		
		/// <summary>
		/// Occurs when the drop-down is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void useNewShortcutInDropDownList_DropDown(object sender, EventArgs e) {
			// Measure each item to determine the width
			int width = useNewShortcutInDropDownList.Width;
			Font font = useNewShortcutInDropDownList.Font;
			int verticalScrollBarWidth = (useNewShortcutInDropDownList.Items.Count > useNewShortcutInDropDownList.MaxDropDownItems ? SystemInformation.VerticalScrollBarWidth : 0);
			foreach (string item in useNewShortcutInDropDownList.Items)
				width = Math.Max(width, TextRenderer.MeasureText(item, font).Width + verticalScrollBarWidth);

			// Set the new drop-down width
			useNewShortcutInDropDownList.DropDownWidth = Math.Min(width, useNewShortcutInDropDownList.Width * 3);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Rebinds the bar commands listbox.
		/// </summary>
		/// <param name="selectedIndex">The index to attempt to select.</param>
		private void RebindBarCommandListBox(int selectedIndex) {
			// Get the selected category
			string selectedCategory = null;
			if (barCommandCategoryListBox.SelectedIndex != -1)
				selectedCategory = barCommandCategoryListBox.Text;

			// Add the bar commands to the list
			barCommandListBox.Items.Clear();
			ArrayList barCommands = new ArrayList();
			foreach (BarCommand command in barManager.Commands) {
				// If the command should be displayed in the command list...
				if (command.CanCustomizeCreate) {
					// Localize
					string category = command.Category;
					if (barManager.CategoryLocalization.ContainsKey(category))
						category = barManager.CategoryLocalization[category];

					if ((selectedCategory == null) || (String.Compare(category, selectedCategory, true) == 0))
						barCommands.Add(command);
				}
			}
			object[] barCommandArray = barCommands.ToArray();
			Array.Sort(barCommandArray, new BarCommandTextComparer());
			barCommandListBox.Items.AddRange(barCommandArray);

			// Try to select the desired item
			if (barCommandListBox.Items.Count > 0) {
				if (selectedIndex < barCommandListBox.Items.Count)
					barCommandListBox.SelectedIndex = selectedIndex;
				else
					barCommandListBox.SelectedIndex = barCommandListBox.Items.Count - 1;
			}
		}

		/// <summary>
		/// Rebinds the category listbox.
		/// </summary>
		private void RebindCommandCategoryListBox() {
			// Add the categories
			string selectedCategory = barCommandCategoryListBox.Text;
			barCommandCategoryListBox.Items.Clear();
			string[] categories = barManager.GetCustomizableCategories();
			for (int index = 0; index < categories.Length; index++) {
				// Localize
				string category = categories[index];
				if (barManager.CategoryLocalization.ContainsKey(category))
					category = barManager.CategoryLocalization[category];

				barCommandCategoryListBox.Items.Add(category);
				if (categories[index] == selectedCategory) {
					barCommandCategoryListBox.SelectedIndex = index;
					break;
				}
			}
			if ((barCommandCategoryListBox.SelectedIndex == -1) && (barCommandCategoryListBox.Items.Count > 0))
				barCommandCategoryListBox.SelectedIndex = 0;
		}

		/// <summary>
		/// Rebinds the toolbars listbox.
		/// </summary>
		/// <param name="selectedIndex">The index to attempt to select.</param>
		private void RebindToolBarListBox(int selectedIndex) {
			// Build the list
			toolBarListBox.Items.Clear();
			toolBarListBox.DisplayMember = "TitleBarText";
			foreach (DockableToolBar toolBar in barManager.DockableToolBars) {
				int index = toolBarListBox.Items.Add(toolBar);
				toolBarListBox.SetItemChecked(index, toolBar.Active);
			}

			// Try to select the desired item
			if (toolBarListBox.Items.Count > 0) {
				if ((selectedIndex >= 0) && (selectedIndex < toolBarListBox.Items.Count))
					toolBarListBox.SelectedIndex = selectedIndex;
				else
					toolBarListBox.SelectedIndex = toolBarListBox.Items.Count - 1;
			}
		}

		/// <summary>
		/// Updates the shortcut currently used by list.
		/// </summary>
		private void UpdateShortcutCurrentlyUsedBy() {
			// Update the shortcut currently used by
			shortcutCurrentlyUsedByDropDownList.Items.Clear();
			if (shortcutTextBox.Text.Length > 0) {
				// Look for a match
				foreach (BarCommand command in barManager.Commands) {
					foreach (BarKeyboardShortcut shortcut in command.KeyboardShortcuts) {
						if ((shortcutTextBox.ChordKey == shortcut.ChordKey) && (shortcutTextBox.Key == shortcut.Key))
							shortcutCurrentlyUsedByDropDownList.Items.Add(String.Format("{0} ({1})", command.FullName, shortcut.Description));
					}
				}

				// Select the first item
				if (shortcutCurrentlyUsedByDropDownList.Items.Count > 0)
					shortcutCurrentlyUsedByDropDownList.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Updates the shortcuts for selected command drop-down list.
		/// </summary>
		private void UpdateShortcutsForSelectedCommandDropDownList() {
			// Clear the list
			shortcutsForSelectedCommandDropDownList.Items.Clear();
			
			// Populate the list
			if (showCommandsContainingListBox.SelectedIndex != -1) {
				BarCommand command = barManager.Commands[showCommandsContainingListBox.Text];
				if (command != null) {
					foreach (BarKeyboardShortcut shortcut in command.KeyboardShortcuts)
						shortcutsForSelectedCommandDropDownList.Items.Add(shortcut);
				}				
			}		

			// Select the first item
			if (shortcutsForSelectedCommandDropDownList.Items.Count > 0)
				shortcutsForSelectedCommandDropDownList.SelectedIndex = 0;

			// Change the enabled state of the remove button
			removeShortcutButton.Enabled = (shortcutsForSelectedCommandDropDownList.SelectedIndex != -1);
		}

		/// <summary>
		/// Updates the show commands containing list.
		/// </summary>
		private void UpdateShowCommandsContainingList() {
			// Get the filter text
			string filter = showCommandsContainingTextBox.Text.Trim().ToUpper();

			// Clear the list
			showCommandsContainingListBox.Items.Clear();

			// Populate the list
			foreach (BarCommand command in barManager.Commands) {
				if ((command.CanCustomizeKeyboardShortcuts) && ((filter.Length == 0) || (command.FullName.ToUpper().IndexOf(filter) != -1)))
					showCommandsContainingListBox.Items.Add(command.FullName);
			}

			// Try to select the first item
			if (showCommandsContainingListBox.Items.Count > 0)
				showCommandsContainingListBox.SelectedIndex = 0;
		}

		/// <summary>
		/// Updates the toolbar button enabled states.
		/// </summary>
		private void UpdateToolBarButtons() {
			// Get the selected toolbar
			DockableToolBar toolBar = (DockableToolBar)toolBarListBox.SelectedItem;

			toolBarRenameButton.Enabled = ((toolBar != null) && (toolBar.CreationStyle == DockableToolBarCreationStyle.Custom));
			toolBarDeleteButton.Enabled = ((toolBar != null) && (toolBar.CreationStyle == DockableToolBarCreationStyle.Custom));
			toolBarResetButton.Enabled = ((toolBar != null) && (toolBar.CreationStyle != DockableToolBarCreationStyle.Custom));
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc/>
		protected override bool IsDpiAwareFormShowBehaviorEnabled => true;

		/// <summary>
		/// Raises the <c>Closing</c> event.
		/// </summary>
		/// <param name="e">An <c>CancelEventArgs</c> that contains the event data.</param>
		protected override void OnClosing(CancelEventArgs e) {
			// Call the base method
			base.OnClosing(e);

			// Stop customize mode when the window is closed
			barManager.CustomizeMode = BarCustomizeMode.None;

			// Workaround for the activation bug in Windows Forms
			if (this.Owner != null)
				this.Owner.Activate();
		}

		/// <summary>
		/// Updates the selected command link data.
		/// </summary>
		/// <param name="commandLink">The <see cref="BarCommandLink"/> that was selected.</param>
		public void UpdateSelectedCommandLink(BarCommandLink commandLink) {
			if (commandLink != null)
				selectedCommandDescriptionLabel.Text = commandLink.CommandCore.FullName;
			else
				selectedCommandDescriptionLabel.Text = String.Empty;

			modifySelectionButton.Enabled = (commandLink != null);
		}

	}
}
