using ActiproSoftware.UI.WinForms.Controls.Bars;

#if NETFRAMEWORK || NET10_0_OR_GREATER
// Avoid ambiguity with System.Windows.Forms.ToolBar from .NET Framework or .NET 10+
using ToolBar = ActiproSoftware.UI.WinForms.Controls.Bars.ToolBar;
#endif

namespace ActiproSoftware.ProductSamples.BarsSamples.QuickStart.MdiMerging;

/// <summary>
/// A form to test the <c>Bar</c> controls' MDI merging.
/// </summary>
public partial class ChildForm : Form {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="barManager">The <see cref="BarManager"/> that is managing the commands.</param>
	public ChildForm(BarManager barManager) {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		// One way to implement MDI merging is to use a trick where the commands for this toolbar are designed
		//   as a PopupMenu on the managing BarManager of the parent form, then the command links can be cloned
		//   into the toolbar for the MDI child.
		var childToolBar = barManager.PopupMenus["ChildToolBar"]
			?? throw new InvalidOperationException("This sample requires that the MDI child toolbar commands are defined in the BarManager as the 'ChildToolBar' popup menu.");
		toolBar.CommandLinks.AddRange(childToolBar.CommandLinks.CloneToArray());
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// The <see cref="ToolBar"/> on the form.
	/// </summary>
	public ToolBar ToolBar
		=> toolBar;

}
