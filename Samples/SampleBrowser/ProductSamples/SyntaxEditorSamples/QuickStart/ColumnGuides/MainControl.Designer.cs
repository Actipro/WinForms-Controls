namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ColumnGuides {
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
            this.resetColumnGuidesButton = new System.Windows.Forms.Button();
            this.toggleColumnGuideButton = new System.Windows.Forms.Button();
            this.areColumnGuidesVisibleCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.IsOutliningMarginVisible = false;
            this.editor.Location = new System.Drawing.Point(13, 54);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 533);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // resetColumnGuidesButton
            // 
            this.resetColumnGuidesButton.AutoSize = true;
            this.resetColumnGuidesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetColumnGuidesButton.Location = new System.Drawing.Point(379, 3);
            this.resetColumnGuidesButton.Name = "resetColumnGuidesButton";
            this.resetColumnGuidesButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.resetColumnGuidesButton.Size = new System.Drawing.Size(139, 29);
            this.resetColumnGuidesButton.TabIndex = 2;
            this.resetColumnGuidesButton.Text = "Reset Column Guides";
            this.resetColumnGuidesButton.UseVisualStyleBackColor = true;
            this.resetColumnGuidesButton.Click += new System.EventHandler(this.OnResetColumnGuidesButtonClick);
            // 
            // toggleColumnGuideButton
            // 
            this.toggleColumnGuideButton.AutoSize = true;
            this.toggleColumnGuideButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleColumnGuideButton.Location = new System.Drawing.Point(154, 3);
            this.toggleColumnGuideButton.Name = "toggleColumnGuideButton";
            this.toggleColumnGuideButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.toggleColumnGuideButton.Size = new System.Drawing.Size(219, 29);
            this.toggleColumnGuideButton.TabIndex = 1;
            this.toggleColumnGuideButton.Text = "Toggle Column Guide at Caret Position";
            this.toggleColumnGuideButton.UseVisualStyleBackColor = true;
            this.toggleColumnGuideButton.Click += new System.EventHandler(this.OnToggleColumnGuideButtonClick);
            // 
            // areColumnGuidesVisibleCheckBox
            // 
            this.areColumnGuidesVisibleCheckBox.AutoSize = true;
            this.areColumnGuidesVisibleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.areColumnGuidesVisibleCheckBox.Name = "areColumnGuidesVisibleCheckBox";
            this.areColumnGuidesVisibleCheckBox.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.areColumnGuidesVisibleCheckBox.Size = new System.Drawing.Size(145, 24);
            this.areColumnGuidesVisibleCheckBox.TabIndex = 0;
            this.areColumnGuidesVisibleCheckBox.Text = "Are column guides visible";
            this.areColumnGuidesVisibleCheckBox.UseVisualStyleBackColor = true;
            this.areColumnGuidesVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnAreColumnGuidesVisibleCheckBoxCheckedChanged);
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
            this.headerFlowLayoutPanel.Controls.Add(this.areColumnGuidesVisibleCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.toggleColumnGuideButton);
            this.headerFlowLayoutPanel.Controls.Add(this.resetColumnGuidesButton);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 35);
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
		private System.Windows.Forms.CheckBox areColumnGuidesVisibleCheckBox;
		private System.Windows.Forms.Button toggleColumnGuideButton;
		private System.Windows.Forms.Button resetColumnGuidesButton;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
