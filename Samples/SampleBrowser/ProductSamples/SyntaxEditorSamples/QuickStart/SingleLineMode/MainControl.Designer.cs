namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SingleLineMode {
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
            this.cSharpEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.cSharpEditorLabel = new System.Windows.Forms.Label();
            this.formulaEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.formulaEditorLabel = new System.Windows.Forms.Label();
            this.xmlEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.xmlEditorLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cSharpEditor
            // 
            this.cSharpEditor.AcceptsTab = false;
            this.cSharpEditor.AllowDrop = true;
            this.cSharpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSharpEditor.Document.IsReadOnly = true;
            this.cSharpEditor.IsMultiLine = false;
            this.cSharpEditor.IsOutliningMarginVisible = false;
            this.cSharpEditor.IsSelectionMarginVisible = false;
            this.cSharpEditor.Location = new System.Drawing.Point(13, 188);
            this.cSharpEditor.Name = "cSharpEditor";
            this.cSharpEditor.OverrideCursor = null;
            this.cSharpEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.cSharpEditor.Size = new System.Drawing.Size(774, 23);
            this.cSharpEditor.TabIndex = 6;
            this.cSharpEditor.Text = "int i = 50;  // Use ReadOnly mode for copyable code snippets";
            this.cSharpEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // cSharpEditorLabel
            // 
            this.cSharpEditorLabel.AutoSize = true;
            this.cSharpEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSharpEditorLabel.Location = new System.Drawing.Point(13, 159);
            this.cSharpEditorLabel.Name = "cSharpEditorLabel";
            this.cSharpEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.cSharpEditorLabel.Size = new System.Drawing.Size(774, 26);
            this.cSharpEditorLabel.TabIndex = 5;
            this.cSharpEditorLabel.Text = "This is another SyntaxEditor in read-only mode:";
            // 
            // formulaEditor
            // 
            this.formulaEditor.AcceptsTab = false;
            this.formulaEditor.AllowDrop = true;
            this.formulaEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formulaEditor.IsMultiLine = false;
            this.formulaEditor.IsOutliningMarginVisible = false;
            this.formulaEditor.IsSelectionMarginVisible = false;
            this.formulaEditor.Location = new System.Drawing.Point(13, 133);
            this.formulaEditor.Name = "formulaEditor";
            this.formulaEditor.OverrideCursor = null;
            this.formulaEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.formulaEditor.Size = new System.Drawing.Size(774, 23);
            this.formulaEditor.TabIndex = 4;
            this.formulaEditor.Text = "AVERAGE(100, ABS(x2 - (x1 + 1)))";
            this.formulaEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // formulaEditorLabel
            // 
            this.formulaEditorLabel.AutoSize = true;
            this.formulaEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formulaEditorLabel.Location = new System.Drawing.Point(13, 104);
            this.formulaEditorLabel.Name = "formulaEditorLabel";
            this.formulaEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.formulaEditorLabel.Size = new System.Drawing.Size(774, 26);
            this.formulaEditorLabel.TabIndex = 3;
            this.formulaEditorLabel.Text = "This SyntaxEditor is using a dynamic language definition where nested parenthesis" +
    " alternate to a different color and could be used as a formula editor:";
            // 
            // xmlEditor
            // 
            this.xmlEditor.AcceptsTab = false;
            this.xmlEditor.AllowDrop = true;
            this.xmlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlEditor.IsMultiLine = false;
            this.xmlEditor.IsOutliningMarginVisible = false;
            this.xmlEditor.IsSelectionMarginVisible = false;
            this.xmlEditor.Location = new System.Drawing.Point(13, 78);
            this.xmlEditor.Name = "xmlEditor";
            this.xmlEditor.OverrideCursor = null;
            this.xmlEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.xmlEditor.Size = new System.Drawing.Size(774, 23);
            this.xmlEditor.TabIndex = 2;
            this.xmlEditor.Text = "<html><head><title>XHTML Editing</title></head><body>Edit with full automated Int" +
    "elliPrompt!</body></html>";
            // 
            // xmlEditorLabel
            // 
            this.xmlEditorLabel.AutoSize = true;
            this.xmlEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlEditorLabel.Location = new System.Drawing.Point(13, 36);
            this.xmlEditorLabel.Name = "xmlEditorLabel";
            this.xmlEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.xmlEditorLabel.Size = new System.Drawing.Size(774, 39);
            this.xmlEditorLabel.TabIndex = 1;
            this.xmlEditorLabel.Text = resources.GetString("xmlEditorLabel.Text");
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Location = new System.Drawing.Point(13, 10);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(774, 26);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = resources.GetString("headerLabel.Text");
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.cSharpEditor, 0, 6);
            this.contentTableLayoutPanel.Controls.Add(this.headerLabel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.cSharpEditorLabel, 0, 5);
            this.contentTableLayoutPanel.Controls.Add(this.xmlEditorLabel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.formulaEditor, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.xmlEditor, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.formulaEditorLabel, 0, 3);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 8;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
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
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Label xmlEditorLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor xmlEditor;
		private System.Windows.Forms.Label formulaEditorLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor formulaEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor cSharpEditor;
		private System.Windows.Forms.Label cSharpEditorLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
