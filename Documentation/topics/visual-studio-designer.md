---
title: "Visual Studio Designer"
page-title: "Visual Studio Designer"
order: 23
---
# Visual Studio Designer

Actipro WinForms Controls can be configured using Visual Studio designer functionality. The designer experience is based on the target framework of a project. All versions of .NET Framework have been supported by Visual Studio for many years. However, support for .NET Core / .NET 5+ is relatively new to Visual Studio and requires a radically different approach to host those controls in the designer.

## .NET Framework Support

Proper designer support for .NET Framework requires that controls have been installed by the *WinForms Controls Installer* with the "Visual Studio Designer Functionality" option selected.

> [!IMPORTANT]
> Due to limitations with NuGet packages, our controls must be installed as noted above even when working with NuGet package references. This is only necessary for design-time support and the installer is not required on build machines when NuGet packages are used.

## .NET Core / .NET 5 and Higher Support

To support Visual Studio design-time functionality with .NET Core and/or .NET 5+, controls must be referenced as NuGet packages.  See the [NuGet Packages and Feeds](nuget.md) topic for additional information on working with NuGet packages.

> [!IMPORTANT]
> WinForms designer support for .NET Core / .NET 5+ in Visual Studio 2019/2022 is available *only as a preview*.  Our NuGet packages ship with support for multiple versions of the Visual Studio Design Tools SDK, and Visual Studio will attempt to use the version which most closely matches.  Breaking changes to the SDK are still common with new Visual Studio releases, and **any upgrade to Visual Studio may break designer functionality** until an update is available.

Until Visual Studio designer support stabilizes, new versions of Visual Studio will likely require new versions of our controls.  With each new Visual Studio version that is incompatible with a previous version, we intend to publish updated NuGet packages to support the latest version of Visual Studio. *Only the latest version* of WinForms Controls will be updated to support the new releases of Visual Studio.

### Visual Studio Support Matrix

The following outlines the compatibility of Actipro WinForms Controls with versions of Visual Studio.

<table>
<thead>

<tr>
<th>WinForms Controls Versions</th>
<th>Supported Visual Studio Versions</th>
</tr>


</thead>
<tbody>

<tr>
<td>WinForms Controls v22.1</td>
<td>

- Visual Studio 2022 v17.0
- Visual Studio 2019 v16.11
- Visual Studio 2019 v16.10
- *Minor updates to v16 and v17 are expected to be supported and will be verified as they are released*

</td>
</tr>

<tr>
<td>WinForms Controls v21.1</td>
<td>

- Visual Studio 2019 v16.11
- Visual Studio 2019 v16.10
- *Minor updates to v16 are expected to be supported and will be verified as they are released*

</td>
</tr>

<tr>
<td>

*All other versions*

</td>
<td>

*None*

</td>
</tr>

</tbody>
</table>

### .NET Framework Designer Workaround

If you are unable to use a WinForms Controls version that is compatible with the version of Visual Studio you are using, you may be able to use the .NET Framework designer support instead.

While the designers themselves are framework-specific, the code serialized by the designers will work across frameworks. This means that even if you design your user interface using .NET Framework designers, the same code can still be compiled to target .NET Core and/or .NET 5+. Even if you do not plan to ship with support for .NET Framework, you can still target .NET Framework by your project to enable use of the designers. See the "Multi-Framework Projects" section below for additional information.

## Multi-Framework Projects

As noted above, the Visual Studio designer capabilities vary between projects that target .NET Framework and those that target .NET Core / .NET5+. What if you target both?

> [!NOTE]
> As of Visual Studio 2019, any project which is configured to target multiple frameworks cannot switch designer capabilities while the project is loaded. Changing the target framework of the Visual Studio debugger does not affect the design-time functionality.

The `TargetFrameworks` property of a project configuration file is used to define multiple targets in a semicolon-delimited list.  The first framework listed will dictate which designer capabilities are used by Visual Studio.

In the following example, the .NET Framework designer capabilities will be used since the first target of `net462` is based on .NET Framework:

```xml
<TargetFrameworks>net462;net471;netcoreapp3.1;net50-windows</TargetFrameworks>
```

> [!IMPORTANT]
> See the requirements noted above for .NET Framework or .NET Core / .NET 5+ based on which target framework will govern the designer capabilities of your project.
