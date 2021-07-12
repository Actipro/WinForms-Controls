using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.UI.WinForms.Controls.Wizard;

namespace ActiproSoftware.ProductSamples.WizardSamples.Demo.Features {

	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public partial class MainForm : ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm {

		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Set up the custom appearance pages
			customAppearanceListBox.SelectedIndex = 1;
			windowsXPPage.BackgroundFill = new WindowsXPBackgroundFill();

			// Set the active control to the Wizard... this works around a .NET framework focus bug with ContainerControls where
			//   focus won't enter the Wizard until a mouse click occurs
			this.ActiveControl = this.Wizard;
		}

		/// <summary>
		/// Occurs when Back button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
		/// </summary>
		/// <param name="e">A <c>WizardPageCancelEventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// Note how it cancels the default page sequencing and decides to go to the data entry page
		/// if using normal page sequencing and if the custom appearances page is selected.  
		/// This programmatically skips over the other sequence of pages
		/// that are in between the data entry page and the custom appearances page.
		/// </remarks>
		protected override void OnBackButtonClick(WizardPageCancelEventArgs e) {
			if (this.Wizard.PageSequenceType == WizardPageSequenceType.Normal) {
				if (this.Wizard.SelectedPage == customAppearancesPage) {
					e.Cancel = true;
					this.Wizard.SelectedPage = dataCollectionPage;
				}
			}
		}

		/// <summary>
		/// Occurs when Cancel button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		protected override void OnCancelButtonClick(EventArgs e) {
			// Close the form
			this.Close();
		}

		/// <summary>
		/// Occurs when Finish button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// This is where you would perform the finishing tasks of the this.Wizard.
		/// </remarks>
		protected override void OnFinishButtonClick(EventArgs e) {
			// Display a message
			MessageBox.Show("The wizard is finished.", "Wizard");

			// Close the form
			this.Close();
		}

		/// <summary>
		/// Occurs when Help button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// Display help for the current wizard step when this button is pressed.
		/// </remarks>
		protected override void OnHelpButtonClick(EventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com");
		}

		/// <summary>
		/// Occurs when control is requested to lay out it's child controls.
		/// </summary>
		/// <param name="e">A <c>WizardLayoutButtonsEventArgs</c> that contains the event data.</param>
		protected override void OnLayoutButtons(WizardLayoutButtonsEventArgs e) {
		}

		/// <summary>
		/// Occurs when Next button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
		/// </summary>
		/// <param name="e">A <c>WizardPageCancelEventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// This event is raised if there is not an event handler for the currently selected page's associated
		/// event.  For instance, since a NextButtonClick event handler is defined for the data collection page
		/// in this sample application, this event will not fire when the data collection page is selected and
		/// the Next button is clicked.
		/// </remarks>
		protected override void OnNextButtonClick(WizardPageCancelEventArgs e) {
			// You can override default page sequencing here by setting e.Cancel = true
			// and setting this.Wizard.SelectedIndex to a valid page index
		}

		/// <summary>
		/// Occurs after a page is selected.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		protected override void OnSelectionChanged(EventArgs e) {
			if (this.Wizard.SelectedPage != null)
				Console.WriteLine("SelectionChanged: {0} (Page #{1})", this.Wizard.SelectedPage.PageCaption, this.Wizard.SelectedIndex + 1);

			// When the processing page is being selected it is set up in the designer to disable all
			// wizard buttons while processing is occurring... 
			// Do some processing here and then re-enable the appropriate buttons using code
			if (this.Wizard.SelectedPage == processingPage) {
				// Clear the processing amount
				progressBar.Value = 0;
				processingLabel.Text = "Ready to start...";

				// Make the thread sleep for a second to simulate some simple processing
				for (int i = 0; i < 10; i++) {
					Thread.Sleep(100);
					progressBar.Value += 10;
					processingLabel.Text = "Processing amount: " + i * 10 + "%";
					Application.DoEvents();
				}

				// Re-enable the buttons now that the processing is complete
				processingLabel.Text = "Processing complete!";
				this.Wizard.BackButtonEnabled = true;
				this.Wizard.NextButtonEnabled = true;
			}
		}

		/// <summary>
		/// Occurs before a page is selected.
		/// </summary>
		/// <param name="e">A <c>WizardPageCancelEventArgs</c> that contains the event data.</param>
		protected override void OnSelectionChanging(WizardPageCancelEventArgs e) {
			if (cancelPageChangeCheckBox.Checked) {
				// You can perform validation and cancel page switching here by setting e.Cancel = true.
				e.Cancel = true;
				Console.WriteLine("SelectionChanging: Programmatically cancelled page change.");
				return;
			}

			if (this.Wizard.SelectedIndex != -1) {
				if (e.Page == null)
					Console.WriteLine("SelectionChanging: {0} (Page #{1})", this.Wizard.SelectedPage.PageCaption, this.Wizard.SelectedIndex + 1);
				else
					Console.WriteLine("SelectionChanging: {0} (Page #{1}) --> {2} (Page #{3})",
						this.Wizard.SelectedPage.PageCaption, this.Wizard.SelectedIndex + 1,
						e.Page.PageCaption, this.Wizard.Pages.IndexOf(e.Page) + 1);
			}
		}

		/// <summary>
		/// Occurs when the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void customAppearanceListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			switch (customAppearanceListBox.SelectedIndex) {
				case 0:  // Default
					customAppearancesPage.InteriorPageHeaderBackgroundFill = null;
					customAppearancesPage.BackgroundFill = null;
					customAppearancesPage.ButtonContainerBackgroundFill = null;
					break;
				case 1:  // Red
					customAppearancesPage.InteriorPageHeaderBackgroundFill = new TwoColorLinearGradient(Color.White, Color.SeaShell, 90, TwoColorLinearGradientStyle.Normal);
					customAppearancesPage.BackgroundFill = new TwoColorLinearGradient(Color.AntiqueWhite, Color.LightSalmon, 90, TwoColorLinearGradientStyle.Normal);
					customAppearancesPage.ButtonContainerBackgroundFill = new TwoColorLinearGradient(Color.IndianRed, Color.SaddleBrown, 90, TwoColorLinearGradientStyle.Normal);
					break;
				case 2: {  // Blue
						customAppearancesPage.InteriorPageHeaderBackgroundFill = new TwoColorLinearGradient(Color.White, Color.LightSteelBlue, 0, TwoColorLinearGradientStyle.Normal);
						customAppearancesPage.BackgroundFill = new TwoColorLinearGradient(Color.White, Color.LightSteelBlue, 90, TwoColorLinearGradientStyle.Normal);
						customAppearancesPage.ButtonContainerBackgroundFill = new TwoColorLinearGradient(Color.LightSteelBlue, Color.SteelBlue, 90, TwoColorLinearGradientStyle.Normal);
						break;
					}
				case 3:  // Rainbow
					customAppearancesPage.InteriorPageHeaderBackgroundFill = new TwoColorLinearGradient(Color.White, Color.Silver, 90, TwoColorLinearGradientStyle.Normal);
					MultiColorLinearGradient gradient = new MultiColorLinearGradient();
					gradient.Angle = 75;
					gradient.StartColor = Color.Red;
					gradient.IntermediateColors = new LinearGradientColorPosition[] {
						new LinearGradientColorPosition(Color.Yellow, 0.3f),
						new LinearGradientColorPosition(Color.Green, 0.5f),
						new LinearGradientColorPosition(Color.Blue, 0.7f),
						};
					gradient.EndColor = Color.Violet;
					customAppearancesPage.BackgroundFill = gradient;
					customAppearancesPage.ButtonContainerBackgroundFill = null;
					break;
			}
		}

		/// <summary>
		/// Occurs when the Wizard's Next button is clicked and the data collection page is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">A <c>WizardPageCancelEventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// Since this event handler was defined, the NextButtonClick event for the Wizard control will
		/// not fire when the Next button is clicked on the data collection page only.
		/// <para>
		/// Note how this event handler cancels the default page sequencing and decides 
		/// to go to one page or the other based on the setting of the radio buttons.
		/// </para>
		/// </remarks>
		private void dataCollectionPage_NextButtonClick(object sender, ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPageCancelEventArgs e) {
			e.Cancel = true;
			if (executionPath1.Checked)
				this.Wizard.SelectedPage = processingPage;
			else
				this.Wizard.SelectedPage = customAppearancesPage;
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void goToSecondExecutionPathButton_Click(object sender, System.EventArgs e) {
			this.Wizard.SelectedPage = customAppearancesPage;
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void infoWebSiteLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser(((LinkLabel)sender).Text);
		}

		/// <summary>
		/// Occurs when the textbox is validating.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void validatingTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			if ((this.Wizard.SelectedPage == dataCollectionPage) && (validatingTextBox.Text.Length == 0)) {
				// User has not entered a description, prompt with error provider
				errorProvider.SetError(validatingTextBox, "Please provide a description.");
				e.Cancel = true;
			}
			else {
				// Cancel any outstanding error provider
				errorProvider.SetError(validatingTextBox, null);
			}
		}

	}
}
