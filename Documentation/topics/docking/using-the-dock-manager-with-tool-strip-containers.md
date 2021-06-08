---
title: "Using the DockManager with ToolStripContainers"
page-title: "Using the DockManager with ToolStripContainers - Docking & MDI Reference"
order: 20
---
# Using the DockManager with ToolStripContainers

The .NET Framework 2.0 introduced a new set of menu/toolbar controls.  A special control, `ToolStripContainer` can be used to provide docking toolbar functionality.  Essentially the `ToolStripContainer` is added to the parent `Form` and docking toolbars are able to be added and rafted to the sides of the container.  The `ToolStripContainer` control has a child control within it that is of type `ToolStripContainer.ContentPanel`.

Dock controls will work with the `ToolStripContainer`, however a couple tweaks are needed.  First the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) needs to be set to the interior of the `ToolStripContainer`.

> [!IMPORTANT]
> *Do not* set the [HostContainerControl](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.HostContainerControl) property to the `ToolStripContainer` control itself.

Since the `ToolStripContainer.ContentPanel` is not a `ContainerControl`, the [HostContainerControl](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.HostContainerControl) property cannot be set to it.  Therefore a control that inherits `ContainerControl` must be added as a child of the `ToolStripContainer.ContentPanel`.  This control should be set to `DockStyle.Fill`.

A recommended way to add a `ContainerControl` is to make a simple `UserControl` and place it as the child of the `ToolStripContainer.ContentPanel`, with `DockStyle.Fill`.  Then set the [HostContainerControl](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.HostContainerControl) property of the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) to the `UserControl`.

After that, the menu/toolbar controls will dock to the outer areas of the parent `Form`, while the Dock controls dock inside of the toolbar rafting containers.
