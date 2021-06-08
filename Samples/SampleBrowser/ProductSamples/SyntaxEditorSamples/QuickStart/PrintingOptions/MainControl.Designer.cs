namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrintingOptions {
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
			this.collapsedNodesCheckBox = new System.Windows.Forms.CheckBox();
			this.documentTitleLabel = new System.Windows.Forms.Label();
			this.documentTitleTextBox = new System.Windows.Forms.TextBox();
			this.showPrintPreviewDialogButton = new System.Windows.Forms.Button();
			this.highlightingCheckBox = new System.Windows.Forms.CheckBox();
			this.whitespaceCheckBox = new System.Windows.Forms.CheckBox();
			this.wordWrapCheckBox = new System.Windows.Forms.CheckBox();
			this.pageNumbersCheckBox = new System.Windows.Forms.CheckBox();
			this.lineNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.documentTitleCheckBox = new System.Windows.Forms.CheckBox();
			this.indentationGuidesCheckBox = new System.Windows.Forms.CheckBox();
			this.squiggleLinesCheckBox = new System.Windows.Forms.CheckBox();
			this.contentPanel.SuspendLayout();
			this.headerPanel.SuspendLayout();
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
			this.editor.AreWordWrapGlyphsVisible = true;
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.Location = new System.Drawing.Point(0, 182);
			this.editor.Name = "editor";
			this.editor.PrintSettings.DocumentTitle = "c:\\mydocument.txt";
			this.editor.PrintSettings.IsLineNumberMarginVisible = true;
			this.editor.PrintSettings.IsWhitespaceVisible = true;
			this.editor.Size = new System.Drawing.Size(780, 398);
			this.editor.TabIndex = 10;
			this.editor.Text = resources.GetString("editor.Text");
			this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.squiggleLinesCheckBox);
			this.headerPanel.Controls.Add(this.indentationGuidesCheckBox);
			this.headerPanel.Controls.Add(this.collapsedNodesCheckBox);
			this.headerPanel.Controls.Add(this.documentTitleLabel);
			this.headerPanel.Controls.Add(this.documentTitleTextBox);
			this.headerPanel.Controls.Add(this.showPrintPreviewDialogButton);
			this.headerPanel.Controls.Add(this.highlightingCheckBox);
			this.headerPanel.Controls.Add(this.whitespaceCheckBox);
			this.headerPanel.Controls.Add(this.wordWrapCheckBox);
			this.headerPanel.Controls.Add(this.pageNumbersCheckBox);
			this.headerPanel.Controls.Add(this.lineNumberCheckBox);
			this.headerPanel.Controls.Add(this.documentTitleCheckBox);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 182);
			this.headerPanel.TabIndex = 3;
			// 
			// collapsedNodesCheckBox
			// 
			this.collapsedNodesCheckBox.AutoSize = true;
			this.collapsedNodesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.collapsedNodesCheckBox.Location = new System.Drawing.Point(0, 114);
			this.collapsedNodesCheckBox.Name = "collapsedNodesCheckBox";
			this.collapsedNodesCheckBox.Size = new System.Drawing.Size(780, 19);
			this.collapsedNodesCheckBox.TabIndex = 10;
			this.collapsedNodesCheckBox.Text = "Are collapsed outlining nodes allowed";
			this.collapsedNodesCheckBox.UseVisualStyleBackColor = true;
			this.collapsedNodesCheckBox.CheckedChanged += new System.EventHandler(this.OnCollapsedNodesCheckBoxCheckedChanged);
			// 
			// documentTitleLabel
			// 
			this.documentTitleLabel.AutoSize = true;
			this.documentTitleLabel.Location = new System.Drawing.Point(385, 0);
			this.documentTitleLabel.Name = "documentTitleLabel";
			this.documentTitleLabel.Size = new System.Drawing.Size(89, 15);
			this.documentTitleLabel.TabIndex = 9;
			this.documentTitleLabel.Text = "Document title:";
			// 
			// documentTitleTextBox
			// 
			this.documentTitleTextBox.Location = new System.Drawing.Point(388, 17);
			this.documentTitleTextBox.Name = "documentTitleTextBox";
			this.documentTitleTextBox.Size = new System.Drawing.Size(273, 23);
			this.documentTitleTextBox.TabIndex = 6;
			this.documentTitleTextBox.TextChanged += new System.EventHandler(this.OnDocumentTitleTextBoxTextChanged);
			// 
			// showPrintPreviewDialogButton
			// 
			this.showPrintPreviewDialogButton.AutoSize = true;
			this.showPrintPreviewDialogButton.Location = new System.Drawing.Point(388, 67);
			this.showPrintPreviewDialogButton.Name = "showPrintPreviewDialogButton";
			this.showPrintPreviewDialogButton.Size = new System.Drawing.Size(155, 25);
			this.showPrintPreviewDialogButton.TabIndex = 7;
			this.showPrintPreviewDialogButton.Text = "Show Print Preview Dialog";
			this.showPrintPreviewDialogButton.UseVisualStyleBackColor = true;
			this.showPrintPreviewDialogButton.Click += new System.EventHandler(this.OnShowPrintPreviewDialogButtonClick);
			// 
			// highlightingCheckBox
			// 
			this.highlightingCheckBox.AutoSize = true;
			this.highlightingCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.highlightingCheckBox.Location = new System.Drawing.Point(0, 95);
			this.highlightingCheckBox.Name = "highlightingCheckBox";
			this.highlightingCheckBox.Size = new System.Drawing.Size(780, 19);
			this.highlightingCheckBox.TabIndex = 5;
			this.highlightingCheckBox.Text = "Use syntax highlighting";
			this.highlightingCheckBox.UseVisualStyleBackColor = true;
			this.highlightingCheckBox.CheckedChanged += new System.EventHandler(this.OnHighlightingCheckBoxCheckedChanged);
			// 
			// whitespaceCheckBox
			// 
			this.whitespaceCheckBox.AutoSize = true;
			this.whitespaceCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.whitespaceCheckBox.Location = new System.Drawing.Point(0, 76);
			this.whitespaceCheckBox.Name = "whitespaceCheckBox";
			this.whitespaceCheckBox.Size = new System.Drawing.Size(780, 19);
			this.whitespaceCheckBox.TabIndex = 4;
			this.whitespaceCheckBox.Text = "Whitespace visible";
			this.whitespaceCheckBox.UseVisualStyleBackColor = true;
			this.whitespaceCheckBox.CheckedChanged += new System.EventHandler(this.OnWhitespaceCheckBoxCheckedChanged);
			// 
			// wordWrapCheckBox
			// 
			this.wordWrapCheckBox.AutoSize = true;
			this.wordWrapCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.wordWrapCheckBox.Location = new System.Drawing.Point(0, 57);
			this.wordWrapCheckBox.Name = "wordWrapCheckBox";
			this.wordWrapCheckBox.Size = new System.Drawing.Size(780, 19);
			this.wordWrapCheckBox.TabIndex = 3;
			this.wordWrapCheckBox.Text = "Word wrap glyph margin visible";
			this.wordWrapCheckBox.UseVisualStyleBackColor = true;
			this.wordWrapCheckBox.CheckedChanged += new System.EventHandler(this.OnWordWrapCheckBoxCheckedChanged);
			// 
			// pageNumbersCheckBox
			// 
			this.pageNumbersCheckBox.AutoSize = true;
			this.pageNumbersCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.pageNumbersCheckBox.Location = new System.Drawing.Point(0, 38);
			this.pageNumbersCheckBox.Name = "pageNumbersCheckBox";
			this.pageNumbersCheckBox.Size = new System.Drawing.Size(780, 19);
			this.pageNumbersCheckBox.TabIndex = 2;
			this.pageNumbersCheckBox.Text = "Page number margin visible";
			this.pageNumbersCheckBox.UseVisualStyleBackColor = true;
			this.pageNumbersCheckBox.CheckedChanged += new System.EventHandler(this.OnPageNumbersCheckBoxCheckedChanged);
			// 
			// lineNumberCheckBox
			// 
			this.lineNumberCheckBox.AutoSize = true;
			this.lineNumberCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.lineNumberCheckBox.Location = new System.Drawing.Point(0, 19);
			this.lineNumberCheckBox.Name = "lineNumberCheckBox";
			this.lineNumberCheckBox.Size = new System.Drawing.Size(780, 19);
			this.lineNumberCheckBox.TabIndex = 1;
			this.lineNumberCheckBox.Text = "Line number margin visible";
			this.lineNumberCheckBox.UseVisualStyleBackColor = true;
			this.lineNumberCheckBox.CheckedChanged += new System.EventHandler(this.OnLineNumberCheckBoxCheckedChanged);
			// 
			// documentTitleCheckBox
			// 
			this.documentTitleCheckBox.AutoSize = true;
			this.documentTitleCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.documentTitleCheckBox.Location = new System.Drawing.Point(0, 0);
			this.documentTitleCheckBox.Name = "documentTitleCheckBox";
			this.documentTitleCheckBox.Size = new System.Drawing.Size(780, 19);
			this.documentTitleCheckBox.TabIndex = 0;
			this.documentTitleCheckBox.Text = "Document title margin visible";
			this.documentTitleCheckBox.UseVisualStyleBackColor = true;
			this.documentTitleCheckBox.CheckedChanged += new System.EventHandler(this.OnDocumentTitleCheckBoxCheckedChanged);
			// 
			// indentationGuidesCheckBox
			// 
			this.indentationGuidesCheckBox.AutoSize = true;
			this.indentationGuidesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.indentationGuidesCheckBox.Location = new System.Drawing.Point(0, 133);
			this.indentationGuidesCheckBox.Name = "indentationGuidesCheckBox";
			this.indentationGuidesCheckBox.Size = new System.Drawing.Size(780, 19);
			this.indentationGuidesCheckBox.TabIndex = 11;
			this.indentationGuidesCheckBox.Text = "Are indentation guides visible";
			this.indentationGuidesCheckBox.UseVisualStyleBackColor = true;
			this.indentationGuidesCheckBox.CheckedChanged += new System.EventHandler(this.OnIndentationGuidesCheckBoxCheckedChanged);
			// 
			// squiggleLinesCheckBox
			// 
			this.squiggleLinesCheckBox.AutoSize = true;
			this.squiggleLinesCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.squiggleLinesCheckBox.Location = new System.Drawing.Point(0, 152);
			this.squiggleLinesCheckBox.Name = "squiggleLinesCheckBox";
			this.squiggleLinesCheckBox.Size = new System.Drawing.Size(780, 19);
			this.squiggleLinesCheckBox.TabIndex = 12;
			this.squiggleLinesCheckBox.Text = "Are squiggle lines visible";
			this.squiggleLinesCheckBox.UseVisualStyleBackColor = true;
			this.squiggleLinesCheckBox.CheckedChanged += new System.EventHandler(this.OnSquiggleLinesCheckBoxCheckedChanged);
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.CheckBox whitespaceCheckBox;
		private System.Windows.Forms.CheckBox wordWrapCheckBox;
		private System.Windows.Forms.CheckBox pageNumbersCheckBox;
		private System.Windows.Forms.CheckBox lineNumberCheckBox;
		private System.Windows.Forms.CheckBox documentTitleCheckBox;
		private System.Windows.Forms.Button showPrintPreviewDialogButton;
		private System.Windows.Forms.CheckBox highlightingCheckBox;
		private System.Windows.Forms.Label documentTitleLabel;
		private System.Windows.Forms.TextBox documentTitleTextBox;
		private System.Windows.Forms.CheckBox collapsedNodesCheckBox;
		private System.Windows.Forms.CheckBox squiggleLinesCheckBox;
		private System.Windows.Forms.CheckBox indentationGuidesCheckBox;
	}
}
