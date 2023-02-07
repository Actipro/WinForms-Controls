namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ScrollBarVisibility {
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
            this.verticalScrollBarComboBox = new System.Windows.Forms.ComboBox();
            this.verticalScrollBarLabel = new System.Windows.Forms.Label();
            this.horizontalScrollBarComboBox = new System.Windows.Forms.ComboBox();
            this.horizontalScrollBarLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.horizontalScrollBarComboBoxPanel = new System.Windows.Forms.Panel();
            this.verticalScrollBarComboBoxPanel = new System.Windows.Forms.Panel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.horizontalScrollBarComboBoxPanel.SuspendLayout();
            this.verticalScrollBarComboBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.CanScrollPastDocumentEnd = false;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 73);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 514);
            this.editor.TabIndex = 4;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // verticalScrollBarComboBox
            // 
            this.verticalScrollBarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verticalScrollBarComboBox.FormattingEnabled = true;
            this.verticalScrollBarComboBox.Location = new System.Drawing.Point(0, 0);
            this.verticalScrollBarComboBox.Name = "verticalScrollBarComboBox";
            this.verticalScrollBarComboBox.Size = new System.Drawing.Size(121, 21);
            this.verticalScrollBarComboBox.TabIndex = 3;
            this.verticalScrollBarComboBox.SelectedValueChanged += new System.EventHandler(this.OnVerticalScrollBarComboBoxSelectedValueChanged);
            // 
            // verticalScrollBarLabel
            // 
            this.verticalScrollBarLabel.AutoSize = true;
            this.verticalScrollBarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalScrollBarLabel.Location = new System.Drawing.Point(13, 40);
            this.verticalScrollBarLabel.Name = "verticalScrollBarLabel";
            this.verticalScrollBarLabel.Size = new System.Drawing.Size(102, 30);
            this.verticalScrollBarLabel.TabIndex = 2;
            this.verticalScrollBarLabel.Text = "Vertical ScrollBar:";
            this.verticalScrollBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // horizontalScrollBarComboBox
            // 
            this.horizontalScrollBarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horizontalScrollBarComboBox.FormattingEnabled = true;
            this.horizontalScrollBarComboBox.Location = new System.Drawing.Point(0, 0);
            this.horizontalScrollBarComboBox.Name = "horizontalScrollBarComboBox";
            this.horizontalScrollBarComboBox.Size = new System.Drawing.Size(121, 21);
            this.horizontalScrollBarComboBox.TabIndex = 1;
            this.horizontalScrollBarComboBox.SelectedValueChanged += new System.EventHandler(this.OnHorizontalScrollBarComboBoxSelectedValueChanged);
            // 
            // horizontalScrollBarLabel
            // 
            this.horizontalScrollBarLabel.AutoSize = true;
            this.horizontalScrollBarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalScrollBarLabel.Location = new System.Drawing.Point(13, 10);
            this.horizontalScrollBarLabel.Name = "horizontalScrollBarLabel";
            this.horizontalScrollBarLabel.Size = new System.Drawing.Size(102, 30);
            this.horizontalScrollBarLabel.TabIndex = 0;
            this.horizontalScrollBarLabel.Text = "Horizontal ScrollBar:";
            this.horizontalScrollBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.verticalScrollBarComboBoxPanel, 1, 1);
            this.contentTableLayoutPanel.Controls.Add(this.horizontalScrollBarComboBoxPanel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.verticalScrollBarLabel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.horizontalScrollBarLabel, 0, 0);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 3;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // horizontalScrollBarComboBoxPanel
            // 
            this.horizontalScrollBarComboBoxPanel.AutoSize = true;
            this.horizontalScrollBarComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.horizontalScrollBarComboBoxPanel.Controls.Add(this.horizontalScrollBarComboBox);
            this.horizontalScrollBarComboBoxPanel.Location = new System.Drawing.Point(121, 13);
            this.horizontalScrollBarComboBoxPanel.Name = "horizontalScrollBarComboBoxPanel";
            this.horizontalScrollBarComboBoxPanel.Size = new System.Drawing.Size(124, 24);
            this.horizontalScrollBarComboBoxPanel.TabIndex = 1;
            // 
            // verticalScrollBarComboBoxPanel
            // 
            this.verticalScrollBarComboBoxPanel.AutoSize = true;
            this.verticalScrollBarComboBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verticalScrollBarComboBoxPanel.Controls.Add(this.verticalScrollBarComboBox);
            this.verticalScrollBarComboBoxPanel.Location = new System.Drawing.Point(121, 43);
            this.verticalScrollBarComboBoxPanel.Name = "verticalScrollBarComboBoxPanel";
            this.verticalScrollBarComboBoxPanel.Size = new System.Drawing.Size(124, 24);
            this.verticalScrollBarComboBoxPanel.TabIndex = 3;
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
            this.horizontalScrollBarComboBoxPanel.ResumeLayout(false);
            this.verticalScrollBarComboBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ComboBox horizontalScrollBarComboBox;
		private System.Windows.Forms.Label horizontalScrollBarLabel;
		private System.Windows.Forms.ComboBox verticalScrollBarComboBox;
		private System.Windows.Forms.Label verticalScrollBarLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.Panel verticalScrollBarComboBoxPanel;
		private System.Windows.Forms.Panel horizontalScrollBarComboBoxPanel;
	}
}
