---
title: "Controlling Window Capabilities"
page-title: "Controlling Window Capabilities - Docking & MDI Reference"
order: 6
---
# Controlling Window Capabilities

The Dock controls provide the most detailed control of window capabilities in a product of its type.  Window capabilities can be set on a global level via properties on the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component, or can be set on an individual basis via properties on each document or tool window instance that override the global defaults.

## Global Defaults

Global defaults can be set to affect window capabilities.  The values can be overwritten in each window instance however these settings will be used if no overrides are set.  The following properties are all found on the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component and control the global default settings:

| Member | Description |
|-----|-----|
| [DocumentWindowsCanClose](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.DocumentWindowsCanClose) Property | Gets or sets the global setting for whether document windows can be closed. |
| [ToolWindowsCanAttach](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanAttach) Property | Gets or sets the global setting for whether tool windows may be attached to another tool window. |
| [ToolWindowsCanAutoHide](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanAutoHide) Property | Gets or sets the global setting for whether tool windows may be placed in auto-hide mode. |
| [ToolWindowsCanBecomeDocuments](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanBecomeDocuments) Property | Gets or sets the global setting for whether tool windows may be placed in a document state. |
| [ToolWindowsCanClose](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanClose) Property | Gets or sets the global setting for whether tool windows can be closed. |
| [ToolWindowsCanDockHostBottom](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanDockHostBottom) Property | Gets or sets the global setting for whether tool windows may be docked to the bottom of the host container control. |
| [ToolWindowsCanDockHostLeft](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanDockHostLeft) Property | Gets or sets the global setting for whether tool windows may be docked to the left of the host container control. |
| [ToolWindowsCanDockHostRight](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanDockHostRight) Property | Gets or sets the global setting for whether tool windows may be docked to the right of the host container control. |
| [ToolWindowsCanDockHostTop](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanDockHostTop) Property | Gets or sets the global setting for whether tool windows may be docked to the top of the host container control. |
| [ToolWindowsCanDrag](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanDrag) Property | Gets or sets the global setting for whether tool windows may be dragged to another location. |
| [ToolWindowsCanFloat](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsCanFloat) Property | Gets or sets the global setting for whether tool windows may be contained in a floating window. |
| [ToolWindowsHaveOptions](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsHaveOptions) Property | Gets or sets the global setting for whether tool windows have more options available than the standard options. |
| [ToolWindowsHaveTitleBars](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ToolWindowsHaveTitleBars) Property | Gets or sets the global setting for whether tool windows display a title bar when docked. |

## Instance Settings

Instance settings are specific to a single instance of a tool or document window.  Boolean values use a `DefaultableBoolean` enumeration value to indicate whether they should use the global default value, or force a `true` or `false` instance setting.

These are the settings found on the [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow) class that provide instance settings to each tool window and document window.

| Member | Description |
|-----|-----|
| [CanClose](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow.CanClose) Property | Gets or sets whether the window may be closed. |

These are the settings found on the [ToolWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow) class that provide instance settings to each tool window.

| Member | Description |
|-----|-----|
| [CanAttach](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanAttach) Property | Gets or sets whether the tool window may be attached to another tool window. |
| [CanAutoHide](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanAutoHide) Property | Gets or sets whether the tool window may be placed in auto-hide mode. |
| [CanBecomeDocument](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanBecomeDocument) Property | Gets or sets whether the tool window may be placed in a document state. |
| [CanDockHostBottom](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanDockHostBottom) Property | Gets or sets whether the tool window may be docked to the bottom of the host container control. |
| [CanDockHostLeft](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanDockHostLeft) Property | Gets or sets whether the tool window may be docked to the left of the host container control. |
| [CanDockHostRight](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanDockHostRight) Property | Gets or sets whether the tool window may be docked to the right of the host container control. |
| [CanDockHostTop](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanDockHostTop) Property | Gets or sets whether the tool window may be docked to the top of the host container control. |
| [CanDrag](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanDrag) Property | Gets or sets whether the tool window may be dragged to another location. |
| [CanFloat](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.CanFloat) Property | Gets or sets whether the tool window may be contained in a floating window. |
| [HasOptions](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.HasOptions) Property | Gets or sets whether the tool window has more options available than the standard options. |
| [HasTitleBar](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ToolWindow.HasTitleBar) Property | Gets or sets whether the tool window displays a title bar when docked. |
