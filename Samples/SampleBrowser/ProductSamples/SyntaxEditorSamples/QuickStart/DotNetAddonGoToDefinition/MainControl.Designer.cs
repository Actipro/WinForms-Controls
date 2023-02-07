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
            this.codeEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.headerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.goToDefinitionButton = new System.Windows.Forms.Button();
            this.selectDefinitionCheckBox = new System.Windows.Forms.CheckBox();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerFlowLayoutPanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            this.codeEditor.AllowDrop = true;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.IsLineNumberMarginVisible = true;
            this.codeEditor.Location = new System.Drawing.Point(13, 59);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.codeEditor.Size = new System.Drawing.Size(774, 311);
            this.codeEditor.TabIndex = 0;
            this.codeEditor.Text = resources.GetString("codeEditor.Text");
            this.codeEditor.ViewSelectionChanged += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorViewSelectionEventArgs>(this.OnSyntaxEditorViewSelectionChanged);
            this.codeEditor.MouseLeave += new System.EventHandler(this.OnSyntaxEditorMouseLeave);
            this.codeEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnSyntaxEditorMouseMove);
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTextBox.Location = new System.Drawing.Point(13, 381);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(774, 206);
            this.resultsTextBox.TabIndex = 2;
            // 
            // headerFlowLayoutPanel
            // 
            this.headerFlowLayoutPanel.AutoSize = true;
            this.headerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerFlowLayoutPanel.Controls.Add(this.goToDefinitionButton);
            this.headerFlowLayoutPanel.Controls.Add(this.selectDefinitionCheckBox);
            this.headerFlowLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerFlowLayoutPanel.Name = "headerFlowLayoutPanel";
            this.headerFlowLayoutPanel.Size = new System.Drawing.Size(326, 35);
            this.headerFlowLayoutPanel.TabIndex = 3;
            // 
            // goToDefinitionButton
            // 
            this.goToDefinitionButton.AutoSize = true;
            this.goToDefinitionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.goToDefinitionButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconGoToDefinition16;
            this.goToDefinitionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goToDefinitionButton.Location = new System.Drawing.Point(3, 3);
            this.goToDefinitionButton.Margin = new System.Windows.Forms.Padding(3, 3, 23, 3);
            this.goToDefinitionButton.Name = "goToDefinitionButton";
            this.goToDefinitionButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.goToDefinitionButton.Size = new System.Drawing.Size(130, 29);
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
            this.selectDefinitionCheckBox.Location = new System.Drawing.Point(159, 3);
            this.selectDefinitionCheckBox.Name = "selectDefinitionCheckBox";
            this.selectDefinitionCheckBox.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.selectDefinitionCheckBox.Size = new System.Drawing.Size(164, 24);
            this.selectDefinitionCheckBox.TabIndex = 1;
            this.selectDefinitionCheckBox.Text = "Select Definition on Navigate";
            this.selectDefinitionCheckBox.UseVisualStyleBackColor = true;
            this.selectDefinitionCheckBox.CheckedChanged += new System.EventHandler(this.OnSelectDefinitionCheckBoxCheckedChanged);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.codeEditor, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.resultsTextBox, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.headerFlowLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 5;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 1;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.headerFlowLayoutPanel.ResumeLayout(false);
            this.headerFlowLayoutPanel.PerformLayout();
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor codeEditor;
		private System.Windows.Forms.TextBox resultsTextBox;
		private System.Windows.Forms.FlowLayoutPanel headerFlowLayoutPanel;
		private System.Windows.Forms.Button goToDefinitionButton;
		private System.Windows.Forms.CheckBox selectDefinitionCheckBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
