---
title: "Print Options"
page-title: "Print Options - SyntaxEditor Printing Features"
order: 3
---
# Print Options

There are a large number of options available that affect how printouts render.

## Accessing Print Settings

The [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings) interface contains all the options that relate to printing.  The print settings are accessed via the [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor).[PrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor.PrintSettings) property.

## The Document Title

The document title can optionally be displayed at the top of each page in a printer view.  It is visible when the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[DocumentTitle](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.DocumentTitle) property is non-null and the [IsDocumentTitleMarginVisible](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.IsDocumentTitleMarginVisible) property is `true`, which is the default.

This code sets the document title that is displayed at the top of each page:

```csharp
editor.PrintSettings.DocumentTitle = "My Document";
```

## Turning Off Syntax Highlighting

Syntax highlighting is on by default for printer views.  To turn it off and make text black and white, set the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[IsSyntaxHighlightingEnabled](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.IsSyntaxHighlightingEnabled) property is set to `false`.

## Using a Custom Highlighting Style Registry

When syntax highlighting is on for printer views, it will use the [IHighlightingStyleRegistry](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry) that is currently active in the editor.  However when the editor is using a dark theme, this is not a desirable registry to use for printouts.

A [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[HighlightingStyleRegistry](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.HighlightingStyleRegistry) property can be set to a custom [IHighlightingStyleRegistry](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry) instance that will be used for printer output only, and is ideally set up with darker foreground colors and no backgrounds.

See the [Highlighting Style Registries](../styles/highlighting-style-registries.md) topic for more information on highlighting style registries.

## Displaying Whitespace

Tabs and spaces can be visually displayed when the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[IsWhitespaceVisible](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.IsWhitespaceVisible) property is set to `true`.  The default is to not show whitespace.

## Allowing Collapsed Outlining Nodes

Collapsed outlining nodes are automatically expanded in printer views when the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[AreCollapsedOutliningNodesAllowed](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.AreCollapsedOutliningNodesAllowed) property is set to `false`, which is the default value.  Set the property to `true` to allow currently-collapsed outlining nodes in the document to render as collapsed in the printer view.

## Displaying Indentation Guides

Indentation guides can be rendered when the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[AreIndentationGuidesVisible](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.AreIndentationGuidesVisible) property is set to `true`.  The default is to not show indentation guides.

## Displaying Squiggle Lines

Squiggle lines, such as those that mark syntax errors, can be rendered when the [IPrintSettings](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings).[AreSquiggleLinesVisible](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IPrintSettings.AreSquiggleLinesVisible) property is set to `true`.  The default is to not show squiggle lines.
