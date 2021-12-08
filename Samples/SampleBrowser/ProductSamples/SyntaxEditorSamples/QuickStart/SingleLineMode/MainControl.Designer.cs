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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.formulaEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.formulaEditorLabel = new System.Windows.Forms.Label();
            this.xmlEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.xmlEditorLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.cSharpEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.cSharpEditorLabel = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.cSharpEditor);
            this.contentPanel.Controls.Add(this.cSharpEditorLabel);
            this.contentPanel.Controls.Add(this.formulaEditor);
            this.contentPanel.Controls.Add(this.formulaEditorLabel);
            this.contentPanel.Controls.Add(this.xmlEditor);
            this.contentPanel.Controls.Add(this.xmlEditorLabel);
            this.contentPanel.Controls.Add(this.headerLabel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // formulaEditor
            // 
            this.formulaEditor.AcceptsTab = false;
            this.formulaEditor.AllowDrop = true;
            this.formulaEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaEditor.IsMultiLine = false;
            this.formulaEditor.IsOutliningMarginVisible = false;
            this.formulaEditor.IsSelectionMarginVisible = false;
            this.formulaEditor.Location = new System.Drawing.Point(0, 94);
            this.formulaEditor.Name = "formulaEditor";
            this.formulaEditor.Size = new System.Drawing.Size(780, 23);
            this.formulaEditor.TabIndex = 4;
            this.formulaEditor.Text = "AVERAGE(100, ABS(x2 - (x1 + 1)))";
            this.formulaEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // formulaEditorLabel
            // 
            this.formulaEditorLabel.AutoSize = true;
            this.formulaEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaEditorLabel.Location = new System.Drawing.Point(0, 66);
            this.formulaEditorLabel.Name = "formulaEditorLabel";
            this.formulaEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.formulaEditorLabel.Size = new System.Drawing.Size(795, 28);
            this.formulaEditorLabel.TabIndex = 3;
            this.formulaEditorLabel.Text = "This SyntaxEditor is using a dynamic language definition where nested parenthesis" +
    " alternate to a different color and could be used as a formula editor:";
            // 
            // xmlEditor
            // 
            this.xmlEditor.AcceptsTab = false;
            this.xmlEditor.AllowDrop = true;
            this.xmlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.xmlEditor.IsMultiLine = false;
            this.xmlEditor.IsOutliningMarginVisible = false;
            this.xmlEditor.IsSelectionMarginVisible = false;
            this.xmlEditor.Location = new System.Drawing.Point(0, 43);
            this.xmlEditor.Name = "xmlEditor";
            this.xmlEditor.Size = new System.Drawing.Size(780, 23);
            this.xmlEditor.TabIndex = 2;
            this.xmlEditor.Text = "<html><head><title>XHTML Editing</title></head><body>Edit with full automated Int" +
    "elliPrompt!</body></html>";
            // 
            // xmlEditorLabel
            // 
            this.xmlEditorLabel.AutoSize = true;
            this.xmlEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.xmlEditorLabel.Location = new System.Drawing.Point(0, 15);
            this.xmlEditorLabel.Name = "xmlEditorLabel";
            this.xmlEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.xmlEditorLabel.Size = new System.Drawing.Size(1316, 28);
            this.xmlEditorLabel.TabIndex = 1;
            this.xmlEditorLabel.Text = resources.GetString("xmlEditorLabel.Text");
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(1300, 15);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = resources.GetString("headerLabel.Text");
            // 
            // cSharpEditor
            // 
            this.cSharpEditor.AcceptsTab = false;
            this.cSharpEditor.AllowDrop = true;
            this.cSharpEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.cSharpEditor.Document.IsReadOnly = true;
            this.cSharpEditor.IsMultiLine = false;
            this.cSharpEditor.IsOutliningMarginVisible = false;
            this.cSharpEditor.IsSelectionMarginVisible = false;
            this.cSharpEditor.Location = new System.Drawing.Point(0, 145);
            this.cSharpEditor.Name = "cSharpEditor";
            this.cSharpEditor.Size = new System.Drawing.Size(780, 23);
            this.cSharpEditor.TabIndex = 6;
            this.cSharpEditor.Text = "int i = 50;  // Use ReadOnly mode for copyable code snippets";
            this.cSharpEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // cSharpEditorLabel
            // 
            this.cSharpEditorLabel.AutoSize = true;
            this.cSharpEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cSharpEditorLabel.Location = new System.Drawing.Point(0, 117);
            this.cSharpEditorLabel.Name = "cSharpEditorLabel";
            this.cSharpEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.cSharpEditorLabel.Size = new System.Drawing.Size(256, 28);
            this.cSharpEditorLabel.TabIndex = 5;
            this.cSharpEditorLabel.Text = "This is another SyntaxEditor in read-only mode:";
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
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Label xmlEditorLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor xmlEditor;
		private System.Windows.Forms.Label formulaEditorLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor formulaEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor cSharpEditor;
		private System.Windows.Forms.Label cSharpEditorLabel;
	}
}
