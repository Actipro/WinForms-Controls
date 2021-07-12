---
title: "Tool Tips"
page-title: "Tool Tips - Docking & MDI Reference"
order: 13
---
# Tool Tips

Tool tips are displayed for each tool and document window when the mouse is hovered over its tab.  The tool tip uses the value of the [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow).[ToolTipText](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow.ToolTipText) property.  If this property is `null`, then no tool tip will display.

## Lazy Loading of Tool Tip Text

The Dock controls provide a mechanism for lazy-loading the tool tip text.  The [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) component raises the [WindowTabToolTipDisplaying](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.WindowTabToolTipDisplaying) event immediately before a tool tip is about to be displayed for a [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow).  The event's arguments have a property that indicates which [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow) is requesting tool tip text.
