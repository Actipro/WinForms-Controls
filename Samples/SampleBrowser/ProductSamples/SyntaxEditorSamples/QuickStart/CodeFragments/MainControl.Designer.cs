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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// fragmentEditor
			// 
			this.fragmentEditor.AllowDrop = true;
			this.fragmentEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fragmentEditor.IsLineNumberMarginVisible = true;
			this.fragmentEditor.Location = new System.Drawing.Point(10, 243);
			this.fragmentEditor.Name = "fragmentEditor";
			this.fragmentEditor.Size = new System.Drawing.Size(780, 232);
			this.fragmentEditor.TabIndex = 0;
			this.fragmentEditor.Text = resources.GetString("fragmentEditor.Text");
			// 
			// headerEditor
			// 
			this.headerEditor.AllowDrop = true;
			this.headerEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.headerEditor.Location = new System.Drawing.Point(10, 30);
			this.headerEditor.Name = "headerEditor";
			this.headerEditor.Size = new System.Drawing.Size(780, 183);
			this.headerEditor.TabIndex = 1;
			this.headerEditor.Text = resources.GetString("headerEditor.Text");
			// 
			// footerEditor
			// 
			this.footerEditor.AllowDrop = true;
			this.footerEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.footerEditor.Location = new System.Drawing.Point(10, 504);
			this.footerEditor.Name = "footerEditor";
			this.footerEditor.Size = new System.Drawing.Size(780, 86);
			this.footerEditor.TabIndex = 2;
			this.footerEditor.Text = "\r\n\t\t}\r\n\t}\r\n}";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(474, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "Code in this read-only editor is prepended to the fragment editor\'s text when it " +
    "is parsed.";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 486);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(480, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Code in this read-only editor is postpended to the fragment editor\'s text when it" +
    " is parsed.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 225);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(667, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Code in this editable fragment editor is what the end user would only see normall" +
    "y, effectively creating a C# statement editor.";
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.footerEditor);
			this.Controls.Add(this.headerEditor);
			this.Controls.Add(this.fragmentEditor);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor fragmentEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor headerEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor footerEditor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}
