namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewsSplitting {
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
            this.hasSplitCheckBox = new System.Windows.Forms.CheckBox();
            this.canSplitCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.Location = new System.Drawing.Point(13, 42);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 545);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.ViewSplitAdded += new System.EventHandler(this.OnEditorViewSplitAdded);
            this.editor.ViewSplitRemoved += new System.EventHandler(this.OnEditorViewSplitRemoved);
            // 
            // hasSplitCheckBox
            // 
            this.hasSplitCheckBox.AutoSize = true;
            this.hasSplitCheckBox.Location = new System.Drawing.Point(130, 3);
            this.hasSplitCheckBox.Name = "hasSplitCheckBox";
            this.hasSplitCheckBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.hasSplitCheckBox.Size = new System.Drawing.Size(124, 17);
            this.hasSplitCheckBox.TabIndex = 1;
            this.hasSplitCheckBox.Text = "Has horizontal split";
            this.hasSplitCheckBox.UseVisualStyleBackColor = true;
            this.hasSplitCheckBox.CheckedChanged += new System.EventHandler(this.OnHasSplitCheckBoxCheckedChanged);
            // 
            // canSplitCheckBox
            // 
            this.canSplitCheckBox.AutoSize = true;
            this.canSplitCheckBox.Location = new System.Drawing.Point(3, 3);
            this.canSplitCheckBox.Name = "canSplitCheckBox";
            this.canSplitCheckBox.Size = new System.Drawing.Size(121, 17);
            this.canSplitCheckBox.TabIndex = 0;
            this.canSplitCheckBox.Text = "Can split horizontally";
            this.canSplitCheckBox.UseVisualStyleBackColor = true;
            this.canSplitCheckBox.CheckedChanged += new System.EventHandler(this.OnCanSplitCheckBoxCheckedChanged);
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
            this.headerFlowLayoutPanel.Controls.Add(this.canSplitCheckBox);
            this.headerFlowLayoutPanel.Controls.Add(this.hasSplitCheckBox);
            this.headerFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(774, 23);
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
		private System.Windows.Forms.CheckBox hasSplitCheckBox;
		private System.Windows.Forms.CheckBox canSplitCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
	}
}
