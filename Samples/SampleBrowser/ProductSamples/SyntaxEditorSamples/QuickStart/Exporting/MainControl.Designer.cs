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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.upperPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.instanceLabel = new System.Windows.Forms.Label();
            this.upperHeaderPanel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.exporterComboBox = new System.Windows.Forms.ComboBox();
            this.exporterLabel = new System.Windows.Forms.Label();
            this.horizontalSpacerPanel = new System.Windows.Forms.Panel();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.lowerLeftPanel = new System.Windows.Forms.Panel();
            this.exportEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.exportedLabel = new System.Windows.Forms.Label();
            this.verticalSpacerPanel = new System.Windows.Forms.Panel();
            this.lowerRightPanel = new System.Windows.Forms.Panel();
            this.previewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.rtfPreviewLabel = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.upperHeaderPanel.SuspendLayout();
            this.lowerPanel.SuspendLayout();
            this.lowerLeftPanel.SuspendLayout();
            this.lowerRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.upperPanel);
            this.contentPanel.Controls.Add(this.horizontalSpacerPanel);
            this.contentPanel.Controls.Add(this.lowerPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // upperPanel
            // 
            this.upperPanel.Controls.Add(this.editor);
            this.upperPanel.Controls.Add(this.instanceLabel);
            this.upperPanel.Controls.Add(this.upperHeaderPanel);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(780, 285);
            this.upperPanel.TabIndex = 6;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 51);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 234);
            this.editor.TabIndex = 2;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // instanceLabel
            // 
            this.instanceLabel.AutoSize = true;
            this.instanceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.instanceLabel.Location = new System.Drawing.Point(0, 33);
            this.instanceLabel.Name = "instanceLabel";
            this.instanceLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.instanceLabel.Size = new System.Drawing.Size(120, 18);
            this.instanceLabel.TabIndex = 4;
            this.instanceLabel.Text = "SyntaxEditor Instance";
            // 
            // upperHeaderPanel
            // 
            this.upperHeaderPanel.Controls.Add(this.exportButton);
            this.upperHeaderPanel.Controls.Add(this.exporterComboBox);
            this.upperHeaderPanel.Controls.Add(this.exporterLabel);
            this.upperHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.upperHeaderPanel.Name = "upperHeaderPanel";
            this.upperHeaderPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.upperHeaderPanel.Size = new System.Drawing.Size(780, 33);
            this.upperHeaderPanel.TabIndex = 3;
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.exportButton.Location = new System.Drawing.Point(271, 0);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.OnExportButtonClick);
            // 
            // exporterComboBox
            // 
            this.exporterComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.exporterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exporterComboBox.FormattingEnabled = true;
            this.exporterComboBox.Items.AddRange(new object[] {
            "RTF (Rich Text Format)",
            "HTML (Class-Based Styling)",
            "HTML (Inline Styling)",
            "HTML (Fragment w/Inline Styling)"});
            this.exporterComboBox.Location = new System.Drawing.Point(56, 0);
            this.exporterComboBox.Name = "exporterComboBox";
            this.exporterComboBox.Size = new System.Drawing.Size(215, 23);
            this.exporterComboBox.TabIndex = 1;
            // 
            // exporterLabel
            // 
            this.exporterLabel.AutoSize = true;
            this.exporterLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.exporterLabel.Location = new System.Drawing.Point(0, 0);
            this.exporterLabel.Name = "exporterLabel";
            this.exporterLabel.Padding = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.exporterLabel.Size = new System.Drawing.Size(56, 19);
            this.exporterLabel.TabIndex = 0;
            this.exporterLabel.Text = "Exporter";
            // 
            // horizontalSpacerPanel
            // 
            this.horizontalSpacerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalSpacerPanel.Location = new System.Drawing.Point(0, 285);
            this.horizontalSpacerPanel.Name = "horizontalSpacerPanel";
            this.horizontalSpacerPanel.Size = new System.Drawing.Size(780, 10);
            this.horizontalSpacerPanel.TabIndex = 4;
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.lowerLeftPanel);
            this.lowerPanel.Controls.Add(this.verticalSpacerPanel);
            this.lowerPanel.Controls.Add(this.lowerRightPanel);
            this.lowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerPanel.Location = new System.Drawing.Point(0, 295);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(780, 285);
            this.lowerPanel.TabIndex = 7;
            // 
            // lowerLeftPanel
            // 
            this.lowerLeftPanel.Controls.Add(this.exportEditor);
            this.lowerLeftPanel.Controls.Add(this.exportedLabel);
            this.lowerLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lowerLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.lowerLeftPanel.Name = "lowerLeftPanel";
            this.lowerLeftPanel.Size = new System.Drawing.Size(385, 285);
            this.lowerLeftPanel.TabIndex = 0;
            // 
            // exportEditor
            // 
            this.exportEditor.AllowDrop = true;
            this.exportEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportEditor.Document.IsReadOnly = true;
            this.exportEditor.Location = new System.Drawing.Point(0, 18);
            this.exportEditor.Name = "exportEditor";
            this.exportEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.exportEditor.Size = new System.Drawing.Size(385, 267);
            this.exportEditor.TabIndex = 3;
            // 
            // exportedLabel
            // 
            this.exportedLabel.AutoSize = true;
            this.exportedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.exportedLabel.Location = new System.Drawing.Point(0, 0);
            this.exportedLabel.Name = "exportedLabel";
            this.exportedLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.exportedLabel.Size = new System.Drawing.Size(98, 18);
            this.exportedLabel.TabIndex = 5;
            this.exportedLabel.Text = "Exported Markup";
            // 
            // verticalSpacerPanel
            // 
            this.verticalSpacerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.verticalSpacerPanel.Location = new System.Drawing.Point(385, 0);
            this.verticalSpacerPanel.Name = "verticalSpacerPanel";
            this.verticalSpacerPanel.Size = new System.Drawing.Size(10, 285);
            this.verticalSpacerPanel.TabIndex = 5;
            // 
            // lowerRightPanel
            // 
            this.lowerRightPanel.Controls.Add(this.previewRichTextBox);
            this.lowerRightPanel.Controls.Add(this.rtfPreviewLabel);
            this.lowerRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lowerRightPanel.Location = new System.Drawing.Point(395, 0);
            this.lowerRightPanel.Name = "lowerRightPanel";
            this.lowerRightPanel.Size = new System.Drawing.Size(385, 285);
            this.lowerRightPanel.TabIndex = 1;
            // 
            // previewRichTextBox
            // 
            this.previewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewRichTextBox.Location = new System.Drawing.Point(0, 18);
            this.previewRichTextBox.Name = "previewRichTextBox";
            this.previewRichTextBox.ReadOnly = true;
            this.previewRichTextBox.Size = new System.Drawing.Size(385, 267);
            this.previewRichTextBox.TabIndex = 0;
            this.previewRichTextBox.Text = "";
            // 
            // rtfPreviewLabel
            // 
            this.rtfPreviewLabel.AutoSize = true;
            this.rtfPreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtfPreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.rtfPreviewLabel.Name = "rtfPreviewLabel";
            this.rtfPreviewLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.rtfPreviewLabel.Size = new System.Drawing.Size(69, 18);
            this.rtfPreviewLabel.TabIndex = 6;
            this.rtfPreviewLabel.Text = "RTF Preview";
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
            this.upperHeaderPanel.ResumeLayout(false);
            this.upperHeaderPanel.PerformLayout();
            this.lowerPanel.ResumeLayout(false);
            this.lowerLeftPanel.ResumeLayout(false);
            this.lowerLeftPanel.PerformLayout();
            this.lowerRightPanel.ResumeLayout(false);
            this.lowerRightPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Panel horizontalSpacerPanel;
		private System.Windows.Forms.Panel upperPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel upperHeaderPanel;
		private System.Windows.Forms.Panel lowerPanel;
		private System.Windows.Forms.Panel lowerLeftPanel;
		private System.Windows.Forms.Panel verticalSpacerPanel;
		private System.Windows.Forms.Panel lowerRightPanel;
		private System.Windows.Forms.ComboBox exporterComboBox;
		private System.Windows.Forms.Label exporterLabel;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Label instanceLabel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor exportEditor;
		private System.Windows.Forms.Label exportedLabel;
		private System.Windows.Forms.Label rtfPreviewLabel;
		private System.Windows.Forms.RichTextBox previewRichTextBox;
	}
}
