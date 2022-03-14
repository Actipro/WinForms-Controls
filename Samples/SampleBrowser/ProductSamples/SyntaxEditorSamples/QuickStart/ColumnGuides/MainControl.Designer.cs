namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ColumnGuides {
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
            this.resetColumnGuidesButton = new System.Windows.Forms.Button();
            this.toggleColumnGuideButton = new System.Windows.Forms.Button();
            this.areColumnGuidesVisibleCheckBox = new System.Windows.Forms.CheckBox();
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
            this.editor.IsOutliningMarginVisible = false;
            this.editor.Location = new System.Drawing.Point(0, 31);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(780, 549);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.resetColumnGuidesButton);
            this.headerPanel.Controls.Add(this.toggleColumnGuideButton);
            this.headerPanel.Controls.Add(this.areColumnGuidesVisibleCheckBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 31);
            this.headerPanel.TabIndex = 3;
            // 
            // resetColumnGuidesButton
            // 
            this.resetColumnGuidesButton.AutoSize = true;
            this.resetColumnGuidesButton.Location = new System.Drawing.Point(428, 3);
            this.resetColumnGuidesButton.Name = "resetColumnGuidesButton";
            this.resetColumnGuidesButton.Size = new System.Drawing.Size(130, 25);
            this.resetColumnGuidesButton.TabIndex = 2;
            this.resetColumnGuidesButton.Text = "Reset Column Guides";
            this.resetColumnGuidesButton.UseVisualStyleBackColor = true;
            this.resetColumnGuidesButton.Click += new System.EventHandler(this.OnResetColumnGuidesButtonClick);
            // 
            // toggleColumnGuideButton
            // 
            this.toggleColumnGuideButton.AutoSize = true;
            this.toggleColumnGuideButton.Location = new System.Drawing.Point(200, 3);
            this.toggleColumnGuideButton.Name = "toggleColumnGuideButton";
            this.toggleColumnGuideButton.Size = new System.Drawing.Size(222, 25);
            this.toggleColumnGuideButton.TabIndex = 1;
            this.toggleColumnGuideButton.Text = "Toggle Column Guide at Caret Position";
            this.toggleColumnGuideButton.UseVisualStyleBackColor = true;
            this.toggleColumnGuideButton.Click += new System.EventHandler(this.OnToggleColumnGuideButtonClick);
            // 
            // areColumnGuidesVisibleCheckBox
            // 
            this.areColumnGuidesVisibleCheckBox.AutoSize = true;
            this.areColumnGuidesVisibleCheckBox.Location = new System.Drawing.Point(0, 7);
            this.areColumnGuidesVisibleCheckBox.Name = "areColumnGuidesVisibleCheckBox";
            this.areColumnGuidesVisibleCheckBox.Size = new System.Drawing.Size(162, 19);
            this.areColumnGuidesVisibleCheckBox.TabIndex = 0;
            this.areColumnGuidesVisibleCheckBox.Text = "Are column guides visible";
            this.areColumnGuidesVisibleCheckBox.UseVisualStyleBackColor = true;
            this.areColumnGuidesVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnAreColumnGuidesVisibleCheckBoxCheckedChanged);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
		private System.Windows.Forms.CheckBox areColumnGuidesVisibleCheckBox;
		private System.Windows.Forms.Button toggleColumnGuideButton;
		private System.Windows.Forms.Button resetColumnGuidesButton;
	}
}
