---
title: "Overview"
page-title: "Bars Commands and Command Links Reference"
order: 1
---
# Overview

The most important concept to understand with the bar controls is the concept of commands and command links.  Since the bar controls are fairly advanced, understanding this concept is key before using them.  Be sure to thoroughly read this topic before moving onto using the bar controls.

A command is any object that inherits from [BarCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand).  Commands represent a specific functionality of your application, such as creating a new document.  A command *does not* have a user interface.  Changes made to a command affect all the command links that reference it.

A command link is any object that inherits from [BarCommandLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink).  A command link provides the user interface for a command.  So, each command link references a specific command.  One or more command links can be created for each command.  Changes made to command link properties only affect that particular command link instance.

## Command Categories and Names

Each command has a unique key, known in the bar controls as a "full name".  The full name can be returned via the [FullName](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.FullName) property on [BarCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand).

The full name is a concatenation of a category and a command name, with a period ( `.`) in between.  This allows commands to easily be categorized and also for some names to be used more than once, in different categories.

For instance, typical commands on a `File` menu are `New`, `Open`, etc.  In Bars, the full name of these commands would be `File.New` and `File.Open`, where the category of the command is `File` and the names of the commands are `New` and `Open` respectively.

The full name is the primary method of accessing and identifying commands.

## Command / Command Link Types

There are a number of built-in command and command link types that each provide distinct functionality.  Each command has a corresponding command link type.

This table illustrates each command and command link `Type`:

<table>
<thead>

<tr>
<th>Command Name (Command Link Name)</th>
<th>Description</th>
</tr>


</thead>
<tbody>

<tr>
<td>

[BarButtonCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarButtonCommand) ([BarButtonLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarButtonLink))

</td>
<td>

Represents a standard button (on a toolbar) or menu item (on a menu), that can be pushed.  It also supports a checked state.

![Screenshot](../images/bar-button-on-toolbar.gif)

![Screenshot](../images/bar-button-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarPopupButtonCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarPopupButtonCommand) ([BarPopupButtonLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarPopupButtonLink))

</td>
<td>

Represents a root menu item button (on a toolbar) or menu item (on a menu).  The link has a collection of child command links that generate a child menu when the link is pressed.

![Screenshot](../images/bar-popupbutton-on-toolbar.gif)

![Screenshot](../images/bar-popupbutton-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarSplitButtonCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarSplitButtonCommand) ([BarSplitButtonLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarSplitButtonLink))

</td>
<td>

Represents a split button where one part acts like a normal button and the other part has a drop-down arrow and displays a menu when pressed.  The button supports a checked state.  The link has a collection of child command links that generate the menu when the link is pressed.

![Screenshot](../images/bar-splitbutton-on-toolbar.gif)

![Screenshot](../images/bar-splitbutton-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarExpanderButtonCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarExpanderButtonCommand) ([BarExpanderButtonLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarExpanderButtonLink))

</td>
<td>

Represents a button that has dynamically-generated child command links.  These can be a list of toolbars, windows open, or anything else.  When on a toolbar, the command link functionality is similar to a [BarPopupButtonLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarPopupButtonLink).  When on a menu, the command link is replaced by the child command links.

![Screenshot](../images/bar-expander-button-on-toolbar.gif)

![Screenshot](../images/bar-expander-button-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarLabelCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarLabelCommand) ([BarLabelLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarLabelLink))

</td>
<td>

Represents a static label that can display text and images.

![Screenshot](../images/bar-label-on-toolbar.gif)

![Screenshot](../images/bar-label-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarTextBoxCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarTextBoxCommand) ([BarTextBoxLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarTextBoxLink))

</td>
<td>

Represents a textbox that accepts text input.

![Screenshot](../images/bar-textbox-on-toolbar.gif)

![Screenshot](../images/bar-textbox-on-menu.gif)

</td>
</tr>

<tr>
<td>

[BarComboBoxCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxCommand) ([BarComboBoxLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarComboBoxLink))

</td>
<td>

Represents a combobox that can display a drop-down list of pre-defined values.  The combobox text area can be editable or read-only.

![Screenshot](../images/bar-combobox-on-toolbar.gif)

![Screenshot](../images/bar-combobox-on-menu.gif)

</td>
</tr>

</tbody>
</table>

## Creating Command Links

The easiest way to create a command link for a command is to call the [CreateCommandLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.CreateCommandLink*) method on the command.  A command link is returned that references the command and can be programmatically added to any bar control.

## Cloning Command Links

Command links can be cloned by using the [Clone](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.Clone*) method.

## Preventing Menus from Closing When a Link Is clicked

When used on a menu, command links normally close the menu when they are clicked.  However in some cases it is useful to keep the menu open so that the link may be immediately clicked again.  For these scenarios, you can set the [StaysOpenOnClick](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommand.StaysOpenOnClick) property to `true` to keep a menu open when a link for the command is clicked.
