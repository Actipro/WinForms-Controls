---
title: "Global Renderers"
page-title: "Global Renderers - Shared Library Reference"
order: 100
---
# Global Renderers

Most of the WinForms control products have the concept of global renderers.  Global renderers allow you to easily use the same single instance of a control renderer for all control instances that use that renderer type.  This provides an easy way to provide a consistent theme across an application and also saves on resources since all controls of the same type reuse a single renderer as opposed to each control having its own renderer instance.

## The Renderer Manager

All global renderers are managed by the [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager) class that is located in the `ActiproSoftware.UI.WinForms.Controls` namespace, within the `ActiproSoftware.Shared.WinForms` assembly.  It has a number of static methods that provide control over all of the renderers currently being managed.

> [!IMPORTANT]
> [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager) only manages global renderers.  If a control has a control-specific renderer set, it will not use global renderer settings.

## Changing the Global Color Scheme

The [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager) tracks a global color scheme, which is the color scheme that the global renderers should use.  The color scheme is of type [WindowsColorScheme](xref:ActiproSoftware.UI.WinForms.Drawing.WindowsColorScheme), which is located in the `ActiproSoftware.UI.WinForms.Drawing` namespace, within the `ActiproSoftware.Shared` assembly.  There are a number of built-in color schemes (available from static properties off of [WindowsColorScheme](xref:ActiproSoftware.UI.WinForms.Drawing.WindowsColorScheme)), or you can inherit the [WindowsColorScheme](xref:ActiproSoftware.UI.WinForms.Drawing.WindowsColorScheme) class and build your own custom color scheme.

Once you have determined which color scheme you'd like to use, set it to the static [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).[ColorScheme](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager.ColorScheme) property, and all the global renderers will attempt update to use that color scheme.

This code demonstrates how to set the color scheme to a built-in Visual Studio 2005 theme:

```csharp
UIRendererManager.ColorScheme = WindowsColorScheme.VisualStudio2005;
```

## Using the UIRendererManager Component

Although all the renderer managing functionality is on the static instance of a [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager), The [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager) is also a `Component`.  This means it can be dropped on a `Form` in the designer.  The benefit of this is that when the [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).[ColorSchemeType](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager.ColorSchemeType) instance property is set, it auto-updates the [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).[ColorScheme](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager.ColorScheme) static property to be the related color scheme.

This means that you can drop an instance of [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager) on your application's main `Form`, set the color scheme type that you'd like to use, and once the main `Form` is loaded at run-time, it and all the other child windows after it will use that color scheme.

> [!NOTE]
> The [WindowsColorSchemeType](xref:ActiproSoftware.UI.WinForms.Drawing.WindowsColorSchemeType) enumeration only provides several common built-in color schemes.  If a totally custom color scheme should be used within the application, assign a custom instance of a class derived from [WindowsColorScheme](xref:ActiproSoftware.UI.WinForms.Drawing.WindowsColorScheme) directly to the [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).[ColorScheme](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager.ColorScheme) property.

## Setting a Custom Global Renderer Factory

There may be certain cases where you'd like to use a global renderer that isn't available by default.  For instance, say you'd like to use the [VisualStudio2002ToolWindowTabStripRenderer](xref:ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2002ToolWindowTabStripRenderer) by default for all standalone [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip) controls in your application.  There is no color scheme that will use that renderer since the color schemes default to using the newer Visual Studio renderers instead.  Therefore you have to create a class which implements [IUIRendererFactory](xref:ActiproSoftware.UI.WinForms.Controls.IUIRendererFactory).

The [IUIRendererFactory](xref:ActiproSoftware.UI.WinForms.Controls.IUIRendererFactory).[CreateRenderer](xref:ActiproSoftware.UI.WinForms.Controls.IUIRendererFactory.CreateRenderer*) method implemented on the custom factory class is responsible for returning an instance if [IUIRenderer](xref:ActiproSoftware.UI.WinForms.Controls.IUIRenderer), which is the interface that all renderers implement.

This code demonstrates how to implement a renderer factory for our Visual Studio 2002 [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip) renderer:

```csharp
public class CustomTabStripRendererFactory : IUIRendererFactory {
	IUIRenderer IUIRendererFactory.CreateRenderer() {
		return new VisualStudio2002ToolWindowTabStripRenderer();
	}
}
```

Now that the factory class is available, it must be assigned to the [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).  This is done by a call to the static [UIRendererManager](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager).[RegisterRendererFactory](xref:ActiproSoftware.UI.WinForms.Controls.UIRendererManager.RegisterRendererFactory*) method.  The renderer type must be specified, which is the renderer-specific interface type to be served by the factory class.  In our example, it would be the [ITabStripRenderer](xref:ActiproSoftware.UI.WinForms.Controls.Docking.ITabStripRenderer) interface.  We must also indicate to overwrite any existing renderer factory for the renderer type.

This code demonstrates how to set the custom renderer factory:

```csharp
UIRendererManager.RegisterRendererFactory(typeof(ITabStripRenderer), 
	new CustomTabStripRendererFactory(), overwrite: true);
```

At this point any standalone [TabStrip](xref:ActiproSoftware.UI.WinForms.Controls.Docking.TabStrip) control that doesn't have a control-specific renderer assigned to it will use the global [VisualStudio2002ToolWindowTabStripRenderer](xref:ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2002ToolWindowTabStripRenderer) instance created by the factory.

## Renderer vs. RendererResolved Properties

Each control that supports custom rendering has a `Renderer` (or similarly-named) property and a corresponding `RendererResolved` property.  The `Renderer` property will be `null` by default and should be used to get or set the control-specific renderer to use.  If it is set, the appropriate global renderer will not be used.  The `RendererResolved` property is a read-only property and either returns the control-specific renderer (if set), or the global renderer that is in use by the control.
