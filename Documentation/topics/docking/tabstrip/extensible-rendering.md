---
title: "Extensible Rendering"
page-title: "Extensible Rendering - TabStrip - Docking & MDI Reference"
order: 9
---
# Extensible Rendering

[TabStrip](xref:@ActiproUIRoot.Controls.Docking.TabStrip) uses an extensible rendering model that is based on our common object model.  The object model centers around the use of a renderer class.  The renderer measures and draws all of the elements within the control.  This is a great design because it allows you to use our pre-defined renderers or create your own.

This object model allows for three levels of rendering customization.  Choose which level of customization you wish to use:

- Use Built-In Renderers As-Is - Use the built-in rendering styles without any changes, which include several Metro, Visual Studio, and Office styles for tool/document windows.
- Modify Properties on Built-In Renderers - Use the built-in renderers but modify the various properties on the renderers to easily create a customized appearance.
- Create Custom Renderers - Implement the [ITabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.ITabStripRenderer) interface or inherit our [TabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.TabStripRenderer) class to do all the measuring and drawing of the controls and their elements yourself.

These are some sample rendering styles that come with [TabStrip](xref:@ActiproUIRoot.Controls.Docking.TabStrip):

![Screenshot](../images/tabstrip-visual-studio-2005-tool-window.gif)

![Screenshot](../images/tabstrip-visual-studio-2005-document-window.gif)

![Screenshot](../images/tabstrip-visual-studio-2002-tool-window.gif)

![Screenshot](../images/tabstrip-visual-studio-2002-document-window.gif)

![Screenshot](../images/tabstrip-office-2003-tool-window.gif)

![Screenshot](../images/tabstrip-office-2003-document-window.gif)

## Use Built-In Renderers As-Is

Dock includes these built-in renderers:

| Renderer | Description |
|-----|-----|
| [MetroToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.MetroToolWindowTabStripRenderer) | Capable of drawing a Metro styles (Light and Dark) for a tool window.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Docking.MetroToolWindowTabStripRenderer.BaseColorSchemeType). |
| [MetroDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.MetroDocumentWindowTabStripRenderer) | Capable of drawing a Metro styles (Light and Dark) for document window.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Docking.MetroDocumentWindowTabStripRenderer.BaseColorSchemeType). |
| [OfficeClassicToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicToolWindowTabStripRenderer) | Capable of drawing all Office classic styles (Blue, Black, Silver), Luna styles (Blue, Olive Green, Silver), and Windows Classic for a tool window.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicToolWindowTabStripRenderer.BaseColorSchemeType). |
| [OfficeClassicDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer) | Capable of drawing all Office classic styles (Blue, Black, Silver), Luna styles (Blue, Olive Green, Silver), and Windows Classic for a document window.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer.BaseColorSchemeType). |
| [VisualStudioToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.VisualStudioToolWindowTabStripRenderer) | Capable of drawing a Visual Studio tool window. |
| [VisualStudioDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.VisualStudioDocumentWindowTabStripRenderer) | Capable of drawing a Visual Studio document window. |
| [VisualStudioClassicToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.VisualStudioClassicToolWindowTabStripRenderer) | Capable of drawing a Visual Studio classic tool window. |
| [VisualStudioClassicDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.VisualStudioClassicDocumentWindowTabStripRenderer) | Capable of drawing a Visual Studio classic document window. |
| [WindowsClassicToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.WindowsClassicToolWindowTabStripRenderer) | Capable of drawing a Windows classic tool window. |
| [WindowsClassicDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.WindowsClassicDocumentWindowTabStripRenderer) | Capable of drawing a Windows classic document window. |


## Color Tinting Color Schemes

With one line of code, any `WindowsColorScheme` can be tinted so that all of the colors are altered.  For instance, you can easily create a custom color scheme and then use those color schemes with the [OfficeClassicDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer) and [OfficeClassicToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.OfficeClassicToolWindowTabStripRenderer) classes.

This code shows how to load a custom purple-tinted color scheme that is based on the built-in Luna blue theme:

```csharp
var scheme = new WindowsColorScheme("Purple", WindowsColorSchemeType.LunaBlue, Color.Purple);
tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(scheme);
```

## Customizing Specific Colors in a Color Scheme

Each color property on the `WindowsColorScheme` class has a getter and setter.  This means that after a base color scheme is selected for use, you may alter specific colors as needed.

This code shows how to change the background of menus to be `LightBlue` for the built-in Windows Classic color scheme.

```csharp
WindowsColorScheme.WindowsClassic.MenuBack = Color.LightBlue;
```

> [!NOTE]
> Any renderers created before the color settings were changed may need to be refreshed for the color changes to take effect in the renderer.

## Modify Properties on Built-In Renderers

Select a base built-in renderer to use by following the steps above.  Then use the designer to change its properties.  You can change fonts, colors, backgrounds, measuring parameters, etc.  Our built-in renderers give you a lot of options that you can use to customize the look and feel of the controls.

## Create Custom Renderers

For the most flexibility over what is measured and rendered, create a class that implements the [ITabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.ITabStripRenderer) interface.  Alternatively, you can create a class that inherits our [TabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.TabStripRenderer) or one of its descendants.  The renderer interface has methods that measure and draw the controls and their elements.

After your custom renderer class has been created, assign it to the [Renderer](xref:@ActiproUIRoot.Controls.Docking.TabStrip.Renderer) property of each [TabStrip](xref:@ActiproUIRoot.Controls.Docking.TabStrip) that should use it for drawing.

## Customizing Individual Tab Pages

Renderer settings affect the rendering of all the controls that use the renderer.  However, there are other properties on each [TabStripPage](xref:@ActiproUIRoot.Controls.Docking.TabStripPage) that allow for customization of that particular instance.  These are the properties that can be used to customize a specific page:

| Member | Description |
|-----|-----|
| [BackgroundFill](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.BackgroundFill) Property | Gets or sets the page-specific `BackgroundFill` for the tabstrip page. |
| [TabSelectedBackgroundFill](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabSelectedBackgroundFill) Property | Gets or sets the page-specific `BackgroundFill` for the page's tab when it is selected. |
| [TabSelectedFont](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabSelectedFont) Property | Gets or sets the page-specific `Font` to use for drawing the page's tab when it is selected. |
| [TabSelectedForeColor](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabSelectedForeColor) Property | Gets or sets the page-specific foreground color of the page's tab when it is selected. |
| [TabUnselectedBackgroundFill](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabUnselectedBackgroundFill) Property | Gets or sets the page-specific `BackgroundFill` for the page's tab when it is unselected. |
| [TabUnselectedFont](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabUnselectedFont) Property | Gets or sets the page-specific `Font` to use for drawing the page's tab when it is unselected. |
| [TabUnselectedForeColor](xref:@ActiproUIRoot.Controls.Docking.TabStripPage.TabUnselectedForeColor) Property | Gets or sets the page-specific foreground color of the page's tab when it is unselected. |
