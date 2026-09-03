using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.QuickStart.MdiMerging;

/// <summary>
/// A form to test the <c>Bar</c> controls' MDI merging.
/// </summary>
public partial class MainForm : Form {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainForm() {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		// Add a child form
		ProcessFileNew();
	}

	// --------------------------------------------------------------------------------------------------
	// NON.PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when a <see cref="BarCommand"/> is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCommandClick(object sender, BarCommandLinkEventArgs e) {
		// Quit if the command is undefined
		if (e.Command is not { } command)
			return;

		switch (command.FullName) {
			case "File.Exit":
				Close();
				break;
			case "File.New":
				ProcessFileNew();
				break;
			default:
				MessageBox.Show($"The command '{command.FullName}' has not been implemented for this sample.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
				break;
		}
	}

	/// <summary>
	/// Processes the <c>File.New</c> command.
	/// </summary>
	private void ProcessFileNew() {
		var childForm = new ChildForm(barManager) {
			MdiParent = this
		};
		childForm.Show();
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void OnMdiChildActivate(EventArgs e) {
		// Call the base method.
		base.OnMdiChildActivate(e);

		// This sample requires that a MenuBar is configured for the BarManager
		if (barManager.MenuBar is not { } menuBar) {
			MessageBox.Show("This sample requires that a MenuBar is configured for the BarManager.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		// Merge or revert merge
		if (ActiveMdiChild is ChildForm childForm)
			BarManager.Merge(childForm.ToolBar, menuBar, revertAllFirst: true);
		else
			BarManager.RevertAllMerges(menuBar);
	}

}
