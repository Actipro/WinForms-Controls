namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IntelliPromptCompletionMatchOptions {
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
            this.useShorthandCheckBox = new System.Windows.Forms.CheckBox();
            this.showCompletionListButton = new System.Windows.Forms.Button();
            this.completeWordButton = new System.Windows.Forms.Button();
            this.highlightMatchesCheckBox = new System.Windows.Forms.CheckBox();
            this.useAcronymsCheckBox = new System.Windows.Forms.CheckBox();
            this.requiresExactCheckBox = new System.Windows.Forms.CheckBox();
            this.isCaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLeftFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerRightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerLeftFlowLayoutPanel.SuspendLayout();
            this.headerRightFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 134);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 453);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // useShorthandCheckBox
            // 
            this.useShorthandCheckBox.AutoSize = true;
            this.useShorthandCheckBox.Checked = true;
            this.useShorthandCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useShorthandCheckBox.Location = new System.Drawing.Point(3, 72);
            this.useShorthandCheckBox.Name = "useShorthandCheckBox";
            this.useShorthandCheckBox.Size = new System.Drawing.Size(297, 17);
            this.useShorthandCheckBox.TabIndex = 3;
            this.useShorthandCheckBox.Text = "Use shorthand matching algorithm (normally off by default)";
            this.useShorthandCheckBox.UseVisualStyleBackColor = true;
            this.useShorthandCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
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
            // highlightMatchesCheckBox
            // 
            this.highlightMatchesCheckBox.AutoSize = true;
            this.highlightMatchesCheckBox.Checked = true;
            this.highlightMatchesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highlightMatchesCheckBox.Location = new System.Drawing.Point(3, 95);
            this.highlightMatchesCheckBox.Name = "highlightMatchesCheckBox";
            this.highlightMatchesCheckBox.Size = new System.Drawing.Size(131, 17);
            this.highlightMatchesCheckBox.TabIndex = 4;
            this.highlightMatchesCheckBox.Text = "Highlight matched text";
            this.highlightMatchesCheckBox.UseVisualStyleBackColor = true;
            this.highlightMatchesCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // useAcronymsCheckBox
            // 
            this.useAcronymsCheckBox.AutoSize = true;
            this.useAcronymsCheckBox.Checked = true;
            this.useAcronymsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAcronymsCheckBox.Location = new System.Drawing.Point(3, 49);
            this.useAcronymsCheckBox.Name = "useAcronymsCheckBox";
            this.useAcronymsCheckBox.Size = new System.Drawing.Size(290, 17);
            this.useAcronymsCheckBox.TabIndex = 2;
            this.useAcronymsCheckBox.Text = "Use acronym matching algorithm (normally off by default)";
            this.useAcronymsCheckBox.UseVisualStyleBackColor = true;
            this.useAcronymsCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // requiresExactCheckBox
            // 
            this.requiresExactCheckBox.AutoSize = true;
            this.requiresExactCheckBox.Location = new System.Drawing.Point(3, 26);
            this.requiresExactCheckBox.Name = "requiresExactCheckBox";
            this.requiresExactCheckBox.Size = new System.Drawing.Size(205, 17);
            this.requiresExactCheckBox.TabIndex = 1;
            this.requiresExactCheckBox.Text = "Requires exact match for full selection";
            this.requiresExactCheckBox.UseVisualStyleBackColor = true;
            this.requiresExactCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // isCaseSensitiveCheckBox
            // 
            this.isCaseSensitiveCheckBox.AutoSize = true;
            this.isCaseSensitiveCheckBox.Checked = true;
            this.isCaseSensitiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isCaseSensitiveCheckBox.Location = new System.Drawing.Point(3, 3);
            this.isCaseSensitiveCheckBox.Name = "isCaseSensitiveCheckBox";
            this.isCaseSensitiveCheckBox.Size = new System.Drawing.Size(177, 17);
            this.isCaseSensitiveCheckBox.TabIndex = 0;
            this.isCaseSensitiveCheckBox.Text = "Use case sensitive matches first";
            this.isCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.isCaseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
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
            // headerLeftFlowLayoutPanel
            // 
            this.headerLeftFlowLayoutPanel.AutoSize = true;
            this.headerLeftFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerLeftFlowLayoutPanel.Controls.Add(this.isCaseSensitiveCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.requiresExactCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.useAcronymsCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.useShorthandCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.highlightMatchesCheckBox);
            this.headerLeftFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLeftFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerLeftFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerLeftFlowLayoutPanel.Name = "headerLeftFlowLayoutPanel";
            this.headerLeftFlowLayoutPanel.Size = new System.Drawing.Size(303, 115);
            this.headerLeftFlowLayoutPanel.TabIndex = 3;
            // 
            // headerRightFlowLayoutPanel
            // 
            this.headerRightFlowLayoutPanel.AutoSize = true;
            this.headerRightFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerRightFlowLayoutPanel.Controls.Add(this.completeWordButton);
            this.headerRightFlowLayoutPanel.Controls.Add(this.showCompletionListButton);
            this.headerRightFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerRightFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerRightFlowLayoutPanel.Location = new System.Drawing.Point(322, 13);
            this.headerRightFlowLayoutPanel.Name = "headerRightFlowLayoutPanel";
            this.headerRightFlowLayoutPanel.Size = new System.Drawing.Size(465, 115);
            this.headerRightFlowLayoutPanel.TabIndex = 3;
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
            this.headerLeftFlowLayoutPanel.ResumeLayout(false);
            this.headerLeftFlowLayoutPanel.PerformLayout();
            this.headerRightFlowLayoutPanel.ResumeLayout(false);
            this.headerRightFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Button showCompletionListButton;
		private System.Windows.Forms.Button completeWordButton;
		private System.Windows.Forms.CheckBox isCaseSensitiveCheckBox;
		private System.Windows.Forms.CheckBox useShorthandCheckBox;
		private System.Windows.Forms.CheckBox useAcronymsCheckBox;
		private System.Windows.Forms.CheckBox requiresExactCheckBox;
		private System.Windows.Forms.CheckBox highlightMatchesCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerRightFlowLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerLeftFlowLayoutPanel;
	}
}
