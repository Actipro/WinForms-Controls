namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SearchFindResults {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
			this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.dockManager = new ActiproSoftware.UI.WinForms.Controls.Docking.DockManager(this.components);
			this.autoHideTabStripPanel1 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel2 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel3 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer3 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel4 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer4 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.resultsToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
			this.resultsTextBox = new System.Windows.Forms.TextBox();
			this.toolWindowContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.resultsToolWindow.SuspendLayout();
			this.toolWindowContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// editor
			// 
			this.editor.AllowDrop = true;
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.IsLineNumberMarginVisible = true;
			this.editor.Location = new System.Drawing.Point(6, 6);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(788, 450);
			this.editor.TabIndex = 0;
			this.editor.Text = resources.GetString("editor.Text");
			this.editor.OverlayPaneOpened += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.OverlayPaneEventArgs>(this.OnEditorOverlayPaneOpened);
			this.editor.ViewSearch += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorViewSearchEventArgs>(this.OnEditorViewSearch);
			// 
			// dockManager
			// 
			this.dockManager.HostContainerControl = this;
			this.dockManager.ToolWindowsCanClose = false;
			// 
			// autoHideTabStripPanel1
			// 
			this.autoHideTabStripPanel1.AllowDrop = true;
			this.autoHideTabStripPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.autoHideTabStripPanel1.DockManager = this.dockManager;
			this.autoHideTabStripPanel1.Location = new System.Drawing.Point(0, 0);
			this.autoHideTabStripPanel1.Name = "autoHideTabStripPanel1";
			this.autoHideTabStripPanel1.Size = new System.Drawing.Size(6, 600);
			this.autoHideTabStripPanel1.TabIndex = 1;
			// 
			// autoHideContainer1
			// 
			this.autoHideContainer1.AutoHideTabStripPanel = this.autoHideTabStripPanel1;
			this.autoHideContainer1.DockManager = this.dockManager;
			this.autoHideContainer1.Location = new System.Drawing.Point(0, 0);
			this.autoHideContainer1.Name = "autoHideContainer1";
			this.autoHideContainer1.Size = new System.Drawing.Size(0, 0);
			this.autoHideContainer1.TabIndex = 2;
			// 
			// autoHideTabStripPanel2
			// 
			this.autoHideTabStripPanel2.AllowDrop = true;
			this.autoHideTabStripPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.autoHideTabStripPanel2.DockManager = this.dockManager;
			this.autoHideTabStripPanel2.Location = new System.Drawing.Point(6, 0);
			this.autoHideTabStripPanel2.Name = "autoHideTabStripPanel2";
			this.autoHideTabStripPanel2.Size = new System.Drawing.Size(788, 6);
			this.autoHideTabStripPanel2.TabIndex = 3;
			// 
			// autoHideContainer2
			// 
			this.autoHideContainer2.AutoHideTabStripPanel = this.autoHideTabStripPanel2;
			this.autoHideContainer2.DockManager = this.dockManager;
			this.autoHideContainer2.Location = new System.Drawing.Point(0, 0);
			this.autoHideContainer2.Name = "autoHideContainer2";
			this.autoHideContainer2.Size = new System.Drawing.Size(0, 0);
			this.autoHideContainer2.TabIndex = 4;
			// 
			// autoHideTabStripPanel3
			// 
			this.autoHideTabStripPanel3.AllowDrop = true;
			this.autoHideTabStripPanel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.autoHideTabStripPanel3.DockManager = this.dockManager;
			this.autoHideTabStripPanel3.Location = new System.Drawing.Point(794, 0);
			this.autoHideTabStripPanel3.Name = "autoHideTabStripPanel3";
			this.autoHideTabStripPanel3.Size = new System.Drawing.Size(6, 600);
			this.autoHideTabStripPanel3.TabIndex = 5;
			// 
			// autoHideContainer3
			// 
			this.autoHideContainer3.AutoHideTabStripPanel = this.autoHideTabStripPanel3;
			this.autoHideContainer3.DockManager = this.dockManager;
			this.autoHideContainer3.Location = new System.Drawing.Point(0, 0);
			this.autoHideContainer3.Name = "autoHideContainer3";
			this.autoHideContainer3.Size = new System.Drawing.Size(0, 0);
			this.autoHideContainer3.TabIndex = 6;
			// 
			// autoHideTabStripPanel4
			// 
			this.autoHideTabStripPanel4.AllowDrop = true;
			this.autoHideTabStripPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.autoHideTabStripPanel4.DockManager = this.dockManager;
			this.autoHideTabStripPanel4.Location = new System.Drawing.Point(6, 594);
			this.autoHideTabStripPanel4.Name = "autoHideTabStripPanel4";
			this.autoHideTabStripPanel4.Size = new System.Drawing.Size(788, 6);
			this.autoHideTabStripPanel4.TabIndex = 7;
			// 
			// autoHideContainer4
			// 
			this.autoHideContainer4.AutoHideTabStripPanel = this.autoHideTabStripPanel4;
			this.autoHideContainer4.DockManager = this.dockManager;
			this.autoHideContainer4.Location = new System.Drawing.Point(0, 0);
			this.autoHideContainer4.Name = "autoHideContainer4";
			this.autoHideContainer4.Size = new System.Drawing.Size(0, 0);
			this.autoHideContainer4.TabIndex = 8;
			// 
			// resultsToolWindow
			// 
			this.resultsToolWindow.CanClose = ActiproSoftware.UI.WinForms.DefaultableBoolean.False;
			this.resultsToolWindow.Controls.Add(this.resultsTextBox);
			this.resultsToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsToolWindow.DockedSize = new System.Drawing.Size(200, 132);
			this.resultsToolWindow.DockManager = this.dockManager;
			this.resultsToolWindow.Location = new System.Drawing.Point(1, 28);
			this.resultsToolWindow.Name = "resultsToolWindow";
			this.resultsToolWindow.Size = new System.Drawing.Size(786, 109);
			this.resultsToolWindow.TabIndex = 0;
			this.resultsToolWindow.Text = "Find Results";
			// 
			// resultsTextBox
			// 
			this.resultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.resultsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsTextBox.Location = new System.Drawing.Point(0, 0);
			this.resultsTextBox.Multiline = true;
			this.resultsTextBox.Name = "resultsTextBox";
			this.resultsTextBox.ReadOnly = true;
			this.resultsTextBox.Size = new System.Drawing.Size(786, 109);
			this.resultsTextBox.TabIndex = 0;
			this.resultsTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnResultsTextBoxMouseDoubleClick);
			// 
			// toolWindowContainer2
			// 
			this.toolWindowContainer2.Controls.Add(this.resultsToolWindow);
			this.toolWindowContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolWindowContainer2.DockManager = this.dockManager;
			this.toolWindowContainer2.Location = new System.Drawing.Point(6, 456);
			this.toolWindowContainer2.Name = "toolWindowContainer2";
			this.toolWindowContainer2.Size = new System.Drawing.Size(788, 138);
			this.toolWindowContainer2.TabIndex = 10;
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.editor);
			this.Controls.Add(this.toolWindowContainer2);
			this.Controls.Add(this.autoHideContainer3);
			this.Controls.Add(this.autoHideContainer4);
			this.Controls.Add(this.autoHideTabStripPanel2);
			this.Controls.Add(this.autoHideTabStripPanel4);
			this.Controls.Add(this.autoHideTabStripPanel3);
			this.Controls.Add(this.autoHideTabStripPanel1);
			this.Controls.Add(this.autoHideContainer1);
			this.Controls.Add(this.autoHideContainer2);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
			this.resultsToolWindow.ResumeLayout(false);
			this.resultsToolWindow.PerformLayout();
			this.toolWindowContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow resultsToolWindow;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer2;
		private System.Windows.Forms.TextBox resultsTextBox;
	}
}
