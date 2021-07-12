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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.verticalScrollBarComboBox = new System.Windows.Forms.ComboBox();
            this.verticalScrollBarLabel = new System.Windows.Forms.Label();
            this.horizontalScrollBarComboBox = new System.Windows.Forms.ComboBox();
            this.horizontalScrollBarLabel = new System.Windows.Forms.Label();
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
            this.editor.CanScrollPastDocumentEnd = false;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 31);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 549);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.verticalScrollBarComboBox);
            this.headerPanel.Controls.Add(this.verticalScrollBarLabel);
            this.headerPanel.Controls.Add(this.horizontalScrollBarComboBox);
            this.headerPanel.Controls.Add(this.horizontalScrollBarLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 31);
            this.headerPanel.TabIndex = 3;
            // 
            // verticalScrollBarComboBox
            // 
            this.verticalScrollBarComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalScrollBarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verticalScrollBarComboBox.FormattingEnabled = true;
            this.verticalScrollBarComboBox.Location = new System.Drawing.Point(362, 0);
            this.verticalScrollBarComboBox.Name = "verticalScrollBarComboBox";
            this.verticalScrollBarComboBox.Size = new System.Drawing.Size(121, 23);
            this.verticalScrollBarComboBox.TabIndex = 3;
            this.verticalScrollBarComboBox.SelectedValueChanged += new System.EventHandler(this.OnVerticalScrollBarComboBoxSelectedValueChanged);
            // 
            // verticalScrollBarLabel
            // 
            this.verticalScrollBarLabel.AutoSize = true;
            this.verticalScrollBarLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalScrollBarLabel.Location = new System.Drawing.Point(235, 0);
            this.verticalScrollBarLabel.Name = "verticalScrollBarLabel";
            this.verticalScrollBarLabel.Padding = new System.Windows.Forms.Padding(30, 4, 0, 0);
            this.verticalScrollBarLabel.Size = new System.Drawing.Size(127, 19);
            this.verticalScrollBarLabel.TabIndex = 2;
            this.verticalScrollBarLabel.Text = "Vertical ScrollBar:";
            // 
            // horizontalScrollBarComboBox
            // 
            this.horizontalScrollBarComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.horizontalScrollBarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horizontalScrollBarComboBox.FormattingEnabled = true;
            this.horizontalScrollBarComboBox.Location = new System.Drawing.Point(114, 0);
            this.horizontalScrollBarComboBox.Name = "horizontalScrollBarComboBox";
            this.horizontalScrollBarComboBox.Size = new System.Drawing.Size(121, 23);
            this.horizontalScrollBarComboBox.TabIndex = 1;
            this.horizontalScrollBarComboBox.SelectedValueChanged += new System.EventHandler(this.OnHorizontalScrollBarComboBoxSelectedValueChanged);
            // 
            // horizontalScrollBarLabel
            // 
            this.horizontalScrollBarLabel.AutoSize = true;
            this.horizontalScrollBarLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.horizontalScrollBarLabel.Location = new System.Drawing.Point(0, 0);
            this.horizontalScrollBarLabel.Name = "horizontalScrollBarLabel";
            this.horizontalScrollBarLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.horizontalScrollBarLabel.Size = new System.Drawing.Size(114, 19);
            this.horizontalScrollBarLabel.TabIndex = 0;
            this.horizontalScrollBarLabel.Text = "Horizontal ScrollBar:";
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
		private System.Windows.Forms.ComboBox horizontalScrollBarComboBox;
		private System.Windows.Forms.Label horizontalScrollBarLabel;
		private System.Windows.Forms.ComboBox verticalScrollBarComboBox;
		private System.Windows.Forms.Label verticalScrollBarLabel;
	}
}
