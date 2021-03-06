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
			this.contentPanel = new System.Windows.Forms.Panel();
			this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.formatSelectionButton = new System.Windows.Forms.Button();
			this.formatDocumentButton = new System.Windows.Forms.Button();
			this.elementSpacingModeComboBox = new System.Windows.Forms.ComboBox();
			this.elementSpacingModeLabel = new System.Windows.Forms.Label();
			this.attributeSpacingModeComboBox = new System.Windows.Forms.ComboBox();
			this.attributeSpacingModeLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tagWrapLengthTextBox = new System.Windows.Forms.TextBox();
			this.contentPanel.SuspendLayout();
			this.headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// contentPanel
			// 
			this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contentPanel.Controls.Add(this.editor);
			this.contentPanel.Controls.Add(this.headerPanel);
			this.contentPanel.Location = new System.Drawing.Point(10, 10);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(780, 580);
			this.contentPanel.TabIndex = 1;
			// 
			// editor
			// 
			this.editor.AllowDrop = true;
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.Location = new System.Drawing.Point(0, 92);
			this.editor.Name = "editor";
			this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.editor.Size = new System.Drawing.Size(780, 488);
			this.editor.TabIndex = 10;
			this.editor.Text = resources.GetString("editor.Text");
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.tagWrapLengthTextBox);
			this.headerPanel.Controls.Add(this.label1);
			this.headerPanel.Controls.Add(this.formatSelectionButton);
			this.headerPanel.Controls.Add(this.formatDocumentButton);
			this.headerPanel.Controls.Add(this.elementSpacingModeComboBox);
			this.headerPanel.Controls.Add(this.elementSpacingModeLabel);
			this.headerPanel.Controls.Add(this.attributeSpacingModeComboBox);
			this.headerPanel.Controls.Add(this.attributeSpacingModeLabel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.headerPanel.Size = new System.Drawing.Size(780, 92);
			this.headerPanel.TabIndex = 3;
			// 
			// formatSelectionButton
			// 
			this.formatSelectionButton.Location = new System.Drawing.Point(224, 55);
			this.formatSelectionButton.Name = "formatSelectionButton";
			this.formatSelectionButton.Size = new System.Drawing.Size(200, 25);
			this.formatSelectionButton.TabIndex = 5;
			this.formatSelectionButton.Text = "Format Selection";
			this.formatSelectionButton.UseVisualStyleBackColor = true;
			this.formatSelectionButton.Click += new System.EventHandler(this.OnFormatSelectionButtonClick);
			// 
			// formatDocumentButton
			// 
			this.formatDocumentButton.AutoSize = true;
			this.formatDocumentButton.Location = new System.Drawing.Point(0, 55);
			this.formatDocumentButton.Name = "formatDocumentButton";
			this.formatDocumentButton.Size = new System.Drawing.Size(200, 25);
			this.formatDocumentButton.TabIndex = 4;
			this.formatDocumentButton.Text = "Format Document";
			this.formatDocumentButton.UseVisualStyleBackColor = true;
			this.formatDocumentButton.Click += new System.EventHandler(this.OnFormatDocumentButtonClick);
			// 
			// elementSpacingModeComboBox
			// 
			this.elementSpacingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.elementSpacingModeComboBox.FormattingEnabled = true;
			this.elementSpacingModeComboBox.Location = new System.Drawing.Point(224, 22);
			this.elementSpacingModeComboBox.Name = "elementSpacingModeComboBox";
			this.elementSpacingModeComboBox.Size = new System.Drawing.Size(200, 23);
			this.elementSpacingModeComboBox.TabIndex = 1;
			this.elementSpacingModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnUpdateTextFormatter);
			// 
			// elementSpacingModeLabel
			// 
			this.elementSpacingModeLabel.AutoSize = true;
			this.elementSpacingModeLabel.Location = new System.Drawing.Point(224, 0);
			this.elementSpacingModeLabel.Name = "elementSpacingModeLabel";
			this.elementSpacingModeLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.elementSpacingModeLabel.Size = new System.Drawing.Size(132, 19);
			this.elementSpacingModeLabel.TabIndex = 2;
			this.elementSpacingModeLabel.Text = "Element Spacing Mode:";
			// 
			// attributeSpacingModeComboBox
			// 
			this.attributeSpacingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.attributeSpacingModeComboBox.FormattingEnabled = true;
			this.attributeSpacingModeComboBox.Location = new System.Drawing.Point(0, 22);
			this.attributeSpacingModeComboBox.Name = "attributeSpacingModeComboBox";
			this.attributeSpacingModeComboBox.Size = new System.Drawing.Size(200, 23);
			this.attributeSpacingModeComboBox.TabIndex = 0;
			this.attributeSpacingModeComboBox.SelectedValueChanged += new System.EventHandler(this.OnUpdateTextFormatter);
			// 
			// attributeSpacingModeLabel
			// 
			this.attributeSpacingModeLabel.AutoSize = true;
			this.attributeSpacingModeLabel.Location = new System.Drawing.Point(0, 0);
			this.attributeSpacingModeLabel.Name = "attributeSpacingModeLabel";
			this.attributeSpacingModeLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.attributeSpacingModeLabel.Size = new System.Drawing.Size(136, 19);
			this.attributeSpacingModeLabel.TabIndex = 0;
			this.attributeSpacingModeLabel.Text = "Attribute Spacing Mode:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(446, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.label1.Size = new System.Drawing.Size(99, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tag Wrap Length:";
			// 
			// tagWrapLengthTextBox
			// 
			this.tagWrapLengthTextBox.Location = new System.Drawing.Point(449, 22);
			this.tagWrapLengthTextBox.Name = "tagWrapLengthTextBox";
			this.tagWrapLengthTextBox.Size = new System.Drawing.Size(100, 23);
			this.tagWrapLengthTextBox.TabIndex = 2;
			this.tagWrapLengthTextBox.Text = "100";
			this.tagWrapLengthTextBox.TextChanged += new System.EventHandler(this.OnUpdateTextFormatter);
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
			this.headerPanel.ResumeLayout(false);
			this.headerPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.ComboBox attributeSpacingModeComboBox;
		private System.Windows.Forms.Label attributeSpacingModeLabel;
		private System.Windows.Forms.ComboBox elementSpacingModeComboBox;
		private System.Windows.Forms.Label elementSpacingModeLabel;
		private System.Windows.Forms.Button formatSelectionButton;
		private System.Windows.Forms.Button formatDocumentButton;
		private System.Windows.Forms.TextBox tagWrapLengthTextBox;
		private System.Windows.Forms.Label label1;
	}
}
