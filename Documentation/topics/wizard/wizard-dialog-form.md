---
title: "Wizard Dialog Form"
page-title: "Wizard Dialog Form - Wizard Reference"
order: 4
---
# Wizard Dialog Form

The [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) is a `Form` object that provides an abstract implementation of a [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) on a `Form`.  To use it, simply create a `Form` that inherits from it.  Several properties and methods have been added in the [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) implementation.

## Controlling the Form Title Bar Text

Title bar text for the [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) can be set automatically by the control.  The [TitleStyle](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.TitleStyle) property specifies the method for building the title bar text string.  The various styles generally use the [TitleBarText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.TitleBarText) property as a base for the title bar text with other text appended to it in one form or another.

> [!IMPORTANT]
> It is not recommended that the [Text](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.Text) property be set directly since the [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) manages that property and may override any value assigned.

If additional title bar text styles need to be implemented, the [OnUpdateTitleBarText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnUpdateTitleBarText*) method can be overridden to provide this extra functionality.

## Wizard Event Handlers

Many of the [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) events have been attached to various methods in the [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) control.  You can override these methods to handle the wizard events instead of handling the [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) events in event handlers:

| Method | Description |
|-----|-----|
| [OnBackButtonClick](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnBackButtonClick*) | Occurs when the **Back** button on the wizard is clicked. |
| [OnCancelButtonClick](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnCancelButtonClick*) | Occurs when the **Cancel** button on the wizard is clicked. |
| [OnFinishButtonClick](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnFinishButtonClick*) | Occurs when the **Finish** button on the wizard is clicked. |
| [OnHelpButtonClick](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnHelpButtonClick*) | Occurs when the **Help** button on the wizard is clicked. |
| [OnLayoutButtons](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnLayoutButtons*) | Occurs when control is requested to lay out its child controls. |
| [OnNextButtonClick](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnNextButtonClick*) | Occurs when the **Next** button on the wizard is clicked. |
| [OnSelectionChanged](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnSelectionChanged*) | Occurs after a page is selected. |
| [OnSelectionChanging](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.OnSelectionChanging*) | Occurs before a page is selected. |
