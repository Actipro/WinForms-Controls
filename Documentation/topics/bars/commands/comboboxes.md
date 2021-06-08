---
title: "Comboboxes"
page-title: "Comboboxes - Bars Commands and Command Links Reference"
order: 8
---
# Comboboxes

Comboboxes are represented using the [BarComboBoxCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand) and a [BarComboBoxLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxLink) classes.  The [BarComboBoxCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand) class is the base command for the [BarComboBoxLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxLink), which is the command link.

See the [Commands and Command Links](index.md) topic for more information on commands and command links and how they relate to each other.

![Screenshot](../images/bar-combobox-on-toolbar.gif)

![Screenshot](../images/bar-combobox-on-menu.gif)

Comboboxes have two modes of input, normal and drop-down list.  The style is specified by the [Style](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand.Style) property on the command and takes an enumeration value of type [BarComboBoxCommandStyle](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommandStyle).

When using the normal style, a drop-down of items can be displayed and typing can occur in the combobox.  The selecting of a drop-down item, pressing of `Enter` or the changing of a value and tabbing off the combobox will raise the command click event.

When using the drop-down list style, a drop-down of items can be displayed and but the text in the combobox is read-only.  The selecting of a drop-down item will raise the command click event.

## Obtaining the Combobox Value

The combobox value can be retrieved from the command's [ControlValue](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCustomControlCommand.ControlValue) property.  This value will be displayed in all command link instances of the command.

## Setting the Width and Drop-Down Width

The width of the combobox can be set using the command's [Width](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCustomControlCommand.Width) property.  The width of the combobox's drop-down can be set using the command's [DropDownWidth](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand.DropDownWidth) property.

## Adding Items to the Combobox Drop-Down

Items can be added to all command link instances of the combobox by adding them to the [Items](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand.Items) collection.

## Setting the Selected Index

The selected index of the combobox can be set using the command's [SelectedIndex](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand.SelectedIndex) property.  The value must be set to a valid index in the command's [Items](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand.Items) collection.

## Enabling / Disabling

Command links can be enabled or disabled based on a resolved value of enabled properties, one on the command and one on the command link that can override it.  The command link's [Enabled](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.Enabled) accepts a `DefaultableBoolean`, which can override the command's [Enabled](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.Enabled) property.

## Keyboard Shortcuts

Keyboard shortcuts can be set to the command by adding the appropriate [BarKeyboardShortcut](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarKeyboardShortcut) instances to the [KeyboardShortcuts](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.KeyboardShortcuts) collection on the command.

See the [Keyboard Shortcuts](../keyboard-shortcuts.md) topic for more information on keyboard shortcuts.

## Begin a Group

The [BeginAGroup](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.BeginAGroup) property on each command link indicates whether the command link begins a group.  If it does, a separator will be drawn before it.

## Visibility

The [Visible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.Visible) property on each command link controls whether the command link is visible or invisible within its parent bar control.

## Tooltips

Tooltips will be displayed for the command if the [ToolTipEnabled](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.ToolTipEnabled) property is set to `true`.  The tooltip will display the value of the [Text](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.Text) property unless the [ToolTipText](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.ToolTipText) property overrides it with a different value.  The [ToolTipText](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.ToolTipText) property can be left as `null` to indicate to use the [Text](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.Text) property instead.

## Changing the Text Displayed in the Run-Time Customize Dialog for the Command

By default, the [Text](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.Text) property value of the command will be displayed in the run-time customize dialog's command listbox.  However if this is not appropriate or needs to be customized for the command listbox, the [CustomizeListText](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.CustomizeListText) property can be set to override what is displayed.
