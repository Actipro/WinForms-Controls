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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.identifierCheckBox = new System.Windows.Forms.CheckBox();
            this.commentsCheckBox = new System.Windows.Forms.CheckBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 65);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 522);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // identifierCheckBox
            // 
            this.identifierCheckBox.AutoSize = true;
            this.identifierCheckBox.Location = new System.Drawing.Point(3, 26);
            this.identifierCheckBox.Name = "identifierCheckBox";
            this.identifierCheckBox.Size = new System.Drawing.Size(165, 17);
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
            this.commentsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.commentsCheckBox.Name = "commentsCheckBox";
            this.commentsCheckBox.Size = new System.Drawing.Size(242, 17);
            this.commentsCheckBox.TabIndex = 0;
            this.commentsCheckBox.Text = "Highlight \'Actipro\' in documentation comments";
            this.commentsCheckBox.UseVisualStyleBackColor = true;
            this.commentsCheckBox.CheckedChanged += new System.EventHandler(this.OnCommentsCheckBoxCheckedChanged);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.headerFlowLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
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
            // headerFlowLayoutPanel
            // 
            this.headerFlowLayoutPanel.AutoSize = true;
            this.headerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerFlowLayoutPanel.Controls.Add(this.commentsCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.identifierCheckBox);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 46);
            this.headerFlowLayoutPanel.TabIndex = 3;
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
            this.headerFlowLayoutPanel.ResumeLayout(false);
            this.headerFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.CheckBox identifierCheckBox;
		private System.Windows.Forms.CheckBox commentsCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
