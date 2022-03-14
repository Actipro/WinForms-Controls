---
title: "Buttons"
page-title: "Buttons - Bars Commands and Command Links Reference"
order: 2
---
# Buttons

Regular buttons are represented using the [BarButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarButtonCommand) and a [BarButtonLink](xref:@ActiproUIRoot.Controls.Bars.BarButtonLink) classes.  The [BarButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarButtonCommand) class is the base command for the [BarButtonLink](xref:@ActiproUIRoot.Controls.Bars.BarButtonLink), which is the command link.

See the [Commands and Command Links](index.md) topic for more information on commands and command links and how they relate to each other.

![Screenshot](../images/bar-button-on-toolbar.gif)

![Screenshot](../images/bar-button-on-menu.gif)

Regular buttons appear like a button when on a toolbar and appear like a normal menu item when on a menu.  They can be clicked and an action can be taken in response to the click.

## Checkable Buttons

Buttons can optionally become checkable and can be used in check groups.  These options are set up on the command.  See the [Checkable Buttons](../checkable-buttons.md) topic for detailed information on working with checkable buttons.

## Text and Images

Each command has a text and image value.  The text value comes from the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property.  The image first looks at the [Image](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Image) property.  If not specified, it looks to the [ImageIndex](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ImageIndex) property.

Each command link instance can override all of these properties as well with command link-specific property values.  The command link versions of the properties are examined first when resolving the text and image values.

## Enabling / Disabling

Command links can be enabled or disabled based on a resolved value of enabled properties, one on the command and one on the command link that can override it.  The command link's [Enabled](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.Enabled) accepts a `DefaultableBoolean`, which can override the command's [Enabled](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Enabled) property.

## Keyboard Shortcuts

Keyboard shortcuts can be set to the command by adding the appropriate [BarKeyboardShortcut](xref:@ActiproUIRoot.Controls.Bars.BarKeyboardShortcut) instances to the [KeyboardShortcuts](xref:@ActiproUIRoot.Controls.Bars.BarCommand.KeyboardShortcuts) collection on the command.

See the [Keyboard Shortcuts](../keyboard-shortcuts.md) topic for more information on keyboard shortcuts.

## Begin a Group

The [BeginAGroup](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.BeginAGroup) property on each command link indicates whether the command link begins a group.  If it does, a separator will be drawn before it.

## Display Styles

The [DisplayStyle](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.DisplayStyle) property on each command link accepts a [BarCommandLinkDisplayStyle](xref:@ActiproUIRoot.Controls.Bars.BarCommandLinkDisplayStyle) enumeration value that indicates how to render the command link in terms of image and text display.

## Visibility

The [Visible](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.Visible) property on each command link controls whether the command link is visible or invisible within its parent bar control.

## Tooltips

Tooltips will be displayed for the command if the [ToolTipEnabled](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipEnabled) property is set to `true`.  The tooltip will display the value of the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property unless the [ToolTipText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipText) property overrides it with a different value.  The [ToolTipText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipText) property can be left as `null` to indicate to use the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property instead.

## Changing the Text Displayed in the Run-Time Customize Dialog for the Command

By default, the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property value of the command will be displayed in the run-time customize dialog's command listbox.  However if this is not appropriate or needs to be customized for the command listbox, the [CustomizeListText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.CustomizeListText) property can be set to override what is displayed.
