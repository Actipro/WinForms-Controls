namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted02 {
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
			this.functionCountLabel = new System.Windows.Forms.Label();
			this.functionLabel = new System.Windows.Forms.Label();
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
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.Location = new System.Drawing.Point(0, 23);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 557);
			this.editor.TabIndex = 1;
			this.editor.Text = resources.GetString("editor.Text");
			this.editor.DocumentParseDataChanged += new System.EventHandler(this.OnCodeEditorDocumentParseDataChanged);
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.functionCountLabel);
			this.headerPanel.Controls.Add(this.functionLabel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(780, 23);
			this.headerPanel.TabIndex = 3;
			// 
			// functionCountLabel
			// 
			this.functionCountLabel.AutoSize = true;
			this.functionCountLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.functionCountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.functionCountLabel.Location = new System.Drawing.Point(187, 0);
			this.functionCountLabel.Name = "functionCountLabel";
			this.functionCountLabel.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
			this.functionCountLabel.Size = new System.Drawing.Size(20, 23);
			this.functionCountLabel.TabIndex = 4;
			this.functionCountLabel.Text = "0";
			// 
			// functionLabel
			// 
			this.functionLabel.AutoSize = true;
			this.functionLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.functionLabel.Location = new System.Drawing.Point(0, 0);
			this.functionLabel.Name = "functionLabel";
			this.functionLabel.Padding = new System.Windows.Forms.Padding(0, 4, 2, 4);
			this.functionLabel.Size = new System.Drawing.Size(187, 23);
			this.functionLabel.TabIndex = 3;
			this.functionLabel.Text = "Number of functions in this code:";
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
		private System.Windows.Forms.Label functionCountLabel;
		private System.Windows.Forms.Label functionLabel;
	}
}
