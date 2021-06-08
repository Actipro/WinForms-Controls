namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.TextChangesCancelling {
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
            this.alternateTextCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Location = new System.Drawing.Point(0, 48);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 532);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.DocumentTextChanging += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangingEventArgs>(this.OnEditorDocumentTextChanging);
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.alternateTextCheckBox);
            this.headerPanel.Controls.Add(this.cancelCheckBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 48);
            this.headerPanel.TabIndex = 3;
            // 
            // alternateTextCheckBox
            // 
            this.alternateTextCheckBox.AutoSize = true;
            this.alternateTextCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.alternateTextCheckBox.Location = new System.Drawing.Point(0, 19);
            this.alternateTextCheckBox.Name = "alternateTextCheckBox";
            this.alternateTextCheckBox.Size = new System.Drawing.Size(780, 19);
            this.alternateTextCheckBox.TabIndex = 3;
            this.alternateTextCheckBox.Text = "Insert alternate text instead when canceling";
            this.alternateTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelCheckBox
            // 
            this.cancelCheckBox.AutoSize = true;
            this.cancelCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancelCheckBox.Location = new System.Drawing.Point(0, 0);
            this.cancelCheckBox.Name = "cancelCheckBox";
            this.cancelCheckBox.Size = new System.Drawing.Size(780, 19);
            this.cancelCheckBox.TabIndex = 2;
            this.cancelCheckBox.Text = "Cancel text changes";
            this.cancelCheckBox.UseVisualStyleBackColor = true;
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
		private System.Windows.Forms.CheckBox cancelCheckBox;
		private System.Windows.Forms.CheckBox alternateTextCheckBox;
	}
}
