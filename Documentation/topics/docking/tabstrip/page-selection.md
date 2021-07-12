---
title: "Page Selection"
page-title: "Page Selection - TabStrip - Docking & MDI Reference"
order: 4
---
# Page Selection

All pages in a [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip) are listed in its [Pages](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.Pages) collection.  The selected page can be set programmatically by using the [SelectedPage](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.SelectedPage) property.  The [SelectedIndex](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.SelectedIndex) property also can change the selected page.

## Selection Events

There are two events that are raised when selection changes occur.

The [SelectionChanging](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.SelectionChanging) event is raised immediately before a selection change occurs.  Its event arguments specify the [TabStripPage](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage) that is about to be selected.

The [SelectionChanged](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.SelectionChanged) event is raised immediately after a selection change occurs.

Alternatively, if a mouse click occurs on a tab that is already selected, the [Reselect](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.Reselect) event is raised.

## Cancelling Selection Changes

Most selection changes can be cancelled by handling the [SelectionChanging](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.SelectionChanging) event and setting its `Cancel` property to `true`.
