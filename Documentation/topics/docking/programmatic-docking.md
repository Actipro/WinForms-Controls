---
title: "Programmatic Docking"
page-title: "Programmatic Docking - Docking & MDI Reference"
order: 11
---
# Programmatic Docking

The Dock controls use a robust object model that allows for complete programmatic control over the docking windows.  The MDI area managed by a [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) can contain documents.

> [!IMPORTANT]
> Documents can be tool or document windows, so it is important to remember that the functionality below describes any tool or document window that is active in the MDI area.

## Creating a Tool Window

The [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow) class has several constructors available.  However, the parameterless constructor is reserved for internal code and should never be called.

This code demonstrates how to create a tool window in code:

```csharp
ToolWindow tw = new ToolWindow(dockManager, "TW Key", "TW Text", -1, childControl);
```

Note how the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) that should be used to manage the tool window is passed in, as well as the child control to add to the tool window.  The child control is automatically set to `DockStyle.Fill`.  The child control parameter may be `null`.  Since the tool window inherits from `ContainerControl`, any number of controls can be added to it via its `Controls` collection.

## Docking a Tool Window to Another Dock Object

The [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow) class has a [DockTo](xref:@ActiproUIRoot.Controls.Docking.ToolWindow.DockTo*) method that is used to perform a number of different docking operations for the tool window.  Its first parameter is the target dock object, which can be any [IDockObject](xref:@ActiproUIRoot.Controls.Docking.IDockObject).  The second parameter is a [DockOperationType](xref:@ActiproUIRoot.Controls.Docking.DockOperationType) enumeration value.  The values are described below:

| Value | Description |
|-----|-----|
| `Attach` | Attach to the target. |
| `LeftInner` | Dock on the left interior. |
| `TopInner` | Dock on the top interior. |
| `RightInner` | Dock on the right interior. |
| `BottomInner` | Dock on the bottom interior. |
| `LeftOuter` | Dock on the left exterior. |
| `TopOuter` | Dock on the top exterior. |
| `RightOuter` | Dock on the right exterior. |
| `BottomOuter` | Dock on the bottom exterior. |

The [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) should be used as a dock target whenever the target is intended to be the host container control or the MDI area.

This code docks the tool window to the outer left edge of the host container control:

```csharp
tw.DockTo(dockManager, DockOperationType.LeftOuter);
```

This code docks the tool window to the inner (closest to client area) bottom edge of the host container control:

```csharp
tw.DockTo(dockManager, DockOperationType.BottomInner);
```

This code docks the tool window to the right of another tool window `tw2`:

```csharp
tw.DockTo(tw2, DockOperationType.RightOuter);
```

This code attaches the tool window to another tool window `tw2` so that they share the same space:

```csharp
tw.DockTo(tw2, DockOperationType.Attach);
```

## Undocking a Tool Window

A tool window can be floated to a floating window using the [Undock](xref:@ActiproUIRoot.Controls.Docking.ToolWindow.Undock*) method.  Additionally, by setting the [State](xref:@ActiproUIRoot.Controls.Docking.ToolWindow.State) property to `Floating`, instead of `DockableOutsideHost`, the tool window will not be permitted to dock when dragged over a dock target.

This code undocks the tool window to a floating window:

```csharp
tw.Undock();
```

## Auto-Hiding a Tool Window

A tool window can be placed in auto-hide mode by setting the [State](xref:@ActiproUIRoot.Controls.Docking.ToolWindow.State) property to `AutoHide`.

This code places the tool window into auto-hide mode:

```csharp
tw.State = ToolWindowState.AutoHide;
```

All tool windows can be auto-hidden at once using the [AutoHideAllToolWindowsDockedInHost](xref:@ActiproUIRoot.Controls.Docking.DockManager.AutoHideAllToolWindowsDockedInHost*) method:

```csharp
dockManager.AutoHideAllToolWindowsDockedInHost();
```

To restore a tool window to be docked inside of the host container from auto-hide mode, change the state:

```csharp
tw.State = ToolWindowState.DockableInsideHost;
```

## Moving a Tool Window into the MDI Area

A tool window can be placed in the MDI area by setting the [State](xref:@ActiproUIRoot.Controls.Docking.ToolWindow.State) property to `TabbedDocument`.

This code moves the tool window into the MDI area:

```csharp
tw.State = ToolWindowState.TabbedDocument;
```

## Creating a Document Window

The [DocumentWindow](xref:@ActiproUIRoot.Controls.Docking.DocumentWindow) class has several constructors available.  However, the parameterless constructor is reserved for internal code and should never be called.

This code demonstrates how to create a document window in code:

```csharp
DocumentWindow dw = new DocumentWindow(dockManager, "DW Key", "DW Text", null, childControl);
```

Note how the [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) that should be used to manage the document window is passed in, as well as the child control to add to the document window.  The child control is automatically set to `DockStyle.Fill`.  The child control parameter may be `null`.  Since the document window inherits from `ContainerControl`, any number of controls can be added to it via its `Controls` collection.

## Activating a Tool or Document Window

Tool and document windows can be activated (made available in the user interface) by calling their [Activate](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.Activate*) method.

This code activates a document window:

```csharp
dw.Activate();
```

A separate overload of the [Activate](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.Activate*) method is available that lets you control whether the activated window will receive focus.  The parameterless implementation sets focus to the activated window.

This code activates a document window and does not set focus to the window:

```csharp
dw.Activate(false);
```

## Closing a Tool or Document Window

Tool and document windows can be closed (hidden from the user interface) by calling their [Close](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.Close*) method.

This code closes a document window:

```csharp
dw.Close();
```
