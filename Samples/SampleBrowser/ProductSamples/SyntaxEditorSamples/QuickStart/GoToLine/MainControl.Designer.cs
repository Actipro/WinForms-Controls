namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GoToLine {
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
            this.goToLineButton = new System.Windows.Forms.Button();
            this.lineNumberTextBox = new System.Windows.Forms.TextBox();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(13, 54);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 533);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // goToLineButton
            // 
            this.goToLineButton.AutoSize = true;
            this.goToLineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.goToLineButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.goToLineButton.Location = new System.Drawing.Point(180, 3);
            this.goToLineButton.Name = "goToLineButton";
            this.goToLineButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.goToLineButton.Size = new System.Drawing.Size(82, 29);
            this.goToLineButton.TabIndex = 2;
            this.goToLineButton.Text = "Go to line";
            this.goToLineButton.UseVisualStyleBackColor = true;
            this.goToLineButton.Click += new System.EventHandler(this.OnGoToLineButtonClick);
            // 
            // lineNumberTextBox
            // 
            this.lineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineNumberTextBox.Location = new System.Drawing.Point(74, 7);
            this.lineNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lineNumberTextBox.Name = "lineNumberTextBox";
            this.lineNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.lineNumberTextBox.TabIndex = 1;
            this.lineNumberTextBox.Text = "50";
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineNumberLabel.Location = new System.Drawing.Point(3, 0);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lineNumberLabel.Size = new System.Drawing.Size(65, 35);
            this.lineNumberLabel.TabIndex = 0;
            this.lineNumberLabel.Text = "Line number";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.headerTableLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // headerTableLayoutPanel
            // 
            this.headerTableLayoutPanel.AutoSize = true;
            this.headerTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerTableLayoutPanel.ColumnCount = 3;
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.Controls.Add(this.goToLineButton, 2, 0);
            this.headerTableLayoutPanel.Controls.Add(this.lineNumberLabel, 0, 0);
            this.headerTableLayoutPanel.Controls.Add(this.lineNumberTextBox, 1, 0);
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
		private System.Windows.Forms.Button goToLineButton;
		private System.Windows.Forms.TextBox lineNumberTextBox;
		private System.Windows.Forms.Label lineNumberLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
	}
}
