namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsSquigglesIntro {
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
			editor = new UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			contentPanel = new System.Windows.Forms.Panel();
			contentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// editor
			// 
			editor.AllowDrop = true;
			editor.Dock = System.Windows.Forms.DockStyle.Fill;
			editor.Document.IsReadOnly = true;
			editor.Location = new System.Drawing.Point(10, 10);
			editor.Name = "editor";
			editor.Size = new System.Drawing.Size(780, 580);
			editor.TabIndex = 0;
			editor.Text = resources.GetString("editor.Text");
			// 
			// contentPanel
			// 
			contentPanel.Controls.Add(editor);
			contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			contentPanel.Location = new System.Drawing.Point(0, 0);
			contentPanel.Name = "contentPanel";
			contentPanel.Padding = new System.Windows.Forms.Padding(10);
			contentPanel.Size = new System.Drawing.Size(800, 600);
			contentPanel.TabIndex = 1;
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(contentPanel);
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			contentPanel.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel contentPanel;
	}
}
