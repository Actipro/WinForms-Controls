namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotReading {
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
            this.navigationToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.goToNextDocumentationCommentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextThirdTokenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextTokenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextLineStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextWordStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextCharacterLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToNextLabel = new System.Windows.Forms.Label();
            this.goToCurrentWordEndLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToCurrentWordStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToCurrentLineEndLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToCurrentLineStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToSnapshotEndLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToSnapshotStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToCurrentLabel = new System.Windows.Forms.Label();
            this.goToPreviousDocumentationCommentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousThirdTokenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousTokenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousLineEndLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousWordStartLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousCharacterLinkLabel = new System.Windows.Forms.LinkLabel();
            this.goToPreviousLabel = new System.Windows.Forms.Label();
            this.toolWindowContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.resultsToolWindow.SuspendLayout();
            this.toolWindowContainer2.SuspendLayout();
            this.navigationToolWindow.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.toolWindowContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Document.IsReadOnly = true;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(6, 6);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(582, 450);
            this.editor.TabIndex = 0;
            this.editor.Text = resources.GetString("editor.Text");
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
            this.resultsToolWindow.Text = "Results";
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
            // navigationToolWindow
            // 
            this.navigationToolWindow.Controls.Add(this.navigationPanel);
            this.navigationToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationToolWindow.DockManager = this.dockManager;
            this.navigationToolWindow.Location = new System.Drawing.Point(7, 22);
            this.navigationToolWindow.Name = "navigationToolWindow";
            this.navigationToolWindow.Size = new System.Drawing.Size(198, 427);
            this.navigationToolWindow.TabIndex = 0;
            this.navigationToolWindow.Text = "Navigation";
            // 
            // navigationPanel
            // 
            this.navigationPanel.AutoScroll = true;
            this.navigationPanel.BackColor = System.Drawing.SystemColors.Window;
            this.navigationPanel.Controls.Add(this.goToNextDocumentationCommentLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextThirdTokenLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextTokenLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextLineStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextWordStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextCharacterLinkLabel);
            this.navigationPanel.Controls.Add(this.goToNextLabel);
            this.navigationPanel.Controls.Add(this.goToCurrentWordEndLinkLabel);
            this.navigationPanel.Controls.Add(this.goToCurrentWordStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToCurrentLineEndLinkLabel);
            this.navigationPanel.Controls.Add(this.goToCurrentLineStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToSnapshotEndLinkLabel);
            this.navigationPanel.Controls.Add(this.goToSnapshotStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToCurrentLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousDocumentationCommentLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousThirdTokenLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousTokenLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousLineEndLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousWordStartLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousCharacterLinkLabel);
            this.navigationPanel.Controls.Add(this.goToPreviousLabel);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Padding = new System.Windows.Forms.Padding(10);
            this.navigationPanel.Size = new System.Drawing.Size(198, 427);
            this.navigationPanel.TabIndex = 0;
            // 
            // goToNextDocumentationCommentLinkLabel
            // 
            this.goToNextDocumentationCommentLinkLabel.AutoSize = true;
            this.goToNextDocumentationCommentLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextDocumentationCommentLinkLabel.Location = new System.Drawing.Point(10, 290);
            this.goToNextDocumentationCommentLinkLabel.Name = "goToNextDocumentationCommentLinkLabel";
            this.goToNextDocumentationCommentLinkLabel.Size = new System.Drawing.Size(123, 13);
            this.goToNextDocumentationCommentLinkLabel.TabIndex = 20;
            this.goToNextDocumentationCommentLinkLabel.TabStop = true;
            this.goToNextDocumentationCommentLinkLabel.Text = "documentation comment";
            this.goToNextDocumentationCommentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextDocumentationCommentLinkLabelClicked);
            // 
            // goToNextThirdTokenLinkLabel
            // 
            this.goToNextThirdTokenLinkLabel.AutoSize = true;
            this.goToNextThirdTokenLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextThirdTokenLinkLabel.Location = new System.Drawing.Point(10, 277);
            this.goToNextThirdTokenLinkLabel.Name = "goToNextThirdTokenLinkLabel";
            this.goToNextThirdTokenLinkLabel.Size = new System.Drawing.Size(57, 13);
            this.goToNextThirdTokenLinkLabel.TabIndex = 19;
            this.goToNextThirdTokenLinkLabel.TabStop = true;
            this.goToNextThirdTokenLinkLabel.Text = "third token";
            this.goToNextThirdTokenLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextThirdTokenLinkLabelClicked);
            // 
            // goToNextTokenLinkLabel
            // 
            this.goToNextTokenLinkLabel.AutoSize = true;
            this.goToNextTokenLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextTokenLinkLabel.Location = new System.Drawing.Point(10, 264);
            this.goToNextTokenLinkLabel.Name = "goToNextTokenLinkLabel";
            this.goToNextTokenLinkLabel.Size = new System.Drawing.Size(34, 13);
            this.goToNextTokenLinkLabel.TabIndex = 18;
            this.goToNextTokenLinkLabel.TabStop = true;
            this.goToNextTokenLinkLabel.Text = "token";
            this.goToNextTokenLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextTokenLinkLabelClicked);
            // 
            // goToNextLineStartLinkLabel
            // 
            this.goToNextLineStartLinkLabel.AutoSize = true;
            this.goToNextLineStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextLineStartLinkLabel.Location = new System.Drawing.Point(10, 251);
            this.goToNextLineStartLinkLabel.Name = "goToNextLineStartLinkLabel";
            this.goToNextLineStartLinkLabel.Size = new System.Drawing.Size(46, 13);
            this.goToNextLineStartLinkLabel.TabIndex = 17;
            this.goToNextLineStartLinkLabel.TabStop = true;
            this.goToNextLineStartLinkLabel.Text = "line start";
            this.goToNextLineStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextLineStartLinkLabelClicked);
            // 
            // goToNextWordStartLinkLabel
            // 
            this.goToNextWordStartLinkLabel.AutoSize = true;
            this.goToNextWordStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextWordStartLinkLabel.Location = new System.Drawing.Point(10, 238);
            this.goToNextWordStartLinkLabel.Name = "goToNextWordStartLinkLabel";
            this.goToNextWordStartLinkLabel.Size = new System.Drawing.Size(53, 13);
            this.goToNextWordStartLinkLabel.TabIndex = 16;
            this.goToNextWordStartLinkLabel.TabStop = true;
            this.goToNextWordStartLinkLabel.Text = "word start";
            this.goToNextWordStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextWordStartLinkLabelClicked);
            // 
            // goToNextCharacterLinkLabel
            // 
            this.goToNextCharacterLinkLabel.AutoSize = true;
            this.goToNextCharacterLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextCharacterLinkLabel.Location = new System.Drawing.Point(10, 225);
            this.goToNextCharacterLinkLabel.Name = "goToNextCharacterLinkLabel";
            this.goToNextCharacterLinkLabel.Size = new System.Drawing.Size(52, 13);
            this.goToNextCharacterLinkLabel.TabIndex = 15;
            this.goToNextCharacterLinkLabel.TabStop = true;
            this.goToNextCharacterLinkLabel.Text = "character";
            this.goToNextCharacterLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToNextCharacterLinkLabelClicked);
            // 
            // goToNextLabel
            // 
            this.goToNextLabel.AutoSize = true;
            this.goToNextLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToNextLabel.Location = new System.Drawing.Point(10, 202);
            this.goToNextLabel.Name = "goToNextLabel";
            this.goToNextLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.goToNextLabel.Size = new System.Drawing.Size(65, 23);
            this.goToNextLabel.TabIndex = 14;
            this.goToNextLabel.Text = "Go to next...";
            // 
            // goToCurrentWordEndLinkLabel
            // 
            this.goToCurrentWordEndLinkLabel.AutoSize = true;
            this.goToCurrentWordEndLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToCurrentWordEndLinkLabel.Location = new System.Drawing.Point(10, 189);
            this.goToCurrentWordEndLinkLabel.Name = "goToCurrentWordEndLinkLabel";
            this.goToCurrentWordEndLinkLabel.Size = new System.Drawing.Size(51, 13);
            this.goToCurrentWordEndLinkLabel.TabIndex = 13;
            this.goToCurrentWordEndLinkLabel.TabStop = true;
            this.goToCurrentWordEndLinkLabel.Text = "word end";
            this.goToCurrentWordEndLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToCurrentWordEndLinkLabelClicked);
            // 
            // goToCurrentWordStartLinkLabel
            // 
            this.goToCurrentWordStartLinkLabel.AutoSize = true;
            this.goToCurrentWordStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToCurrentWordStartLinkLabel.Location = new System.Drawing.Point(10, 176);
            this.goToCurrentWordStartLinkLabel.Name = "goToCurrentWordStartLinkLabel";
            this.goToCurrentWordStartLinkLabel.Size = new System.Drawing.Size(53, 13);
            this.goToCurrentWordStartLinkLabel.TabIndex = 12;
            this.goToCurrentWordStartLinkLabel.TabStop = true;
            this.goToCurrentWordStartLinkLabel.Text = "word start";
            this.goToCurrentWordStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToCurrentWordStartLinkLabelClicked);
            // 
            // goToCurrentLineEndLinkLabel
            // 
            this.goToCurrentLineEndLinkLabel.AutoSize = true;
            this.goToCurrentLineEndLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToCurrentLineEndLinkLabel.Location = new System.Drawing.Point(10, 163);
            this.goToCurrentLineEndLinkLabel.Name = "goToCurrentLineEndLinkLabel";
            this.goToCurrentLineEndLinkLabel.Size = new System.Drawing.Size(44, 13);
            this.goToCurrentLineEndLinkLabel.TabIndex = 11;
            this.goToCurrentLineEndLinkLabel.TabStop = true;
            this.goToCurrentLineEndLinkLabel.Text = "line end";
            this.goToCurrentLineEndLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToCurrentLineEndLinkLabelClicked);
            // 
            // goToCurrentLineStartLinkLabel
            // 
            this.goToCurrentLineStartLinkLabel.AutoSize = true;
            this.goToCurrentLineStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToCurrentLineStartLinkLabel.Location = new System.Drawing.Point(10, 150);
            this.goToCurrentLineStartLinkLabel.Name = "goToCurrentLineStartLinkLabel";
            this.goToCurrentLineStartLinkLabel.Size = new System.Drawing.Size(46, 13);
            this.goToCurrentLineStartLinkLabel.TabIndex = 10;
            this.goToCurrentLineStartLinkLabel.TabStop = true;
            this.goToCurrentLineStartLinkLabel.Text = "line start";
            this.goToCurrentLineStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToCurrentLineStartLinkLabelClicked);
            // 
            // goToSnapshotEndLinkLabel
            // 
            this.goToSnapshotEndLinkLabel.AutoSize = true;
            this.goToSnapshotEndLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToSnapshotEndLinkLabel.Location = new System.Drawing.Point(10, 137);
            this.goToSnapshotEndLinkLabel.Name = "goToSnapshotEndLinkLabel";
            this.goToSnapshotEndLinkLabel.Size = new System.Drawing.Size(75, 13);
            this.goToSnapshotEndLinkLabel.TabIndex = 9;
            this.goToSnapshotEndLinkLabel.TabStop = true;
            this.goToSnapshotEndLinkLabel.Text = "document end";
            this.goToSnapshotEndLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToSnapshotEndLinkLabelClicked);
            // 
            // goToSnapshotStartLinkLabel
            // 
            this.goToSnapshotStartLinkLabel.AutoSize = true;
            this.goToSnapshotStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToSnapshotStartLinkLabel.Location = new System.Drawing.Point(10, 124);
            this.goToSnapshotStartLinkLabel.Name = "goToSnapshotStartLinkLabel";
            this.goToSnapshotStartLinkLabel.Size = new System.Drawing.Size(77, 13);
            this.goToSnapshotStartLinkLabel.TabIndex = 8;
            this.goToSnapshotStartLinkLabel.TabStop = true;
            this.goToSnapshotStartLinkLabel.Text = "document start";
            this.goToSnapshotStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToSnapshotStartLinkLabelClicked);
            // 
            // goToCurrentLabel
            // 
            this.goToCurrentLabel.AutoSize = true;
            this.goToCurrentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToCurrentLabel.Location = new System.Drawing.Point(10, 101);
            this.goToCurrentLabel.Name = "goToCurrentLabel";
            this.goToCurrentLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.goToCurrentLabel.Size = new System.Drawing.Size(78, 23);
            this.goToCurrentLabel.TabIndex = 7;
            this.goToCurrentLabel.Text = "Go to current...";
            // 
            // goToPreviousDocumentationCommentLinkLabel
            // 
            this.goToPreviousDocumentationCommentLinkLabel.AutoSize = true;
            this.goToPreviousDocumentationCommentLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousDocumentationCommentLinkLabel.Location = new System.Drawing.Point(10, 88);
            this.goToPreviousDocumentationCommentLinkLabel.Name = "goToPreviousDocumentationCommentLinkLabel";
            this.goToPreviousDocumentationCommentLinkLabel.Size = new System.Drawing.Size(123, 13);
            this.goToPreviousDocumentationCommentLinkLabel.TabIndex = 6;
            this.goToPreviousDocumentationCommentLinkLabel.TabStop = true;
            this.goToPreviousDocumentationCommentLinkLabel.Text = "documentation comment";
            this.goToPreviousDocumentationCommentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousDocumentationCommentLinkLabelClicked);
            // 
            // goToPreviousThirdTokenLinkLabel
            // 
            this.goToPreviousThirdTokenLinkLabel.AutoSize = true;
            this.goToPreviousThirdTokenLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousThirdTokenLinkLabel.Location = new System.Drawing.Point(10, 75);
            this.goToPreviousThirdTokenLinkLabel.Name = "goToPreviousThirdTokenLinkLabel";
            this.goToPreviousThirdTokenLinkLabel.Size = new System.Drawing.Size(57, 13);
            this.goToPreviousThirdTokenLinkLabel.TabIndex = 5;
            this.goToPreviousThirdTokenLinkLabel.TabStop = true;
            this.goToPreviousThirdTokenLinkLabel.Text = "third token";
            this.goToPreviousThirdTokenLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousThirdTokenLinkLabelClicked);
            // 
            // goToPreviousTokenLinkLabel
            // 
            this.goToPreviousTokenLinkLabel.AutoSize = true;
            this.goToPreviousTokenLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousTokenLinkLabel.Location = new System.Drawing.Point(10, 62);
            this.goToPreviousTokenLinkLabel.Name = "goToPreviousTokenLinkLabel";
            this.goToPreviousTokenLinkLabel.Size = new System.Drawing.Size(34, 13);
            this.goToPreviousTokenLinkLabel.TabIndex = 4;
            this.goToPreviousTokenLinkLabel.TabStop = true;
            this.goToPreviousTokenLinkLabel.Text = "token";
            this.goToPreviousTokenLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousTokenLinkLabelClicked);
            // 
            // goToPreviousLineEndLinkLabel
            // 
            this.goToPreviousLineEndLinkLabel.AutoSize = true;
            this.goToPreviousLineEndLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousLineEndLinkLabel.Location = new System.Drawing.Point(10, 49);
            this.goToPreviousLineEndLinkLabel.Name = "goToPreviousLineEndLinkLabel";
            this.goToPreviousLineEndLinkLabel.Size = new System.Drawing.Size(44, 13);
            this.goToPreviousLineEndLinkLabel.TabIndex = 3;
            this.goToPreviousLineEndLinkLabel.TabStop = true;
            this.goToPreviousLineEndLinkLabel.Text = "line end";
            this.goToPreviousLineEndLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousLineEndLinkLabelClicked);
            // 
            // goToPreviousWordStartLinkLabel
            // 
            this.goToPreviousWordStartLinkLabel.AutoSize = true;
            this.goToPreviousWordStartLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousWordStartLinkLabel.Location = new System.Drawing.Point(10, 36);
            this.goToPreviousWordStartLinkLabel.Name = "goToPreviousWordStartLinkLabel";
            this.goToPreviousWordStartLinkLabel.Size = new System.Drawing.Size(53, 13);
            this.goToPreviousWordStartLinkLabel.TabIndex = 2;
            this.goToPreviousWordStartLinkLabel.TabStop = true;
            this.goToPreviousWordStartLinkLabel.Text = "word start";
            this.goToPreviousWordStartLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousWordStartLinkLabelClicked);
            // 
            // goToPreviousCharacterLinkLabel
            // 
            this.goToPreviousCharacterLinkLabel.AutoSize = true;
            this.goToPreviousCharacterLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousCharacterLinkLabel.Location = new System.Drawing.Point(10, 23);
            this.goToPreviousCharacterLinkLabel.Name = "goToPreviousCharacterLinkLabel";
            this.goToPreviousCharacterLinkLabel.Size = new System.Drawing.Size(52, 13);
            this.goToPreviousCharacterLinkLabel.TabIndex = 1;
            this.goToPreviousCharacterLinkLabel.TabStop = true;
            this.goToPreviousCharacterLinkLabel.Text = "character";
            this.goToPreviousCharacterLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnGoToPreviousCharacterLinkLabelClicked);
            // 
            // goToPreviousLabel
            // 
            this.goToPreviousLabel.AutoSize = true;
            this.goToPreviousLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.goToPreviousLabel.Location = new System.Drawing.Point(10, 10);
            this.goToPreviousLabel.Name = "goToPreviousLabel";
            this.goToPreviousLabel.Size = new System.Drawing.Size(85, 13);
            this.goToPreviousLabel.TabIndex = 0;
            this.goToPreviousLabel.Text = "Go to previous...";
            // 
            // toolWindowContainer1
            // 
            this.toolWindowContainer1.Controls.Add(this.navigationToolWindow);
            this.toolWindowContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolWindowContainer1.DockManager = this.dockManager;
            this.toolWindowContainer1.Location = new System.Drawing.Point(588, 6);
            this.toolWindowContainer1.Name = "toolWindowContainer1";
            this.toolWindowContainer1.Size = new System.Drawing.Size(206, 450);
            this.toolWindowContainer1.TabIndex = 11;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.editor);
            this.Controls.Add(this.toolWindowContainer1);
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
            this.resultsToolWindow.ResumeLayout(false);
            this.resultsToolWindow.PerformLayout();
            this.toolWindowContainer2.ResumeLayout(false);
            this.navigationToolWindow.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.navigationPanel.PerformLayout();
            this.toolWindowContainer1.ResumeLayout(false);
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
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow navigationToolWindow;
		private System.Windows.Forms.Panel navigationPanel;
		private System.Windows.Forms.LinkLabel goToPreviousWordStartLinkLabel;
		private System.Windows.Forms.LinkLabel goToPreviousCharacterLinkLabel;
		private System.Windows.Forms.Label goToPreviousLabel;
		private System.Windows.Forms.LinkLabel goToPreviousLineEndLinkLabel;
		private System.Windows.Forms.LinkLabel goToPreviousTokenLinkLabel;
		private System.Windows.Forms.LinkLabel goToPreviousThirdTokenLinkLabel;
		private System.Windows.Forms.LinkLabel goToPreviousDocumentationCommentLinkLabel;
		private System.Windows.Forms.LinkLabel goToSnapshotStartLinkLabel;
		private System.Windows.Forms.Label goToCurrentLabel;
		private System.Windows.Forms.LinkLabel goToSnapshotEndLinkLabel;
		private System.Windows.Forms.LinkLabel goToCurrentLineStartLinkLabel;
		private System.Windows.Forms.LinkLabel goToCurrentLineEndLinkLabel;
		private System.Windows.Forms.LinkLabel goToCurrentWordStartLinkLabel;
		private System.Windows.Forms.LinkLabel goToCurrentWordEndLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextDocumentationCommentLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextThirdTokenLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextTokenLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextLineStartLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextWordStartLinkLabel;
		private System.Windows.Forms.LinkLabel goToNextCharacterLinkLabel;
		private System.Windows.Forms.Label goToNextLabel;
	}
}
