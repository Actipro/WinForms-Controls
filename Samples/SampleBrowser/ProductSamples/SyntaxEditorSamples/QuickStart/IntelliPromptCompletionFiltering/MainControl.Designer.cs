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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.filterUnmatchedItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.showCompletionListButton = new System.Windows.Forms.Button();
            this.completeWordButton = new System.Windows.Forms.Button();
            this.filterTabsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.inheritedFilterButtonVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.memberTypeFilterButtonsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerRightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerLeftFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerRightFlowLayoutPanel.SuspendLayout();
            this.headerLeftFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 111);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 476);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // filterUnmatchedItemsCheckBox
            // 
            this.filterUnmatchedItemsCheckBox.AutoSize = true;
            this.filterUnmatchedItemsCheckBox.Location = new System.Drawing.Point(3, 72);
            this.filterUnmatchedItemsCheckBox.Name = "filterUnmatchedItemsCheckBox";
            this.filterUnmatchedItemsCheckBox.Size = new System.Drawing.Size(207, 17);
            this.filterUnmatchedItemsCheckBox.TabIndex = 3;
            this.filterUnmatchedItemsCheckBox.Text = "Filter unmatched items (auto-shrink list)";
            this.filterUnmatchedItemsCheckBox.UseVisualStyleBackColor = true;
            this.filterUnmatchedItemsCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // showCompletionListButton
            // 
            this.showCompletionListButton.AutoSize = true;
            this.showCompletionListButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showCompletionListButton.Location = new System.Drawing.Point(3, 38);
            this.showCompletionListButton.Name = "showCompletionListButton";
            this.showCompletionListButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.showCompletionListButton.Size = new System.Drawing.Size(133, 29);
            this.showCompletionListButton.TabIndex = 6;
            this.showCompletionListButton.Text = "Show completion list";
            this.showCompletionListButton.UseVisualStyleBackColor = true;
            this.showCompletionListButton.Click += new System.EventHandler(this.OnShowCompletionListButtonClick);
            // 
            // completeWordButton
            // 
            this.completeWordButton.AutoSize = true;
            this.completeWordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.completeWordButton.Location = new System.Drawing.Point(3, 3);
            this.completeWordButton.Name = "completeWordButton";
            this.completeWordButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.completeWordButton.Size = new System.Drawing.Size(168, 29);
            this.completeWordButton.TabIndex = 5;
            this.completeWordButton.Text = "Complete word (Ctrl+Space)";
            this.completeWordButton.UseVisualStyleBackColor = true;
            this.completeWordButton.Click += new System.EventHandler(this.OnCompleteWordButtonClick);
            // 
            // filterTabsVisibleCheckBox
            // 
            this.filterTabsVisibleCheckBox.AutoSize = true;
            this.filterTabsVisibleCheckBox.Checked = true;
            this.filterTabsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterTabsVisibleCheckBox.Location = new System.Drawing.Point(3, 49);
            this.filterTabsVisibleCheckBox.Name = "filterTabsVisibleCheckBox";
            this.filterTabsVisibleCheckBox.Size = new System.Drawing.Size(151, 17);
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
            this.inheritedFilterButtonVisibleCheckBox.Location = new System.Drawing.Point(3, 26);
            this.inheritedFilterButtonVisibleCheckBox.Name = "inheritedFilterButtonVisibleCheckBox";
            this.inheritedFilterButtonVisibleCheckBox.Size = new System.Drawing.Size(156, 17);
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
            this.memberTypeFilterButtonsVisibleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.memberTypeFilterButtonsVisibleCheckBox.Name = "memberTypeFilterButtonsVisibleCheckBox";
            this.memberTypeFilterButtonsVisibleCheckBox.Size = new System.Drawing.Size(179, 17);
            this.memberTypeFilterButtonsVisibleCheckBox.TabIndex = 0;
            this.memberTypeFilterButtonsVisibleCheckBox.Text = "Member type filter buttons visible";
            this.memberTypeFilterButtonsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.memberTypeFilterButtonsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.headerRightFlowLayoutPanel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.headerLeftFlowLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // headerRightFlowLayoutPanel
            // 
            this.headerRightFlowLayoutPanel.AutoSize = true;
            this.headerRightFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerRightFlowLayoutPanel.Controls.Add(this.completeWordButton);
            this.headerRightFlowLayoutPanel.Controls.Add(this.showCompletionListButton);
            this.headerRightFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerRightFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerRightFlowLayoutPanel.Location = new System.Drawing.Point(232, 13);
            this.headerRightFlowLayoutPanel.Name = "headerRightFlowLayoutPanel";
            this.headerRightFlowLayoutPanel.Size = new System.Drawing.Size(555, 92);
            this.headerRightFlowLayoutPanel.TabIndex = 3;
            // 
            // headerLeftFlowLayoutPanel
            // 
            this.headerLeftFlowLayoutPanel.AutoSize = true;
            this.headerLeftFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerLeftFlowLayoutPanel.Controls.Add(this.memberTypeFilterButtonsVisibleCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.inheritedFilterButtonVisibleCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.filterTabsVisibleCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.filterUnmatchedItemsCheckBox);
            this.headerLeftFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLeftFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerLeftFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerLeftFlowLayoutPanel.Name = "headerLeftFlowLayoutPanel";
            this.headerLeftFlowLayoutPanel.Size = new System.Drawing.Size(213, 92);
            this.headerLeftFlowLayoutPanel.TabIndex = 3;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.headerRightFlowLayoutPanel.ResumeLayout(false);
            this.headerRightFlowLayoutPanel.PerformLayout();
            this.headerLeftFlowLayoutPanel.ResumeLayout(false);
            this.headerLeftFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Button showCompletionListButton;
		private System.Windows.Forms.Button completeWordButton;
		private System.Windows.Forms.CheckBox memberTypeFilterButtonsVisibleCheckBox;
		private System.Windows.Forms.CheckBox filterUnmatchedItemsCheckBox;
		private System.Windows.Forms.CheckBox filterTabsVisibleCheckBox;
		private System.Windows.Forms.CheckBox inheritedFilterButtonVisibleCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerRightFlowLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerLeftFlowLayoutPanel;
	}
}
