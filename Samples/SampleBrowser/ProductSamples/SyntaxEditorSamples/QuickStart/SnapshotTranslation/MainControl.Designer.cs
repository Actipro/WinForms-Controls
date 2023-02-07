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
            this.topEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.topEditorLabel = new System.Windows.Forms.Label();
            this.heading3Label = new System.Windows.Forms.Label();
            this.heading2Label = new System.Windows.Forms.Label();
            this.heading1Label = new System.Windows.Forms.Label();
            this.bottomEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.bottomEditorLabel = new System.Windows.Forms.Label();
            this.updateSelectionButton = new System.Windows.Forms.Button();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topEditor
            // 
            this.topEditor.AllowDrop = true;
            this.topEditor.AreWordWrapGlyphsVisible = true;
            this.topEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topEditor.Document.IsReadOnly = true;
            this.topEditor.IsLineNumberMarginVisible = true;
            this.topEditor.Location = new System.Drawing.Point(13, 158);
            this.topEditor.Name = "topEditor";
            this.topEditor.OverrideCursor = null;
            this.topEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.topEditor.Size = new System.Drawing.Size(774, 175);
            this.topEditor.TabIndex = 3;
            this.topEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // topEditorLabel
            // 
            this.topEditorLabel.AutoSize = true;
            this.topEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topEditorLabel.Location = new System.Drawing.Point(13, 125);
            this.topEditorLabel.Name = "topEditorLabel";
            this.topEditorLabel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 3);
            this.topEditorLabel.Size = new System.Drawing.Size(774, 30);
            this.topEditorLabel.TabIndex = 7;
            this.topEditorLabel.Text = "Original Snapshot:";
            // 
            // heading3Label
            // 
            this.heading3Label.AutoSize = true;
            this.heading3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading3Label.Location = new System.Drawing.Point(13, 74);
            this.heading3Label.Name = "heading3Label";
            this.heading3Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading3Label.Size = new System.Drawing.Size(774, 51);
            this.heading3Label.TabIndex = 6;
            this.heading3Label.Text = resources.GetString("heading3Label.Text");
            // 
            // heading2Label
            // 
            this.heading2Label.AutoSize = true;
            this.heading2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading2Label.Location = new System.Drawing.Point(13, 36);
            this.heading2Label.Name = "heading2Label";
            this.heading2Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading2Label.Size = new System.Drawing.Size(774, 38);
            this.heading2Label.TabIndex = 5;
            this.heading2Label.Text = resources.GetString("heading2Label.Text");
            // 
            // heading1Label
            // 
            this.heading1Label.AutoSize = true;
            this.heading1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading1Label.Location = new System.Drawing.Point(13, 10);
            this.heading1Label.Name = "heading1Label";
            this.heading1Label.Size = new System.Drawing.Size(774, 26);
            this.heading1Label.TabIndex = 4;
            this.heading1Label.Text = resources.GetString("heading1Label.Text");
            // 
            // bottomEditor
            // 
            this.bottomEditor.AllowDrop = true;
            this.bottomEditor.AreWordWrapGlyphsVisible = true;
            this.bottomEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomEditor.IsLineNumberMarginVisible = true;
            this.bottomEditor.Location = new System.Drawing.Point(13, 412);
            this.bottomEditor.Name = "bottomEditor";
            this.bottomEditor.OverrideCursor = null;
            this.bottomEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.bottomEditor.Size = new System.Drawing.Size(774, 175);
            this.bottomEditor.TabIndex = 2;
            this.bottomEditor.Text = resources.GetString("bottomEditor.Text");
            this.bottomEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // bottomEditorLabel
            // 
            this.bottomEditorLabel.AutoSize = true;
            this.bottomEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomEditorLabel.Location = new System.Drawing.Point(13, 391);
            this.bottomEditorLabel.Name = "bottomEditorLabel";
            this.bottomEditorLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.bottomEditorLabel.Size = new System.Drawing.Size(774, 18);
            this.bottomEditorLabel.TabIndex = 8;
            this.bottomEditorLabel.Text = "Current Snapshot:";
            // 
            // updateSelectionButton
            // 
            this.updateSelectionButton.AutoSize = true;
            this.updateSelectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateSelectionButton.Location = new System.Drawing.Point(13, 349);
            this.updateSelectionButton.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.updateSelectionButton.Name = "updateSelectionButton";
            this.updateSelectionButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.updateSelectionButton.Size = new System.Drawing.Size(774, 29);
            this.updateSelectionButton.TabIndex = 6;
            this.updateSelectionButton.Text = "Translate Selection";
            this.updateSelectionButton.UseVisualStyleBackColor = true;
            this.updateSelectionButton.Click += new System.EventHandler(this.OnUpdateSelectionButtonClick);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.heading1Label, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.heading2Label, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.heading3Label, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.topEditorLabel, 0, 3);
            this.contentTableLayoutPanel.Controls.Add(this.topEditor, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.updateSelectionButton, 0, 5);
            this.contentTableLayoutPanel.Controls.Add(this.bottomEditorLabel, 0, 6);
            this.contentTableLayoutPanel.Controls.Add(this.bottomEditor, 0, 7);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 8;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor bottomEditor;
		private System.Windows.Forms.Button updateSelectionButton;
		private System.Windows.Forms.Label heading3Label;
		private System.Windows.Forms.Label heading2Label;
		private System.Windows.Forms.Label heading1Label;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor topEditor;
		private System.Windows.Forms.Label topEditorLabel;
		private System.Windows.Forms.Label bottomEditorLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
