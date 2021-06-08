---
title: "Working with Documents"
page-title: "Working with Documents - Docking & MDI Reference"
order: 17
---
# Working with Documents

The MDI area managed by a [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) can contain documents.

> [!IMPORTANT]
> Documents can be tool or document windows so it is important to remember that the functionality below describes any tool or document window that is active in the MDI area.

## Active Documents Collection

The [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) maintains an [ActiveDocuments](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.ActiveDocuments) collection that contains all of the active documents in the document MDI area.  This is useful for populating **Window** menus that list open documents.

When in `Tabbed` MDI mode, special code keeps the order of the documents in the collection in sync with the order in which they appear in the visual interface.  This keeps the list of documents consistent with what the end-user sees.

## Closing All Active Documents

All documents can be quickly closed by using the [CloseAllActiveDocuments](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.CloseAllActiveDocuments*) method.  The method accepts a boolean parameter indicating whether to force the closings or not.  If the closings are forced, they cannot be cancelled by handling the [WindowClosing](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.WindowClosing) event and setting its event argument's `Cancel` property to `true`.

IDEs typically provide this feature as a **Close All Documents** menu item on a **Window** menu.

## Selected Document

The currently selected window in the MDI area is available via the [SelectedDocument](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SelectedDocument) property on the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager).

If using `Tabbed` MDI mode, the [SelectedTabbedMdiContainerChanged](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SelectedTabbedMdiContainerChanged) event of the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) is raised whenever the selected tabbed MDI container is changed.

The [SelectedDocumentChanged](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SelectedDocumentChanged) event of the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) is raised whenever a new tool or document window is selected within the MDI area.
