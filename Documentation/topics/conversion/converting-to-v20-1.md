---
title: "Converting to v20.1"
page-title: "Converting to v20.1 - Conversion Notes"
order: 10
---
# Converting to v20.1

Changes are described below.

## SyntaxEditor Modernized

The 2020.1 version of SyntaxEditor is effectively a rewrite of the product so that it shares a common codebase with the WPF and UWP versions.  These versions have a much more modern design than the prior WinForms versions, with advanced features and better performance.

Bringing the same codebase to WinForms allows the WinForms version to be kept in sync with all improvements made to SyntaxEditor in the future, as well as allowing for a more powerful .NET Languages Add-on, JavaScript and JSON languages in the Web Languages Add-on, and the new Python Language Add-on.  The new LL(*) Parser Framework is also an excellent way to build parsers for use with SyntaxEditor, and is used in all our premium add-ons.

### Approaching Conversion

Unfortunately, many APIs between the 2020.1 version and prior WinForms versions are different, as are ways of accomplishing similar tasks.  Depending on which feature areas you use, it could take significant effort to convert old code to work with the new codebase.

The best approach is to examine related documentation and samples for feature areas and add-ons you use.  We include many QuickStart samples in the 2020.1 version that focus on specific feature areas.  These QuickStart samples are excellent places to go when wanting to learn about a feature area.

If you have any questions after looking at the documentation and samples on how to proceed with implementing a certain feature area, please contact our [support team](../support.md).
