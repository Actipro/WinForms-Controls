namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.WebAddonXmlEditor {
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
			this.requestIntelliPromptCompletionSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.requestIntelliPromptQuickInfoSessionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.requestIntelliPromptAutoCompleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.commentLinesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.uncommentLinesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.formatDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.formatSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.openSchemaToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.closeSchemaToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openXhtmlSchemaToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openXsdSchemaToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openXsltSchemaToolStripButton = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.astOutputToolWindow.SuspendLayout();
			this.toolWindowContainer1.SuspendLayout();
			this.errorToolWindow.SuspendLayout();
			this.toolWindowContainer2.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// dockManager
			// 
			this.dockManager.DocumentMdiStyle = ActiproSoftware.UI.WinForms.Controls.Docking.DocumentMdiStyle.Tabbed;
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
			this.autoHideContainer1.Location = new System.Drawing.Point(6, 25);
			this.autoHideContainer1.Name = "autoHideContainer1";
			this.autoHideContainer1.Size = new System.Drawing.Size(1, 575);
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
			this.autoHideContainer2.Location = new System.Drawing.Point(6, 31);
			this.autoHideContainer2.Name = "autoHideContainer2";
			this.autoHideContainer2.Size = new System.Drawing.Size(788, 1);
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
			this.autoHideContainer3.Location = new System.Drawing.Point(793, 25);
			this.autoHideContainer3.Name = "autoHideContainer3";
			this.autoHideContainer3.Size = new System.Drawing.Size(1, 575);
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
			this.autoHideContainer4.Location = new System.Drawing.Point(6, 593);
			this.autoHideContainer4.Name = "autoHideContainer4";
			this.autoHideContainer4.Size = new System.Drawing.Size(788, 1);
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
            this.openSchemaToolStripButton,
            this.openXhtmlSchemaToolStripButton,
            this.openXsdSchemaToolStripButton,
            this.openXsltSchemaToolStripButton,
            this.closeSchemaToolStripButton,
            this.toolStripSeparator4,
            this.requestIntelliPromptCompletionSessionToolStripButton,
            this.requestIntelliPromptQuickInfoSessionToolStripButton,
            this.requestIntelliPromptAutoCompleteToolStripButton,
            this.toolStripSeparator2,
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
			// requestIntelliPromptCompletionSessionToolStripButton
			// 
			this.requestIntelliPromptCompletionSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.requestIntelliPromptCompletionSessionToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconIntelliPromptCompletion16;
			this.requestIntelliPromptCompletionSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.requestIntelliPromptCompletionSessionToolStripButton.Name = "requestIntelliPromptCompletionSessionToolStripButton";
			this.requestIntelliPromptCompletionSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.requestIntelliPromptCompletionSessionToolStripButton.Text = "toolStripButton1";
			this.requestIntelliPromptCompletionSessionToolStripButton.ToolTipText = "Display an Object Member List";
			// 
			// requestIntelliPromptQuickInfoSessionToolStripButton
			// 
			this.requestIntelliPromptQuickInfoSessionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.requestIntelliPromptQuickInfoSessionToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconIntelliPromptQuickInfo16;
			this.requestIntelliPromptQuickInfoSessionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.requestIntelliPromptQuickInfoSessionToolStripButton.Name = "requestIntelliPromptQuickInfoSessionToolStripButton";
			this.requestIntelliPromptQuickInfoSessionToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.requestIntelliPromptQuickInfoSessionToolStripButton.Text = "toolStripButton1";
			this.requestIntelliPromptQuickInfoSessionToolStripButton.ToolTipText = "Display Quick Info";
			// 
			// requestIntelliPromptAutoCompleteToolStripButton
			// 
			this.requestIntelliPromptAutoCompleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.requestIntelliPromptAutoCompleteToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconIntelliPromptAutoComplete16;
			this.requestIntelliPromptAutoCompleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.requestIntelliPromptAutoCompleteToolStripButton.Name = "requestIntelliPromptAutoCompleteToolStripButton";
			this.requestIntelliPromptAutoCompleteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.requestIntelliPromptAutoCompleteToolStripButton.Text = "toolStripButton1";
			this.requestIntelliPromptAutoCompleteToolStripButton.ToolTipText = "Display Word Completion";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// openSchemaToolStripButton
			// 
			this.openSchemaToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconOpen16;
			this.openSchemaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openSchemaToolStripButton.Name = "openSchemaToolStripButton";
			this.openSchemaToolStripButton.Size = new System.Drawing.Size(101, 22);
			this.openSchemaToolStripButton.Text = "Open Schema";
			// 
			// closeSchemaToolStripButton
			// 
			this.closeSchemaToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconClose16;
			this.closeSchemaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.closeSchemaToolStripButton.Name = "closeSchemaToolStripButton";
			this.closeSchemaToolStripButton.Size = new System.Drawing.Size(101, 22);
			this.closeSchemaToolStripButton.Text = "Close Schema";
			// 
			// openXhtmlSchemaToolStripButton
			// 
			this.openXhtmlSchemaToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconXmlSchema16;
			this.openXhtmlSchemaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openXhtmlSchemaToolStripButton.Name = "openXhtmlSchemaToolStripButton";
			this.openXhtmlSchemaToolStripButton.Size = new System.Drawing.Size(66, 22);
			this.openXhtmlSchemaToolStripButton.Text = "XHTML";
			// 
			// openXsdSchemaToolStripButton
			// 
			this.openXsdSchemaToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconXmlSchema16;
			this.openXsdSchemaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openXsdSchemaToolStripButton.Name = "openXsdSchemaToolStripButton";
			this.openXsdSchemaToolStripButton.Size = new System.Drawing.Size(48, 22);
			this.openXsdSchemaToolStripButton.Text = "XSD";
			// 
			// openXsltSchemaToolStripButton
			// 
			this.openXsltSchemaToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconXmlSchema16;
			this.openXsltSchemaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openXsltSchemaToolStripButton.Name = "openXsltSchemaToolStripButton";
			this.openXsltSchemaToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.openXsltSchemaToolStripButton.Text = "XSLT";
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
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
		private System.Windows.Forms.ToolStripButton requestIntelliPromptCompletionSessionToolStripButton;
		private System.Windows.Forms.ToolStripButton requestIntelliPromptQuickInfoSessionToolStripButton;
		private System.Windows.Forms.ToolStripButton requestIntelliPromptAutoCompleteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton commentLinesToolStripButton;
		private System.Windows.Forms.ToolStripButton uncommentLinesToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton formatDocumentToolStripButton;
		private System.Windows.Forms.ToolStripButton formatSelectionToolStripButton;
		private System.Windows.Forms.ToolStripButton openSchemaToolStripButton;
		private System.Windows.Forms.ToolStripButton openXhtmlSchemaToolStripButton;
		private System.Windows.Forms.ToolStripButton openXsdSchemaToolStripButton;
		private System.Windows.Forms.ToolStripButton openXsltSchemaToolStripButton;
		private System.Windows.Forms.ToolStripButton closeSchemaToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}
