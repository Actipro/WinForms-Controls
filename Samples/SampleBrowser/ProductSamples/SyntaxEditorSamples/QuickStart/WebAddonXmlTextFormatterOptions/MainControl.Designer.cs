namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WebAddonXmlTextFormatterOptions {
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
            this.tagWrapLengthTextBox = new System.Windows.Forms.TextBox();
            this.tagWrapLengthLabel = new System.Windows.Forms.Label();
            this.formatSelectionButton = new System.Windows.Forms.Button();
            this.formatDocumentButton = new System.Windows.Forms.Button();
            this.elementSpacingModeComboBox = new System.Windows.Forms.ComboBox();
            this.elementSpacingModeLabel = new System.Windows.Forms.Label();
            this.attributeSpacingModeComboBox = new System.Windows.Forms.ComboBox();
            this.attributeSpacingModeLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.attributeSpacingModeComboBoxPanel = new System.Windows.Forms.Panel();
            this.elementSpacingModeComboBoxPanel = new System.Windows.Forms.Panel();
            this.tagWrapLengthTextBoxPanel = new System.Windows.Forms.Panel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.attributeSpacingModeComboBoxPanel.SuspendLayout();
            this.elementSpacingModeComboBoxPanel.SuspendLayout();
            this.tagWrapLengthTextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 6);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 115);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 472);
            this.editor.TabIndex = 10;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // tagWrapLengthTextBox
            // 
            this.tagWrapLengthTextBox.Location = new System.Drawing.Point(0, 0);
            this.tagWrapLengthTextBox.Name = "tagWrapLengthTextBox";
            this.tagWrapLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.tagWrapLengthTextBox.TabIndex = 2;
            this.tagWrapLengthTextBox.Text = "100";
            this.tagWrapLengthTextBox.TextChanged += new System.EventHandler(this.OnUpdateTextFormatter);
            // 
            // tagWrapLengthLabel
            // 
            this.tagWrapLengthLabel.AutoSize = true;
            this.tagWrapLengthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagWrapLengthLabel.Location = new System.Drawing.Point(451, 10);
            this.tagWrapLengthLabel.Name = "tagWrapLengthLabel";
            this.tagWrapLengthLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.tagWrapLengthLabel.Size = new System.Drawing.Size(103, 17);
            this.tagWrapLengthLabel.TabIndex = 6;
            this.tagWrapLengthLabel.Text = "Tag Wrap Length:";
            // 
            // formatSelectionButton
            // 
            this.formatSelectionButton.AutoSize = true;
            this.formatSelectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formatSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatSelectionButton.Location = new System.Drawing.Point(232, 70);
            this.formatSelectionButton.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.formatSelectionButton.Name = "formatSelectionButton";
            this.formatSelectionButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.formatSelectionButton.Size = new System.Drawing.Size(203, 29);
            this.formatSelectionButton.TabIndex = 5;
            this.formatSelectionButton.Text = "Format Selection";
            this.formatSelectionButton.UseVisualStyleBackColor = true;
            this.formatSelectionButton.Click += new System.EventHandler(this.OnFormatSelectionButtonClick);
            // 
            // formatDocumentButton
            // 
            this.formatDocumentButton.AutoSize = true;
            this.formatDocumentButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formatDocumentButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatDocumentButton.Location = new System.Drawing.Point(13, 70);
            this.formatDocumentButton.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.formatDocumentButton.Name = "formatDocumentButton";
            this.formatDocumentButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.formatDocumentButton.Size = new System.Drawing.Size(203, 29);
            this.formatDocumentButton.TabIndex = 4;
            this.formatDocumentButton.Text = "Format Document";
            this.formatDocumentButton.UseVisualStyleBackColor = true;
            this.formatDocumentButton.Click += new System.EventHandler(this.OnFormatDocumentButtonClick);
            // 
            // elementSpacingModeComboBox
            // 
            this.elementSpacingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementSpacingModeComboBox.FormattingEnabled = true;
            this.elementSpacingModeComboBox.Location = new System.Drawing.Point(0, 0);
            this.elementSpacingModeComboBox.Name = "elementSpacingModeComboBox";
            this.elementSpacingModeComboBox.Size = new System.Drawing.Size(200, 21);
            this.elementSpacingModeComboBox.TabIndex = 1;
            this.elementSpacingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnUpdateTextFormatter);
            // 
            // elementSpacingModeLabel
            // 
            this.elementSpacingModeLabel.AutoSize = true;
            this.elementSpacingModeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementSpacingModeLabel.Location = new System.Drawing.Point(232, 10);
            this.elementSpacingModeLabel.Name = "elementSpacingModeLabel";
            this.elementSpacingModeLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.elementSpacingModeLabel.Size = new System.Drawing.Size(203, 17);
            this.elementSpacingModeLabel.TabIndex = 2;
            this.elementSpacingModeLabel.Text = "Element Spacing Mode:";
            // 
            // attributeSpacingModeComboBox
            // 
            this.attributeSpacingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attributeSpacingModeComboBox.FormattingEnabled = true;
            this.attributeSpacingModeComboBox.Location = new System.Drawing.Point(0, 0);
            this.attributeSpacingModeComboBox.Name = "attributeSpacingModeComboBox";
            this.attributeSpacingModeComboBox.Size = new System.Drawing.Size(200, 21);
            this.attributeSpacingModeComboBox.TabIndex = 0;
            this.attributeSpacingModeComboBox.SelectedValueChanged += new System.EventHandler(this.OnUpdateTextFormatter);
            // 
            // attributeSpacingModeLabel
            // 
            this.attributeSpacingModeLabel.AutoSize = true;
            this.attributeSpacingModeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeSpacingModeLabel.Location = new System.Drawing.Point(13, 10);
            this.attributeSpacingModeLabel.Name = "attributeSpacingModeLabel";
            this.attributeSpacingModeLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.attributeSpacingModeLabel.Size = new System.Drawing.Size(203, 17);
            this.attributeSpacingModeLabel.TabIndex = 0;
            this.attributeSpacingModeLabel.Text = "Attribute Spacing Mode:";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 6;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.tagWrapLengthTextBoxPanel, 4, 1);
            this.contentTableLayoutPanel.Controls.Add(this.elementSpacingModeComboBoxPanel, 2, 1);
            this.contentTableLayoutPanel.Controls.Add(this.attributeSpacingModeComboBoxPanel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 3);
            this.contentTableLayoutPanel.Controls.Add(this.tagWrapLengthLabel, 4, 0);
            this.contentTableLayoutPanel.Controls.Add(this.formatDocumentButton, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.formatSelectionButton, 2, 2);
            this.contentTableLayoutPanel.Controls.Add(this.elementSpacingModeLabel, 2, 0);
            this.contentTableLayoutPanel.Controls.Add(this.attributeSpacingModeLabel, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 4;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // attributeSpacingModeComboBoxPanel
            // 
            this.attributeSpacingModeComboBoxPanel.AutoSize = true;
            this.attributeSpacingModeComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attributeSpacingModeComboBoxPanel.Controls.Add(this.attributeSpacingModeComboBox);
            this.attributeSpacingModeComboBoxPanel.Location = new System.Drawing.Point(13, 30);
            this.attributeSpacingModeComboBoxPanel.Name = "attributeSpacingModeComboBoxPanel";
            this.attributeSpacingModeComboBoxPanel.Size = new System.Drawing.Size(203, 24);
            this.attributeSpacingModeComboBoxPanel.TabIndex = 3;
            // 
            // elementSpacingModeComboBoxPanel
            // 
            this.elementSpacingModeComboBoxPanel.AutoSize = true;
            this.elementSpacingModeComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.elementSpacingModeComboBoxPanel.Controls.Add(this.elementSpacingModeComboBox);
            this.elementSpacingModeComboBoxPanel.Location = new System.Drawing.Point(232, 30);
            this.elementSpacingModeComboBoxPanel.Name = "elementSpacingModeComboBoxPanel";
            this.elementSpacingModeComboBoxPanel.Size = new System.Drawing.Size(203, 24);
            this.elementSpacingModeComboBoxPanel.TabIndex = 3;
            // 
            // tagWrapLengthTextBoxPanel
            // 
            this.tagWrapLengthTextBoxPanel.AutoSize = true;
            this.tagWrapLengthTextBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tagWrapLengthTextBoxPanel.Controls.Add(this.tagWrapLengthTextBox);
            this.tagWrapLengthTextBoxPanel.Location = new System.Drawing.Point(451, 30);
            this.tagWrapLengthTextBoxPanel.Name = "tagWrapLengthTextBoxPanel";
            this.tagWrapLengthTextBoxPanel.Size = new System.Drawing.Size(103, 23);
            this.tagWrapLengthTextBoxPanel.TabIndex = 3;
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
            this.attributeSpacingModeComboBoxPanel.ResumeLayout(false);
            this.elementSpacingModeComboBoxPanel.ResumeLayout(false);
            this.tagWrapLengthTextBoxPanel.ResumeLayout(false);
            this.tagWrapLengthTextBoxPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ComboBox attributeSpacingModeComboBox;
		private System.Windows.Forms.Label attributeSpacingModeLabel;
		private System.Windows.Forms.ComboBox elementSpacingModeComboBox;
		private System.Windows.Forms.Label elementSpacingModeLabel;
		private System.Windows.Forms.Button formatSelectionButton;
		private System.Windows.Forms.Button formatDocumentButton;
		private System.Windows.Forms.TextBox tagWrapLengthTextBox;
		private System.Windows.Forms.Label tagWrapLengthLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.Panel elementSpacingModeComboBoxPanel;
		private System.Windows.Forms.Panel attributeSpacingModeComboBoxPanel;
		private System.Windows.Forms.Panel tagWrapLengthTextBoxPanel;
	}
}
