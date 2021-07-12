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
			this.contentPanel = new System.Windows.Forms.Panel();
			this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.borderColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
			this.label5 = new System.Windows.Forms.Label();
			this.textStylePreview = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.TextStylePreview();
			this.italicCheckBox = new System.Windows.Forms.CheckBox();
			this.boldCheckBox = new System.Windows.Forms.CheckBox();
			this.backColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
			this.label4 = new System.Windows.Forms.Label();
			this.foreColorButton = new ActiproSoftware.SampleBrowser.ColorButton();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.classificationTypeListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.introLabel = new System.Windows.Forms.Label();
			this.contentPanel.SuspendLayout();
			this.headerPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.editor.IsLineNumberMarginVisible = true;
			this.editor.Location = new System.Drawing.Point(0, 319);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(780, 261);
			this.editor.TabIndex = 10;
			this.editor.Text = resources.GetString("editor.Text");
			// 
			// headerPanel
			// 
			this.headerPanel.Controls.Add(this.panel2);
			this.headerPanel.Controls.Add(this.panel1);
			this.headerPanel.Controls.Add(this.introLabel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.headerPanel.Size = new System.Drawing.Size(780, 319);
			this.headerPanel.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.borderColorButton);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.textStylePreview);
			this.panel2.Controls.Add(this.italicCheckBox);
			this.panel2.Controls.Add(this.boldCheckBox);
			this.panel2.Controls.Add(this.backColorButton);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.foreColorButton);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(230, 15);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.panel2.Size = new System.Drawing.Size(550, 302);
			this.panel2.TabIndex = 2;
			// 
			// borderColorButton
			// 
			this.borderColorButton.BackColor = System.Drawing.SystemColors.Window;
			this.borderColorButton.Color = System.Drawing.Color.Red;
			this.borderColorButton.Location = new System.Drawing.Point(0, 123);
			this.borderColorButton.Name = "borderColorButton";
			this.borderColorButton.Size = new System.Drawing.Size(130, 21);
			this.borderColorButton.TabIndex = 3;
			this.borderColorButton.Text = "colorButton1";
			this.borderColorButton.UseVisualStyleBackColor = false;
			this.borderColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-3, 107);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label5.Size = new System.Drawing.Size(72, 17);
			this.label5.TabIndex = 10;
			this.label5.Text = "Item border:";
			// 
			// textStylePreview
			// 
			this.textStylePreview.HighlightingStyle = null;
			this.textStylePreview.HighlightingStyleRegistry = null;
			this.textStylePreview.Location = new System.Drawing.Point(0, 208);
			this.textStylePreview.Name = "textStylePreview";
			this.textStylePreview.Size = new System.Drawing.Size(254, 69);
			this.textStylePreview.TabIndex = 8;
			this.textStylePreview.TabStop = false;
			this.textStylePreview.Text = "AaBbCcXxYyZz";
			// 
			// italicCheckBox
			// 
			this.italicCheckBox.AutoSize = true;
			this.italicCheckBox.Location = new System.Drawing.Point(79, 166);
			this.italicCheckBox.Name = "italicCheckBox";
			this.italicCheckBox.Size = new System.Drawing.Size(51, 19);
			this.italicCheckBox.TabIndex = 5;
			this.italicCheckBox.Text = "Italic";
			this.italicCheckBox.UseVisualStyleBackColor = true;
			this.italicCheckBox.CheckedChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// boldCheckBox
			// 
			this.boldCheckBox.AutoSize = true;
			this.boldCheckBox.Location = new System.Drawing.Point(0, 166);
			this.boldCheckBox.Name = "boldCheckBox";
			this.boldCheckBox.Size = new System.Drawing.Size(50, 19);
			this.boldCheckBox.TabIndex = 4;
			this.boldCheckBox.Text = "Bold";
			this.boldCheckBox.UseVisualStyleBackColor = true;
			this.boldCheckBox.CheckedChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// backColorButton
			// 
			this.backColorButton.BackColor = System.Drawing.SystemColors.Window;
			this.backColorButton.Color = System.Drawing.Color.Red;
			this.backColorButton.Location = new System.Drawing.Point(0, 74);
			this.backColorButton.Name = "backColorButton";
			this.backColorButton.Size = new System.Drawing.Size(130, 21);
			this.backColorButton.TabIndex = 2;
			this.backColorButton.Text = "colorButton1";
			this.backColorButton.UseVisualStyleBackColor = false;
			this.backColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-3, 58);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label4.Size = new System.Drawing.Size(101, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Item background:";
			// 
			// foreColorButton
			// 
			this.foreColorButton.BackColor = System.Drawing.SystemColors.Window;
			this.foreColorButton.Color = System.Drawing.Color.Red;
			this.foreColorButton.Location = new System.Drawing.Point(0, 27);
			this.foreColorButton.Name = "foreColorButton";
			this.foreColorButton.Size = new System.Drawing.Size(130, 21);
			this.foreColorButton.TabIndex = 1;
			this.foreColorButton.Text = "colorButton1";
			this.foreColorButton.UseVisualStyleBackColor = false;
			this.foreColorButton.ColorChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(-3, 11);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label3.Size = new System.Drawing.Size(97, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Item foreground:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.classificationTypeListView);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 15);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 30, 0);
			this.panel1.Size = new System.Drawing.Size(230, 302);
			this.panel1.TabIndex = 1;
			// 
			// classificationTypeListView
			// 
			this.classificationTypeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.classificationTypeListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.classificationTypeListView.FullRowSelect = true;
			this.classificationTypeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.classificationTypeListView.HideSelection = false;
			this.classificationTypeListView.Location = new System.Drawing.Point(0, 27);
			this.classificationTypeListView.Name = "classificationTypeListView";
			this.classificationTypeListView.Size = new System.Drawing.Size(200, 250);
			this.classificationTypeListView.TabIndex = 0;
			this.classificationTypeListView.UseCompatibleStateImageBehavior = false;
			this.classificationTypeListView.View = System.Windows.Forms.View.Details;
			this.classificationTypeListView.SelectedIndexChanged += new System.EventHandler(this.OnUpdateHighlightingStyle);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 175;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Location = new System.Drawing.Point(0, 277);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.label2.Size = new System.Drawing.Size(83, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sample editor:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 10);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.label1.Size = new System.Drawing.Size(80, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Display items:";
			// 
			// introLabel
			// 
			this.introLabel.AutoSize = true;
			this.introLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.introLabel.Location = new System.Drawing.Point(0, 0);
			this.introLabel.Name = "introLabel";
			this.introLabel.Size = new System.Drawing.Size(763, 15);
			this.introLabel.TabIndex = 0;
			this.introLabel.Text = "This QuickStart shows how to build a dialog that allows the end user to configure" +
    " highlighting styles, similar to the Visual Studio Options dialog.";
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
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView classificationTypeListView;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label introLabel;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel2;
		private SampleBrowser.ColorButton foreColorButton;
		private System.Windows.Forms.Label label3;
		private SampleBrowser.ColorButton backColorButton;
		private System.Windows.Forms.Label label4;
		private UI.WinForms.Controls.SyntaxEditor.TextStylePreview textStylePreview;
		private System.Windows.Forms.CheckBox italicCheckBox;
		private System.Windows.Forms.CheckBox boldCheckBox;
		private SampleBrowser.ColorButton borderColorButton;
		private System.Windows.Forms.Label label5;
	}
}
