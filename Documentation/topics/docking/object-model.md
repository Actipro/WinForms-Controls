---
title: "Object Model"
page-title: "Object Model - Docking & MDI Reference"
order: 3
---
# Object Model

The Dock controls have a number of controls that are used to build the docking window system.

## DockManager

At the center of the docking window system is the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component.  The manager controls all of the docking windows in the system.  To add docking window functionality to your applications, you must create a [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component on a `Form` and assign it a host container control.

## IDockObject Interface

All dock objects implement the [IDockObject](xref:@ActiproUIRoot.Controls.Docking.IDockObject) interface.  This interface provides access to the common [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component and also indicates the dock object type.

## Tool Window

[Tool windows](tool-windows.md), represented by the [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow) class, inherit from the [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow) class.  This allows them to be used in the MDI area, when MDI is used.  Tool windows can be dragged and docked to other dock objects, including the side of the host container control.  They can be attached together, which makes them share the same client area and adds a tabstrip that is used to select which tool window is displayed.  They can be undocked to floating windows and nested in hierarchies in those windows.  They can enter auto-hide mode on any side of the host container control.

## Document Window

[Document windows](document-windows.md), represented by the [DocumentWindow](xref:@ActiproUIRoot.Controls.Docking.DocumentWindow) class, also inherit from the [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow) class.  Document windows are limited to the MDI area.  Their lifetime typically only lasts during the time in which they are displayed.

## Tool Window Container

A tool window container is represented by the [ToolWindowContainer](xref:@ActiproUIRoot.Controls.Docking.ToolWindowContainer) class.  It is used as a container for tool windows that are docked in the host container control as well as in floating windows.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).

## Dock Container Container

A dock container container is represented by the [DockContainerContainer](xref:@ActiproUIRoot.Controls.Docking.DockContainerContainer) class.  It is used as a container for other dock containers which can include tool window containers and dock container containers.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).

## Auto-Hide TabStrip Panel

An auto-hide tabstrip panel is represented by the [AutoHideTabStripPanel](xref:@ActiproUIRoot.Controls.Docking.AutoHideTabStripPanel) class.  It is used as a tabstrip for tool windows that are in auto-hide mode.  It does not contain any tool windows but does have an associated auto-hide container that does contain the tool windows.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).

## Auto-Hide Container

An auto-hide container is represented by the [AutoHideContainer](xref:@ActiproUIRoot.Controls.Docking.AutoHideContainer) class.  It is used as a container for tool windows that are in auto-hide mode on the side of the host container control.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).

## Tabbed MDI Root Container

A tabbed MDI root container is represented by the [TabbedMdiRootContainer](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiRootContainer) class.  It fills the inner MDI area of the host container control when the `Tabbed` MDI mode is used.  It contains tabbed MDI containers, which in turn display the tool and document windows in the MDI area.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).

## Tabbed MDI Container

A tabbed MDI container is represented by the [TabbedMdiContainer](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiContainer) class.  It is used as a container for tool and document windows that are in the MDI area when `Tabbed` MDI mode is used.

> [!IMPORTANT]
> These controls should never be created programmatically by the developer since they are created as-needed by the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).
