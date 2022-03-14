---
title: "Programmatically Controlling Page Sequence"
page-title: "Programmatically Controlling Page Sequence - Wizard Reference"
order: 7
---
# Programmatically Controlling Page Sequence

In many cases, you will want to customize the order in which pages display.  The [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control provides events for doing this.

There are two methods for manually controlling page sequence:

- Page sequencing may be controlled in the wizard-level [NextButtonClick](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonClick) and [BackButtonClick](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonClick) events of the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control.

- Page sequencing may also be controlled in the page-level [NextButtonClick](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.NextButtonClick) and [BackButtonClick](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.BackButtonClick) events of [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) controls.

> [!IMPORTANT]
> When one of the above events is implemented for a [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) control, the associated event in the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control will not be raised if the [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) is currently selected.

## Example Scenario

As an example, say you have a three-page wizard and there is a checkbox on the first page.  If the checkbox is checked, you are on the first page, and you press the **Next** button, you want the wizard to skip the middle page and go directly to the last page.  Likewise, if the checkbox is checked, you are on the last page, and you press the **Back** button, you want to skip the middle page and go back to the first page.  If the checkbox is left unchecked, navigation using the buttons will move through all three pages.

## Controlling Page Sequence with the Wizard

To do this, you create event handlers for both the [NextButtonClick](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonClick) and [BackButtonClick](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonClick) events in the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control.

In the `NextButtonClick` event handler, you implement this code:

```csharp
private void wizard_NextButtonClick(object sender, WizardPageCancelEventArgs e) {
	if ((wizard.SelectedIndex == 0) && (checkBox.Checked)) {
		e.Cancel = true;
		wizard.SelectedIndex = 2;
	}
}
```

In the `BackButtonClick` event handler, you implement this code:

```csharp
private void wizard_BackButtonClick(object sender, WizardPageCancelEventArgs e) {
	if ((wizard.SelectedIndex == 2) && (checkBox.Checked)) {
		e.Cancel = true;
		wizard.SelectedIndex = 0;
	}
}
```

With those two events in place on the wizard, the default navigation of pages is cancelled when the checkbox is checked, and the page selection is then manually updated to skip the middle page.

## Controlling Page Sequence with a WizardPage

However you also could have implemented the [NextButtonClick](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.NextButtonClick) and [BackButtonClick](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.BackButtonClick) events for the [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) control.

In the `NextButtonClick` event handler, you implement this code:

```csharp
private void firstWizardPage_NextButtonClick(object sender, WizardPageCancelEventArgs e) {
	if (checkBox.Checked) {
		e.Cancel = true;
		wizard.SelectedIndex = 2;
	}
}
```

In the `BackButtonClick` event handler, you implement this code:

```csharp
private void lastWizardPage_BackButtonClick(object sender, WizardPageCancelEventArgs e) {
	if (checkBox.Checked) {
		e.Cancel = true;
		wizard.SelectedIndex = 0;
	}
}
```

With those two events in place on the wizard, the default navigation of pages is cancelled when the checkbox is checked, and the page selection is then manually updated to skip the middle page.
