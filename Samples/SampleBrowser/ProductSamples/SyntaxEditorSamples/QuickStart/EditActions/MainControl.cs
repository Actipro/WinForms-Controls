using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.Commands;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditActions;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	private CommandLink? _customCommandLink;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Finalize component initialization
		BuildListView();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Binds data to the list.
	/// </summary>
	private void BuildListView() {
		var ClipboardCategory = "Clipboard / Undo";
		var DeletionCategory = "Deletion";
		var InsertionCategory = "Insertion";
		var IntelliPromptCategory = "IntelliPrompt";
		var MacroCategory = "Macro Recording";
		var MiscellaneousCategory = "Miscellaneous";
		var MovementCategory = "Movement";
		var ScrollCategory = "Scroll";
		var SearchCategory = "Search";
		var SelectionCategory = "Selection";

		EditActionData[] actionDataArray = [
			// Clipboard/undo
			new EditActionData(category: ClipboardCategory, action: new CopyAndAppendToClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new CopyToClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new CutAndAppendToClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new CutLineToClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new CutToClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new PasteFromClipboardAction()),
			new EditActionData(category: ClipboardCategory, action: new RedoAction()),
			new EditActionData(category: ClipboardCategory, action: new UndoAction()),
			// Deletion
			new EditActionData(category: DeletionCategory, action: new BackspaceAction()),
			new EditActionData(category: DeletionCategory, action: new BackspaceToPreviousWordAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteBlankLinesAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteHorizontalWhitespaceAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteLineAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteToLineEndAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteToLineStartAction()),
			new EditActionData(category: DeletionCategory, action: new DeleteToNextWordAction()),
			// Insertion
			new EditActionData(category: InsertionCategory, action: new InsertLineBreakAction()),
			new EditActionData(category: InsertionCategory, action: new OpenLineAboveAction()),
			new EditActionData(category: InsertionCategory, action: new OpenLineBelowAction()),
			new EditActionData(category: InsertionCategory, action: new TypingAction("*Typing*", overwrite: false)),
			// IntelliPrompt
			new EditActionData(category: IntelliPromptCategory, action: new RequestIntelliPromptAutoCompleteAction()),
			new EditActionData(category: IntelliPromptCategory, action: new RequestIntelliPromptCompletionSessionAction()),
			new EditActionData(category: IntelliPromptCategory, action: new RequestIntelliPromptParameterInfoSessionAction()),
			new EditActionData(category: IntelliPromptCategory, action: new RequestIntelliPromptQuickInfoSessionAction()),
			// Macro
			new EditActionData(category: MacroCategory, action: new CancelMacroRecordingAction()),
			new EditActionData(category: MacroCategory, action: new PauseResumeMacroRecordingAction()),
			new EditActionData(category: MacroCategory, action: new RunMacroAction()),
			new EditActionData(category: MacroCategory, action: new ToggleMacroRecordingAction()),
			// Miscellaneous
			new EditActionData(category: MiscellaneousCategory, action: new CapitalizeAction()),
			new EditActionData(category: MiscellaneousCategory, action: new CommentLinesAction()),
			new EditActionData(category: MiscellaneousCategory, action: new ConvertSpacesToTabsAction()),
			new EditActionData(category: MiscellaneousCategory, action: new ConvertTabsToSpacesAction()),
			new EditActionData(category: MiscellaneousCategory, action: new DuplicateAction()),
			new EditActionData(category: MiscellaneousCategory, action: new FormatDocumentAction()),
			new EditActionData(category: MiscellaneousCategory, action: new FormatSelectionAction()),
			new EditActionData(category: MiscellaneousCategory, action: new IndentAction()),
			new EditActionData(category: MiscellaneousCategory, action: new InsertTabStopOrIndentAction()),
			new EditActionData(category: MiscellaneousCategory, action: new MakeLowercaseAction()),
			new EditActionData(category: MiscellaneousCategory, action: new MakeUppercaseAction()),
			new EditActionData(category: MiscellaneousCategory, action: new MoveSelectedLinesDownAction()),
			new EditActionData(category: MiscellaneousCategory, action: new MoveSelectedLinesUpAction()),
			new EditActionData(category: MiscellaneousCategory, action: new NormalizeLineTerminatorsToCRLFAction()),
			new EditActionData(category: MiscellaneousCategory, action: new NormalizeLineTerminatorsToLFAction()),
			new EditActionData(category: MiscellaneousCategory, action: new OutdentAction()),
			new EditActionData(category: MiscellaneousCategory, action: new RemoveTabStopOrOutdentAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TabifySelectedLinesAction()),
			new EditActionData(category: MiscellaneousCategory, action: new ToggleCharacterCasingAction()),
			new EditActionData(category: MiscellaneousCategory, action: new ToggleOverwriteModeAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TransposeCharactersAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TransposeLinesAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TransposeWordsAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TrimAllTrailingWhitespaceAction()),
			new EditActionData(category: MiscellaneousCategory, action: new TrimTrailingWhitespaceAction()),
			new EditActionData(category: MiscellaneousCategory, action: new UncommentLinesAction()),
			new EditActionData(category: MiscellaneousCategory, action: new UntabifySelectedLinesAction()),
			// Movement
			new EditActionData(category: MovementCategory, action: new MoveDownAction()),
			new EditActionData(category: MovementCategory, action: new MoveLeftAction()),
			new EditActionData(category: MovementCategory, action: new MovePageDownAction()),
			new EditActionData(category: MovementCategory, action: new MovePageUpAction()),
			new EditActionData(category: MovementCategory, action: new MoveRightAction()),
			new EditActionData(category: MovementCategory, action: new MoveToDocumentEndAction()),
			new EditActionData(category: MovementCategory, action: new MoveToDocumentStartAction()),
			new EditActionData(category: MovementCategory, action: new MoveToLineEndAction()),
			new EditActionData(category: MovementCategory, action: new MoveToLineStartAction()),
			new EditActionData(category: MovementCategory, action: new MoveToLineStartAfterIndentationAction()),
			new EditActionData(category: MovementCategory, action: new MoveToMatchingBracketAction()),
			new EditActionData(category: MovementCategory, action: new MoveToNextLineStartAfterIndentationAction()),
			new EditActionData(category: MovementCategory, action: new MoveToNextWordAction()),
			new EditActionData(category: MovementCategory, action: new MoveToPreviousLineStartAfterIndentationAction()),
			new EditActionData(category: MovementCategory, action: new MoveToPreviousWordAction()),
			new EditActionData(category: MovementCategory, action: new MoveToVisibleBottomAction()),
			new EditActionData(category: MovementCategory, action: new MoveToVisibleTopAction()),
			new EditActionData(category: MovementCategory, action: new MoveUpAction()),
			// Scroll
			new EditActionData(category: ScrollCategory, action: new ScrollDownAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollLeftAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollLineToVisibleBottomAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollLineToVisibleMiddleAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollLineToVisibleTopAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollPageDownAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollPageUpAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollRightAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollToDocumentEndAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollToDocumentStartAction()),
			new EditActionData(category: ScrollCategory, action: new ScrollUpAction()),
			// Search
			new EditActionData(category: SearchCategory, action: new FindAction()),
			new EditActionData(category: SearchCategory, action: new FindNextAction()),
			new EditActionData(category: SearchCategory, action: new FindNextSelectedAction()),
			new EditActionData(category: SearchCategory, action: new FindPreviousAction()),
			new EditActionData(category: SearchCategory, action: new FindPreviousSelectedAction()),
			new EditActionData(category: SearchCategory, action: new IncrementalSearchAction()),
			new EditActionData(category: SearchCategory, action: new ReplaceAction()),
			new EditActionData(category: SearchCategory, action: new ReverseIncrementalSearchAction()),
			// Selection
			new EditActionData(category: SelectionCategory, action: new CodeBlockSelectionContractAction()),
			new EditActionData(category: SelectionCategory, action: new CodeBlockSelectionExpandAction()),
			new EditActionData(category: SelectionCategory, action: new CollapseSelectionAction()),
			new EditActionData(category: SelectionCategory, action: new CollapseSelectionLeftAction()),
			new EditActionData(category: SelectionCategory, action: new CollapseSelectionRightAction()),
			new EditActionData(category: SelectionCategory, action: new SelectAllAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockDownAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockLeftAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockRightAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockToNextWordAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockToPreviousWordAction()),
			new EditActionData(category: SelectionCategory, action: new SelectBlockUpAction()),
			new EditActionData(category: SelectionCategory, action: new SelectDownAction()),
			new EditActionData(category: SelectionCategory, action: new SelectLeftAction()),
			new EditActionData(category: SelectionCategory, action: new SelectPageDownAction()),
			new EditActionData(category: SelectionCategory, action: new SelectPageUpAction()),
			new EditActionData(category: SelectionCategory, action: new SelectRightAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToDocumentEndAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToDocumentStartAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToLineEndAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToLineStartAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToLineStartAfterIndentationAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToMatchingBracketAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToNextWordAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToPreviousWordAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToVisibleBottomAction()),
			new EditActionData(category: SelectionCategory, action: new SelectToVisibleTopAction()),
			new EditActionData(category: SelectionCategory, action: new SelectUpAction()),
			new EditActionData(category: SelectionCategory, action: new SelectWordAction()),
		];

		// Find the default binding for each action
		foreach (var actionData in actionDataArray) {
			var commandLink = GetCommandLinkForEditAction(actionData.Action);
			if ((commandLink?.KeyBinding is not null)) {
				var sb = new StringBuilder();
				if (commandLink.KeyBinding.Modifiers.HasFlag(UI.WinForms.Input.ModifierKeys.Control))
					sb.Append("Ctrl+");
				if (commandLink.KeyBinding.Modifiers.HasFlag(UI.WinForms.Input.ModifierKeys.Shift))
					sb.Append("Shift+");
				if (commandLink.KeyBinding.Modifiers.HasFlag(UI.WinForms.Input.ModifierKeys.Alt))
					sb.Append("Alt+");
				sb.Append(commandLink.KeyBinding.Key.ToString());
				actionData.Key = sb.ToString();
			}
		}

		// Add each item to the view
		foreach (var actionData in actionDataArray) {
			var item = new ListViewItem([
				actionData.Category,
				actionData.Name ?? string.Empty,
				actionData.Key ?? string.Empty
			]);
			item.Tag = actionData;
			editActionsListView.Items.Add(item);
		}

		// Auto-resize the columns to fit the content
		editActionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
	}

	/// <summary>
	/// The <see cref="CommandLink"/>, if any, associated with the given <see cref="IEditAction"/>.
	/// </summary>
	/// <param name="editAction">The <see cref="IEditAction"/>.</param>
	/// <returns>Returns the matching <see cref="CommandLink"/> if found; otherwise <c>null</c>.</returns>
	private CommandLink? GetCommandLinkForEditAction(IEditAction editAction) {
		foreach (var commandLink in editor.CommandLinks) {
			var commandLinkAction = commandLink.Command as IEditAction;
			if ((commandLinkAction is not null) && (commandLinkAction.Key == editAction.Key))
				return commandLink;
		}
		return null;
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBindCustomActionButtonClick(object sender, EventArgs e) {
		// Unbind
		UnbindCustomEditAction();

		// Add a command link to action bound to Ctrl+P
		var command = new CustomAction();
		_customCommandLink = new CommandLink(command, new KeyBinding(UI.WinForms.Input.ModifierKeys.Control, Keys.P));
		editor.CommandLinks.Insert(0, _customCommandLink);

		// Notify user
		MessageBox.Show("Bound Ctrl+P to custom edit action.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
		editor.Focus();
	}

	/// <summary>
	/// Occurs when the mouse is double-clicked in the list view.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditActionsListViewMouseDoubleClick(object sender, MouseEventArgs e) {
		if (editActionsListView.SelectedItems.Count == 0)
			return;

		var actionData = editActionsListView.SelectedItems[0].Tag as EditActionData;
		if (actionData is not null) {
			// If the action can execute...
			if (actionData.Action.CanExecute(editor.ActiveView)) {
				// Focus the editor
				editor.Focus();

				// Execute it
				actionData.Action.Execute(editor.ActiveView);
			}
			else {
				// Display a message
				MessageBox.Show("The selected edit action cannot currently execute based on the current selection context.", "Cannot Execute", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnExecuteCustomActionButtonClick(object sender, EventArgs e) {
		editor.Focus();
		new CustomAction().Execute(editor.ActiveView);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">The sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnUnbindCustomActionButtonClick(object sender, EventArgs e) {
		// Unbind
		UnbindCustomEditAction();

		// Notify user
		MessageBox.Show("Unbound Ctrl+P.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
		editor.Focus();
	}

	/// <summary>
	/// Unbinds the custom edit action.
	/// </summary>
	private void UnbindCustomEditAction() {
		if (_customCommandLink is not null) {
			editor.CommandLinks.Remove(_customCommandLink);
			_customCommandLink = null;
		}
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
				editActionsListView,
				customActionsHeaderLabel,
				executeCustomActionButton,
				bindCustomActionButton,
				unbindCustomActionButton,
				customActionsDescriptionLabel,
				builtInActionsLabel
			};
			foreach (var control in manualFontControls)
				control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
		}

		// Resize the width of ListView columns
		DpiHelper.RescaleListViewColumns(editActionsListView, deviceDpiOld, deviceDpiNew);
	}

}
