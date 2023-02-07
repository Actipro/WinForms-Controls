using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.Commands;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditActions {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private CommandLink customCommandLink;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize component initialization
			BuildListView();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Binds data to the list.
		/// </summary>
		private void BuildListView() {
			string ClipboardCategory = "Clipboard / Undo";
			string DeletionCategory = "Deletion";
			string InsertionCategory = "Insertion";
			string IntelliPromptCategory = "IntelliPrompt";
			string MacroCategory = "Macro Recording";
			string MiscellaneousCategory = "Miscellaneous";
			string MovementCategory = "Movement";
			string ScrollCategory = "Scroll";
			string SearchCategory = "Search";
			string SelectionCategory = "Selection";

			EditActionData[] actionDataArray = new EditActionData[] {
				// Clipboard/undo
				new EditActionData() { Category = ClipboardCategory, Action = new CopyAndAppendToClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new CopyToClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new CutAndAppendToClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new CutLineToClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new CutToClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new PasteFromClipboardAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new RedoAction() },
				new EditActionData() { Category = ClipboardCategory, Action = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.UndoAction() },
				// Deletion
				new EditActionData() { Category = DeletionCategory, Action = new BackspaceAction() },
				new EditActionData() { Category = DeletionCategory, Action = new BackspaceToPreviousWordAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteBlankLinesAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteHorizontalWhitespaceAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteLineAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteToLineEndAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteToLineStartAction() },
				new EditActionData() { Category = DeletionCategory, Action = new DeleteToNextWordAction() },
				// Insertion
				new EditActionData() { Category = InsertionCategory, Action = new InsertLineBreakAction() },
				new EditActionData() { Category = InsertionCategory, Action = new OpenLineAboveAction() },
				new EditActionData() { Category = InsertionCategory, Action = new OpenLineBelowAction() },
				new EditActionData() { Category = InsertionCategory, Action = new TypingAction("*Typing*", false) },
				// IntelliPrompt
				new EditActionData() { Category = IntelliPromptCategory, Action = new RequestIntelliPromptAutoCompleteAction() },
				new EditActionData() { Category = IntelliPromptCategory, Action = new RequestIntelliPromptCompletionSessionAction() },
				new EditActionData() { Category = IntelliPromptCategory, Action = new RequestIntelliPromptParameterInfoSessionAction() },
				new EditActionData() { Category = IntelliPromptCategory, Action = new RequestIntelliPromptQuickInfoSessionAction() },
				// Macro
				new EditActionData() { Category = MacroCategory, Action = new CancelMacroRecordingAction() },
				new EditActionData() { Category = MacroCategory, Action = new PauseResumeMacroRecordingAction() },
				new EditActionData() { Category = MacroCategory, Action = new RunMacroAction() },
				new EditActionData() { Category = MacroCategory, Action = new ToggleMacroRecordingAction() },
				// Miscellaneous
				new EditActionData() { Category = MiscellaneousCategory, Action = new CapitalizeAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new CommentLinesAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new ConvertSpacesToTabsAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new ConvertTabsToSpacesAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new DuplicateAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new FormatDocumentAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new FormatSelectionAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new IndentAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new InsertTabStopOrIndentAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new MakeLowercaseAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new MakeUppercaseAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new MoveSelectedLinesDownAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new MoveSelectedLinesUpAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new OutdentAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new RemoveTabStopOrOutdentAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TabifySelectedLinesAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new ToggleCharacterCasingAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new ToggleOverwriteModeAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TransposeCharactersAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TransposeLinesAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TransposeWordsAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TrimAllTrailingWhitespaceAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new TrimTrailingWhitespaceAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new UncommentLinesAction() },
				new EditActionData() { Category = MiscellaneousCategory, Action = new UntabifySelectedLinesAction() },
				// Movement
				new EditActionData() { Category = MovementCategory, Action = new MoveDownAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveLeftAction() },
				new EditActionData() { Category = MovementCategory, Action = new MovePageDownAction() },
				new EditActionData() { Category = MovementCategory, Action = new MovePageUpAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveRightAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToDocumentEndAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToDocumentStartAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToLineEndAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToLineStartAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToLineStartAfterIndentationAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToMatchingBracketAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToNextLineStartAfterIndentationAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToNextWordAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToPreviousLineStartAfterIndentationAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToPreviousWordAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToVisibleBottomAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveToVisibleTopAction() },
				new EditActionData() { Category = MovementCategory, Action = new MoveUpAction() },
				// Scroll
				new EditActionData() { Category = ScrollCategory, Action = new ScrollDownAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollLeftAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollLineToVisibleBottomAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollLineToVisibleMiddleAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollLineToVisibleTopAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollPageDownAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollPageUpAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollRightAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollToDocumentEndAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollToDocumentStartAction() },
				new EditActionData() { Category = ScrollCategory, Action = new ScrollUpAction() },
				// Search
				new EditActionData() { Category = SearchCategory, Action = new FindAction() },
				new EditActionData() { Category = SearchCategory, Action = new FindNextAction() },
				new EditActionData() { Category = SearchCategory, Action = new FindNextSelectedAction() },
				new EditActionData() { Category = SearchCategory, Action = new FindPreviousAction() },
				new EditActionData() { Category = SearchCategory, Action = new FindPreviousSelectedAction() },
				new EditActionData() { Category = SearchCategory, Action = new IncrementalSearchAction() },
				new EditActionData() { Category = SearchCategory, Action = new ReplaceAction() },
				new EditActionData() { Category = SearchCategory, Action = new ReverseIncrementalSearchAction() },
				// Selection
				new EditActionData() { Category = SelectionCategory, Action = new CodeBlockSelectionContractAction() },
				new EditActionData() { Category = SelectionCategory, Action = new CodeBlockSelectionExpandAction() },
				new EditActionData() { Category = SelectionCategory, Action = new CollapseSelectionAction() },
				new EditActionData() { Category = SelectionCategory, Action = new CollapseSelectionLeftAction() },
				new EditActionData() { Category = SelectionCategory, Action = new CollapseSelectionRightAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectAllAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockDownAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockLeftAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockRightAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockToNextWordAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockToPreviousWordAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectBlockUpAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectDownAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectLeftAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectPageDownAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectPageUpAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectRightAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToDocumentEndAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToDocumentStartAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToLineEndAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToLineStartAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToLineStartAfterIndentationAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToMatchingBracketAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToNextWordAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToPreviousWordAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToVisibleBottomAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectToVisibleTopAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectUpAction() },
				new EditActionData() { Category = SelectionCategory, Action = new SelectWordAction() },
			};

			// Find the default binding for each action
			foreach (EditActionData actionData in actionDataArray) {
				var commandLink = GetCommandLinkForEditAction(actionData.Action);
				if (commandLink != null) {
					if (commandLink.KeyBinding != null) {
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
			}

			// Add each item to the view
			foreach (EditActionData actionData in actionDataArray) {
				var item = new ListViewItem(new string[] { actionData.Category, actionData.Name, actionData.Key });
				item.Tag = actionData;
				editActionsListView.Items.Add(item);
			}

			// Auto-resize the columns to fit the content
			editActionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		/// <summary>
		/// Gets the <see cref="CommandLink"/> (if any) associated with the given <see cref="IEditAction"/>.
		/// </summary>
		/// <param name="editAction">The <see cref="IEditAction"/>.</param>
		/// <returns>Returns the matching <see cref="CommandLink"/> if found; otherwise <c>null</c>.</returns>
		private CommandLink GetCommandLinkForEditAction(IEditAction editAction) {
			foreach (var commandLink in editor.CommandLinks.OfType<CommandLink>()) {
				var commandLinkAction = commandLink.Command as IEditAction;
				if ((commandLinkAction != null) && (commandLinkAction.Key == editAction.Key))
					return commandLink;
			}
			return null;
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnBindCustomActionButtonClick(object sender, EventArgs e) {
			// Unbind
			this.UnbindCustomEditAction();

			// Add a command link to action bound to Ctrl+P
			var command = new CustomAction();
			customCommandLink = new CommandLink(command, new KeyBinding(UI.WinForms.Input.ModifierKeys.Control, Keys.P));
			editor.CommandLinks.Insert(0, customCommandLink);

			// Notify user
			MessageBox.Show("Bound Ctrl+P to custom edit action.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the mouse is double-clicked in the list view.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
		private void OnEditActionsListViewMouseDoubleClick(object sender, MouseEventArgs e) {
			if (editActionsListView.SelectedItems.Count == 0)
				return;

			EditActionData actionData = editActionsListView.SelectedItems[0].Tag as EditActionData;
			if (actionData != null) {
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
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnExecuteCustomActionButtonClick(object sender, EventArgs e) {
			editor.Focus();
			new CustomAction().Execute(editor.ActiveView);
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUnbindCustomActionButtonClick(object sender, EventArgs e) {
			// Unbind
			this.UnbindCustomEditAction();

			// Notify user
			MessageBox.Show("Unbound Ctrl+P.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			editor.Focus();
		}

		/// <summary>
		/// Unbinds the custom edit action.
		/// </summary>
		private void UnbindCustomEditAction() {
			if (customCommandLink != null) {
				editor.CommandLinks.Remove(customCommandLink);
				customCommandLink = null;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

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

}
