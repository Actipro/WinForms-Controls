---
title: "Using Forms as Child Controls"
page-title: "Using Forms as Child Controls - Docking & MDI Reference"
order: 19
---
# Using Forms as Child Controls

Any object that inherits from the `Control` class may be used as a child control of a [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow) or [DocumentWindow](xref:@ActiproUIRoot.Controls.Docking.DocumentWindow).

This code shows how to add a control to a [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow) and make it the available area within the [ToolWindow](xref:@ActiproUIRoot.Controls.Docking.ToolWindow):

```csharp
// Assume that toolWindow is already referencing a tool window
TextBox tb = new TextBox();
tb.Dock = DockStyle.Fill;
toolWindow.Controls.Add(tb);
```

When the child control is a `Form`, several extra steps need to be taken.  By default, normal `Control`-based objects are visible while `Form`-based objects are not. `Form`-based objects cannot be parented to other `Control`s until the `Form.TopLevel` property has been set to `false`.  Also, `Form` objects will continue to show their border unless you turn it off.

Keeping these issues in mind, the above code must be changed to the following to support a `Form` as a child control:

```csharp
// Assume that toolWindow is already referencing a tool window
Form f = new Form();
f.Visible = true;
f.TopLevel = false;
f.FormBorderStyle = FormBorderStyle.None;
f.Dock = DockStyle.Fill;
toolWindow.Controls.Add(f);
```
