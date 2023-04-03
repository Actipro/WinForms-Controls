---
title: "Deployment"
page-title: "Deployment"
order: 21
---
# Deployment

## Deployment Steps

There are two main steps to follow when deploying an application that uses Actipro control products.

### Configure Licensing

Please read the [Licensing](licensing.md) topic for details on the two options for applying purchased licenses.  Once configured properly, your license data will either be applied via code or embedded into your application by the build process.

### Include Redistributable Assemblies

Next, simply copy the appropriate redistributable assemblies to the same folder as your application's executable on the target machine.  Nothing else needs to be deployed.

This table describes where referenced assemblies appear after project compilation:

| Reference Kind | Description |
|-----|-----|
| NuGet package reference | The referenced assemblies will be in your `bin` folder after compilation. |
| Assembly reference | The referenced assemblies will be in your `bin` folder after compilation if the "Copy Local" property on the reference (via the Visual Studio Properties window) is set to true. |

## Redistributable Files

When you own a license for WinForms Studio (our large control bundle) or one of its individual products, you are licensed to redistribute certain files with your application.

The tables below show the product assemblies that may be redistributed based on the product(s) for which you own licenses.

### Individual Products

This table shows the product assemblies that may be redistributed based on individual products for which you own licenses, and includes their source NuGet packages:

<table>
<thead>

<tr>
<th>Actipro Product</th>
<th>Redistributable Assemblies and Related NuGet Packages</th>
</tr>

</thead>
<tbody>

<tr>
<td>Bars</td>
<td>

- *ActiproSoftware.Bars.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Bars` NuGet package)
- *ActiproSoftware.Shared.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Shared` NuGet package)

</td>
</tr>

<tr>
<td>Docking/MDI</td>
<td>

- *ActiproSoftware.Docking.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Docking` NuGet package)
- *ActiproSoftware.Shared.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Shared` NuGet package)

</td>
</tr>

<tr>
<td>Navigation</td>
<td>

- *ActiproSoftware.Navigation.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Navigation` NuGet package)
- *ActiproSoftware.Shared.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Shared` NuGet package)

</td>
</tr>

<tr>
<td>SyntaxEditor</td>
<td>

- *ActiproSoftware.SyntaxEditor.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor` NuGet package)
- *ActiproSoftware.Text.LLParser.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor` NuGet package)
- *ActiproSoftware.Text.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor` NuGet package)
- *ActiproSoftware.Shared.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Shared` NuGet package)

</td>
</tr>

<tr>
<td>

SyntaxEditor .NET Languages Add-on \*

</td>
<td>

- *ActiproSoftware.SyntaxEditor.Addons.DotNet.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.DotNet` NuGet package)
- *ActiproSoftware.Text.Addons.DotNet.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.DotNet` NuGet package)
- *ActiproSoftware.Text.Addons.DotNet.Roslyn.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.DotNet` NuGet package)

</td>
</tr>

<tr>
<td>

SyntaxEditor Python Language Add-on \*

</td>
<td>

- *ActiproSoftware.SyntaxEditor.Addons.Python.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.Python` NuGet package)
- *ActiproSoftware.Text.Addons.Python.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.Python` NuGet package)

</td>
</tr>

<tr>
<td>

SyntaxEditor Web Languages Add-on \*

</td>
<td>

- *ActiproSoftware.SyntaxEditor.Addons.JavaScript.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.JavaScript` NuGet package)
- *ActiproSoftware.Text.Addons.JavaScript.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.JavaScript` NuGet package)
- *ActiproSoftware.SyntaxEditor.Addons.Xml.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.XML` NuGet package)
- *ActiproSoftware.Text.Addons.Xml.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.SyntaxEditor.Addons.XML` NuGet package)

</td>
</tr>

<tr>
<td>Wizard</td>
<td>

- *ActiproSoftware.Wizard.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Wizard` NuGet package)
- *ActiproSoftware.Shared.WinForms.dll* (via `ActiproSoftware.Controls.WinForms.Shared` NuGet package)

</td>
</tr>

</tbody>
</table>

*\* Add-ons marked with an asterisk are sold separately from SyntaxEditor and its containing bundles.  See [this documentation](syntaxeditor/assemblies.md) for more details on licensing these add-ons.*

### Bundles

This table shows a bundle that allows groups of Actipro control products to be licensed at a large discount:

<table>
<thead>

<tr>
<th>Actipro Bundle</th>
<th>Description</th>
</tr>

</thead>
<tbody>

<tr>
<td>WinForms Studio</td>
<td>

Available via the `ActiproSoftware.Controls.WinForms` NuGet metapackage, and includes these products:

- Bars
- Docking/MDI
- Navigation
- SyntaxEditor
- Wizard
- Shared Library

</td>
</tr>

</tbody>
</table>

## Other Deployment Notes

### No Run-time Royalties

There are no run-time royalties or other distribution charges for our WinForms control products.  We only require that you have the proper of licenses for each developer on your project.

See the [Licensing](licensing.md) topic for more information on licensing requirements.

### Do Not Use Our Product Installers on End User Machines

You do **NOT** need to use our product installers to place our controls on end user machines, nor are you permitted to apply your license key on end user machines.

If you are getting license popups on end user machines, your licensing configuration is incorrect on your build machine.  Read the [Licensing](licensing.md) topic to troubleshoot the issue.  Once licensing is configured properly, you should only need to xcopy our product assemblies into the same folder as your application on end machines.

### Do Not Install Our Controls to End User GACs (Global Assembly Cache)

We ask that you do not place our control assemblies in the GACs of end user machines.  Our controls should only be in the GACs of developer machines, which is done by our product installer.
