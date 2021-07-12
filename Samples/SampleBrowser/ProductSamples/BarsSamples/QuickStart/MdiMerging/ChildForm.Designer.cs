namespace ActiproSoftware.ProductSamples.BarsSamples.QuickStart.MdiMerging {
	partial class ChildForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildForm));
			this.toolBar = new ActiproSoftware.UI.WinForms.Controls.Bars.ToolBar();
			this.textBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(384, 23);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "Standalone";
			this.toolBar.Visible = false;
			// 
			// textBox
			// 
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox.Location = new System.Drawing.Point(0, 23);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox.Size = new System.Drawing.Size(384, 255);
			this.textBox.TabIndex = 1;
			this.textBox.Text = resources.GetString("textBox.Text");
			// 
			// ChildForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(384, 278);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.toolBar);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChildForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Document";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ActiproSoftware.UI.WinForms.Controls.Bars.ToolBar toolBar;
		private System.Windows.Forms.TextBox textBox;
	}
}
