---
title: "Context Menus"
page-title: "Context Menus - Navigation Reference"
order: 5
---
# Context Menus

By default, the [NavigationBar](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar) control will display its own built-in menus for context menus and the overflow menu button.  However that default menu can be cancelled to provide a completely custom menu instead.  This is ideal for situations where a third-party menu is to be used or if the default menu needs to be customized.

Whenever a menu is to be displayed, [NavigationBar](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar) raises the [ContextMenuRequested](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.ContextMenuRequested) event.  The event arguments indicate the location at which the menu should be displayed as well as a [NavigationBarContextMenuSource](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarContextMenuSource) specifying why the menu is being displayed.

To cancel the default menu and display a custom one instead, set the `Cancel` property of the event arguments to `true` and display the custom menu in the event handler.
