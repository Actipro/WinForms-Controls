namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WordWrap {
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
            this.areGlyphsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.wordWrapModeComboBox = new System.Windows.Forms.ComboBox();
            this.wordWrapModeLabel = new System.Windows.Forms.Label();
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
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsOutliningMarginVisible = false;
            this.editor.Location = new System.Drawing.Point(0, 31);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 549);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.areGlyphsVisibleCheckBox);
            this.headerPanel.Controls.Add(this.wordWrapModeComboBox);
            this.headerPanel.Controls.Add(this.wordWrapModeLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 31);
            this.headerPanel.TabIndex = 3;
            // 
            // areGlyphsVisibleCheckBox
            // 
            this.areGlyphsVisibleCheckBox.AutoSize = true;
            this.areGlyphsVisibleCheckBox.Checked = true;
            this.areGlyphsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.areGlyphsVisibleCheckBox.Location = new System.Drawing.Point(260, 2);
            this.areGlyphsVisibleCheckBox.Name = "areGlyphsVisibleCheckBox";
            this.areGlyphsVisibleCheckBox.Size = new System.Drawing.Size(177, 19);
            this.areGlyphsVisibleCheckBox.TabIndex = 2;
            this.areGlyphsVisibleCheckBox.Text = "Are word wrap glyphs visible";
            this.areGlyphsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.areGlyphsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnAreGlyphsVisibleCheckBoxCheckedChanged);
            // 
            // wordWrapModeComboBox
            // 
            this.wordWrapModeComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.wordWrapModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wordWrapModeComboBox.FormattingEnabled = true;
            this.wordWrapModeComboBox.Location = new System.Drawing.Point(104, 0);
            this.wordWrapModeComboBox.Name = "wordWrapModeComboBox";
            this.wordWrapModeComboBox.Size = new System.Drawing.Size(121, 23);
            this.wordWrapModeComboBox.TabIndex = 1;
            this.wordWrapModeComboBox.SelectedValueChanged += new System.EventHandler(this.OnWordWrapModeComboBoxSelectedValueChanged);
            // 
            // wordWrapModeLabel
            // 
            this.wordWrapModeLabel.AutoSize = true;
            this.wordWrapModeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.wordWrapModeLabel.Location = new System.Drawing.Point(0, 0);
            this.wordWrapModeLabel.Name = "wordWrapModeLabel";
            this.wordWrapModeLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.wordWrapModeLabel.Size = new System.Drawing.Size(104, 19);
            this.wordWrapModeLabel.TabIndex = 0;
            this.wordWrapModeLabel.Text = "Word Wrap Mode:";
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
		private System.Windows.Forms.ComboBox wordWrapModeComboBox;
		private System.Windows.Forms.Label wordWrapModeLabel;
		private System.Windows.Forms.CheckBox areGlyphsVisibleCheckBox;
	}
}
