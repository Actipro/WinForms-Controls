namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.HighlightingStyleViewer {
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
            this.itemBorderLabel = new System.Windows.Forms.Label();
            this.textStylePreview = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.TextStylePreview();
            this.italicCheckBox = new System.Windows.Forms.CheckBox();
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.itemBackgroundLabel = new System.Windows.Forms.Label();
            this.itemForegroundLabel = new System.Windows.Forms.Label();
            this.classificationTypeListBox = new System.Windows.Forms.ListBox();
            this.displayItemsLabel = new System.Windows.Forms.Label();
            this.sampleEditorLabel = new System.Windows.Forms.Label();
            this.introLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.classificationTypeListBoxPanel = new System.Windows.Forms.Panel();
            this.backColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.borderColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.foreColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
            this.contentTableLayoutPanel.SuspendLayout();
            this.classificationTypeListBoxPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemBorderLabel
            // 
            this.itemBorderLabel.AutoSize = true;
            this.itemBorderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemBorderLabel.Location = new System.Drawing.Point(337, 127);
            this.itemBorderLabel.Name = "itemBorderLabel";
            this.itemBorderLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.itemBorderLabel.Size = new System.Drawing.Size(450, 25);
            this.itemBorderLabel.TabIndex = 4;
            this.itemBorderLabel.Text = "Item border:";
            // 
            // textStylePreview
            // 
            this.textStylePreview.HighlightingStyle = null;
            this.textStylePreview.HighlightingStyleRegistry = null;
            this.textStylePreview.Location = new System.Drawing.Point(337, 241);
            this.textStylePreview.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.textStylePreview.Name = "textStylePreview";
            this.textStylePreview.Padding = new System.Windows.Forms.Padding(30, 10, 30, 0);
            this.textStylePreview.Size = new System.Drawing.Size(254, 69);
            this.textStylePreview.TabIndex = 7;
            this.textStylePreview.TabStop = false;
            this.textStylePreview.Text = "AaBbCcXxYyZz";
            // 
            // italicCheckBox
            // 
            this.italicCheckBox.AutoSize = true;
            this.italicCheckBox.Location = new System.Drawing.Point(86, 13);
            this.italicCheckBox.Name = "italicCheckBox";
            this.italicCheckBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.italicCheckBox.Size = new System.Drawing.Size(78, 17);
            this.italicCheckBox.TabIndex = 1;
            this.italicCheckBox.Text = "Italic";
            this.italicCheckBox.UseVisualStyleBackColor = true;
            this.italicCheckBox.CheckedChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
            // 
            // boldCheckBox
            // 
            this.boldCheckBox.AutoSize = true;
            this.boldCheckBox.Location = new System.Drawing.Point(3, 13);
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.boldCheckBox.Size = new System.Drawing.Size(77, 17);
            this.boldCheckBox.TabIndex = 0;
            this.boldCheckBox.Text = "Bold";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.CheckedChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
            // 
            // itemBackgroundLabel
            // 
            this.itemBackgroundLabel.AutoSize = true;
            this.itemBackgroundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemBackgroundLabel.Location = new System.Drawing.Point(337, 75);
            this.itemBackgroundLabel.Name = "itemBackgroundLabel";
            this.itemBackgroundLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.itemBackgroundLabel.Size = new System.Drawing.Size(450, 25);
            this.itemBackgroundLabel.TabIndex = 2;
            this.itemBackgroundLabel.Text = "Item background:";
            // 
            // itemForegroundLabel
            // 
            this.itemForegroundLabel.AutoSize = true;
            this.itemForegroundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemForegroundLabel.Location = new System.Drawing.Point(337, 23);
            this.itemForegroundLabel.Name = "itemForegroundLabel";
            this.itemForegroundLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.itemForegroundLabel.Size = new System.Drawing.Size(450, 25);
            this.itemForegroundLabel.TabIndex = 0;
            this.itemForegroundLabel.Text = "Item foreground:";
            // 
            // classificationTypeListBox
            // 
            this.classificationTypeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classificationTypeListBox.FormattingEnabled = true;
            this.classificationTypeListBox.Location = new System.Drawing.Point(0, 0);
            this.classificationTypeListBox.Name = "classificationTypeListBox";
            this.classificationTypeListBox.Size = new System.Drawing.Size(298, 259);
            this.classificationTypeListBox.TabIndex = 2;
            this.classificationTypeListBox.SelectedIndexChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
            // 
            // displayItemsLabel
            // 
            this.displayItemsLabel.AutoSize = true;
            this.displayItemsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayItemsLabel.Location = new System.Drawing.Point(13, 23);
            this.displayItemsLabel.Name = "displayItemsLabel";
            this.displayItemsLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 2);
            this.displayItemsLabel.Size = new System.Drawing.Size(298, 25);
            this.displayItemsLabel.TabIndex = 0;
            this.displayItemsLabel.Text = "Display items:";
            // 
            // sampleEditorLabel
            // 
            this.sampleEditorLabel.AutoSize = true;
            this.sampleEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleEditorLabel.Location = new System.Drawing.Point(13, 313);
            this.sampleEditorLabel.Name = "sampleEditorLabel";
            this.sampleEditorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.sampleEditorLabel.Size = new System.Drawing.Size(298, 23);
            this.sampleEditorLabel.TabIndex = 3;
            this.sampleEditorLabel.Text = "Sample editor:";
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.introLabel, 3);
            this.introLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introLabel.Location = new System.Drawing.Point(13, 10);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(774, 13);
            this.introLabel.TabIndex = 0;
            this.introLabel.Text = "This QuickStart shows how to build a dialog that allows the end user to configure" +
    " highlighting styles, similar to the Visual Studio Options dialog.";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 3;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.contentTableLayoutPanel.Controls.Add(this.classificationTypeListBoxPanel, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.displayItemsLabel, 0, 3);
            this.contentTableLayoutPanel.Controls.Add(this.introLabel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.itemBackgroundLabel, 2, 7);
            this.contentTableLayoutPanel.Controls.Add(this.backColorButton, 2, 8);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 14);
            this.contentTableLayoutPanel.Controls.Add(this.itemBorderLabel, 2, 9);
            this.contentTableLayoutPanel.Controls.Add(this.sampleEditorLabel, 0, 13);
            this.contentTableLayoutPanel.Controls.Add(this.borderColorButton, 2, 10);
            this.contentTableLayoutPanel.Controls.Add(this.textStylePreview, 2, 12);
            this.contentTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 11);
            this.contentTableLayoutPanel.Controls.Add(this.itemForegroundLabel, 2, 3);
            this.contentTableLayoutPanel.Controls.Add(this.foreColorButton, 2, 4);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 15;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // classificationTypeListBoxPanel
            // 
            this.classificationTypeListBoxPanel.AutoSize = true;
            this.classificationTypeListBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.classificationTypeListBoxPanel.Controls.Add(this.classificationTypeListBox);
            this.classificationTypeListBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classificationTypeListBoxPanel.Location = new System.Drawing.Point(13, 51);
            this.classificationTypeListBoxPanel.Name = "classificationTypeListBoxPanel";
            this.contentTableLayoutPanel.SetRowSpan(this.classificationTypeListBoxPanel, 9);
            this.classificationTypeListBoxPanel.Size = new System.Drawing.Size(298, 259);
            this.classificationTypeListBoxPanel.TabIndex = 3;
            // 
            // backColorButton
            // 
            this.backColorButton.BackColor = System.Drawing.SystemColors.Window;
            this.backColorButton.Color = System.Drawing.Color.Red;
            this.backColorButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.backColorButton.Location = new System.Drawing.Point(337, 103);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(130, 21);
            this.backColorButton.TabIndex = 3;
            this.backColorButton.Text = "colorButton1";
            this.backColorButton.UseVisualStyleBackColor = false;
            this.backColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreIndentationGuidesVisible = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 3);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsCurrentLineHighlightingEnabled = true;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(13, 339);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 248);
            this.editor.TabIndex = 4;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // borderColorButton
            // 
            this.borderColorButton.BackColor = System.Drawing.SystemColors.Window;
            this.borderColorButton.Color = System.Drawing.Color.Red;
            this.borderColorButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.borderColorButton.Location = new System.Drawing.Point(337, 155);
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(130, 21);
            this.borderColorButton.TabIndex = 5;
            this.borderColorButton.Text = "colorButton1";
            this.borderColorButton.UseVisualStyleBackColor = false;
            this.borderColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.boldCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.italicCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(337, 182);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 33);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // foreColorButton
            // 
            this.foreColorButton.BackColor = System.Drawing.SystemColors.Window;
            this.foreColorButton.Color = System.Drawing.Color.Red;
            this.foreColorButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.foreColorButton.Location = new System.Drawing.Point(337, 51);
            this.foreColorButton.Name = "foreColorButton";
            this.foreColorButton.Size = new System.Drawing.Size(130, 21);
            this.foreColorButton.TabIndex = 1;
            this.foreColorButton.Text = "colorButton1";
            this.foreColorButton.UseVisualStyleBackColor = false;
            this.foreColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
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
            this.classificationTypeListBoxPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label sampleEditorLabel;
		private System.Windows.Forms.Label displayItemsLabel;
		private System.Windows.Forms.Label introLabel;
		private SampleBrowser.ColorButton foreColorButton;
		private System.Windows.Forms.Label itemForegroundLabel;
		private SampleBrowser.ColorButton backColorButton;
		private System.Windows.Forms.Label itemBackgroundLabel;
		private UI.WinForms.Controls.SyntaxEditor.TextStylePreview textStylePreview;
		private System.Windows.Forms.CheckBox italicCheckBox;
		private System.Windows.Forms.CheckBox boldCheckBox;
		private SampleBrowser.ColorButton borderColorButton;
		private System.Windows.Forms.Label itemBorderLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ListBox classificationTypeListBox;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel classificationTypeListBoxPanel;
	}
}
