---
title: "Tab Overflow Styles"
page-title: "Tab Overflow Styles - TabStrip - Docking & MDI Reference"
order: 3
---
# Tab Overflow Styles

The [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip) control has multiple ways to handle tabs that do not fit within the client area.  The three options for tab overflow are:

| Value | Description |
|-----|-----|
| `None` | No special handling occurs other than always ensuring that the selected tab is visible. |
| `ShrinkToFit` | All the tabs are shrunk in size, if necessary, to make them fit in the bounds of the control. |
| `ScrollButtons` | Scroll buttons are displayed allowing for smooth scrolling of the tabs. |

The smooth scrolling feature actually slides the tabs using animation while the scroll button is pressed.

![Screenshot](../images/tabstrip-tab-overflow-style-none.gif)

*TabStrip with no tab overflow handling*

![Screenshot](../images/tabstrip-tab-overflow-style-shrink-to-fit.gif)

*TabStrip with shrink-to-fit tab overflow handling*

![Screenshot](../images/tabstrip-tab-overflow-style-scroll-buttons.gif)

*TabStrip with smooth scroll buttons for tab overflow handling*

## Changing the Tab Overflow Style

To change the overflow style of tabs in a [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip), change the value of the [TabOverflowStyle](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip.TabOverflowStyle) property.  It uses a [TabStripTabOverflowStyle](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStripTabOverflowStyle) enumeration value.
