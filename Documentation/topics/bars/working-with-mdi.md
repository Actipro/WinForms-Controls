---
title: "Working with MDI"
page-title: "Working with MDI - Bars Reference"
order: 11
---
# Working with MDI

The bar controls have several great features for working with MDI:

- Standard MDI button control
- Flexible command link merging
- MDI window lists via expanders

## Standard MDI Button Control

When standard MDI is used in an application and a child MDI window is maximized, its system button and other buttons (minimize, restore, and close) are typically added to the main menu.  The bar controls will handle this situation and will place the appropriate buttons in the [MenuBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MenuBar) if each button is allowed to be visible.

![Screenshot](images/bar-menu-bar-docked.gif)

This table indicates the members of [BarManager](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager) that control standard MDI button visibility:

| Member | Description |
|-----|-----|
| [MdiChildCloseButtonVisible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MdiChildCloseButtonVisible) Property | Gets or sets whether maximized MDI child windows (in standard MDI mode) display a close button on the menubar. |
| [MdiChildMinimizeButtonVisible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MdiChildMinimizeButtonVisible) Property | Gets or sets whether maximized MDI child windows (in standard MDI mode) display a minimize button on the menubar. |
| [MdiChildRestoreButtonVisible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MdiChildRestoreButtonVisible) Property | Gets or sets whether maximized MDI child windows (in standard MDI mode) display a restore button on the menubar. |
| [MdiChildSystemButtonVisible](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MdiChildSystemButtonVisible) Property | Gets or sets whether maximized MDI child windows (in standard MDI mode) display a system button on the menubar.  The system button, when clicked, displays a system menu for the MDI child window. |

## Merging Command Links

The bar controls support the merging of command links from two different bar controls, often referred to as MDI merging.  However since dockable toolbars (and menubars) are lightweight elements and do not inherit from `Control`, the bar controls can't automatically merge a menubar from a child MDI windows with a menubar from a parent MDI window.  This is easily done in code though with a few lines.

This table indicates the static members of [BarManager](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager) that control merging:

| Member | Description |
|-----|-----|
| [Merge](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.Merge*) Method | Merges the source [IBarControl](xref:ActiproSoftware.UI.WinForms.Controls.Bars.IBarControl) with a target [IBarControl](xref:ActiproSoftware.UI.WinForms.Controls.Bars.IBarControl). |
| [RevertAllMerges](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.RevertAllMerges*) Method | Reverts any existing merges on the target [IBarControl](xref:ActiproSoftware.UI.WinForms.Controls.Bars.IBarControl). |
| [RevertMerge](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.RevertMerge*) Method | Reverts the merge from the source [IBarControl](xref:ActiproSoftware.UI.WinForms.Controls.Bars.IBarControl) on the target [IBarControl](xref:ActiproSoftware.UI.WinForms.Controls.Bars.IBarControl). |

This first example is useful only if standard MDI is used.  It overrides the `OnMdiChildActivate` method of the parent MDI window to add the merge code.  Assume that both the parent MDI window and the child MDI window have their own [BarManager](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager), each with a [MenuBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MenuBar) defined.  Also assume that the child MDI window is a custom type `BarMdiMergeChildForm` and that type has a `MenuBar` property exposed that provides direct access to the child MDI window's [MenuBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MenuBar).

```csharp
/// <summary>
/// Raises the <c>MdiChildActivate</c> event.
/// </summary>
/// <param name="e">Event arguments.</param>
protected override void OnMdiChildActivate(EventArgs e) {
	// Call the base method.
	base.OnMdiChildActivate(e);

	// Merge or revert merge
	if (this.ActiveMdiChild is BarMdiMergeChildForm) {
		BarMdiMergeChildForm childForm = (BarMdiMergeChildForm)this.ActiveMdiChild;
		BarManager.Merge(childForm.MenuBar, barManager.MenuBar, true);
	}
	else
		BarManager.RevertAllMerges(barManager.MenuBar);
}
```

This second example is useful only if Actipro Docking & MDI controls are being used for MDI.  It handles the [SelectedDocumentChanged](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager.SelectedDocumentChanged) event of the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager) and performs the merge there.  Assume that both the parent `Form` and the document window have their own [BarManager](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager), each with a [MenuBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MenuBar) defined.  Also assume that the document window is a custom type `MdiMergeDocumentWindow` and that type has a `MenuBar` property exposed that provides direct access to the document window's [MenuBar](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.MenuBar).

```csharp
/// <summary>
/// Occurs when the selected document is changed.
/// </summary>
/// <param name="sender">Sender of the event.</param>
/// <param name="e">Event arguments.</param>
protected override void dockManager_SelectedDocumentChanged(object sender, EventArgs e) {
	// Merge or revert merge
	if (dockManager.SelectedDocument is MdiMergeDocumentWindow) {
		MdiMergeDocumentWindow documentWindow = (MdiMergeDocumentWindow)dockManager.SelectedDocument;
		BarManager.Merge(documentWindow.MenuBar, barManager.MenuBar, true);
	}
	else
		BarManager.RevertAllMerges(barManager.MenuBar);
}
```

## Choosing Which Command Links to Merge

Each command link has a couple properties that govern how it is merged with another bar control.

The [MergeAction](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.MergeAction) is the primary controller for how merging occurs.  It is of the enumeration type [BarMergeAction](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarMergeAction), which has these values:

| Value | Description |
|-----|-----|
| `Append` | Appends the command link to the end of the target command links collection. |
| `Insert` | Inserts the command link before the matched command link. |
| `InsertAfter` | Inserts the command link after the matched command link. |
| `MatchOnly` | A match is required, but no action is taken.  Use this for tree creation and successful access to nested layouts. |
| `Remove` | If the command link is on the source, the matched command link on the target is removed and the source command link is not merged.  If the command link is on the target, the command link is removed. |
| `Replace` | Replaces the matched command link with the source command link.  The original command link's drop-down command links do not become children of the incoming command link. |

"Matching" of command links is done by comparing each command link's merge key.  The resolved merge key defaults to the command's full name, unless the [MergeKey](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.MergeKey) property overrides it.  If the command link is a merge source command link, the resolved merge key looks for a match on the target command link collection.  If the command link is a merge target command link, the resolved merge key is used for matching against source command links.

Therefore if you wished to insert a `File.Save` source command link before a `File.Exit` target command link, you'd set the source command link's [MergeAction](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.MergeAction) property to `BarMergeAction.Insert` and the source command link's [MergeKey](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLink.MergeKey) property to `File.Exit`.

## MDI Window List

The [BarExpanderButtonCommand](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarExpanderButtonCommand) is capable of dynamically populating child command links.  One of the built-in automatic population styles is `BarExpanderButtonCommandPopulationStyle.StandardMdiWindowList`.  This value can be set to the [PopulationStyle](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarExpanderButtonCommand.PopulationStyle) property.  When set, the expander will automatically list any standard MDI windows in the `Form` containing the host container control.  Note that this only works for standard MDI mode.

Since tabbed MDI (an advanced option provided by our Docking & MDI controls) does not have native support in Windows Forms, listing MDI windows in that mode is a little more complex, but can still be done using expanders.  Leave the population style of the expander as `BarExpanderButtonCommandPopulationStyle.Custom` and handle the [CommandPopup](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.CommandPopup) event.  This event is raised for expanders whenever they are clicked (on a toolbar) or before they are displayed (on a menu), allowing you to update the child command links.

In that event you simply clear any existing child command links, and add one command link for each [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow) in the [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager).  Set the reference to the [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow) in the `Tag` property of each command link.  This code illustrates how to implement this feature and even shows asterisks for modified documents from within the event handler:

```csharp
switch (e.Command.FullName) {
	case "Window.WindowList": {
		// Populate the command with the list of open windows
		BarExpanderButtonCommand command = (BarExpanderButtonCommand)e.Command;
		command.CommandLinks.Clear();
		foreach (TabbedMdiWindow tabbedMdiWindow in dockManager.ActiveDocuments) {
			string text = tabbedMdiWindow.Text;
			DocumentWindow documentWindow = tabbedMdiWindow as DocumentWindow;
			if (documentWindow != null)
				text = documentWindow.FileName + (documentWindow.Modified ? "*" : String.Empty);
			BarButtonLink commandLink = new BarButtonLink("WindowActivate", String.Empty, text,
				tabbedMdiWindow.ImageIndex, true, true, (dockManager.SelectedDocument == tabbedMdiWindow), false);
			commandLink.Command.Tag = tabbedMdiWindow;
			command.CommandLinks.Add(commandLink);
		}
		break;
	}
}
```

Then the next step is to handle the [CommandClick](xref:ActiproSoftware.UI.WinForms.Controls.Bars.BarManager.CommandClick) event to process the window activation.  This code shows how to activate a [TabbedMdiWindow](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow) from within the event handler:

```csharp
if (e.Command.Category == "WindowActivate") {
	// Activate the TabbedMdiWindow in the Tag
	((TabbedMdiWindow)e.Command.Tag).Activate();
	return;
}
```

After implementing those events, both standard and tabbed MDI are supported in a window list expander item when using a [DockManager](xref:ActiproSoftware.UI.WinForms.Controls.Docking.DockManager).
