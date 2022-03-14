---
title: "Application Modes"
page-title: "Application Modes - Bars Reference"
order: 10
---
# Application Modes

Application modes are a special feature found in the bar controls.  An application mode is a mode that your application enters in which certain functionality should be switched on or off.

This is extremely useful in an IDE type of application.  In an IDE like Visual Studio, there are modes like `Text Editor`, `Image Editor`, `WebBrowser`, etc.  In each mode certain keyboard shortcuts and dockable toolbars are used that are not used in other modes.

The [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) provides functionality for automatically displaying and hiding certain dockable toolbars based on what the current application mode is.  The [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) can also be set up to only recognize certain keyboard shortcuts while in specific modes.

## Global Mode

A global mode exists by default.  It is specified by `null`.

The global mode is selected by default until you set a different mode.

## Setting Up Modes

Application modes are simple strings, and each mode for your application should be added to the [Modes](xref:@ActiproUIRoot.Controls.Bars.BarManager.Modes) collection on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).  You can do this at design-time.

The global mode should never be added to this collection since it is natively available.

## Tracking the Selected Mode

The currently selected mode is accessible via the [SelectedMode](xref:@ActiproUIRoot.Controls.Bars.BarManager.SelectedMode) property on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).  This property can be set to change the mode.  Setting the value to `null` changes to the global mode.

The [SelectedModeChanged](xref:@ActiproUIRoot.Controls.Bars.BarManager.SelectedModeChanged) event is raised whenever the [SelectedMode](xref:@ActiproUIRoot.Controls.Bars.BarManager.SelectedMode) property value changes, allowing you to perform further updating.

## Showing/Hiding Dockable Toolbars Based on Mode

Dockable toolbars can be automatically displayed or hidden based on what mode is selected.  By default, dockable toolbars do not show or hide.  This is because their [Modes](xref:@ActiproUIRoot.Controls.Bars.DockableToolBar.Modes) collection is empty when created.

To enable this functionality, add the applicable modes to the [Modes](xref:@ActiproUIRoot.Controls.Bars.DockableToolBar.Modes) collection for which the dockable toolbar should be displayed.  When any of those modes are selected in the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager), the dockable toolbar will display.  When a different mode is selected, the dockable toolbar will hide.

## Keyboard Shortcuts

Each [BarKeyboardShortcut](xref:@ActiproUIRoot.Controls.Bars.BarKeyboardShortcut) has a [Mode](xref:@ActiproUIRoot.Controls.Bars.BarKeyboardShortcut.Mode) property.  If that value is `null`, then the shortcut applies to the global mode.  If that value is populated, then the shortcut only applies to that specific mode.

For example, if a `Text Editor` mode is currently set, any keyboard shortcuts defined for the `Text Editor` mode will be recognized.  If there is no keyboard shortcut defined in the mode for a key sequence that is pressed, a keyboard shortcut in the global mode is searched for.  If one is found, then that keyboard shortcut is used.

Read the [Keyboard Shortcuts](keyboard-shortcuts.md) topic for more information on keyboard shortcuts.
