---
title: "Troubleshooting"
page-title: "Troubleshooting - Wizard Reference"
order: 12
---
# Troubleshooting

This page lists the known issues with Wizard.

## Visual Studio Designer Recognizing BackgroundFill Reference Changes on Renderer

There is a Visual Studio designer bug where changes made to `BackgroundFill` references on a renderer class sometimes do not tell the designer that a property has changed and that the `Form` needs to be saved.  When the editor for `BackgroundFill` classes is opened, and a `BackgroundFill` reference is changed, we use the recommended method `PropertyDescriptor.SetValue` to update the reference.  The designer should recognize that as a component change, but it does not.

You can duplicate this by opening a `Form` with a `Wizard` on it in the designer.  Then go to the Wizard's `Renderer` property, expand it, and select a background fill property.  Click the **...** button to open the **Background Fill Editor**.  Change the reference to another background fill type.  Press the **OK** button.  Notice that the tab for the `Form` has not been marked with an asterisk (*) to indicate that a component has changed.  The Visual Studio bug is that it should have been flagged as changed.

Since Visual Studio thinks that no change has been made, even the pressing of the **Save** button in Visual Studio may not save the change.  However, the change will be saved if you update another property that causes a component change recognized by the designer, and then save the `Form`.  If the tab for the `Form` is marked with an asterisk (*) the background fill change will serialize correctly.

The important thing to remember is that if you make a renderer background fill change in the designer, ensure that the tab for the `Form` has an asterisk next to it, indicating that a component has been changed.  If you change a background fill and no asterisk is there, you can force one to show up by moving a control, resizing a control, changing a property of a control or component, etc.  Once the asterisk appears, save the `Form` and the background fill change should properly serialize.
