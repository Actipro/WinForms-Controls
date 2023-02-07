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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.functionCountLabel = new System.Windows.Forms.Label();
            this.functionLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 36);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 551);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.DocumentParseDataChanged += new System.EventHandler(this.OnCodeEditorDocumentParseDataChanged);
            // 
            // functionCountLabel
            // 
            this.functionCountLabel.AutoSize = true;
            this.functionCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionCountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionCountLabel.Location = new System.Drawing.Point(183, 10);
            this.functionCountLabel.Name = "functionCountLabel";
            this.functionCountLabel.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
            this.functionCountLabel.Size = new System.Drawing.Size(604, 23);
            this.functionCountLabel.TabIndex = 4;
            this.functionCountLabel.Text = "0";
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionLabel.Location = new System.Drawing.Point(13, 10);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Padding = new System.Windows.Forms.Padding(0, 4, 2, 4);
            this.functionLabel.Size = new System.Drawing.Size(164, 23);
            this.functionLabel.TabIndex = 3;
            this.functionLabel.Text = "Number of functions in this code:";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.functionCountLabel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.functionLabel, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Label functionCountLabel;
		private System.Windows.Forms.Label functionLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
