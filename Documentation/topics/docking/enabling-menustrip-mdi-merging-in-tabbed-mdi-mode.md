---
title: "Enabling MenuStrip MDI Merging in Tabbed MDI Mode"
page-title: "Enabling MenuStrip MDI Merging in Tabbed MDI Mode - Docking & MDI Reference"
order: 21
---
# Enabling MenuStrip MDI Merging in Tabbed MDI Mode

By default, Dock supports MDI menu merging only in standard MDI mode. Since the .NET `MenuStrip` control supports ways to manually merge menus, you can also integrate MDI menu merging in tabbed MDI mode.

This code demonstrates how to support `MenuStrip` MDI merging in tabbed MDI mode:

```csharp
/// <summary>
/// Occurs when the value of the <see cref="SelectedDocument"/> property changes.
/// </summary>
/// <param name="sender">Sender of the event.</param>
/// <param name="e">Event arguments.</param>
private void dockManager_SelectedDocumentChanged(object sender, TabbedMdiWindowEventArgs e) {
	// Since automated MDI menu merging doesn't occur for MenuStrips unless in standard MDI mode,
	//   if we are in tabbed MDI mode, we must manually merge the child MenuStrip
	if (dockManager.DocumentMdiStyle == DocumentMdiStyle.Tabbed) {
		// Revert any currently merged MenuStrip
		ToolStripManager.RevertMerge(mdiParentMenuStrip);

		// If a new document is selected...
		if (e.TabbedMdiWindow != null) {
			// Try to find a MenuStrip and merge it
			MenuStrip menuStrip = this.FindMergableMenuStrip(e.TabbedMdiWindow);
			if (menuStrip != null)
				ToolStripManager.Merge(menuStrip, mdiParentMenuStrip);
		}
	}
}

/// <summary>
/// Recursively looks for a mergable <c>MenuStrip</c>.
/// </summary>
/// <param name="parentControl">The parent <c>Control</c> to search.</param>
/// <returns>The <c>MenuStrip</c> that was found, if any.</returns>
private MenuStrip FindMergableMenuStrip(Control parentControl) {
	foreach (Control control in parentControl.Controls) {
		if (control is MenuStrip) {
			if (((MenuStrip)control).AllowMerge)
				return (MenuStrip)control;
		}				
		if (control.HasChildren) {
			MenuStrip menuStrip = this.FindMergableMenuStrip(control);
			if (menuStrip != null)
				return menuStrip;
		}
	}
	return null;
}
```
