using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.Wizard;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Threading;

namespace ActiproSoftware.ProductSamples.WizardSamples.Demo.Features;

/// <summary>
/// Summary description for MainForm.
/// </summary>
public partial class MainForm : WizardDialogForm {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

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
		ActiveControl = Wizard;
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the selected index is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnCustomAppearanceListBoxSelectedIndexChanged(object sender, EventArgs e) {
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
			case 2:   // Blue
				customAppearancesPage.InteriorPageHeaderBackgroundFill = new TwoColorLinearGradient(Color.White, Color.LightSteelBlue, 0, TwoColorLinearGradientStyle.Normal);
				customAppearancesPage.BackgroundFill = new TwoColorLinearGradient(Color.White, Color.LightSteelBlue, 90, TwoColorLinearGradientStyle.Normal);
				customAppearancesPage.ButtonContainerBackgroundFill = new TwoColorLinearGradient(Color.LightSteelBlue, Color.SteelBlue, 90, TwoColorLinearGradientStyle.Normal);
				break;
			case 3:  // Rainbow
				customAppearancesPage.InteriorPageHeaderBackgroundFill = new TwoColorLinearGradient(Color.White, Color.Silver, 90, TwoColorLinearGradientStyle.Normal);
				var gradient = new MultiColorLinearGradient {
					Angle = 75,
					StartColor = Color.Red,
					IntermediateColors = [
						new LinearGradientColorPosition(Color.Yellow, 0.3f),
							new LinearGradientColorPosition(Color.Green, 0.5f),
							new LinearGradientColorPosition(Color.Blue, 0.7f),
						],
					EndColor = Color.Violet
				};
				customAppearancesPage.BackgroundFill = gradient;
				customAppearancesPage.ButtonContainerBackgroundFill = null;
				break;
		}
	}

	/// <summary>
	/// Occurs when the Wizard's Next button is clicked and the data collection page is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	/// <remarks>
	/// Since this event handler was defined, the NextButtonClick event for the Wizard control will
	/// not fire when the Next button is clicked on the data collection page only.
	/// <para>
	/// Note how this event handler cancels the default page sequencing and decides 
	/// to go to one page or the other based on the setting of the radio buttons.
	/// </para>
	/// </remarks>
	private void OnDataCollectionPageNextButtonClick(object sender, WizardPageCancelEventArgs e) {
		e.Cancel = true;
		if (executionPath1.Checked)
			Wizard.SelectedPage = processingPage;
		else
			Wizard.SelectedPage = customAppearancesPage;
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnGoToSecondExecutionPathButtonClick(object sender, EventArgs e) {
		Wizard.SelectedPage = customAppearancesPage;
	}

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnInfoWebSiteLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		=> Program.LaunchExternalBrowser(((LinkLabel)sender).Text);


	/// <summary>
	/// Occurs when the page is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnStartPageResize(object sender, EventArgs e) {
		// Resize the content panel of the start page to match the available space
		startPageTableLayoutPanel.Bounds = new Rectangle(
			startPage.ClientRectangle.Left + startPage.ScaleLogicalValue(startPage.WatermarkWidth),
			startPage.ClientRectangle.Top,
			startPage.ClientRectangle.Width - startPage.ScaleLogicalValue(startPage.WatermarkWidth),
			startPage.ClientRectangle.Height
		);
	}

	/// <summary>
	/// Occurs when the textbox is validating.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnValidatingTextBoxValidating(object sender, System.ComponentModel.CancelEventArgs e) {
		if ((Wizard.SelectedPage == dataCollectionPage) && (validatingTextBox.Text.Length == 0)) {
			// User has not entered a description, prompt with error provider
			errorProvider.SetError(validatingTextBox, "Please provide a description.");
			e.Cancel = true;
		}
		else {
			// Cancel any outstanding error provider
			errorProvider.SetError(validatingTextBox, null);
		}
	}

	/// <summary>
	/// Occurs when the page is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowsXPPageResize(object sender, EventArgs e) {
		// Adjust the size of message label to fill the space allocated by the background
		windowsXPMessageLabel.Width = windowsXPPage.Width;
		windowsXPMessageLabel.Height = windowsXPPage.ScaleLogicalValue(WindowsXPBackgroundFill.BottomLabelHeight);
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	public override void DpiScaleChanged(SizeF scaleFactor) {
		var deviceDpiOld = DpiHelper.ScaleFactorToDeviceDpi(DpiScaleFactor);
		var deviceDpiNew = DpiHelper.ScaleFactorToDeviceDpi(scaleFactor);

		base.DpiScaleChanged(scaleFactor);

		if (!Program.IsControlFontScalingHandledByRuntime) {
			// Manually scale control fonts
			var manualFontControls = new Control[] {
					welcomeLabel,
					finishPage1FinishPageLabel,
					finishPage1Number1Label,
					finishPage2FinishPageLabel,
					finishPage2Number2Label,
					windowsXPMessageLabel,
					windowsXPActiproLabel,
					windowsXPWizardLabel
				};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}

		// Rescale controls that don't automatically scale with DPI changes
		#if !NET6_0_OR_GREATER
		progressBar.Size = DpiHelper.RescaleSize(progressBar.Size, deviceDpiOld, deviceDpiNew);
		#endif
	}

	/// <summary>
	/// Occurs when Back button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
	/// </summary>
	/// <param name="e">The event data.</param>
	/// <remarks>
	/// Note how it cancels the default page sequencing and decides to go to the data entry page
	/// if using normal page sequencing and if the custom appearances page is selected.  
	/// This programmatically skips over the other sequence of pages
	/// that are in between the data entry page and the custom appearances page.
	/// </remarks>
	protected override void OnBackButtonClick(WizardPageCancelEventArgs e) {
		if (Wizard.PageSequenceType == WizardPageSequenceType.Normal) {
			if (Wizard.SelectedPage == customAppearancesPage) {
				e.Cancel = true;
				Wizard.SelectedPage = dataCollectionPage;
			}
		}
	}

	/// <summary>
	/// Occurs when Cancel button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnCancelButtonClick(EventArgs e) {
		// Close the form
		Close();
	}

	/// <summary>
	/// Occurs when Finish button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
	/// </summary>
	/// <param name="e">The event data.</param>
	/// <remarks>
	/// This is where you would perform the finishing tasks of the Wizard.
	/// </remarks>
	protected override void OnFinishButtonClick(EventArgs e) {
		// Display a message
		MessageBox.Show("The wizard is finished.", "Wizard");

		// Close the form
		Close();
	}

	/// <summary>
	/// Occurs when Help button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
	/// </summary>
	/// <param name="e">The event data.</param>
	/// <remarks>
	/// Display help for the current wizard step when this button is pressed.
	/// </remarks>
	protected override void OnHelpButtonClick(EventArgs e)
		=> Program.LaunchExternalBrowser("https://www.actiprosoftware.com");

	/// <summary>
	/// Occurs when control is requested to lay out it's child controls.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnLayoutButtons(WizardLayoutButtonsEventArgs e) {
		// No operation
	}

	/// <summary>
	/// Occurs when Next button on the <see cref="WizardDialogForm.Wizard"/> is clicked.
	/// </summary>
	/// <param name="e">The event data.</param>
	/// <remarks>
	/// This event is raised if there is not an event handler for the currently selected page's associated
	/// event.  For instance, since a NextButtonClick event handler is defined for the data collection page
	/// in this sample application, this event will not fire when the data collection page is selected and
	/// the Next button is clicked.
	/// </remarks>
	protected override void OnNextButtonClick(WizardPageCancelEventArgs e) {
		// You can override default page sequencing here by setting e.Cancel = true
		//   and setting Wizard.SelectedIndex to a valid page index
	}

	/// <summary>
	/// Occurs after a page is selected.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnSelectionChanged(EventArgs e) {
		if (Wizard.SelectedPage is { } selectedPage)
			Console.WriteLine("{0}: {1} (Page #{2})", nameof(Wizard.SelectionChanged), selectedPage.PageCaption, Wizard.SelectedIndex + 1);

		// When the processing page is being selected it is set up in the designer to disable all
		//   wizard buttons while processing is occurring... 

		// Do some processing here and then re-enable the appropriate buttons using code
		if (Wizard.SelectedPage == processingPage) {
			// Clear the processing amount
			progressBar.Value = 0;
			processingLabel.Text = "Ready to start...";

			// Make the thread sleep for a second to simulate some simple processing
			for (var i = 10; i <= 100; i += 10) {
				Thread.Sleep(100);
				progressBar.Value = i;
				processingLabel.Text = $"Processing amount: {progressBar.Value}%";
				Application.DoEvents();
			}

			// Re-enable the buttons now that the processing is complete
			processingLabel.Text = "Processing complete!";
			Wizard.BackButtonEnabled = true;
			Wizard.NextButtonEnabled = true;
		}
	}

	/// <summary>
	/// Occurs before a page is selected.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnSelectionChanging(WizardPageCancelEventArgs e) {
		if (cancelPageChangeCheckBox.Checked) {
			// You can perform validation and cancel page switching here by setting e.Cancel = true.
			e.Cancel = true;
			Console.WriteLine($"{nameof(Wizard.SelectionChanging)}: Programmatically cancelled page change.");
			return;
		}

		if (Wizard.SelectedIndex != -1) {
			if (e.Page is null) {
				Console.WriteLine("{0}: {1} (Page #{2})", nameof(Wizard.SelectionChanging), Wizard.SelectedPage?.PageCaption, Wizard.SelectedIndex + 1);
			}
			else {
				Console.WriteLine("{0}: {1} (Page #{2}) --> {3} (Page #{4})",
					nameof(Wizard.SelectionChanging),
					Wizard.SelectedPage?.PageCaption,
					Wizard.SelectedIndex + 1,
					e.Page.PageCaption,
					Wizard.Pages.IndexOf(e.Page) + 1
				);
			}
		}
	}

}
