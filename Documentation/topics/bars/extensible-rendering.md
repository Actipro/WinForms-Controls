---
title: "Extensible Rendering"
page-title: "Extensible Rendering - Bars Reference"
order: 15
---
# Extensible Rendering

All the bar controls use an extensible rendering model that is based on our common object model.  The object model centers around the use of a renderer class.  The renderer measures and draws all of the elements within the control.  This is a great design because it allows you to use our pre-defined renderers or create your own.

This object model allows for three levels of rendering customization.  Choose which level of customization you wish to use:

- Use Built-In Renderers As-Is - Use the built-in rendering styles without any changes, which include several Metro, Visual Studio, and Office styles.
- Modify Properties on Built-In Renderers - Use the built-in renderers but modify the various properties on the renderers to easily create a customized appearance.
- Create Custom Renderers - Implement the [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer) or [IStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IStatusBarRenderer) interfaces or inherit our [BarRenderer](xref:@ActiproUIRoot.Controls.Bars.BarRenderer) or [StatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.StatusBarRenderer) classes to do all the measuring and drawing of the controls and their elements yourself.

These are some sample rendering styles that come with [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) and [StatusBar](xref:@ActiproUIRoot.Controls.Bars.StatusBar):

![Screenshot](images/bar-controls-metro-light.png)![Screenshot](images/bar-controls-office-2007-blue.png)![Screenshot](images/bar-controls-office-2007-silver.png)![Screenshot](images/bar-controls-office-2007-black.png)![Screenshot](images/bar-controls-office-2003-blue.png)![Screenshot](images/bar-controls-office-2003-olive-green.png)![Screenshot](images/bar-controls-office-2003-silver.png)![Screenshot](images/bar-controls-windows-classic.png)![Screenshot](images/bar-controls-visual-studio-2002.png)![Screenshot](images/bar-controls-visual-studio-2005.png)

## Use Built-In Renderers As-Is

Bars includes these built-in renderers, which support Metro, Visual Studio, Office, and other classic styles:

| Renderer | Description |
|-----|-----|
| [MetroBarRenderer](xref:@ActiproUIRoot.Controls.Bars.MetroBarRenderer) | Capable of drawing Metro styles (Light and Dark) for bar controls.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Bars.MetroBarRenderer.BaseColorSchemeType). |
| [MetroStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.MetroStatusBarRenderer) | Capable of drawing Metro styles (Light and Dark) for statusbar controls.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Bars.MetroStatusBarRenderer.BaseColorSchemeType). |
| [OfficeClassicBarRenderer](xref:@ActiproUIRoot.Controls.Bars.OfficeClassicBarRenderer) | Capable of drawing all Office classic styles (Blue, Silver, Black), Luna styles (Blue, Olive Green, Silver), and Windows Classic, as well as the Visual Studio classic style for bar controls.  To change to a different style, change the [BaseColorSchemeType](xref:@ActiproUIRoot.Controls.Bars.OfficeClassicBarRenderer.BaseColorSchemeType). |
| [OfficeClassicStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.OfficeClassicStatusBarRenderer) | Capable of drawing all Office styles for statusbar controls. |
| [VisualStudioBarRenderer](xref:@ActiproUIRoot.Controls.Bars.VisualStudioBarRenderer) | Capable of drawing Visual Studio bar controls. |
| [VisualStudioClassicStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.VisualStudioClassicStatusBarRenderer) | Capable of drawing Visual Studio classic statusbar controls. |
| [WindowsClassicBarRenderer](xref:@ActiproUIRoot.Controls.Bars.WindowsClassicBarRenderer) | Capable of drawing Windows classic bar controls. |
| [WindowsClassicStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.WindowsClassicStatusBarRenderer) | Capable of drawing Windows classic statusbar controls. |

## Color Tinting Color Schemes

With one line of code, any `WindowsColorScheme` can be tinted so that all of the colors are altered.  For instance, you can easily create a tan or red color scheme and then use those color schemes with the [OfficeClassicBarRenderer](xref:@ActiproUIRoot.Controls.Bars.OfficeClassicBarRenderer) class like this:

![Screenshot](images/bar-controls-custom-tan.png)![Screenshot](images/bar-controls-custom-red.png)

This code shows how to load a custom tan-tinted color scheme (displayed in the screenshot above) that is based on the built-in Luna blue theme:

```csharp
var scheme = new WindowsColorScheme("Tan", WindowsColorSchemeType.LunaBlue, Color.Tan);
barManager.Renderer = new OfficeClassicBarRenderer(scheme);
```

## Customizing Specific Colors in a Color Scheme

Each color property on the `WindowsColorScheme` class has a getter and setter.  This means that after a base color scheme is selected for use, you may alter specific colors as needed.

This code shows how change the background of menus to be `LightBlue` for the built-in Windows Classic color scheme.

```csharp
WindowsColorScheme.WindowsClassic.MenuBack = Color.LightBlue;
```

> [!IMPORTANT]
> Any renderers created before the color settings were changed may need to be refreshed for the color changes to take effect in the renderer.

## Modify Properties on Built-In Renderers

Select a base built-in renderer to use by following the steps above.  Then use the designer to change its properties.  You can change fonts, colors, backgrounds, measuring parameters, etc.  Our built-in renderers give you a lot of options that you can use to customize the look and feel of the controls.

## Create Custom Renderers

For the most flexibility over what is measured and rendered, create a class that implements the [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer) or [IStatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IStatusBarRenderer) interfaces.  Alternatively, you can create a class that inherits our [BarRenderer](xref:@ActiproUIRoot.Controls.Bars.BarRenderer) or [StatusBarRenderer](xref:@ActiproUIRoot.Controls.Bars.StatusBarRenderer), or one of their descendants.  The renderer interface has methods that measure and draw the controls and their elements.

After your custom renderer class has been created, assign it to the [Renderer](xref:@ActiproUIRoot.Controls.Bars.BarManager.Renderer) property of each [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager), or the [Renderer](xref:@ActiproUIRoot.Controls.Bars.StatusBar.Renderer) property of each [StatusBar](xref:@ActiproUIRoot.Controls.Bars.StatusBar) that should use it for drawing.

## Customizing Individual Statusbar Panels

Renderer settings affect the rendering of all the controls that use the renderer.  However, there are other properties on each [StatusBarPanel](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanel) that allow for customization of that particular instance.  These are the properties that can be used to customize a specific panel:

| Member | Description |
|-----|-----|
| [BackgroundFill](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanel.BackgroundFill) Property | Gets or sets the page-specific `BackgroundFill` for the panel. |
| [Border](xref:@ActiproUIRoot.Controls.Bars.StatusBarPanel.Border) Property | Gets or sets the page-specific `SimpleBorder` for the panel. |
