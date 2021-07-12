namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WhitespaceDisplay {
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
            this.tabSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.isWhiteSpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.tabSizeLabel = new System.Windows.Forms.Label();
            this.tabSizeCurrentValueLabel = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeTrackBar)).BeginInit();
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
            this.editor.IsWhitespaceVisible = true;
            this.editor.Location = new System.Drawing.Point(0, 31);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(780, 549);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.isWhiteSpaceVisibleCheckBox);
            this.headerPanel.Controls.Add(this.tabSizeCurrentValueLabel);
            this.headerPanel.Controls.Add(this.tabSizeTrackBar);
            this.headerPanel.Controls.Add(this.tabSizeLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.headerPanel.Size = new System.Drawing.Size(780, 31);
            this.headerPanel.TabIndex = 3;
            // 
            // tabSizeTrackBar
            // 
            this.tabSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSizeTrackBar.LargeChange = 1;
            this.tabSizeTrackBar.Location = new System.Drawing.Point(50, 0);
            this.tabSizeTrackBar.Maximum = 16;
            this.tabSizeTrackBar.Minimum = 1;
            this.tabSizeTrackBar.Name = "tabSizeTrackBar";
            this.tabSizeTrackBar.Size = new System.Drawing.Size(159, 21);
            this.tabSizeTrackBar.TabIndex = 3;
            this.tabSizeTrackBar.Value = 4;
            this.tabSizeTrackBar.ValueChanged += new System.EventHandler(this.OnTabSizeTrackBarValueChanged);
            // 
            // isWhiteSpaceVisibleCheckBox
            // 
            this.isWhiteSpaceVisibleCheckBox.AutoSize = true;
            this.isWhiteSpaceVisibleCheckBox.Checked = true;
            this.isWhiteSpaceVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isWhiteSpaceVisibleCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.isWhiteSpaceVisibleCheckBox.Location = new System.Drawing.Point(272, 0);
            this.isWhiteSpaceVisibleCheckBox.Name = "isWhiteSpaceVisibleCheckBox";
            this.isWhiteSpaceVisibleCheckBox.Size = new System.Drawing.Size(132, 21);
            this.isWhiteSpaceVisibleCheckBox.TabIndex = 2;
            this.isWhiteSpaceVisibleCheckBox.Text = "Is whitespace visible";
            this.isWhiteSpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            this.isWhiteSpaceVisibleCheckBox.CheckedChanged += new System.EventHandler(this.OnIsWhitespaceVisibleCheckBoxCheckedChanged);
            // 
            // tabSizeLabel
            // 
            this.tabSizeLabel.AutoSize = true;
            this.tabSizeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSizeLabel.Location = new System.Drawing.Point(0, 0);
            this.tabSizeLabel.Name = "tabSizeLabel";
            this.tabSizeLabel.Size = new System.Drawing.Size(50, 15);
            this.tabSizeLabel.TabIndex = 0;
            this.tabSizeLabel.Text = "Tab size:";
            // 
            // tabSizeCurrentValueLabel
            // 
            this.tabSizeCurrentValueLabel.AutoSize = true;
            this.tabSizeCurrentValueLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSizeCurrentValueLabel.Location = new System.Drawing.Point(209, 0);
            this.tabSizeCurrentValueLabel.Name = "tabSizeCurrentValueLabel";
            this.tabSizeCurrentValueLabel.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.tabSizeCurrentValueLabel.Size = new System.Drawing.Size(63, 15);
            this.tabSizeCurrentValueLabel.TabIndex = 4;
            this.tabSizeCurrentValueLabel.Text = "4";
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
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeTrackBar)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.Label tabSizeLabel;
		private System.Windows.Forms.CheckBox isWhiteSpaceVisibleCheckBox;
		private System.Windows.Forms.TrackBar tabSizeTrackBar;
		private System.Windows.Forms.Label tabSizeCurrentValueLabel;
	}
}
