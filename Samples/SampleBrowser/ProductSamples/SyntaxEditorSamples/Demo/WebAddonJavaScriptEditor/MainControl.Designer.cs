namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonJavaScriptEditor {
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
			this.codeEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			this.dockManager = new ActiproSoftware.UI.WinForms.Controls.Docking.DockManager(this.components);
			this.autoHideTabStripPanel1 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel2 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel3 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer3 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.autoHideTabStripPanel4 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel();
			this.autoHideContainer4 = new ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer();
			this.astOutputToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
			this.astOutputEditor = new System.Windows.Forms.TextBox();
			this.toolWindowContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
			this.errorToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
			this.errorListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolWindowContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.newDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.commentLinesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.uncommentLinesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.formatDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.formatSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.astOutputToolWindow.SuspendLayout();
			this.toolWindowContainer1.SuspendLayout();
			this.errorToolWindow.SuspendLayout();
			this.toolWindowContainer2.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// codeEditor
			// 
			this.codeEditor.AllowDrop = true;
			this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codeEditor.IsLineNumberMarginVisible = true;
			this.codeEditor.Location = new System.Drawing.Point(6, 31);
			this.codeEditor.Name = "codeEditor";
			this.codeEditor.Size = new System.Drawing.Size(582, 425);
			this.codeEditor.TabIndex = 0;
			this.codeEditor.Text = resources.GetString("codeEditor.Text");
			this.codeEditor.DocumentParseDataChanged += new System.EventHandler(this.OnCodeEditorDocumentParseDataChanged);
			this.codeEditor.UserInterfaceUpdate += new System.EventHandler(this.OnCodeEditorUserInterfaceUpdate);
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
			this.autoHideTabStripPanel1.Location = new System.Drawing.Point(0, 25);
			this.autoHideTabStripPanel1.Name = "autoHideTabStripPanel1";
			this.autoHideTabStripPanel1.Size = new System.Drawing.Size(6, 575);
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
			this.autoHideTabStripPanel2.Location = new System.Drawing.Point(6, 25);
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
			this.autoHideTabStripPanel3.Location = new System.Drawing.Point(794, 25);
			this.autoHideTabStripPanel3.Name = "autoHideTabStripPanel3";
			this.autoHideTabStripPanel3.Size = new System.Drawing.Size(6, 575);
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
			// astOutputToolWindow
			// 
			this.astOutputToolWindow.Controls.Add(this.astOutputEditor);
			this.astOutputToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.astOutputToolWindow.DockManager = this.dockManager;
			this.astOutputToolWindow.Location = new System.Drawing.Point(7, 22);
			this.astOutputToolWindow.Name = "astOutputToolWindow";
			this.astOutputToolWindow.Size = new System.Drawing.Size(198, 540);
			this.astOutputToolWindow.TabIndex = 0;
			this.astOutputToolWindow.Text = "Document Outline";
			// 
			// astOutputEditor
			// 
			this.astOutputEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.astOutputEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.astOutputEditor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.astOutputEditor.Location = new System.Drawing.Point(0, 0);
			this.astOutputEditor.Multiline = true;
			this.astOutputEditor.Name = "astOutputEditor";
			this.astOutputEditor.ReadOnly = true;
			this.astOutputEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.astOutputEditor.Size = new System.Drawing.Size(198, 540);
			this.astOutputEditor.TabIndex = 0;
			this.astOutputEditor.WordWrap = false;
			// 
			// toolWindowContainer1
			// 
			this.toolWindowContainer1.Controls.Add(this.astOutputToolWindow);
			this.toolWindowContainer1.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolWindowContainer1.DockManager = this.dockManager;
			this.toolWindowContainer1.Location = new System.Drawing.Point(588, 31);
			this.toolWindowContainer1.Name = "toolWindowContainer1";
			this.toolWindowContainer1.Size = new System.Drawing.Size(206, 563);
			this.toolWindowContainer1.TabIndex = 9;
			// 
			// errorToolWindow
			// 
			this.errorToolWindow.Controls.Add(this.errorListView);
			this.errorToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorToolWindow.DockedSize = new System.Drawing.Size(200, 132);
			this.errorToolWindow.DockManager = this.dockManager;
			this.errorToolWindow.Location = new System.Drawing.Point(1, 28);
			this.errorToolWindow.Name = "errorToolWindow";
			this.errorToolWindow.Size = new System.Drawing.Size(580, 109);
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
			this.errorListView.Size = new System.Drawing.Size(580, 109);
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
			this.toolWindowContainer2.Size = new System.Drawing.Size(582, 138);
			this.toolWindowContainer2.TabIndex = 10;
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDocumentToolStripButton,
            this.openDocumentToolStripButton,
            this.toolStripSeparator1,
            this.commentLinesToolStripButton,
            this.uncommentLinesToolStripButton,
            this.toolStripSeparator3,
            this.formatDocumentToolStripButton,
            this.formatSelectionToolStripButton});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(800, 25);
			this.mainToolStrip.TabIndex = 11;
			this.mainToolStrip.Text = "toolStrip1";
			this.mainToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnMainToolStripItemClicked);
			// 
			// newDocumentToolStripButton
			// 
			this.newDocumentToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconNew16;
			this.newDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newDocumentToolStripButton.Name = "newDocumentToolStripButton";
			this.newDocumentToolStripButton.Size = new System.Drawing.Size(110, 22);
			this.newDocumentToolStripButton.Text = "New Document";
			// 
			// openDocumentToolStripButton
			// 
			this.openDocumentToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconOpen16;
			this.openDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openDocumentToolStripButton.Name = "openDocumentToolStripButton";
			this.openDocumentToolStripButton.Size = new System.Drawing.Size(115, 22);
			this.openDocumentToolStripButton.Text = "Open Document";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// commentLinesToolStripButton
			// 
			this.commentLinesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.commentLinesToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconCommentLines16;
			this.commentLinesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.commentLinesToolStripButton.Name = "commentLinesToolStripButton";
			this.commentLinesToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.commentLinesToolStripButton.Text = "toolStripButton1";
			this.commentLinesToolStripButton.ToolTipText = "Comment Selected Lines";
			// 
			// uncommentLinesToolStripButton
			// 
			this.uncommentLinesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.uncommentLinesToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconUncommentLines16;
			this.uncommentLinesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uncommentLinesToolStripButton.Name = "uncommentLinesToolStripButton";
			this.uncommentLinesToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.uncommentLinesToolStripButton.Text = "toolStripButton1";
			this.uncommentLinesToolStripButton.ToolTipText = "Uncomment Selected Lines";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// formatDocumentToolStripButton
			// 
			this.formatDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.formatDocumentToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconFormatDocument16;
			this.formatDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.formatDocumentToolStripButton.Name = "formatDocumentToolStripButton";
			this.formatDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.formatDocumentToolStripButton.Text = "toolStripButton1";
			this.formatDocumentToolStripButton.ToolTipText = "Format Document";
			// 
			// formatSelectionToolStripButton
			// 
			this.formatSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.formatSelectionToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconFormatSelection16;
			this.formatSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.formatSelectionToolStripButton.Name = "formatSelectionToolStripButton";
			this.formatSelectionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.formatSelectionToolStripButton.Text = "toolStripButton1";
			this.formatSelectionToolStripButton.ToolTipText = "Format Selection";
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.codeEditor);
			this.Controls.Add(this.toolWindowContainer2);
			this.Controls.Add(this.autoHideContainer3);
			this.Controls.Add(this.autoHideContainer4);
			this.Controls.Add(this.toolWindowContainer1);
			this.Controls.Add(this.autoHideTabStripPanel2);
			this.Controls.Add(this.autoHideTabStripPanel4);
			this.Controls.Add(this.autoHideTabStripPanel3);
			this.Controls.Add(this.autoHideTabStripPanel1);
			this.Controls.Add(this.autoHideContainer1);
			this.Controls.Add(this.autoHideContainer2);
			this.Controls.Add(this.mainToolStrip);
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
			this.astOutputToolWindow.ResumeLayout(false);
			this.astOutputToolWindow.PerformLayout();
			this.toolWindowContainer1.ResumeLayout(false);
			this.errorToolWindow.ResumeLayout(false);
			this.toolWindowContainer2.ResumeLayout(false);
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor codeEditor;
		private ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow astOutputToolWindow;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer1;
		private System.Windows.Forms.TextBox astOutputEditor;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow errorToolWindow;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer2;
		private System.Windows.Forms.ListView errorListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.ToolStripButton newDocumentToolStripButton;
		private System.Windows.Forms.ToolStripButton openDocumentToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton commentLinesToolStripButton;
		private System.Windows.Forms.ToolStripButton uncommentLinesToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton formatDocumentToolStripButton;
		private System.Windows.Forms.ToolStripButton formatSelectionToolStripButton;
	}
}
