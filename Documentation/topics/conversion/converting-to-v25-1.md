---
title: "Converting to v25.1"
page-title: "Converting to v25.1 - Conversion Notes"
order: 5
---
# Converting to v25.1

All of the breaking changes are detailed or linked below.

## New Targets

All NuGet packages include a new target for .NET 8.

NuGet packages for the SyntaxEditor Text assemblies have been moved from .NET 6 to .NET 8.  Those who still need to support older versions of .NET can use the .NET Standard 2.0 targets.

NuGet packages no longer include the legacy .NET Core 3.1 target.  This target was previously used to support .NET Core 3.1 and .NET 5, neither of which are still supported by Microsoft. Projects that target .NET should be moved to .NET 6 or greater.

The .NET Framework configurations are unchanged.

## Visual Studio 2019 Support Removed

Visual Studio 2019 does not support .NET 6 or higher, so it can no longer be used to build .NET applications that use Actipro components.  Applications that target .NET Framework should continue to work, but compatibility is no longer verified with new releases.

## SyntaxEditor Intra-Text Adornment Placement Updates

This version enhances the [Intra-Text Adornments](../syntaxeditor/user-interface/adornment/intra-text-adornments.md) feature with the ability to position the intra-text adornment after the tagged text range instead of before.  This option is handy for scenarios such as when AI suggestions should be displayed at the end of a line, after the last character.

The [IsSpacerBefore](xref:ActiproSoftware.Text.Tagging.IIntraTextSpacerTag.IsSpacerBefore) property was added to the [IIntraTextSpacerTag](xref:ActiproSoftware.Text.Tagging.IIntraTextSpacerTag) interface to support this new option.  Any classes implementing this interface should return `true` for this property to retain prior version functionality where the adornment appears before the tagged range.