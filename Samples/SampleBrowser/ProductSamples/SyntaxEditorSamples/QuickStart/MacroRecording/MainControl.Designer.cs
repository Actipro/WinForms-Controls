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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.runRecordedMacroToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.recordMacroToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pauseRecordingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancelRecordingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusLabel = new System.Windows.Forms.Label();
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
            this.contentPanel.Controls.Add(this.statusLabel);
            this.contentPanel.Controls.Add(this.mainToolStrip);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 25);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 530);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            this.editor.MacroRecordingStateChanged += new System.EventHandler(this.OnSyntaxEditorMacroRecordingStateChanged);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runRecordedMacroToolStripButton,
            this.recordMacroToolStripButton,
            this.pauseRecordingToolStripButton,
            this.cancelRecordingToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
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
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.Location = new System.Drawing.Point(0, 555);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(39, 25);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Ready";
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
		private System.Windows.Forms.ToolStripButton runRecordedMacroToolStripButton;
		private System.Windows.Forms.ToolStripButton recordMacroToolStripButton;
		private System.Windows.Forms.ToolStripButton pauseRecordingToolStripButton;
		private System.Windows.Forms.ToolStripButton cancelRecordingToolStripButton;
		private System.Windows.Forms.Label statusLabel;
	}
}
