namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.LanguageTransitions {
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
            this.tabStrip1 = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip();
            this.aspTabStripPage = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage();
            this.directiveEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.scriptTabStripPage = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage();
            this.tagEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip1)).BeginInit();
            this.tabStrip1.SuspendLayout();
            this.aspTabStripPage.SuspendLayout();
            this.scriptTabStripPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabStrip1);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.TabIndex = 1;
            // 
            // tabStrip1
            // 
            this.tabStrip1.Controls.Add(this.aspTabStripPage);
            this.tabStrip1.Controls.Add(this.scriptTabStripPage);
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStrip1.Location = new System.Drawing.Point(10, 10);
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.Size = new System.Drawing.Size(780, 580);
            this.tabStrip1.TabIndex = 2;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // aspTabStripPage
            // 
            this.aspTabStripPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aspTabStripPage.Controls.Add(this.directiveEditor);
            this.aspTabStripPage.Key = "aspTabStripPage";
            this.aspTabStripPage.Location = new System.Drawing.Point(1, 20);
            this.aspTabStripPage.Name = "aspTabStripPage";
            this.aspTabStripPage.Size = new System.Drawing.Size(778, 559);
            this.aspTabStripPage.TabIndex = 0;
            this.aspTabStripPage.Text = "Language Transitions: <% %>";
            // 
            // directiveEditor
            // 
            this.directiveEditor.AllowDrop = true;
            this.directiveEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directiveEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directiveEditor.Location = new System.Drawing.Point(0, 0);
            this.directiveEditor.Name = "directiveEditor";
            this.directiveEditor.OverrideCursor = null;
            this.directiveEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.directiveEditor.Size = new System.Drawing.Size(778, 559);
            this.directiveEditor.TabIndex = 2;
            this.directiveEditor.Text = resources.GetString("directiveEditor.Text");
            // 
            // scriptTabStripPage
            // 
            this.scriptTabStripPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scriptTabStripPage.Controls.Add(this.tagEditor);
            this.scriptTabStripPage.Key = "scriptTabStripPage";
            this.scriptTabStripPage.Location = new System.Drawing.Point(1, 20);
            this.scriptTabStripPage.Name = "scriptTabStripPage";
            this.scriptTabStripPage.Size = new System.Drawing.Size(778, 559);
            this.scriptTabStripPage.TabIndex = 1;
            this.scriptTabStripPage.Text = "Language Transitions: <script>";
            // 
            // tagEditor
            // 
            this.tagEditor.AllowDrop = true;
            this.tagEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tagEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagEditor.Location = new System.Drawing.Point(0, 0);
            this.tagEditor.Name = "tagEditor";
            this.tagEditor.OverrideCursor = null;
            this.tagEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.tagEditor.Size = new System.Drawing.Size(778, 559);
            this.tagEditor.TabIndex = 2;
            this.tagEditor.Text = resources.GetString("tagEditor.Text");
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip1)).EndInit();
            this.tabStrip1.ResumeLayout(false);
            this.aspTabStripPage.ResumeLayout(false);
            this.scriptTabStripPage.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip tabStrip1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage aspTabStripPage;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage scriptTabStripPage;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor directiveEditor;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor tagEditor;
	}
}
