---
title: "Other Events"
page-title: "Other Events - Navigation Reference"
order: 7
---
# Other Events

The [NavigationBar](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar) control exposes several other useful events for various situations.

## NavigationPane Active Property Changes

The [NavigationPaneActiveChanging](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.NavigationPaneActiveChanging) event is raised before the [Active](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane.Active) property is set to a new value.  The event's arguments contain a `Cancel` property that allows you to cancel whether the property value is allowed to change or not.

## Maximum Button Count Change Notification

The [MaximumBarButtonCountChanged](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.MaximumBarButtonCountChanged) event is raised whenever the value of the [MaximumBarButtonCount](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.MaximumBarButtonCount) property is changed.  This property can indirectly be changed by the end user via resizing of the splitter, or by using the configuration menu to show more or less buttons.

## Notification of End User Reordering Panes

The [NavigationPanesReordered](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.NavigationPanesReordered) event is raised whenever the end user uses the **Navigation Bar Options** dialog to reorder the panes.
