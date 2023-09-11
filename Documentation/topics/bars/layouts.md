---
title: "Bar Layouts"
page-title: "Bar Layouts - Bars Reference"
order: 6
---
# Bar Layouts

Bar layouts can be saved to and loaded from XML.  There are two different styles of bar layouts, differential and complete.  Each is useful for different scenarios.

## Differential Layouts

Differential layouts are intended to be used once your application is deployed.  These are the type of layouts you will use most of the time since they are the preferred way to persist end user customizations from one application execution to the next.

They don't save any command information (except for customized keyboard shortcuts), and only save differential data for layouts.  The differential data is found by comparing the layout set up in the designer to the current run-time layout.

This means that the differential layout data will be very small, especially if no end user customizations have been made.

To save a differential bar layout to a file programmatically, call the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).[SaveBarLayoutToFile](xref:@ActiproUIRoot.Controls.Bars.BarManager.SaveBarLayoutToFile*) method and pass `false` for the `isComplete` parameter.

```csharp
barManager.SaveBarLayoutToFile(path, isComplete: false);
```

To load a differential bar layout from a file programmatically, call the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).[LoadBarLayoutFromFile](xref:@ActiproUIRoot.Controls.Bars.BarManager.LoadBarLayoutFromFile*) method.

```csharp
barManager.LoadBarLayoutFromFile(path);
```

To get or set a differential bar layout to the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) from an `XmlDocument`, use the [DifferentialBarLayoutData](xref:@ActiproUIRoot.Controls.Bars.BarManager.DifferentialBarLayoutData) property.  This feature allows you to store the layout data in a database or other storage mechanism and not use files.

## Complete Layouts

Complete layouts are useful for completely backing up a bar layout.  The complete layout saves all of the command definitions along with the bar control and command link layouts.  Every single non-default value is preserved.

Since this type of layout persists all of the information about commands, it is not recommended that you use this type to persist end user customizations to layouts.  Use differential layouts instead for that scenario.

The Visual Studio designer's **Save Layout to File...** action on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) saves a complete layout.  It is *highly* recommended that you periodically back up your designer bar layouts using this action.  In the unlikely event that the designer crashes and you save your form, but proper code serialization hasn't taken place, you could lose your entire command definition and bar layout.  By restoring a saved complete bar layout using the designer's **Load Layout from File...** action on the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager), you can instantly be back in business.

To save a complete bar layout to a file programmatically, call the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).[SaveBarLayoutToFile](xref:@ActiproUIRoot.Controls.Bars.BarManager.SaveBarLayoutToFile*) method and pass `true` for the `isComplete` parameter.

```csharp
barManager.SaveBarLayoutToFile(path, isComplete: true);
```

To load a complete bar layout from a file programmatically, call the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager).[LoadBarLayoutFromFile](xref:@ActiproUIRoot.Controls.Bars.BarManager.LoadBarLayoutFromFile*) method.

```csharp
barManager.LoadBarLayoutFromFile(path);
```
