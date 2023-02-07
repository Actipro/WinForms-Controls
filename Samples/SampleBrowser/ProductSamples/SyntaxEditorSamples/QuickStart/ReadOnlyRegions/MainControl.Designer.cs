namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ReadOnlyRegions {
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
            this.makeSelectionReadOnlyButton = new System.Windows.Forms.Button();
            this.highlightRegionsCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Location = new System.Drawing.Point(13, 54);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 533);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // makeSelectionReadOnlyButton
            // 
            this.makeSelectionReadOnlyButton.AutoSize = true;
            this.makeSelectionReadOnlyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.makeSelectionReadOnlyButton.Location = new System.Drawing.Point(159, 3);
            this.makeSelectionReadOnlyButton.Name = "makeSelectionReadOnlyButton";
            this.makeSelectionReadOnlyButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.makeSelectionReadOnlyButton.Size = new System.Drawing.Size(155, 29);
            this.makeSelectionReadOnlyButton.TabIndex = 1;
            this.makeSelectionReadOnlyButton.Text = "Make selection read-only";
            this.makeSelectionReadOnlyButton.UseVisualStyleBackColor = true;
            this.makeSelectionReadOnlyButton.Click += new System.EventHandler(this.OnMakeSelectionReadOnlyButtonClick);
            // 
            // highlightRegionsCheckBox
            // 
            this.highlightRegionsCheckBox.AutoSize = true;
            this.highlightRegionsCheckBox.Checked = true;
            this.highlightRegionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highlightRegionsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.highlightRegionsCheckBox.Name = "highlightRegionsCheckBox";
            this.highlightRegionsCheckBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.highlightRegionsCheckBox.Size = new System.Drawing.Size(150, 22);
            this.highlightRegionsCheckBox.TabIndex = 0;
            this.highlightRegionsCheckBox.Text = "Highlight read-only regions";
            this.highlightRegionsCheckBox.UseVisualStyleBackColor = true;
            this.highlightRegionsCheckBox.CheckedChanged += new System.EventHandler(this.OnHighlightRegionsCheckBoxChecked);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.headerFlowLayoutPanel, 0, 0);
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
            this.headerFlowLayoutPanel.Controls.Add(this.highlightRegionsCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.makeSelectionReadOnlyButton);
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
		private System.Windows.Forms.CheckBox highlightRegionsCheckBox;
		private System.Windows.Forms.Button makeSelectionReadOnlyButton;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
