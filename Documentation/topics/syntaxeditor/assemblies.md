---
title: "Assemblies and Add-on Licensing"
page-title: "Assemblies and Add-on Licensing - SyntaxEditor Reference"
order: 6
---
# Assemblies and Add-on Licensing

SyntaxEditor is a bit unique in relation to our other WinForms control products in that it requires several assemblies depending on which features and add-ons you use.

## What is an Add-on?

An add-on is simply a term used to describe some sort of functionality that can optionally be added onto the main product.

Add-ons may include very advanced syntax language implementations that have features such as automated IntelliPrompt, etc.  These sorts of add-ons are generally sold separately from SyntaxEditor or its containing bundles.

## Add-on Packaging

Add-ons can come in one or more assemblies.  Often add-ons for a syntax language implementation involve two assemblies.  One contains the core text/parsing (non-UI) implementation for language and the other provides UI-related functionality such as working with IntelliPrompt.

The reason add-on assemblies are split up in this way is that we have designed this SyntaxEditor framework to be multi-platform capable.  This means that the core text/parsing assembly could be used in WPF, Windows Forms, ASP.NET, etc.  Then each platform would have their own UI-related assembly that interacted with the user interface.

## Assemblies and Cost

This list of assemblies indicates all of the assemblies related to SyntaxEditor, if they are required or optional, the related add-on (if any), and if they are included for free or sold separately from SyntaxEditor and its containing bundles.

Although the add-ons that are marked as sold separately are included with the WinForms controls sample for demo purposes, licenses for them must be purchased separately if you would like to use them.  However, the pricing on the add-ons is very affordable and licenses are all Enterprise licenses, meaning they cover your entire organization.
