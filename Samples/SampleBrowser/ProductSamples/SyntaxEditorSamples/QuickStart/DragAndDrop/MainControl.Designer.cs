namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DragAndDrop {
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
            this.richTextToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
            this.sampleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolWindowContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
            this.toolboxToolWindow = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow();
            this.toolboxListBox = new System.Windows.Forms.ListBox();
            this.toolWindowContainer2 = new ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer();
            this.dockContainerContainer1 = new ActiproSoftware.UI.WinForms.Controls.Docking.DockContainerContainer();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.overrideDropTextBox = new System.Windows.Forms.TextBox();
            this.overrideDragTextBox = new System.Windows.Forms.TextBox();
            this.isDocumentReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelDropCheckBox = new System.Windows.Forms.CheckBox();
            this.customDragSourcePanel = new System.Windows.Forms.Panel();
            this.customDragSourceLabel = new System.Windows.Forms.Label();
            this.shouldReselectTextAfterDropCheckBox = new System.Windows.Forms.CheckBox();
            this.overrideDropCheckBox = new System.Windows.Forms.CheckBox();
            this.overrideDragCheckBox = new System.Windows.Forms.CheckBox();
            this.overrideLabel = new System.Windows.Forms.Label();
            this.populateWithRtfCheckBox = new System.Windows.Forms.CheckBox();
            this.populateWithHtmlCheckBox = new System.Windows.Forms.CheckBox();
            this.populateWithLabel = new System.Windows.Forms.Label();
            this.allowDropCheckBox = new System.Windows.Forms.CheckBox();
            this.allowLabel = new System.Windows.Forms.Label();
            this.allowDragCheckBox = new System.Windows.Forms.CheckBox();
            this.stringDragSourcePanel = new System.Windows.Forms.Panel();
            this.stringDragSourceLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.richTextToolWindow.SuspendLayout();
            this.toolWindowContainer1.SuspendLayout();
            this.toolboxToolWindow.SuspendLayout();
            this.toolWindowContainer2.SuspendLayout();
            this.dockContainerContainer1.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.customDragSourcePanel.SuspendLayout();
            this.stringDragSourcePanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsOutliningMarginVisible = false;
            this.editor.Location = new System.Drawing.Point(3, 140);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(576, 445);
            this.editor.TabIndex = 0;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.CutCopyDrag += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.CutCopyDragEventArgs>(this.OnEditorCutCopyDrag);
            this.editor.PasteDragDrop += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.PasteDragDropEventArgs>(this.OnEditorPasteDragDrop);
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
            // richTextToolWindow
            // 
            this.richTextToolWindow.Controls.Add(this.sampleRichTextBox);
            this.richTextToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextToolWindow.DockedSize = new System.Drawing.Size(200, 330);
            this.richTextToolWindow.DockManager = this.dockManager;
            this.richTextToolWindow.Location = new System.Drawing.Point(1, 22);
            this.richTextToolWindow.Name = "richTextToolWindow";
            this.richTextToolWindow.Size = new System.Drawing.Size(198, 307);
            this.richTextToolWindow.TabIndex = 0;
            this.richTextToolWindow.Text = "Rich Text";
            // 
            // sampleRichTextBox
            // 
            this.sampleRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sampleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleRichTextBox.EnableAutoDragDrop = true;
            this.sampleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.sampleRichTextBox.Name = "sampleRichTextBox";
            this.sampleRichTextBox.Size = new System.Drawing.Size(198, 307);
            this.sampleRichTextBox.TabIndex = 2;
            this.sampleRichTextBox.Text = "Use this RichTextBox to test outside drag and drop with SyntaxEditor.\n\nWhen enabl" +
    "ed, RTF syntax highlighting will be preserved when dropping on targets which sup" +
    "port RTF.";
            // 
            // toolWindowContainer1
            // 
            this.toolWindowContainer1.Controls.Add(this.richTextToolWindow);
            this.toolWindowContainer1.DockManager = this.dockManager;
            this.toolWindowContainer1.Location = new System.Drawing.Point(6, 258);
            this.toolWindowContainer1.Name = "toolWindowContainer1";
            this.toolWindowContainer1.Size = new System.Drawing.Size(200, 330);
            this.toolWindowContainer1.TabIndex = 9;
            // 
            // toolboxToolWindow
            // 
            this.toolboxToolWindow.Controls.Add(this.toolboxListBox);
            this.toolboxToolWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolboxToolWindow.DockedSize = new System.Drawing.Size(200, 252);
            this.toolboxToolWindow.DockManager = this.dockManager;
            this.toolboxToolWindow.Location = new System.Drawing.Point(1, 22);
            this.toolboxToolWindow.Name = "toolboxToolWindow";
            this.toolboxToolWindow.Size = new System.Drawing.Size(198, 229);
            this.toolboxToolWindow.TabIndex = 0;
            this.toolboxToolWindow.Text = "Toolbox";
            // 
            // toolboxListBox
            // 
            this.toolboxListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolboxListBox.DisplayMember = "DisplayText";
            this.toolboxListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolboxListBox.FormattingEnabled = true;
            this.toolboxListBox.Location = new System.Drawing.Point(0, 0);
            this.toolboxListBox.Name = "toolboxListBox";
            this.toolboxListBox.Size = new System.Drawing.Size(198, 229);
            this.toolboxListBox.TabIndex = 0;
            // 
            // toolWindowContainer2
            // 
            this.toolWindowContainer2.Controls.Add(this.toolboxToolWindow);
            this.toolWindowContainer2.DockManager = this.dockManager;
            this.toolWindowContainer2.Location = new System.Drawing.Point(6, 0);
            this.toolWindowContainer2.Name = "toolWindowContainer2";
            this.toolWindowContainer2.Size = new System.Drawing.Size(200, 252);
            this.toolWindowContainer2.TabIndex = 10;
            // 
            // dockContainerContainer1
            // 
            this.dockContainerContainer1.Controls.Add(this.toolWindowContainer2);
            this.dockContainerContainer1.Controls.Add(this.toolWindowContainer1);
            this.dockContainerContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockContainerContainer1.DockManager = this.dockManager;
            this.dockContainerContainer1.Location = new System.Drawing.Point(588, 6);
            this.dockContainerContainer1.Name = "dockContainerContainer1";
            this.dockContainerContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.dockContainerContainer1.SelectedToolWindow = null;
            this.dockContainerContainer1.Size = new System.Drawing.Size(206, 588);
            this.dockContainerContainer1.TabIndex = 9;
            // 
            // headerTableLayoutPanel
            // 
            this.headerTableLayoutPanel.AutoSize = true;
            this.headerTableLayoutPanel.ColumnCount = 4;
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayoutPanel.Controls.Add(this.overrideDropTextBox, 2, 3);
            this.headerTableLayoutPanel.Controls.Add(this.overrideDragTextBox, 2, 2);
            this.headerTableLayoutPanel.Controls.Add(this.isDocumentReadOnlyCheckBox, 2, 4);
            this.headerTableLayoutPanel.Controls.Add(this.cancelDropCheckBox, 1, 4);
            this.headerTableLayoutPanel.Controls.Add(this.customDragSourcePanel, 3, 2);
            this.headerTableLayoutPanel.Controls.Add(this.shouldReselectTextAfterDropCheckBox, 0, 4);
            this.headerTableLayoutPanel.Controls.Add(this.overrideDropCheckBox, 1, 3);
            this.headerTableLayoutPanel.Controls.Add(this.overrideDragCheckBox, 1, 2);
            this.headerTableLayoutPanel.Controls.Add(this.overrideLabel, 0, 2);
            this.headerTableLayoutPanel.Controls.Add(this.populateWithRtfCheckBox, 2, 1);
            this.headerTableLayoutPanel.Controls.Add(this.populateWithHtmlCheckBox, 1, 1);
            this.headerTableLayoutPanel.Controls.Add(this.populateWithLabel, 0, 1);
            this.headerTableLayoutPanel.Controls.Add(this.allowDropCheckBox, 2, 0);
            this.headerTableLayoutPanel.Controls.Add(this.allowLabel, 0, 0);
            this.headerTableLayoutPanel.Controls.Add(this.allowDragCheckBox, 1, 0);
            this.headerTableLayoutPanel.Controls.Add(this.stringDragSourcePanel, 3, 0);
            this.headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            this.headerTableLayoutPanel.RowCount = 5;
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerTableLayoutPanel.Size = new System.Drawing.Size(576, 131);
            this.headerTableLayoutPanel.TabIndex = 0;
            // 
            // overrideDropTextBox
            // 
            this.overrideDropTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.overrideDropTextBox.Enabled = false;
            this.overrideDropTextBox.Location = new System.Drawing.Point(237, 79);
            this.overrideDropTextBox.Name = "overrideDropTextBox";
            this.overrideDropTextBox.Size = new System.Drawing.Size(117, 20);
            this.overrideDropTextBox.TabIndex = 11;
            this.overrideDropTextBox.Text = "Custom Drop Text";
            // 
            // overrideDragTextBox
            // 
            this.overrideDragTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.overrideDragTextBox.Enabled = false;
            this.overrideDragTextBox.Location = new System.Drawing.Point(237, 53);
            this.overrideDragTextBox.Name = "overrideDragTextBox";
            this.overrideDragTextBox.Size = new System.Drawing.Size(117, 20);
            this.overrideDragTextBox.TabIndex = 9;
            this.overrideDragTextBox.Text = "Custom Drag Text";
            // 
            // isDocumentReadOnlyCheckBox
            // 
            this.isDocumentReadOnlyCheckBox.AutoSize = true;
            this.isDocumentReadOnlyCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isDocumentReadOnlyCheckBox.Location = new System.Drawing.Point(237, 111);
            this.isDocumentReadOnlyCheckBox.Name = "isDocumentReadOnlyCheckBox";
            this.isDocumentReadOnlyCheckBox.Size = new System.Drawing.Size(124, 17);
            this.isDocumentReadOnlyCheckBox.TabIndex = 14;
            this.isDocumentReadOnlyCheckBox.Text = "Read-only document";
            this.isDocumentReadOnlyCheckBox.UseVisualStyleBackColor = true;
            this.isDocumentReadOnlyCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // cancelDropCheckBox
            // 
            this.cancelDropCheckBox.AutoSize = true;
            this.cancelDropCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelDropCheckBox.Location = new System.Drawing.Point(148, 111);
            this.cancelDropCheckBox.Name = "cancelDropCheckBox";
            this.cancelDropCheckBox.Size = new System.Drawing.Size(83, 17);
            this.cancelDropCheckBox.TabIndex = 13;
            this.cancelDropCheckBox.Text = "Cancel drop";
            this.cancelDropCheckBox.UseVisualStyleBackColor = true;
            // 
            // customDragSourcePanel
            // 
            this.customDragSourcePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customDragSourcePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.customDragSourcePanel.Controls.Add(this.customDragSourceLabel);
            this.customDragSourcePanel.Location = new System.Drawing.Point(367, 53);
            this.customDragSourcePanel.Name = "customDragSourcePanel";
            this.customDragSourcePanel.Padding = new System.Windows.Forms.Padding(1);
            this.headerTableLayoutPanel.SetRowSpan(this.customDragSourcePanel, 2);
            this.customDragSourcePanel.Size = new System.Drawing.Size(206, 52);
            this.customDragSourcePanel.TabIndex = 16;
            // 
            // customDragSourceLabel
            // 
            this.customDragSourceLabel.BackColor = System.Drawing.SystemColors.Control;
            this.customDragSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDragSourceLabel.Location = new System.Drawing.Point(1, 1);
            this.customDragSourceLabel.Name = "customDragSourceLabel";
            this.customDragSourceLabel.Size = new System.Drawing.Size(204, 50);
            this.customDragSourceLabel.TabIndex = 1;
            this.customDragSourceLabel.Text = "Drag from Here for Object Data";
            this.customDragSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shouldReselectTextAfterDropCheckBox
            // 
            this.shouldReselectTextAfterDropCheckBox.AutoSize = true;
            this.shouldReselectTextAfterDropCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shouldReselectTextAfterDropCheckBox.Location = new System.Drawing.Point(3, 111);
            this.shouldReselectTextAfterDropCheckBox.Name = "shouldReselectTextAfterDropCheckBox";
            this.shouldReselectTextAfterDropCheckBox.Size = new System.Drawing.Size(139, 17);
            this.shouldReselectTextAfterDropCheckBox.TabIndex = 12;
            this.shouldReselectTextAfterDropCheckBox.Text = "Re-select text after drop";
            this.shouldReselectTextAfterDropCheckBox.UseVisualStyleBackColor = true;
            this.shouldReselectTextAfterDropCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // overrideDropCheckBox
            // 
            this.overrideDropCheckBox.AutoSize = true;
            this.overrideDropCheckBox.Location = new System.Drawing.Point(148, 79);
            this.overrideDropCheckBox.Name = "overrideDropCheckBox";
            this.overrideDropCheckBox.Size = new System.Drawing.Size(49, 17);
            this.overrideDropCheckBox.TabIndex = 10;
            this.overrideDropCheckBox.Text = "Drop";
            this.overrideDropCheckBox.UseVisualStyleBackColor = true;
            this.overrideDropCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // overrideDragCheckBox
            // 
            this.overrideDragCheckBox.AutoSize = true;
            this.overrideDragCheckBox.Location = new System.Drawing.Point(148, 53);
            this.overrideDragCheckBox.Name = "overrideDragCheckBox";
            this.overrideDragCheckBox.Size = new System.Drawing.Size(49, 17);
            this.overrideDragCheckBox.TabIndex = 8;
            this.overrideDragCheckBox.Text = "Drag";
            this.overrideDragCheckBox.UseVisualStyleBackColor = true;
            this.overrideDragCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // overrideLabel
            // 
            this.overrideLabel.AutoSize = true;
            this.overrideLabel.Location = new System.Drawing.Point(3, 50);
            this.overrideLabel.Name = "overrideLabel";
            this.overrideLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.overrideLabel.Size = new System.Drawing.Size(129, 16);
            this.overrideLabel.TabIndex = 7;
            this.overrideLabel.Text = "Override with custom text:";
            this.overrideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // populateWithRtfCheckBox
            // 
            this.populateWithRtfCheckBox.AutoSize = true;
            this.populateWithRtfCheckBox.Location = new System.Drawing.Point(237, 26);
            this.populateWithRtfCheckBox.Name = "populateWithRtfCheckBox";
            this.populateWithRtfCheckBox.Size = new System.Drawing.Size(47, 17);
            this.populateWithRtfCheckBox.TabIndex = 6;
            this.populateWithRtfCheckBox.Text = "RTF";
            this.populateWithRtfCheckBox.UseVisualStyleBackColor = true;
            this.populateWithRtfCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // populateWithHtmlCheckBox
            // 
            this.populateWithHtmlCheckBox.AutoSize = true;
            this.populateWithHtmlCheckBox.Location = new System.Drawing.Point(148, 26);
            this.populateWithHtmlCheckBox.Name = "populateWithHtmlCheckBox";
            this.populateWithHtmlCheckBox.Size = new System.Drawing.Size(56, 17);
            this.populateWithHtmlCheckBox.TabIndex = 5;
            this.populateWithHtmlCheckBox.Text = "HTML";
            this.populateWithHtmlCheckBox.UseVisualStyleBackColor = true;
            this.populateWithHtmlCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // populateWithLabel
            // 
            this.populateWithLabel.AutoSize = true;
            this.populateWithLabel.Location = new System.Drawing.Point(3, 23);
            this.populateWithLabel.Name = "populateWithLabel";
            this.populateWithLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.populateWithLabel.Size = new System.Drawing.Size(98, 16);
            this.populateWithLabel.TabIndex = 4;
            this.populateWithLabel.Text = "Populate drag with:";
            this.populateWithLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowDropCheckBox
            // 
            this.allowDropCheckBox.AutoSize = true;
            this.allowDropCheckBox.Location = new System.Drawing.Point(237, 3);
            this.allowDropCheckBox.Name = "allowDropCheckBox";
            this.allowDropCheckBox.Size = new System.Drawing.Size(49, 17);
            this.allowDropCheckBox.TabIndex = 3;
            this.allowDropCheckBox.Text = "Drop";
            this.allowDropCheckBox.UseVisualStyleBackColor = true;
            this.allowDropCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // allowLabel
            // 
            this.allowLabel.AutoSize = true;
            this.allowLabel.Location = new System.Drawing.Point(3, 0);
            this.allowLabel.Name = "allowLabel";
            this.allowLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.allowLabel.Size = new System.Drawing.Size(35, 16);
            this.allowLabel.TabIndex = 1;
            this.allowLabel.Text = "Allow:";
            this.allowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowDragCheckBox
            // 
            this.allowDragCheckBox.AutoSize = true;
            this.allowDragCheckBox.Location = new System.Drawing.Point(148, 3);
            this.allowDragCheckBox.Name = "allowDragCheckBox";
            this.allowDragCheckBox.Size = new System.Drawing.Size(49, 17);
            this.allowDragCheckBox.TabIndex = 2;
            this.allowDragCheckBox.Text = "Drag";
            this.allowDragCheckBox.UseVisualStyleBackColor = true;
            this.allowDragCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckBoxCheckedChanged);
            // 
            // stringDragSourcePanel
            // 
            this.stringDragSourcePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringDragSourcePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stringDragSourcePanel.Controls.Add(this.stringDragSourceLabel);
            this.stringDragSourcePanel.Location = new System.Drawing.Point(367, 3);
            this.stringDragSourcePanel.Name = "stringDragSourcePanel";
            this.stringDragSourcePanel.Padding = new System.Windows.Forms.Padding(1);
            this.headerTableLayoutPanel.SetRowSpan(this.stringDragSourcePanel, 2);
            this.stringDragSourcePanel.Size = new System.Drawing.Size(206, 44);
            this.stringDragSourcePanel.TabIndex = 15;
            // 
            // stringDragSourceLabel
            // 
            this.stringDragSourceLabel.BackColor = System.Drawing.SystemColors.Control;
            this.stringDragSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringDragSourceLabel.Location = new System.Drawing.Point(1, 1);
            this.stringDragSourceLabel.Name = "stringDragSourceLabel";
            this.stringDragSourceLabel.Size = new System.Drawing.Size(204, 42);
            this.stringDragSourceLabel.TabIndex = 0;
            this.stringDragSourceLabel.Text = "Drag from Here for String Data";
            this.stringDragSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 1;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Controls.Add(this.headerTableLayoutPanel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 1);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(6, 6);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.RowCount = 2;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(582, 588);
            this.contentTableLayoutPanel.TabIndex = 11;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Controls.Add(this.autoHideContainer3);
            this.Controls.Add(this.autoHideContainer4);
            this.Controls.Add(this.dockContainerContainer1);
            this.Controls.Add(this.autoHideTabStripPanel2);
            this.Controls.Add(this.autoHideTabStripPanel4);
            this.Controls.Add(this.autoHideTabStripPanel3);
            this.Controls.Add(this.autoHideTabStripPanel1);
            this.Controls.Add(this.autoHideContainer1);
            this.Controls.Add(this.autoHideContainer2);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.richTextToolWindow.ResumeLayout(false);
            this.toolWindowContainer1.ResumeLayout(false);
            this.toolboxToolWindow.ResumeLayout(false);
            this.toolWindowContainer2.ResumeLayout(false);
            this.dockContainerContainer1.ResumeLayout(false);
            this.headerTableLayoutPanel.ResumeLayout(false);
            this.headerTableLayoutPanel.PerformLayout();
            this.customDragSourcePanel.ResumeLayout(false);
            this.stringDragSourcePanel.ResumeLayout(false);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel3;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel4;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow richTextToolWindow;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideTabStripPanel autoHideTabStripPanel1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.AutoHideContainer autoHideContainer2;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer1;
		private ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow toolboxToolWindow;
		private UI.WinForms.Controls.Docking.DockContainerContainer dockContainerContainer1;
		private UI.WinForms.Controls.Docking.ToolWindowContainer toolWindowContainer2;
		private System.Windows.Forms.RichTextBox sampleRichTextBox;
		private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
		private System.Windows.Forms.Label overrideLabel;
		private System.Windows.Forms.CheckBox populateWithRtfCheckBox;
		private System.Windows.Forms.CheckBox populateWithHtmlCheckBox;
		private System.Windows.Forms.Label populateWithLabel;
		private System.Windows.Forms.CheckBox allowDropCheckBox;
		private System.Windows.Forms.Label allowLabel;
		private System.Windows.Forms.CheckBox allowDragCheckBox;
		private System.Windows.Forms.CheckBox overrideDragCheckBox;
		private System.Windows.Forms.CheckBox shouldReselectTextAfterDropCheckBox;
		private System.Windows.Forms.CheckBox overrideDropCheckBox;
		private System.Windows.Forms.Panel customDragSourcePanel;
		private System.Windows.Forms.Panel stringDragSourcePanel;
		private System.Windows.Forms.Label customDragSourceLabel;
		private System.Windows.Forms.Label stringDragSourceLabel;
		private System.Windows.Forms.ListBox toolboxListBox;
		private System.Windows.Forms.CheckBox cancelDropCheckBox;
		private System.Windows.Forms.CheckBox isDocumentReadOnlyCheckBox;
		private System.Windows.Forms.TextBox overrideDropTextBox;
		private System.Windows.Forms.TextBox overrideDragTextBox;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
