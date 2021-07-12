---
title: "Context Images"
page-title: "Context Images - TabStrip - Docking & MDI Reference"
order: 5
---
# Context Images

Each [TabStripPage](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage) is capable of display a small image on its side (in addition to the normal optional image), which is used to indicate some sort of contextual status for the page's content.

![Screenshot](../images/tabstrip-context-image.gif)

## Implementation Details

Commonly, the context images are used to flag read-only documents, but they can be used to show any other sort of context status as well.  It is advisable to use small images for context images, such as 12x12 pixel images.

To set a context image, set the [TabStripPage](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage). [ContextImage](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPage.ContextImage) property.

Dock includes a "lock" context image that can be used for read-only documents.  The `Image` may be accessed with this code:

```csharp
tabStripPage.ContextImage = 
	ActiproSoftware.Products.Docking.AssemblyInfo.Instance.Resources.GetImage(
		ActiproSoftware.Products.Docking.ImageResource.ContextReadOnly);
```
