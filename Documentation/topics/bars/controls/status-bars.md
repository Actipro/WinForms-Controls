---
title: "Statusbars"
page-title: "Statusbars - Bars Control Types Reference"
order: 5
---
# Statusbars

Statusbars, represented by the [StatusBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBar) class, provide a powerful alternative to the Windows Forms `StatusBar` class.

![Screenshot](../images/bar-status-bar.gif)

In addition to customizable rendering, the Bars statusbar supports several panels types, each with many features.

## Gripper Visibility

The [GripperVisible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBar.GripperVisible) property on the [StatusBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBar) class controls whether the gripper is visible on the statusbar.  If set to `true`, the gripper will be visible.  A value of `false` hides the gripper.

## Modifying Child Panels

The [Panels](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBar.Panels) collection stores all of the panels that are contained by the statusbar.  To programmatically add a new panel to the statusbar, simply add it to collection.  The collection can be edited in the designer to add and configure new panels as well.

## Statusbar Panels

Each panel class inherits from the [StatusBarPanel](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel) class.  This class provides a number of properties that are common to all panels:

| Member | Description |
|-----|-----|
| [AutoSize](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.AutoSize) Property | Gets or sets the auto-size style to apply to the panel. |
| [BackgroundFill](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.BackgroundFill) Property | Gets or sets the `BackgroundFill` to use for the background of the panel. |
| [Border](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.Border) Property | Gets or sets a `SimpleBorder` that indicates the type of border for the panel. |
| [Key](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.Key) Property | Gets or sets the key of the panel. |
| [MinimumWidth](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.MinimumWidth) Property | Gets or sets the minimum width for the panel. |
| [Padding](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.Padding) Property | Gets or sets a `Padding` that describes the padding of the panel. |
| [ToolTipText](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.ToolTipText) Property | Gets or sets the tool tip text for the panel. |
| [Visible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.Visible) Property | Gets or sets whether the panel is visible. |
| [Width](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.Width) Property | Gets or sets the width of the panel. |
| [AutoSize](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanel.AutoSize) Property | Gets or sets the auto-size style to apply to the panel. |

## Statusbar Label Panels

The [StatusBarLabelPanel](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel) class provides a panel that can display images and text in various formats.  It has these important properties:

| Member | Description |
|-----|-----|
| [Enabled](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.Enabled) Property | Gets or sets whether the panel is enabled. |
| [ForeColor](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.ForeColor) Property | Gets or sets the `Color` to use for drawing the text. |
| [HorizontalAlignment](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.HorizontalAlignment) Property | Gets or sets the horizontal alignment of text in the panel. |
| [Image](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.Image) Property | Gets or sets the image that is displayed for the panel. |
| [ImageIndex](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.ImageIndex) Property | Gets or sets the index of an image within an `ImageList` that is displayed on the panel. |
| [ImageLayoutStyle](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.ImageLayoutStyle) Property | Gets or sets the layout style of the panel's image in relation to the text. |
| [ImageSizeToFit](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.ImageSizeToFit) Property | Gets or sets whether to size the panel's image to fit in the panel. |
| [IsLink](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.IsLink) Property | Gets or sets whether the panel is a link. |
| [LinkBehavior](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.LinkBehavior) Property | Gets or sets the link behavior. |
| [LinkVisited](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.LinkVisited) Property | Gets or sets whether the link has been visited. |
| [Text](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.Text) Property | Gets or sets the text to display in the panel. |
| [TextTrimming](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarLabelPanel.TextTrimming) Property | Gets or sets the `StringTrimming` to use for text in the panel. |

## Statusbar Progressbar Panels

The [StatusBarProgressBarPanel](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel) class provides a panel that can display progressbars.  It has these important properties:

| Member | Description |
|-----|-----|
| [Increment](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Increment*) Method | Advances the current value of the progress bar by the specified amount. |
| [Maximum](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Maximum) Property | Gets or sets the upper bound of the range that is defined for this progress bar. |
| [Minimum](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Minimum) Property | Gets or sets the lower bound of the range that is defined for this progress bar. |
| [PerformStep](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.PerformStep*) Method | Advances the current position of the progress bar by the amount of the [Step](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Step) property. |
| [Step](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Step) Property | Gets or sets the amount by which a call to the [PerformStep](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.PerformStep*) method increases the current position of the progress bar. |
| [Style](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Style) Property | Gets or sets the [StatusBarProgressBarPanelStyle](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanelStyle) that indicates how the progress bar should indicate status. |
| [Text](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Text) Property | Gets or sets the text to display in the panel. |
| [TextTrimming](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.TextTrimming) Property | Gets or sets the `StringTrimming` to use for text in the panel. |
| [Value](xref:ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarProgressBarPanel.Value) Property | Gets or sets the current value of this progress bar. |
