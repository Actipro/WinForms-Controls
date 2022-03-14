namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CompareFiles {
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ignoreWhiteSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.oldEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.newEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.contentPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.tableLayoutPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.ignoreWhiteSpaceCheckBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.oldEditor, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.newEditor, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(780, 580);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // ignoreWhiteSpaceCheckBox
            // 
            this.ignoreWhiteSpaceCheckBox.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.ignoreWhiteSpaceCheckBox, 3);
            this.ignoreWhiteSpaceCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ignoreWhiteSpaceCheckBox.Name = "ignoreWhiteSpaceCheckBox";
            this.ignoreWhiteSpaceCheckBox.Size = new System.Drawing.Size(125, 19);
            this.ignoreWhiteSpaceCheckBox.TabIndex = 3;
            this.ignoreWhiteSpaceCheckBox.Text = "Ignore white space";
            this.ignoreWhiteSpaceCheckBox.UseVisualStyleBackColor = true;
            this.ignoreWhiteSpaceCheckBox.CheckedChanged += new System.EventHandler(this.OnIgnoreWhiteSpaceCheckBoxCheckedChanged);
            // 
            // oldEditor
            // 
            this.oldEditor.AllowDrop = true;
            this.oldEditor.CanSplitHorizontally = false;
            this.oldEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oldEditor.IsLineNumberMarginVisible = true;
            this.oldEditor.IsOutliningMarginVisible = false;
            this.oldEditor.Location = new System.Drawing.Point(3, 33);
            this.oldEditor.Name = "leftEditor";
            this.oldEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.oldEditor.Size = new System.Drawing.Size(380, 544);
            this.oldEditor.TabIndex = 1;
            this.oldEditor.Text = resources.GetString("oldEditor.Text");
            // 
            // newEditor
            // 
            this.newEditor.AllowDrop = true;
            this.newEditor.CanSplitHorizontally = false;
            this.newEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newEditor.IsLineNumberMarginVisible = true;
            this.newEditor.IsOutliningMarginVisible = false;
            this.newEditor.Location = new System.Drawing.Point(396, 33);
            this.newEditor.Name = "rightEditor";
            this.newEditor.Size = new System.Drawing.Size(381, 544);
            this.newEditor.TabIndex = 2;
            this.newEditor.Text = resources.GetString("newEditor.Text");
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
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor oldEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor newEditor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.CheckBox ignoreWhiteSpaceCheckBox;
	}
}
