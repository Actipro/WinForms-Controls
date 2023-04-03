---
title: "Next Window Navigation Dialog"
page-title: "Next Window Navigation Dialog - Docking & MDI Reference"
order: 10
---
# Next Window Navigation Dialog

Dock controls was one of the first docking window suites to provide a **Next Window Navigation** dialog, and it continues to be useful today.

The **Next Window Navigation** dialog makes it easy to determine what window will be selected next by providing a high-level view of everything that is open in the dock control workspace.  The dialog grows as needed and is truly a helpful tool for window switching.

![Screenshot](images/dock-controls-next-window-navigation-dialog.gif)

*The Next Window Navigation Dialog in action*

The [NextWindowNavigationEnabled](xref:@ActiproUIRoot.Controls.Docking.DockManager.NextWindowNavigationEnabled) property controls whether the feature is enabled or not.

## Activation Keys

Several keys may be used to display the dialog:

| Key | Description |
|-----|-----|
| <kbd>Ctrl</kbd>+<kbd>Tab</kbd> | Displays the **Next Window Navigation** dialog and selects the next document window.  Hold the <kbd>Ctrl</kbd> key down to keep the dialog displayed. |
| <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>Tab</kbd> | Displays the **Next Window Navigation** dialog and selects the previous document window.  Hold the <kbd>Ctrl</kbd> key down to keep the dialog displayed. |
| <kbd>Alt</kbd>+<kbd>F7</kbd> | Displays the **Next Window Navigation** dialog and selects the next tool window.  Hold the <kbd>Alt</kbd> key down to keep the dialog displayed. |
| <kbd>Alt</kbd>+<kbd>Shift</kbd>+<kbd>F7</kbd> | Displays the **Next Window Navigation** dialog and selects the previous tool window.  Hold the <kbd>Alt</kbd> key down to keep the dialog displayed. |

## Next Window Navigation Types

There are several types of Next Window Navigation available.  The [NextWindowNavigationType](xref:@ActiproUIRoot.Controls.Docking.NextWindowNavigationType) enumeration contains the possible settings.  The value set to the [NextWindowNavigationType](xref:@ActiproUIRoot.Controls.Docking.DockManager.NextWindowNavigationType) property controls which type is active.

| Value | Description |
|-----|-----|
| `ToolAndDocumentWindow` | The Next Window Navigation will work for both tool and document windows. |
| `ToolWindow` | The Next Window Navigation will work for tool windows only. |
| `DocumentWindow` | The Next Window Navigation will work for document windows only. |

## Navigation Keys

Several keys are also valid while the **Next Window Navigation** dialog is displayed:

| Key | Description |
|-----|-----|
| <kbd>Left Arrow</kbd> | Selects the tool or document window left of the current selection in the **Next Window Navigation** dialog.  Wrapping will occur if necessary. |
| <kbd>Up Arrow</kbd> | Selects the tool or document window above the current selection in the **Next Window Navigation** dialog.  Wrapping will occur if necessary. |
| <kbd>Right Arrow</kbd> | Selects the tool or document window right of the current selection in the **Next Window Navigation** dialog.  Wrapping will occur if necessary. |
| <kbd>Down Arrow</kbd> | Selects the tool or document window below the current selection in the **Next Window Navigation** dialog.  Wrapping will occur if necessary. |

## Customizing the Selected Window's Descriptions

When a window is selected, its [TitleBarText](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.TitleBarText) property (with nullable fallback to the [Text](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow.Text) property) is displayed on the first line in the selection box.  By default, tool windows don't display any description lines.  By default, document windows display the file type ( [FileType](xref:@ActiproUIRoot.Controls.Docking.DocumentWindow.FileType) property) as the first description line and the file name ( [FileName](xref:@ActiproUIRoot.Controls.Docking.DocumentWindow.FileName) property) as the second description line.

The defaults can be customized.  By handling the [NextWindowNavigationSelectionChanged](xref:@ActiproUIRoot.Controls.Docking.DockManager.NextWindowNavigationSelectionChanged) event, you can set the various properties of the event arguments to customize the text to display on the two description lines as well as the `StringTrimming` to use for each line.  The event is raised each time a [TabbedMdiWindow](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindow) is selected in the **Next Window Navigation** dialog.
