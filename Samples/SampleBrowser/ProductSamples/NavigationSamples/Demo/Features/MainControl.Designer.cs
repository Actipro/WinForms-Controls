using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.NavigationSamples.Demo.Features {
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
			ActiproSoftware.UI.WinForms.Controls.Navigation.Office2003NavigationBarRenderer office2003NavigationBarRenderer1 = new ActiproSoftware.UI.WinForms.Controls.Navigation.Office2003NavigationBarRenderer(ActiproSoftware.UI.WinForms.Drawing.WindowsColorSchemeType.WindowsXPOliveGreen);
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Actipro WinForms Studio", 1, 1);
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Deleted Items", 2, 2);
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Drafts", 3, 3);
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Inbox", 4, 4);
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Junk E-mail", 5, 5);
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Outbox", 6, 6);
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Sent Items", 7, 7);
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Search Folders", 8, 8);
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Personal Folders", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
			this.tabStrip = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip();
			this.navigationBarTabStripPage = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage();
			this.navigationBarPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.navigationBar = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar();
			this.mailNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.allFoldersNavigationBarPanel = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel();
			this.mailTreeView = new System.Windows.Forms.TreeView();
			this.mailImageList = new System.Windows.Forms.ImageList(this.components);
			this.calendarNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.contactsNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.tasksNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.notesNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.folderListNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.shortcutsNavigationPane = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane();
			this.largeImageList = new System.Windows.Forms.ImageList(this.components);
			this.smallImageList = new System.Windows.Forms.ImageList(this.components);
			this.rendererTabStripPage = new ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage();
			this.rendererPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.propertiesImageList = new System.Windows.Forms.ImageList(this.components);
			this.eventsListBox = new System.Windows.Forms.ListBox();
			this.eventsNavigationBarPanel = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel();
			this.changeNavigationBarPanel = new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel();
			this.saveLayoutButton = new System.Windows.Forms.Button();
			this.loadLayoutButton = new System.Windows.Forms.Button();
			this.preventSelectionChangesCheckBox = new System.Windows.Forms.CheckBox();
			this.rendererLabel = new System.Windows.Forms.Label();
			this.rendererDropDownList = new System.Windows.Forms.ComboBox();
			this.panel = new System.Windows.Forms.Panel();
			this.vSplitter2 = new System.Windows.Forms.Splitter();
			this.vSplitter = new System.Windows.Forms.Splitter();
			this.hSplitter = new System.Windows.Forms.Splitter();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.tabStrip)).BeginInit();
			this.tabStrip.SuspendLayout();
			this.navigationBarTabStripPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.navigationBar)).BeginInit();
			this.navigationBar.SuspendLayout();
			this.mailNavigationPane.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allFoldersNavigationBarPanel)).BeginInit();
			this.allFoldersNavigationBarPanel.SuspendLayout();
			this.calendarNavigationPane.SuspendLayout();
			this.rendererTabStripPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.eventsNavigationBarPanel)).BeginInit();
			this.eventsNavigationBarPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.changeNavigationBarPanel)).BeginInit();
			this.changeNavigationBarPanel.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabStrip
			// 
			this.tabStrip.Controls.Add(this.navigationBarTabStripPage);
			this.tabStrip.Controls.Add(this.rendererTabStripPage);
			this.tabStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabStrip.ImageList = this.propertiesImageList;
			this.tabStrip.Location = new System.Drawing.Point(0, 260);
			this.tabStrip.Name = "tabStrip";
			this.tabStrip.Size = new System.Drawing.Size(500, 320);
			this.tabStrip.TabAlignment = ActiproSoftware.UI.WinForms.Controls.Docking.TabStripTabAlignment.Bottom;
			this.tabStrip.TabIndex = 0;
			// 
			// navigationBarTabStripPage
			// 
			this.navigationBarTabStripPage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.navigationBarTabStripPage.Controls.Add(this.navigationBarPropertyGrid);
			this.navigationBarTabStripPage.ImageIndex = 0;
			this.navigationBarTabStripPage.Key = "TabStripPage";
			this.navigationBarTabStripPage.Location = new System.Drawing.Point(1, 1);
			this.navigationBarTabStripPage.Name = "navigationBarTabStripPage";
			this.navigationBarTabStripPage.Size = new System.Drawing.Size(498, 298);
			this.navigationBarTabStripPage.TabIndex = 0;
			this.navigationBarTabStripPage.Text = "NavigationBar";
			// 
			// navigationBarPropertyGrid
			// 
			this.navigationBarPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationBarPropertyGrid.HelpVisible = false;
			this.navigationBarPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.navigationBarPropertyGrid.Location = new System.Drawing.Point(0, 0);
			this.navigationBarPropertyGrid.Name = "navigationBarPropertyGrid";
			this.navigationBarPropertyGrid.SelectedObject = this.navigationBar;
			this.navigationBarPropertyGrid.Size = new System.Drawing.Size(498, 298);
			this.navigationBarPropertyGrid.TabIndex = 0;
			this.navigationBarPropertyGrid.ToolbarVisible = false;
			// 
			// navigationBar
			// 
			this.navigationBar.Controls.Add(this.mailNavigationPane);
			this.navigationBar.Controls.Add(this.calendarNavigationPane);
			this.navigationBar.Controls.Add(this.contactsNavigationPane);
			this.navigationBar.Controls.Add(this.tasksNavigationPane);
			this.navigationBar.Controls.Add(this.notesNavigationPane);
			this.navigationBar.Controls.Add(this.folderListNavigationPane);
			this.navigationBar.Controls.Add(this.shortcutsNavigationPane);
			this.navigationBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationBar.LargeImageList = this.largeImageList;
			this.navigationBar.Location = new System.Drawing.Point(10, 10);
			this.navigationBar.MaximumBarButtonCount = 3;
			this.navigationBar.Name = "navigationBar";
			office2003NavigationBarRenderer1.NavigationBarSplitterBackgroundFill = new ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradient(System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(131)))), ((int)(((byte)(82))))), System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(72)))), ((int)(((byte)(49))))), 90F, ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradientStyle.Normal, ActiproSoftware.UI.WinForms.Drawing.BackgroundFillRotationType.None);
			office2003NavigationBarRenderer1.NavigationPaneDefaultButtonBackgroundFill = new ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradient(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(193)))), ((int)(((byte)(163))))), System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(168)))), ((int)(((byte)(128))))), 90F, ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradientStyle.Normal, ActiproSoftware.UI.WinForms.Drawing.BackgroundFillRotationType.None);
			this.navigationBar.Renderer = office2003NavigationBarRenderer1;
			this.navigationBar.Size = new System.Drawing.Size(273, 580);
			this.navigationBar.SmallImageList = this.smallImageList;
			this.navigationBar.TabIndex = 100;
			this.navigationBar.ContextMenuRequested += new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarContextMenuEventHandler(this.navigationBar_ContextMenuRequested);
			this.navigationBar.MaximumBarButtonCountChanged += new System.EventHandler(this.navigationBar_MaximumBarButtonCountChanged);
			this.navigationBar.NavigationPaneActiveChanging += new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPaneCancelEventHandler(this.navigationBar_NavigationPaneActiveChanging);
			this.navigationBar.NavigationPanesReordered += new System.EventHandler(this.navigationBar_NavigationPanesReordered);
			this.navigationBar.SelectionChanged += new System.EventHandler(this.navigationBar_SelectionChanged);
			this.navigationBar.SelectionChanging += new ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPaneCancelEventHandler(this.navigationBar_SelectionChanging);
			// 
			// mailNavigationPane
			// 
			this.mailNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.mailNavigationPane.Controls.Add(this.allFoldersNavigationBarPanel);
			this.mailNavigationPane.ImageIndex = 0;
			this.mailNavigationPane.Key = "Mail";
			this.mailNavigationPane.Location = new System.Drawing.Point(1, 26);
			this.mailNavigationPane.Name = "mailNavigationPane";
			this.mailNavigationPane.Size = new System.Drawing.Size(271, 419);
			this.mailNavigationPane.TabIndex = 0;
			this.mailNavigationPane.Text = "Mail";
			// 
			// allFoldersNavigationBarPanel
			// 
			this.allFoldersNavigationBarPanel.Controls.Add(this.mailTreeView);
			this.allFoldersNavigationBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.allFoldersNavigationBarPanel.Location = new System.Drawing.Point(0, 0);
			this.allFoldersNavigationBarPanel.Name = "allFoldersNavigationBarPanel";
			this.allFoldersNavigationBarPanel.Size = new System.Drawing.Size(271, 419);
			this.allFoldersNavigationBarPanel.Style = ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanelStyle.SubHeader;
			this.allFoldersNavigationBarPanel.TabIndex = 1;
			this.allFoldersNavigationBarPanel.TabStop = false;
			this.allFoldersNavigationBarPanel.Text = "All Folders";
			// 
			// mailTreeView
			// 
			this.mailTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mailTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mailTreeView.ImageIndex = 0;
			this.mailTreeView.ImageList = this.mailImageList;
			this.mailTreeView.Location = new System.Drawing.Point(0, 21);
			this.mailTreeView.Name = "mailTreeView";
			treeNode1.ImageIndex = 1;
			treeNode1.Name = "";
			treeNode1.SelectedImageIndex = 1;
			treeNode1.Text = "Actipro WinForms Studio";
			treeNode2.ImageIndex = 2;
			treeNode2.Name = "";
			treeNode2.SelectedImageIndex = 2;
			treeNode2.Text = "Deleted Items";
			treeNode3.ImageIndex = 3;
			treeNode3.Name = "";
			treeNode3.SelectedImageIndex = 3;
			treeNode3.Text = "Drafts";
			treeNode4.ImageIndex = 4;
			treeNode4.Name = "";
			treeNode4.SelectedImageIndex = 4;
			treeNode4.Text = "Inbox";
			treeNode5.ImageIndex = 5;
			treeNode5.Name = "";
			treeNode5.SelectedImageIndex = 5;
			treeNode5.Text = "Junk E-mail";
			treeNode6.ImageIndex = 6;
			treeNode6.Name = "";
			treeNode6.SelectedImageIndex = 6;
			treeNode6.Text = "Outbox";
			treeNode7.ImageIndex = 7;
			treeNode7.Name = "";
			treeNode7.SelectedImageIndex = 7;
			treeNode7.Text = "Sent Items";
			treeNode8.ImageIndex = 8;
			treeNode8.Name = "";
			treeNode8.SelectedImageIndex = 8;
			treeNode8.Text = "Search Folders";
			treeNode9.Name = "";
			treeNode9.Text = "Personal Folders";
			this.mailTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
			this.mailTreeView.Scrollable = false;
			this.mailTreeView.SelectedImageIndex = 0;
			this.mailTreeView.Size = new System.Drawing.Size(271, 398);
			this.mailTreeView.TabIndex = 0;
			// 
			// mailImageList
			// 
			this.mailImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mailImageList.ImageStream")));
			this.mailImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.mailImageList.Images.SetKeyName(0, "");
			this.mailImageList.Images.SetKeyName(1, "");
			this.mailImageList.Images.SetKeyName(2, "");
			this.mailImageList.Images.SetKeyName(3, "");
			this.mailImageList.Images.SetKeyName(4, "");
			this.mailImageList.Images.SetKeyName(5, "");
			this.mailImageList.Images.SetKeyName(6, "");
			this.mailImageList.Images.SetKeyName(7, "");
			this.mailImageList.Images.SetKeyName(8, "");
			// 
			// calendarNavigationPane
			// 
			this.calendarNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.calendarNavigationPane.Controls.Add(this.monthCalendar1);
			this.calendarNavigationPane.DefaultSortOrder = 1;
			this.calendarNavigationPane.ImageIndex = 1;
			this.calendarNavigationPane.Key = "Calendar";
			this.calendarNavigationPane.Location = new System.Drawing.Point(667, 3502);
			this.calendarNavigationPane.Name = "calendarNavigationPane";
			this.calendarNavigationPane.Size = new System.Drawing.Size(239, 493);
			this.calendarNavigationPane.TabIndex = 1;
			this.calendarNavigationPane.Text = "Calendar";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(32, 24);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 0;
			// 
			// contactsNavigationPane
			// 
			this.contactsNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.contactsNavigationPane.DefaultSortOrder = 2;
			this.contactsNavigationPane.ImageIndex = 2;
			this.contactsNavigationPane.Key = "Contacts";
			this.contactsNavigationPane.Location = new System.Drawing.Point(667, 4030);
			this.contactsNavigationPane.Name = "contactsNavigationPane";
			this.contactsNavigationPane.Size = new System.Drawing.Size(239, 461);
			this.contactsNavigationPane.TabIndex = 2;
			this.contactsNavigationPane.Text = "Contacts";
			// 
			// tasksNavigationPane
			// 
			this.tasksNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tasksNavigationPane.DefaultSortOrder = 3;
			this.tasksNavigationPane.ImageIndex = 3;
			this.tasksNavigationPane.Key = "Tasks";
			this.tasksNavigationPane.Location = new System.Drawing.Point(667, 4590);
			this.tasksNavigationPane.Name = "tasksNavigationPane";
			this.tasksNavigationPane.Size = new System.Drawing.Size(239, 429);
			this.tasksNavigationPane.TabIndex = 3;
			this.tasksNavigationPane.Text = "Tasks";
			// 
			// notesNavigationPane
			// 
			this.notesNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.notesNavigationPane.DefaultSortOrder = 4;
			this.notesNavigationPane.ImageIndex = 4;
			this.notesNavigationPane.Key = "Notes";
			this.notesNavigationPane.Location = new System.Drawing.Point(51, 24);
			this.notesNavigationPane.Name = "notesNavigationPane";
			this.notesNavigationPane.Size = new System.Drawing.Size(237, 423);
			this.notesNavigationPane.TabIndex = 4;
			this.notesNavigationPane.Text = "Notes";
			// 
			// folderListNavigationPane
			// 
			this.folderListNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.folderListNavigationPane.DefaultSortOrder = 5;
			this.folderListNavigationPane.Enabled = false;
			this.folderListNavigationPane.ImageIndex = 5;
			this.folderListNavigationPane.Key = "Folder List";
			this.folderListNavigationPane.Location = new System.Drawing.Point(667, 5118);
			this.folderListNavigationPane.Name = "folderListNavigationPane";
			this.folderListNavigationPane.Size = new System.Drawing.Size(239, 429);
			this.folderListNavigationPane.TabIndex = 6;
			this.folderListNavigationPane.Text = "Folder List";
			// 
			// shortcutsNavigationPane
			// 
			this.shortcutsNavigationPane.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.shortcutsNavigationPane.DefaultSortOrder = 6;
			this.shortcutsNavigationPane.ImageIndex = 6;
			this.shortcutsNavigationPane.Key = "Shortcuts";
			this.shortcutsNavigationPane.Location = new System.Drawing.Point(667, 5118);
			this.shortcutsNavigationPane.Name = "shortcutsNavigationPane";
			this.shortcutsNavigationPane.Size = new System.Drawing.Size(239, 429);
			this.shortcutsNavigationPane.TabIndex = 5;
			this.shortcutsNavigationPane.Text = "Shortcuts";
			// 
			// largeImageList
			// 
			this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
			this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.largeImageList.Images.SetKeyName(0, "");
			this.largeImageList.Images.SetKeyName(1, "");
			this.largeImageList.Images.SetKeyName(2, "");
			this.largeImageList.Images.SetKeyName(3, "");
			this.largeImageList.Images.SetKeyName(4, "");
			this.largeImageList.Images.SetKeyName(5, "");
			this.largeImageList.Images.SetKeyName(6, "");
			// 
			// smallImageList
			// 
			this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
			this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.smallImageList.Images.SetKeyName(0, "");
			this.smallImageList.Images.SetKeyName(1, "");
			this.smallImageList.Images.SetKeyName(2, "");
			this.smallImageList.Images.SetKeyName(3, "");
			this.smallImageList.Images.SetKeyName(4, "");
			this.smallImageList.Images.SetKeyName(5, "");
			this.smallImageList.Images.SetKeyName(6, "");
			// 
			// rendererTabStripPage
			// 
			this.rendererTabStripPage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.rendererTabStripPage.Controls.Add(this.rendererPropertyGrid);
			this.rendererTabStripPage.ImageIndex = 1;
			this.rendererTabStripPage.Key = "TabStripPage";
			this.rendererTabStripPage.Location = new System.Drawing.Point(1, 1);
			this.rendererTabStripPage.Name = "rendererTabStripPage";
			this.rendererTabStripPage.Size = new System.Drawing.Size(498, 298);
			this.rendererTabStripPage.TabIndex = 1;
			this.rendererTabStripPage.Text = "Renderer";
			// 
			// rendererPropertyGrid
			// 
			this.rendererPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rendererPropertyGrid.HelpVisible = false;
			this.rendererPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.rendererPropertyGrid.Location = new System.Drawing.Point(0, 0);
			this.rendererPropertyGrid.Name = "rendererPropertyGrid";
			this.rendererPropertyGrid.Size = new System.Drawing.Size(498, 298);
			this.rendererPropertyGrid.TabIndex = 0;
			this.rendererPropertyGrid.ToolbarVisible = false;
			// 
			// propertiesImageList
			// 
			this.propertiesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("propertiesImageList.ImageStream")));
			this.propertiesImageList.TransparentColor = System.Drawing.Color.Lime;
			this.propertiesImageList.Images.SetKeyName(0, "");
			this.propertiesImageList.Images.SetKeyName(1, "");
			// 
			// eventsListBox
			// 
			this.eventsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.eventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventsListBox.IntegralHeight = false;
			this.eventsListBox.ItemHeight = 15;
			this.eventsListBox.Location = new System.Drawing.Point(1, 31);
			this.eventsListBox.Name = "eventsListBox";
			this.eventsListBox.Size = new System.Drawing.Size(498, 99);
			this.eventsListBox.TabIndex = 2;
			// 
			// eventsNavigationBarPanel
			// 
			this.eventsNavigationBarPanel.Controls.Add(this.eventsListBox);
			this.eventsNavigationBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventsNavigationBarPanel.Image = ((System.Drawing.Image)(resources.GetObject("eventsNavigationBarPanel.Image")));
			this.eventsNavigationBarPanel.Location = new System.Drawing.Point(0, 122);
			this.eventsNavigationBarPanel.Name = "eventsNavigationBarPanel";
			this.eventsNavigationBarPanel.Size = new System.Drawing.Size(500, 131);
			this.eventsNavigationBarPanel.Style = ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanelStyle.Header;
			this.eventsNavigationBarPanel.TabIndex = 6;
			this.eventsNavigationBarPanel.TabStop = false;
			this.eventsNavigationBarPanel.Text = "Events";
			// 
			// changeNavigationBarPanel
			// 
			this.changeNavigationBarPanel.Controls.Add(this.saveLayoutButton);
			this.changeNavigationBarPanel.Controls.Add(this.loadLayoutButton);
			this.changeNavigationBarPanel.Controls.Add(this.preventSelectionChangesCheckBox);
			this.changeNavigationBarPanel.Controls.Add(this.rendererLabel);
			this.changeNavigationBarPanel.Controls.Add(this.rendererDropDownList);
			this.changeNavigationBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.changeNavigationBarPanel.Location = new System.Drawing.Point(0, 0);
			this.changeNavigationBarPanel.Name = "changeNavigationBarPanel";
			this.changeNavigationBarPanel.Size = new System.Drawing.Size(500, 115);
			this.changeNavigationBarPanel.TabIndex = 8;
			this.changeNavigationBarPanel.TabStop = false;
			// 
			// saveLayoutButton
			// 
			this.saveLayoutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.saveLayoutButton.Location = new System.Drawing.Point(153, 74);
			this.saveLayoutButton.Name = "saveLayoutButton";
			this.saveLayoutButton.Size = new System.Drawing.Size(75, 23);
			this.saveLayoutButton.TabIndex = 3;
			this.saveLayoutButton.Text = "Save Layout";
			this.saveLayoutButton.Click += new System.EventHandler(this.saveLayoutButton_Click);
			// 
			// loadLayoutButton
			// 
			this.loadLayoutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.loadLayoutButton.Location = new System.Drawing.Point(72, 74);
			this.loadLayoutButton.Name = "loadLayoutButton";
			this.loadLayoutButton.Size = new System.Drawing.Size(75, 23);
			this.loadLayoutButton.TabIndex = 2;
			this.loadLayoutButton.Text = "Load Layout";
			this.loadLayoutButton.Click += new System.EventHandler(this.loadLayoutButton_Click);
			// 
			// preventSelectionChangesCheckBox
			// 
			this.preventSelectionChangesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.preventSelectionChangesCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.preventSelectionChangesCheckBox.Location = new System.Drawing.Point(72, 44);
			this.preventSelectionChangesCheckBox.Name = "preventSelectionChangesCheckBox";
			this.preventSelectionChangesCheckBox.Size = new System.Drawing.Size(408, 24);
			this.preventSelectionChangesCheckBox.TabIndex = 1;
			this.preventSelectionChangesCheckBox.Text = "Prevent selection changes";
			this.preventSelectionChangesCheckBox.UseVisualStyleBackColor = false;
			// 
			// rendererLabel
			// 
			this.rendererLabel.AutoSize = true;
			this.rendererLabel.BackColor = System.Drawing.Color.Transparent;
			this.rendererLabel.Location = new System.Drawing.Point(16, 21);
			this.rendererLabel.Name = "rendererLabel";
			this.rendererLabel.Size = new System.Drawing.Size(54, 15);
			this.rendererLabel.TabIndex = 1;
			this.rendererLabel.Text = "Renderer";
			// 
			// rendererDropDownList
			// 
			this.rendererDropDownList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rendererDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rendererDropDownList.Location = new System.Drawing.Point(72, 16);
			this.rendererDropDownList.Name = "rendererDropDownList";
			this.rendererDropDownList.Size = new System.Drawing.Size(412, 23);
			this.rendererDropDownList.TabIndex = 0;
			this.rendererDropDownList.SelectedIndexChanged += new System.EventHandler(this.rendererDropDownList_SelectedIndexChanged);
			// 
			// panel
			// 
			this.panel.Controls.Add(this.eventsNavigationBarPanel);
			this.panel.Controls.Add(this.vSplitter2);
			this.panel.Controls.Add(this.vSplitter);
			this.panel.Controls.Add(this.tabStrip);
			this.panel.Controls.Add(this.changeNavigationBarPanel);
			this.panel.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel.Location = new System.Drawing.Point(290, 10);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(500, 580);
			this.panel.TabIndex = 101;
			// 
			// vSplitter2
			// 
			this.vSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.vSplitter2.Location = new System.Drawing.Point(0, 253);
			this.vSplitter2.Name = "vSplitter2";
			this.vSplitter2.Size = new System.Drawing.Size(500, 7);
			this.vSplitter2.TabIndex = 9;
			this.vSplitter2.TabStop = false;
			// 
			// vSplitter
			// 
			this.vSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.vSplitter.Enabled = false;
			this.vSplitter.Location = new System.Drawing.Point(0, 115);
			this.vSplitter.Name = "vSplitter";
			this.vSplitter.Size = new System.Drawing.Size(500, 7);
			this.vSplitter.TabIndex = 8;
			this.vSplitter.TabStop = false;
			// 
			// hSplitter
			// 
			this.hSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.hSplitter.Location = new System.Drawing.Point(283, 10);
			this.hSplitter.Name = "hSplitter";
			this.hSplitter.Size = new System.Drawing.Size(7, 580);
			this.hSplitter.TabIndex = 102;
			this.hSplitter.TabStop = false;
			// 
			// MainControl
			// 
			this.Controls.Add(this.navigationBar);
			this.Controls.Add(this.hSplitter);
			this.Controls.Add(this.panel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainControl";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.tabStrip)).EndInit();
			this.tabStrip.ResumeLayout(false);
			this.navigationBarTabStripPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.navigationBar)).EndInit();
			this.navigationBar.ResumeLayout(false);
			this.mailNavigationPane.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.allFoldersNavigationBarPanel)).EndInit();
			this.allFoldersNavigationBarPanel.ResumeLayout(false);
			this.calendarNavigationPane.ResumeLayout(false);
			this.rendererTabStripPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.eventsNavigationBarPanel)).EndInit();
			this.eventsNavigationBarPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.changeNavigationBarPanel)).EndInit();
			this.changeNavigationBarPanel.ResumeLayout(false);
			this.changeNavigationBarPanel.PerformLayout();
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar navigationBar;
		private System.Windows.Forms.ListBox eventsListBox;
		private System.Windows.Forms.ImageList smallImageList;
		private System.Windows.Forms.ImageList largeImageList;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel eventsNavigationBarPanel;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel changeNavigationBarPanel;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Splitter vSplitter;
		private System.Windows.Forms.Splitter hSplitter;
		private System.Windows.Forms.CheckBox preventSelectionChangesCheckBox;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane mailNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane calendarNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip tabStrip;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage navigationBarTabStripPage;
		private ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage rendererTabStripPage;
		private System.Windows.Forms.PropertyGrid navigationBarPropertyGrid;
		private System.Windows.Forms.PropertyGrid rendererPropertyGrid;
		private System.Windows.Forms.ImageList propertiesImageList;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane contactsNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane tasksNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane notesNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane shortcutsNavigationPane;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane folderListNavigationPane;
		private System.Windows.Forms.ImageList mailImageList;
		private System.Windows.Forms.TreeView mailTreeView;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarPanel allFoldersNavigationBarPanel;
		private System.Windows.Forms.Splitter vSplitter2;
		private System.Windows.Forms.Label rendererLabel;
		private System.Windows.Forms.ComboBox rendererDropDownList;
		private Button saveLayoutButton;
		private Button loadLayoutButton;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
	}
}
