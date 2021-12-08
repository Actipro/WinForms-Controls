namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewsSynchronizing {
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
            this.leftEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.rightEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
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
            this.tableLayoutPanel.Controls.Add(this.leftEditor, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.rightEditor, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(780, 580);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // leftEditor
            // 
            this.leftEditor.AllowDrop = true;
            this.leftEditor.AreWordWrapGlyphsVisible = true;
            this.leftEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftEditor.Location = new System.Drawing.Point(3, 3);
            this.leftEditor.Name = "leftEditor";
            this.leftEditor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.leftEditor.Size = new System.Drawing.Size(380, 574);
            this.leftEditor.TabIndex = 1;
            this.leftEditor.Text = resources.GetString("leftEditor.Text");
            // 
            // rightEditor
            // 
            this.rightEditor.AllowDrop = true;
            this.rightEditor.AreWordWrapGlyphsVisible = true;
            this.rightEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightEditor.Location = new System.Drawing.Point(396, 3);
            this.rightEditor.Name = "rightEditor";
            this.rightEditor.Size = new System.Drawing.Size(381, 574);
            this.rightEditor.TabIndex = 2;
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
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor leftEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor rightEditor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
	}
}
