---
title: "Troubleshooting (General)"
page-title: "Troubleshooting (General)"
order: 40
---
# Troubleshooting (General)

This topic provides several tips on common questions or issues that you may encounter on the products included in WinForms Studio.

There also are some product-specific troubleshooting topics that provide information related to individual products:

- [Bars Troubleshooting](bars/troubleshooting.md)
- [Wizard Troubleshooting](wizard/troubleshooting.md)

## Licensing Issues

Please refer to the "Troubleshooting" section of the [Licensing](licensing.md) topic.

## Error: The SDK 'Microsoft.NET.Sdk.WindowsDesktop' specified could not be found.

This message is typically displayed when attempting to open an SDK-style project in an older version of Visual Studio that does not support these projects.  Make sure you are using Visual Studio 2019 or later when opening SDK-style projects and that the .NET SDK component is installed.

## Error: The project file cannot be opened. Unabled to locate the .NET SDK.

This message is typically displayed when attempting to open an SDK-style project in Visual Studio and the .NET SDK is not installed.  Some older versions of Visual Studio may not install the .NET SDK by default.  Use the Visual Studio Installer to add the .NET SDK component and reload the solution.