namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsIntro {
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
			this.spacerPanel = new System.Windows.Forms.Panel();
			this.readOnlyEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.collapseButton = new System.Windows.Forms.Button();
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
			this.contentPanel.Controls.Add(this.spacerPanel);
			this.contentPanel.Controls.Add(this.readOnlyEditor);
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
			this.editor.IsLineNumberMarginVisible = true;
			this.editor.Location = new System.Drawing.Point(0, 33);
			this.editor.Name = "editor";
			this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.editor.Size = new System.Drawing.Size(780, 274);
			this.editor.TabIndex = 1;
			this.editor.Text = resources.GetString("editor.Text");
			this.editor.DocumentTextChanged += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangedEventArgs>(this.OnDocumentTextChanged);
			// 
			// spacerPanel
			// 
			this.spacerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spacerPanel.Location = new System.Drawing.Point(0, 307);
			this.spacerPanel.Name = "spacerPanel";
			this.spacerPanel.Size = new System.Drawing.Size(780, 10);
			this.spacerPanel.TabIndex = 4;
			// 
			// readOnlyEditor
			// 
			this.readOnlyEditor.AllowDrop = true;
			this.readOnlyEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.readOnlyEditor.Document.IsReadOnly = true;
			this.readOnlyEditor.IsLineNumberMarginVisible = true;
			this.readOnlyEditor.Location = new System.Drawing.Point(0, 317);
			this.readOnlyEditor.Name = "readOnlyEditor";
			this.readOnlyEditor.Size = new System.Drawing.Size(780, 263);
			this.readOnlyEditor.TabIndex = 2;
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.collapseButton);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 33);
			this.headerPanel.TabIndex = 3;
			// 
			// collapseButton
			// 
			this.collapseButton.AutoSize = true;
			this.collapseButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.collapseButton.Location = new System.Drawing.Point(0, 0);
			this.collapseButton.Name = "collapseButton";
			this.collapseButton.Size = new System.Drawing.Size(133, 23);
			this.collapseButton.TabIndex = 5;
			this.collapseButton.Text = "Collapse Selected Text";
			this.collapseButton.UseVisualStyleBackColor = true;
			this.collapseButton.Click += new System.EventHandler(this.OnCollapseButtonClick);
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
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor readOnlyEditor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Button collapseButton;
		private System.Windows.Forms.Panel spacerPanel;
	}
}
