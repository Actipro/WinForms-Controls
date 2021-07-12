namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ReadOnlyDocument {
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
            this.isDocumentReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Document.IsReadOnly = true;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(0, 31);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 549);
            this.editor.TabIndex = 1;
            this.editor.Text = "Documents can be made read-only by setting their IsReadOnly\r\nproperty to true.\r\n\r" +
    "\nSyntaxEditor watches that property and automatically updates the\r\nUI to reflect" +
    " read-only mode when active.\r\n";
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.isDocumentReadOnlyCheckBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 31);
            this.headerPanel.TabIndex = 3;
            // 
            // isDocumentReadOnlyCheckBox
            // 
            this.isDocumentReadOnlyCheckBox.AutoSize = true;
            this.isDocumentReadOnlyCheckBox.Checked = true;
            this.isDocumentReadOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDocumentReadOnlyCheckBox.Location = new System.Drawing.Point(0, 0);
            this.isDocumentReadOnlyCheckBox.Name = "isDocumentReadOnlyCheckBox";
            this.isDocumentReadOnlyCheckBox.Size = new System.Drawing.Size(147, 19);
            this.isDocumentReadOnlyCheckBox.TabIndex = 0;
            this.isDocumentReadOnlyCheckBox.Text = "Document is read-only";
            this.isDocumentReadOnlyCheckBox.UseVisualStyleBackColor = true;
            this.isDocumentReadOnlyCheckBox.CheckedChanged += new System.EventHandler(this.OnIsDocumentReadOnlyCheckBoxCheckedChanged);
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
		private System.Windows.Forms.CheckBox isDocumentReadOnlyCheckBox;
	}
}
