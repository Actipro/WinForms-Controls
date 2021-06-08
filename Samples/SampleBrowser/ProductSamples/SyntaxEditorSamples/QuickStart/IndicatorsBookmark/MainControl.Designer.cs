namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsBookmark {
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
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toggleIndicatorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toggleBookmarkEnabledToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearIndicatorsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.goToPreviousIndicatorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goToNextIndicatorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contentPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.editor);
            this.contentPanel.Controls.Add(this.mainToolStrip);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsIndicatorMarginVisible = true;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(0, 25);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 555);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleIndicatorToolStripButton,
            this.toggleBookmarkEnabledToolStripButton,
            this.clearIndicatorsToolStripButton,
            this.toolStripSeparator1,
            this.goToPreviousIndicatorToolStripButton,
            this.goToNextIndicatorToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(780, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toggleIndicatorToolStripButton
            // 
            this.toggleIndicatorToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconBookmark16;
            this.toggleIndicatorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleIndicatorToolStripButton.Name = "toggleIndicatorToolStripButton";
            this.toggleIndicatorToolStripButton.Size = new System.Drawing.Size(119, 22);
            this.toggleIndicatorToolStripButton.Text = "Toggle Bookmark";
            this.toggleIndicatorToolStripButton.Click += new System.EventHandler(this.OnToggleIndicatorToolStripButtonClick);
            // 
            // toggleBookmarkEnabledToolStripButton
            // 
            this.toggleBookmarkEnabledToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconBookmarkDisabled16;
            this.toggleBookmarkEnabledToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleBookmarkEnabledToolStripButton.Name = "toggleBookmarkEnabledToolStripButton";
            this.toggleBookmarkEnabledToolStripButton.Size = new System.Drawing.Size(107, 22);
            this.toggleBookmarkEnabledToolStripButton.Text = "Toggle Enabled";
            this.toggleBookmarkEnabledToolStripButton.Click += new System.EventHandler(this.OnToggleBookmarkEnabledToolStripButtonClick);
            // 
            // clearIndicatorsToolStripButton
            // 
            this.clearIndicatorsToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconDelete16;
            this.clearIndicatorsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearIndicatorsToolStripButton.Name = "clearIndicatorsToolStripButton";
            this.clearIndicatorsToolStripButton.Size = new System.Drawing.Size(133, 22);
            this.clearIndicatorsToolStripButton.Text = "Clear All Bookmarks";
            this.clearIndicatorsToolStripButton.Click += new System.EventHandler(this.OnClearIndicatorsToolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // goToPreviousIndicatorToolStripButton
            // 
            this.goToPreviousIndicatorToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconBack16;
            this.goToPreviousIndicatorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToPreviousIndicatorToolStripButton.Name = "goToPreviousIndicatorToolStripButton";
            this.goToPreviousIndicatorToolStripButton.Size = new System.Drawing.Size(129, 22);
            this.goToPreviousIndicatorToolStripButton.Text = "Previous Bookmark";
            this.goToPreviousIndicatorToolStripButton.Click += new System.EventHandler(this.OnGoToPreviousIndicatorToolStripButtonClick);
            // 
            // goToNextIndicatorToolStripButton
            // 
            this.goToNextIndicatorToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconNext16;
            this.goToNextIndicatorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToNextIndicatorToolStripButton.Name = "goToNextIndicatorToolStripButton";
            this.goToNextIndicatorToolStripButton.Size = new System.Drawing.Size(109, 22);
            this.goToNextIndicatorToolStripButton.Text = "Next Bookmark";
            this.goToNextIndicatorToolStripButton.Click += new System.EventHandler(this.OnGoToNextIndicatorToolStripButtonClick);
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
            this.contentPanel.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.ToolStripButton toggleIndicatorToolStripButton;
		private System.Windows.Forms.ToolStripButton toggleBookmarkEnabledToolStripButton;
		private System.Windows.Forms.ToolStripButton clearIndicatorsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton goToPreviousIndicatorToolStripButton;
		private System.Windows.Forms.ToolStripButton goToNextIndicatorToolStripButton;
	}
}
