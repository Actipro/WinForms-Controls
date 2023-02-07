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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.alternateTextCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 522);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.DocumentTextChanging += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangingEventArgs>(this.OnEditorDocumentTextChanging);
            // 
            // alternateTextCheckBox
            // 
            this.alternateTextCheckBox.AutoSize = true;
            this.alternateTextCheckBox.Location = new System.Drawing.Point(3, 26);
            this.alternateTextCheckBox.Name = "alternateTextCheckBox";
            this.alternateTextCheckBox.Size = new System.Drawing.Size(231, 17);
            this.alternateTextCheckBox.TabIndex = 3;
            this.alternateTextCheckBox.Text = "Insert alternate text instead when canceling";
            this.alternateTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelCheckBox
            // 
            this.cancelCheckBox.AutoSize = true;
            this.cancelCheckBox.Location = new System.Drawing.Point(3, 3);
            this.cancelCheckBox.Name = "cancelCheckBox";
            this.cancelCheckBox.Size = new System.Drawing.Size(123, 17);
            this.cancelCheckBox.TabIndex = 2;
            this.cancelCheckBox.Text = "Cancel text changes";
            this.cancelCheckBox.UseVisualStyleBackColor = true;
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
            this.headerFlowLayoutPanel.Controls.Add(this.cancelCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.alternateTextCheckBox);
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
		private System.Windows.Forms.CheckBox cancelCheckBox;
		private System.Windows.Forms.CheckBox alternateTextCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
