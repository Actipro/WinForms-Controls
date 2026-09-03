using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features;

/// <summary>
/// Provides a <see cref="Form"/> for performing run-time bar customization.
/// </summary>
internal partial class BarCustomizeForm : DpiAwareForm {

	private const string GlobalModeName = "Global";

	// --------------------------------------------------------------------------------------------------
	// NESTED TYPES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Represents a comparer for commands based on their customize list text.
	/// </summary>
	private class BarCommandTextComparer : IComparer {

		private static string? GetCompareText(object? obj) {
			if (obj is BarCommand command) {
				return (command.CustomizeListText is { } customizeText)
					? customizeText
					: MnemonicHelper.RemoveMnemonics(command.Text);
			}
			return null;
		}

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to or greater than the other.
		/// </summary>
		/// <param name="x">First object to compare.</param>
		/// <param name="y">Second object to compare.</param>
		/// <returns>A value indicating whether one is less than, equal to or greater than the other.</returns>
		public int Compare(object? x, object? y)
			=> string.Compare(GetCompareText(x), GetCompareText(y));

	}

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
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
		BarManager = barManager ?? throw new ArgumentNullException(nameof(barManager));

		// Set the bar manager to the command listbox
		barCommandListBox.BarManager = barManager;

		// Initialize the form
		OnInitForm();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// The manager being edited.
	/// </summary>
	private BarManager BarManager { get; }

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnAssignShortcutButtonClick(object sender, EventArgs e) {
		// Get the command
		if (BarManager.Commands[showCommandsContainingListBox.Text] is not { } command)
			return;

		// Get the shortcut
		var shortcut = new BarKeyboardShortcut(
			(useNewShortcutInDropDownList.Text != GlobalModeName ? useNewShortcutInDropDownList.Text : null),
			shortcutTextBox.ChordKey,
			shortcutTextBox.Key
			);

		// Quit if the shortcut is already in the list
		if (command.KeyboardShortcuts.Contains(shortcut))
			return;

		// Ensure that the shortcut is not protected
		if (BarManager.IsShortcutProtected(shortcut)) {
			MessageBox.Show(this, string.Format("Sorry but the key '{0}' is protected and cannot be assigned or removed.", shortcut.ToString()),
				"Protected Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}

		if (shortcut.ChordKey != Keys.None) {
			// Ensure that the chord start key is not already a standalone key
			if (BarManager.IsKeyStandalone(shortcut.Mode, shortcut.ChordKey)) {
				MessageBox.Show(this, string.Format("Sorry but the key combination '{0}' is already in use as a standalone key.  Please remove that keyboard shortcut first.", BarKeyboardShortcut.GetKeyString(shortcut.ChordKey)),
					"Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		else {
			// Ensure that the key is not already a chord start key
			if (BarManager.IsKeyAChordStart(shortcut.Mode, shortcut.Key)) {
				MessageBox.Show(this, string.Format("Sorry but the key combination '{0}' is already in use as a chord start key in one or more keyboard shortcuts.  Please remove those keyboard shortcuts first.", BarKeyboardShortcut.GetKeyString(shortcut.Key)),
					"Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}

		// Add the shortcut
		command.KeyboardShortcuts.Add(shortcut);

		// Update the list
		UpdateShortcutsForSelectedCommandDropDownList();
		shortcutsForSelectedCommandDropDownList.SelectedItem = shortcut;

		// Clear the shortcut textbox
		shortcutTextBox.ClearKeys();

		// Update the shortcut currently used by list
		UpdateShortcutCurrentlyUsedBy();
	}

	/// <summary>
	/// Occurs when the selected index of the drop-down list changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarCommandCategoryListBoxSelectedIndexChanged(object sender, EventArgs e)
		=> RebindBarCommandListBox(selectedIndex: 0);

	/// <summary>
	/// Occurs when the form needs to be initialized.
	/// </summary>
	private void OnInitForm() {
		// Update the colors for themes
		if (System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported) {
			foreach (var tabPage in tabStrip.TabPages.Cast<TabPage>())
				tabPage.BackColor = SystemColors.Window;
		}

		// Rebind listboxes
		RebindToolBarListBox(0);
		RebindCommandCategoryListBox();

		// Populate the drop-down list
		useNewShortcutInDropDownList.Items.Add(GlobalModeName);
		if (BarManager.Modes.Count > 0)
			useNewShortcutInDropDownList.Items.AddRange([.. BarManager.Modes]);
		useNewShortcutInDropDownList.SelectedIndex = 0;
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnModifySelectionButtonClick(object sender, EventArgs e) {
		if (BarManager.CustomizeSelectedCommandLink is { } selectedCommandLink) {
			BarManager.ShowCustomizeModifySelectionMenu(
				this,
				selectedCommandLink,
				modifySelectionButton.RectangleToScreen(modifySelectionButton.ClientRectangle)
			);
		}
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnOkButtonClick(object sender, EventArgs e)
		=> Close();

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnRemoveShortcutButtonClick(object sender, EventArgs e) {
		// Get the shortcut
		if (shortcutsForSelectedCommandDropDownList.SelectedItem is not BarKeyboardShortcut shortcut)
			return;

		// Ensure that the shortcut is not protected
		if (BarManager.IsShortcutProtected(shortcut)) {
			MessageBox.Show(this, string.Format("Sorry but the key '{0}' is protected and cannot be assigned or removed.", shortcut.ToString()),
				"Protected Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}

		// Remove the shortcut
		var command = BarManager.Commands[showCommandsContainingListBox.Text];
		command?.KeyboardShortcuts.Remove(shortcut);

		// Rebuild the list
		UpdateShortcutsForSelectedCommandDropDownList();

		// Update the shortcut currently used by list
		UpdateShortcutCurrentlyUsedBy();
	}

	/// <summary>
	/// Occurs when the selected index is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnShowCommandsContainingListBoxSelectedIndexChanged(object sender, EventArgs e)
		=> UpdateShortcutsForSelectedCommandDropDownList();

	/// <summary>
	/// Occurs when the text is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnShortcutTextBoxTextChanged(object sender, EventArgs e) {
		// Update the enabled state of the assign button
		assignShortcutButton.Enabled = (shortcutTextBox.Text.Length > 0);

		// Update the shortcut currently used by list
		UpdateShortcutCurrentlyUsedBy();
	}

	/// <summary>
	/// Occurs when the text is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnShowCommandsContainingTextBoxTextChanged(object sender, EventArgs e)
		=> UpdateShowCommandsContainingList();

	/// <summary>
	/// Occurs when the selected index is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnTabStripSelectedIndexChanged(object sender, EventArgs e) {
		if (tabStrip.SelectedTab == keyboardTab)
			UpdateShowCommandsContainingList();
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarDeleteButtonClick(object sender, EventArgs e) {
		// Get the selected index
		int selectedIndex = toolBarListBox.SelectedIndex;
		if (toolBarListBox.SelectedItem is not DockableToolBar toolBar)
			return;

		// Confirm with user
		if (MessageBox.Show(this, string.Format("Are you sure you want to delete the '{0}' toolbar?", toolBar.TitleBarText), "Customize",
			MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			return;

		// Remove the toolbar
		BarManager.DockableToolBars.Remove(toolBar);
		RebindToolBarListBox(selectedIndex);
	}

	/// <summary>
	/// Occurs when an item is checked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarListBoxItemCheck(object sender, ItemCheckEventArgs e) {
		// Get the selected toolbar
		int selectedIndex = toolBarListBox.SelectedIndex;
		if (toolBarListBox.SelectedItem is not DockableToolBar toolBar)
			return;

		// Prevent toolbars from being closed that are not permitted to close
		if ((!toolBar.CanCloseResolved) && (e.NewValue == CheckState.Unchecked)) {
			e.NewValue = CheckState.Checked;
			MessageBox.Show(this, string.Format("The toolbar '{0}' cannot be closed.", toolBar.TitleBarText), "Cannot Close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}

		// Update the active property on the toolbar
		toolBar.Active = (e.NewValue == CheckState.Checked);

		// Remove the toolbar from the list if it has been disposed
		if ((!toolBar.Active) && (!BarManager.DockableToolBars.Contains(toolBar))) {
			if (e.Index + 1 < toolBarListBox.Items.Count)
				e.NewValue = toolBarListBox.GetItemCheckState(e.Index + 1);
			toolBarListBox.Items.Remove(toolBar);
			if (toolBarListBox.SelectedIndex == -1)
				toolBarListBox.SelectedIndex = Math.Min(selectedIndex, toolBarListBox.Items.Count - 1);
		}
	}

	/// <summary>
	/// Occurs when the selected index of the listbox changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarListBoxSelectedIndexChanged(object sender, EventArgs e)
		=> UpdateToolBarButtons();

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarNewButtonClick(object sender, EventArgs e) {
		// Show the form
		using var form = new BarCustomizeNewToolBarForm(BarManager, "New Toolbar");
		form.ShowDialog(this);
		if (form.DialogResult == DialogResult.Cancel)
			return;

		// Add the toolbar
		var toolBar = new DockableToolBar(form.ToolBarKey);
		BarManager.DockableToolBars.Add(toolBar);
		toolBar.CreationStyle = DockableToolBarCreationStyle.Custom;
		toolBar.DockTo(DockableToolBarPosition.Top, 1000, 0, true);
		RebindToolBarListBox(-1);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarRenameButtonClick(object sender, EventArgs e) {
		// Get the selected index
		int selectedIndex = toolBarListBox.SelectedIndex;
		if (toolBarListBox.SelectedItem is not DockableToolBar toolBar)
			return;

		// Show the form
		using var form = new BarCustomizeNewToolBarForm(BarManager, "Rename Toolbar");
		form.ToolBarKey = toolBar.Key;
		form.ShowDialog(this);
		if (form.DialogResult == DialogResult.Cancel)
			return;

		// Update the key
		toolBar.Key = form.ToolBarKey;
		RebindToolBarListBox(selectedIndex);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarResetButtonClick(object sender, EventArgs e) {
		// Get the selected index
		if (toolBarListBox.SelectedItem is not DockableToolBar toolBar)
			return;

		// Confirm with user
		if (MessageBox.Show(this, string.Format("Are you sure you want to reset the changes made to the '{0}' toolbar?", toolBar.TitleBarText), "Customize",
			MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			return;

		// Reset the toolbar
		toolBar.Reset();
	}

	/// <summary>
	/// Occurs when the drop-down is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnUseNewShortcutInDropDownListDropDown(object sender, EventArgs e) {
		// Measure each item to determine the width
		var width = useNewShortcutInDropDownList.Width;
		var font = useNewShortcutInDropDownList.Font;
		var verticalScrollBarWidth = (useNewShortcutInDropDownList.Items.Count > useNewShortcutInDropDownList.MaxDropDownItems ? SystemInformation.VerticalScrollBarWidth : 0);
		foreach (var item in useNewShortcutInDropDownList.Items.Cast<string>())
			width = Math.Max(width, TextRenderer.MeasureText(item, font).Width + verticalScrollBarWidth);

		// Set the new drop-down width
		useNewShortcutInDropDownList.DropDownWidth = Math.Min(width, useNewShortcutInDropDownList.Width * 3);
	}

	/// <summary>
	/// Rebinds the bar commands listbox.
	/// </summary>
	/// <param name="selectedIndex">The index to attempt to select.</param>
	private void RebindBarCommandListBox(int selectedIndex) {
		// Get the selected category
		string? selectedCategory = null;
		if (barCommandCategoryListBox.SelectedIndex != -1)
			selectedCategory = barCommandCategoryListBox.Text;

		// Add the bar commands to the list
		barCommandListBox.Items.Clear();
		var barCommands = new List<BarCommand>();
		foreach (var command in BarManager.Commands) {
			// If the command should be displayed in the command list...
			if (command.CanCustomizeCreate) {
				// Localize
				var category = command.Category;
				if (BarManager.CategoryLocalization.ContainsKey(category))
					category = BarManager.CategoryLocalization[category];

				if ((selectedCategory is null) || (string.Compare(category, selectedCategory, ignoreCase: true) == 0))
					barCommands.Add(command);
			}
		}
		var barCommandArray = barCommands.ToArray();
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
		var selectedCategory = barCommandCategoryListBox.Text;
		barCommandCategoryListBox.Items.Clear();
		var categories = BarManager.GetCustomizableCategories();
		for (int index = 0; index < categories.Length; index++) {
			// Localize
			var category = categories[index];
			if (BarManager.CategoryLocalization.ContainsKey(category))
				category = BarManager.CategoryLocalization[category];

			if (category is not null) {
				barCommandCategoryListBox.Items.Add(category);
				if (categories[index] == selectedCategory) {
					barCommandCategoryListBox.SelectedIndex = index;
					break;
				}
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
		foreach (var toolBar in BarManager.DockableToolBars) {
			int index = toolBarListBox.Items.Add(toolBar);
			toolBarListBox.SetItemChecked(index, toolBar.Active);
		}

		// Try to select the desired item
		if (toolBarListBox.Items.Count > 0) {
			if ((0 <= selectedIndex) && (selectedIndex < toolBarListBox.Items.Count))
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
			foreach (var command in BarManager.Commands) {
				foreach (var shortcut in command.KeyboardShortcuts) {
					if ((shortcutTextBox.ChordKey == shortcut.ChordKey) && (shortcutTextBox.Key == shortcut.Key))
						shortcutCurrentlyUsedByDropDownList.Items.Add(string.Format("{0} ({1})", command.FullName, shortcut.Description));
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
			if (BarManager.Commands[showCommandsContainingListBox.Text] is { } command) {
				foreach (var shortcut in command.KeyboardShortcuts)
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
		foreach (var command in BarManager.Commands) {
			if ((command.CanCustomizeKeyboardShortcuts) && ((filter.Length == 0) || (command.FullName.ToUpper().Contains(filter))))
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
		var toolBar = (DockableToolBar?)toolBarListBox.SelectedItem;

		toolBarRenameButton.Enabled = ((toolBar is not null) && (toolBar.CreationStyle == DockableToolBarCreationStyle.Custom));
		toolBarDeleteButton.Enabled = ((toolBar is not null) && (toolBar.CreationStyle == DockableToolBarCreationStyle.Custom));
		toolBarResetButton.Enabled = ((toolBar is not null) && (toolBar.CreationStyle != DockableToolBarCreationStyle.Custom));
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override bool IsDpiAwareFormShowBehaviorEnabled
		=> true;

	/// <inheritdoc/>
	protected override void OnFormClosed(FormClosedEventArgs e) {
		// Call the base method
		base.OnFormClosed(e);

		// Stop customize mode when the window is closed
		BarManager.CustomizeMode = BarCustomizeMode.None;

		// Workaround for the activation bug in Windows Forms
		Owner?.Activate();
	}

	/// <summary>
	/// Updates the selected command link data.
	/// </summary>
	/// <param name="commandLink">The <see cref="BarCommandLink"/> that was selected.</param>
	public void UpdateSelectedCommandLink(BarCommandLink? commandLink) {
		if (commandLink is not null)
			selectedCommandDescriptionLabel.Text = commandLink.CommandCore.FullName;
		else
			selectedCommandDescriptionLabel.Text = string.Empty;

		modifySelectionButton.Enabled = (commandLink is not null);
	}

}
