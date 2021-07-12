namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ClassificationLayered {
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
			this.identifierCheckBox = new System.Windows.Forms.CheckBox();
			this.commentsCheckBox = new System.Windows.Forms.CheckBox();
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
			this.editor.Location = new System.Drawing.Point(0, 51);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 529);
			this.editor.TabIndex = 1;
			this.editor.Text = resources.GetString("editor.Text");
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.identifierCheckBox);
			this.headerPanel.Controls.Add(this.commentsCheckBox);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 51);
			this.headerPanel.TabIndex = 3;
			// 
			// identifierCheckBox
			// 
			this.identifierCheckBox.AutoSize = true;
			this.identifierCheckBox.Location = new System.Drawing.Point(0, 22);
			this.identifierCheckBox.Name = "identifierCheckBox";
			this.identifierCheckBox.Size = new System.Drawing.Size(192, 19);
			this.identifierCheckBox.TabIndex = 1;
			this.identifierCheckBox.Text = "Highlight \'Actipro\' in identifiers";
			this.identifierCheckBox.UseVisualStyleBackColor = true;
			this.identifierCheckBox.CheckedChanged += new System.EventHandler(this.OnIdentifiersCheckBoxCheckedChanged);
			// 
			// commentsCheckBox
			// 
			this.commentsCheckBox.AutoSize = true;
			this.commentsCheckBox.Checked = true;
			this.commentsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.commentsCheckBox.Location = new System.Drawing.Point(0, 0);
			this.commentsCheckBox.Name = "commentsCheckBox";
			this.commentsCheckBox.Size = new System.Drawing.Size(282, 19);
			this.commentsCheckBox.TabIndex = 0;
			this.commentsCheckBox.Text = "Highlight \'Actipro\' in documentation comments";
			this.commentsCheckBox.UseVisualStyleBackColor = true;
			this.commentsCheckBox.CheckedChanged += new System.EventHandler(this.OnCommentsCheckBoxCheckedChanged);
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
		private System.Windows.Forms.CheckBox identifierCheckBox;
		private System.Windows.Forms.CheckBox commentsCheckBox;
	}
}
