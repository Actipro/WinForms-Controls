---
title: "Layouts"
page-title: "Layouts - Navigation Reference"
order: 6
---
# Layouts

A NavigationBar layout is defined as the selected pane, buttons visible, pane order, and pane visibility for a [NavigationBar](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar) control.

Sometimes it is useful to save the layout state of a [NavigationBar](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar) and restore it later.  This allows for end users to retain their customizations across multiple application executions.  The way to do this is to persist the NavigationBar layout data.

## Saving Layout Data

NavigationBar layout data can be persisted in XML format and loaded at a later time.  Probably the two most common ways to store layouts are in files and in a database.

The [SaveLayoutToFile](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.SaveLayoutToFile*) method is used to save NavigationBar layout data to a file.  This method saves the layout data of all panes being managed by the [NavigationBar](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar) control.  The method accepts the full path to the data file as a parameter.

Saving to other storage formats can also be accomplished.  The [LayoutData](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.LayoutData) property returns the NavigationBar layout data expressed in an `XmlDocument`.  The `XmlDocument` can be written to a database or persisted in some other form.

## Loading Layout Data

When loaded, NavigationBar layout data restores the order and visibility states of the panes being managed by the [NavigationBar](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar) control.  It also determines the number of large buttons to display and selects the pane that was selected when the layout was saved.

The layout data loading code attempts to match the keys of panes that were stored in the layout to the keys of panes contained in the [Panes](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.Panes) collection.  If there is pane layout data for a pane that cannot be found in the panes collection, that layout data is ignored.

The [LoadLayoutFromFile](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.LoadLayoutFromFile*) method is used to load NavigationBar layout data from a file.  The method accepts the full path to the data file as a parameter.

Loading from other storage formats can also be accomplished.  For instance, if the XML layout data was stored in a database, the layout data should be loaded into an `XmlDocument` class and then set to the [LayoutData](xref:@ActiproUIRoot.Controls.Navigation.NavigationBar.LayoutData) property.  The setting of this property loads the specified layout data.
