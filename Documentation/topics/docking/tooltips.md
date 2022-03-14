---
title: "Tool Tips"
page-title: "Tool Tips - Docking & MDI Reference"
order: 13
---
# Tool Tips

Tool tips are displayed for each tool and document window when the mouse is hovered over its tab.  The tool tip uses the value of the [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow).[ToolTipText](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.ToolTipText) property.  If this property is `null`, then no tool tip will display.

## Lazy Loading of Tool Tip Text

The Dock controls provide a mechanism for lazy-loading the tool tip text.  The [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager) component raises the [WindowTabToolTipDisplaying](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowTabToolTipDisplaying) event immediately before a tool tip is about to be displayed for a [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow).  The event's arguments have a property that indicates which [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow) is requesting tool tip text.
