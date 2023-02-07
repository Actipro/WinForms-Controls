namespace ActiproSoftware.ProductSamples.WizardSamples.Demo.Features {
	partial class MainForm {
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
            ActiproSoftware.UI.WinForms.Controls.Wizard.WindowsClassicWizardRenderer windowsClassicWizardRenderer1 = new ActiproSoftware.UI.WinForms.Controls.Wizard.WindowsClassicWizardRenderer();
            ActiproSoftware.UI.WinForms.Drawing.ImageBackgroundFill imageBackgroundFill1 = new ActiproSoftware.UI.WinForms.Drawing.ImageBackgroundFill();
            ActiproSoftware.UI.WinForms.Drawing.ImageBackgroundFill imageBackgroundFill2 = new ActiproSoftware.UI.WinForms.Drawing.ImageBackgroundFill();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardWelcomePage();
            this.startPageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startPageFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.infoWebSiteLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataCollectionPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.dataCollectionPageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.validatingTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.executionPath1 = new System.Windows.Forms.RadioButton();
            this.executionPath2 = new System.Windows.Forms.RadioButton();
            this.processingPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.processingPageFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.processingLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cancelPageChangeCheckBox = new System.Windows.Forms.CheckBox();
            this.finishPage1 = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.finishPage1TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.finishPage1Number1Label = new System.Windows.Forms.Label();
            this.finishPage1FinishPageLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.goToSecondExecutionPathButton = new System.Windows.Forms.Button();
            this.finishPage2 = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.finishPage2TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.finishPage2FinishPageLabel = new System.Windows.Forms.Label();
            this.finishPage2Number2Label = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.windowsXPPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.windowsXPTabelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.windowsXPActiproLabel = new System.Windows.Forms.Label();
            this.windowsXPWizardLabel = new System.Windows.Forms.Label();
            this.windowsXPMessageLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.customAppearancesPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
            this.customAppearancesPageTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.customAppearanceListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wizard)).BeginInit();
            this.startPage.SuspendLayout();
            this.startPageTableLayoutPanel.SuspendLayout();
            this.startPageFlowLayoutPanel.SuspendLayout();
            this.dataCollectionPage.SuspendLayout();
            this.dataCollectionPageTableLayoutPanel.SuspendLayout();
            this.processingPage.SuspendLayout();
            this.processingPageFlowLayoutPanel.SuspendLayout();
            this.finishPage1.SuspendLayout();
            this.finishPage1TableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.finishPage2.SuspendLayout();
            this.finishPage2TableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.windowsXPPage.SuspendLayout();
            this.windowsXPTabelLayoutPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.customAppearancesPage.SuspendLayout();
            this.customAppearancesPageTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wizard
            // 
            this.Wizard.ButtonFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Wizard.FormAcceptButton = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardAcceptButtonDefault.FinishThenNext;
            this.Wizard.FormCancelButton = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardCancelButtonDefault.Cancel;
            this.Wizard.Pages.AddRange(new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage[] {
            this.startPage,
            this.dataCollectionPage,
            this.processingPage,
            this.finishPage1,
            this.customAppearancesPage,
            this.windowsXPPage,
            this.finishPage2});
            this.Wizard.PageSequenceType = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPageSequenceType.BackStack;
            windowsClassicWizardRenderer1.WizardButtonContainerDefaultBackgroundFill = new ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradient(System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.Control, 90F, ActiproSoftware.UI.WinForms.Drawing.TwoColorLinearGradientStyle.Normal, ActiproSoftware.UI.WinForms.Drawing.BackgroundFillRotationType.None);
            imageBackgroundFill1.Image = ((System.Drawing.Image)(resources.GetObject("imageBackgroundFill1.Image")));
            windowsClassicWizardRenderer1.WizardInteriorPageHeaderDefaultBackgroundFill = imageBackgroundFill1;
            windowsClassicWizardRenderer1.WizardInteriorPageHeaderDefaultImage = ((System.Drawing.Image)(resources.GetObject("windowsClassicWizardRenderer1.WizardInteriorPageHeaderDefaultImage")));
            imageBackgroundFill2.Image = ((System.Drawing.Image)(resources.GetObject("imageBackgroundFill2.Image")));
            windowsClassicWizardRenderer1.WizardWelcomePageWatermarkDefaultBackgroundFill = imageBackgroundFill2;
            this.Wizard.Renderer = windowsClassicWizardRenderer1;
            this.Wizard.Size = new System.Drawing.Size(558, 403);
            // 
            // startPage
            // 
            this.startPage.BackColor = System.Drawing.SystemColors.Window;
            this.startPage.Controls.Add(this.startPageTableLayoutPanel);
            this.startPage.IsInteriorPage = false;
            this.startPage.Name = "startPage";
            this.startPage.PageTitleBarText = "Step 1";
            this.startPage.TabIndex = 0;
            this.startPage.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("startPage.WatermarkImage")));
            this.startPage.WatermarkImageLocation = new System.Drawing.Point(96, 18);
            this.startPage.Resize += new System.EventHandler(this.startPage_Resize);
            // 
            // startPageTableLayoutPanel
            // 
            this.startPageTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.startPageTableLayoutPanel.ColumnCount = 1;
            this.startPageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startPageTableLayoutPanel.Controls.Add(this.startPageFlowLayoutPanel, 0, 2);
            this.startPageTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.startPageTableLayoutPanel.Controls.Add(this.welcomeLabel, 0, 0);
            this.startPageTableLayoutPanel.Controls.Add(this.label3, 0, 3);
            this.startPageTableLayoutPanel.Location = new System.Drawing.Point(167, 3);
            this.startPageTableLayoutPanel.Name = "startPageTableLayoutPanel";
            this.startPageTableLayoutPanel.Padding = new System.Windows.Forms.Padding(16);
            this.startPageTableLayoutPanel.RowCount = 4;
            this.startPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.startPageTableLayoutPanel.Size = new System.Drawing.Size(388, 358);
            this.startPageTableLayoutPanel.TabIndex = 15;
            // 
            // startPageFlowLayoutPanel
            // 
            this.startPageFlowLayoutPanel.Controls.Add(this.label4);
            this.startPageFlowLayoutPanel.Controls.Add(this.infoWebSiteLabel);
            this.startPageFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPageFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.startPageFlowLayoutPanel.Location = new System.Drawing.Point(19, 155);
            this.startPageFlowLayoutPanel.Name = "startPageFlowLayoutPanel";
            this.startPageFlowLayoutPanel.Size = new System.Drawing.Size(350, 141);
            this.startPageFlowLayoutPanel.TabIndex = 15;
            this.startPageFlowLayoutPanel.WrapContents = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Visit our web site for new versions and licensing information:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // infoWebSiteLabel
            // 
            this.infoWebSiteLabel.AutoSize = true;
            this.infoWebSiteLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoWebSiteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoWebSiteLabel.Location = new System.Drawing.Point(3, 13);
            this.infoWebSiteLabel.Name = "infoWebSiteLabel";
            this.infoWebSiteLabel.Size = new System.Drawing.Size(288, 13);
            this.infoWebSiteLabel.TabIndex = 0;
            this.infoWebSiteLabel.TabStop = true;
            this.infoWebSiteLabel.Text = "https://www.actiprosoftware.com";
            this.infoWebSiteLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.infoWebSiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.infoWebSiteLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thank you for downloading the Wizard control.  This test application demonstrates" +
    " many of the features of the Wizard control.";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.Location = new System.Drawing.Point(19, 16);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(350, 50);
            this.welcomeLabel.TabIndex = 4;
            this.welcomeLabel.Text = "Welcome to the Wizard Test Application";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(19, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To continue, click Next.";
            // 
            // dataCollectionPage
            // 
            this.dataCollectionPage.Controls.Add(this.dataCollectionPageTableLayoutPanel);
            this.dataCollectionPage.Name = "dataCollectionPage";
            this.dataCollectionPage.PageCaption = "Information Gathering";
            this.dataCollectionPage.PageDescription = "This page demonstrates how simple it is for the Wizard to gather information from" +
    " users in a friendly way.";
            this.dataCollectionPage.PageTitleBarText = "Step 2";
            this.dataCollectionPage.TabIndex = 14;
            this.dataCollectionPage.NextButtonClick += new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPageCancelEventHandler(this.dataCollectionPage_NextButtonClick);
            // 
            // dataCollectionPageTableLayoutPanel
            // 
            this.dataCollectionPageTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataCollectionPageTableLayoutPanel.ColumnCount = 2;
            this.dataCollectionPageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dataCollectionPageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.label9, 0, 0);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.label5, 0, 6);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.label8, 0, 1);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.validatingTextBox, 1, 1);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.label7, 0, 3);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.textBox2, 1, 2);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.label6, 0, 2);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.executionPath1, 0, 4);
            this.dataCollectionPageTableLayoutPanel.Controls.Add(this.executionPath2, 0, 5);
            this.dataCollectionPageTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataCollectionPageTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dataCollectionPageTableLayoutPanel.Name = "dataCollectionPageTableLayoutPanel";
            this.dataCollectionPageTableLayoutPanel.RowCount = 7;
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dataCollectionPageTableLayoutPanel.Size = new System.Drawing.Size(526, 272);
            this.dataCollectionPageTableLayoutPanel.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.dataCollectionPageTableLayoutPanel.SetColumnSpan(this.label9, 2);
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(520, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Please enter some information in the fields below (description is required)...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.dataCollectionPageTableLayoutPanel.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(520, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Press the Next button to continue...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(23, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(23, 0, 3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label8.Size = new System.Drawing.Size(63, 26);
            this.label8.TabIndex = 17;
            this.label8.Text = "Description:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // validatingTextBox
            // 
            this.validatingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validatingTextBox.Location = new System.Drawing.Point(92, 26);
            this.validatingTextBox.Name = "validatingTextBox";
            this.validatingTextBox.Size = new System.Drawing.Size(431, 20);
            this.validatingTextBox.TabIndex = 16;
            this.validatingTextBox.Text = "Wizard Control Demo";
            this.validatingTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.validatingTextBox_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.dataCollectionPageTableLayoutPanel.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 30, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(520, 26);
            this.label7.TabIndex = 23;
            this.label7.Text = "These radio buttons control which page is displayed when clicking \'Next\' (control" +
    "led by the \'NextButtonPressed\' event):";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(92, 52);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(431, 60);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(23, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(23, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label6.Size = new System.Drawing.Size(63, 66);
            this.label6.TabIndex = 20;
            this.label6.Text = "Notes:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // executionPath1
            // 
            this.executionPath1.AutoSize = true;
            this.executionPath1.Checked = true;
            this.dataCollectionPageTableLayoutPanel.SetColumnSpan(this.executionPath1, 2);
            this.executionPath1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executionPath1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.executionPath1.Location = new System.Drawing.Point(23, 184);
            this.executionPath1.Margin = new System.Windows.Forms.Padding(23, 3, 3, 3);
            this.executionPath1.Name = "executionPath1";
            this.executionPath1.Size = new System.Drawing.Size(500, 18);
            this.executionPath1.TabIndex = 21;
            this.executionPath1.TabStop = true;
            this.executionPath1.Text = "Processing Test - First execution path";
            // 
            // executionPath2
            // 
            this.executionPath2.AutoSize = true;
            this.dataCollectionPageTableLayoutPanel.SetColumnSpan(this.executionPath2, 2);
            this.executionPath2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executionPath2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.executionPath2.Location = new System.Drawing.Point(23, 208);
            this.executionPath2.Margin = new System.Windows.Forms.Padding(23, 3, 3, 3);
            this.executionPath2.Name = "executionPath2";
            this.executionPath2.Size = new System.Drawing.Size(500, 18);
            this.executionPath2.TabIndex = 22;
            this.executionPath2.Text = "Custom Appearance Test - Second execution path";
            // 
            // processingPage
            // 
            this.processingPage.BackButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
            this.processingPage.Controls.Add(this.processingPageFlowLayoutPanel);
            this.processingPage.Name = "processingPage";
            this.processingPage.NextButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
            this.processingPage.PageCaption = "Processing Test";
            this.processingPage.PageDescription = "This page demonstrates a processing page where an event takes place before the Wi" +
    "zard buttons are enabled.";
            this.processingPage.PageTitleBarText = "Step 3 (Execution Path 1)";
            this.processingPage.TabIndex = 15;
            // 
            // processingPageFlowLayoutPanel
            // 
            this.processingPageFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.processingPageFlowLayoutPanel.Controls.Add(this.label11);
            this.processingPageFlowLayoutPanel.Controls.Add(this.processingLabel);
            this.processingPageFlowLayoutPanel.Controls.Add(this.progressBar);
            this.processingPageFlowLayoutPanel.Controls.Add(this.cancelPageChangeCheckBox);
            this.processingPageFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processingPageFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.processingPageFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.processingPageFlowLayoutPanel.Name = "processingPageFlowLayoutPanel";
            this.processingPageFlowLayoutPanel.Size = new System.Drawing.Size(526, 272);
            this.processingPageFlowLayoutPanel.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(499, 39);
            this.label11.TabIndex = 1;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // processingLabel
            // 
            this.processingLabel.AutoSize = true;
            this.processingLabel.BackColor = System.Drawing.Color.Transparent;
            this.processingLabel.Location = new System.Drawing.Point(23, 69);
            this.processingLabel.Margin = new System.Windows.Forms.Padding(23, 0, 3, 0);
            this.processingLabel.Name = "processingLabel";
            this.processingLabel.Size = new System.Drawing.Size(88, 13);
            this.processingLabel.TabIndex = 3;
            this.processingLabel.Text = "Ready to begin...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 85);
            this.progressBar.Margin = new System.Windows.Forms.Padding(23, 3, 3, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(228, 18);
            this.progressBar.TabIndex = 2;
            // 
            // cancelPageChangeCheckBox
            // 
            this.cancelPageChangeCheckBox.AutoSize = true;
            this.cancelPageChangeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelPageChangeCheckBox.Location = new System.Drawing.Point(23, 136);
            this.cancelPageChangeCheckBox.Margin = new System.Windows.Forms.Padding(23, 30, 3, 3);
            this.cancelPageChangeCheckBox.Name = "cancelPageChangeCheckBox";
            this.cancelPageChangeCheckBox.Size = new System.Drawing.Size(272, 18);
            this.cancelPageChangeCheckBox.TabIndex = 20;
            this.cancelPageChangeCheckBox.Text = "Prevent page change (simulates manual validation)";
            // 
            // finishPage1
            // 
            this.finishPage1.Controls.Add(this.finishPage1TableLayoutPanel);
            this.finishPage1.FinishButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.True;
            this.finishPage1.Name = "finishPage1";
            this.finishPage1.NextButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
            this.finishPage1.PageCaption = "Finish Page #1";
            this.finishPage1.PageDescription = "The first finish page for the sample Wizard.";
            this.finishPage1.PageTitleBarText = "Step 4 (Execution Path 1)";
            this.finishPage1.TabIndex = 16;
            // 
            // finishPage1TableLayoutPanel
            // 
            this.finishPage1TableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.finishPage1TableLayoutPanel.ColumnCount = 1;
            this.finishPage1TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.finishPage1TableLayoutPanel.Controls.Add(this.label10, 0, 0);
            this.finishPage1TableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.finishPage1TableLayoutPanel.Controls.Add(this.goToSecondExecutionPathButton, 0, 1);
            this.finishPage1TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage1TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.finishPage1TableLayoutPanel.Name = "finishPage1TableLayoutPanel";
            this.finishPage1TableLayoutPanel.RowCount = 3;
            this.finishPage1TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.finishPage1TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.finishPage1TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.finishPage1TableLayoutPanel.Size = new System.Drawing.Size(526, 272);
            this.finishPage1TableLayoutPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.finishPage1Number1Label);
            this.flowLayoutPanel1.Controls.Add(this.finishPage1FinishPageLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(317, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 195);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // finishPage1Number1Label
            // 
            this.finishPage1Number1Label.AutoSize = true;
            this.finishPage1Number1Label.BackColor = System.Drawing.Color.Transparent;
            this.finishPage1Number1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage1Number1Label.Font = new System.Drawing.Font("Verdana", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishPage1Number1Label.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.finishPage1Number1Label.Location = new System.Drawing.Point(3, 79);
            this.finishPage1Number1Label.Name = "finishPage1Number1Label";
            this.finishPage1Number1Label.Size = new System.Drawing.Size(200, 116);
            this.finishPage1Number1Label.TabIndex = 1;
            this.finishPage1Number1Label.Text = "#1";
            // 
            // finishPage1FinishPageLabel
            // 
            this.finishPage1FinishPageLabel.AutoSize = true;
            this.finishPage1FinishPageLabel.BackColor = System.Drawing.Color.Transparent;
            this.finishPage1FinishPageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage1FinishPageLabel.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishPage1FinishPageLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.finishPage1FinishPageLabel.Location = new System.Drawing.Point(3, 56);
            this.finishPage1FinishPageLabel.Name = "finishPage1FinishPageLabel";
            this.finishPage1FinishPageLabel.Size = new System.Drawing.Size(200, 23);
            this.finishPage1FinishPageLabel.TabIndex = 2;
            this.finishPage1FinishPageLabel.Text = "Finish Page";
            this.finishPage1FinishPageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(512, 39);
            this.label10.TabIndex = 0;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // goToSecondExecutionPathButton
            // 
            this.goToSecondExecutionPathButton.AutoSize = true;
            this.goToSecondExecutionPathButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.goToSecondExecutionPathButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.goToSecondExecutionPathButton.Location = new System.Drawing.Point(23, 49);
            this.goToSecondExecutionPathButton.Margin = new System.Windows.Forms.Padding(23, 10, 3, 0);
            this.goToSecondExecutionPathButton.Name = "goToSecondExecutionPathButton";
            this.goToSecondExecutionPathButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.goToSecondExecutionPathButton.Size = new System.Drawing.Size(202, 22);
            this.goToSecondExecutionPathButton.TabIndex = 3;
            this.goToSecondExecutionPathButton.Text = "View custom appearance features";
            this.goToSecondExecutionPathButton.Click += new System.EventHandler(this.goToSecondExecutionPathButton_Click);
            // 
            // finishPage2
            // 
            this.finishPage2.Controls.Add(this.finishPage2TableLayoutPanel);
            this.finishPage2.Name = "finishPage2";
            this.finishPage2.PageCaption = "Finish Page #2";
            this.finishPage2.PageDescription = "The second finish page for the sample Wizard.";
            this.finishPage2.PageTitleBarText = "Step 5 (Execution Path 2)";
            this.finishPage2.TabIndex = 17;
            // 
            // finishPage2TableLayoutPanel
            // 
            this.finishPage2TableLayoutPanel.ColumnCount = 1;
            this.finishPage2TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.finishPage2TableLayoutPanel.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.finishPage2TableLayoutPanel.Controls.Add(this.label15, 0, 0);
            this.finishPage2TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage2TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.finishPage2TableLayoutPanel.Name = "finishPage2TableLayoutPanel";
            this.finishPage2TableLayoutPanel.RowCount = 2;
            this.finishPage2TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.finishPage2TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.finishPage2TableLayoutPanel.Size = new System.Drawing.Size(526, 272);
            this.finishPage2TableLayoutPanel.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.finishPage2Number2Label);
            this.flowLayoutPanel2.Controls.Add(this.finishPage2FinishPageLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(317, 29);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(206, 240);
            this.flowLayoutPanel2.TabIndex = 7;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // finishPage2FinishPageLabel
            // 
            this.finishPage2FinishPageLabel.AutoSize = true;
            this.finishPage2FinishPageLabel.BackColor = System.Drawing.Color.Transparent;
            this.finishPage2FinishPageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage2FinishPageLabel.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.finishPage2FinishPageLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.finishPage2FinishPageLabel.Location = new System.Drawing.Point(3, 101);
            this.finishPage2FinishPageLabel.Name = "finishPage2FinishPageLabel";
            this.finishPage2FinishPageLabel.Size = new System.Drawing.Size(200, 23);
            this.finishPage2FinishPageLabel.TabIndex = 5;
            this.finishPage2FinishPageLabel.Text = "Finish Page";
            this.finishPage2FinishPageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // finishPage2Number2Label
            // 
            this.finishPage2Number2Label.AutoSize = true;
            this.finishPage2Number2Label.BackColor = System.Drawing.Color.Transparent;
            this.finishPage2Number2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPage2Number2Label.Font = new System.Drawing.Font("Verdana", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishPage2Number2Label.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.finishPage2Number2Label.Location = new System.Drawing.Point(3, 124);
            this.finishPage2Number2Label.Name = "finishPage2Number2Label";
            this.finishPage2Number2Label.Size = new System.Drawing.Size(200, 116);
            this.finishPage2Number2Label.TabIndex = 4;
            this.finishPage2Number2Label.Text = "#2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(520, 26);
            this.label15.TabIndex = 3;
            this.label15.Text = "This page is the finish page for the second execution page of the Wizard.  Try us" +
    "ing the Wizard yourself in the design-time environment to see how it enhances yo" +
    "ur productivity.";
            // 
            // windowsXPPage
            // 
            this.windowsXPPage.BackgroundFill = new ActiproSoftware.UI.WinForms.Drawing.SolidColorBackgroundFill(System.Drawing.Color.CornflowerBlue);
            this.windowsXPPage.Controls.Add(this.windowsXPTabelLayoutPanel);
            this.windowsXPPage.IsInteriorPage = false;
            this.windowsXPPage.Name = "windowsXPPage";
            this.windowsXPPage.PageCaption = "Custom Draw Page";
            this.windowsXPPage.PageDescription = "A page that has some custom drawing code.";
            this.windowsXPPage.PageTitleBarText = "Step 4 (Execution Path 2)";
            this.windowsXPPage.TabIndex = 18;
            this.windowsXPPage.Resize += new System.EventHandler(this.windowsXPPage_Resize);
            // 
            // windowsXPTabelLayoutPanel
            // 
            this.windowsXPTabelLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.windowsXPTabelLayoutPanel.ColumnCount = 1;
            this.windowsXPTabelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.windowsXPTabelLayoutPanel.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.windowsXPTabelLayoutPanel.Controls.Add(this.windowsXPMessageLabel, 0, 1);
            this.windowsXPTabelLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsXPTabelLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.windowsXPTabelLayoutPanel.Name = "windowsXPTabelLayoutPanel";
            this.windowsXPTabelLayoutPanel.RowCount = 2;
            this.windowsXPTabelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.windowsXPTabelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.windowsXPTabelLayoutPanel.Size = new System.Drawing.Size(558, 364);
            this.windowsXPTabelLayoutPanel.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.windowsXPActiproLabel);
            this.flowLayoutPanel3.Controls.Add(this.windowsXPWizardLabel);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(244, 63);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 63, 3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(311, 244);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // windowsXPActiproLabel
            // 
            this.windowsXPActiproLabel.AutoSize = true;
            this.windowsXPActiproLabel.BackColor = System.Drawing.Color.Transparent;
            this.windowsXPActiproLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsXPActiproLabel.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsXPActiproLabel.ForeColor = System.Drawing.Color.LightSalmon;
            this.windowsXPActiproLabel.Location = new System.Drawing.Point(3, 0);
            this.windowsXPActiproLabel.Name = "windowsXPActiproLabel";
            this.windowsXPActiproLabel.Size = new System.Drawing.Size(305, 35);
            this.windowsXPActiproLabel.TabIndex = 0;
            this.windowsXPActiproLabel.Text = "Actipro";
            // 
            // windowsXPWizardLabel
            // 
            this.windowsXPWizardLabel.AutoSize = true;
            this.windowsXPWizardLabel.BackColor = System.Drawing.Color.Transparent;
            this.windowsXPWizardLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsXPWizardLabel.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsXPWizardLabel.ForeColor = System.Drawing.Color.White;
            this.windowsXPWizardLabel.Location = new System.Drawing.Point(23, 35);
            this.windowsXPWizardLabel.Margin = new System.Windows.Forms.Padding(23, 0, 3, 0);
            this.windowsXPWizardLabel.Name = "windowsXPWizardLabel";
            this.windowsXPWizardLabel.Size = new System.Drawing.Size(285, 78);
            this.windowsXPWizardLabel.TabIndex = 1;
            this.windowsXPWizardLabel.Text = "Wizard";
            // 
            // windowsXPMessageLabel
            // 
            this.windowsXPMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.windowsXPMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsXPMessageLabel.ForeColor = System.Drawing.Color.White;
            this.windowsXPMessageLabel.Location = new System.Drawing.Point(3, 310);
            this.windowsXPMessageLabel.Name = "windowsXPMessageLabel";
            this.windowsXPMessageLabel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.windowsXPMessageLabel.Size = new System.Drawing.Size(1, 54);
            this.windowsXPMessageLabel.TabIndex = 2;
            this.windowsXPMessageLabel.Text = "Create custom draw Wizard pages like this one that have the classic Windows XP ap" +
    "pearance";
            this.windowsXPMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataMember = "";
            // 
            // customAppearancesPage
            // 
            this.customAppearancesPage.Controls.Add(this.customAppearancesPageTableLayoutPanel);
            this.customAppearancesPage.Name = "customAppearancesPage";
            this.customAppearancesPage.PageCaption = "Custom Appearances";
            this.customAppearancesPage.PageDescription = "Each wizard\'s appearance can be completely customized, with both global Wizard re" +
    "ndering settings and page-specific overrides.";
            this.customAppearancesPage.PageTitleBarText = "Step 3 (Execution Path 2)";
            this.customAppearancesPage.TabIndex = 19;
            // 
            // customAppearancesPageTableLayoutPanel
            // 
            this.customAppearancesPageTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.customAppearancesPageTableLayoutPanel.ColumnCount = 1;
            this.customAppearancesPageTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customAppearancesPageTableLayoutPanel.Controls.Add(this.label19, 0, 0);
            this.customAppearancesPageTableLayoutPanel.Controls.Add(this.label20, 0, 2);
            this.customAppearancesPageTableLayoutPanel.Controls.Add(this.customAppearanceListBox, 0, 1);
            this.customAppearancesPageTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customAppearancesPageTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.customAppearancesPageTableLayoutPanel.Name = "customAppearancesPageTableLayoutPanel";
            this.customAppearancesPageTableLayoutPanel.RowCount = 3;
            this.customAppearancesPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.customAppearancesPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customAppearancesPageTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.customAppearancesPageTableLayoutPanel.Size = new System.Drawing.Size(526, 272);
            this.customAppearancesPageTableLayoutPanel.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(520, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Select a different item in the list below to see how easy it is to customize a pa" +
    "ge\'s appearance:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(3, 233);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(520, 39);
            this.label20.TabIndex = 2;
            this.label20.Text = resources.GetString("label20.Text");
            // 
            // customAppearanceListBox
            // 
            this.customAppearanceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customAppearanceListBox.Items.AddRange(new object[] {
            "Wizard Default (No page override)",
            "Red",
            "Blue",
            "Rainbow"});
            this.customAppearanceListBox.Location = new System.Drawing.Point(23, 26);
            this.customAppearanceListBox.Margin = new System.Windows.Forms.Padding(23, 3, 23, 3);
            this.customAppearanceListBox.Name = "customAppearanceListBox";
            this.customAppearanceListBox.Size = new System.Drawing.Size(480, 174);
            this.customAppearanceListBox.TabIndex = 1;
            this.customAppearanceListBox.SelectedIndexChanged += new System.EventHandler(this.customAppearanceListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(558, 403);
            this.MinimumSize = new System.Drawing.Size(417, 325);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TitleBarText = "Wizard C# Sample";
            this.TitleStyle = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogTitleStyle.PageTitleBarText;
            ((System.ComponentModel.ISupportInitialize)(this.Wizard)).EndInit();
            this.startPage.ResumeLayout(false);
            this.startPageTableLayoutPanel.ResumeLayout(false);
            this.startPageTableLayoutPanel.PerformLayout();
            this.startPageFlowLayoutPanel.ResumeLayout(false);
            this.startPageFlowLayoutPanel.PerformLayout();
            this.dataCollectionPage.ResumeLayout(false);
            this.dataCollectionPageTableLayoutPanel.ResumeLayout(false);
            this.dataCollectionPageTableLayoutPanel.PerformLayout();
            this.processingPage.ResumeLayout(false);
            this.processingPageFlowLayoutPanel.ResumeLayout(false);
            this.processingPageFlowLayoutPanel.PerformLayout();
            this.finishPage1.ResumeLayout(false);
            this.finishPage1TableLayoutPanel.ResumeLayout(false);
            this.finishPage1TableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.finishPage2.ResumeLayout(false);
            this.finishPage2TableLayoutPanel.ResumeLayout(false);
            this.finishPage2TableLayoutPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.windowsXPPage.ResumeLayout(false);
            this.windowsXPTabelLayoutPanel.ResumeLayout(false);
            this.windowsXPTabelLayoutPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.customAppearancesPage.ResumeLayout(false);
            this.customAppearancesPageTableLayoutPanel.ResumeLayout(false);
            this.customAppearancesPageTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton executionPath2;
		private System.Windows.Forms.RadioButton executionPath1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label processingLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label finishPage1Number1Label;
		private System.Windows.Forms.Label finishPage1FinishPageLabel;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardWelcomePage startPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage dataCollectionPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage processingPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage finishPage1;
		private System.Windows.Forms.Label finishPage2FinishPageLabel;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label finishPage2Number2Label;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage finishPage2;
		private System.Windows.Forms.Label windowsXPActiproLabel;
		private System.Windows.Forms.Label windowsXPWizardLabel;
		private System.Windows.Forms.CheckBox cancelPageChangeCheckBox;
		private System.Windows.Forms.TextBox validatingTextBox;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage windowsXPPage;
		private System.Windows.Forms.Label windowsXPMessageLabel;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage customAppearancesPage;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ListBox customAppearanceListBox;
		private System.Windows.Forms.Button goToSecondExecutionPathButton;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TableLayoutPanel startPageTableLayoutPanel;
		private System.Windows.Forms.Label welcomeLabel;
		private System.Windows.Forms.FlowLayoutPanel startPageFlowLayoutPanel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel infoWebSiteLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel dataCollectionPageTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel processingPageFlowLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel finishPage1TableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel customAppearancesPageTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel finishPage2TableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel windowsXPTabelLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
	}
}
