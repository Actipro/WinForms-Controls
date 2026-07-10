using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features;

/// <summary>
/// Provides a <see cref="Form"/> for entering data about a new toolbar.
/// </summary>
internal partial class BarCustomizeNewToolBarForm : DpiAwareForm {

	private readonly BarManager _barManager;
	private string? _existingToolbarName;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="barManager">The manager being edited.</param>
	/// <param name="text">The title bar text.</param>
	public BarCustomizeNewToolBarForm(BarManager barManager, string text) {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		// Initialize parameters
		_barManager = barManager;

		// Initialize the form
		Text = text;
		OnInitForm();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the form needs to be initialized.
	/// </summary>
	private void OnInitForm() {
		// Find a default key
		for (var index = 1; index < int.MaxValue; index++) {
			var key = string.Format("Custom {0}", index);
			if (!_barManager.DockableToolBars.Contains(key)) {
				keyTextBox.Text = key;
				keyTextBox.SelectAll();
				break;
			}
		}
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnOkButtonClick(object sender, EventArgs e) {
		// Ensure that a key was entered
		if (ToolBarKey.Length == 0) {
			MessageBox.Show(this, "Please enter a name for the toolbar.", "Error");
			return;
		}

		// Ensure that the key doesn't already exist
		if ((_existingToolbarName is null) || (ToolBarKey != _existingToolbarName)) {
			if (_barManager.DockableToolBars.Contains(ToolBarKey)) {
				MessageBox.Show(this, "A toolbar with that name already exists.  Please enter a different name.", "Error");
				return;
			}
		}

		// Close the form
		DialogResult = DialogResult.OK;
		Close();
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override bool IsDpiAwareFormShowBehaviorEnabled
		=> true;

	/// <summary>
	/// Gets or sets the toolbar key entered by the user.
	/// </summary>
	/// <value>The toolbar key entered by the user.</value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string ToolBarKey {
		get => keyTextBox.Text.Trim();
		set {
			_existingToolbarName = value;
			keyTextBox.Text = _existingToolbarName;
			keyTextBox.SelectAll();
		}
	}

}
