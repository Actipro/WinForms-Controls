---
title: "Converting to v22.1"
page-title: "Converting to v22.1 - Conversion Notes"
order: 8
---
# Converting to v22.1

All of the breaking changes are detailed or linked below.

## SyntaxEditor Drag and Drop Updates

The [Drag and Drop](../syntaxeditor/user-interface/input-output/drag-drop.md) functionality has been enhanced to provide more control over the experience.

Previously, any non-`null` value assigned to the [PasteDragDropEventArgs](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.PasteDragDropEventArgs).[Text](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.PasteDragDropEventArgs.Text) property within a handler for the [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor).[PasteDragDrop](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor.PasteDragDrop) event would indicate that drag-and-drop was allowed, but this limited advanced scenarios such as drag-and-drop with custom objects or dropping onto read-only documents.  Going forward, the accepted operation assigned through [PasteDragDropEventArgs](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.PasteDragDropEventArgs).[DragEventArgs](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.PasteDragDropEventArgs.DragEventArgs) will be used to indicate `Copy`, `Move`, or `None` operations. Refer to the [Drag and Drop](../syntaxeditor/user-interface/input-output/drag-drop.md) topic for details on customizing drag operations.

## SyntaxEditor Tagging Updates

Previously, any [ITagger<T>](xref:ActiproSoftware.Text.Tagging.ITagger`1) which implemented the `IDisposable` interface would be disposed when detached from an instance of the [TagAggregatorBase<T>](xref:ActiproSoftware.Text.Tagging.TagAggregatorBase`1) class.  Since taggers are frequently reused, this could lead to issues if the tagger was accessed after it was disposed.

New [ITaggerBase](xref:ActiproSoftware.Text.Tagging.ITaggerBase).[NotifyTagAggregatorAttached](xref:ActiproSoftware.Text.Tagging.ITaggerBase.NotifyTagAggregatorAttached*) and [ITaggerBase](xref:ActiproSoftware.Text.Tagging.ITaggerBase).[NotifyTagAggregatorDetached](xref:ActiproSoftware.Text.Tagging.ITaggerBase.NotifyTagAggregatorDetached*) methods have been added for more granular control over the lifecycle of a tagger. Taggers which derive from [TaggerBase<T>](xref:ActiproSoftware.Text.Tagging.Implementation.TaggerBase`1) can override the [OnTagAggregatorAttached](xref:ActiproSoftware.Text.Tagging.Implementation.TaggerBase`1.OnTagAggregatorAttached*) and [OnTagAggregatorDetached](xref:ActiproSoftware.Text.Tagging.Implementation.TaggerBase`1.OnTagAggregatorDetached*) methods to respond to these notifications and more accurately determine if/when a tagger should be disposed.

The following changes were made to tagging-related interfaces:

- New [ITaggerBase](xref:ActiproSoftware.Text.Tagging.ITaggerBase) interface added which is implemented by [ITagger<T>](xref:ActiproSoftware.Text.Tagging.ITagger`1).
- The `Close` method, `Closed` event, and `TagsChanged` event were moved from [ITagger<T>](xref:ActiproSoftware.Text.Tagging.ITagger`1) to [ITaggerBase](xref:ActiproSoftware.Text.Tagging.ITaggerBase).
- New [ITagAggregatorBase](xref:ActiproSoftware.Text.Tagging.ITagAggregatorBase) interface added which is implemented by [ITagAggregator<T>](xref:ActiproSoftware.Text.Tagging.ITagAggregator`1).
- The `TagsChanged` event was moved from [ITagAggregator<T>](xref:ActiproSoftware.Text.Tagging.ITagAggregator`1) to [ITagAggregatorBase](xref:ActiproSoftware.Text.Tagging.ITagAggregatorBase).

## SyntaxEditor Python Language Add-on Updates

The [Python](../syntaxeditor/python-language-addon/python/index.md) parser grammar has been updated to support v3.9.5 syntax.

Python v2.x has been officially end of life for some time now, so we removed support for it.  The `PythonVersion` enum was removed, and all APIs that had a `PythonVersion` parameter have had that parameter removed.

## SyntaxEditor .NET Languages Add-on Updates

The [C#](../syntaxeditor/dotnet-languages-addon/csharp/index.md) parser grammar has been updated to support v8.0 syntax.
