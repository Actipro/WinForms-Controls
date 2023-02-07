namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging {
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
            this.toggleBreakpointToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toggleBreakpointEnabledToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearBreakpointsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startDebuggingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopDebuggingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contentPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.editor);
            this.contentPanel.Controls.Add(this.mainToolStrip);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsIndicatorMarginVisible = true;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(10, 35);
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
            this.toggleBreakpointToolStripButton,
            this.toggleBreakpointEnabledToolStripButton,
            this.clearBreakpointsToolStripButton,
            this.toolStripSeparator1,
            this.startDebuggingToolStripButton,
            this.stopDebuggingToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(10, 10);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(780, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toggleBreakpointToolStripButton
            // 
            this.toggleBreakpointToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconBreakpoint16;
            this.toggleBreakpointToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleBreakpointToolStripButton.Name = "toggleBreakpointToolStripButton";
            this.toggleBreakpointToolStripButton.Size = new System.Drawing.Size(122, 22);
            this.toggleBreakpointToolStripButton.Text = "Toggle Breakpoint";
            this.toggleBreakpointToolStripButton.Click += new System.EventHandler(this.OnToggleBreakpointToolStripButtonClick);
            // 
            // toggleBreakpointEnabledToolStripButton
            // 
            this.toggleBreakpointEnabledToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconBreakpointToggleEnabled16;
            this.toggleBreakpointEnabledToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleBreakpointEnabledToolStripButton.Name = "toggleBreakpointEnabledToolStripButton";
            this.toggleBreakpointEnabledToolStripButton.Size = new System.Drawing.Size(107, 22);
            this.toggleBreakpointEnabledToolStripButton.Text = "Toggle Enabled";
            this.toggleBreakpointEnabledToolStripButton.Click += new System.EventHandler(this.OnToggleBreakpointEnabledToolStripButtonClick);
            // 
            // clearBreakpointsToolStripButton
            // 
            this.clearBreakpointsToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconDelete16;
            this.clearBreakpointsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBreakpointsToolStripButton.Name = "clearBreakpointsToolStripButton";
            this.clearBreakpointsToolStripButton.Size = new System.Drawing.Size(119, 22);
            this.clearBreakpointsToolStripButton.Text = "Clear Breakpoints";
            this.clearBreakpointsToolStripButton.Click += new System.EventHandler(this.OnClearBreakpointsToolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // startDebuggingToolStripButton
            // 
            this.startDebuggingToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconPlay16;
            this.startDebuggingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startDebuggingToolStripButton.Name = "startDebuggingToolStripButton";
            this.startDebuggingToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.startDebuggingToolStripButton.Text = "Run";
            this.startDebuggingToolStripButton.Click += new System.EventHandler(this.OnStartDebuggingToolStripButtonClick);
            // 
            // stopDebuggingToolStripButton
            // 
            this.stopDebuggingToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconStop16;
            this.stopDebuggingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopDebuggingToolStripButton.Name = "stopDebuggingToolStripButton";
            this.stopDebuggingToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.stopDebuggingToolStripButton.Text = "Stop";
            this.stopDebuggingToolStripButton.Click += new System.EventHandler(this.OnStopDebuggingToolStripButtonClick);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentPanel);
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
		private System.Windows.Forms.ToolStripButton toggleBreakpointToolStripButton;
		private System.Windows.Forms.ToolStripButton toggleBreakpointEnabledToolStripButton;
		private System.Windows.Forms.ToolStripButton clearBreakpointsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton startDebuggingToolStripButton;
		private System.Windows.Forms.ToolStripButton stopDebuggingToolStripButton;
	}
}
