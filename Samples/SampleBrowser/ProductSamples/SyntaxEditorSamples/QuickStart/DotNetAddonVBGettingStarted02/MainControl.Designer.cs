namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DotNetAddonVBGettingStarted02 {
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
            this.codeEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            this.codeEditor.AllowDrop = true;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.IsLineNumberMarginVisible = true;
            this.codeEditor.Location = new System.Drawing.Point(10, 10);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.OverrideCursor = null;
            this.codeEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.codeEditor.Size = new System.Drawing.Size(780, 580);
            this.codeEditor.TabIndex = 0;
            this.codeEditor.Text = resources.GetString("codeEditor.Text");
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.codeEditor);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.TabIndex = 1;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor codeEditor;
		private System.Windows.Forms.Panel contentPanel;
	}
}
