namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSwapping {
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
			this.instructionsLabel = new System.Windows.Forms.Label();
			this.documentComboBox = new System.Windows.Forms.ComboBox();
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
			this.editor.Location = new System.Drawing.Point(0, 33);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 547);
			this.editor.TabIndex = 1;
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.documentComboBox);
			this.headerPanel.Controls.Add(this.instructionsLabel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 33);
			this.headerPanel.TabIndex = 3;
			// 
			// instructionsLabel
			// 
			this.instructionsLabel.AutoSize = true;
			this.instructionsLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.instructionsLabel.Location = new System.Drawing.Point(0, 0);
			this.instructionsLabel.Name = "instructionsLabel";
			this.instructionsLabel.Padding = new System.Windows.Forms.Padding(0, 4, 2, 4);
			this.instructionsLabel.Size = new System.Drawing.Size(107, 23);
			this.instructionsLabel.TabIndex = 3;
			this.instructionsLabel.Text = "Current document";
			// 
			// documentComboBox
			// 
			this.documentComboBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.documentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.documentComboBox.FormattingEnabled = true;
			this.documentComboBox.Location = new System.Drawing.Point(107, 0);
			this.documentComboBox.Name = "documentComboBox";
			this.documentComboBox.Size = new System.Drawing.Size(121, 23);
			this.documentComboBox.TabIndex = 4;
			this.documentComboBox.SelectedIndexChanged += new System.EventHandler(this.OnDocumentComboBoxSelectedIndexChanged);
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
		private System.Windows.Forms.Label instructionsLabel;
		private System.Windows.Forms.ComboBox documentComboBox;
	}
}
