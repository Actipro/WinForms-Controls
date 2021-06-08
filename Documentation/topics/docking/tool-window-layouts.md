---
title: "Tool Window Layouts"
page-title: "Tool Window Layouts - Docking & MDI Reference"
order: 12
---
# Tool Window Layouts

A tool window layout is defined as the visibility, position, size, and docking state of one or more tool windows as controlled by a [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component.  Tool windows may be docked, undocked, attached, floated, or hidden in any number of variations.

It is generally desirable for applications to save customized tool window layouts for later use.  For instance, when an end-user runs an application that uses the Dock controls, he or she will dock tool windows to their liking.  They will want this customization to remain the same across multiple application sessions.  The way to do this is to persist the tool window layout data.

## Saving Layout Data

Tool window layout data can be persisted in XML format and loaded at a later time.  Probably the two most common ways to store layouts are in files and in a database.

The [SaveToolWindowLayoutToFile](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SaveToolWindowLayoutToFile*) method is used to save tool window layout data to a file.  This method saves the layout data of all tool windows being managed by the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component.  The method accepts the full path to the data file as a parameter.

Saving to other storage formats can also be accomplished.  The [ToolWindowLayoutData](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowLayoutData) property returns the tool window layout data expressed in an `XmlDocument`.  The `XmlDocument` can be written to a database or persisted in some other form.

## Loading Layout Data

When loaded, tool window layout data restores the tool windows being managed by the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component to their proper locations and sizes within the host container control.

The layout data loading code attempts to match the keys of tool windows that were stored in the layout to the keys of tool windows contained in the [ToolWindows](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindows) collection.  If there is tool window layout data for a [ToolWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow).[Key](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow.Key) that cannot be found in the tool windows collection, a new blank tool window is created.  The [CreationMethod](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow.CreationMethod) property specifies how each tool window is created.  If its value is `Layout`, then you know that the tool window was created because of a layout not matching a tool window key.

The [WindowCreated](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.WindowCreated) event can be used to initialize a tool window that was created dynamically via a layout (or any other method).  In its event arguments, the window that was created is passed, allowing for checking of its [CreationMethod](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow.CreationMethod) property.

The [LoadToolWindowLayoutFromFile](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.LoadToolWindowLayoutFromFile*) method is used to load tool window layout data from a file.  The method accepts the full path to the data file as a parameter.

Loading from other storage formats can also be accomplished.  For instance, if the XML layout data was stored in a database, the layout data should be loaded into an `XmlDocument` class and then set to the [ToolWindowLayoutData](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowLayoutData) property.  The setting of this property loads the specified layout data.

## Layout Load Events

The loading of a tool window layout causes two events on the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component to be raised.

| Member | Description |
|-----|-----|
| [ToolWindowLayoutLoading](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowLayoutLoading) Event | Occurs before tool window layout is loaded. |
| [ToolWindowLayoutLoaded](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowLayoutLoaded) Event | Occurs after tool window layout is loaded. |

## Saving Custom Data in a Layout

The [SaveCustomToolWindowLayoutData](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SaveCustomToolWindowLayoutData) event can be used to write custom data to a tool window layout file.  Its event arguments pass an `XmlWriter` which is used to persist the custom data.  The data can be read when the layout is loaded at a later time.

## Loading Custom Data from a Layout

The [LoadCustomToolWindowLayoutData](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.LoadCustomToolWindowLayoutData) event can be used to load custom data that was written to the tool window layout.  Its event arguments pass an `XmlReader` which is used to read the custom data.

## Closing All Tool Windows

All tool windows can be quickly closed by using the [CloseAllActiveToolWindows](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.CloseAllActiveToolWindows*) method.  The method accepts a boolean parameter indicating whether to force the closings or not.  If the closings are forced, they cannot be cancelled by handling the [WindowClosing](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.WindowClosing) event and setting its event argument's `Cancel` property to `true`.
