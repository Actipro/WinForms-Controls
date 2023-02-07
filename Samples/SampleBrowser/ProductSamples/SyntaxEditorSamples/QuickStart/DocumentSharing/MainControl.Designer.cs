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
            this.leftEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.rightEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftEditor
            // 
            this.leftEditor.AllowDrop = true;
            this.leftEditor.AreWordWrapGlyphsVisible = true;
            this.leftEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftEditor.Location = new System.Drawing.Point(13, 13);
            this.leftEditor.Name = "leftEditor";
            this.leftEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.leftEditor.Size = new System.Drawing.Size(381, 574);
            this.leftEditor.TabIndex = 1;
            this.leftEditor.Text = resources.GetString("leftEditor.Text");
            this.leftEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // rightEditor
            // 
            this.rightEditor.AllowDrop = true;
            this.rightEditor.AreWordWrapGlyphsVisible = true;
            this.rightEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightEditor.Location = new System.Drawing.Point(405, 13);
            this.rightEditor.Name = "rightEditor";
            this.rightEditor.Size = new System.Drawing.Size(382, 574);
            this.rightEditor.TabIndex = 2;
            this.rightEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 3;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.leftEditor, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.rightEditor, 2, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 1;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor leftEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor rightEditor;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
