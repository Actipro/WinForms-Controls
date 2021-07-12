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
			this.infoWebSiteLabel = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataCollectionPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.label5 = new System.Windows.Forms.Label();
			this.validatingTextBox = new System.Windows.Forms.TextBox();
			this.executionPath1 = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.executionPath2 = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.processingPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.cancelPageChangeCheckBox = new System.Windows.Forms.CheckBox();
			this.processingLabel = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label11 = new System.Windows.Forms.Label();
			this.finishPage1 = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.goToSecondExecutionPathButton = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.finishPage2 = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.windowsXPPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.windowsXPMessageLabel = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.customAppearancesPage = new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage();
			this.label20 = new System.Windows.Forms.Label();
			this.customAppearanceListBox = new System.Windows.Forms.ListBox();
			this.label19 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Wizard)).BeginInit();
			this.startPage.SuspendLayout();
			this.dataCollectionPage.SuspendLayout();
			this.processingPage.SuspendLayout();
			this.finishPage1.SuspendLayout();
			this.finishPage2.SuspendLayout();
			this.windowsXPPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.customAppearancesPage.SuspendLayout();
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
			this.startPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startPage.BackColor = System.Drawing.SystemColors.Window;
			this.startPage.Controls.Add(this.infoWebSiteLabel);
			this.startPage.Controls.Add(this.label4);
			this.startPage.Controls.Add(this.label3);
			this.startPage.Controls.Add(this.label2);
			this.startPage.Controls.Add(this.label1);
			this.startPage.IsInteriorPage = false;
			this.startPage.Location = new System.Drawing.Point(0, 0);
			this.startPage.Name = "startPage";
			this.startPage.PageTitleBarText = "Step 1";
			this.startPage.Size = new System.Drawing.Size(558, 364);
			this.startPage.TabIndex = 0;
			this.startPage.WatermarkImage = ((System.Drawing.Image)(resources.GetObject("startPage.WatermarkImage")));
			this.startPage.WatermarkImageLocation = new System.Drawing.Point(96, 18);
			// 
			// infoWebSiteLabel
			// 
			this.infoWebSiteLabel.AutoSize = true;
			this.infoWebSiteLabel.BackColor = System.Drawing.Color.Transparent;
			this.infoWebSiteLabel.Location = new System.Drawing.Point(217, 220);
			this.infoWebSiteLabel.Name = "infoWebSiteLabel";
			this.infoWebSiteLabel.Size = new System.Drawing.Size(186, 15);
			this.infoWebSiteLabel.TabIndex = 0;
			this.infoWebSiteLabel.TabStop = true;
			this.infoWebSiteLabel.Text = "https://www.actiprosoftware.com";
			this.infoWebSiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.infoWebSiteLabel_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(196, 204);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(327, 15);
			this.label4.TabIndex = 13;
			this.label4.Text = "Visit our web site for new versions and licensing information:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(178, 336);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "To continue, click Next.";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(178, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(316, 60);
			this.label2.TabIndex = 2;
			this.label2.Text = "Thank you for downloading the Wizard control.  This test application demonstrates" +
    " many of the features of the Wizard control.";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(176, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(309, 55);
			this.label1.TabIndex = 1;
			this.label1.Text = "Welcome to the Wizard Test Application";
			// 
			// dataCollectionPage
			// 
			this.dataCollectionPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataCollectionPage.Controls.Add(this.label5);
			this.dataCollectionPage.Controls.Add(this.validatingTextBox);
			this.dataCollectionPage.Controls.Add(this.executionPath1);
			this.dataCollectionPage.Controls.Add(this.label8);
			this.dataCollectionPage.Controls.Add(this.textBox2);
			this.dataCollectionPage.Controls.Add(this.label9);
			this.dataCollectionPage.Controls.Add(this.label7);
			this.dataCollectionPage.Controls.Add(this.executionPath2);
			this.dataCollectionPage.Controls.Add(this.label6);
			this.dataCollectionPage.Location = new System.Drawing.Point(16, 76);
			this.dataCollectionPage.Name = "dataCollectionPage";
			this.dataCollectionPage.PageCaption = "Information Gathering";
			this.dataCollectionPage.PageDescription = "This page demonstrates how simple it is for the Wizard to gather information from" +
    " users in a friendly way.";
			this.dataCollectionPage.PageTitleBarText = "Step 2";
			this.dataCollectionPage.Size = new System.Drawing.Size(526, 272);
			this.dataCollectionPage.TabIndex = 14;
			this.dataCollectionPage.NextButtonClick += new ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPageCancelEventHandler(this.dataCollectionPage_NextButtonClick);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(0, 256);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(194, 15);
			this.label5.TabIndex = 18;
			this.label5.Text = "Press the Next button to continue...";
			// 
			// validatingTextBox
			// 
			this.validatingTextBox.Location = new System.Drawing.Point(84, 21);
			this.validatingTextBox.Name = "validatingTextBox";
			this.validatingTextBox.Size = new System.Drawing.Size(166, 23);
			this.validatingTextBox.TabIndex = 16;
			this.validatingTextBox.Text = "Wizard Control Demo";
			this.validatingTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.validatingTextBox_Validating);
			// 
			// executionPath1
			// 
			this.executionPath1.Checked = true;
			this.executionPath1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.executionPath1.Location = new System.Drawing.Point(68, 196);
			this.executionPath1.Name = "executionPath1";
			this.executionPath1.Size = new System.Drawing.Size(378, 18);
			this.executionPath1.TabIndex = 21;
			this.executionPath1.TabStop = true;
			this.executionPath1.Text = "Processing Test - First execution path";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Location = new System.Drawing.Point(20, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 15);
			this.label8.TabIndex = 17;
			this.label8.Text = "Description";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(84, 48);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(416, 115);
			this.textBox2.TabIndex = 19;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Location = new System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(404, 15);
			this.label9.TabIndex = 15;
			this.label9.Text = "Please enter some information in the fields below (description is required)...";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(0, 176);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(525, 15);
			this.label7.TabIndex = 23;
			this.label7.Text = "These radio buttons set the page with which to finish (controlled by the NextButt" +
    "onPressed event).";
			// 
			// executionPath2
			// 
			this.executionPath2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.executionPath2.Location = new System.Drawing.Point(68, 216);
			this.executionPath2.Name = "executionPath2";
			this.executionPath2.Size = new System.Drawing.Size(389, 18);
			this.executionPath2.TabIndex = 22;
			this.executionPath2.Text = "Custom Appearance Test - Second execution path";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(44, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 15);
			this.label6.TabIndex = 20;
			this.label6.Text = "Notes";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// processingPage
			// 
			this.processingPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.processingPage.BackButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
			this.processingPage.Controls.Add(this.cancelPageChangeCheckBox);
			this.processingPage.Controls.Add(this.processingLabel);
			this.processingPage.Controls.Add(this.progressBar);
			this.processingPage.Controls.Add(this.label11);
			this.processingPage.Location = new System.Drawing.Point(16, 76);
			this.processingPage.Name = "processingPage";
			this.processingPage.NextButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
			this.processingPage.PageCaption = "Processing Test";
			this.processingPage.PageDescription = "This page demonstrates a processing page where an event takes place before the Wi" +
    "zard buttons are enabled.";
			this.processingPage.PageTitleBarText = "Step 3 (Execution Path 1)";
			this.processingPage.Size = new System.Drawing.Size(526, 272);
			this.processingPage.TabIndex = 15;
			// 
			// cancelPageChangeCheckBox
			// 
			this.cancelPageChangeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelPageChangeCheckBox.Location = new System.Drawing.Point(115, 192);
			this.cancelPageChangeCheckBox.Name = "cancelPageChangeCheckBox";
			this.cancelPageChangeCheckBox.Size = new System.Drawing.Size(309, 19);
			this.cancelPageChangeCheckBox.TabIndex = 20;
			this.cancelPageChangeCheckBox.Text = "Prevent page change (simulates manual validation)";
			// 
			// processingLabel
			// 
			this.processingLabel.AutoSize = true;
			this.processingLabel.BackColor = System.Drawing.Color.Transparent;
			this.processingLabel.Location = new System.Drawing.Point(113, 109);
			this.processingLabel.Name = "processingLabel";
			this.processingLabel.Size = new System.Drawing.Size(95, 15);
			this.processingLabel.TabIndex = 3;
			this.processingLabel.Text = "Ready to begin...";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(115, 129);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(274, 22);
			this.progressBar.TabIndex = 2;
			// 
			// label11
			// 
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Location = new System.Drawing.Point(0, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(526, 116);
			this.label11.TabIndex = 1;
			this.label11.Text = resources.GetString("label11.Text");
			// 
			// finishPage1
			// 
			this.finishPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.finishPage1.Controls.Add(this.goToSecondExecutionPathButton);
			this.finishPage1.Controls.Add(this.label13);
			this.finishPage1.Controls.Add(this.label10);
			this.finishPage1.Controls.Add(this.label12);
			this.finishPage1.FinishButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.True;
			this.finishPage1.Location = new System.Drawing.Point(16, 76);
			this.finishPage1.Name = "finishPage1";
			this.finishPage1.NextButtonEnabled = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardButtonEnabledDefault.False;
			this.finishPage1.PageCaption = "Finish Page #1";
			this.finishPage1.PageDescription = "The first finish page for the sample Wizard.";
			this.finishPage1.PageTitleBarText = "Step 4 (Execution Path 1)";
			this.finishPage1.Size = new System.Drawing.Size(526, 272);
			this.finishPage1.TabIndex = 16;
			// 
			// goToSecondExecutionPathButton
			// 
			this.goToSecondExecutionPathButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.goToSecondExecutionPathButton.Location = new System.Drawing.Point(16, 56);
			this.goToSecondExecutionPathButton.Name = "goToSecondExecutionPathButton";
			this.goToSecondExecutionPathButton.Size = new System.Drawing.Size(256, 23);
			this.goToSecondExecutionPathButton.TabIndex = 3;
			this.goToSecondExecutionPathButton.Text = "View custom appearance features";
			this.goToSecondExecutionPathButton.Click += new System.EventHandler(this.goToSecondExecutionPathButton_Click);
			// 
			// label13
			// 
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(218, 168);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(110, 25);
			this.label13.TabIndex = 2;
			this.label13.Text = "Finish Page";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Location = new System.Drawing.Point(0, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(526, 56);
			this.label10.TabIndex = 0;
			this.label10.Text = resources.GetString("label10.Text");
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Font = new System.Drawing.Font("Verdana", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.label12.Location = new System.Drawing.Point(316, 144);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(201, 109);
			this.label12.TabIndex = 1;
			this.label12.Text = "#1";
			// 
			// finishPage2
			// 
			this.finishPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.finishPage2.Controls.Add(this.label14);
			this.finishPage2.Controls.Add(this.label15);
			this.finishPage2.Controls.Add(this.label16);
			this.finishPage2.Location = new System.Drawing.Point(16, 76);
			this.finishPage2.Name = "finishPage2";
			this.finishPage2.PageCaption = "Finish Page #2";
			this.finishPage2.PageDescription = "The second finish page for the sample Wizard.";
			this.finishPage2.PageTitleBarText = "Step 5 (Execution Path 2)";
			this.finishPage2.Size = new System.Drawing.Size(526, 272);
			this.finishPage2.TabIndex = 17;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(218, 168);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(110, 25);
			this.label14.TabIndex = 5;
			this.label14.Text = "Finish Page";
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.Location = new System.Drawing.Point(0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(500, 62);
			this.label15.TabIndex = 3;
			this.label15.Text = "This page is the finish page for the second execution page of the Wizard.  Try us" +
    "ing the Wizard yourself in the design-time environment to see how it enhances yo" +
    "ur productivity.";
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.Font = new System.Drawing.Font("Verdana", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.label16.Location = new System.Drawing.Point(316, 144);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(201, 109);
			this.label16.TabIndex = 4;
			this.label16.Text = "#2";
			// 
			// windowsXPPage
			// 
			this.windowsXPPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.windowsXPPage.BackgroundFill = new ActiproSoftware.UI.WinForms.Drawing.SolidColorBackgroundFill(System.Drawing.Color.CornflowerBlue);
			this.windowsXPPage.Controls.Add(this.windowsXPMessageLabel);
			this.windowsXPPage.Controls.Add(this.label18);
			this.windowsXPPage.Controls.Add(this.label17);
			this.windowsXPPage.IsInteriorPage = false;
			this.windowsXPPage.Location = new System.Drawing.Point(0, 0);
			this.windowsXPPage.Name = "windowsXPPage";
			this.windowsXPPage.PageCaption = "Custom Draw Page";
			this.windowsXPPage.PageDescription = "A page that has some custom drawing code.";
			this.windowsXPPage.PageTitleBarText = "Step 4 (Execution Path 2)";
			this.windowsXPPage.Size = new System.Drawing.Size(558, 364);
			this.windowsXPPage.TabIndex = 18;
			// 
			// windowsXPMessageLabel
			// 
			this.windowsXPMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.windowsXPMessageLabel.BackColor = System.Drawing.Color.Transparent;
			this.windowsXPMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowsXPMessageLabel.ForeColor = System.Drawing.Color.White;
			this.windowsXPMessageLabel.Location = new System.Drawing.Point(16, 303);
			this.windowsXPMessageLabel.Name = "windowsXPMessageLabel";
			this.windowsXPMessageLabel.Size = new System.Drawing.Size(520, 53);
			this.windowsXPMessageLabel.TabIndex = 2;
			this.windowsXPMessageLabel.Text = "Create custom draw Wizard pages like this one that have the Windows XP appearance" +
    "";
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(267, 92);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(285, 78);
			this.label18.TabIndex = 1;
			this.label18.Text = "Wizard";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.Color.LightSalmon;
			this.label17.Location = new System.Drawing.Point(242, 53);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(132, 35);
			this.label17.TabIndex = 0;
			this.label17.Text = "Actipro";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			this.errorProvider.DataMember = "";
			// 
			// customAppearancesPage
			// 
			this.customAppearancesPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.customAppearancesPage.Controls.Add(this.label20);
			this.customAppearancesPage.Controls.Add(this.customAppearanceListBox);
			this.customAppearancesPage.Controls.Add(this.label19);
			this.customAppearancesPage.Location = new System.Drawing.Point(16, 76);
			this.customAppearancesPage.Name = "customAppearancesPage";
			this.customAppearancesPage.PageCaption = "Custom Appearances";
			this.customAppearancesPage.PageDescription = "Each wizard\'s appearance can be completely customized, with both global Wizard re" +
    "ndering settings and page-specific overrides.";
			this.customAppearancesPage.PageTitleBarText = "Step 3 (Execution Path 2)";
			this.customAppearancesPage.Size = new System.Drawing.Size(526, 272);
			this.customAppearancesPage.TabIndex = 19;
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label20.BackColor = System.Drawing.Color.Transparent;
			this.label20.Location = new System.Drawing.Point(0, 88);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(512, 48);
			this.label20.TabIndex = 2;
			this.label20.Text = resources.GetString("label20.Text");
			// 
			// customAppearanceListBox
			// 
			this.customAppearanceListBox.ItemHeight = 15;
			this.customAppearanceListBox.Items.AddRange(new object[] {
            "Wizard Default (No page override)",
            "Red",
            "Blue",
            "Rainbow"});
			this.customAppearanceListBox.Location = new System.Drawing.Point(16, 16);
			this.customAppearanceListBox.Name = "customAppearanceListBox";
			this.customAppearanceListBox.Size = new System.Drawing.Size(256, 49);
			this.customAppearanceListBox.TabIndex = 1;
			this.customAppearanceListBox.SelectedIndexChanged += new System.EventHandler(this.customAppearanceListBox_SelectedIndexChanged);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.Location = new System.Drawing.Point(0, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(499, 15);
			this.label19.TabIndex = 0;
			this.label19.Text = "Select a different item in the list below to see how easy it is to customize a pa" +
    "ge\'s appearance:";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(558, 403);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TitleBarText = "Wizard C# Sample";
			this.TitleStyle = ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogTitleStyle.PageTitleBarText;
			((System.ComponentModel.ISupportInitialize)(this.Wizard)).EndInit();
			this.startPage.ResumeLayout(false);
			this.startPage.PerformLayout();
			this.dataCollectionPage.ResumeLayout(false);
			this.dataCollectionPage.PerformLayout();
			this.processingPage.ResumeLayout(false);
			this.processingPage.PerformLayout();
			this.finishPage1.ResumeLayout(false);
			this.finishPage2.ResumeLayout(false);
			this.windowsXPPage.ResumeLayout(false);
			this.windowsXPPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.customAppearancesPage.ResumeLayout(false);
			this.customAppearancesPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel infoWebSiteLabel;
		private System.Windows.Forms.Label label4;
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
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardWelcomePage startPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage dataCollectionPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage processingPage;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage finishPage1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage finishPage2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
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
	}
}
