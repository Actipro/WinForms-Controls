namespace ActiproSoftware.SampleBrowser {
	partial class RootForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.primaryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.versionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.contentAreaPanel = new System.Windows.Forms.Panel();
			this.contentHostPanel = new System.Windows.Forms.Panel();
			this.contentHeaderPanel = new ActiproSoftware.SampleBrowser.ContentHeaderPanel();
			this.companyLogoImage = new System.Windows.Forms.PictureBox();
			this.contentHeaderLabel = new System.Windows.Forms.Label();
			this.navigationSplitter = new System.Windows.Forms.Splitter();
			this.titleSplitter = new System.Windows.Forms.Splitter();
			this.navigationPanel = new System.Windows.Forms.Panel();
			this.navigationListBox = new ActiproSoftware.SampleBrowser.NavigationListBox();
			this.navigationToolStrip = new System.Windows.Forms.ToolStrip();
			this.introductionToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.navigationToToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.navigateToIntroductionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.navigateToSyntaxEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.navigateToBarsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.navigateToDockingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.navigateToNavigationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.navigateToWizardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.openDocumentationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSampleProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip.SuspendLayout();
			this.contentAreaPanel.SuspendLayout();
			this.contentHeaderPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.companyLogoImage)).BeginInit();
			this.navigationPanel.SuspendLayout();
			this.navigationToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primaryStatusLabel,
            this.versionStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 688);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip.Size = new System.Drawing.Size(1040, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// primaryStatusLabel
			// 
			this.primaryStatusLabel.Margin = new System.Windows.Forms.Padding(4, 3, 0, 2);
			this.primaryStatusLabel.Name = "primaryStatusLabel";
			this.primaryStatusLabel.Size = new System.Drawing.Size(970, 17);
			this.primaryStatusLabel.Spring = true;
			this.primaryStatusLabel.Text = "Ready";
			this.primaryStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// versionStatusLabel
			// 
			this.versionStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 4, 2);
			this.versionStatusLabel.Name = "versionStatusLabel";
			this.versionStatusLabel.Size = new System.Drawing.Size(45, 17);
			this.versionStatusLabel.Text = "Version";
			// 
			// contentAreaPanel
			// 
			this.contentAreaPanel.Controls.Add(this.contentHostPanel);
			this.contentAreaPanel.Controls.Add(this.contentHeaderPanel);
			this.contentAreaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentAreaPanel.Location = new System.Drawing.Point(240, 1);
			this.contentAreaPanel.Name = "contentAreaPanel";
			this.contentAreaPanel.Size = new System.Drawing.Size(800, 687);
			this.contentAreaPanel.TabIndex = 2;
			// 
			// contentHostPanel
			// 
			this.contentHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentHostPanel.Location = new System.Drawing.Point(0, 87);
			this.contentHostPanel.Name = "contentHostPanel";
			this.contentHostPanel.Size = new System.Drawing.Size(800, 600);
			this.contentHostPanel.TabIndex = 1;
			// 
			// contentHeaderPanel
			// 
			this.contentHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
			this.contentHeaderPanel.Controls.Add(this.companyLogoImage);
			this.contentHeaderPanel.Controls.Add(this.contentHeaderLabel);
			this.contentHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.contentHeaderPanel.Location = new System.Drawing.Point(0, 0);
			this.contentHeaderPanel.Name = "contentHeaderPanel";
			this.contentHeaderPanel.Size = new System.Drawing.Size(800, 87);
			this.contentHeaderPanel.TabIndex = 0;
			// 
			// companyLogoImage
			// 
			this.companyLogoImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.companyLogoImage.BackColor = System.Drawing.Color.Transparent;
			this.companyLogoImage.Image = global::ActiproSoftware.SampleBrowser.Resources.CompanyLogo;
			this.companyLogoImage.Location = new System.Drawing.Point(625, 30);
			this.companyLogoImage.Name = "companyLogoImage";
			this.companyLogoImage.Size = new System.Drawing.Size(100, 26);
			this.companyLogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.companyLogoImage.TabIndex = 1;
			this.companyLogoImage.TabStop = false;
			// 
			// contentHeaderLabel
			// 
			this.contentHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contentHeaderLabel.AutoEllipsis = true;
			this.contentHeaderLabel.BackColor = System.Drawing.Color.Transparent;
			this.contentHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contentHeaderLabel.ForeColor = System.Drawing.Color.White;
			this.contentHeaderLabel.Location = new System.Drawing.Point(49, 5);
			this.contentHeaderLabel.Name = "contentHeaderLabel";
			this.contentHeaderLabel.Size = new System.Drawing.Size(559, 73);
			this.contentHeaderLabel.TabIndex = 0;
			this.contentHeaderLabel.Text = "Introduction";
			this.contentHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.contentHeaderLabel.UseMnemonic = false;
			// 
			// navigationSplitter
			// 
			this.navigationSplitter.BackColor = System.Drawing.SystemColors.ControlDark;
			this.navigationSplitter.Location = new System.Drawing.Point(233, 1);
			this.navigationSplitter.MinExtra = 500;
			this.navigationSplitter.Name = "navigationSplitter";
			this.navigationSplitter.Size = new System.Drawing.Size(7, 687);
			this.navigationSplitter.TabIndex = 3;
			this.navigationSplitter.TabStop = false;
			// 
			// titleSplitter
			// 
			this.titleSplitter.BackColor = System.Drawing.SystemColors.ControlDark;
			this.titleSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleSplitter.Enabled = false;
			this.titleSplitter.Location = new System.Drawing.Point(233, 0);
			this.titleSplitter.Name = "titleSplitter";
			this.titleSplitter.Size = new System.Drawing.Size(807, 1);
			this.titleSplitter.TabIndex = 4;
			this.titleSplitter.TabStop = false;
			// 
			// navigationPanel
			// 
			this.navigationPanel.Controls.Add(this.navigationListBox);
			this.navigationPanel.Controls.Add(this.navigationToolStrip);
			this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.navigationPanel.Location = new System.Drawing.Point(0, 0);
			this.navigationPanel.MinimumSize = new System.Drawing.Size(170, 0);
			this.navigationPanel.Name = "navigationPanel";
			this.navigationPanel.Size = new System.Drawing.Size(233, 688);
			this.navigationPanel.TabIndex = 5;
			// 
			// navigationListBox
			// 
			this.navigationListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.navigationListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.navigationListBox.IntegralHeight = false;
			this.navigationListBox.Location = new System.Drawing.Point(0, 29);
			this.navigationListBox.Name = "navigationListBox";
			this.navigationListBox.Size = new System.Drawing.Size(233, 659);
			this.navigationListBox.TabIndex = 1;
			// 
			// navigationToolStrip
			// 
			this.navigationToolStrip.CanOverflow = false;
			this.navigationToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.navigationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introductionToolStripButton,
            this.navigationToToolStripDropDownButton,
            this.toolStripSeparator1,
            this.previousToolStripButton,
            this.nextToolStripButton});
			this.navigationToolStrip.Location = new System.Drawing.Point(0, 0);
			this.navigationToolStrip.Name = "navigationToolStrip";
			this.navigationToolStrip.Padding = new System.Windows.Forms.Padding(3);
			this.navigationToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.navigationToolStrip.Size = new System.Drawing.Size(233, 29);
			this.navigationToolStrip.TabIndex = 2;
			this.navigationToolStrip.Text = "toolStrip1";
			// 
			// introductionToolStripButton
			// 
			this.introductionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.introductionToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconHome16;
			this.introductionToolStripButton.Name = "introductionToolStripButton";
			this.introductionToolStripButton.Size = new System.Drawing.Size(23, 20);
			this.introductionToolStripButton.Text = "Home";
			this.introductionToolStripButton.ToolTipText = "Go to Introduction";
			this.introductionToolStripButton.Click += new System.EventHandler(this.OnIntroductionToolStripButtonClick);
			// 
			// navigationToToolStripDropDownButton
			// 
			this.navigationToToolStripDropDownButton.AutoToolTip = false;
			this.navigationToToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.navigationToToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigateToIntroductionMenuItem,
            this.toolStripSeparator2,
            this.navigateToSyntaxEditorMenuItem,
            this.navigateToBarsMenuItem,
            this.navigateToDockingMenuItem,
            this.navigateToNavigationMenuItem,
            this.navigateToWizardMenuItem,
            this.toolStripSeparator3,
            this.openDocumentationMenuItem,
            this.openSampleProjectMenuItem});
			this.navigationToToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.navigationToToolStripDropDownButton.Name = "navigationToToolStripDropDownButton";
			this.navigationToToolStripDropDownButton.Size = new System.Drawing.Size(82, 20);
			this.navigationToToolStripDropDownButton.Text = "Navigate To";
			// 
			// navigateToIntroductionMenuItem
			// 
			this.navigateToIntroductionMenuItem.Name = "navigateToIntroductionMenuItem";
			this.navigateToIntroductionMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToIntroductionMenuItem.Tag = "/SampleBrowser/Documents/Introduction.html";
			this.navigateToIntroductionMenuItem.Text = "Introduction";
			this.navigateToIntroductionMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
			// 
			// navigateToSyntaxEditorMenuItem
			// 
			this.navigateToSyntaxEditorMenuItem.Name = "navigateToSyntaxEditorMenuItem";
			this.navigateToSyntaxEditorMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToSyntaxEditorMenuItem.Tag = "/ProductSamples/SyntaxEditorSamples/Documents/Overview.html";
			this.navigateToSyntaxEditorMenuItem.Text = "SyntaxEditor";
			this.navigateToSyntaxEditorMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// navigateToBarsMenuItem
			// 
			this.navigateToBarsMenuItem.Name = "navigateToBarsMenuItem";
			this.navigateToBarsMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToBarsMenuItem.Tag = "/ProductSamples/BarsSamples/Documents/Overview.html";
			this.navigateToBarsMenuItem.Text = "Bars";
			this.navigateToBarsMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// navigateToDockingMenuItem
			// 
			this.navigateToDockingMenuItem.Name = "navigateToDockingMenuItem";
			this.navigateToDockingMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToDockingMenuItem.Tag = "/ProductSamples/DockingSamples/Documents/Overview.html";
			this.navigateToDockingMenuItem.Text = "Docking && MDI";
			this.navigateToDockingMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// navigateToNavigationMenuItem
			// 
			this.navigateToNavigationMenuItem.Name = "navigateToNavigationMenuItem";
			this.navigateToNavigationMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToNavigationMenuItem.Tag = "/ProductSamples/NavigationSamples/Documents/Overview.html";
			this.navigateToNavigationMenuItem.Text = "Navigation";
			this.navigateToNavigationMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// navigateToWizardMenuItem
			// 
			this.navigateToWizardMenuItem.Name = "navigateToWizardMenuItem";
			this.navigateToWizardMenuItem.Size = new System.Drawing.Size(234, 22);
			this.navigateToWizardMenuItem.Tag = "/ProductSamples/WizardSamples/Documents/Overview.html";
			this.navigateToWizardMenuItem.Text = "Wizard";
			this.navigateToWizardMenuItem.Click += new System.EventHandler(this.OnNavigateToMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
			// 
			// openDocumentationMenuItem
			// 
			this.openDocumentationMenuItem.Name = "openDocumentationMenuItem";
			this.openDocumentationMenuItem.Size = new System.Drawing.Size(234, 22);
			this.openDocumentationMenuItem.Tag = "documentation";
			this.openDocumentationMenuItem.Text = "Open Product Documentation";
			this.openDocumentationMenuItem.Click += new System.EventHandler(this.OnOpenDocumentationMenuItemClick);
			// 
			// openSampleProjectMenuItem
			// 
			this.openSampleProjectMenuItem.Name = "openSampleProjectMenuItem";
			this.openSampleProjectMenuItem.Size = new System.Drawing.Size(234, 22);
			this.openSampleProjectMenuItem.Tag = "sampleproject";
			this.openSampleProjectMenuItem.Text = "Open VS Sample Project";
			this.openSampleProjectMenuItem.Click += new System.EventHandler(this.OnOpenSampleProjectMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// previousToolStripButton
			// 
			this.previousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.previousToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconNavigateUp16;
			this.previousToolStripButton.Name = "previousToolStripButton";
			this.previousToolStripButton.Size = new System.Drawing.Size(23, 20);
			this.previousToolStripButton.Text = "Go to Previous Document/Sample";
			this.previousToolStripButton.Click += new System.EventHandler(this.OnPreviousToolStripButtonClick);
			// 
			// nextToolStripButton
			// 
			this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextToolStripButton.Image = global::ActiproSoftware.SampleBrowser.Resources.IconNavigateDown16;
			this.nextToolStripButton.Name = "nextToolStripButton";
			this.nextToolStripButton.Size = new System.Drawing.Size(23, 20);
			this.nextToolStripButton.Text = "Go to Next Document/Sample";
			this.nextToolStripButton.Click += new System.EventHandler(this.OnNextToolStripButtonClick);
			// 
			// RootForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(1040, 710);
			this.Controls.Add(this.contentAreaPanel);
			this.Controls.Add(this.navigationSplitter);
			this.Controls.Add(this.titleSplitter);
			this.Controls.Add(this.navigationPanel);
			this.Controls.Add(this.statusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.Name = "RootForm";
			this.Text = "Actipro WinForms Controls";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.contentAreaPanel.ResumeLayout(false);
			this.contentHeaderPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.companyLogoImage)).EndInit();
			this.navigationPanel.ResumeLayout(false);
			this.navigationPanel.PerformLayout();
			this.navigationToolStrip.ResumeLayout(false);
			this.navigationToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel primaryStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel versionStatusLabel;
		private System.Windows.Forms.Panel contentAreaPanel;
		private System.Windows.Forms.Splitter navigationSplitter;
		private System.Windows.Forms.Splitter titleSplitter;
		private System.Windows.Forms.Panel navigationPanel;
		private NavigationListBox navigationListBox;
		private System.Windows.Forms.ToolStrip navigationToolStrip;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton navigationToToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem navigateToIntroductionMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem navigateToSyntaxEditorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem navigateToBarsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem navigateToDockingMenuItem;
		private System.Windows.Forms.ToolStripMenuItem navigateToNavigationMenuItem;
		private System.Windows.Forms.ToolStripMenuItem navigateToWizardMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton introductionToolStripButton;
		private System.Windows.Forms.Panel contentHostPanel;
		private ActiproSoftware.SampleBrowser.ContentHeaderPanel contentHeaderPanel;
		private System.Windows.Forms.Label contentHeaderLabel;
		private System.Windows.Forms.PictureBox companyLogoImage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem openSampleProjectMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openDocumentationMenuItem;
	}
}