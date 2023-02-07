namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted06 {
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
			this.errorToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
			this.errorListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolWindowContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.errorToolWindow.SuspendLayout();
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
			this.editor.DocumentParseDataChanged += new System.EventHandler(this.OnCodeEditorDocumentParseDataChanged);
			this.editor.UserInterfaceUpdate += new System.EventHandler(this.OnCodeEditorUserInterfaceUpdate);
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
			// errorToolWindow
			// 
			this.errorToolWindow.Controls.Add(this.errorListView);
			this.errorToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorToolWindow.DockedSize = new System.Drawing.Size(200, 132);
			this.errorToolWindow.DockManager = this.dockManager;
			this.errorToolWindow.Location = new System.Drawing.Point(1, 28);
			this.errorToolWindow.Name = "errorToolWindow";
			this.errorToolWindow.Size = new System.Drawing.Size(786, 109);
			this.errorToolWindow.TabIndex = 0;
			this.errorToolWindow.Text = "Error List";
			// 
			// errorListView
			// 
			this.errorListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.errorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.errorListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorListView.FullRowSelect = true;
			this.errorListView.HideSelection = false;
			this.errorListView.Location = new System.Drawing.Point(0, 0);
			this.errorListView.Name = "errorListView";
			this.errorListView.Size = new System.Drawing.Size(786, 109);
			this.errorListView.TabIndex = 0;
			this.errorListView.UseCompatibleStateImageBehavior = false;
			this.errorListView.View = System.Windows.Forms.View.Details;
			this.errorListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnErrorListViewMouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Line";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Char";
			this.columnHeader2.Width = 40;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Description";
			this.columnHeader3.Width = 450;
			// 
			// toolWindowContainer2
			// 
			this.toolWindowContainer2.Controls.Add(this.errorToolWindow);
			this.toolWindowContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolWindowContainer2.DockManager = this.dockManager;
			this.toolWindowContainer2.Location = new System.Drawing.Point(6, 456);
			this.toolWindowContainer2.Name = "toolWindowContainer2";
			this.toolWindowContainer2.Size = new System.Drawing.Size(788, 138);
			this.toolWindowContainer2.TabIndex = 10;
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
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
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
			this.errorToolWindow.ResumeLayout(false);
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
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow errorToolWindow;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer2;
		private System.Windows.Forms.ListView errorListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}
