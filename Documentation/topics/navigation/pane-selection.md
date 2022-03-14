---
title: "Pane Selection"
page-title: "Pane Selection - Navigation Reference"
order: 3
---
# Pane Selection

All panes in a [NavigationBar](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar) are listed in its [Panes](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.Panes) collection.  The selected pane can be set programmatically by using the [SelectedPane](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SelectedPane) property.  The [SelectedIndex](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SelectedIndex) property also can change the selected pane.

## Selection Events

There are two events which are raised when selection changes occur.

The [SelectionChanging](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SelectionChanging) event is raised immediately before a selection change occurs.  Its event arguments specify the [NavigationPane](xref:@ActiproUIRoot.Controls.Navigation.NavigationPane) that is about to be selected.

The [SelectionChanged](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SelectionChanged) event is raised immediately after a selection change occurs.

## Cancelling Selection Changes

Most selection changes can be cancelled by handling the [SelectionChanging](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SelectionChanging) event and setting its `Cancel` property to `true`.
