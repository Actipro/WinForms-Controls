namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GoToLine {
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
			this.label1 = new System.Windows.Forms.Label();
			this.lineNumberTextBox = new System.Windows.Forms.TextBox();
			this.goToLineButton = new System.Windows.Forms.Button();
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
			this.editor.Location = new System.Drawing.Point(0, 34);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 546);
			this.editor.TabIndex = 1;
			this.editor.Text = resources.GetString("editor.Text");
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.goToLineButton);
			this.headerPanel.Controls.Add(this.lineNumberTextBox);
			this.headerPanel.Controls.Add(this.label1);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 34);
			this.headerPanel.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.label1.Size = new System.Drawing.Size(74, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line number";
			// 
			// lineNumberTextBox
			// 
			this.lineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.lineNumberTextBox.Location = new System.Drawing.Point(74, 0);
			this.lineNumberTextBox.Name = "lineNumberTextBox";
			this.lineNumberTextBox.Size = new System.Drawing.Size(100, 23);
			this.lineNumberTextBox.TabIndex = 1;
			this.lineNumberTextBox.Text = "50";
			// 
			// goToLineButton
			// 
			this.goToLineButton.AutoSize = true;
			this.goToLineButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.goToLineButton.Location = new System.Drawing.Point(174, 0);
			this.goToLineButton.Name = "goToLineButton";
			this.goToLineButton.Size = new System.Drawing.Size(78, 24);
			this.goToLineButton.TabIndex = 2;
			this.goToLineButton.Text = "Go to line";
			this.goToLineButton.UseVisualStyleBackColor = true;
			this.goToLineButton.Click += new System.EventHandler(this.OnGoToLineButtonClick);
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
		private System.Windows.Forms.Button goToLineButton;
		private System.Windows.Forms.TextBox lineNumberTextBox;
		private System.Windows.Forms.Label label1;
	}
}
