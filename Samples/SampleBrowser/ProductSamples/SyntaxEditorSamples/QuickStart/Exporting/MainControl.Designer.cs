namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.Exporting {
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
            this.instanceLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.exporterComboBox = new System.Windows.Forms.ComboBox();
            this.exporterLabel = new System.Windows.Forms.Label();
            this.exportEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.exportedLabel = new System.Windows.Forms.Label();
            this.previewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.rtfPreviewLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 75);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 242);
            this.editor.TabIndex = 2;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // instanceLabel
            // 
            this.instanceLabel.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.instanceLabel, 2);
            this.instanceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instanceLabel.Location = new System.Drawing.Point(13, 51);
            this.instanceLabel.Name = "instanceLabel";
            this.instanceLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.instanceLabel.Size = new System.Drawing.Size(774, 21);
            this.instanceLabel.TabIndex = 4;
            this.instanceLabel.Text = "SyntaxEditor Instance";
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportButton.Location = new System.Drawing.Point(704, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.exportButton.Size = new System.Drawing.Size(67, 29);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // exporterComboBox
            // 
            this.exporterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exporterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exporterComboBox.FormattingEnabled = true;
            this.exporterComboBox.Items.AddRange(new object[] {
            "RTF (Rich Text Format)",
            "HTML (Class-Based Styling)",
            "HTML (Inline Styling)",
            "HTML (Fragment w/Inline Styling)"});
            this.exporterComboBox.Location = new System.Drawing.Point(55, 7);
            this.exporterComboBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.exporterComboBox.Name = "exporterComboBox";
            this.exporterComboBox.Size = new System.Drawing.Size(643, 21);
            this.exporterComboBox.TabIndex = 1;
            // 
            // exporterLabel
            // 
            this.exporterLabel.AutoSize = true;
            this.exporterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exporterLabel.Location = new System.Drawing.Point(3, 0);
            this.exporterLabel.Name = "exporterLabel";
            this.exporterLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.exporterLabel.Size = new System.Drawing.Size(46, 35);
            this.exporterLabel.TabIndex = 0;
            this.exporterLabel.Text = "Exporter";
            // 
            // exportEditor
            // 
            this.exportEditor.AllowDrop = true;
            this.exportEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportEditor.Document.IsReadOnly = true;
            this.exportEditor.Location = new System.Drawing.Point(13, 344);
            this.exportEditor.Name = "exportEditor";
            this.exportEditor.OverrideCursor = null;
            this.exportEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.exportEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.exportEditor.Size = new System.Drawing.Size(384, 243);
            this.exportEditor.TabIndex = 3;
            // 
            // exportedLabel
            // 
            this.exportedLabel.AutoSize = true;
            this.exportedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportedLabel.Location = new System.Drawing.Point(13, 320);
            this.exportedLabel.Name = "exportedLabel";
            this.exportedLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.exportedLabel.Size = new System.Drawing.Size(384, 21);
            this.exportedLabel.TabIndex = 5;
            this.exportedLabel.Text = "Exported Markup";
            // 
            // previewRichTextBox
            // 
            this.previewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewRichTextBox.Location = new System.Drawing.Point(403, 344);
            this.previewRichTextBox.Name = "previewRichTextBox";
            this.previewRichTextBox.ReadOnly = true;
            this.previewRichTextBox.Size = new System.Drawing.Size(384, 243);
            this.previewRichTextBox.TabIndex = 0;
            this.previewRichTextBox.Text = "";
            // 
            // rtfPreviewLabel
            // 
            this.rtfPreviewLabel.AutoSize = true;
            this.rtfPreviewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfPreviewLabel.Location = new System.Drawing.Point(403, 320);
            this.rtfPreviewLabel.Name = "rtfPreviewLabel";
            this.rtfPreviewLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.rtfPreviewLabel.Size = new System.Drawing.Size(384, 21);
            this.rtfPreviewLabel.TabIndex = 6;
            this.rtfPreviewLabel.Text = "RTF Preview";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.headerTableLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.exportEditor, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.instanceLabel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.rtfPreviewLabel, 1, 3);
            this.contentTableLayoutPanel.Controls.Add(this.previewRichTextBox, 1, 4);
            this.contentTableLayoutPanel.Controls.Add(this.exportedLabel, 0, 3);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 5;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // headerTableLayoutPanel
            // 
            this.headerTableLayoutPanel.AutoSize = true;
            this.headerTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerTableLayoutPanel.ColumnCount = 3;
            this.contentTableLayoutPanel.SetColumnSpan(this.headerTableLayoutPanel, 2);
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.Controls.Add(this.exportButton, 2, 0);
            this.headerTableLayoutPanel.Controls.Add(this.exporterComboBox, 1, 0);
            this.headerTableLayoutPanel.Controls.Add(this.exporterLabel, 0, 0);
            this.headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTableLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            this.headerTableLayoutPanel.RowCount = 1;
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.Size = new System.Drawing.Size(774, 35);
            this.headerTableLayoutPanel.TabIndex = 3;
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
            this.headerTableLayoutPanel.ResumeLayout(false);
            this.headerTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ComboBox exporterComboBox;
		private System.Windows.Forms.Label exporterLabel;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Label instanceLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor exportEditor;
		private System.Windows.Forms.Label exportedLabel;
		private System.Windows.Forms.Label rtfPreviewLabel;
		private System.Windows.Forms.RichTextBox previewRichTextBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
	}
}
