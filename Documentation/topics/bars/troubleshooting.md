---
title: "Troubleshooting"
page-title: "Troubleshooting - Bars Reference"
order: 99
---
# Troubleshooting

## Visual Studio Error When Bar Controls Are Loaded or Saved

This problem may happen when the `Form` containing the bar controls is loaded or saved, or if the designer verbs are used to load/save a bar layout to a file.

The error message will typically be some sort of `InvalidCastException` or a `NullReferenceException`.  The reason this happens is a bug in Visual Studio, that is described below.

The problem can arise if `Copy Local` is set to `true` for the Actipro assemblies referenced by your project, and the Actipro assemblies are located in the Global Assembly Cache (GAC) on your computer.  To resolve the problem, simply change `Copy Local` to `false` for the Actipro assemblies referenced by your project that are located in the GAC.

The problem is generally caused because of how Visual Studio inappropriately handles `TypeConverter` attributes.  When `Copy Local` is set to `true`, the referenced assembly will be copied to a local folder and that will be used to instantiate the objects in the designer.  Then when a `TypeConverter` is created, it is created by the assembly located in the GAC.  So Visual Studio loads two different copies of the same assembly.  The `TypeConverter` (created from the GAC) is passed an object (created from the local copy) and when a cast operation occurs in the `TypeConverter` (which normally would work fine), you get an exception because the `System.Type` information differs between the type in the `TypeConverter` and the type of the object that is passed.

## Bar Control Shortcuts Don't Work in Secondary AppDomain

This problem occurs when you are using the Bar controls on a `Form` in a non-default `AppDomain`.  In this scenario, the keyboard shortcuts will not work.

The problem is not actually a problem with Bars but is a setup issue with the `AppDomain`.  In order for keyboard shortcuts to be recognized, a message pump needs to be in place in the `AppDomain`.  This is instantiated with a call to `Application.Run`.

Therefore to run a `Form` in a secondary `AppDomain`, don't create/unwrap it and call its `Show` method.  Instead, call a static method on a class in the `AppDomain`, and have that method execute `Application.Run` on the new instance of the `Form`.  This ensures a message pump is created and the `Form` is the main window in the `AppDomain`.
