---
title: "Edit Actions"
page-title: "Edit Actions - SyntaxEditor Input/Output Features"
order: 5
---
# Edit Actions

Edit actions are classes that implement [IEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditAction) and contain code to perform different simple tasks related to a [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor).  They are effectively commands with can-execute and executed handlers that perform all the work.

## Edit Actions and Commands

SyntaxEditor includes over 100 unique edit actions, covering everything such as movements, selection types, clipboard operations, and more.

The built-in edit actions are all located in the [ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions) namespace.

All commands related to the built-in edit actions are available via static properties on the [EditorCommands](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorCommands) class.

## Executing Edit Actions

To execute an edit action, use the [IEditorView](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView).[ExecuteEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView.ExecuteEditAction*) method.  Simply pass it an instance of the [IEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditAction) to execute.

This code shows how to execute an [IndentAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.IndentAction) on the active view:

```csharp
editor.ActiveView.ExecuteEditAction(new IndentAction());
```

Most of the edit action classes defined by SyntaxEditor also have helper methods which make running the edit actions easier.  or instance, the [IEditorViewSelection](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorViewSelection) interface has a method [SelectAll](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorViewSelection.SelectAll*), which runs the [SelectAllAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectAllAction).  Another example is the [IEditorView](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView) interface has a method [CopyToClipboard](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView.CopyToClipboard*), which runs the [CopyToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CopyToClipboardAction).

## Canceling an Edit Action

The [IEditorView](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView).[ExecuteEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView.ExecuteEditAction*) method immediately raises the [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor).[ViewActionExecuting](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor.ViewActionExecuting) event, which is passed an [EditActionEventArgs](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActionEventArgs) that specifies the [IEditorView](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditorView) and [IEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditAction) being executed.  The event args has a `Cancel` property that can be set to `true` to prevent the edit action from executing.  This provides a way for certain edit actions to be externally filtered out if desired.

## Creating a Custom Edit Action

Custom edit action classes may be defined.  The only requirement is that they implement [IEditAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IEditAction).  When defining an edit action, it's easiest to inherit [EditActionBase](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation.EditActionBase).

This code shows how to define an edit action that surrounds the selected text with `custom` tags.

```csharp
/// <summary>
/// Provides a custom <see cref="IEditAction"/> implementation that inserts a 
/// <c>custom</c> tag surrounding the selected text.
/// </summary>
public class CustomAction : ActiproSoftware.Windows.Controls.SyntaxEditor.Implementation.EditActionBase {
	
	/// <summary>
	/// Initializes an instance of the <c>CustomAction</c> class.
	/// </summary>
	public CustomAction() : base("Custom") {}
	
	/// <summary>
	/// Executes the edit action in the specified <see cref="IEditorView"/>.
	/// </summary>
	/// <param name="view">The <see cref="IEditorView"/> in which to execute the edit action.</param>
	public override void Execute(IEditorView view) {
		view.InsertSurroundingText("<custom>", "</custom>");
	}
	
}
```
