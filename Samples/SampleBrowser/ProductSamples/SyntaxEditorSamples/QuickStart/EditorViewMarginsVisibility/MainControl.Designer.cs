namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsVisibility {
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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.selectionCheckBox = new System.Windows.Forms.CheckBox();
            this.rulerCheckBox = new System.Windows.Forms.CheckBox();
            this.outliningCheckBox = new System.Windows.Forms.CheckBox();
            this.lineNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.indicatorCheckBox = new System.Windows.Forms.CheckBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 134);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 453);
            this.editor.TabIndex = 1;
            this.editor.Text = "SyntaxEditor has several properties that easily set whether the built-in margins " +
    "are visible.\r\n";
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // selectionCheckBox
            // 
            this.selectionCheckBox.AutoSize = true;
            this.selectionCheckBox.Location = new System.Drawing.Point(3, 95);
            this.selectionCheckBox.Name = "selectionCheckBox";
            this.selectionCheckBox.Size = new System.Drawing.Size(136, 17);
            this.selectionCheckBox.TabIndex = 4;
            this.selectionCheckBox.Text = "Selection margin visible";
            this.selectionCheckBox.UseVisualStyleBackColor = true;
            this.selectionCheckBox.CheckedChanged += new System.EventHandler(this.OnSelectionCheckBoxCheckedChanged);
            // 
            // rulerCheckBox
            // 
            this.rulerCheckBox.AutoSize = true;
            this.rulerCheckBox.Location = new System.Drawing.Point(3, 72);
            this.rulerCheckBox.Name = "rulerCheckBox";
            this.rulerCheckBox.Size = new System.Drawing.Size(270, 17);
            this.rulerCheckBox.TabIndex = 3;
            this.rulerCheckBox.Text = "Ruler margin visible (useful for fixed-width fonts only)";
            this.rulerCheckBox.UseVisualStyleBackColor = true;
            this.rulerCheckBox.CheckedChanged += new System.EventHandler(this.OnRulerCheckBoxCheckedChanged);
            // 
            // outliningCheckBox
            // 
            this.outliningCheckBox.AutoSize = true;
            this.outliningCheckBox.Location = new System.Drawing.Point(3, 49);
            this.outliningCheckBox.Name = "outliningCheckBox";
            this.outliningCheckBox.Size = new System.Drawing.Size(133, 17);
            this.outliningCheckBox.TabIndex = 2;
            this.outliningCheckBox.Text = "Outlining margin visible";
            this.outliningCheckBox.UseVisualStyleBackColor = true;
            this.outliningCheckBox.CheckedChanged += new System.EventHandler(this.OnOutliningCheckBoxCheckedChanged);
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
            // indicatorCheckBox
            // 
            this.indicatorCheckBox.AutoSize = true;
            this.indicatorCheckBox.Location = new System.Drawing.Point(3, 3);
            this.indicatorCheckBox.Name = "indicatorCheckBox";
            this.indicatorCheckBox.Size = new System.Drawing.Size(133, 17);
            this.indicatorCheckBox.TabIndex = 0;
            this.indicatorCheckBox.Text = "Indicator margin visible";
            this.indicatorCheckBox.UseVisualStyleBackColor = true;
            this.indicatorCheckBox.CheckedChanged += new System.EventHandler(this.OnIndicatorCheckBoxCheckedChanged);
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
            this.headerFlowLayoutPanel.Controls.Add(this.indicatorCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.lineNumberCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.outliningCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.rulerCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.selectionCheckBox);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 115);
            this.headerFlowLayoutPanel.TabIndex = 3;
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
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.CheckBox selectionCheckBox;
		private System.Windows.Forms.CheckBox rulerCheckBox;
		private System.Windows.Forms.CheckBox outliningCheckBox;
		private System.Windows.Forms.CheckBox lineNumberCheckBox;
		private System.Windows.Forms.CheckBox indicatorCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
