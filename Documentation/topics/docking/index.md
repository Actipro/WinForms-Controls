---
title: "Overview"
page-title: "Docking & MDI Reference"
order: 1
---
# Overview

Actipro Docking & MDI contains our next generation of docking controls, which provides the latest functionality found in Visual Studio.  At the core of this functionality are [tool windows](tool-windows.md), which act as containers for other child controls.  Tool windows can be dragged and docked on any side of the host container, [nested in hierarchies](complex-hierarchies.md) or floated in their own `Form` window.  Additionally they can be collapsed into [auto-hide](auto-hide.md) mode and hidden, or moved to the MDI area.

Another important piece of the dock control system is the MDI support.  The dock controls two types of MDI, standard and tabbed.  Tabbed MDI allows you to drag tabs of documents to create new tab groups.  It maximizes workspace real estate and is simple for end-users to manipulate.  Switching between MDI modes is done with a single command and can be done at run-time.  The dock controls support the ability to not have an MDI at all and place any sort of control in the inner workspace area.  The dock controls also support [tool window inner-fill](tool-window-inner-fill.md), in which there are no documents and tool windows fill the entire space within the host container control.

The dock controls have [designer support](designer-support.md) which lets you manipulate the dock controls in the designer and serialize the layout to code for when the application is executed in run-time mode.

Tool window layouts can be serialized to a file or stream and later reloaded to restore all the same tool window docking states.

![Screenshot](images/dock-controls-visual-studio-2005-blue.gif)

*Dock controls in the Visual Studio 2005 theme*

Out of the box, the dock controls have [rendering capabilities](extensible-rendering.md) that mimic Visual Studio 2005, Visual Studio 2002, and Office tool and document window styles.  The dock controls even support the [Next Window Navigation](next-window-navigation.md) dialog.

## Feature List

- Built-in rendering styles include Metro Light, Visual Studio 2005/2002, and all Office 2007/2003 styles.
- Robust rendering interface allows for totally [customized rendering](extensible-rendering.md).
- Dock [tool windows](tool-windows.md) on all sides of a central client area.
- Multiple styles of docking guides which easily control drop locations.
- Multiple styles of drop-target hints, including translucent regions and rubber bands.
- Supports complex [nested hierarchies](complex-hierarchies.md) of tool windows that can be resized with splitters.
- Attach several tool windows in one container, displayed with tabs.
- Tear off tool windows into floating windows.
- Dock tool windows in any combination within floating forms.
- Place tool windows in collapsible [auto-hide](auto-hide.md) mode to preserve client area real estate.
- Show and hide tool windows.
- [Tool window inner-fill](tool-window-inner-fill.md) mode.
- Dragging undocked tool windows can snap next to other undocked tool windows using [magnetism](magnetism.md) features.  Also works for documents in standard MDI mode.
- Global defaults for tool window capability control (`CanAttach`, `CanDrag`, `CanFloat`, etc.).
- Extremely granular control over exactly what each tool window can do (`CanDockLeft`, `CanAutoHide`, `CanClose`, etc.) and how it appears (`TitleBarText`, `ImageIndex`, `HasTitleBar`, `HasOptions`, etc.).
- Load and save tool window layouts directly to XML data files or persist layout data in some other media, such as a database.
- Dynamically read and write custom XML data to layout data.
- Instantly switch between window layouts - useful for IDEs when state switching occurs between design-time and run-time modes.
- Option to turn off MDI so that a single control can be used to fill the client area.
- Two styles of MDI - standard and tabbed.
- [Standard MDI](standard-mdi.md) allows for normal MDI windows that can be tiled and cascaded.
- [Tabbed MDI](tabbed-mdi.md) has tabstrips that allow for selection of the current document.
- Tabbed MDI tabs can be dragged to create new horizontal or vertical tab groups.
- Tabbed MDI tabs can be floated to top-level windows.
- Tabbed MDI containers can display a drop-down list of active documents and/or use scroll buttons to smoothly scroll through tabs that are out of view.
- [Document windows](document-windows.md) track modified states and reflect them in the user interface.
- `Ctrl+Tab` tool and document switching with the optional [Next Window Navigation](next-window-navigation.md) dialog.
- Ability to cancel the closing of tool and document windows.
- Option to hide document tabs if there is only one document open.
- Programmatically dock all tool windows anywhere in the layout and move/resize floating tool windows at run-time.
- Dynamically create new tool windows and document windows.
- Tool and document windows automatically select when a drag/drop operation is moved over them.
- Built-in default context menus that may be cancelled to provide custom menus.
- Detailed event model.
- Full [designer support](designer-support.md) for codeless layout design.
- [Tool Windows](designer-support.md) dialog available in designer to aid in locating and manipulating tool windows.
