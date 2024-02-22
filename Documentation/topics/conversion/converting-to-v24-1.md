---
title: "Converting to v24.1"
page-title: "Converting to v24.1 - Conversion Notes"
order: 6
---
# Converting to v24.1

All of the breaking changes are detailed or linked below.

## SyntaxEditor Native Dark Theme Support

Support for dark themes is now integrated directly into [SyntaxEditor](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditor).  Refer to the [Dark Themes](../syntaxeditor/user-interface/styles/dark-themes.md) topic for details on concepts like [SyntaxEditorThemeManager](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorThemeManager) or [IHighlightingStyleColorPalette](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.IHighlightingStyleColorPalette).

### Switching Themes

Previously, switching between light and dark themes would require multiple steps like:
1. Unregistering all classification types in a registry.
1. Re-registering all the classification types from multiple providers.
1. Re-loading language definition *.langdef* files.
1. For dark theme, importing a *.vssettings* file with colors configured for a dark theme.
1. Changing the [CommonImageSourceProvider](xref:@ActiproUIRoot.Controls.SyntaxEditor.IntelliPrompt.Implementation.CommonImageSourceProvider).[DefaultImageSet](xref:@ActiproUIRoot.Controls.SyntaxEditor.IntelliPrompt.Implementation.CommonImageSourceProvider.DefaultImageSet) between light and dark color sets.

A new [SyntaxEditorThemeManager](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorThemeManager) class now takes care of all of those settings by default, and most developers will not have to do anything to support changing themes.  Check for any custom code that handles theme changes and remove any SyntaxEditor logic related to the previous technique of switching themes.

If custom registries are used instead of [AmbientHighlightingStyleRegistry](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.AmbientHighlightingStyleRegistry), those registries can be configured to automatically switch themes by calling [SyntaxEditorThemeManager](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorThemeManager).[Manage](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorThemeManager.Manage*) and passing the custom registry.

If any developer does not want the default functionality provided by [SyntaxEditorThemeManager](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditorThemeManager), the following code will disable the default features:

```csharp
// Disable automatically switching between light/dark color palettes
SyntaxEditorThemeManager.Unmanage(AmbientHighlightingStyleRegistry.Instance);

// Ensure the light color palette is the default (in case a dark theme was active before being unmanaged)
AmbientHighlightingStyleRegistry.Instance.CurrentColorPalette = AmbientHighlightingStyleRegistry.Instance.LightColorPalette;

// Disable changing image sets
SyntaxEditorThemeManager.IsCommonImageSetSynchronizationEnabled = false;
```

### Dark Colors

If a custom *.vssettings* file was used with preferred dark colors, those colors may not match the new defaults.  A special dark color palette can be initialized with preferred colors to use in dark themes on a per-registry basis.  The following example code demonstrates how to configure the default dark colors for the ambient registry:

```csharp
IHighlightingStyleRegistry registry = AmbientHighlightingStyleRegistry.Instance;
registry.DarkColorPalette.SetForeground("String", Color.FromArgb(255, 214, 157, 133));
registry.DarkColorPalette.SetForeground("PlainText", Color.FromArgb(255, 220, 220, 220));
registry.DarkColorPalette.SetBackground("PlainText", Color.FromArgb(255, 30, 30, 30));
```

> [!NOTE]
> Configuring the dark color palette is only necessary if languages are not updated with explicit dark styles.

### Language Updates

The [Language Designer Tool](../syntaxeditor/language-designer-tool/index.md) has been updated to support the configuration and preview of dark styles for classification types.  Developers are encouraged to use the tool to configure appropriate dark colors instead of explicitly populating the dark color palette, and many dark colors will be automatically configured based on built-in classification types and a pre-defined mapping of common light colors to dark colors.

All Actipro-provided languages have been updated with the new dark style configuration.

### New IHighlightingStyleRegistry Interface Properties

The [IHighlightingStyleRegistry](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry) interface added the [CurrentColorPalette](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry.CurrentColorPalette), [DarkColorPalette](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry.DarkColorPalette), and [LightColorPalette](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.IHighlightingStyleRegistry.LightColorPalette) properties. Any custom classes that implement this interface without deriving from [HighlightingStyleRegistry](xref:@ActiproUIRoot.Controls.SyntaxEditor.Highlighting.Implementation.HighlightingStyleRegistry) will need to implement the new properties.

## SyntaxEditor Enhancements

The following changes were made to enhance the capabilities of SyntaxEditor and might impact some applications.
- The default colors for several [IClassificationType](xref:ActiproSoftware.Text.IClassificationType) instances on [DisplayItemClassificationTypeProvider](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider) have been changed to be more consistent with modern code editor expectations.  Some classification types were updated to remove opacity from the default color and, instead, always apply an opacity when the color is rendered.
    - [SelectedText](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.SelectedText) background from #99CCFF to #0078D7.
    - [InactiveSelectedText](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.InactiveSelectedText) background from #CCDDEE to #BFCDDB.
    - [LineNumbers](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.LineNumbers) foreground from #2B91AF to #7A7A7A.
    - [BreakpointEnabled](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.BreakpointEnabled) background from #AB616B to #963A46.
    - [BreakpointDisabled](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.BreakpointDisabled) border from #AB616B to #000000.
    - [IndicatorMargin](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.IndicatorMargin) background from #F0F0F0 to #E6E7E8.
    - [CurrentLine](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.CurrentLine) border from #30A0A0A0 to #EAEAF2; 30% opacity automatically applied when rendered.
    - [DelimiterMatching](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeKeys.DelimiterMatching) background from #30A0A0A0 to #DBE0CC with 75% opacity automatically applied when rendered.
    - [FindMatchHighlight](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.FindMatchHighlight) background from #C8F4A721 to #F4A721 with 75% opacity automatically applied when rendered.
    - [CollapsibleRegion](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.CollapsibleRegion) foreground from #80D7DDE8 to #D7DDE8 with 50% opacity automatically applied when rendered.  Background from #80EDEFF5 to #F6F7FA.
    - [ColumnGuides](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.ColumnGuides) background from #F0F0F0 to #D0D0D0.
    - [IndentationGuides](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.IndentationGuides) background from #F0F0F0 to #D0D0D0.
- The [Punctuation](xref:ActiproSoftware.Text.ClassificationTypes.Punctuation) classification type was added to all appropriate Actipro languages.
  - Implement the [IDotNetClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.DotNet.IDotNetClassificationTypeProvider).[Punctuation](xref:ActiproSoftware.Text.Languages.DotNet.IDotNetClassificationTypeProvider.Punctuation) property for classes that implement the interface without deriving from the [DotNetClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.DotNet.Implementation.DotNetClassificationTypeProvider) class.
  - Implement the [IJavaScriptClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.JavaScript.IJavaScriptClassificationTypeProvider).[Punctuation](xref:ActiproSoftware.Text.Languages.JavaScript.IJavaScriptClassificationTypeProvider.Punctuation) property for classes that implement the interface without deriving from the [JavaScriptClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.JavaScript.Implementation.JavaScriptClassificationTypeProvider) class.
  - Implement the [IPythonClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.Python.IPythonClassificationTypeProvider).[Punctuation](xref:ActiproSoftware.Text.Languages.Python.IPythonClassificationTypeProvider.Punctuation) property for classes that implement the interface without deriving from the [PythonClassificationTypeProvider](xref:ActiproSoftware.Text.Languages.Python.Implementation.PythonClassificationTypeProvider) class.
- The [SyntaxEditor](xref:@ActiproUIRoot.Controls.SyntaxEditor.SyntaxEditor) `ForeColor` and `BackColor` properties are no longer used as the default foreground and background colors for a printer view.  If non-default colors are desired, register a style with the [PlainText](xref:@ActiproUIRoot.Controls.SyntaxEditor.DisplayItemClassificationTypeProvider.PlainText) classification type on the editor's highlighting style registry.

## Theme Updates

Several changes were made to theme-related classes.  Generally speaking, the following changes were made:
- A new "Visual Studio Blue" theme is available based on Visual Studio 2022's Blue theme.
- "Visual Studio 2005" is now referred to as "Visual Studio Classic".
- "Office 2007" and "Office 2003" are now referred to as "Office Classic".
- "Windows XP" is now referred to as "Luna".
- The "Visual Studio 2005 Beta 2" renderers have been deprecated and will be removed in a future release.
- The `WindowsXPRoyale` color scheme has been deprecated since it duplicates other classic color schemes and will be removed in a future release.
- Several previously deprecated renderers were removed.

> [!IMPORTANT]
> Every effort was made to ensure a seamless upgrade by maintaining binary compatibility with the previous release. After upgrading to this release, your IDE should display warnings for the use of any deprecated values.  This should allow developers to slowly migrate to the new values, but do not ignore the warnings as the values will be removed in a future release.

See below for the specific details on theme-related changes.

### Color Scheme Changes

The following changes were made to color schemes:
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`VisualStudio2005` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`VisualStudio2005` will be referred to as `VisualStudioClassic` going forward.  The original `VisualStudio2005` values have been deprecated and will be removed in a future release. Use `VisualStudioClassic` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`Office2007Blue` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`Office2007Blue` will be referred to as `OfficeClassicBlue` going forward.  The original `Office2007Blue` values have been deprecated and will be removed in a future release. Use `OfficeClassicBlue` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`Office2007Black` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`Office2007Black` will be referred to as `OfficeClassicBlack` going forward.  The original `Office2007Black` values have been deprecated and will be removed in a future release. Use `OfficeClassicBlack` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`Office2007Silver` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`Office2007Silver` will be referred to as `OfficeClassicSilver` going forward.  The original `Office2007Silver` values have been deprecated and will be removed in a future release. Use `OfficeClassicSilver` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`WindowsXPBlue` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`WindowsXPBlue` will be referred to as `LunaBlue` going forward.  The original `WindowsXPBlue` values have been deprecated and will be removed in a future release. Use `LunaBlue` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`WindowsXPOliveGreen` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`WindowsXPOliveGreen` will be referred to as `LunaOliveGreen` going forward.  The original `WindowsXPOliveGreen` values have been deprecated and will be removed in a future release. Use `LunaOliveGreen` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`WindowsXPSilver` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`WindowsSilver` will be referred to as `LunaSilver` going forward.  The original `WindowsXPSilver` values have been deprecated and will be removed in a future release. Use `LunaSilver` instead.
- [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).`WindowsXPRoyale` and [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme).`WindowsXPRoyale` have been deprecated since they duplicate other classic color schemes and will be removed in a future release. Use one of the other classic color schemes instead, like `VisualStudioClassic`.

### UIRenderer Changes

The following renderers are being renamed. In each scenario, the original renderer was recreated to derive from the class of the new name and has been marked as deprecated for removal in a future release. Migrate to the new renderer names to avoid future breaking changes.

- `WindowsXPScrollBarRenderer` will be referred to as `WindowsScrollBarRender` going forward.
- `Office2003NavigationBarRenderer` will be referred to as `OfficeLunaNavigationBarRenderer` going forward.
- `Office2007NavigationBarRenderer` will be referred to as `OfficeClassicNavigationBarRenderer` going forward.
- `VisualStudio2002BarRenderer` will be referred to as `WindowsClassicBarRenderer` going forward.
- `Office2003BarRenderer` will be referred to as `OfficeClassicBarRenderer` going forward.
- `VisualStudio2002StatusBarRenderer` will be referred to as `WindowsClassicStatusBarRenderer` going forward.
- `VisualStudio2005StatusBarRenderer` will be referred to as `VisualStudioClassicStatusBarRenderer` going forward.
- `Office2003StatusBarRenderer` will be referred to as `OfficeClassicStatusBarRenderer` going forward.
- `VisualStudio2002DockRenderer` will be referred to as `WindowsClassicDockRenderer` going forward.
- `VisualStudio2002DocumentWindowTabStripRenderer` will be referred to as `WindowsClassicDocumentWindowTabStripRenderer` going forward.
- `VisualStudio2002ToolWindowTabStripRenderer` will be referred to as `WindowsClassicToolWindowTabStripRenderer` going forward.
- `VisualStudio2005DockRenderer` will be referred to as `VisualStudioClassicDockRenderer` going forward.
- `VisualStudio2005DocumentWindowTabStripRenderer` will be referred to as `VisualStudioClassicDocumentWindowTabStripRenderer` going forward.
- `VisualStudio2005ToolWindowTabStripRenderer` will be referred to as `VisualStudioClassicToolWindowTabStripRenderer` going forward.
- `Office2003DockRenderer` will be referred to as `OfficeClassicDockRenderer` going forward.
- `Office2003DocumentWindowTabStripRenderer` will be referred to as `OfficeClassicDocumentWindowTabStripRenderer` going forward.
- `Office2003ToolWindowTabStripRenderer` will be referred to as `OfficeClassicToolWindowTabStripRenderer` going forward.

The following renders have been deprecated and will be removed in a future release. Migrate to different renderers to avoid future breaking changes.
- `Office2003VisualStudio2005Beta2DockRenderer`
- `Office2003VisualStudio2005Beta2ToolWindowTabStripRenderer`
- `VisualStudio2005Beta2DockRenderer`
- `VisualStudio2005Beta2ToolWindowTabStripRenderer`

The following renderers were previously deprecated and removed in this release:
- Removed `MetroLightBarRenderer`. Use [MetroBarRenderer](xref:@ActiproUIRoot.Controls.Bars.MetroBarRenderer) instead.
- Removed `MetroLightDockRenderer`. Use [MetroDockRenderer](xref:@ActiproUIRoot.Controls.Docking.MetroDockRenderer) instead.
- Removed `MetroLightDocumentWindowTabStripRenderer`. Use [MetroDocumentWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.MetroDocumentWindowTabStripRenderer) instead.
- Removed `MetroLightToolWindowTabStripRenderer`. Use [MetroToolWindowTabStripRenderer](xref:@ActiproUIRoot.Controls.Docking.MetroToolWindowTabStripRenderer) instead.
- Removed `MetroLightNavigationBarRenderer`. Use [MetroNavigationBarRenderer](xref:@ActiproUIRoot.Controls.Navigation.MetroNavigationBarRenderer) instead.

## UIColor Updates

The [UIColor](xref:@ActiproUIRoot.Drawing.UIColor) class has been updated with additional support, and some existing properties/methods are being deprecated to keep the public consistent and avoid ambiguity.  The original properties/methods will be removed in a future release.
- `Hue` property replaced by [HlsHue](xref:@ActiproUIRoot.Drawing.UIColor.HlsHue).
  - Note that the original `Hue` property is based on values from `0` to `1`, and the new [HlsHue](xref:@ActiproUIRoot.Drawing.UIColor.HlsHue) property is based on values from `0` to `360`, so conversion will be necessary.
- `Saturation` property replaced by [HlsSaturation](xref:@ActiproUIRoot.Drawing.UIColor.HlsSaturation).
- `Brightness` property replaced by [HlsLightness](xref:@ActiproUIRoot.Drawing.UIColor.HlsLightness).
- [FromArgb](xref:@ActiproUIRoot.Drawing.UIColor.FromArgb*) method overload with `System.Drawing.Color` argument replaced by [FromColor](xref:@ActiproUIRoot.Drawing.UIColor.FromColor*).
- [FromArgb](xref:@ActiproUIRoot.Drawing.UIColor.FromArgb*) method overload without alpha argument replaced by [FromRgb](xref:@ActiproUIRoot.Drawing.UIColor.FromRgb*).
- [FromAhsb](xref:@ActiproUIRoot.Drawing.UIColor.FromAhsb*) method overload without alpha argument replaced by [FromHsb](xref:@ActiproUIRoot.Drawing.UIColor.FromHsb*).

## Previously Deprecated Items Removed

The following members were deprecated in previous releases have been removed in this release.

- (Docking) [AssemblyInfo](xref:ActiproSoftware.Products.Docking.AssemblyInfo).`GetImage` method that did not accept a scale factor was removed. Use the [GetImage](xref:ActiproSoftware.Products.Docking.AssemblyInfo.GetImage*) method that accepts a scale factor.
- (SyntaxEditor) [IntelliPromptSessionTypes](xref:@ActiproUIRoot.Controls.SyntaxEditor.IntelliPrompt.IntelliPromptSessionTypes).`CodeSnippet` was removed. Use the [CodeSnippetTemplate](xref:@ActiproUIRoot.Controls.SyntaxEditor.IntelliPrompt.IntelliPromptSessionTypes.CodeSnippetTemplate) property instead.