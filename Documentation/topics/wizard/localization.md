---
title: "Localization"
page-title: "Localization - Wizard Reference"
order: 10
---
# Localization

The wizard contains all the support necessary to create multi-cultural, localized user interfaces.

## Preparing the Parent Form for Localization

To enable localization, you must set two properties on the `Form` object that contains the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control.

- The `Localizable` property should be set to `true`.

- The `Language` property should be set to the current language to be localized.  The default language will be used for all languages which do not have specific settings.

Once those two properties have been set, you can change various properties on the wizard and they will be set specific to current language context defined by the `Language` property.

## Localizable Wizard Properties

The following properties on the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control are localizable:

- [BackButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonText)

- [BackButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonWidth)

- [CancelButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.CancelButtonText)

- [CancelButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.CancelButtonWidth)

- [FinishButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonText)

- [FinishButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonWidth)

- [Font](xref:@ActiproUIRoot.Controls.Wizard.Wizard.Font)

- [HelpButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonText)

- [HelpButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonWidth)

- [NextButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonText)

- [NextButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonWidth)

The properties above enable you to set different fonts and text for each language.  Sometimes various text is drastically different size.  By setting the widths of the buttons for each language, you have total control over the size of the buttons.  The wizard automatically takes care of positioning the buttons appropriately.

## Localizable WizardPage Properties

The following properties on the [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) control are localizable:

- [PageCaption](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.PageCaption)

- [PageDescription](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.PageDescription)

- [PageTitleBarText](xref:@ActiproUIRoot.Controls.Wizard.WizardPage.PageTitleBarText)

## Localizable WizardDialogForm Properties

The following properties on the [WizardDialogForm](xref:@ActiproUIRoot.Controls.Wizard.WizardDialogForm) control are localizable:

- [TitleBarText](xref:@ActiproUIRoot.Controls.Wizard.WizardDialogForm.TitleBarText)

## Localizable WindowsClassicWizardRenderer Properties

The following properties on the [WindowsClassicWizardRenderer](xref:@ActiproUIRoot.Controls.Wizard.WindowsClassicWizardRenderer) class are localizable:

- [WizardPageCaptionFont](xref:@ActiproUIRoot.Controls.Wizard.WindowsClassicWizardRenderer.WizardPageCaptionFont)

- [WizardPageDescriptionFont](xref:@ActiproUIRoot.Controls.Wizard.WindowsClassicWizardRenderer.WizardPageDescriptionFont)
