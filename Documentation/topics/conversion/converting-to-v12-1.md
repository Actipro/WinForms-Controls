---
title: "Converting to v12.1"
page-title: "Converting to v12.1 - Conversion Notes"
order: 11
---
# Converting to v12.1

All of the breaking changes are detailed or linked below.

## Unification of Products into a Single Download

All WinForms products are now unified into a single platform download.  Licenses for individual products can still be purchased, but all WinForms products are distributed as a unit.

A new unified WinForms products license key that you obtain when you are licensed for one or more products contains flags indicating which products you are licensed to use.  Thus, now if you have licensed all the WinForms products, you will have a single license key.

A new WinForms Studio bundle is also now available for purchase that provides significant savings over purchasing all the WinForms control products separately.  Please note that the SyntaxEditor add-ons are not included in the WinForms Studio bundle.

These major infrastructure updates align our product deployment, distribution, and licensing implementations with our WPF and UWP platform products and allows us to serve you better.

## Unified Versioning Scheme

Prior to this version, each WinForms product had separate version numbers (i.e., v4.0).  In this version and moving forward, all WinForms products will now share the same version/build numbers so that it's easy to identify which assemblies work with which.  The 2012.1 version will have version number 12.1, and so on, allowing you to also have a general idea of when the version was released (year 2012, first major release of that year).

## UIStudio Split into Separate Products

What was formerly called UIStudio has been split into three separate products (Bars, Docking, and Navigation).  They can now be purchased separately, or together in the WinForms Studio bundle.

The namespaces in the updated assemblies still retain UIStudio in their name to make the transition to 2012.1 an easy one.  In a future major version, we will likely rename namespaces to more closely match the containing product.

## .NET 3.5 Minimum Framework and Client Profile Support

All WinForms products now target .NET 3.5 as their minimum framework version.  They will work fine in any .NET framework 3.5 or later (.NET 4.0, .NET 4.5, etc.).

In addition, the products now support "client profile", meaning they no longer have requirements on *System.Design.dll* and will work on end user machines that have only installed .NET 3.5 or later's "client profile".

> [!NOTE]
> Update your application's project to target .NET 3.5 or later, optionally choosing the "client profile" variation if appropriate.

## Updated Assembly Names

All Actipro product assembly names have been updated to more generic platform-based naming schema as described in this list:

- *ActiproSoftware.UIStudio.Bar.Net20.dll* is now *ActiproSoftware.Bars.WinForms.dll*
- *ActiproSoftware.UIStudio.Dock.Net20.dll* is now *ActiproSoftware.Docking.WinForms.dll*
- *ActiproSoftware.UIStudio.NavigationBar.Net20.dll* is now *ActiproSoftware.Navigation.WinForms.dll*
- *ActiproSoftware.SyntaxEditor.Net20.dll* is now *ActiproSoftware.SyntaxEditor.WinForms.dll*
- *ActiproSoftware.SyntaxEditor.Addons.DotNet.Net20.dll* is now *ActiproSoftware.SyntaxEditor.Addons.DotNet.WinForms.dll*
- *ActiproSoftware.SyntaxEditor.Addons.Web.Net20.dll* is now *ActiproSoftware.SyntaxEditor.Addons.Xml.WinForms.dll*
- *ActiproSoftware.Wizard.Net20.dll* is now *ActiproSoftware.Wizard.WinForms.dll*
- *ActiproSoftware.Shared.Net20.dll* and *ActiproSoftware.WinUICore.Net20.dll* have both been merged into *ActiproSoftware.Shared.WinForms.dll*

> [!NOTE]
> Update all assembly references in your projects, and be sure to also update your *licenses.licx* file with the proper entries you need, as described in detail in the [Licensing](../licensing.md) topic.

## Visual Studio 2010 Projects

The 2012.1 products are built using Visual Studio 2010, and the sample projects are shipped in both Visual Studio 2010 and Visual Studio 2008 form.  Visual Studio 2005 samples are no longer available.

## Former WinUICore Assembly Merged into Shared Assembly

The old WinUICore assembly and all its contents have been merged into the new Shared assembly.  Since all products previously required both assemblies, it made sense to merge them into a single assembly for ease of use and distribution.

> [!NOTE]
> When upgrading from an old product to 2012.1, no WinUICore assembly reference is required any more.  Only the Shared assembly reference is required.

## Resource Access

Access to string resources has been improved to use the implementation we have in our WPF and UWP products.  String resources used to be accessed via a call such as `AssemblyInfo.Instance.Resources.GetString(name)`.  Now they are accessed like `SR.GetString(name)`.

> [!NOTE]
> Change all `AssemblyInfo.Instance.Resources.GetString` calls to `SR.GetString` instead.

Resources methods such as `GetIcon` that previously were accessed on `AssemblyInfo.Instance.Resources` are now accessed directly on `AssemblyInfo.Instance`.

> [!NOTE]
> Call methods such as `GetIcon` directly on `AssemblyInfo` instead of on its old `Resources` property.

## Namespaces Renamed

Several of the former UIStudio product namespaces (that only contain assembly meta data information and resource access) were renamed.  The main namespaces in the former UIStudio products that contain controls and components were not renamed for this version.  Updates include:

- `ActiproSoftware.Products.UIStudio.Bar` renamed to `ActiproSoftware.Products.Bars`
- `ActiproSoftware.Products.UIStudio.Dock` renamed to `ActiproSoftware.Products.Docking`
- `ActiproSoftware.Products.UIStudio.NavigationBar` renamed to `ActiproSoftware.Products.Navigation`

> [!NOTE]
> If you had referenced any of the namespaces listed above, use their renamed namespaces instead.

## Designer Functionality Moved to Separate Design Assemblies

Visual Studio designer functionality for the products has been moved out to separate Design assemblies now.  This allows the products themselves to fully support apps that target "client profile" variations of the .NET framework since they no longer have a *System.Design.dll* dependency.

## Removed ThemeHelper Class

In this version we removed the `ActiproSoftware.Win32.ThemeHelper` class (written prior to .NET 2.0) and replaced its usage with the related native WinForms visual styles classes that were added in .NET 2.0.

> [!NOTE]
> In the unlikely event that you had used ThemeHelper, please use the types in the `System.Windows.Forms.VisualStyles` namespace instead.

## Removed Deprecated Office2003ColorScheme

The `Office2003ColorScheme` class had previously been deprecated and marked obsolete in favor of the newer `WindowsColorScheme` class.  In 2011.2, we removed the `Office2003ColorScheme` from the Shared assembly.

> [!NOTE]
> In the unlikely event that you were still using `Office2003ColorScheme`, convert to using `WindowsColorScheme` instead.
