namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features {
	partial class BarCustomizeForm {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.okButton = new System.Windows.Forms.Button();
            this.tabStrip = new System.Windows.Forms.TabControl();
            this.toolBarsTab = new System.Windows.Forms.TabPage();
            this.toolBarsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolBarListBox = new System.Windows.Forms.CheckedListBox();
            this.toolBarResetButton = new System.Windows.Forms.Button();
            this.toolBarsLabel = new System.Windows.Forms.Label();
            this.toolBarDeleteButton = new System.Windows.Forms.Button();
            this.toolBarRenameButton = new System.Windows.Forms.Button();
            this.toolBarNewButton = new System.Windows.Forms.Button();
            this.barCommandsTab = new System.Windows.Forms.TabPage();
            this.commandsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.selectedCommandTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.modifySelectionButton = new System.Windows.Forms.Button();
            this.selectedCommandDescriptionLabel = new System.Windows.Forms.Label();
            this.barCommandCategoryListBoxPanel = new System.Windows.Forms.Panel();
            this.barCommandCategoryListBox = new System.Windows.Forms.ListBox();
            this.barCommandExplanationLabel = new System.Windows.Forms.Label();
            this.selectedCommandCaptionLabel = new System.Windows.Forms.Label();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.barCommandListBox = new ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandListBox();
            this.barCommandsLabel = new System.Windows.Forms.Label();
            this.keyboardTab = new System.Windows.Forms.TabPage();
            this.keyboardTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.shortcutCurrentlyUsedByDropDownList = new System.Windows.Forms.ComboBox();
            this.showCommandsContainingListBoxPanel = new System.Windows.Forms.Panel();
            this.showCommandsContainingListBox = new System.Windows.Forms.ListBox();
            this.shortcutCurrentlyUsedByCaptionLabel = new System.Windows.Forms.Label();
            this.assignShortcutButton = new System.Windows.Forms.Button();
            this.shortcutTextBox = new ActiproSoftware.UI.WinForms.Controls.Bars.BarKeyboardShortcutTextBox();
            this.showCommandsContainingCaptionLabel = new System.Windows.Forms.Label();
            this.showCommandsContainingTextBox = new System.Windows.Forms.TextBox();
            this.useNewShortcutInDropDownList = new System.Windows.Forms.ComboBox();
            this.shortcutsForSelectedCommandCaptionLabel = new System.Windows.Forms.Label();
            this.pressShortcutKeysCaptionLabel = new System.Windows.Forms.Label();
            this.useNewShortcutInCaptionLabel = new System.Windows.Forms.Label();
            this.removeShortcutButton = new System.Windows.Forms.Button();
            this.shortcutsForSelectedCommandDropDownList = new System.Windows.Forms.ComboBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTrayFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabStrip.SuspendLayout();
            this.toolBarsTab.SuspendLayout();
            this.toolBarsTableLayoutPanel.SuspendLayout();
            this.barCommandsTab.SuspendLayout();
            this.commandsTableLayoutPanel.SuspendLayout();
            this.selectedCommandTableLayoutPanel.SuspendLayout();
            this.barCommandCategoryListBoxPanel.SuspendLayout();
            this.keyboardTab.SuspendLayout();
            this.keyboardTableLayoutPanel.SuspendLayout();
            this.showCommandsContainingListBoxPanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.buttonTrayFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(306, 3);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.okButton.Size = new System.Drawing.Size(67, 22);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Close";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabStrip
            // 
            this.tabStrip.Controls.Add(this.toolBarsTab);
            this.tabStrip.Controls.Add(this.barCommandsTab);
            this.tabStrip.Controls.Add(this.keyboardTab);
            this.tabStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStrip.Location = new System.Drawing.Point(8, 8);
            this.tabStrip.Name = "tabStrip";
            this.tabStrip.SelectedIndex = 0;
            this.tabStrip.Size = new System.Drawing.Size(370, 304);
            this.tabStrip.TabIndex = 0;
            this.tabStrip.SelectedIndexChanged += new System.EventHandler(this.tabStrip_SelectedIndexChanged);
            // 
            // toolBarsTab
            // 
            this.toolBarsTab.Controls.Add(this.toolBarsTableLayoutPanel);
            this.toolBarsTab.Location = new System.Drawing.Point(4, 22);
            this.toolBarsTab.Name = "toolBarsTab";
            this.toolBarsTab.Size = new System.Drawing.Size(362, 278);
            this.toolBarsTab.TabIndex = 0;
            this.toolBarsTab.Text = "Toolbars";
            // 
            // toolBarsTableLayoutPanel
            // 
            this.toolBarsTableLayoutPanel.ColumnCount = 2;
            this.toolBarsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolBarsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarListBox, 0, 1);
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarResetButton, 1, 4);
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarsLabel, 0, 0);
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarDeleteButton, 1, 3);
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarRenameButton, 1, 2);
            this.toolBarsTableLayoutPanel.Controls.Add(this.toolBarNewButton, 1, 1);
            this.toolBarsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.toolBarsTableLayoutPanel.Name = "toolBarsTableLayoutPanel";
            this.toolBarsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.toolBarsTableLayoutPanel.RowCount = 6;
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toolBarsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolBarsTableLayoutPanel.Size = new System.Drawing.Size(362, 278);
            this.toolBarsTableLayoutPanel.TabIndex = 4;
            // 
            // toolBarListBox
            // 
            this.toolBarListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarListBox.Location = new System.Drawing.Point(8, 21);
            this.toolBarListBox.Name = "toolBarListBox";
            this.toolBarsTableLayoutPanel.SetRowSpan(this.toolBarListBox, 5);
            this.toolBarListBox.Size = new System.Drawing.Size(250, 249);
            this.toolBarListBox.TabIndex = 1;
            this.toolBarListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.toolBarListBox_ItemCheck);
            this.toolBarListBox.SelectedIndexChanged += new System.EventHandler(this.toolBarListBox_SelectedIndexChanged);
            // 
            // toolBarResetButton
            // 
            this.toolBarResetButton.AutoSize = true;
            this.toolBarResetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolBarResetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarResetButton.Enabled = false;
            this.toolBarResetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolBarResetButton.Location = new System.Drawing.Point(264, 105);
            this.toolBarResetButton.Name = "toolBarResetButton";
            this.toolBarResetButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolBarResetButton.Size = new System.Drawing.Size(90, 22);
            this.toolBarResetButton.TabIndex = 5;
            this.toolBarResetButton.Text = "&Reset";
            this.toolBarResetButton.Click += new System.EventHandler(this.toolBarResetButton_Click);
            // 
            // toolBarsLabel
            // 
            this.toolBarsLabel.AutoSize = true;
            this.toolBarsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarsLabel.Location = new System.Drawing.Point(8, 5);
            this.toolBarsLabel.Name = "toolBarsLabel";
            this.toolBarsLabel.Size = new System.Drawing.Size(250, 13);
            this.toolBarsLabel.TabIndex = 0;
            this.toolBarsLabel.Text = "Toolb&ars:";
            // 
            // toolBarDeleteButton
            // 
            this.toolBarDeleteButton.AutoSize = true;
            this.toolBarDeleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolBarDeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarDeleteButton.Enabled = false;
            this.toolBarDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolBarDeleteButton.Location = new System.Drawing.Point(264, 77);
            this.toolBarDeleteButton.Name = "toolBarDeleteButton";
            this.toolBarDeleteButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolBarDeleteButton.Size = new System.Drawing.Size(90, 22);
            this.toolBarDeleteButton.TabIndex = 4;
            this.toolBarDeleteButton.Text = "&Delete";
            this.toolBarDeleteButton.Click += new System.EventHandler(this.toolBarDeleteButton_Click);
            // 
            // toolBarRenameButton
            // 
            this.toolBarRenameButton.AutoSize = true;
            this.toolBarRenameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolBarRenameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarRenameButton.Enabled = false;
            this.toolBarRenameButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolBarRenameButton.Location = new System.Drawing.Point(264, 49);
            this.toolBarRenameButton.Name = "toolBarRenameButton";
            this.toolBarRenameButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolBarRenameButton.Size = new System.Drawing.Size(90, 22);
            this.toolBarRenameButton.TabIndex = 3;
            this.toolBarRenameButton.Text = "R&ename...";
            this.toolBarRenameButton.Click += new System.EventHandler(this.toolBarRenameButton_Click);
            // 
            // toolBarNewButton
            // 
            this.toolBarNewButton.AutoSize = true;
            this.toolBarNewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolBarNewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBarNewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolBarNewButton.Location = new System.Drawing.Point(264, 21);
            this.toolBarNewButton.Name = "toolBarNewButton";
            this.toolBarNewButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolBarNewButton.Size = new System.Drawing.Size(90, 22);
            this.toolBarNewButton.TabIndex = 2;
            this.toolBarNewButton.Text = "&New...";
            this.toolBarNewButton.Click += new System.EventHandler(this.toolBarNewButton_Click);
            // 
            // barCommandsTab
            // 
            this.barCommandsTab.Controls.Add(this.commandsTableLayoutPanel);
            this.barCommandsTab.Location = new System.Drawing.Point(4, 22);
            this.barCommandsTab.Name = "barCommandsTab";
            this.barCommandsTab.Size = new System.Drawing.Size(362, 278);
            this.barCommandsTab.TabIndex = 1;
            this.barCommandsTab.Text = "Commands";
            // 
            // commandsTableLayoutPanel
            // 
            this.commandsTableLayoutPanel.ColumnCount = 3;
            this.commandsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.commandsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.commandsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.commandsTableLayoutPanel.Controls.Add(this.selectedCommandTableLayoutPanel, 0, 4);
            this.commandsTableLayoutPanel.Controls.Add(this.barCommandCategoryListBoxPanel, 0, 2);
            this.commandsTableLayoutPanel.Controls.Add(this.barCommandExplanationLabel, 0, 0);
            this.commandsTableLayoutPanel.Controls.Add(this.selectedCommandCaptionLabel, 0, 3);
            this.commandsTableLayoutPanel.Controls.Add(this.categoriesLabel, 0, 1);
            this.commandsTableLayoutPanel.Controls.Add(this.barCommandListBox, 2, 2);
            this.commandsTableLayoutPanel.Controls.Add(this.barCommandsLabel, 2, 1);
            this.commandsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.commandsTableLayoutPanel.Name = "commandsTableLayoutPanel";
            this.commandsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.commandsTableLayoutPanel.RowCount = 5;
            this.commandsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.commandsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandsTableLayoutPanel.Size = new System.Drawing.Size(362, 278);
            this.commandsTableLayoutPanel.TabIndex = 4;
            // 
            // selectedCommandTableLayoutPanel
            // 
            this.selectedCommandTableLayoutPanel.AutoSize = true;
            this.selectedCommandTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectedCommandTableLayoutPanel.ColumnCount = 2;
            this.commandsTableLayoutPanel.SetColumnSpan(this.selectedCommandTableLayoutPanel, 3);
            this.selectedCommandTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.selectedCommandTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.selectedCommandTableLayoutPanel.Controls.Add(this.modifySelectionButton, 1, 0);
            this.selectedCommandTableLayoutPanel.Controls.Add(this.selectedCommandDescriptionLabel, 0, 0);
            this.selectedCommandTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedCommandTableLayoutPanel.Location = new System.Drawing.Point(5, 245);
            this.selectedCommandTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.selectedCommandTableLayoutPanel.Name = "selectedCommandTableLayoutPanel";
            this.selectedCommandTableLayoutPanel.RowCount = 1;
            this.selectedCommandTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.selectedCommandTableLayoutPanel.Size = new System.Drawing.Size(352, 28);
            this.selectedCommandTableLayoutPanel.TabIndex = 6;
            // 
            // modifySelectionButton
            // 
            this.modifySelectionButton.AutoSize = true;
            this.modifySelectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.modifySelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modifySelectionButton.Enabled = false;
            this.modifySelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.modifySelectionButton.Location = new System.Drawing.Point(230, 3);
            this.modifySelectionButton.Name = "modifySelectionButton";
            this.modifySelectionButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.modifySelectionButton.Size = new System.Drawing.Size(119, 22);
            this.modifySelectionButton.TabIndex = 1;
            this.modifySelectionButton.Text = "Modify Selection";
            this.modifySelectionButton.Click += new System.EventHandler(this.modifySelectionButton_Click);
            // 
            // selectedCommandDescriptionLabel
            // 
            this.selectedCommandDescriptionLabel.AutoSize = true;
            this.selectedCommandDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedCommandDescriptionLabel.Location = new System.Drawing.Point(3, 0);
            this.selectedCommandDescriptionLabel.Name = "selectedCommandDescriptionLabel";
            this.selectedCommandDescriptionLabel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.selectedCommandDescriptionLabel.Size = new System.Drawing.Size(221, 28);
            this.selectedCommandDescriptionLabel.TabIndex = 0;
            // 
            // barCommandCategoryListBoxPanel
            // 
            this.barCommandCategoryListBoxPanel.Controls.Add(this.barCommandCategoryListBox);
            this.barCommandCategoryListBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCommandCategoryListBoxPanel.Location = new System.Drawing.Point(8, 57);
            this.barCommandCategoryListBoxPanel.Name = "barCommandCategoryListBoxPanel";
            this.barCommandCategoryListBoxPanel.Size = new System.Drawing.Size(165, 162);
            this.barCommandCategoryListBoxPanel.TabIndex = 2;
            // 
            // barCommandCategoryListBox
            // 
            this.barCommandCategoryListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCommandCategoryListBox.Location = new System.Drawing.Point(0, 0);
            this.barCommandCategoryListBox.Name = "barCommandCategoryListBox";
            this.barCommandCategoryListBox.Size = new System.Drawing.Size(165, 162);
            this.barCommandCategoryListBox.TabIndex = 0;
            this.barCommandCategoryListBox.SelectedIndexChanged += new System.EventHandler(this.barCommandCategoryListBox_SelectedIndexChanged);
            // 
            // barCommandExplanationLabel
            // 
            this.barCommandExplanationLabel.AutoSize = true;
            this.commandsTableLayoutPanel.SetColumnSpan(this.barCommandExplanationLabel, 3);
            this.barCommandExplanationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCommandExplanationLabel.Location = new System.Drawing.Point(8, 5);
            this.barCommandExplanationLabel.Name = "barCommandExplanationLabel";
            this.barCommandExplanationLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.barCommandExplanationLabel.Size = new System.Drawing.Size(346, 36);
            this.barCommandExplanationLabel.TabIndex = 0;
            this.barCommandExplanationLabel.Text = "To add a command to a toolbar:  select a category and drag the command out of thi" +
    "s dialog box to a toolbar.";
            // 
            // selectedCommandCaptionLabel
            // 
            this.selectedCommandCaptionLabel.AutoSize = true;
            this.selectedCommandCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedCommandCaptionLabel.Location = new System.Drawing.Point(8, 222);
            this.selectedCommandCaptionLabel.Name = "selectedCommandCaptionLabel";
            this.selectedCommandCaptionLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.selectedCommandCaptionLabel.Size = new System.Drawing.Size(165, 23);
            this.selectedCommandCaptionLabel.TabIndex = 5;
            this.selectedCommandCaptionLabel.Text = "Selected Command:";
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesLabel.Location = new System.Drawing.Point(8, 41);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(165, 13);
            this.categoriesLabel.TabIndex = 1;
            this.categoriesLabel.Text = "Cate&gories:";
            // 
            // barCommandListBox
            // 
            this.barCommandListBox.BarManager = null;
            this.barCommandListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCommandListBox.Location = new System.Drawing.Point(189, 57);
            this.barCommandListBox.Name = "barCommandListBox";
            this.barCommandListBox.Size = new System.Drawing.Size(165, 162);
            this.barCommandListBox.TabIndex = 4;
            // 
            // barCommandsLabel
            // 
            this.barCommandsLabel.AutoSize = true;
            this.barCommandsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCommandsLabel.Location = new System.Drawing.Point(189, 41);
            this.barCommandsLabel.Name = "barCommandsLabel";
            this.barCommandsLabel.Size = new System.Drawing.Size(165, 13);
            this.barCommandsLabel.TabIndex = 3;
            this.barCommandsLabel.Text = "Comman&ds:";
            // 
            // keyboardTab
            // 
            this.keyboardTab.Controls.Add(this.keyboardTableLayoutPanel);
            this.keyboardTab.Location = new System.Drawing.Point(4, 22);
            this.keyboardTab.Name = "keyboardTab";
            this.keyboardTab.Size = new System.Drawing.Size(362, 278);
            this.keyboardTab.TabIndex = 2;
            this.keyboardTab.Text = "Keyboard";
            // 
            // keyboardTableLayoutPanel
            // 
            this.keyboardTableLayoutPanel.ColumnCount = 5;
            this.keyboardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.keyboardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.keyboardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.keyboardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.keyboardTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.keyboardTableLayoutPanel.Controls.Add(this.shortcutCurrentlyUsedByDropDownList, 0, 8);
            this.keyboardTableLayoutPanel.Controls.Add(this.showCommandsContainingListBoxPanel, 0, 2);
            this.keyboardTableLayoutPanel.Controls.Add(this.shortcutCurrentlyUsedByCaptionLabel, 0, 7);
            this.keyboardTableLayoutPanel.Controls.Add(this.assignShortcutButton, 4, 6);
            this.keyboardTableLayoutPanel.Controls.Add(this.shortcutTextBox, 2, 6);
            this.keyboardTableLayoutPanel.Controls.Add(this.showCommandsContainingCaptionLabel, 0, 0);
            this.keyboardTableLayoutPanel.Controls.Add(this.showCommandsContainingTextBox, 0, 1);
            this.keyboardTableLayoutPanel.Controls.Add(this.useNewShortcutInDropDownList, 0, 6);
            this.keyboardTableLayoutPanel.Controls.Add(this.shortcutsForSelectedCommandCaptionLabel, 0, 3);
            this.keyboardTableLayoutPanel.Controls.Add(this.pressShortcutKeysCaptionLabel, 2, 5);
            this.keyboardTableLayoutPanel.Controls.Add(this.useNewShortcutInCaptionLabel, 0, 5);
            this.keyboardTableLayoutPanel.Controls.Add(this.removeShortcutButton, 4, 4);
            this.keyboardTableLayoutPanel.Controls.Add(this.shortcutsForSelectedCommandDropDownList, 0, 4);
            this.keyboardTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.keyboardTableLayoutPanel.Name = "keyboardTableLayoutPanel";
            this.keyboardTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.keyboardTableLayoutPanel.RowCount = 9;
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.keyboardTableLayoutPanel.Size = new System.Drawing.Size(362, 278);
            this.keyboardTableLayoutPanel.TabIndex = 4;
            // 
            // shortcutCurrentlyUsedByDropDownList
            // 
            this.keyboardTableLayoutPanel.SetColumnSpan(this.shortcutCurrentlyUsedByDropDownList, 5);
            this.shortcutCurrentlyUsedByDropDownList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutCurrentlyUsedByDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shortcutCurrentlyUsedByDropDownList.Location = new System.Drawing.Point(8, 249);
            this.shortcutCurrentlyUsedByDropDownList.Name = "shortcutCurrentlyUsedByDropDownList";
            this.shortcutCurrentlyUsedByDropDownList.Size = new System.Drawing.Size(346, 21);
            this.shortcutCurrentlyUsedByDropDownList.TabIndex = 12;
            // 
            // showCommandsContainingListBoxPanel
            // 
            this.keyboardTableLayoutPanel.SetColumnSpan(this.showCommandsContainingListBoxPanel, 5);
            this.showCommandsContainingListBoxPanel.Controls.Add(this.showCommandsContainingListBox);
            this.showCommandsContainingListBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showCommandsContainingListBoxPanel.Location = new System.Drawing.Point(8, 47);
            this.showCommandsContainingListBoxPanel.Name = "showCommandsContainingListBoxPanel";
            this.showCommandsContainingListBoxPanel.Size = new System.Drawing.Size(346, 101);
            this.showCommandsContainingListBoxPanel.TabIndex = 2;
            // 
            // showCommandsContainingListBox
            // 
            this.showCommandsContainingListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showCommandsContainingListBox.Location = new System.Drawing.Point(0, 0);
            this.showCommandsContainingListBox.Name = "showCommandsContainingListBox";
            this.showCommandsContainingListBox.Size = new System.Drawing.Size(346, 101);
            this.showCommandsContainingListBox.Sorted = true;
            this.showCommandsContainingListBox.TabIndex = 0;
            this.showCommandsContainingListBox.SelectedIndexChanged += new System.EventHandler(this.showCommandsContainingListBox_SelectedIndexChanged);
            // 
            // shortcutCurrentlyUsedByCaptionLabel
            // 
            this.shortcutCurrentlyUsedByCaptionLabel.AutoSize = true;
            this.keyboardTableLayoutPanel.SetColumnSpan(this.shortcutCurrentlyUsedByCaptionLabel, 5);
            this.shortcutCurrentlyUsedByCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutCurrentlyUsedByCaptionLabel.Location = new System.Drawing.Point(8, 233);
            this.shortcutCurrentlyUsedByCaptionLabel.Name = "shortcutCurrentlyUsedByCaptionLabel";
            this.shortcutCurrentlyUsedByCaptionLabel.Size = new System.Drawing.Size(346, 13);
            this.shortcutCurrentlyUsedByCaptionLabel.TabIndex = 11;
            this.shortcutCurrentlyUsedByCaptionLabel.Text = "Shortcut currently used by:";
            // 
            // assignShortcutButton
            // 
            this.assignShortcutButton.AutoSize = true;
            this.assignShortcutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.assignShortcutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assignShortcutButton.Enabled = false;
            this.assignShortcutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.assignShortcutButton.Location = new System.Drawing.Point(272, 208);
            this.assignShortcutButton.Name = "assignShortcutButton";
            this.assignShortcutButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.assignShortcutButton.Size = new System.Drawing.Size(82, 22);
            this.assignShortcutButton.TabIndex = 10;
            this.assignShortcutButton.Text = "Assign";
            this.assignShortcutButton.Click += new System.EventHandler(this.assignShortcutButton_Click);
            // 
            // shortcutTextBox
            // 
            this.shortcutTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutTextBox.Location = new System.Drawing.Point(140, 208);
            this.shortcutTextBox.Name = "shortcutTextBox";
            this.shortcutTextBox.Size = new System.Drawing.Size(116, 20);
            this.shortcutTextBox.TabIndex = 9;
            this.shortcutTextBox.TextChanged += new System.EventHandler(this.shortcutTextBox_TextChanged);
            // 
            // showCommandsContainingCaptionLabel
            // 
            this.showCommandsContainingCaptionLabel.AutoSize = true;
            this.keyboardTableLayoutPanel.SetColumnSpan(this.showCommandsContainingCaptionLabel, 5);
            this.showCommandsContainingCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showCommandsContainingCaptionLabel.Location = new System.Drawing.Point(8, 5);
            this.showCommandsContainingCaptionLabel.Name = "showCommandsContainingCaptionLabel";
            this.showCommandsContainingCaptionLabel.Size = new System.Drawing.Size(346, 13);
            this.showCommandsContainingCaptionLabel.TabIndex = 0;
            this.showCommandsContainingCaptionLabel.Text = "Show commands containing:";
            // 
            // showCommandsContainingTextBox
            // 
            this.keyboardTableLayoutPanel.SetColumnSpan(this.showCommandsContainingTextBox, 5);
            this.showCommandsContainingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showCommandsContainingTextBox.Location = new System.Drawing.Point(8, 21);
            this.showCommandsContainingTextBox.Name = "showCommandsContainingTextBox";
            this.showCommandsContainingTextBox.Size = new System.Drawing.Size(346, 20);
            this.showCommandsContainingTextBox.TabIndex = 1;
            this.showCommandsContainingTextBox.TextChanged += new System.EventHandler(this.showCommandsContainingTextBox_TextChanged);
            // 
            // useNewShortcutInDropDownList
            // 
            this.useNewShortcutInDropDownList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useNewShortcutInDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.useNewShortcutInDropDownList.Location = new System.Drawing.Point(8, 208);
            this.useNewShortcutInDropDownList.Name = "useNewShortcutInDropDownList";
            this.useNewShortcutInDropDownList.Size = new System.Drawing.Size(116, 21);
            this.useNewShortcutInDropDownList.TabIndex = 7;
            this.useNewShortcutInDropDownList.DropDown += new System.EventHandler(this.useNewShortcutInDropDownList_DropDown);
            // 
            // shortcutsForSelectedCommandCaptionLabel
            // 
            this.shortcutsForSelectedCommandCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutsForSelectedCommandCaptionLabel.AutoSize = true;
            this.keyboardTableLayoutPanel.SetColumnSpan(this.shortcutsForSelectedCommandCaptionLabel, 3);
            this.shortcutsForSelectedCommandCaptionLabel.Location = new System.Drawing.Point(8, 151);
            this.shortcutsForSelectedCommandCaptionLabel.Name = "shortcutsForSelectedCommandCaptionLabel";
            this.shortcutsForSelectedCommandCaptionLabel.Size = new System.Drawing.Size(248, 13);
            this.shortcutsForSelectedCommandCaptionLabel.TabIndex = 3;
            this.shortcutsForSelectedCommandCaptionLabel.Text = "Shortcut(s) for selected command:";
            // 
            // pressShortcutKeysCaptionLabel
            // 
            this.pressShortcutKeysCaptionLabel.AutoSize = true;
            this.pressShortcutKeysCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pressShortcutKeysCaptionLabel.Location = new System.Drawing.Point(140, 192);
            this.pressShortcutKeysCaptionLabel.Name = "pressShortcutKeysCaptionLabel";
            this.pressShortcutKeysCaptionLabel.Size = new System.Drawing.Size(116, 13);
            this.pressShortcutKeysCaptionLabel.TabIndex = 8;
            this.pressShortcutKeysCaptionLabel.Text = "Press shortcut key(s):";
            // 
            // useNewShortcutInCaptionLabel
            // 
            this.useNewShortcutInCaptionLabel.AutoSize = true;
            this.useNewShortcutInCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useNewShortcutInCaptionLabel.Location = new System.Drawing.Point(8, 192);
            this.useNewShortcutInCaptionLabel.Name = "useNewShortcutInCaptionLabel";
            this.useNewShortcutInCaptionLabel.Size = new System.Drawing.Size(116, 13);
            this.useNewShortcutInCaptionLabel.TabIndex = 6;
            this.useNewShortcutInCaptionLabel.Text = "Use new shortcut in:";
            // 
            // removeShortcutButton
            // 
            this.removeShortcutButton.AutoSize = true;
            this.removeShortcutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeShortcutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeShortcutButton.Enabled = false;
            this.removeShortcutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeShortcutButton.Location = new System.Drawing.Point(272, 167);
            this.removeShortcutButton.Name = "removeShortcutButton";
            this.removeShortcutButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.removeShortcutButton.Size = new System.Drawing.Size(82, 22);
            this.removeShortcutButton.TabIndex = 5;
            this.removeShortcutButton.Text = "Remove";
            this.removeShortcutButton.Click += new System.EventHandler(this.removeShortcutButton_Click);
            // 
            // shortcutsForSelectedCommandDropDownList
            // 
            this.keyboardTableLayoutPanel.SetColumnSpan(this.shortcutsForSelectedCommandDropDownList, 3);
            this.shortcutsForSelectedCommandDropDownList.DisplayMember = "Description";
            this.shortcutsForSelectedCommandDropDownList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutsForSelectedCommandDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shortcutsForSelectedCommandDropDownList.Location = new System.Drawing.Point(8, 167);
            this.shortcutsForSelectedCommandDropDownList.Name = "shortcutsForSelectedCommandDropDownList";
            this.shortcutsForSelectedCommandDropDownList.Size = new System.Drawing.Size(248, 21);
            this.shortcutsForSelectedCommandDropDownList.TabIndex = 4;
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.buttonTrayFlowLayoutPanel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.tabStrip, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(386, 348);
            this.contentTableLayoutPanel.TabIndex = 3;
            // 
            // buttonTrayFlowLayoutPanel
            // 
            this.buttonTrayFlowLayoutPanel.AutoSize = true;
            this.buttonTrayFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTrayFlowLayoutPanel.Controls.Add(this.okButton);
            this.buttonTrayFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTrayFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonTrayFlowLayoutPanel.Location = new System.Drawing.Point(5, 315);
            this.buttonTrayFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTrayFlowLayoutPanel.Name = "buttonTrayFlowLayoutPanel";
            this.buttonTrayFlowLayoutPanel.Size = new System.Drawing.Size(376, 28);
            this.buttonTrayFlowLayoutPanel.TabIndex = 1;
            // 
            // BarCustomizeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(386, 348);
            this.Controls.Add(this.contentTableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarCustomizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize";
            this.tabStrip.ResumeLayout(false);
            this.toolBarsTab.ResumeLayout(false);
            this.toolBarsTableLayoutPanel.ResumeLayout(false);
            this.toolBarsTableLayoutPanel.PerformLayout();
            this.barCommandsTab.ResumeLayout(false);
            this.commandsTableLayoutPanel.ResumeLayout(false);
            this.commandsTableLayoutPanel.PerformLayout();
            this.selectedCommandTableLayoutPanel.ResumeLayout(false);
            this.selectedCommandTableLayoutPanel.PerformLayout();
            this.barCommandCategoryListBoxPanel.ResumeLayout(false);
            this.keyboardTab.ResumeLayout(false);
            this.keyboardTableLayoutPanel.ResumeLayout(false);
            this.keyboardTableLayoutPanel.PerformLayout();
            this.showCommandsContainingListBoxPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.buttonTrayFlowLayoutPanel.ResumeLayout(false);
            this.buttonTrayFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TabControl tabStrip;
		private System.Windows.Forms.TabPage toolBarsTab;
		private System.Windows.Forms.Button toolBarDeleteButton;
		private System.Windows.Forms.Button toolBarNewButton;
		private System.Windows.Forms.CheckedListBox toolBarListBox;
		private System.Windows.Forms.TabPage barCommandsTab;
		private ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandListBox barCommandListBox;
		private System.Windows.Forms.Label toolBarsLabel;
		private System.Windows.Forms.Button toolBarRenameButton;
		private System.Windows.Forms.Button toolBarResetButton;
		private System.Windows.Forms.ListBox barCommandCategoryListBox;
		private System.Windows.Forms.Label barCommandExplanationLabel;
		private System.Windows.Forms.Label categoriesLabel;
		private System.Windows.Forms.Label barCommandsLabel;
		private System.Windows.Forms.Label selectedCommandCaptionLabel;
		private System.Windows.Forms.Label selectedCommandDescriptionLabel;
		private System.Windows.Forms.Button modifySelectionButton;
		private System.Windows.Forms.TabPage keyboardTab;
		private System.Windows.Forms.Label showCommandsContainingCaptionLabel;
		private System.Windows.Forms.TextBox showCommandsContainingTextBox;
		private System.Windows.Forms.ListBox showCommandsContainingListBox;
		private System.Windows.Forms.ComboBox shortcutsForSelectedCommandDropDownList;
		private System.Windows.Forms.Button removeShortcutButton;
		private System.Windows.Forms.ComboBox useNewShortcutInDropDownList;
		private System.Windows.Forms.Button assignShortcutButton;
		private System.Windows.Forms.ComboBox shortcutCurrentlyUsedByDropDownList;
		private ActiproSoftware.UI.WinForms.Controls.Bars.BarKeyboardShortcutTextBox shortcutTextBox;
		private System.Windows.Forms.Label shortcutCurrentlyUsedByCaptionLabel;
		private System.Windows.Forms.Label pressShortcutKeysCaptionLabel;
		private System.Windows.Forms.Label useNewShortcutInCaptionLabel;
		private System.Windows.Forms.Label shortcutsForSelectedCommandCaptionLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel toolBarsTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel buttonTrayFlowLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel commandsTableLayoutPanel;
		private System.Windows.Forms.Panel barCommandCategoryListBoxPanel;
		private System.Windows.Forms.TableLayoutPanel keyboardTableLayoutPanel;
		private System.Windows.Forms.Panel showCommandsContainingListBoxPanel;
		private System.Windows.Forms.TableLayoutPanel selectedCommandTableLayoutPanel;
	}
}
