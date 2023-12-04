namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSwapping {
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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.documentComboBox = new System.Windows.Forms.ComboBox();
            this.documentLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.documentPanel = new System.Windows.Forms.Panel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.documentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 40);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 547);
            this.editor.TabIndex = 1;
			this.editor.WordWrapMode = UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // documentComboBox
            // 
            this.documentComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.documentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.documentComboBox.FormattingEnabled = true;
            this.documentComboBox.Location = new System.Drawing.Point(0, 0);
            this.documentComboBox.Name = "documentComboBox";
            this.documentComboBox.Size = new System.Drawing.Size(205, 21);
            this.documentComboBox.TabIndex = 4;
            this.documentComboBox.SelectedIndexChanged += new System.EventHandler(this.OnDocumentComboBoxSelectedIndexChanged);
            // 
            // documentLabel
            // 
            this.documentLabel.AutoSize = true;
            this.documentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentLabel.Location = new System.Drawing.Point(3, 0);
            this.documentLabel.Name = "documentLabel";
            this.documentLabel.Padding = new System.Windows.Forms.Padding(0, 4, 2, 4);
            this.documentLabel.Size = new System.Drawing.Size(93, 21);
            this.documentLabel.TabIndex = 3;
            this.documentLabel.Text = "Current document";
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
            this.headerTableLayoutPanel.ColumnCount = 2;
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.Controls.Add(this.documentLabel, 0, 0);
            this.headerTableLayoutPanel.Controls.Add(this.documentPanel, 1, 0);
            this.headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTableLayoutPanel.Location = new System.Drawing.Point(13, 13);
            this.headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            this.headerTableLayoutPanel.RowCount = 1;
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.Size = new System.Drawing.Size(774, 21);
            this.headerTableLayoutPanel.TabIndex = 3;
            // 
            // documentPanel
            // 
            this.documentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.documentPanel.Controls.Add(this.documentComboBox);
            this.documentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentPanel.Location = new System.Drawing.Point(99, 0);
            this.documentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.documentPanel.Name = "documentPanel";
            this.documentPanel.Size = new System.Drawing.Size(675, 21);
            this.documentPanel.TabIndex = 5;
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
            this.documentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Label documentLabel;
		private System.Windows.Forms.ComboBox documentComboBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
		private System.Windows.Forms.Panel documentPanel;
	}
}
