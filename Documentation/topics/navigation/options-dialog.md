---
title: "Navigation Bar Options Dialog"
page-title: "Navigation Bar Options Dialog - Navigation Reference"
order: 4
---
# Navigation Bar Options Dialog

Navigation includes a built-in **Navigation Bar Options** dialog.

![Screenshot](images/navigationbar-options-dialog.png)

*The Navigation Bar Options dialog*

The dialog offers the end-user the ability to reorder navigation pane buttons by using the **Move Up** and **Move Down** buttons.  Navigation pane buttons can also be hidden by unchecking the button items in the list.

The **Navigation Bar Options** dialog can be displayed by using the [ShowNavigationBarOptionsForm](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBar.ShowNavigationBarOptionsForm*) method.

## Controlling Reset Button Functionality

The **Reset** button on the dialog is used to reset the panes to their original order and active state.  There are a couple properties that the dialog uses to determine how to do this.

| Member | Description |
|-----|-----|
| [DefaultActive](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane.DefaultActive) Property | Gets or sets the default value of the [Active](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane.Active) property to assign when the **Reset** button is clicked. |
| [DefaultSortOrder](xref:ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPane.DefaultSortOrder) Property | Gets or sets the sort order to use for the pane list when the **Reset** button is clicked. |
