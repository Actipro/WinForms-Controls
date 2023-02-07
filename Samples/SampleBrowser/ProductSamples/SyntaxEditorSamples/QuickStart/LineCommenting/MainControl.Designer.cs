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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.commentLinesButton = new System.Windows.Forms.Button();
            this.lineCommentersComboBox = new System.Windows.Forms.ComboBox();
            this.lineCommentersLabel = new System.Windows.Forms.Label();
            this.uncommentLinesButton = new System.Windows.Forms.Button();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerCommandsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lineCommentersComboBoxPanel = new System.Windows.Forms.Panel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerCommandsFlowLayoutPanel.SuspendLayout();
            this.lineCommentersComboBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 3);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 54);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 533);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // commentLinesButton
            // 
            this.commentLinesButton.AutoSize = true;
            this.commentLinesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commentLinesButton.Location = new System.Drawing.Point(3, 3);
            this.commentLinesButton.Name = "commentLinesButton";
            this.commentLinesButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.commentLinesButton.Size = new System.Drawing.Size(109, 29);
            this.commentLinesButton.TabIndex = 2;
            this.commentLinesButton.Text = "Comment Lines";
            this.commentLinesButton.UseVisualStyleBackColor = true;
            this.commentLinesButton.Click += new System.EventHandler(this.OnCommentLinesButtonClick);
            // 
            // lineCommentersComboBox
            // 
            this.lineCommentersComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineCommentersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineCommentersComboBox.FormattingEnabled = true;
            this.lineCommentersComboBox.Items.AddRange(new object[] {
            "// (per-line)",
            "/* */ (range)"});
            this.lineCommentersComboBox.Location = new System.Drawing.Point(0, 8);
            this.lineCommentersComboBox.Name = "lineCommentersComboBox";
            this.lineCommentersComboBox.Size = new System.Drawing.Size(437, 21);
            this.lineCommentersComboBox.TabIndex = 3;
            this.lineCommentersComboBox.SelectedValueChanged += new System.EventHandler(this.OnLineCommentersComboBoxSelectedValueChanged);
            // 
            // lineCommentersLabel
            // 
            this.lineCommentersLabel.AutoSize = true;
            this.lineCommentersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineCommentersLabel.Location = new System.Drawing.Point(13, 10);
            this.lineCommentersLabel.Name = "lineCommentersLabel";
            this.lineCommentersLabel.Size = new System.Drawing.Size(82, 41);
            this.lineCommentersLabel.TabIndex = 0;
            this.lineCommentersLabel.Text = "Line commenter";
            this.lineCommentersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uncommentLinesButton
            // 
            this.uncommentLinesButton.AutoSize = true;
            this.uncommentLinesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uncommentLinesButton.Location = new System.Drawing.Point(118, 3);
            this.uncommentLinesButton.Name = "uncommentLinesButton";
            this.uncommentLinesButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.uncommentLinesButton.Size = new System.Drawing.Size(122, 29);
            this.uncommentLinesButton.TabIndex = 4;
            this.uncommentLinesButton.Text = "Uncomment Lines";
            this.uncommentLinesButton.UseVisualStyleBackColor = true;
            this.uncommentLinesButton.Click += new System.EventHandler(this.OnUncommentLinesButtonClick);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 3;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.Controls.Add(this.lineCommentersComboBoxPanel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.headerCommandsFlowLayoutPanel, 2, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.lineCommentersLabel, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // headerCommandsFlowLayoutPanel
            // 
            this.headerCommandsFlowLayoutPanel.AutoSize = true;
            this.headerCommandsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerCommandsFlowLayoutPanel.Controls.Add(this.commentLinesButton);
            this.headerCommandsFlowLayoutPanel.Controls.Add(this.uncommentLinesButton);
            this.headerCommandsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerCommandsFlowLayoutPanel.Location = new System.Drawing.Point(544, 13);
            this.headerCommandsFlowLayoutPanel.Name = "headerCommandsFlowLayoutPanel";
            this.headerCommandsFlowLayoutPanel.Size = new System.Drawing.Size(243, 35);
            this.headerCommandsFlowLayoutPanel.TabIndex = 3;
            this.headerCommandsFlowLayoutPanel.WrapContents = false;
            // 
            // lineCommentersComboBoxPanel
            // 
            this.lineCommentersComboBoxPanel.AutoSize = true;
            this.lineCommentersComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lineCommentersComboBoxPanel.Controls.Add(this.lineCommentersComboBox);
            this.lineCommentersComboBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineCommentersComboBoxPanel.Location = new System.Drawing.Point(101, 13);
            this.lineCommentersComboBoxPanel.Name = "lineCommentersComboBoxPanel";
            this.lineCommentersComboBoxPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lineCommentersComboBoxPanel.Size = new System.Drawing.Size(437, 35);
            this.lineCommentersComboBoxPanel.TabIndex = 3;
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
            this.headerCommandsFlowLayoutPanel.ResumeLayout(false);
            this.headerCommandsFlowLayoutPanel.PerformLayout();
            this.lineCommentersComboBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Button commentLinesButton;
		private System.Windows.Forms.Label lineCommentersLabel;
		private System.Windows.Forms.ComboBox lineCommentersComboBox;
		private System.Windows.Forms.Button uncommentLinesButton;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerCommandsFlowLayoutPanel;
		private System.Windows.Forms.Panel lineCommentersComboBoxPanel;
	}
}
