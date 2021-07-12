---
title: "Processing Pages"
page-title: "Processing Pages - Wizard Reference"
order: 9
---
# Processing Pages

On pages that perform intensive processing, you don't generally want the user to be able to press the **Next** and **Back** buttons while the processing is taking place.  The [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) control provides properties and events for handling these situations.

Each [WizardPage](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage) object has properties that let you set the default enabled state of the buttons when the page is selected.

These properties are:

- [BackButtonEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.BackButtonEnabled)

- [NextButtonEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.NextButtonEnabled)

- [FinishButtonEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.FinishButtonEnabled)

- [CancelButtonEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.CancelButtonEnabled)

- [HelpButtonEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.HelpButtonEnabled)

For a processing page, these should be set to `false`.

The next step is to create a handler for the [SelectionChanged](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.SelectionChanged) event.  This event is raised after the selected page changes and the new page is visible.

In this event, check to see if the currently selected page is the processing page.  If so, route to a processing function.  After the call to this function, re-enable the buttons.

The following code displays how to do this:

```csharp
private void wizard_SelectionChanged(object sender, System.EventArgs e) {
	if (wizard.SelectedPage == processingPage) {
		// Call processing function
		DoProcessing();

		// Re-enable the buttons now that the processing is complete
		wizard.BackButtonEnabled = true;
		wizard.NextButtonEnabled = true;
	}
}
```
