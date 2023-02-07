namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CodeFragments {
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
            this.fragmentEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.footerEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.headerLabel = new System.Windows.Forms.Label();
            this.footerLabel = new System.Windows.Forms.Label();
            this.fragmentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fragmentEditor
            // 
            this.fragmentEditor.AllowDrop = true;
            this.fragmentEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentEditor.IsLineNumberMarginVisible = true;
            this.fragmentEditor.Location = new System.Drawing.Point(13, 174);
            this.fragmentEditor.Name = "fragmentEditor";
            this.fragmentEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.fragmentEditor.Size = new System.Drawing.Size(774, 264);
            this.fragmentEditor.TabIndex = 0;
            this.fragmentEditor.Text = resources.GetString("fragmentEditor.Text");
            // 
            // headerEditor
            // 
            this.headerEditor.AllowDrop = true;
            this.headerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerEditor.Location = new System.Drawing.Point(13, 26);
            this.headerEditor.Name = "headerEditor";
            this.headerEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.headerEditor.Size = new System.Drawing.Size(774, 129);
            this.headerEditor.TabIndex = 1;
            this.headerEditor.Text = resources.GetString("headerEditor.Text");
            // 
            // footerEditor
            // 
            this.footerEditor.AllowDrop = true;
            this.footerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerEditor.Location = new System.Drawing.Point(13, 457);
            this.footerEditor.Name = "footerEditor";
            this.footerEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.footerEditor.Size = new System.Drawing.Size(774, 130);
            this.footerEditor.TabIndex = 2;
            this.footerEditor.Text = "\r\n\t\t}\r\n\t}\r\n}";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Location = new System.Drawing.Point(13, 10);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(774, 13);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "Code in this read-only editor is prepended to the fragment editor\'s text when it " +
    "is parsed.";
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerLabel.Location = new System.Drawing.Point(13, 441);
            this.footerLabel.Name = "footerLabel";
			this.footerLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.footerLabel.Size = new System.Drawing.Size(774, 13);
            this.footerLabel.TabIndex = 4;
            this.footerLabel.Text = "Code in this read-only editor is postpended to the fragment editor\'s text when it" +
    " is parsed.";
            // 
            // fragmentLabel
            // 
            this.fragmentLabel.AutoSize = true;
            this.fragmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentLabel.Location = new System.Drawing.Point(13, 158);
            this.fragmentLabel.Name = "fragmentLabel";
			this.fragmentLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.fragmentLabel.Size = new System.Drawing.Size(774, 13);
            this.fragmentLabel.TabIndex = 5;
            this.fragmentLabel.Text = "Code in this editable fragment editor is what the end user would only see normall" +
    "y, effectively creating a C# statement editor.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.headerLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.footerEditor, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.footerLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fragmentLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.headerEditor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fragmentEditor, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor fragmentEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor headerEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor footerEditor;
		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Label footerLabel;
		private System.Windows.Forms.Label fragmentLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
