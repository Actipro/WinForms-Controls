---
title: "Popup Buttons"
page-title: "Popup Buttons - Bars Commands and Command Links Reference"
order: 3
---
# Popup Buttons

Popup buttons are represented using the [BarPopupButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand) and a [BarPopupButtonLink](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink) classes.  The [BarPopupButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand) class is the base command for the [BarPopupButtonLink](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink), which is the command link.

See the [Commands and Command Links](index.md) topic for more information on commands and command links and how they relate to each other.

![Screenshot](../images/bar-popupbutton-on-toolbar.gif)

![Screenshot](../images/bar-popupbutton-on-menu.gif)

Popup buttons appear like a button when on a toolbar and appear like a popup menu item when on a menu.  The popup button can be clicked to display a menu.

## Child Command Links and Menus

Clicking a popup button displays a menu containing the command links found in the [CommandLinks](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink.CommandLinks) collection on the command link instance.  The menu uses a resolved setting from the command link's [UseToolBarStyleForPopupMenu](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink.UseToolBarStyleForPopupMenu) property and the command's [UseToolBarStyleForPopupMenu](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand.UseToolBarStyleForPopupMenu) property to determine whether the menu should display in a toolbar style or not.

Whenever a [BarPopupButtonLink](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink) is created from a [BarPopupButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand), the command's [DefaultCommandLinks](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand.DefaultCommandLinks) property is used to auto-fill the command link's [CommandLinks](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonLink.CommandLinks) collection.  Further code-based customization can also occur by handling the [CustomizeCommandLinkCreated](xref:@ActiproUIRoot.Controls.Bars.BarManager.CustomizeCommandLinkCreated) event.

## Tear-Off Menus

The popup menu displayed by the popup button can optionally have a gripper placed on it, allowing it to be torn off into a floating toolbar by the end user.  To allow this feature, set the command's [CanTearOff](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand.CanTearOff) property to `true`.  Since popup buttons don't have a toolbar key associated with them and a toolbar is created when tearing off a menu, the toolbar needs to know what key to use for displaying in customize dialogs, etc.  This toolbar key is set using the command's [TearOffDockableToolBarKey](xref:@ActiproUIRoot.Controls.Bars.BarPopupButtonCommand.TearOffDockableToolBarKey) property.

When a tear-off occurs, the [MenuTearOff](xref:@ActiproUIRoot.Controls.Bars.BarManager.MenuTearOff) event on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) is raised.

## Text and Images

Each command has a text and image value.  The text value comes from the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property.  The image first looks at the [Image](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Image) property.  If not specified, it looks to the [ImageIndex](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ImageIndex) property.

Each command link instance can override all of these properties as well with command link-specific property values.  The command link versions of the properties are examined first when resolving the text and image values.

## Enabling / Disabling

Command links can be enabled or disabled based on a resolved value of enabled properties, one on the command and one on the command link that can override it.  The command link's [Enabled](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.Enabled) property accepts a `DefaultableBoolean`, which can override the command's [Enabled](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Enabled) property.

## Begin a Group

The [BeginAGroup](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.BeginAGroup) property on each command link indicates whether the command link begins a group.  If it does, a separator will be drawn before it.

## Display Styles

The [DisplayStyle](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.DisplayStyle) property on each command link accepts a [BarCommandLinkDisplayStyle](xref:@ActiproUIRoot.Controls.Bars.BarCommandLinkDisplayStyle) enumeration value that indicates how to render the command link in terms of image and text display.

## Visibility

The [Visible](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink.Visible) property on each command link controls whether the command link is visible or invisible within its parent bar control.

## Tooltips

Tooltips will be displayed for the command if the [ToolTipEnabled](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipEnabled) property is set to `true`.  The tooltip will display the value of the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property unless the [ToolTipText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipText) property overrides it with a different value.  The [ToolTipText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.ToolTipText) property can be left as `null` to indicate to use the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property instead.

## Changing the Text Displayed in the Run-Time Customize Dialog for the Command

By default, the [Text](xref:@ActiproUIRoot.Controls.Bars.BarCommand.Text) property value of the command will be displayed in the run-time customize dialog's command listbox.  However, if this is not appropriate or needs to be customized for the command listbox, the [CustomizeListText](xref:@ActiproUIRoot.Controls.Bars.BarCommand.CustomizeListText) property can be set to override what is displayed.
