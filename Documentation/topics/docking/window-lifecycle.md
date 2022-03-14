---
title: "Window Lifecycle"
page-title: "Window Lifecycle - Docking & MDI Reference"
order: 4
---
# Window Lifecycle

Both tool and document windows share the same base class and share similar lifecycles.  The main difference is that by default, tool windows exist throughout the life of the manager and document windows exist only while active.  However that behavior can be overridden.

## Lifecycle Events

Each tool and document window raises a number of events on the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component when lifecycle events occur.

| Member | Description |
|-----|-----|
| [WindowCreated](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowCreated) Event | Occurs immediately after a window is created.  This event is only called once during the lifetime of the window. |
| [WindowInitializing](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowInitializing) Event | Occurs before the window is activated for the first time, allowing for lazy initialization of the window.  After this event is raised for a window, the window's [IsInitialized](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.IsInitialized) property is set to `true`.  This event is only called once during the lifetime of the window. |
| [WindowActivating](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowActivating) Event | Occurs before a window is activated from an inactive state. |
| [WindowActivated](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowActivated) Event | Occurs after a window is activated from an inactive state and is visible. |
| [WindowFocused](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowFocused) Event | Occurs after a window receives focus. |
| [WindowClosing](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowClosing) Event | Occurs before a window is deactivated from an active state.  The event arguments for this event have a `Cancel` property that allows for the cancelling of closing. |
| [WindowClosed](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowClosed) Event | Occurs after a window is deactivated from an active state. |
| [WindowDisposed](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowDisposed) Event | Occurs when a window is disposed.  This event is only called once during the lifetime of the window. |
