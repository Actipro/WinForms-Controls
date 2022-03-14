---
title: "Getting Started"
page-title: "Getting Started - Wizard Reference"
order: 3
---
# Getting Started

Creating a wizard is simple with the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control.  Follow these steps to get started.

## Option 1 - Creating a Form and Adding a Wizard

The first step in making a wizard is to create a `Form` for the wizard.  Set the appropriate properties of the `Form`, such as `FormBorderStyle` and `Text`.

Place a [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control on the `Form`.  Set its `Dock` property to `Fill`.

## Option 2 - Creating a Form that Inherits WizardDialogForm

Alternatively, create a form that inherits the [WizardDialogForm](xref:@ActiproUIRoot.Controls.Wizard.WizardDialogForm) class.  The [WizardDialogForm](xref:@ActiproUIRoot.Controls.Wizard.WizardDialogForm) already has a [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control built into it and exposes it as a property.  It also takes all of the important [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) events and provides methods that you can override to handle the events.

See the [Wizard Dialog Form](wizard-dialog-form.md) topic for more information on using a [WizardDialogForm](xref:@ActiproUIRoot.Controls.Wizard.WizardDialogForm).

## Configuring the Wizard Control

This list displays several of the most important properties to configure on the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control:

| Property | Description |
|-----|-----|
| [FinishButtonDistinct](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonDistinct) | Whether the **Finish** button should always appear or if it should appear in place of the **Next** button on finish pages. |
| [Font](xref:@ActiproUIRoot.Controls.Wizard.Wizard.Font) | The `Font` object used on all child controls of the wizard, except for the page caption and page description.  This can be used for localization. |
| [FormAcceptButton](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FormAcceptButton) | The button to use as the accept button for the wizard's container `Form`. |
| [FormCancelButton](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FormCancelButton) | The button to use as the cancel button for the wizard's container `Form`. |
| [HelpButtonAlignLeft](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonAlignLeft) | Whether the **Help** button is aligned to the left side of the wizard. |
| [InteriorPageGuideLineCount](xref:@ActiproUIRoot.Controls.Wizard.Wizard.InteriorPageGuideLineCount) | The number of guide lines to display in interior pages while in design-mode.  The guide lines help provide a consistent layout of wizard page child controls. |
| [PageSequenceType](xref:@ActiproUIRoot.Controls.Wizard.Wizard.PageSequenceType) | Sets the mode of page sequencing to use at run-time. `Normal` page sequencing simply iterates through the pages in the [Pages](xref:@ActiproUIRoot.Controls.Wizard.Wizard.Pages) collection in the order in which they appear. `BackStack` page sequencing acts like `Normal` when moving forward through the wizard.  However as page changes occur, the visited pages are stored on a stack.  When the **Back** button is pressed, the last page on the stack is popped off the stack and revisited.  This process continues until there are no pages left on the stack. |

## Configuring a Wizard Renderer for Global Wizard Appearance

Each [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control must be assigned a [WizardRenderer](xref:@ActiproUIRoot.Controls.Wizard.WizardRenderer) component to its [Renderer](xref:@ActiproUIRoot.Controls.Wizard.Wizard.Renderer) property.  The renderer draws all of the elements of the wizard.  The default renderer assigned to a wizard is an instance of the [WindowsClassicWizardRenderer](xref:@ActiproUIRoot.Controls.Wizard.WindowsClassicWizardRenderer) class.

It has numerous properties for layout, colors, as well as for the setting the default background fills to each distinct element in the wizard.  See the [Working with Background Fills](working-with-background-fills.md) topic for more information on working with background fills.  Essentially, all global appearance-related properties are found on the renderer.  Some global default properties can be overwritten by page-specific properties found on the [WizardPage](xref:@ActiproUIRoot.Controls.Wizard.WizardPage) class.

For complete customization, you can even create a class that inherits from [WizardRenderer](xref:@ActiproUIRoot.Controls.Wizard.WizardRenderer) and overrides its various `Draw` methods. An instance of the custom renderer can then be assigned to the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard).[Renderer](xref:@ActiproUIRoot.Controls.Wizard.Wizard.Renderer) property to replace the default renderer.

## Changing Button Text

Each of the buttons' text can be modified by setting the appropriate property (i.e. [NextButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonText) property) on the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control.  You may wish to do this to switch from the normal button names or maybe because you are programming for a non-English language.  In any event, [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) also provides width properties (i.e. [NextButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonWidth) property) for each button so that you can change the width of each button to accommodate the width of the custom text.

Both of these types of properties are localizable so that you can store different values for different languages.  See the [Localization](localization.md) topic for more information on localization of properties.

These properties of the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control relate to button text and width:

| Property | Description |
|-----|-----|
| [BackButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonText) | The text displayed on the **Back** button. This can be used for localization. |
| [BackButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonWidth) | The width of the **Back** button. This can be used for localization. |
| [CancelButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.CancelButtonText) | The text displayed on the **Cancel** button. This can be used for localization. |
| [CancelButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.CancelButtonWidth) | The width of the **Cancel** button. This can be used for localization. |
| [FinishButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonText) | The text displayed on the **Finish** button. This can be used for localization. |
| [FinishButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonWidth) | The width of the **Finish** button. This can be used for localization. |
| [HelpButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonText) | The text displayed on the **Help** button. This can be used for localization. |
| [HelpButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonWidth) | The width of the **Help** button. This can be used for localization. |
| [NextButtonText](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonText) | The text displayed on the **Next** button. This can be used for localization. |
| [NextButtonWidth](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonWidth) | The width of the **Next** button. This can be used for localization. |

## Configuring Button Appearance

By default, the buttons in the Wizard have a Windows Classic appearance.  If you would like your buttons to have a different appearance, Wizard exposes several properties on the [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control that are useful.

The [ButtonFlatStyle](xref:@ActiproUIRoot.Controls.Wizard.Wizard.ButtonFlatStyle) property sets the flat style of all buttons.  With this, you can set its value to `FlatStyle.System` to allow the buttons to use system theme styles.

If not using themes for the buttons, you can set the background color of each button.  The [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) control exposes two special button events, [ButtonMouseEnter](xref:@ActiproUIRoot.Controls.Wizard.Wizard.ButtonMouseEnter) and [ButtonMouseLeave](xref:@ActiproUIRoot.Controls.Wizard.Wizard.ButtonMouseLeave).  You can attach to those and update the background color of the affected button to provide "hot" styles.

| Property | Description |
|-----|-----|
| [BackButtonBackColor](xref:@ActiproUIRoot.Controls.Wizard.Wizard.BackButtonBackColor) | The background color of the **Back** button. |
| [ButtonFlatStyle](xref:@ActiproUIRoot.Controls.Wizard.Wizard.ButtonFlatStyle) | The flat style appearance of the buttons in the wizard. |
| [CancelButtonBackColor](xref:@ActiproUIRoot.Controls.Wizard.Wizard.CancelButtonBackColor) | The background color of the **Cancel** button. |
| [FinishButtonBackColor](xref:@ActiproUIRoot.Controls.Wizard.Wizard.FinishButtonBackColor) | The background color of the **Finish** button. |
| [HelpButtonBackColor](xref:@ActiproUIRoot.Controls.Wizard.Wizard.HelpButtonBackColor) | The background color of the **Help** button. |
| [NextButtonBackColor](xref:@ActiproUIRoot.Controls.Wizard.Wizard.NextButtonBackColor) | The background color of the **Next** button. |

## Adding Wizard Pages

After all of the above tasks have been completed, start adding wizard pages to your wizard.  Use the design-time functionality of [Wizard](xref:@ActiproUIRoot.Controls.Wizard.Wizard) to add new pages.  See the [Design-Time Functionality](design-time-functionality.md) topic for more information on how to add pages and navigate between them.
