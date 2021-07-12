namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotTranslation {
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
            this.upperPanel = new System.Windows.Forms.Panel();
            this.topEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.topEditorLabel = new System.Windows.Forms.Label();
            this.heading3Label = new System.Windows.Forms.Label();
            this.heading2Label = new System.Windows.Forms.Label();
            this.heading1Label = new System.Windows.Forms.Label();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.bottomEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.bottomEditorLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.updateSelectionButton = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.lowerPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.upperPanel);
            this.contentPanel.Controls.Add(this.lowerPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // upperPanel
            // 
            this.upperPanel.Controls.Add(this.topEditor);
            this.upperPanel.Controls.Add(this.topEditorLabel);
            this.upperPanel.Controls.Add(this.heading3Label);
            this.upperPanel.Controls.Add(this.heading2Label);
            this.upperPanel.Controls.Add(this.heading1Label);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(780, 295);
            this.upperPanel.TabIndex = 7;
            this.upperPanel.Resize += new System.EventHandler(this.OnUpperPanelResize);
            // 
            // topEditor
            // 
            this.topEditor.AllowDrop = true;
            this.topEditor.AreWordWrapGlyphsVisible = true;
            this.topEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topEditor.Document.IsReadOnly = true;
            this.topEditor.IsLineNumberMarginVisible = true;
            this.topEditor.Location = new System.Drawing.Point(0, 99);
            this.topEditor.Name = "topEditor";
            this.topEditor.Size = new System.Drawing.Size(780, 196);
            this.topEditor.TabIndex = 3;
            this.topEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // topEditorLabel
            // 
            this.topEditorLabel.AutoSize = true;
            this.topEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topEditorLabel.Location = new System.Drawing.Point(0, 69);
            this.topEditorLabel.Name = "topEditorLabel";
            this.topEditorLabel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 3);
            this.topEditorLabel.Size = new System.Drawing.Size(107, 30);
            this.topEditorLabel.TabIndex = 7;
            this.topEditorLabel.Text = "Original Snapshot:";
            // 
            // heading3Label
            // 
            this.heading3Label.AutoSize = true;
            this.heading3Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading3Label.Location = new System.Drawing.Point(0, 42);
            this.heading3Label.Name = "heading3Label";
            this.heading3Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading3Label.Size = new System.Drawing.Size(1797, 27);
            this.heading3Label.TabIndex = 6;
            this.heading3Label.Text = resources.GetString("heading3Label.Text");
            // 
            // heading2Label
            // 
            this.heading2Label.AutoSize = true;
            this.heading2Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading2Label.Location = new System.Drawing.Point(0, 15);
            this.heading2Label.Name = "heading2Label";
            this.heading2Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading2Label.Size = new System.Drawing.Size(1662, 27);
            this.heading2Label.TabIndex = 5;
            this.heading2Label.Text = resources.GetString("heading2Label.Text");
            // 
            // heading1Label
            // 
            this.heading1Label.AutoSize = true;
            this.heading1Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading1Label.Location = new System.Drawing.Point(0, 0);
            this.heading1Label.Name = "heading1Label";
            this.heading1Label.Size = new System.Drawing.Size(1337, 15);
            this.heading1Label.TabIndex = 4;
            this.heading1Label.Text = resources.GetString("heading1Label.Text");
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.bottomEditor);
            this.lowerPanel.Controls.Add(this.bottomEditorLabel);
            this.lowerPanel.Controls.Add(this.buttonPanel);
            this.lowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerPanel.Location = new System.Drawing.Point(0, 295);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(780, 285);
            this.lowerPanel.TabIndex = 6;
            // 
            // bottomEditor
            // 
            this.bottomEditor.AllowDrop = true;
            this.bottomEditor.AreWordWrapGlyphsVisible = true;
            this.bottomEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomEditor.IsLineNumberMarginVisible = true;
            this.bottomEditor.Location = new System.Drawing.Point(0, 66);
            this.bottomEditor.Name = "bottomEditor";
            this.bottomEditor.Size = new System.Drawing.Size(780, 219);
            this.bottomEditor.TabIndex = 2;
            this.bottomEditor.Text = resources.GetString("bottomEditor.Text");
            this.bottomEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // bottomEditorLabel
            // 
            this.bottomEditorLabel.AutoSize = true;
            this.bottomEditorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomEditorLabel.Location = new System.Drawing.Point(0, 48);
            this.bottomEditorLabel.Name = "bottomEditorLabel";
            this.bottomEditorLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.bottomEditorLabel.Size = new System.Drawing.Size(107, 18);
            this.bottomEditorLabel.TabIndex = 8;
            this.bottomEditorLabel.Text = "Current Snapshot:";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.updateSelectionButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.buttonPanel.Size = new System.Drawing.Size(780, 48);
            this.buttonPanel.TabIndex = 6;
            // 
            // updateSelectionButton
            // 
            this.updateSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateSelectionButton.Location = new System.Drawing.Point(0, 10);
            this.updateSelectionButton.Name = "updateSelectionButton";
            this.updateSelectionButton.Size = new System.Drawing.Size(780, 28);
            this.updateSelectionButton.TabIndex = 6;
            this.updateSelectionButton.Text = "Translate Selection";
            this.updateSelectionButton.UseVisualStyleBackColor = true;
            this.updateSelectionButton.Click += new System.EventHandler(this.OnUpdateSelectionButtonClick);
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
            this.upperPanel.ResumeLayout(false);
            this.upperPanel.PerformLayout();
            this.lowerPanel.ResumeLayout(false);
            this.lowerPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Panel lowerPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor bottomEditor;
		private System.Windows.Forms.Panel upperPanel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button updateSelectionButton;
		private System.Windows.Forms.Label heading3Label;
		private System.Windows.Forms.Label heading2Label;
		private System.Windows.Forms.Label heading1Label;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor topEditor;
		private System.Windows.Forms.Label topEditorLabel;
		private System.Windows.Forms.Label bottomEditorLabel;
	}
}
