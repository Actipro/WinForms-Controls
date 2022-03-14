---
title: "Window Context Images"
page-title: "Window Context Images - Docking & MDI Reference"
order: 18
---
# Window Context Images

Each [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow) is capable of display a small image on its side (in addition to the normal optional image), which is used to indicate some sort of contextual status for the window's content.

![Screenshot](images/tabstrip-context-image.gif)

## Implementation Details

Commonly, the context images are used to flag read-only documents, but they can be used to show any other sort of context status as well.  It is advisable to use small images for context images, such as 12x12 pixel images.

To set a context image, set the [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow).[ContextImage](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.ContextImage) property.

Dock controls include a built-in "lock" context image that can be used for read-only documents.  The `Image` may be accessed with this code:

```csharp
documentWindow.ContextImage = 
	ActiproSoftware.Products.Docking.AssemblyInfo.Instance.Resources.GetImage(
		ActiproSoftware.Products.Docking.ImageResource.ContextReadOnly);
```
