namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WordWrap {
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
            this.areGlyphsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.wordWrapModeComboBox = new System.Windows.Forms.ComboBox();
            this.wordWrapModeLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.wordWrapModeComboBoxPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.indentAmountComboBox = new System.Windows.Forms.ComboBox();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.wordWrapModeComboBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsOutliningMarginVisible = false;
            this.editor.Location = new System.Drawing.Point(13, 51);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(774, 536);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // areGlyphsVisibleCheckBox
            // 
            this.areGlyphsVisibleCheckBox.AutoSize = true;
            this.areGlyphsVisibleCheckBox.Checked = true;
            this.areGlyphsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.areGlyphsVisibleCheckBox.Location = new System.Drawing.Point(273, 3);
            this.areGlyphsVisibleCheckBox.Name = "areGlyphsVisibleCheckBox";
            this.areGlyphsVisibleCheckBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.areGlyphsVisibleCheckBox.Size = new System.Drawing.Size(177, 21);
            this.areGlyphsVisibleCheckBox.TabIndex = 2;
            this.areGlyphsVisibleCheckBox.Text = "Are word wrap glyphs visible";
            this.areGlyphsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.areGlyphsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnAreGlyphsVisibleCheckBoxCheckedChanged);
            // 
            // wordWrapModeComboBox
            // 
            this.wordWrapModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wordWrapModeComboBox.FormattingEnabled = true;
            this.wordWrapModeComboBox.Location = new System.Drawing.Point(0, 0);
            this.wordWrapModeComboBox.Name = "wordWrapModeComboBox";
            this.wordWrapModeComboBox.Size = new System.Drawing.Size(121, 23);
            this.wordWrapModeComboBox.TabIndex = 1;
            this.wordWrapModeComboBox.SelectedValueChanged += new System.EventHandler(this.OnWordWrapModeComboBoxSelectedValueChanged);
            // 
            // wordWrapModeLabel
            // 
            this.wordWrapModeLabel.AutoSize = true;
            this.wordWrapModeLabel.Location = new System.Drawing.Point(3, 0);
            this.wordWrapModeLabel.Name = "wordWrapModeLabel";
            this.wordWrapModeLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.wordWrapModeLabel.Size = new System.Drawing.Size(104, 20);
            this.wordWrapModeLabel.TabIndex = 0;
            this.wordWrapModeLabel.Text = "Word Wrap Mode:";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.headerFlowLayoutPanel, 0, 0);
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
            // headerFlowLayoutPanel
            // 
            this.headerFlowLayoutPanel.AutoSize = true;
            this.headerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerFlowLayoutPanel.Controls.Add(this.wordWrapModeLabel);
            this.headerFlowLayoutPanel.Controls.Add(this.wordWrapModeComboBoxPanel);
            this.headerFlowLayoutPanel.Controls.Add(this.areGlyphsVisibleCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.label1);
            this.headerFlowLayoutPanel.Controls.Add(this.indentAmountComboBox);
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(634, 32);
            this.headerFlowLayoutPanel.TabIndex = 3;
            // 
            // wordWrapModeComboBoxPanel
            // 
            this.wordWrapModeComboBoxPanel.AutoSize = true;
            this.wordWrapModeComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wordWrapModeComboBoxPanel.Controls.Add(this.wordWrapModeComboBox);
            this.wordWrapModeComboBoxPanel.Location = new System.Drawing.Point(113, 3);
            this.wordWrapModeComboBoxPanel.Name = "wordWrapModeComboBoxPanel";
            this.wordWrapModeComboBoxPanel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.wordWrapModeComboBoxPanel.Size = new System.Drawing.Size(154, 26);
            this.wordWrapModeComboBoxPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Indent Amount:";
            // 
            // indentAmountComboBox
            // 
            this.indentAmountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.indentAmountComboBox.FormattingEnabled = true;
            this.indentAmountComboBox.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.indentAmountComboBox.Location = new System.Drawing.Point(580, 3);
            this.indentAmountComboBox.Name = "indentAmountComboBox";
            this.indentAmountComboBox.Size = new System.Drawing.Size(51, 23);
            this.indentAmountComboBox.TabIndex = 2;
            this.indentAmountComboBox.SelectedValueChanged += new System.EventHandler(this.OnIndentAmountComboBoxSelectedValueChanged);
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
            this.headerFlowLayoutPanel.ResumeLayout(false);
            this.headerFlowLayoutPanel.PerformLayout();
            this.wordWrapModeComboBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ComboBox wordWrapModeComboBox;
		private System.Windows.Forms.Label wordWrapModeLabel;
		private System.Windows.Forms.CheckBox areGlyphsVisibleCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
		private System.Windows.Forms.Panel wordWrapModeComboBoxPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox indentAmountComboBox;
	}
}
