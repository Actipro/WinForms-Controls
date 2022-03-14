---
title: "Converting to v21.1"
page-title: "Converting to v21.1 - Conversion Notes"
order: 9
---
# Converting to v21.1

All of the breaking changes are detailed or linked below.

## Namespaces Renamed

The following API types and namespaces have been moved or renamed for clarity and consistency with those used by our other platforms:

- `UIContainerControl`, `UIControl`, `UIElement`, `NoActivateForm`, and `PopupControl` types moved from `ActiproSoftware.WinUICore` namespace to `ActiproSoftware.UI.WinForms.Controls.Primitives` namespace.
- `ActiproSoftware.ComponentModel` namespace is now `ActiproSoftware.UI.WinForms`
- `ActiproSoftware.WinUICore.Input` namespace is now `ActiproSoftware.UI.WinForms.Input`
- `ActiproSoftware.WinUICore` namespace is now `ActiproSoftware.UI.WinForms.Controls`
- `ActiproSoftware.WinUICore.Commands` namespace is now `ActiproSoftware.UI.WinForms.Controls.Commands`
- `ActiproSoftware.WinUICore.Rendering` namespace is now `ActiproSoftware.UI.WinForms.Controls.Rendering`
- `ActiproSoftware.MarkupLabel` namespace is now `ActiproSoftware.UI.WinForms.Controls.MarkupLabel`
- `ActiproSoftware.Drawing` namespace is now `ActiproSoftware.UI.WinForms.Drawing`
- `ActiproSoftware.UIStudio.Bar` namespace is now `ActiproSoftware.UI.WinForms.Controls.Bars`
- `ActiproSoftware.UIStudio.NavigationBar` namespace is now `ActiproSoftware.UI.WinForms.Controls.Navigation`
- `ActiproSoftware.UIStudio.Dock` and `ActiproSoftware.UIStudio.TabStrip` namespaces have both been merged into `ActiproSoftware.UI.WinForms.Controls.Docking`
- `ActiproSoftware.Wizard` namespace is now `ActiproSoftware.UI.WinForms.Controls.Wizard`

> [!NOTE]
> Update all `using` statements and fully-qualified type names to use the new namespaces as defined above. The following replace operations can be used in the given order to safely perform the majority of the conversion:
> 
> - Replace `ActiproSoftware.WinUICore.UIContainerControl` with `ActiproSoftware.UI.WinForms.Controls.Primitives.UIContainerControl`
> - Replace `ActiproSoftware.WinUICore.UIControl` with `ActiproSoftware.UI.WinForms.Controls.Primitives.UIControl`
> - Replace `ActiproSoftware.WinUICore.UIElement` with `ActiproSoftware.UI.WinForms.Controls.Primitives.UIElement`
> - Replace `ActiproSoftware.WinUICore.NoActivateForm` with `ActiproSoftware.UI.WinForms.Controls.Primitives.NoActivateForm`
> - Replace `ActiproSoftware.WinUICore.PopupControl` with `ActiproSoftware.UI.WinForms.Controls.Primitives.PopupControl`
> - Replace `ActiproSoftware.WinUICore.Input` with `ActiproSoftware.UI.WinForms.Input`
> - Replace `ActiproSoftware.ComponentModel` with `ActiproSoftware.UI.WinForms`
> - Replace `ActiproSoftware.Drawing` with `ActiproSoftware.UI.WinForms.Drawing`
> - Replace `ActiproSoftware.WinUICore` with `ActiproSoftware.UI.WinForms.Controls`
> - Replace `ActiproSoftware.MarkupLabel` with `ActiproSoftware.UI.WinForms.Controls.MarkupLabel`
> - Replace `ActiproSoftware.UIStudio.Bar` with `ActiproSoftware.UI.WinForms.Controls.Bars`
> - Replace `ActiproSoftware.UIStudio.Dock` with `ActiproSoftware.UI.WinForms.Controls.Docking`
> - Replace `ActiproSoftware.UIStudio.NavigationBar` with `ActiproSoftware.UI.WinForms.Controls.Navigation`
> - Replace `ActiproSoftware.UIStudio.TabStrip` with `ActiproSoftware.UI.WinForms.Controls.Docking`
> - Replace `ActiproSoftware.Wizard` with `ActiproSoftware.UI.WinForms.Controls.Wizard`
> 
>  If a compiler error indicates a `UIContainerControl`, `UIControl`, `UIElement`, `NoActivateForm`, or `PopupControl` type cannot be found, you may need to add a `using ActiproSoftware.UI.WinForms.Controls.Primitives;` statement since any existing `using ActiproSoftware.WinUICore;` statement that qualified those types may have been renamed to `using ActiproSoftware.UI.WinForms.Controls;`.

## StatusBarPanel.AutoSize Property Type Changed

The [StatusBarPanel](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanel).[AutoSize](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanel.AutoSize) property has changed from type `System.Windows.Forms.StatusBarPanelAutoSize` (removed in .NET 5) to [StatusBarPanelAutoSize](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanelAutoSize) in the [ActiproSoftware.UI.WinForms.Controls.Bars](xref:@ActiproUIRoot.Controls.Bars) namespace (previously in the `ActiproSoftware.UIStudio.Bar` namespace).

> [!NOTE]
> Replace all `System.Windows.Forms.StatusBarPanelAutoSize` enum values with `ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanelAutoSize` enum values of the same name.

## Context Menu Type Changes

To better align with .NET Core, usage of `System.Windows.Forms.ContextMenu` was replaced with `System.Windows.Forms.ContextMenuStrip` for the following types:

- `ActiproSoftware.UI.WinForms.Controls.ScrollBar` (previously of the `ActiproSoftware.WinUICore` namespace).
- [SyntaxEditor](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditor) and [SyntaxEditorMenuEventArgs](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorMenuEventArgs) of the `ActiproSoftware.UI.WinForms.Controls.SyntaxEditor` namespace.

> [!NOTE]
> 
> - Update any overrides of [SyntaxEditor](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditor).[CreateDefaultContextMenu](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditor.CreateDefaultContextMenu*) to return `System.Windows.Forms.ContextMenuStrip`.
> - Update any references to [SyntaxEditorMenuEventArgs](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorMenuEventArgs).[Menu](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorMenuEventArgs.Menu) to work with `System.Windows.Forms.ContextMenuStrip`.

## .NET Core Changes

For users targeting .NET Core, the following changes were made only in our .NET Core builds since .NET Core 3.1 removed `MainMenu`, `ContextMenu`, and `MenuItem` (of the `System.Windows.Forms` namespace):

- `OwnerDrawMainMenu`, `OwnerDrawContextMenu`, and `OwnerDrawMenuItem` types (previously of the `ActiproSoftware.WinUICore` namespace) were removed.
- `OwnerDrawMainMenu` and `MainMenu` replaced with `System.Windows.Forms.MenuStrip`.
- `OwnerDrawContextMenu` and `ContextMenu` replaced with `System.Windows.Forms.ContextMenuStrip`.
- `OwnerDrawMenuItem` and `MenuItem` replaced with `System.Windows.Forms.ToolStripMenuItem`.

## IBarRenderer.DrawCommandLinkInCustomizeList Method Added

The [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer) interface has a new [DrawCommandLinkInCustomizeList](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer.DrawCommandLinkInCustomizeList*) method for rendering a [BarCommandLink](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink) in a ListBox control. This method is implemented by all built-in renderers, so only user-defined renderers that directly implement the [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer) interface or derive from the abstract base class [BarRenderer](xref:@ActiproUIRoot.Controls.Bars.BarRenderer) will need to implement the method.

> [!NOTE]
> 
> - Add `DrawCommandLinkInCustomizeList` method implementation to any classes which implement the [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer) interface.
> - Add `DrawCommandLinkInCustomizeList` method implementation to any classes which derive from the [BarRenderer](xref:@ActiproUIRoot.Controls.Bars.BarRenderer) abstract class.

## BarManager.PopupAnimation Removed

Popup animations have not been supported since Windows XP and any value assigned to `BarManager.PopupAnimation` has been ignored on newer versions of Windows. Since Windows XP is no longer supported, the `BarManager.PopupAnimation` property and related `BarPopupAnimation` enum have been removed.

> [!NOTE]
> 
> - Remove any statements which read or write the `BarManager.PopupAnimation` property.
> - Remove any references to the `BarPopupAnimation` enum.
