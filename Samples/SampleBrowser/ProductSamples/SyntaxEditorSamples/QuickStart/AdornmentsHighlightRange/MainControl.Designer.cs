namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsHighlightRange {
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
            this.clearButton = new System.Windows.Forms.Button();
            this.highlightSelectionButton = new System.Windows.Forms.Button();
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
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(0, 33);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 547);
            this.editor.TabIndex = 10;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.clearButton);
            this.headerPanel.Controls.Add(this.highlightSelectionButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 33);
            this.headerPanel.TabIndex = 3;
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.clearButton.Location = new System.Drawing.Point(133, 0);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(143, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear All Highlights";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // highlightSelectionButton
            // 
            this.highlightSelectionButton.AutoSize = true;
            this.highlightSelectionButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.highlightSelectionButton.Location = new System.Drawing.Point(0, 0);
            this.highlightSelectionButton.Name = "highlightSelectionButton";
            this.highlightSelectionButton.Size = new System.Drawing.Size(133, 23);
            this.highlightSelectionButton.TabIndex = 0;
            this.highlightSelectionButton.Text = "Highlight Selection";
            this.highlightSelectionButton.UseVisualStyleBackColor = true;
            this.highlightSelectionButton.Click += new System.EventHandler(this.OnHighlightSelectionButtonClick);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
		private System.Windows.Forms.Button highlightSelectionButton;
		private System.Windows.Forms.Button clearButton;
	}
}
