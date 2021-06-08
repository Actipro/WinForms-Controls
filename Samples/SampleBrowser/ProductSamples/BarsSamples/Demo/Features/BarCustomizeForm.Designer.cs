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
			this.toolBarResetButton = new System.Windows.Forms.Button();
			this.toolBarRenameButton = new System.Windows.Forms.Button();
			this.toolBarDeleteButton = new System.Windows.Forms.Button();
			this.toolBarNewButton = new System.Windows.Forms.Button();
			this.toolBarListBox = new System.Windows.Forms.CheckedListBox();
			this.toolBarsLabel = new System.Windows.Forms.Label();
			this.barCommandsTab = new System.Windows.Forms.TabPage();
			this.modifySelectionButton = new System.Windows.Forms.Button();
			this.selectedCommandDescriptionLabel = new System.Windows.Forms.Label();
			this.selectedCommandCaptionLabel = new System.Windows.Forms.Label();
			this.barCommandExplanationLabel = new System.Windows.Forms.Label();
			this.barCommandCategoryListBox = new System.Windows.Forms.ListBox();
			this.barCommandListBox = new ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandListBox();
			this.categoriesLabel = new System.Windows.Forms.Label();
			this.barCommandsLabel = new System.Windows.Forms.Label();
			this.keyboardTab = new System.Windows.Forms.TabPage();
			this.shortcutCurrentlyUsedByDropDownList = new System.Windows.Forms.ComboBox();
			this.shortcutTextBox = new ActiproSoftware.UI.WinForms.Controls.Bars.BarKeyboardShortcutTextBox();
			this.assignShortcutButton = new System.Windows.Forms.Button();
			this.useNewShortcutInDropDownList = new System.Windows.Forms.ComboBox();
			this.removeShortcutButton = new System.Windows.Forms.Button();
			this.shortcutsForSelectedCommandDropDownList = new System.Windows.Forms.ComboBox();
			this.showCommandsContainingListBox = new System.Windows.Forms.ListBox();
			this.showCommandsContainingTextBox = new System.Windows.Forms.TextBox();
			this.showCommandsContainingCaptionLabel = new System.Windows.Forms.Label();
			this.shortcutsForSelectedCommandCaptionLabel = new System.Windows.Forms.Label();
			this.useNewShortcutInCaptionLabel = new System.Windows.Forms.Label();
			this.pressShortcutKeysCaptionLabel = new System.Windows.Forms.Label();
			this.shortcutCurrentlyUsedByCaptionLabel = new System.Windows.Forms.Label();
			this.tabStrip.SuspendLayout();
			this.toolBarsTab.SuspendLayout();
			this.barCommandsTab.SuspendLayout();
			this.keyboardTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(304, 319);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "Close";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// tabStrip
			// 
			this.tabStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabStrip.Controls.Add(this.toolBarsTab);
			this.tabStrip.Controls.Add(this.barCommandsTab);
			this.tabStrip.Controls.Add(this.keyboardTab);
			this.tabStrip.Location = new System.Drawing.Point(7, 7);
			this.tabStrip.Name = "tabStrip";
			this.tabStrip.SelectedIndex = 0;
			this.tabStrip.Size = new System.Drawing.Size(372, 305);
			this.tabStrip.TabIndex = 2;
			this.tabStrip.SelectedIndexChanged += new System.EventHandler(this.tabStrip_SelectedIndexChanged);
			// 
			// toolBarsTab
			// 
			this.toolBarsTab.Controls.Add(this.toolBarResetButton);
			this.toolBarsTab.Controls.Add(this.toolBarRenameButton);
			this.toolBarsTab.Controls.Add(this.toolBarDeleteButton);
			this.toolBarsTab.Controls.Add(this.toolBarNewButton);
			this.toolBarsTab.Controls.Add(this.toolBarListBox);
			this.toolBarsTab.Controls.Add(this.toolBarsLabel);
			this.toolBarsTab.Location = new System.Drawing.Point(4, 24);
			this.toolBarsTab.Name = "toolBarsTab";
			this.toolBarsTab.Size = new System.Drawing.Size(364, 277);
			this.toolBarsTab.TabIndex = 0;
			this.toolBarsTab.Text = "Toolbars";
			// 
			// toolBarResetButton
			// 
			this.toolBarResetButton.Enabled = false;
			this.toolBarResetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.toolBarResetButton.Location = new System.Drawing.Point(280, 120);
			this.toolBarResetButton.Name = "toolBarResetButton";
			this.toolBarResetButton.Size = new System.Drawing.Size(75, 23);
			this.toolBarResetButton.TabIndex = 5;
			this.toolBarResetButton.Text = "&Reset";
			this.toolBarResetButton.Click += new System.EventHandler(this.toolBarResetButton_Click);
			// 
			// toolBarRenameButton
			// 
			this.toolBarRenameButton.Enabled = false;
			this.toolBarRenameButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.toolBarRenameButton.Location = new System.Drawing.Point(280, 56);
			this.toolBarRenameButton.Name = "toolBarRenameButton";
			this.toolBarRenameButton.Size = new System.Drawing.Size(75, 23);
			this.toolBarRenameButton.TabIndex = 3;
			this.toolBarRenameButton.Text = "R&ename...";
			this.toolBarRenameButton.Click += new System.EventHandler(this.toolBarRenameButton_Click);
			// 
			// toolBarDeleteButton
			// 
			this.toolBarDeleteButton.Enabled = false;
			this.toolBarDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.toolBarDeleteButton.Location = new System.Drawing.Point(280, 88);
			this.toolBarDeleteButton.Name = "toolBarDeleteButton";
			this.toolBarDeleteButton.Size = new System.Drawing.Size(75, 23);
			this.toolBarDeleteButton.TabIndex = 4;
			this.toolBarDeleteButton.Text = "&Delete";
			this.toolBarDeleteButton.Click += new System.EventHandler(this.toolBarDeleteButton_Click);
			// 
			// toolBarNewButton
			// 
			this.toolBarNewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.toolBarNewButton.Location = new System.Drawing.Point(280, 24);
			this.toolBarNewButton.Name = "toolBarNewButton";
			this.toolBarNewButton.Size = new System.Drawing.Size(75, 23);
			this.toolBarNewButton.TabIndex = 2;
			this.toolBarNewButton.Text = "&New...";
			this.toolBarNewButton.Click += new System.EventHandler(this.toolBarNewButton_Click);
			// 
			// toolBarListBox
			// 
			this.toolBarListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolBarListBox.Location = new System.Drawing.Point(8, 24);
			this.toolBarListBox.Name = "toolBarListBox";
			this.toolBarListBox.Size = new System.Drawing.Size(266, 184);
			this.toolBarListBox.TabIndex = 1;
			this.toolBarListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.toolBarListBox_ItemCheck);
			this.toolBarListBox.SelectedIndexChanged += new System.EventHandler(this.toolBarListBox_SelectedIndexChanged);
			// 
			// toolBarsLabel
			// 
			this.toolBarsLabel.AutoSize = true;
			this.toolBarsLabel.Location = new System.Drawing.Point(8, 8);
			this.toolBarsLabel.Name = "toolBarsLabel";
			this.toolBarsLabel.Size = new System.Drawing.Size(54, 15);
			this.toolBarsLabel.TabIndex = 0;
			this.toolBarsLabel.Text = "Toolb&ars:";
			// 
			// barCommandsTab
			// 
			this.barCommandsTab.Controls.Add(this.modifySelectionButton);
			this.barCommandsTab.Controls.Add(this.selectedCommandDescriptionLabel);
			this.barCommandsTab.Controls.Add(this.selectedCommandCaptionLabel);
			this.barCommandsTab.Controls.Add(this.barCommandExplanationLabel);
			this.barCommandsTab.Controls.Add(this.barCommandCategoryListBox);
			this.barCommandsTab.Controls.Add(this.barCommandListBox);
			this.barCommandsTab.Controls.Add(this.categoriesLabel);
			this.barCommandsTab.Controls.Add(this.barCommandsLabel);
			this.barCommandsTab.Location = new System.Drawing.Point(4, 24);
			this.barCommandsTab.Name = "barCommandsTab";
			this.barCommandsTab.Size = new System.Drawing.Size(364, 277);
			this.barCommandsTab.TabIndex = 1;
			this.barCommandsTab.Text = "Commands";
			// 
			// modifySelectionButton
			// 
			this.modifySelectionButton.Enabled = false;
			this.modifySelectionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.modifySelectionButton.Location = new System.Drawing.Point(239, 224);
			this.modifySelectionButton.Name = "modifySelectionButton";
			this.modifySelectionButton.Size = new System.Drawing.Size(116, 23);
			this.modifySelectionButton.TabIndex = 5;
			this.modifySelectionButton.Text = "Modify Selection";
			this.modifySelectionButton.Click += new System.EventHandler(this.modifySelectionButton_Click);
			// 
			// selectedCommandDescriptionLabel
			// 
			this.selectedCommandDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.selectedCommandDescriptionLabel.Location = new System.Drawing.Point(8, 228);
			this.selectedCommandDescriptionLabel.Name = "selectedCommandDescriptionLabel";
			this.selectedCommandDescriptionLabel.Size = new System.Drawing.Size(224, 38);
			this.selectedCommandDescriptionLabel.TabIndex = 7;
			// 
			// selectedCommandCaptionLabel
			// 
			this.selectedCommandCaptionLabel.AutoSize = true;
			this.selectedCommandCaptionLabel.Location = new System.Drawing.Point(8, 212);
			this.selectedCommandCaptionLabel.Name = "selectedCommandCaptionLabel";
			this.selectedCommandCaptionLabel.Size = new System.Drawing.Size(114, 15);
			this.selectedCommandCaptionLabel.TabIndex = 5;
			this.selectedCommandCaptionLabel.Text = "Selected Command:";
			// 
			// barCommandExplanationLabel
			// 
			this.barCommandExplanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.barCommandExplanationLabel.Location = new System.Drawing.Point(8, 8);
			this.barCommandExplanationLabel.Name = "barCommandExplanationLabel";
			this.barCommandExplanationLabel.Size = new System.Drawing.Size(348, 32);
			this.barCommandExplanationLabel.TabIndex = 0;
			this.barCommandExplanationLabel.Text = "To add a command to a toolbar:  select a category and drag the command out of thi" +
    "s dialog box to a toolbar.";
			// 
			// barCommandCategoryListBox
			// 
			this.barCommandCategoryListBox.ItemHeight = 15;
			this.barCommandCategoryListBox.Location = new System.Drawing.Point(10, 60);
			this.barCommandCategoryListBox.Name = "barCommandCategoryListBox";
			this.barCommandCategoryListBox.Size = new System.Drawing.Size(132, 139);
			this.barCommandCategoryListBox.TabIndex = 2;
			this.barCommandCategoryListBox.SelectedIndexChanged += new System.EventHandler(this.barCommandCategoryListBox_SelectedIndexChanged);
			// 
			// barCommandListBox
			// 
			this.barCommandListBox.BarManager = null;
			this.barCommandListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.barCommandListBox.ItemHeight = 22;
			this.barCommandListBox.Location = new System.Drawing.Point(156, 60);
			this.barCommandListBox.Name = "barCommandListBox";
			this.barCommandListBox.Size = new System.Drawing.Size(200, 136);
			this.barCommandListBox.TabIndex = 4;
			// 
			// categoriesLabel
			// 
			this.categoriesLabel.AutoSize = true;
			this.categoriesLabel.Location = new System.Drawing.Point(8, 44);
			this.categoriesLabel.Name = "categoriesLabel";
			this.categoriesLabel.Size = new System.Drawing.Size(66, 15);
			this.categoriesLabel.TabIndex = 1;
			this.categoriesLabel.Text = "Cate&gories:";
			// 
			// barCommandsLabel
			// 
			this.barCommandsLabel.AutoSize = true;
			this.barCommandsLabel.Location = new System.Drawing.Point(153, 44);
			this.barCommandsLabel.Name = "barCommandsLabel";
			this.barCommandsLabel.Size = new System.Drawing.Size(72, 15);
			this.barCommandsLabel.TabIndex = 3;
			this.barCommandsLabel.Text = "Comman&ds:";
			// 
			// keyboardTab
			// 
			this.keyboardTab.Controls.Add(this.shortcutCurrentlyUsedByDropDownList);
			this.keyboardTab.Controls.Add(this.shortcutTextBox);
			this.keyboardTab.Controls.Add(this.assignShortcutButton);
			this.keyboardTab.Controls.Add(this.useNewShortcutInDropDownList);
			this.keyboardTab.Controls.Add(this.removeShortcutButton);
			this.keyboardTab.Controls.Add(this.shortcutsForSelectedCommandDropDownList);
			this.keyboardTab.Controls.Add(this.showCommandsContainingListBox);
			this.keyboardTab.Controls.Add(this.showCommandsContainingTextBox);
			this.keyboardTab.Controls.Add(this.showCommandsContainingCaptionLabel);
			this.keyboardTab.Controls.Add(this.shortcutsForSelectedCommandCaptionLabel);
			this.keyboardTab.Controls.Add(this.useNewShortcutInCaptionLabel);
			this.keyboardTab.Controls.Add(this.pressShortcutKeysCaptionLabel);
			this.keyboardTab.Controls.Add(this.shortcutCurrentlyUsedByCaptionLabel);
			this.keyboardTab.Location = new System.Drawing.Point(4, 24);
			this.keyboardTab.Name = "keyboardTab";
			this.keyboardTab.Size = new System.Drawing.Size(364, 277);
			this.keyboardTab.TabIndex = 2;
			this.keyboardTab.Text = "Keyboard";
			// 
			// shortcutCurrentlyUsedByDropDownList
			// 
			this.shortcutCurrentlyUsedByDropDownList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shortcutCurrentlyUsedByDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shortcutCurrentlyUsedByDropDownList.Location = new System.Drawing.Point(12, 244);
			this.shortcutCurrentlyUsedByDropDownList.Name = "shortcutCurrentlyUsedByDropDownList";
			this.shortcutCurrentlyUsedByDropDownList.Size = new System.Drawing.Size(340, 23);
			this.shortcutCurrentlyUsedByDropDownList.TabIndex = 7;
			// 
			// shortcutTextBox
			// 
			this.shortcutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shortcutTextBox.Location = new System.Drawing.Point(136, 196);
			this.shortcutTextBox.Name = "shortcutTextBox";
			this.shortcutTextBox.Size = new System.Drawing.Size(136, 23);
			this.shortcutTextBox.TabIndex = 5;
			this.shortcutTextBox.TextChanged += new System.EventHandler(this.shortcutTextBox_TextChanged);
			// 
			// assignShortcutButton
			// 
			this.assignShortcutButton.Enabled = false;
			this.assignShortcutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.assignShortcutButton.Location = new System.Drawing.Point(276, 194);
			this.assignShortcutButton.Name = "assignShortcutButton";
			this.assignShortcutButton.Size = new System.Drawing.Size(75, 23);
			this.assignShortcutButton.TabIndex = 6;
			this.assignShortcutButton.Text = "Assign";
			this.assignShortcutButton.Click += new System.EventHandler(this.assignShortcutButton_Click);
			// 
			// useNewShortcutInDropDownList
			// 
			this.useNewShortcutInDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.useNewShortcutInDropDownList.Location = new System.Drawing.Point(12, 196);
			this.useNewShortcutInDropDownList.Name = "useNewShortcutInDropDownList";
			this.useNewShortcutInDropDownList.Size = new System.Drawing.Size(108, 23);
			this.useNewShortcutInDropDownList.TabIndex = 4;
			this.useNewShortcutInDropDownList.DropDown += new System.EventHandler(this.useNewShortcutInDropDownList_DropDown);
			// 
			// removeShortcutButton
			// 
			this.removeShortcutButton.Enabled = false;
			this.removeShortcutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.removeShortcutButton.Location = new System.Drawing.Point(276, 146);
			this.removeShortcutButton.Name = "removeShortcutButton";
			this.removeShortcutButton.Size = new System.Drawing.Size(75, 23);
			this.removeShortcutButton.TabIndex = 3;
			this.removeShortcutButton.Text = "Remove";
			this.removeShortcutButton.Click += new System.EventHandler(this.removeShortcutButton_Click);
			// 
			// shortcutsForSelectedCommandDropDownList
			// 
			this.shortcutsForSelectedCommandDropDownList.DisplayMember = "Description";
			this.shortcutsForSelectedCommandDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shortcutsForSelectedCommandDropDownList.Location = new System.Drawing.Point(12, 148);
			this.shortcutsForSelectedCommandDropDownList.Name = "shortcutsForSelectedCommandDropDownList";
			this.shortcutsForSelectedCommandDropDownList.Size = new System.Drawing.Size(260, 23);
			this.shortcutsForSelectedCommandDropDownList.TabIndex = 2;
			// 
			// showCommandsContainingListBox
			// 
			this.showCommandsContainingListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showCommandsContainingListBox.ItemHeight = 15;
			this.showCommandsContainingListBox.Location = new System.Drawing.Point(12, 48);
			this.showCommandsContainingListBox.Name = "showCommandsContainingListBox";
			this.showCommandsContainingListBox.Size = new System.Drawing.Size(340, 64);
			this.showCommandsContainingListBox.Sorted = true;
			this.showCommandsContainingListBox.TabIndex = 1;
			this.showCommandsContainingListBox.SelectedIndexChanged += new System.EventHandler(this.showCommandsContainingListBox_SelectedIndexChanged);
			// 
			// showCommandsContainingTextBox
			// 
			this.showCommandsContainingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showCommandsContainingTextBox.Location = new System.Drawing.Point(12, 24);
			this.showCommandsContainingTextBox.Name = "showCommandsContainingTextBox";
			this.showCommandsContainingTextBox.Size = new System.Drawing.Size(340, 23);
			this.showCommandsContainingTextBox.TabIndex = 0;
			this.showCommandsContainingTextBox.TextChanged += new System.EventHandler(this.showCommandsContainingTextBox_TextChanged);
			// 
			// showCommandsContainingCaptionLabel
			// 
			this.showCommandsContainingCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showCommandsContainingCaptionLabel.AutoSize = true;
			this.showCommandsContainingCaptionLabel.Location = new System.Drawing.Point(8, 8);
			this.showCommandsContainingCaptionLabel.Name = "showCommandsContainingCaptionLabel";
			this.showCommandsContainingCaptionLabel.Size = new System.Drawing.Size(162, 15);
			this.showCommandsContainingCaptionLabel.TabIndex = 1;
			this.showCommandsContainingCaptionLabel.Text = "Show commands containing:";
			// 
			// shortcutsForSelectedCommandCaptionLabel
			// 
			this.shortcutsForSelectedCommandCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shortcutsForSelectedCommandCaptionLabel.AutoSize = true;
			this.shortcutsForSelectedCommandCaptionLabel.Location = new System.Drawing.Point(12, 132);
			this.shortcutsForSelectedCommandCaptionLabel.Name = "shortcutsForSelectedCommandCaptionLabel";
			this.shortcutsForSelectedCommandCaptionLabel.Size = new System.Drawing.Size(190, 15);
			this.shortcutsForSelectedCommandCaptionLabel.TabIndex = 4;
			this.shortcutsForSelectedCommandCaptionLabel.Text = "Shortcut(s) for selected command:";
			// 
			// useNewShortcutInCaptionLabel
			// 
			this.useNewShortcutInCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.useNewShortcutInCaptionLabel.AutoSize = true;
			this.useNewShortcutInCaptionLabel.Location = new System.Drawing.Point(12, 180);
			this.useNewShortcutInCaptionLabel.Name = "useNewShortcutInCaptionLabel";
			this.useNewShortcutInCaptionLabel.Size = new System.Drawing.Size(114, 15);
			this.useNewShortcutInCaptionLabel.TabIndex = 7;
			this.useNewShortcutInCaptionLabel.Text = "Use new shortcut in:";
			// 
			// pressShortcutKeysCaptionLabel
			// 
			this.pressShortcutKeysCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pressShortcutKeysCaptionLabel.AutoSize = true;
			this.pressShortcutKeysCaptionLabel.Location = new System.Drawing.Point(136, 180);
			this.pressShortcutKeysCaptionLabel.Name = "pressShortcutKeysCaptionLabel";
			this.pressShortcutKeysCaptionLabel.Size = new System.Drawing.Size(118, 15);
			this.pressShortcutKeysCaptionLabel.TabIndex = 9;
			this.pressShortcutKeysCaptionLabel.Text = "Press shortcut key(s):";
			// 
			// shortcutCurrentlyUsedByCaptionLabel
			// 
			this.shortcutCurrentlyUsedByCaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shortcutCurrentlyUsedByCaptionLabel.AutoSize = true;
			this.shortcutCurrentlyUsedByCaptionLabel.Location = new System.Drawing.Point(12, 228);
			this.shortcutCurrentlyUsedByCaptionLabel.Name = "shortcutCurrentlyUsedByCaptionLabel";
			this.shortcutCurrentlyUsedByCaptionLabel.Size = new System.Drawing.Size(149, 15);
			this.shortcutCurrentlyUsedByCaptionLabel.TabIndex = 12;
			this.shortcutCurrentlyUsedByCaptionLabel.Text = "Shortcut currently used by:";
			// 
			// BarCustomizeForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(386, 348);
			this.Controls.Add(this.tabStrip);
			this.Controls.Add(this.okButton);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BarCustomizeForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Customize";
			this.tabStrip.ResumeLayout(false);
			this.toolBarsTab.ResumeLayout(false);
			this.toolBarsTab.PerformLayout();
			this.barCommandsTab.ResumeLayout(false);
			this.barCommandsTab.PerformLayout();
			this.keyboardTab.ResumeLayout(false);
			this.keyboardTab.PerformLayout();
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
	}
}
