namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.MacroRecording {
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.runRecordedMacroToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.recordMacroToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pauseRecordingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancelRecordingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainToolStrip.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 38);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(774, 526);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            this.editor.MacroRecordingStateChanged += new System.EventHandler(this.OnSyntaxEditorMacroRecordingStateChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Location = new System.Drawing.Point(13, 567);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(774, 23);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Ready";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runRecordedMacroToolStripButton,
            this.recordMacroToolStripButton,
            this.pauseRecordingToolStripButton,
            this.cancelRecordingToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(10, 10);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(780, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // runRecordedMacroToolStripButton
            // 
            this.runRecordedMacroToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconMacroRecordingRun16;
            this.runRecordedMacroToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runRecordedMacroToolStripButton.Name = "runRecordedMacroToolStripButton";
            this.runRecordedMacroToolStripButton.Size = new System.Drawing.Size(138, 22);
            this.runRecordedMacroToolStripButton.Text = "Run Recorded Macro";
            this.runRecordedMacroToolStripButton.Click += new System.EventHandler(this.OnRunRecordedMacroToolStripButtonClick);
            // 
            // recordMacroToolStripButton
            // 
            this.recordMacroToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconMacroRecordingRecord16;
            this.recordMacroToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recordMacroToolStripButton.Name = "recordMacroToolStripButton";
            this.recordMacroToolStripButton.Size = new System.Drawing.Size(101, 22);
            this.recordMacroToolStripButton.Text = "Record Macro";
            this.recordMacroToolStripButton.Click += new System.EventHandler(this.OnRecordMacroToolStripButtonClick);
            // 
            // pauseRecordingToolStripButton
            // 
            this.pauseRecordingToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconMacroRecordingPause16;
            this.pauseRecordingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseRecordingToolStripButton.Name = "pauseRecordingToolStripButton";
            this.pauseRecordingToolStripButton.Size = new System.Drawing.Size(115, 22);
            this.pauseRecordingToolStripButton.Text = "Pause Recording";
            this.pauseRecordingToolStripButton.Click += new System.EventHandler(this.OnPauseRecordingToolStripButtonClick);
            // 
            // cancelRecordingToolStripButton
            // 
            this.cancelRecordingToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconMacroRecordingCancel16;
            this.cancelRecordingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelRecordingToolStripButton.Name = "cancelRecordingToolStripButton";
            this.cancelRecordingToolStripButton.Size = new System.Drawing.Size(120, 22);
            this.cancelRecordingToolStripButton.Text = "Cancel Recording";
            this.cancelRecordingToolStripButton.Click += new System.EventHandler(this.OnCancelRecordingToolStripButtonClick);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.mainToolStrip, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.statusLabel, 0, 2);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 3;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.ToolStripButton runRecordedMacroToolStripButton;
		private System.Windows.Forms.ToolStripButton recordMacroToolStripButton;
		private System.Windows.Forms.ToolStripButton pauseRecordingToolStripButton;
		private System.Windows.Forms.ToolStripButton cancelRecordingToolStripButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
