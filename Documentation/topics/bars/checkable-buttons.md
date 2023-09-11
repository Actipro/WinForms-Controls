---
title: "Checkable Buttons"
page-title: "Checkable Buttons - Bars Reference"
order: 8
---
# Checkable Buttons

Bars controls support several features to make it easy to work with checkable buttons.

## IBarCheckableCommand Interface

The [IBarCheckableCommand](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand) interface is used to define a checkable button.  Both the [BarButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarButtonCommand) and [BarSplitButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarSplitButtonCommand) implement it and support checkable button features.

This table indicates the members of the [IBarCheckableCommand](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand) interface:

| Member | Description |
|-----|-----|
| [Checkable](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checkable) Property | Gets or sets whether the button is checkable. |
| [Checked](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checked) Property | Gets or sets whether the button is checked. |
| [CheckGroupName](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.CheckGroupName) Property | Gets or sets the name of the check group. |
| [FullName](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.FullName) Property | Gets the full name of the command, which is formatted like `"Category.Name"`. |

## Working with Checkable Buttons

A command must be flagged as [Checkable](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checkable) before it can be checked.  If the [Checkable](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checkable) property is `false`, the command cannot be checked by the end user.  If the [Checkable](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checkable) property is `true`, the command's [Checked](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checked) property value can be toggled by the end user.

The [Checked](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checked) property value can be toggled programmatically as well.

```csharp
((IBarCheckableCommand)barManager.Commands["Format.TextAlignmentLeft"]).Checked = true;
```

If the [AutoUpdateChecks](xref:@ActiproUIRoot.Controls.Bars.BarManager.AutoUpdateChecks) property is set to `true`, any checkable buttons that are clicked by the end user will be automatically toggled.  If that property is `false`, the checkable buttons can only have their [Checked](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checked) state toggled programmatically.

## Working with Check Groups

Check groups are a powerful feature found in Bars.  When working with checkable buttons, there are two scenarios.  The first is where the checkable button provides an on/off toggle for a specific feature.  This sort of checkable button stands alone.  The second is where the checkable button is a toggle for a specific feature within a feature group.  For instance, in a text editing application, there would be a check group for text alignment (left, center, right, and justify).

By specifying a [CheckGroupName](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.CheckGroupName) for all the checkable buttons in a check group, Bars adds numerous features for easily working with check groups.  In our above scenario, all the checkable buttons for the text alignment check group could have a [CheckGroupName](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.CheckGroupName) value of `"TextAlignment"`.

If the [AutoUpdateCheckGroups](xref:@ActiproUIRoot.Controls.Bars.BarManager.AutoUpdateCheckGroups) property is set to `true`, any checkable buttons in a check group that are clicked by the end user will be automatically checked and all other checkable buttons in the check group will be unchecked.  If that property is `false`, the checkable buttons can only have their [Checked](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand.Checked) state toggled programmatically.

To return the [IBarCheckableCommand](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand) that is current checked in a check group, call the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).[GetCheckGroupValue](xref:@ActiproUIRoot.Controls.Bars.BarManager.GetCheckGroupValue*) method and pass in the desired check group name.  If the check group is not found, or no command is checked within the check group, `null` is returned.

```csharp
IBarCheckableCommand checkableCommand = barManager.GetCheckGroupValue("TextAlignment");
```

To set the value of a check group, call the [SetCheckGroupValue](xref:@ActiproUIRoot.Controls.Bars.BarManager.SetCheckGroupValue*) method and pass in the check group name and the [IBarCheckableCommand](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand) that should be checked.  Any other [IBarCheckableCommand](xref:@ActiproUIRoot.Controls.Bars.IBarCheckableCommand) in the group that was previously checked will automatically be unchecked.

```csharp
barManager.SetCheckGroupValue("TextAlignment", (IBarCheckableCommand)barManager.Commands["Format.TextAlignmentLeft"]);
```

To get an array of all the check group names being managed by the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager), call the [GetCheckGroupNames](xref:@ActiproUIRoot.Controls.Bars.BarManager.GetCheckGroupNames*) method.

```csharp
string[] checkGroupNames = barManager.GetCheckGroupNames();
```
