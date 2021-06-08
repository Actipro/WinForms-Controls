---
title: "Localization"
page-title: "Localization - Wizard Reference"
order: 10
---
# Localization

The wizard contains all the support necessary to create multi-cultural, localized user interfaces.

## Preparing the Parent Form for Localization

To enable localization, you must set two properties on the `Form` object that contains the [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) control.

- The `Localizable` property should be set to `true`.

- The `Language` property should be set to the current language to be localized.  The default language will be used for all languages which do not have specific settings.

Once those two properties have been set, you can change various properties on the wizard and they will be set specific to current language context defined by the `Language` property.

## Localizable Wizard Properties

The following properties on the [Wizard](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard) control are localizable:

- [BackButtonText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.BackButtonText)

- [BackButtonWidth](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.BackButtonWidth)

- [CancelButtonText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.CancelButtonText)

- [CancelButtonWidth](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.CancelButtonWidth)

- [FinishButtonText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.FinishButtonText)

- [FinishButtonWidth](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.FinishButtonWidth)

- [Font](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.Font)

- [HelpButtonText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.HelpButtonText)

- [HelpButtonWidth](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.HelpButtonWidth)

- [NextButtonText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.NextButtonText)

- [NextButtonWidth](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.Wizard.NextButtonWidth)

The properties above enable you to set different fonts and text for each language.  Sometimes various text is drastically different size.  By setting the widths of the buttons for each language, you have total control over the size of the buttons.  The wizard automatically takes care of positioning the buttons appropriately.

## Localizable WizardPage Properties

The following properties on the [WizardPage](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage) control are localizable:

- [PageCaption](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.PageCaption)

- [PageDescription](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.PageDescription)

- [PageTitleBarText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardPage.PageTitleBarText)

## Localizable WizardDialogForm Properties

The following properties on the [WizardDialogForm](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm) control are localizable:

- [TitleBarText](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WizardDialogForm.TitleBarText)

## Localizable WindowsClassicWizardRenderer Properties

The following properties on the [WindowsClassicWizardRenderer](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WindowsClassicWizardRenderer) class are localizable:

- [WizardPageCaptionFont](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WindowsClassicWizardRenderer.WizardPageCaptionFont)

- [WizardPageDescriptionFont](xref:ActiproSoftware.UI.WinForms.Controls.Wizard.WindowsClassicWizardRenderer.WizardPageDescriptionFont)
