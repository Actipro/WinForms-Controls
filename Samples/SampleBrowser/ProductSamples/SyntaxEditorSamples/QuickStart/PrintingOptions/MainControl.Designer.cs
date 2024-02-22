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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.squiggleLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.indentationGuidesCheckBox = new System.Windows.Forms.CheckBox();
            this.columnGuidesCheckBox = new System.Windows.Forms.CheckBox();
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
			this.editor.AreIndentationGuidesVisible = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 249);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.PrintSettings.DocumentTitle = "c:\\mydocument.txt";
            this.editor.PrintSettings.IsLineNumberMarginVisible = true;
            this.editor.PrintSettings.IsWhitespaceVisible = true;
            this.editor.Size = new System.Drawing.Size(774, 338);
            this.editor.TabIndex = 10;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // squiggleLinesCheckBox
            // 
            this.squiggleLinesCheckBox.AutoSize = true;
            this.squiggleLinesCheckBox.Location = new System.Drawing.Point(3, 210);
            this.squiggleLinesCheckBox.Name = "squiggleLinesCheckBox";
            this.squiggleLinesCheckBox.Size = new System.Drawing.Size(140, 17);
            this.squiggleLinesCheckBox.TabIndex = 13;
            this.squiggleLinesCheckBox.Text = "Are squiggle lines visible";
            this.squiggleLinesCheckBox.UseVisualStyleBackColor = true;
            this.squiggleLinesCheckBox.CheckedChanged += new System.EventHandler(this.OnSquiggleLinesCheckBoxCheckedChanged);
            // 
            // indentationGuidesCheckBox
            // 
            this.indentationGuidesCheckBox.AutoSize = true;
            this.indentationGuidesCheckBox.Location = new System.Drawing.Point(3, 187);
            this.indentationGuidesCheckBox.Name = "indentationGuidesCheckBox";
            this.indentationGuidesCheckBox.Size = new System.Drawing.Size(163, 17);
            this.indentationGuidesCheckBox.TabIndex = 12;
            this.indentationGuidesCheckBox.Text = "Are indentation guides visible";
            this.indentationGuidesCheckBox.UseVisualStyleBackColor = true;
            this.indentationGuidesCheckBox.CheckedChanged += new System.EventHandler(this.OnIndentationGuidesCheckBoxCheckedChanged);
            // 
            // columnGuidesCheckBox
            // 
            this.columnGuidesCheckBox.AutoSize = true;
            this.columnGuidesCheckBox.Location = new System.Drawing.Point(3, 164);
            this.columnGuidesCheckBox.Name = "columnGuidesCheckBox";
            this.columnGuidesCheckBox.Size = new System.Drawing.Size(145, 17);
            this.columnGuidesCheckBox.TabIndex = 11;
            this.columnGuidesCheckBox.Text = "Are column guides visible";
            this.columnGuidesCheckBox.UseVisualStyleBackColor = true;
            this.columnGuidesCheckBox.CheckedChanged += new System.EventHandler(this.OnColumnGuidesCheckBoxCheckedChanged);
            // 
            // collapsedNodesCheckBox
            // 
            this.collapsedNodesCheckBox.AutoSize = true;
            this.collapsedNodesCheckBox.Location = new System.Drawing.Point(3, 141);
            this.collapsedNodesCheckBox.Name = "collapsedNodesCheckBox";
            this.collapsedNodesCheckBox.Size = new System.Drawing.Size(203, 17);
            this.collapsedNodesCheckBox.TabIndex = 10;
            this.collapsedNodesCheckBox.Text = "Are collapsed outlining nodes allowed";
            this.collapsedNodesCheckBox.UseVisualStyleBackColor = true;
            this.collapsedNodesCheckBox.CheckedChanged += new System.EventHandler(this.OnCollapsedNodesCheckBoxCheckedChanged);
            // 
            // documentTitleLabel
            // 
            this.documentTitleLabel.AutoSize = true;
            this.documentTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.documentTitleLabel.Name = "documentTitleLabel";
            this.documentTitleLabel.Size = new System.Drawing.Size(78, 13);
            this.documentTitleLabel.TabIndex = 9;
            this.documentTitleLabel.Text = "Document title:";
            // 
            // documentTitleTextBox
            // 
            this.documentTitleTextBox.Location = new System.Drawing.Point(3, 16);
            this.documentTitleTextBox.Name = "documentTitleTextBox";
            this.documentTitleTextBox.Size = new System.Drawing.Size(273, 20);
            this.documentTitleTextBox.TabIndex = 6;
            this.documentTitleTextBox.TextChanged += new System.EventHandler(this.OnDocumentTitleTextBoxTextChanged);
            // 
            // showPrintPreviewDialogButton
            // 
            this.showPrintPreviewDialogButton.AutoSize = true;
            this.showPrintPreviewDialogButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showPrintPreviewDialogButton.Location = new System.Drawing.Point(3, 62);
            this.showPrintPreviewDialogButton.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.showPrintPreviewDialogButton.Name = "showPrintPreviewDialogButton";
            this.showPrintPreviewDialogButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.showPrintPreviewDialogButton.Size = new System.Drawing.Size(162, 29);
            this.showPrintPreviewDialogButton.TabIndex = 7;
            this.showPrintPreviewDialogButton.Text = "Show Print Preview Dialog";
            this.showPrintPreviewDialogButton.UseVisualStyleBackColor = true;
            this.showPrintPreviewDialogButton.Click += new System.EventHandler(this.OnShowPrintPreviewDialogButtonClick);
            // 
            // highlightingCheckBox
            // 
            this.highlightingCheckBox.AutoSize = true;
            this.highlightingCheckBox.Location = new System.Drawing.Point(3, 118);
            this.highlightingCheckBox.Name = "highlightingCheckBox";
            this.highlightingCheckBox.Size = new System.Drawing.Size(134, 17);
            this.highlightingCheckBox.TabIndex = 5;
            this.highlightingCheckBox.Text = "Use syntax highlighting";
            this.highlightingCheckBox.UseVisualStyleBackColor = true;
            this.highlightingCheckBox.CheckedChanged += new System.EventHandler(this.OnHighlightingCheckBoxCheckedChanged);
            // 
            // whitespaceCheckBox
            // 
            this.whitespaceCheckBox.AutoSize = true;
            this.whitespaceCheckBox.Location = new System.Drawing.Point(3, 95);
            this.whitespaceCheckBox.Name = "whitespaceCheckBox";
            this.whitespaceCheckBox.Size = new System.Drawing.Size(115, 17);
            this.whitespaceCheckBox.TabIndex = 4;
            this.whitespaceCheckBox.Text = "Whitespace visible";
            this.whitespaceCheckBox.UseVisualStyleBackColor = true;
            this.whitespaceCheckBox.CheckedChanged += new System.EventHandler(this.OnWhitespaceCheckBoxCheckedChanged);
            // 
            // wordWrapCheckBox
            // 
            this.wordWrapCheckBox.AutoSize = true;
            this.wordWrapCheckBox.Location = new System.Drawing.Point(3, 72);
            this.wordWrapCheckBox.Name = "wordWrapCheckBox";
            this.wordWrapCheckBox.Size = new System.Drawing.Size(172, 17);
            this.wordWrapCheckBox.TabIndex = 3;
            this.wordWrapCheckBox.Text = "Word wrap glyph margin visible";
            this.wordWrapCheckBox.UseVisualStyleBackColor = true;
            this.wordWrapCheckBox.CheckedChanged += new System.EventHandler(this.OnWordWrapCheckBoxCheckedChanged);
            // 
            // pageNumbersCheckBox
            // 
            this.pageNumbersCheckBox.AutoSize = true;
            this.pageNumbersCheckBox.Location = new System.Drawing.Point(3, 49);
            this.pageNumbersCheckBox.Name = "pageNumbersCheckBox";
            this.pageNumbersCheckBox.Size = new System.Drawing.Size(155, 17);
            this.pageNumbersCheckBox.TabIndex = 2;
            this.pageNumbersCheckBox.Text = "Page number margin visible";
            this.pageNumbersCheckBox.UseVisualStyleBackColor = true;
            this.pageNumbersCheckBox.CheckedChanged += new System.EventHandler(this.OnPageNumbersCheckBoxCheckedChanged);
            // 
            // lineNumberCheckBox
            // 
            this.lineNumberCheckBox.AutoSize = true;
            this.lineNumberCheckBox.Location = new System.Drawing.Point(3, 26);
            this.lineNumberCheckBox.Name = "lineNumberCheckBox";
            this.lineNumberCheckBox.Size = new System.Drawing.Size(150, 17);
            this.lineNumberCheckBox.TabIndex = 1;
            this.lineNumberCheckBox.Text = "Line number margin visible";
            this.lineNumberCheckBox.UseVisualStyleBackColor = true;
            this.lineNumberCheckBox.CheckedChanged += new System.EventHandler(this.OnLineNumberCheckBoxCheckedChanged);
            // 
            // documentTitleCheckBox
            // 
            this.documentTitleCheckBox.AutoSize = true;
            this.documentTitleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.documentTitleCheckBox.Name = "documentTitleCheckBox";
            this.documentTitleCheckBox.Size = new System.Drawing.Size(160, 17);
            this.documentTitleCheckBox.TabIndex = 0;
            this.documentTitleCheckBox.Text = "Document title margin visible";
            this.documentTitleCheckBox.UseVisualStyleBackColor = true;
            this.documentTitleCheckBox.CheckedChanged += new System.EventHandler(this.OnDocumentTitleCheckBoxCheckedChanged);
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
            this.headerLeftFlowLayoutPanel.Controls.Add(this.documentTitleCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.lineNumberCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.pageNumbersCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.wordWrapCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.whitespaceCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.highlightingCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.collapsedNodesCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.columnGuidesCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.indentationGuidesCheckBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.squiggleLinesCheckBox);
            this.headerLeftFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLeftFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerLeftFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerLeftFlowLayoutPanel.Name = "headerLeftFlowLayoutPanel";
            this.headerLeftFlowLayoutPanel.Size = new System.Drawing.Size(209, 230);
            this.headerLeftFlowLayoutPanel.TabIndex = 3;
            this.headerLeftFlowLayoutPanel.WrapContents = false;
            // 
            // headerRightFlowLayoutPanel
            // 
            this.headerRightFlowLayoutPanel.AutoSize = true;
            this.headerRightFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerRightFlowLayoutPanel.Controls.Add(this.documentTitleLabel);
            this.headerRightFlowLayoutPanel.Controls.Add(this.documentTitleTextBox);
            this.headerRightFlowLayoutPanel.Controls.Add(this.showPrintPreviewDialogButton);
            this.headerRightFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerRightFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerRightFlowLayoutPanel.Location = new System.Drawing.Point(228, 13);
            this.headerRightFlowLayoutPanel.Name = "headerRightFlowLayoutPanel";
            this.headerRightFlowLayoutPanel.Size = new System.Drawing.Size(559, 230);
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
		private System.Windows.Forms.CheckBox columnGuidesCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerRightFlowLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerLeftFlowLayoutPanel;
	}
}
