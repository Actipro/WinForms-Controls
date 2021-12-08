namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DotNetAddonGoToDefinition {
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
            this.codeEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.bottomSpacerPanel = new System.Windows.Forms.Panel();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.topSpacerPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.goToDefinitionButton = new System.Windows.Forms.Button();
            this.selectDefinitionCheckBox = new System.Windows.Forms.CheckBox();
            this.contentPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.codeEditor);
            this.contentPanel.Controls.Add(this.bottomSpacerPanel);
            this.contentPanel.Controls.Add(this.resultsTextBox);
            this.contentPanel.Controls.Add(this.topSpacerPanel);
            this.contentPanel.Controls.Add(this.flowLayoutPanel1);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // codeEditor
            // 
            this.codeEditor.AllowDrop = true;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.IsLineNumberMarginVisible = true;
            this.codeEditor.Location = new System.Drawing.Point(0, 38);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.codeEditor.Size = new System.Drawing.Size(780, 332);
            this.codeEditor.TabIndex = 1;
            this.codeEditor.Text = resources.GetString("codeEditor.Text");
            this.codeEditor.ViewSelectionChanged += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorViewSelectionEventArgs>(this.OnSyntaxEditorViewSelectionChanged);
            // 
            // bottomSpacerPanel
            // 
            this.bottomSpacerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomSpacerPanel.Location = new System.Drawing.Point(0, 370);
            this.bottomSpacerPanel.Name = "bottomSpacerPanel";
            this.bottomSpacerPanel.Size = new System.Drawing.Size(780, 10);
            this.bottomSpacerPanel.TabIndex = 4;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultsTextBox.Location = new System.Drawing.Point(0, 380);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(780, 200);
            this.resultsTextBox.TabIndex = 5;
            // 
            // topSpacerPanel
            // 
            this.topSpacerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topSpacerPanel.Location = new System.Drawing.Point(0, 28);
            this.topSpacerPanel.Name = "topSpacerPanel";
            this.topSpacerPanel.Size = new System.Drawing.Size(780, 10);
            this.topSpacerPanel.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.goToDefinitionButton);
            this.flowLayoutPanel1.Controls.Add(this.selectDefinitionCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 28);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // goToDefinitionButton
            // 
            this.goToDefinitionButton.AutoSize = true;
            this.goToDefinitionButton.Image = ((System.Drawing.Image)(resources.GetObject("goToDefinitionButton.Image")));
            this.goToDefinitionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goToDefinitionButton.Location = new System.Drawing.Point(3, 3);
            this.goToDefinitionButton.Name = "goToDefinitionButton";
            this.goToDefinitionButton.Size = new System.Drawing.Size(118, 25);
            this.goToDefinitionButton.TabIndex = 0;
            this.goToDefinitionButton.Text = "Go To Definition";
            this.goToDefinitionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.goToDefinitionButton.UseVisualStyleBackColor = true;
            this.goToDefinitionButton.Click += new System.EventHandler(this.OnGoToDefinitionButtonClick);
            // 
            // selectDefinitionCheckBox
            // 
            this.selectDefinitionCheckBox.AutoSize = true;
            this.selectDefinitionCheckBox.Checked = true;
            this.selectDefinitionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectDefinitionCheckBox.Location = new System.Drawing.Point(127, 3);
            this.selectDefinitionCheckBox.Name = "selectDefinitionCheckBox";
            this.selectDefinitionCheckBox.Padding = new System.Windows.Forms.Padding(20, 4, 0, 0);
            this.selectDefinitionCheckBox.Size = new System.Drawing.Size(199, 23);
            this.selectDefinitionCheckBox.TabIndex = 1;
            this.selectDefinitionCheckBox.Text = "Select Definition on Navigate";
            this.selectDefinitionCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor codeEditor;
		private System.Windows.Forms.Panel bottomSpacerPanel;
		private System.Windows.Forms.TextBox resultsTextBox;
		private System.Windows.Forms.Panel topSpacerPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button goToDefinitionButton;
		private System.Windows.Forms.CheckBox selectDefinitionCheckBox;
	}
}
