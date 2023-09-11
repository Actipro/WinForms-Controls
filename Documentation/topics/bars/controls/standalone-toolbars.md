---
title: "Standalone Toolbars"
page-title: "Standalone Toolbars - Bars Control Types Reference"
order: 3
---
# Standalone Toolbars

Standalone toolbars, represented by the [ToolBar](xref:@ActiproUIRoot.Controls.Bars.ToolBar) class, provide an alternative to the standard Windows Forms `ToolBar` control.  They can be placed anywhere on a `Form` and used like a regular `ToolBar` control.

![Screenshot](../images/bar-standalone-toolbar.gif)

It is typically best to attach a [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) to the toolbar.

## Changing the Orientation

A toolbar's orientation can be changed by setting the [Orientation](xref:@ActiproUIRoot.Controls.Bars.ToolBar.Orientation) property.

## Modifying Child Command Links Programmatically

The [CommandLinks](xref:@ActiproUIRoot.Controls.Bars.ToolBar.CommandLinks) collection stores all of the command links that are contained by the toolbar.  To programmatically add a new command link to the bar control, simply add it to collection.

## Modifying Child Command links in the Designer

If the toolbar is attached to a [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) and the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) is in customize mode in the designer, commands can be added to the standalone toolbar just like they are for dockable toolbars.  The toolbar is only customizable via this functionality at design-time and cannot be customized by the end user at run-time.

## Handling Command Link Events

The toolbar has several equivalent events like those that appear on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager), such as [CommandClick](xref:@ActiproUIRoot.Controls.Bars.ToolBar.CommandClick).  These can be used for processing command link clicks.

> [!IMPORTANT]
> If a [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) is attached to the toolbar, only the events on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) will be raised and not the equivalent events on the toolbar.
