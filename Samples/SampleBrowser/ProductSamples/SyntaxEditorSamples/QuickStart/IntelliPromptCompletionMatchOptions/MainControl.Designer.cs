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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.useShorthandCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.showCompletionListButton = new System.Windows.Forms.Button();
            this.completeWordButton = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.highlightMatchesCheckBox = new System.Windows.Forms.CheckBox();
            this.useAcronymsCheckBox = new System.Windows.Forms.CheckBox();
            this.requiresExactCheckBox = new System.Windows.Forms.CheckBox();
            this.isCaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Location = new System.Drawing.Point(0, 111);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 469);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.useShorthandCheckBox);
            this.headerPanel.Controls.Add(this.buttonPanel);
            this.headerPanel.Controls.Add(this.optionsPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 111);
            this.headerPanel.TabIndex = 2;
            // 
            // useShorthandCheckBox
            // 
            this.useShorthandCheckBox.AutoSize = true;
            this.useShorthandCheckBox.Checked = true;
            this.useShorthandCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useShorthandCheckBox.Location = new System.Drawing.Point(0, 60);
            this.useShorthandCheckBox.Name = "useShorthandCheckBox";
            this.useShorthandCheckBox.Size = new System.Drawing.Size(343, 19);
            this.useShorthandCheckBox.TabIndex = 3;
            this.useShorthandCheckBox.Text = "Use shorthand matching algorithm (normally off by default)";
            this.useShorthandCheckBox.UseVisualStyleBackColor = true;
            this.useShorthandCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.showCompletionListButton);
            this.buttonPanel.Controls.Add(this.completeWordButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(365, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(200, 101);
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
            this.optionsPanel.Controls.Add(this.highlightMatchesCheckBox);
            this.optionsPanel.Controls.Add(this.useAcronymsCheckBox);
            this.optionsPanel.Controls.Add(this.requiresExactCheckBox);
            this.optionsPanel.Controls.Add(this.isCaseSensitiveCheckBox);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(365, 101);
            this.optionsPanel.TabIndex = 6;
            // 
            // highlightMatchesCheckBox
            // 
            this.highlightMatchesCheckBox.AutoSize = true;
            this.highlightMatchesCheckBox.Checked = true;
            this.highlightMatchesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highlightMatchesCheckBox.Location = new System.Drawing.Point(0, 81);
            this.highlightMatchesCheckBox.Name = "highlightMatchesCheckBox";
            this.highlightMatchesCheckBox.Size = new System.Drawing.Size(149, 19);
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
            this.useAcronymsCheckBox.Location = new System.Drawing.Point(0, 40);
            this.useAcronymsCheckBox.Name = "useAcronymsCheckBox";
            this.useAcronymsCheckBox.Size = new System.Drawing.Size(336, 19);
            this.useAcronymsCheckBox.TabIndex = 2;
            this.useAcronymsCheckBox.Text = "Use acronym matching algorithm (normally off by default)";
            this.useAcronymsCheckBox.UseVisualStyleBackColor = true;
            this.useAcronymsCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // requiresExactCheckBox
            // 
            this.requiresExactCheckBox.AutoSize = true;
            this.requiresExactCheckBox.Location = new System.Drawing.Point(0, 20);
            this.requiresExactCheckBox.Name = "requiresExactCheckBox";
            this.requiresExactCheckBox.Size = new System.Drawing.Size(227, 19);
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
            this.isCaseSensitiveCheckBox.Location = new System.Drawing.Point(0, 0);
            this.isCaseSensitiveCheckBox.Name = "isCaseSensitiveCheckBox";
            this.isCaseSensitiveCheckBox.Size = new System.Drawing.Size(190, 19);
            this.isCaseSensitiveCheckBox.TabIndex = 0;
            this.isCaseSensitiveCheckBox.Text = "Use case sensitive matches first";
            this.isCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.isCaseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
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
		private System.Windows.Forms.CheckBox isCaseSensitiveCheckBox;
		private System.Windows.Forms.CheckBox useShorthandCheckBox;
		private System.Windows.Forms.CheckBox useAcronymsCheckBox;
		private System.Windows.Forms.CheckBox requiresExactCheckBox;
		private System.Windows.Forms.CheckBox highlightMatchesCheckBox;
	}
}
