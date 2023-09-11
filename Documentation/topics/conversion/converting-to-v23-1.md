---
title: "Converting to v23.1"
page-title: "Converting to v23.1 - Conversion Notes"
order: 7
---
# Converting to v23.1

All of the breaking changes are detailed or linked below.

## New Targets

Control assemblies for .NET have been updated to target .NET 6 (previously .NET 5) since .NET 5 is no longer supported.  Any applications that target .NET 5 will still be supported using our .NET Core 3.1 targets.

Control assemblies for .NET Framework have been updated to target .NET Framework 4.6.2 (previously .NET Framework 4.0) since it is the most recent supported version. Any applications that reference our controls that were also on an older version of .NET Framework will need to update their targets to at least 4.6.2. Users who cannot update to .NET Framework 4.6.2 should not update to this release and continue using prior versions of these controls.

## High DPI Updates

This release has improved high DPI support across all products. Aside from possible breaking changes noted below, no changes are necessary for components used in an application that is not DPI aware as those applications will continue to emulate 96 dpi (100%). For applications that will support system or per-monitor DPI awareness, Actipro controls will measure and render differently based on the DPI context, so applications should be retested to verify components still behave as expected within your supported environments.

All built-in renderers have been updated for DPI awareness. Any custom renderer implementations with their own logic for measuring and/or drawing will need to be updated to adjust to the DPI scale. The [DpiHelper](xref:@ActiproUIRoot.Drawing.DpiHelper) class contains many helper methods to assist with scaling common values. The current DPI scale factor can be determined by examining the [IDpiAwareElement](xref:@ActiproUIRoot.Controls.IDpiAwareElement).[DpiScaleFactor](xref:@ActiproUIRoot.Controls.IDpiAwareElement.DpiScaleFactor) property of the related element being drawn.

The following breaking changes were necessary to properly handle per-monitor DPI awareness:

- The [IUIElement](xref:@ActiproUIRoot.Controls.IUIElement) and [IBarControl](xref:@ActiproUIRoot.Controls.Bars.IBarControl) interfaces now implement [IDpiAwareElement](xref:@ActiproUIRoot.Controls.IDpiAwareElement).  This change will not impact most users, but any custom classes built using these interfaces that don't derive from one of our default implementations will need to implement the additional interface.

- The [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer).[DrawMenuSeparator](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer.DrawMenuSeparator*) and [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer).[DrawToolBarSeparator](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer.DrawToolBarSeparator*) methods added an [IBarControl](xref:@ActiproUIRoot.Controls.Bars.IBarControl) argument to indicate the element where the separator is being drawn. Any custom renderers that want to support high DPI can use the [IDpiAwareElement](xref:@ActiproUIRoot.Controls.IDpiAwareElement).[DpiScaleFactor](xref:@ActiproUIRoot.Controls.IDpiAwareElement.DpiScaleFactor) property available through the `IBarControl` to render the separator appropriately based on DPI scale.

- The [IBarRenderer](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer).[DrawCommandInCustomizeList](xref:@ActiproUIRoot.Controls.Bars.IBarRenderer.DrawCommandInCustomizeList*) added a `scaleFactor` argument to indicate the DPI scale of the `ListBox` where the command is being drawn.  Any custom renderers that want to support high DPI can use the `scaleFactor` argument to render the command appropriately based on DPI scale.

## Dark Color Scheme

This release includes a new [WindowsColorSchemeType](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType).[MetroDark](xref:@ActiproUIRoot.Drawing.WindowsColorSchemeType.MetroDark) color scheme. To properly support a dark color scheme, the [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme) class was enhanced to define new color properties and enable new capabilities. For increased flexibility, a new [IWindowsColorScheme](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme) interface was added to replace references to [WindowsColorScheme](xref:@ActiproUIRoot.Drawing.WindowsColorScheme) in public APIs.

Windows Forms, in general, relies heavily on the use of `SystemColors` to define the color to be used for common UI elements like text foreground and window backgrounds.  Text foreground, for instance, is typically the color `Black`. While this works in light themes, `Black` text cannot be used effectively with dark backgrounds. Instead of working directly with `SystemColors`, all colors should be queried using [IWindowsColorScheme](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme).[GetKnownColor](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme.GetKnownColor*). This method allows most color schemes to return the native `SystemColor` directly, but a theme with dark intent can return a different color that is more appropriate for that color scheme. A color scheme with dark intent, for instance, might return a shade of `White` for text that will be legible when rendered on a dark background.

The following breaking changes were necessary to properly handle dark color schemes:

- The [IUIRenderer](xref:@ActiproUIRoot.Controls.IUIRenderer).[ColorScheme](xref:@ActiproUIRoot.Controls.IUIRenderer.ColorScheme) property was added to ensure all renderer implementations have access to a color scheme that can be used to resolve known colors. Any custom renderers that do not derive from a built-in renderer will need to implement the new property.

- Any custom rendering that needs to support multiple color schemes should replace `SystemColor` usage with [IWindowsColorScheme](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme).[GetKnownColor](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme.GetKnownColor*).  For example, replace `SystemColors.WindowText` with `colorScheme.GetKnownColor(KnownColor.WindowText)`.

- The [IWizardRenderer](xref:@ActiproUIRoot.Controls.Wizard.IWizardRenderer) interface now implements the [IUIRenderer](xref:@ActiproUIRoot.Controls.IUIRenderer) interface. Any custom implementations of `IWizardRenderer` will need to be updated to support the additional requirements of `IUIRenderer`.

## ContextMenu to ContextMenuStrip (.NET Framework only)

For .NET Framework targets only, all usages of `ContextMenu` have been replaced by `ContextMenuStrip`.  The `ContextMenuStrip` implementation is newer and supported cross-platform by .NET Core+. Not only does this unify our code base around a single solution, `ContextMenuStrip` also provides greater support for custom themes and high DPI awareness that are important features for this release.

The [TabbedMdiWindowContextMenuEventArgs](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindowContextMenuEventArgs).[DefaultContextMenu](xref:@ActiproUIRoot.Controls.Docking.TabbedMdiWindowContextMenuEventArgs.DefaultContextMenu) property has changed from `ContextMenu` to `ContextMenuStrip`.  These arguments are used by [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).[ActiveFilesContextMenu](xref:@ActiproUIRoot.Controls.Docking.DockManager.ActiveFilesContextMenu) and [DockManager](xref:@ActiproUIRoot.Controls.Docking.DockManager).[WindowContextMenu](xref:@ActiproUIRoot.Controls.Docking.DockManager.WindowContextMenu) events. Any code that uses these events to customize or replace the default context menu will need to be refactored to work with `ContextMenuStrip` and `ToolStripMenuItem` types.

## Modern DockGuides

Docking support for [DockGuideStyle](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle).[Sunken](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle.Sunken) (previous default) and [DockGuideStyle](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle).[Raised](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle.Raised) (old Windows XP-era style) has been removed and replaced by [DockGuideStyle](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle).[Modern](xref:@ActiproUIRoot.Controls.Docking.DockGuideStyle.Modern) (new default). The old values are still defined but have been marked as obsolete and will use the `Modern` style when used. No changes are necessary at this time, but any references to the old values should be replaced with `Modern` to avoid IDE warnings and eventual breaking changes when the obsolete values are removed in a future release.

The `Sunken` and `Raised` styles were based on image resources that could be customized using `ActiproSoftware.Products.Docking.AssemblyInfo.Instance.ImageProviderFunc`. Since the `Modern` guides are built dynamically at run-time, there are no images to customize and the `ImageProviderFunc` property has been removed.  The colors used for `Modern` guides can be customized using various properties on [IWindowsColorScheme](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme) (e.g., [IWindowsColorScheme](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme).[DockGuideArrowBack](xref:@ActiproUIRoot.Drawing.IWindowsColorScheme.DockGuideArrowBack) changes the background color of the arrow).  See the [Extensible Rendering](../docking/extensible-rendering.md) topic for more details on customizing a color scheme.

## All Assemblies Code-Signed

All product assemblies are now code-signed so that their authenticity can be verified.

We previously only shipped non-code-signed assemblies, and the installer had an option for whether to install code-signed variations of .NET Framework assemblies.  That installer option has been removed since all assemblies are now code-signed, including all assemblies in the NuGet packages.
