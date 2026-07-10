using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotVersioning;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private readonly List<ITextSnapshot> _snapshotList = [];

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Load a language from a language definition
		topEditor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");
		bottomEditor.Document.Language = topEditor.Document.Language;

		// Append the first snapshot
		AppendSnapshot(topEditor.Document.CurrentSnapshot);
		snapshotListBox.SelectedIndex = 0;
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Appends a snapshot to the list.
	/// </summary>
	/// <param name="snapshot">The <see cref="ITextSnapshot"/> to append.</param>
	private void AppendSnapshot(ITextSnapshot snapshot) {
		_snapshotList.Add(snapshot);
		snapshotListBox.SelectedIndex = snapshotListBox.Items.Add("Version " + snapshot.Version.Number + " (" + snapshot.Version.Length + ")");
	}

	/// <summary>
	/// Occurs when the selection has changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnSnapshotListBoxSelectedIndexChanged(object sender, EventArgs e) {
		var index = snapshotListBox.SelectedIndex;
		if (0 <= index && index < _snapshotList.Count) {
			var snapshot = _snapshotList[index];
			bottomEditor.Document.SetText(snapshot.Text);
		}
	}

	/// <summary>
	/// Occurs after the editor's document text has changed.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnTopEditorDocumentTextChanged(object sender, UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangedEventArgs e) {
		AppendSnapshot(e.NewSnapshot);
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
		base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

		if (!Program.IsControlFontScalingHandledByRuntime) {
			// Manually scale control fonts
			var manualFontControls = new Control[] {
				bottomEditorLabel,
				heading1Label,
				heading2Label,
				heading3Label,
				snapshotLabel,
				snapshotListBox,
				topEditorLabel,
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}
	}

}
