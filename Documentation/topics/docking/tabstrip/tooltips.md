---
title: "Tool Tips"
page-title: "Tool Tips - TabStrip - Docking & MDI Reference"
order: 6
---
# Tool Tips

The [TabStrip](xref:@ActiproUIRoot.Controls.Docking.TabStrip) control allows tool tips to be displayed for each tab.

Whenever the mouse is hovered over a tab, a tool tip will display using the text contained in the corresponding [TabStripPage](xref:@ActiproUIRoot.Controls.Docking.TabStripPage).[ToolTipText](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.ToolTipText) property.  If this property is `null`, then no tool tip will display.

## Lazy Loading of Tool Tip Text

The [TabStrip](xref:@ActiproUIRoot.Controls.Docking.TabStrip) control raises the [TabStripPageTabToolTipDisplaying](xref:@ActiproUIRoot.Controls.Docking.TabStrip.TabStripPageTabToolTipDisplaying) event immediately before displaying a tool tip.  That event provides the opportunity to lazy load the [ToolTipText](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.ToolTipText) property of the page for which the tool tip is about to display.  The event's arguments have a property that indicates which page is requesting tool tip text.
