namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSharing {
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
			this.topEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.spacerPanel = new System.Windows.Forms.Panel();
			this.bottomEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.contentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// contentPanel
			// 
			this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contentPanel.Controls.Add(this.topEditor);
			this.contentPanel.Controls.Add(this.spacerPanel);
			this.contentPanel.Controls.Add(this.bottomEditor);
			this.contentPanel.Location = new System.Drawing.Point(10, 10);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(780, 580);
			this.contentPanel.TabIndex = 1;
			// 
			// topEditor
			// 
			this.topEditor.AllowDrop = true;
			this.topEditor.AreWordWrapGlyphsVisible = true;
			this.topEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topEditor.Location = new System.Drawing.Point(0, 0);
			this.topEditor.Name = "topEditor";
			this.topEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.topEditor.Size = new System.Drawing.Size(780, 284);
			this.topEditor.TabIndex = 1;
			this.topEditor.Text = resources.GetString("topEditor.Text");
			this.topEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
			// 
			// spacerPanel
			// 
			this.spacerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.spacerPanel.Location = new System.Drawing.Point(0, 284);
			this.spacerPanel.Name = "spacerPanel";
			this.spacerPanel.Size = new System.Drawing.Size(780, 10);
			this.spacerPanel.TabIndex = 4;
			// 
			// bottomEditor
			// 
			this.bottomEditor.AllowDrop = true;
			this.bottomEditor.AreWordWrapGlyphsVisible = true;
			this.bottomEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomEditor.Location = new System.Drawing.Point(0, 294);
			this.bottomEditor.Name = "bottomEditor";
			this.bottomEditor.Size = new System.Drawing.Size(780, 286);
			this.bottomEditor.TabIndex = 2;
			this.bottomEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor topEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor bottomEditor;
		private System.Windows.Forms.Panel spacerPanel;
	}
}
