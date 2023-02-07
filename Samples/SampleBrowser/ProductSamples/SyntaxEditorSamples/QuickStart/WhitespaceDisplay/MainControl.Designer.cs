namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WhitespaceDisplay {
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
            this.isWhiteSpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.tabSizeCurrentValueLabel = new System.Windows.Forms.Label();
            this.tabSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.tabSizeLabel = new System.Windows.Forms.Label();
            this.tabSizeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeTrackBar)).BeginInit();
            this.tabSizeFlowLayoutPanel.SuspendLayout();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsOutliningMarginVisible = false;
            this.editor.IsWhitespaceVisible = true;
            this.editor.Location = new System.Drawing.Point(13, 76);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 511);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // isWhiteSpaceVisibleCheckBox
            // 
            this.isWhiteSpaceVisibleCheckBox.AutoSize = true;
            this.isWhiteSpaceVisibleCheckBox.Checked = true;
            this.isWhiteSpaceVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isWhiteSpaceVisibleCheckBox.Location = new System.Drawing.Point(299, 3);
            this.isWhiteSpaceVisibleCheckBox.Name = "isWhiteSpaceVisibleCheckBox";
            this.isWhiteSpaceVisibleCheckBox.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.isWhiteSpaceVisibleCheckBox.Size = new System.Drawing.Size(123, 27);
            this.isWhiteSpaceVisibleCheckBox.TabIndex = 2;
            this.isWhiteSpaceVisibleCheckBox.Text = "Is whitespace visible";
            this.isWhiteSpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            this.isWhiteSpaceVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnIsWhitespaceVisibleCheckBoxCheckedChanged);
            // 
            // tabSizeCurrentValueLabel
            // 
            this.tabSizeCurrentValueLabel.AutoSize = true;
            this.tabSizeCurrentValueLabel.Location = new System.Drawing.Point(224, 0);
            this.tabSizeCurrentValueLabel.Name = "tabSizeCurrentValueLabel";
            this.tabSizeCurrentValueLabel.Padding = new System.Windows.Forms.Padding(0, 10, 50, 0);
            this.tabSizeCurrentValueLabel.Size = new System.Drawing.Size(63, 23);
            this.tabSizeCurrentValueLabel.TabIndex = 4;
            this.tabSizeCurrentValueLabel.Text = "4";
            // 
            // tabSizeTrackBar
            // 
            this.tabSizeTrackBar.LargeChange = 1;
            this.tabSizeTrackBar.Location = new System.Drawing.Point(59, 3);
            this.tabSizeTrackBar.Maximum = 16;
            this.tabSizeTrackBar.Minimum = 1;
            this.tabSizeTrackBar.Name = "tabSizeTrackBar";
            this.tabSizeTrackBar.Size = new System.Drawing.Size(159, 45);
            this.tabSizeTrackBar.TabIndex = 3;
            this.tabSizeTrackBar.Value = 4;
            this.tabSizeTrackBar.ValueChanged += new System.EventHandler(this.OnTabSizeTrackBarValueChanged);
            // 
            // tabSizeLabel
            // 
            this.tabSizeLabel.AutoSize = true;
            this.tabSizeLabel.Location = new System.Drawing.Point(3, 0);
            this.tabSizeLabel.Name = "tabSizeLabel";
            this.tabSizeLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tabSizeLabel.Size = new System.Drawing.Size(50, 23);
            this.tabSizeLabel.TabIndex = 0;
            this.tabSizeLabel.Text = "Tab size:";
            // 
            // tabSizeFlowLayoutPanel
            // 
            this.tabSizeFlowLayoutPanel.AutoSize = true;
            this.tabSizeFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabSizeFlowLayoutPanel.Controls.Add(this.tabSizeLabel);
            this.tabSizeFlowLayoutPanel.Controls.Add(this.tabSizeTrackBar);
            this.tabSizeFlowLayoutPanel.Controls.Add(this.tabSizeCurrentValueLabel);
            this.tabSizeFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tabSizeFlowLayoutPanel.Name = "tabSizeFlowLayoutPanel";
            this.tabSizeFlowLayoutPanel.Size = new System.Drawing.Size(290, 51);
            this.tabSizeFlowLayoutPanel.TabIndex = 2;
            this.tabSizeFlowLayoutPanel.WrapContents = false;
            // 
            // headerFlowLayoutPanel
            // 
            this.headerFlowLayoutPanel.AutoSize = true;
            this.headerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerFlowLayoutPanel.Controls.Add(this.tabSizeFlowLayoutPanel);
            this.headerFlowLayoutPanel.Controls.Add(this.isWhiteSpaceVisibleCheckBox);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 57);
            this.headerFlowLayoutPanel.TabIndex = 3;
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
            this.contentTableLayoutPanel.TabIndex = 4;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeTrackBar)).EndInit();
            this.tabSizeFlowLayoutPanel.ResumeLayout(false);
            this.tabSizeFlowLayoutPanel.PerformLayout();
            this.headerFlowLayoutPanel.ResumeLayout(false);
            this.headerFlowLayoutPanel.PerformLayout();
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Label tabSizeLabel;
		private System.Windows.Forms.CheckBox isWhiteSpaceVisibleCheckBox;
		private System.Windows.Forms.TrackBar tabSizeTrackBar;
		private System.Windows.Forms.Label tabSizeCurrentValueLabel;
		private System.Windows.Forms.FlowLayoutPanel tabSizeFlowLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
