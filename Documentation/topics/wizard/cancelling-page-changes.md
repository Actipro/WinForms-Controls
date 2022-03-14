---
title: "Cancelling Page Changes"
page-title: "Cancelling Page Changes - Wizard Reference"
order: 8
---
# Cancelling Page Changes

[Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) allows you to programmatically cancel page changes.  This is useful when making a page that requires validation before another page can be selected.  Use the [SelectionChanging](xref:@ActiproUIRoot.Controls.Wizard.Wizard.SelectionChanging) event to ensure that proper data is entered on a page before navigating away from it. If it isn't, you can display a message to the user and can tell the wizard that page switching should not occur.

This is an example `SelectionChanging` event handler that implements page validation:

```csharp
private void wizard_SelectionChanging(object sender, WizardPageCancelEventArgs e) {
	// Check to see if the page is valid			
	if (!this.CheckPageIsValid()) {
		e.Cancel = true;
		MessageBox.Show("The page is not valid.");
	}
}
```
