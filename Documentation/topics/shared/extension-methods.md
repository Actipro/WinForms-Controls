---
title: "Extension Methods"
page-title: "Extension Methods - Shared Library Reference"
order: 13
---
# Extension Methods

Various extension methods are provided for several common .NET types.

> [!IMPORTANT]
> The `ActiproSoftware.Windows.Controls.Extensions` namespace must be imported for the extensions described below to be available.

> [!TIP]
> The Core Library defines many additional [Extension Methods](../core/extension-methods.md) for common types that are not associated with a UI framework.

## Control Extensions

The [ControlExtensions](xref:@ActiproUIRoot.Controls.Extensions.ControlExtensions) type contains extension methods for the `Control` type.  Some of the most frequently used extension methods are highlighted below.  Refer to the API documentation for additional methods.

| Member | Description |
|-----|-----|
| [FindAncestorOfType&lt;T&gt;](xref:@ActiproUIRoot.Controls.Extensions.ControlExtensions.FindAncestorOfType*) | Finds the first ancestor of the given type in the logical tree. |
| [FindDescendantOfType&lt;T&gt;](xref:@ActiproUIRoot.Controls.Extensions.ControlExtensions.FindDescendantOfType*) | Finds the first descendant of the given type in the logical tree. |
| [GetAncestors](xref:@ActiproUIRoot.Controls.Extensions.ControlExtensions.GetAncestors*) | Enumerates the ancestors of an object in the logical tree and can be easily combined with LINQ queries. |
| [GetDescendants](xref:@ActiproUIRoot.Controls.Extensions.ControlExtensions.GetDescendants*) | Enumerates the descendants of an object in the logical tree and can be easily combined with LINQ queries. |

## ILogicalTreeNode Extensions

The [ILogicalTreeNodeExtensions](xref:@ActiproUIRoot.Controls.Extensions.ILogicalTreeNodeExtensions) type contains extension methods for the [ILogicalTreeNode](xref:@ActiproUIRoot.ILogicalTreeNode) interface that is utilized by many Actipro controls to compose the individual elements of a control.  Some of the most frequently used extension methods are highlighted below.  Refer to the API documentation for additional methods.

| Member | Description |
|-----|-----|
| [FindLogicalAncestorOfType&lt;T&gt;](xref:@ActiproUIRoot.Controls.Extensions.ILogicalTreeNodeExtensions.FindLogicalAncestorOfType*) | Finds the first ancestor of the given type in the visual tree. |
| [FindLogicalDescendantOfType&lt;T&gt;](xref:@ActiproUIRoot.Controls.Extensions.ILogicalTreeNodeExtensions.FindLogicalDescendantOfType*) | Finds the first descendant of the given type in the visual tree. |
| [GetLogicalAncestors](xref:@ActiproUIRoot.Controls.Extensions.ILogicalTreeNodeExtensions.GetLogicalAncestors*) | Enumerates the ancestors of a visual in the visual tree and can be easily combined with LINQ queries. |
| [GetLogicalDescendants](xref:@ActiproUIRoot.Controls.Extensions.ILogicalTreeNodeExtensions.GetLogicalDescendants*) | Enumerates the descendants of a visual in the visual tree and can be easily combined with LINQ queries. |
