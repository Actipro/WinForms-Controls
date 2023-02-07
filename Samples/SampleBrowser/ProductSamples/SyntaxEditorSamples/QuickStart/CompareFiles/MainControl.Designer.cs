namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CompareFiles {
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
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ignoreWhiteSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.oldEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.newEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 3;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.headerFlowLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.oldEditor, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.newEditor, 2, 1);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 3;
            // 
            // ignoreWhiteSpaceCheckBox
            // 
            this.ignoreWhiteSpaceCheckBox.AutoSize = true;
            this.ignoreWhiteSpaceCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ignoreWhiteSpaceCheckBox.Name = "ignoreWhiteSpaceCheckBox";
            this.ignoreWhiteSpaceCheckBox.Size = new System.Drawing.Size(116, 17);
            this.ignoreWhiteSpaceCheckBox.TabIndex = 3;
            this.ignoreWhiteSpaceCheckBox.Text = "Ignore white space";
            this.ignoreWhiteSpaceCheckBox.UseVisualStyleBackColor = true;
            this.ignoreWhiteSpaceCheckBox.CheckedChanged += new System.EventHandler(this.OnIgnoreWhiteSpaceCheckBoxCheckedChanged);
            // 
            // oldEditor
            // 
            this.oldEditor.AllowDrop = true;
            this.oldEditor.CanSplitHorizontally = false;
            this.oldEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oldEditor.IsLineNumberMarginVisible = true;
            this.oldEditor.IsOutliningMarginVisible = false;
            this.oldEditor.Location = new System.Drawing.Point(13, 42);
            this.oldEditor.Name = "oldEditor";
            this.oldEditor.OverrideCursor = null;
            this.oldEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.oldEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.oldEditor.Size = new System.Drawing.Size(380, 545);
            this.oldEditor.TabIndex = 1;
            this.oldEditor.Text = resources.GetString("oldEditor.Text");
            // 
            // newEditor
            // 
            this.newEditor.AllowDrop = true;
            this.newEditor.CanSplitHorizontally = false;
            this.newEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newEditor.IsLineNumberMarginVisible = true;
            this.newEditor.IsOutliningMarginVisible = false;
            this.newEditor.Location = new System.Drawing.Point(406, 42);
            this.newEditor.Name = "newEditor";
            this.newEditor.OverrideCursor = null;
            this.newEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.newEditor.Size = new System.Drawing.Size(381, 545);
            this.newEditor.TabIndex = 2;
            this.newEditor.Text = resources.GetString("newEditor.Text");
            // 
            // headerFlowLayoutPanel
            // 
            this.headerFlowLayoutPanel.AutoSize = true;
            this.headerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentTableLayoutPanel.SetColumnSpan(this.headerFlowLayoutPanel, 3);
            this.headerFlowLayoutPanel.Controls.Add(this.ignoreWhiteSpaceCheckBox);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 23);
            this.headerFlowLayoutPanel.TabIndex = 4;
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
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor oldEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor newEditor;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.CheckBox ignoreWhiteSpaceCheckBox;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
