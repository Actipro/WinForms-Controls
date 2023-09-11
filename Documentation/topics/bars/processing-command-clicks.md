---
title: "Processing Command Clicks"
page-title: "Processing Command Clicks - Bars Reference"
order: 9
---
# Processing Command Clicks

Command clicks can occur from several situations.  One is when a button command link is clicked or one of its keyboard shortcuts is pressed.  Another is if a custom control's (such as a textbox or combobox) value changes and is committed.

There currently are two ways to handle and process command clicks.

## Handling the BarManager.CommandClick Event

This method of processing command clicks is similar to a "dispatch" type of method.  Basically, you handle the [CommandClick](xref:@ActiproUIRoot.Controls.Bars.BarManager.CommandClick) event exposed by the [BarManager](xref:@ActiproUIRoot.Controls.Bars.BarManager) and in it, use a large `switch` statement to forward command processing to other methods.  Or you can handle the processing directly in the event handler itself.

The [CommandClick](xref:@ActiproUIRoot.Controls.Bars.BarManager.CommandClick) event arguments indicate which [BarCommand](xref:@ActiproUIRoot.Controls.Bars.BarCommand) should be processed.  They also will pass which [BarCommandLink](xref:@ActiproUIRoot.Controls.Bars.BarCommandLink) was clicked if the click originated from the user interface.

This sample demonstrates how to handle command clicks using this approach:

```csharp
/// <summary>
/// Occurs when a <see cref="BarCommand"/> is clicked.
/// </summary>
/// <param name="sender">Sender of the event.</param>
/// <param name="e">Event arguments.</param>
private void barManager_CommandClick(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
	switch (e.Command.FullName) {
		case "File.New":
			this.ProcessFileNew();
			break;
		case "File.Exit":
			this.ProcessFileExit();
			break;
	}
}
```

## Overriding Command Classes

Another option, which is much more advanced, is to create a command class for each command.  For instance, you could make a `FileNewCommand` that inherits [BarButtonCommand](xref:@ActiproUIRoot.Controls.Bars.BarButtonCommand).  Then you would place all your code for `"File.New"` in the override of the [OnClick](xref:@ActiproUIRoot.Controls.Bars.BarButtonCommand.OnClick*) method.

This sample demonstrates how to handle command clicks using this approach:

```csharp
public class FileNewCommand : BarButtonCommand {

	/// <summary>
	/// Initializes a new instance of the <c>FileNewCommand</c> class.
	/// </summary>
	/// <param name="category">The category of the bar command.</param>
	/// <param name="name">The name of the bar command.</param>
	/// <param name="text">The text caption.</param>
	/// <param name="imageIndex">The index of an image within an <c>ImageList</c>.</param>
	public FileNewCommand(string category, string name, string text, int imageIndex) :
		base(category, name, text, imageIndex) {}

	/// <summary>
	/// Raises the <c>Click</c> event.
	/// </summary>
	/// <param name="e">A <c>BarCommandLinkEventArgs</c> that contains the event data.</param>
	protected override void OnClick(BarCommandLinkEventArgs e) {
		// Get some sort of pre-set context object from the BarManager's Tag property
		BarForm.BarFormContext context = (BarForm.BarFormContext)e.BarManager.Tag;

		// NOTE: Create a new document here
	}
}
```

The downside to this method is that there is no designer-oriented way to swap the normal command with your custom command type.  However, you can modify the `InitializeComponent` code directly to make the switch.

To make the switch you'd change this line...

```csharp
ActiproSoftware.UI.WinForms.Controls.Bars.BarButtonCommand fileNewBarButtonCommand =
	new ActiproSoftware.UI.WinForms.Controls.Bars.BarButtonCommand("File", "New", "&New...", -1);
```

To this:

```csharp
MyNamespace.FileNewCommand fileNewBarButtonCommand = new MyNamespace.FileNewCommand("File", "New", "&New...", -1);
```

Once that code is in place, the designer should remember to code serialize your class.

> [!IMPORTANT]
> Remember to always back up your code before changing anything in `InitializeComponent`!
