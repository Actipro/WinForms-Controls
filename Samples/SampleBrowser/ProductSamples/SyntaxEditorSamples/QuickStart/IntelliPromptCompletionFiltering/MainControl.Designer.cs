namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptCompletionFiltering {
	partial class MainControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.contentPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.filterUnmatchedItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.showCompletionListButton = new System.Windows.Forms.Button();
            this.completeWordButton = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.filterTabsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.inheritedFilterButtonVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.memberTypeFilterButtonsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.contentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.editor);
            this.contentPanel.Controls.Add(this.headerPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 89);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 491);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.filterUnmatchedItemsCheckBox);
            this.headerPanel.Controls.Add(this.buttonPanel);
            this.headerPanel.Controls.Add(this.optionsPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 89);
            this.headerPanel.TabIndex = 2;
            // 
            // filterUnmatchedItemsCheckBox
            // 
            this.filterUnmatchedItemsCheckBox.AutoSize = true;
            this.filterUnmatchedItemsCheckBox.Location = new System.Drawing.Point(0, 60);
            this.filterUnmatchedItemsCheckBox.Name = "filterUnmatchedItemsCheckBox";
            this.filterUnmatchedItemsCheckBox.Size = new System.Drawing.Size(238, 19);
            this.filterUnmatchedItemsCheckBox.TabIndex = 3;
            this.filterUnmatchedItemsCheckBox.Text = "Filter unmatched items (auto-shrink list)";
            this.filterUnmatchedItemsCheckBox.UseVisualStyleBackColor = true;
            this.filterUnmatchedItemsCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.showCompletionListButton);
            this.buttonPanel.Controls.Add(this.completeWordButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(290, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(200, 79);
            this.buttonPanel.TabIndex = 5;
            // 
            // showCompletionListButton
            // 
            this.showCompletionListButton.AutoSize = true;
            this.showCompletionListButton.Location = new System.Drawing.Point(0, 31);
            this.showCompletionListButton.Name = "showCompletionListButton";
            this.showCompletionListButton.Size = new System.Drawing.Size(168, 25);
            this.showCompletionListButton.TabIndex = 6;
            this.showCompletionListButton.Text = "Show completion list";
            this.showCompletionListButton.UseVisualStyleBackColor = true;
            this.showCompletionListButton.Click += new System.EventHandler(this.OnShowCompletionListButtonClick);
            // 
            // completeWordButton
            // 
            this.completeWordButton.AutoSize = true;
            this.completeWordButton.Location = new System.Drawing.Point(0, 0);
            this.completeWordButton.Name = "completeWordButton";
            this.completeWordButton.Size = new System.Drawing.Size(168, 25);
            this.completeWordButton.TabIndex = 5;
            this.completeWordButton.Text = "Complete word (Ctrl+Space)";
            this.completeWordButton.UseVisualStyleBackColor = true;
            this.completeWordButton.Click += new System.EventHandler(this.OnCompleteWordButtonClick);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.filterTabsVisibleCheckBox);
            this.optionsPanel.Controls.Add(this.inheritedFilterButtonVisibleCheckBox);
            this.optionsPanel.Controls.Add(this.memberTypeFilterButtonsVisibleCheckBox);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(290, 79);
            this.optionsPanel.TabIndex = 6;
            // 
            // filterTabsVisibleCheckBox
            // 
            this.filterTabsVisibleCheckBox.AutoSize = true;
            this.filterTabsVisibleCheckBox.Checked = true;
            this.filterTabsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterTabsVisibleCheckBox.Location = new System.Drawing.Point(0, 40);
            this.filterTabsVisibleCheckBox.Name = "filterTabsVisibleCheckBox";
            this.filterTabsVisibleCheckBox.Size = new System.Drawing.Size(164, 19);
            this.filterTabsVisibleCheckBox.TabIndex = 2;
            this.filterTabsVisibleCheckBox.Text = "Access-related tabs visible";
            this.filterTabsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.filterTabsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // inheritedFilterButtonVisibleCheckBox
            // 
            this.inheritedFilterButtonVisibleCheckBox.AutoSize = true;
            this.inheritedFilterButtonVisibleCheckBox.Checked = true;
            this.inheritedFilterButtonVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inheritedFilterButtonVisibleCheckBox.Location = new System.Drawing.Point(0, 20);
            this.inheritedFilterButtonVisibleCheckBox.Name = "inheritedFilterButtonVisibleCheckBox";
            this.inheritedFilterButtonVisibleCheckBox.Size = new System.Drawing.Size(178, 19);
            this.inheritedFilterButtonVisibleCheckBox.TabIndex = 1;
            this.inheritedFilterButtonVisibleCheckBox.Text = "Inherited filter button visibile";
            this.inheritedFilterButtonVisibleCheckBox.UseVisualStyleBackColor = true;
            this.inheritedFilterButtonVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // memberTypeFilterButtonsVisibleCheckBox
            // 
            this.memberTypeFilterButtonsVisibleCheckBox.AutoSize = true;
            this.memberTypeFilterButtonsVisibleCheckBox.Checked = true;
            this.memberTypeFilterButtonsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.memberTypeFilterButtonsVisibleCheckBox.Location = new System.Drawing.Point(0, 0);
            this.memberTypeFilterButtonsVisibleCheckBox.Name = "memberTypeFilterButtonsVisibleCheckBox";
            this.memberTypeFilterButtonsVisibleCheckBox.Size = new System.Drawing.Size(204, 19);
            this.memberTypeFilterButtonsVisibleCheckBox.TabIndex = 0;
            this.memberTypeFilterButtonsVisibleCheckBox.Text = "Member type filter buttons visible";
            this.memberTypeFilterButtonsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.memberTypeFilterButtonsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button showCompletionListButton;
		private System.Windows.Forms.Button completeWordButton;
		private System.Windows.Forms.Panel optionsPanel;
		private System.Windows.Forms.CheckBox memberTypeFilterButtonsVisibleCheckBox;
		private System.Windows.Forms.CheckBox filterUnmatchedItemsCheckBox;
		private System.Windows.Forms.CheckBox filterTabsVisibleCheckBox;
		private System.Windows.Forms.CheckBox inheritedFilterButtonVisibleCheckBox;
	}
}
