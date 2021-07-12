---
title: "Default Key Bindings"
page-title: "Default Key Bindings - SyntaxEditor Input/Output Features"
order: 6
---
# Default Key Bindings

Many keyboard shortcuts are automatically bound to allow keyboard access to most of the built-in [edit actions](edit-actions.md).

The following tables describe the default key bindings that are in place when the [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor) control is created.  These can be modified by using the [SyntaxEditor](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor).`InputBindings` collection.

## Clipboard/Undo Edit Actions

| Key | Edit Action |
|-----|-----|
| Ctrl + C | [CopyToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CopyToClipboardAction) |
| Ctrl + Ins | [CopyToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CopyToClipboardAction) |
| Ctrl + X | [CutToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CutToClipboardAction) |
| Shift + Del | [CutToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CutToClipboardAction) |
| Ctrl + L | [CutLineToClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CutLineToClipboardAction) |
| Ctrl + V | [PasteFromClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.PasteFromClipboardAction) |
| Shift + Ins | [PasteFromClipboardAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.PasteFromClipboardAction) |
| Ctrl + Y | [RedoAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.RedoAction) |
| Ctrl + Shift + Z | [RedoAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.RedoAction) |
| Ctrl + Z | [UndoAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.UndoAction) |

## Deletion Edit Actions

| Key | Edit Action |
|-----|-----|
| Backspace | [BackspaceAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.BackspaceAction) |
| Shift + Backspace | [BackspaceAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.BackspaceAction) |
| Ctrl + Backspace | [BackspaceToPreviousWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.BackspaceToPreviousWordAction) |
| Del | [DeleteAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.DeleteAction) |
| Ctrl + Shift + L | [DeleteLineAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.DeleteLineAction) |
| Ctrl + Del | [DeleteToNextWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.DeleteToNextWordAction) |

## Insertion Edit Actions

| Key | Edit Action |
|-----|-----|
| Enter | [InsertLineBreakAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.InsertLineBreakAction) |
| Shift + Enter | [InsertLineBreakAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.InsertLineBreakAction) |
| Ctrl + Enter | [OpenLineAboveAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.OpenLineAboveAction) |
| Ctrl + Shift + Enter | [OpenLineBelowAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.OpenLineBelowAction) |

## IntelliPrompt Edit Actions

| Key | Edit Action |
|-----|-----|
| Ctrl + Space | [RequestIntelliPromptAutoCompleteAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.RequestIntelliPromptAutoCompleteAction) |
| Ctrl + Shift + Space | [RequestIntelliPromptParameterInfoSessionAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.RequestIntelliPromptParameterInfoSessionAction) |

## Miscellaneous Edit Actions

| Key | Edit Action |
|-----|-----|
| Tab | [InsertTabStopOrIndentAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.InsertTabStopOrIndentAction) |
| Shift + Tab | [RemoveTabStopOrOutdentAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.RemoveTabStopOrOutdentAction) |
| Ctrl + U | [MakeLowercaseAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MakeLowercaseAction) |
| Ctrl + Shift + U | [MakeUppercaseAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MakeUppercaseAction) |
| Insert | [ToggleOverwriteModeAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.ToggleOverwriteModeAction) |
| Ctrl + T | [TransposeCharactersAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.TransposeCharactersAction) |
| Ctrl + Shift + T | [TransposeWordsAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.TransposeWordsAction) |
| Shift + Alt + T | [TransposeLinesAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.TransposeLinesAction) |
| Alt + Up | [MoveSelectedLinesUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveSelectedLinesUpAction) |
| Alt + Down | [MoveSelectedLinesDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveSelectedLinesDownAction) |

## Movement Edit Actions

| Key | Edit Action |
|-----|-----|
| Down | [MoveDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveDownAction) |
| Up  | [MoveUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveUpAction) |
| Left | [MoveLeftAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveLeftAction) |
| Right | [MoveRightAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveRightAction) |
| Ctrl + Left | [MoveToPreviousWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToPreviousWordAction) |
| Ctrl + Right | [MoveToNextWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToNextWordAction) |
| Home | [MoveToLineStartAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToLineStartAction) |
| End | [MoveToLineEndAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToLineEndAction) |
| Ctrl + Home | [MoveToDocumentStartAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToDocumentStartAction) |
| Ctrl + End | [MoveToDocumentEndAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToDocumentEndAction) |
| Page Up | [MovePageUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MovePageUpAction) |
| Page Down | [MovePageDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MovePageDownAction) |
| Ctrl + Page Up | [MoveToVisibleTopAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToVisibleTopAction) |
| Ctrl + Page Down | [MoveToVisibleBottomAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToVisibleBottomAction) |
| Ctrl + ] | [MoveToMatchingBracketAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.MoveToMatchingBracketAction) |

## Scroll Edit Actions

| Key | Edit Action |
|-----|-----|
| Ctrl + Down | [ScrollDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.ScrollDownAction) |
| Ctrl + Up | [ScrollUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.ScrollUpAction) |

## Search Edit Actions

| Key | Edit Action |
|-----|-----|
| Ctrl + F | [FindAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.FindAction) |
| F3  | [FindNextAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.FindNextAction) |
| Ctrl + F3 | [FindNextSelectedAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.FindNextSelectedAction) |
| Shift + F3 | [FindPreviousAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.FindPreviousAction) |
| Ctrl + Shift + F3 | [FindPreviousSelectedAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.FindPreviousSelectedAction) |
| Ctrl + H | [ReplaceAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.ReplaceAction) |
| Ctrl + I | [IncrementalSearchAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.IncrementalSearchAction) |
| Ctrl + Shift + I | [ReverseIncrementalSearchAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.ReverseIncrementalSearchAction) |

## Selection Edit Actions

| Key | Edit Action |
|-----|-----|
| Ctrl + Shift + Num- | [CodeBlockSelectionContractAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CodeBlockSelectionContractAction) |
| Ctrl + Shift + Num+ | [CodeBlockSelectionExpandAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CodeBlockSelectionExpandAction) |
| Escape | [CollapseSelectionAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.CollapseSelectionAction) |
| Shift + Down | [SelectDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectDownAction) |
| Shift + Up | [SelectUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectUpAction) |
| Shift + Left | [SelectLeftAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectLeftAction) |
| Shift + Right | [SelectRightAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectRightAction) |
| Ctrl + Shift + Left | [SelectToPreviousWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToPreviousWordAction) |
| Ctrl + Shift + Right | [SelectBlockToNextWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockToNextWordAction) |
| Shift + Home | [SelectToLineStartAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToLineStartAction) |
| Shift + End | [SelectToLineEndAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToLineEndAction) |
| Ctrl + Shift + Home | [SelectToDocumentStartAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToDocumentStartAction) |
| Ctrl + Shift + End | [SelectToDocumentEndAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToDocumentEndAction) |
| Shift + Page Up | [SelectPageUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectPageUpAction) |
| Shift + Page Down | [SelectPageDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectPageDownAction) |
| Ctrl + Shift + Page Up | [SelectToVisibleTopAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToVisibleTopAction) |
| Ctrl + Shift + Page Down | [SelectToVisibleBottomAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToVisibleBottomAction) |
| Ctrl + A | [SelectAllAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectAllAction) |
| Ctrl + Shift + W | [SelectWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectWordAction) |
| Ctrl + Shift + ] | [SelectToMatchingBracketAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectToMatchingBracketAction) |
| Shift + Alt + Down | [SelectBlockDownAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockDownAction) |
| Shift + Alt + Up | [SelectBlockUpAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockUpAction) |
| Shift + Alt + Left | [SelectBlockLeftAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockLeftAction) |
| Shift + Alt + Right | [SelectBlockRightAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockRightAction) |
| Ctrl + Shift + Alt + Left | [SelectBlockToPreviousWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockToPreviousWordAction) |
| Ctrl + Shift + Alt + Right | [SelectBlockToNextWordAction](xref:ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditActions.SelectBlockToNextWordAction) |
