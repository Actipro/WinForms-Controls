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
			this.contentPanel = new System.Windows.Forms.Panel();
			this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.selectionCheckBox = new System.Windows.Forms.CheckBox();
			this.rulerCheckBox = new System.Windows.Forms.CheckBox();
			this.outliningCheckBox = new System.Windows.Forms.CheckBox();
			this.lineNumberCheckBox = new System.Windows.Forms.CheckBox();
			this.indicatorCheckBox = new System.Windows.Forms.CheckBox();
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
			this.editor.Location = new System.Drawing.Point(0, 103);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 477);
			this.editor.TabIndex = 1;
			this.editor.Text = "SyntaxEditor has several properties that easily set whether the built-in margins " +
    "are visible.\r\n";
			this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.selectionCheckBox);
			this.headerPanel.Controls.Add(this.rulerCheckBox);
			this.headerPanel.Controls.Add(this.outliningCheckBox);
			this.headerPanel.Controls.Add(this.lineNumberCheckBox);
			this.headerPanel.Controls.Add(this.indicatorCheckBox);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 103);
			this.headerPanel.TabIndex = 3;
			// 
			// selectionCheckBox
			// 
			this.selectionCheckBox.AutoSize = true;
			this.selectionCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.selectionCheckBox.Location = new System.Drawing.Point(0, 76);
			this.selectionCheckBox.Name = "selectionCheckBox";
			this.selectionCheckBox.Size = new System.Drawing.Size(780, 19);
			this.selectionCheckBox.TabIndex = 4;
			this.selectionCheckBox.Text = "Selection margin visible";
			this.selectionCheckBox.UseVisualStyleBackColor = true;
			this.selectionCheckBox.CheckedChanged += new System.EventHandler(this.OnSelectionCheckBoxCheckedChanged);
			// 
			// rulerCheckBox
			// 
			this.rulerCheckBox.AutoSize = true;
			this.rulerCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.rulerCheckBox.Location = new System.Drawing.Point(0, 57);
			this.rulerCheckBox.Name = "rulerCheckBox";
			this.rulerCheckBox.Size = new System.Drawing.Size(780, 19);
			this.rulerCheckBox.TabIndex = 3;
			this.rulerCheckBox.Text = "Ruler margin visible (useful for fixed-width fonts only)";
			this.rulerCheckBox.UseVisualStyleBackColor = true;
			this.rulerCheckBox.CheckedChanged += new System.EventHandler(this.OnRulerCheckBoxCheckedChanged);
			// 
			// outliningCheckBox
			// 
			this.outliningCheckBox.AutoSize = true;
			this.outliningCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.outliningCheckBox.Location = new System.Drawing.Point(0, 38);
			this.outliningCheckBox.Name = "outliningCheckBox";
			this.outliningCheckBox.Size = new System.Drawing.Size(780, 19);
			this.outliningCheckBox.TabIndex = 2;
			this.outliningCheckBox.Text = "Outlining margin visible";
			this.outliningCheckBox.UseVisualStyleBackColor = true;
			this.outliningCheckBox.CheckedChanged += new System.EventHandler(this.OnOutliningCheckBoxCheckedChanged);
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
			// indicatorCheckBox
			// 
			this.indicatorCheckBox.AutoSize = true;
			this.indicatorCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.indicatorCheckBox.Location = new System.Drawing.Point(0, 0);
			this.indicatorCheckBox.Name = "indicatorCheckBox";
			this.indicatorCheckBox.Size = new System.Drawing.Size(780, 19);
			this.indicatorCheckBox.TabIndex = 0;
			this.indicatorCheckBox.Text = "Indicator margin visible";
			this.indicatorCheckBox.UseVisualStyleBackColor = true;
			this.indicatorCheckBox.CheckedChanged += new System.EventHandler(this.OnIndicatorCheckBoxCheckedChanged);
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
		private System.Windows.Forms.CheckBox selectionCheckBox;
		private System.Windows.Forms.CheckBox rulerCheckBox;
		private System.Windows.Forms.CheckBox outliningCheckBox;
		private System.Windows.Forms.CheckBox lineNumberCheckBox;
		private System.Windows.Forms.CheckBox indicatorCheckBox;
	}
}
