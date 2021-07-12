namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.LineCommenting {
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
            this.commentLinesButton = new System.Windows.Forms.Button();
            this.lineCommentersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uncommentLinesButton = new System.Windows.Forms.Button();
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
            this.editor.Location = new System.Drawing.Point(0, 34);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 546);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.commentLinesButton);
            this.headerPanel.Controls.Add(this.lineCommentersComboBox);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Controls.Add(this.uncommentLinesButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 34);
            this.headerPanel.TabIndex = 3;
            // 
            // commentLinesButton
            // 
            this.commentLinesButton.AutoSize = true;
            this.commentLinesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.commentLinesButton.Location = new System.Drawing.Point(565, 0);
            this.commentLinesButton.Name = "commentLinesButton";
            this.commentLinesButton.Size = new System.Drawing.Size(101, 24);
            this.commentLinesButton.TabIndex = 2;
            this.commentLinesButton.Text = "Comment Lines";
            this.commentLinesButton.UseVisualStyleBackColor = true;
            this.commentLinesButton.Click += new System.EventHandler(this.OnCommentLinesButtonClick);
            // 
            // lineCommentersComboBox
            // 
            this.lineCommentersComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineCommentersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineCommentersComboBox.FormattingEnabled = true;
            this.lineCommentersComboBox.Items.AddRange(new object[] {
            "// (per-line)",
            "/* */ (range)"});
            this.lineCommentersComboBox.Location = new System.Drawing.Point(94, 0);
            this.lineCommentersComboBox.Name = "lineCommentersComboBox";
            this.lineCommentersComboBox.Size = new System.Drawing.Size(121, 23);
            this.lineCommentersComboBox.TabIndex = 3;
            this.lineCommentersComboBox.SelectedValueChanged += new System.EventHandler(this.OnLineCommentersComboBoxSelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line commenter";
            // 
            // uncommentLinesButton
            // 
            this.uncommentLinesButton.AutoSize = true;
            this.uncommentLinesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.uncommentLinesButton.Location = new System.Drawing.Point(666, 0);
            this.uncommentLinesButton.Name = "uncommentLinesButton";
            this.uncommentLinesButton.Size = new System.Drawing.Size(114, 24);
            this.uncommentLinesButton.TabIndex = 4;
            this.uncommentLinesButton.Text = "Uncomment Lines";
            this.uncommentLinesButton.UseVisualStyleBackColor = true;
            this.uncommentLinesButton.Click += new System.EventHandler(this.OnUncommentLinesButtonClick);
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
		private System.Windows.Forms.Button commentLinesButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox lineCommentersComboBox;
		private System.Windows.Forms.Button uncommentLinesButton;
	}
}
