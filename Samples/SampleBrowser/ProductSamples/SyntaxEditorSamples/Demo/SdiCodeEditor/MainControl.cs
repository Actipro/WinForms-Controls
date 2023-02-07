using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.LLParser;
using ActiproSoftware.Text.Searching;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Outlining;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.Demo.SdiCodeEditor {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl, IProductSample {
		
		private bool				hasPendingParseData;
		
		// Project assemblies used by C#/VB in the .NET Languages Add-on
		private ActiproSoftware.Text.Languages.DotNet.Reflection.IProjectAssembly cSharpProjectAssembly;
		private ActiproSoftware.Text.Languages.DotNet.Reflection.IProjectAssembly vbProjectAssembly;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize initialization
			DpiHelper.RescaleListViewColumns(errorListView, DpiHelper.DefaultDeviceDpi, DpiHelper.GetSystemDeviceDpi());

			// Auto-hide tool windows
			dockManager.AutoHideAllToolWindowsDockedInHost();

			// Set the AST output tab stop width
			astOutputEditor.SetTabStopWidth(1);
			
			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher and an ambient
			//   code repository within your application startup code, and add related cleanup in your
			//   application OnExit code.  These steps are essential to having the add-on perform well.
			//

			// Initialize the project assemblies for .NET Languages Add-on languages
			cSharpProjectAssembly = new ActiproSoftware.Text.Languages.CSharp.Implementation.CSharpProjectAssembly("SampleBrowser");
			vbProjectAssembly = new ActiproSoftware.Text.Languages.VB.Implementation.VBProjectAssembly("SampleBrowser");
			var assemblyLoader = new BackgroundWorker();
			assemblyLoader.DoWork += DotNetProjectAssemblyReferenceLoader;
			assemblyLoader.RunWorkerAsync();

			// Load the .NET Languages Add-on C# language (sold separately) by default
			this.LoadLanguage("C# (in .NET Languages Add-on)");

			// Register display item classification types
			new DisplayItemClassificationTypeProvider().RegisterAll();
		}

		private void DotNetProjectAssemblyReferenceLoader(object sender, DoWorkEventArgs e) {
			// Add some common assemblies for reflection (any custom assemblies could be added using various Add overloads instead)
			SyntaxEditorHelper.AddCommonDotNetSystemAssemblyReferences(cSharpProjectAssembly);
			SyntaxEditorHelper.AddCommonDotNetSystemAssemblyReferences(vbProjectAssembly);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Appends a message to the events <see cref="ListBox"/>.
		/// </summary>
		/// <param name="text">The text to append.</param>
		private void AppendMessage(string text) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(text);
		}

		/// <summary>
		/// Loads a language, with example text.
		/// </summary>
		/// <param name="language">The <see cref="ISyntaxLanguage"/> to load.</param>
		private void LoadLanguage(ISyntaxLanguage language) {
			if (language == null)
				return;

			// Load the language
			editor.Document.Language = language;

			// Get example text
			IExampleTextProvider exampleTextProvider = editor.Document.Language.GetExampleTextProvider();
			if ((exampleTextProvider != null) && (exampleTextProvider.ExampleText != null))
				editor.Document.SetText(exampleTextProvider.ExampleText);

			// Update symbol selector visibility
			symbolSelector.Visible = (language.GetNavigableSymbolProvider() != null);
			symbolSelector.AreMemberSymbolsSupported = (language.Key != "Python");
		}

		/// <summary>
		/// Loads a language definition.
		/// </summary>
		/// <param name="languageKey">The key that identifies the language.</param>
		private void LoadLanguage(string languageKey) {
			// Clear errors and document outline
			this.RefreshErrorList(null);
			astOutputEditor.Text = "(Language may not have AST building features)";

			switch (languageKey) {
				case "Assembly":
					this.LoadLanguageDefinitionFromFile("Assembly.langdef");
					break;
				case "Batch file":
					this.LoadLanguageDefinitionFromFile("BatchFile.langdef");
					break;
				case "C":
					this.LoadLanguageDefinitionFromFile("C.langdef");
					break;
				case "C#":
					this.LoadLanguageDefinitionFromFile("CSharp.langdef");
					editor.Document.Language.RegisterLineCommenter(new LineBasedLineCommenter() { StartDelimiter = "//" });
					break;
				case "C# (in .NET Languages Add-on)": {
					// .NET Languages Add-on C# language
					var language = new ActiproSoftware.Text.Languages.CSharp.Implementation.CSharpSyntaxLanguage();
					language.RegisterService<ActiproSoftware.Text.Languages.DotNet.Reflection.IProjectAssembly>(cSharpProjectAssembly);
					this.LoadLanguage(language);

					// Register a code snippet provider that has several snippets available
					var snippetFolder = SyntaxEditorHelper.LoadSampleCSharpCodeSnippetsFromResources();
					editor.Document.Language.RegisterService(new ActiproSoftware.Text.Languages.CSharp.Implementation.CSharpCodeSnippetProvider() { RootFolder = snippetFolder });
					break;
				}
				case "C++":
					this.LoadLanguageDefinitionFromFile("Cpp.langdef");
					break;
				case "CSS":
					this.LoadLanguageDefinitionFromFile("Css.langdef");
					break;
				case "Custom...":
					BeginInvoke((Action)(() => { this.LoadLanguageDefinitionFromFile(null); }));
					break;
				case "HTML":
					this.LoadLanguageDefinitionFromFile("Html.langdef");
					editor.Document.Language.RegisterLineCommenter(new RangeLineCommenter() { StartDelimiter = "<!--", EndDelimiter = "-->" });
					break;
				case "INI file":
					this.LoadLanguageDefinitionFromFile("IniFile.langdef");
					break;
				case "Java":
					this.LoadLanguageDefinitionFromFile("Java.langdef");
					editor.Document.Language.RegisterLineCommenter(new LineBasedLineCommenter() { StartDelimiter = "//" });
					break;
				case "JavaScript":
					this.LoadLanguageDefinitionFromFile("JavaScript.langdef");
					editor.Document.Language.RegisterLineCommenter(new LineBasedLineCommenter() { StartDelimiter = "//" });
					break;
				case "JavaScript (in Web Languages Add-on)":
					// Web Languages Add-on JavaScript language
					this.LoadLanguage(new ActiproSoftware.Text.Languages.JavaScript.Implementation.JavaScriptSyntaxLanguage());
					break;
				case "JSON (in Web Languages Add-on)":
					// Web Languages Add-on JSON language
					this.LoadLanguage(new ActiproSoftware.Text.Languages.JavaScript.Implementation.JsonSyntaxLanguage());
					break;
				case "JSON with Comments (in Web Languages Add-on)":
					// Web Languages Add-on JSON language
					this.LoadLanguage(new ActiproSoftware.Text.Languages.JavaScript.Implementation.JsonSyntaxLanguage(areCommentsSupported: true));
					break;
				case "Lua":
					this.LoadLanguageDefinitionFromFile("Lua.langdef");
					break;
				case "Markdown":
					this.LoadLanguageDefinitionFromFile("Markdown.langdef");
					break;
				case "MSIL":
					this.LoadLanguageDefinitionFromFile("Msil.langdef");
					break;
				case "Pascal":
					this.LoadLanguageDefinitionFromFile("Pascal.langdef");
					break;
				case "Perl":
					this.LoadLanguageDefinitionFromFile("Perl.langdef");
					break;
				case "PHP":
					this.LoadLanguageDefinitionFromFile("Php.langdef");
					break;
				case "PowerShell":
					this.LoadLanguageDefinitionFromFile("PowerShell.langdef");
					break;
				case "Python":
					this.LoadLanguageDefinitionFromFile("Python.langdef");
					break;
				case "Python (in Python Language Add-on)":
					// Python Language Add-on Python language
					this.LoadLanguage(new ActiproSoftware.Text.Languages.Python.Implementation.PythonSyntaxLanguage());
					break;
				case "RTF":
					this.LoadLanguageDefinitionFromFile("Rtf.langdef");
					break;
				case "Ruby":
					this.LoadLanguageDefinitionFromFile("Ruby.langdef");
					break;
				case "SQL":
					this.LoadLanguageDefinitionFromFile("Sql.langdef");
					break;
				case "VB":
					this.LoadLanguageDefinitionFromFile("VB.langdef");
					editor.Document.Language.RegisterLineCommenter(new LineBasedLineCommenter() { StartDelimiter = "'" });
					break;
				case "VB (in .NET Languages Add-on)": {
					// .NET Languages Add-on VB language
					var language = new ActiproSoftware.Text.Languages.VB.Implementation.VBSyntaxLanguage();
					language.RegisterService<ActiproSoftware.Text.Languages.DotNet.Reflection.IProjectAssembly>(vbProjectAssembly);
					this.LoadLanguage(language);

					// Register a code snippet provider that has several snippets available
					var snippetFolder = SyntaxEditorHelper.LoadSampleVBCodeSnippetsFromResources();
					editor.Document.Language.RegisterService(new ActiproSoftware.Text.Languages.VB.Implementation.VBCodeSnippetProvider() { RootFolder = snippetFolder });
					break;
				}
				case "VBScript":
					this.LoadLanguageDefinitionFromFile("VBScript.langdef");
					break;
				case "XAML":
					this.LoadLanguageDefinitionFromFile("Xaml.langdef");
					editor.Document.Language.RegisterLineCommenter(new RangeLineCommenter() { StartDelimiter = "<!--", EndDelimiter = "-->" });
					break;
				case "XML":
					this.LoadLanguageDefinitionFromFile("Xml.langdef");
					editor.Document.Language.RegisterLineCommenter(new RangeLineCommenter() { StartDelimiter = "<!--", EndDelimiter = "-->" });
					break;
				case "XML (in Web Languages Add-on)":
					// Web Languages Add-on XML language
					this.LoadLanguage(new ActiproSoftware.Text.Languages.Xml.Implementation.XmlSyntaxLanguage());
					break;
				default:
					// Plain text
					this.LoadLanguage(SyntaxLanguage.PlainText);
					break;
			}
		}
		
		/// <summary>
		/// Loads a language definition from a file.
		/// </summary>
		/// <param name="filename">The filename.</param>
		private void LoadLanguageDefinitionFromFile(string filename) {
			if (String.IsNullOrEmpty(filename)) {
				// Show a file open dialog
				var dialog = new OpenFileDialog();
				dialog.CheckFileExists = true;
				dialog.Multiselect = false;
				dialog.Filter = "Language definition files (*.langdef)|*.langdef|All files (*.*)|*.*";
				if (dialog.ShowDialog() != DialogResult.OK)
					return;

				// Open a language definition
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					SyntaxLanguageDefinitionSerializer serializer = new SyntaxLanguageDefinitionSerializer();
					this.LoadLanguage(serializer.LoadFromStream(stream));
				}
			}
			else {
				// Load an embedded resource .langdef file
				this.LoadLanguage(SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream(filename));
			}
		}
		
		/// <summary>
		/// Creates a new file.
		/// </summary>
		private void NewFile() {
			editor.Document.SetText(String.Empty);
		}
		
		/// <summary>
		/// Occurs when the control is double-clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnErrorListViewMouseDoubleClick(object sender, MouseEventArgs e) {
			var item = errorListView.HitTest(e.X, e.Y).Item;
			if (item != null) {
				var error = item.Tag as IParseError;
				if (error != null) {
					editor.ActiveView.Selection.StartPosition = error.PositionRange.StartPosition;
					editor.Focus();
				}
			}
		}
		
		/// <summary>
		/// Occurs when the drop-down menu is opening.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFontSizeToolStripMenuItemDropDownOpening(object sender, EventArgs e) {
			fontSize10ToolStripMenuItem.Checked = (editor.Font.Size == 10);
			fontSize14ToolStripMenuItem.Checked = (editor.Font.Size == 14);
			fontSize18ToolStripMenuItem.Checked = (editor.Font.Size == 18);
		}
		
		/// <summary>
		/// Occurs when the menustrip item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFontSizeToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			editor.Font = new Font(editor.Font.FontFamily, int.Parse(e.ClickedItem.Text));
		}

		/// <summary>
		/// Occurs when the menustrip item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnLanguageToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			if ((e.ClickedItem.Enabled) && (e.ClickedItem is ToolStripMenuItem))
				this.LoadLanguage(e.ClickedItem.Text);
		}

		/// <summary>
		/// Occurs when the toolstrip item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnMainToolStripItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			try {
				switch (e.ClickedItem.Name) {
					case nameof(cancelMacroToolStripButton):
					case nameof(cancelRecordingToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.CancelMacroRecording);
						break;
					case nameof(capitalizeToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ChangeCharacterCasing(ActiproSoftware.Text.CharacterCasing.Normal);
						break;
					case nameof(commentLinesToolStripButton):
					case nameof(commentLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.CommentLines();
						break;
					case nameof(convertSpacesToTabsToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ConvertSpacesToTabs();
						break;
					case nameof(convertTabsToSpacesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ConvertTabsToSpaces();
						break;
					case nameof(copyAppendToolStripMenuItem):
						editor.ActiveView.CopyAndAppendToClipboard();
						break;
					case nameof(copyToolStripButton):
					case nameof(copyToolStripMenuItem):
						editor.ActiveView.CopyToClipboard();
						break;
					case nameof(cutAppendToolStripMenuItem):
						editor.ActiveView.CutAndAppendToClipboard();
						break;
					case nameof(cutToolStripButton):
					case nameof(cutToolStripMenuItem):
						editor.ActiveView.CutToClipboard();
						break;
					case nameof(darkThemeToolStripMenuItem):
						SetColorScheme(WindowsColorSchemeType.MetroDark);
						break;
					case nameof(decreaseLineIndentToolStripMenuItem):
						editor.ActiveView.TextChangeActions.Outdent();
						break;
					case nameof(deleteToolStripButton):
					case nameof(deleteToolStripMenuItem):
						editor.ActiveView.TextChangeActions.Delete();
						break;
					case nameof(deleteBlankLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.DeleteBlankLines();
						break;
					case nameof(deleteHorizontalWhitespaceToolStripMenuItem):
						editor.ActiveView.TextChangeActions.DeleteHorizontalWhitespace();
						break;
					case nameof(deleteLineToolStripMenuItem):
						editor.ActiveView.TextChangeActions.DeleteLine();
						break;
					case nameof(duplicateToolStripMenuItem):
						editor.ActiveView.TextChangeActions.Duplicate();
						break;
					case nameof(exitToolStripMenuItem):
						BeginInvoke((Action)(() => { MessageBox.Show("Close the application here."); }));
						break;
					case nameof(formatDocumentToolStripButton):
					case nameof(formatDocumentToolStripMenuItem):
						editor.ActiveView.TextChangeActions.FormatDocument();
						break;
					case nameof(formatSelectionToolStripButton):
					case nameof(formatSelectionToolStripMenuItem):
						editor.ActiveView.TextChangeActions.FormatSelection();
						break;
					case nameof(increaseLineIndentToolStripMenuItem):
						editor.ActiveView.TextChangeActions.Indent();
						break;
					case nameof(incrementalSearchToolStripMenuItem):
						editor.ActiveView.IsIncrementalSearchActive = true;
						break;
					case nameof(importVisualStudioSettingsToolStripMenuItem):
						BeginInvoke((Action)(() => { this.OpenVSSettingsFile(); }));
						break;
					case nameof(insertLorumIpsumToolStripMenuItem):
						editor.ActiveView.SelectedText = new ActiproSoftware.Text.Utility.LipsumGenerator().GenerateParagraph(true, 30);
						break;
					case nameof(insertSnippetToolStripButton):
					case nameof(insertSnippetToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestInsertSnippetSession();
						break;
					case nameof(lightThemeToolStripMenuItem):
						SetColorScheme(WindowsColorSchemeType.MetroLight);
						break;
					case nameof(makeLowercaseToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ChangeCharacterCasing(ActiproSoftware.Text.CharacterCasing.Lower);
						break;
					case nameof(makeUppercaseToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ChangeCharacterCasing(ActiproSoftware.Text.CharacterCasing.Upper);
						break;
					case nameof(moveSelectedLinesDownToolStripMenuItem):
						editor.ActiveView.TextChangeActions.MoveSelectedLinesDown();
						break;
					case nameof(moveSelectedLinesUpToolStripMenuItem):
						editor.ActiveView.TextChangeActions.MoveSelectedLinesUp();
						break;
					case nameof(newDocumentToolStripButton):
					case nameof(newToolStripMenuItem):
						this.NewFile();
						break;
					case nameof(openDocumentToolStripButton):
					case nameof(openToolStripMenuItem):
						BeginInvoke((Action)(() => { this.OpenFile(); }));
						break;
					case nameof(pasteToolStripButton):
					case nameof(pasteToolStripMenuItem):
						editor.ActiveView.PasteFromClipboard();
						break;
					case nameof(pauseRecordingToolStripButton):
					case nameof(pauseRecordingToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.PauseResumeMacroRecording);
						break;
					case nameof(printPreviewToolStripButton):
					case nameof(printPreviewToolStripMenuItem):
						editor.ShowPrintPreviewDialog();
						break;
					case nameof(printToolStripButton):
					case nameof(printToolStripMenuItem):
						editor.ShowPrintDialog();
						break;
					case nameof(recordMacroToolStripButton):
					case nameof(recordMacroToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.ToggleMacroRecording);
						break;
					case nameof(redoToolStripButton):
					case nameof(redoToolStripMenuItem):
						editor.Document.UndoHistory.Redo();
						break;
					case nameof(requestIntelliPromptAutoCompleteToolStripButton):
					case nameof(completeWordToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestAutoComplete();
						break;
					case nameof(requestIntelliPromptCompletionSessionToolStripButton):
					case nameof(completionListToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestCompletionSession();
						break;
					case nameof(requestIntelliPromptParameterInfoSessionToolStripButton):
					case nameof(parameterInfoToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestParameterInfoSession();
						break;
					case nameof(requestIntelliPromptQuickInfoSessionToolStripButton):
					case nameof(quickInfoToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestQuickInfoSession();
						break;
					case nameof(runMacroToolStripButton):
					case nameof(runRecordedMacroToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.RunMacro);
						break;
					case nameof(saveDocumentToolStripButton):
					case nameof(saveToolStripMenuItem):
						// NOTE: Save the document here and flag as not modified
						BeginInvoke((Action)(() => { MessageBox.Show("Save the document here."); }));
						editor.Document.IsModified = false;
						break;
					case nameof(selectAllToolStripMenuItem):
						editor.ActiveView.Selection.SelectAll();
						break;
					case nameof(surroundWithToolStripMenuItem):
						editor.ActiveView.IntelliPrompt.RequestSurroundWithSession();
						break;
					case nameof(tabifySelectedLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TabifySelectedLines();
						break;
					case nameof(toggleCharacterCasingToolStripMenuItem):
						editor.ActiveView.TextChangeActions.ToggleCharacterCasing();
						break;
					case nameof(transposeCharactersToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TransposeCharacters();
						break;
					case nameof(transposeLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TransposeLines();
						break;
					case nameof(transposeWordsToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TransposeWords();
						break;
					case nameof(trimAllTrailingWhitespaceToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TrimAllTrailingWhitespace();
						break;
					case nameof(trimTrailingWhitespaceToolStripMenuItem):
						editor.ActiveView.TextChangeActions.TrimTrailingWhitespace();
						break;
					case nameof(uncommentLinesToolStripButton):
					case nameof(uncommentLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.UncommentLines();
						break;
					case nameof(undoToolStripButton):
					case nameof(undoToolStripMenuItem):
						editor.Document.UndoHistory.Undo();
						break;
					case nameof(untabifySelectedLinesToolStripMenuItem):
						editor.ActiveView.TextChangeActions.UntabifySelectedLines();
						break;
					// View menu
					case nameof(indicatorMarginVisibleToolStripMenuItem):
						indicatorMarginVisibleToolStripMenuItem.Checked = !indicatorMarginVisibleToolStripMenuItem.Checked;
						editor.IsIndicatorMarginVisible = indicatorMarginVisibleToolStripMenuItem.Checked;
						break;
					case nameof(lineNumberMarginVisibleToolStripMenuItem):
						lineNumberMarginVisibleToolStripMenuItem.Checked = !lineNumberMarginVisibleToolStripMenuItem.Checked;
						editor.IsLineNumberMarginVisible = lineNumberMarginVisibleToolStripMenuItem.Checked;
						break;
					case nameof(outliningMarginVisibleToolStripMenuItem):
						outliningMarginVisibleToolStripMenuItem.Checked = !outliningMarginVisibleToolStripMenuItem.Checked;
						editor.IsOutliningMarginVisible = outliningMarginVisibleToolStripMenuItem.Checked;
						break;
					case nameof(rulerMarginVisibleToolStripMenuItem):
						rulerMarginVisibleToolStripMenuItem.Checked = !rulerMarginVisibleToolStripMenuItem.Checked;
						editor.IsRulerMarginVisible = rulerMarginVisibleToolStripMenuItem.Checked;
						break;
					case nameof(selectionMarginVisibleToolStripMenuItem):
						selectionMarginVisibleToolStripMenuItem.Checked = !selectionMarginVisibleToolStripMenuItem.Checked;
						editor.IsSelectionMarginVisible = selectionMarginVisibleToolStripMenuItem.Checked;
						break;
					case nameof(wordWrapToolStripMenuItem):
						wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
						editor.IsWordWrapEnabled = wordWrapToolStripMenuItem.Checked;
						break;
					case nameof(wordWrapGlyphsVisibleToolStripMenuItem):
						wordWrapGlyphsVisibleToolStripMenuItem.Checked = !wordWrapGlyphsVisibleToolStripMenuItem.Checked;
						editor.AreWordWrapGlyphsVisible = wordWrapGlyphsVisibleToolStripMenuItem.Checked;
						break;
					case nameof(whitespaceVisibleToolStripMenuItem):
						whitespaceVisibleToolStripMenuItem.Checked = !whitespaceVisibleToolStripMenuItem.Checked;
						editor.IsWhitespaceVisible = whitespaceVisibleToolStripMenuItem.Checked;
						break;
					case nameof(canScrollPastDocumentEndToolStripMenuItem):
						canScrollPastDocumentEndToolStripMenuItem.Checked = !canScrollPastDocumentEndToolStripMenuItem.Checked;
						editor.CanScrollPastDocumentEnd = canScrollPastDocumentEndToolStripMenuItem.Checked;
						break;
					case nameof(virtualSpaceAtLineEndToolStripMenuItem):
						virtualSpaceAtLineEndToolStripMenuItem.Checked = !virtualSpaceAtLineEndToolStripMenuItem.Checked;
						editor.IsVirtualSpaceAtLineEndEnabled = virtualSpaceAtLineEndToolStripMenuItem.Checked;
						break;
					case nameof(indentationGuidesVisibleToolStripMenuItem):
						indentationGuidesVisibleToolStripMenuItem.Checked = !indentationGuidesVisibleToolStripMenuItem.Checked;
						editor.AreIndentationGuidesVisible = indentationGuidesVisibleToolStripMenuItem.Checked;
						break;
					case nameof(lineModificationMarksVisibleToolStripMenuItem):
						lineModificationMarksVisibleToolStripMenuItem.Checked = !lineModificationMarksVisibleToolStripMenuItem.Checked;
						editor.AreLineModificationMarksVisible = lineModificationMarksVisibleToolStripMenuItem.Checked;
						break;
					case nameof(currentLineHighlightingEnabledToolStripMenuItem):
						currentLineHighlightingEnabledToolStripMenuItem.Checked = !currentLineHighlightingEnabledToolStripMenuItem.Checked;
						editor.IsCurrentLineHighlightingEnabled = currentLineHighlightingEnabledToolStripMenuItem.Checked;
						break;
					case nameof(delimiterHighlightingEnabledToolStripMenuItem):
						delimiterHighlightingEnabledToolStripMenuItem.Checked = !delimiterHighlightingEnabledToolStripMenuItem.Checked;
						editor.IsDelimiterHighlightingEnabled = delimiterHighlightingEnabledToolStripMenuItem.Checked;
						break;
					case nameof(autoCorrectEnabledToolStripMenuItem):
						autoCorrectEnabledToolStripMenuItem.Checked = !autoCorrectEnabledToolStripMenuItem.Checked;
						editor.IsAutoCorrectEnabled = autoCorrectEnabledToolStripMenuItem.Checked;
						break;
					// Outlining menu
					case nameof(collapseToDefinitionsToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.CollapseToDefinitions);
						break;
					case nameof(hideSelectionToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.HideSelection);
						break;
					case nameof(toggleOutliningExpansionToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.ToggleOutliningExpansion);
						break;
					case nameof(toggleAllOutliningToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.ToggleAllOutliningExpansion);
						break;
					case nameof(stopOutliningToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.StopOutlining);
						break;
					case nameof(stopHidingCurrentToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.StopHidingCurrent);
						break;
					case nameof(startAutomaticOutliningToolStripMenuItem):
						editor.ActiveView.ExecuteEditAction(EditorCommands.StartAutomaticOutlining);
						break;
					// Window menu
					case nameof(canSplitHorizontallyToolStripMenuItem):
						canSplitHorizontallyToolStripMenuItem.Checked = !canSplitHorizontallyToolStripMenuItem.Checked;
						editor.CanSplitHorizontally = canSplitHorizontallyToolStripMenuItem.Checked;
						break;
					case nameof(hasHorizontalSplitToolStripMenuItem):
						hasHorizontalSplitToolStripMenuItem.Checked = !hasHorizontalSplitToolStripMenuItem.Checked;
						editor.HasHorizontalSplit = hasHorizontalSplitToolStripMenuItem.Checked;
						break;
					case nameof(isDocumentReadonlyToolStripMenuItem):
						isDocumentReadonlyToolStripMenuItem.Checked = !isDocumentReadonlyToolStripMenuItem.Checked;
						editor.Document.IsReadOnly = isDocumentReadonlyToolStripMenuItem.Checked;
						break;
				}
			}
			catch (Exception ex) {
				Debug.WriteLine($"Error executing command.  {ex}");
				MessageBox.Show($"Error executing command.  {ex.Message}", "Error Executing Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/// <summary>
		/// Occurs when the drop-down menu is opening.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnOutliningToolStripMenuItemDropDownOpening(object sender, EventArgs e) {
			var view = editor.ActiveView;
			collapseToDefinitionsToolStripMenuItem.Enabled = EditorCommands.CollapseToDefinitions.CanExecute(view);
			hideSelectionToolStripMenuItem.Enabled = EditorCommands.HideSelection.CanExecute(view);
			toggleOutliningExpansionToolStripMenuItem.Enabled = EditorCommands.ToggleOutliningExpansion.CanExecute(view);
			toggleAllOutliningToolStripMenuItem.Enabled = EditorCommands.ToggleAllOutliningExpansion.CanExecute(view);
			stopOutliningToolStripMenuItem.Enabled = EditorCommands.StopOutlining.CanExecute(view);
			stopHidingCurrentToolStripMenuItem.Enabled = EditorCommands.StopHidingCurrent.CanExecute(view);
			startAutomaticOutliningToolStripMenuItem.Enabled = EditorCommands.StartAutomaticOutlining.CanExecute(view);
		}

		/// <summary>
		/// Occurs when the <c>SyntaxEditor.DocumentChanged</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorDocumentChangedEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorDocumentChanged(object sender, EditorDocumentChangedEventArgs e) {
			if (!editor.IsDisposed)
				this.AppendMessage("DocumentChanged");
		}
		
		/// <summary>
		/// Occurs when the <c>SyntaxEditor.DocumentIsModifiedChanged</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorDocumentIsModifiedChanged(object sender, EventArgs e) {
			this.AppendMessage(String.Format("DocumentIsModifiedChanged: IsModified={0}", editor.Document.IsModified));
		}
		
		/// <summary>
		/// Occurs when the document's parse data has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to this event.</param>
		private void OnSyntaxEditorDocumentParseDataChanged(object sender, EventArgs e) {
			//
			// NOTE: The parse data here is generated in a worker thread... this event handler is called 
			//         back in the UI thread immediately when the worker thread completes... it is best
			//         practice to delay UI updates until the end user stops typing... we will flag that
			//         there is a pending parse data change, which will be handled in the 
			//         UserInterfaceUpdate event
			//

			hasPendingParseData = true;
		}
		
		/// <summary>
		/// Occurs when the <c>SyntaxEditor.IsOverwriteModeActiveChanged</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorIsOverwriteModeActiveChanged(object sender, EventArgs e) {
			this.AppendMessage("IsOverwriteModeActiveChanged");
			overwriteModePanel.Text = (editor.IsOverwriteModeActive ? "OVR" : "INS");
		}

		/// <summary>
		/// Occurs when the <c>SyntaxEditor.MacroRecordingStateChanged</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorMacroRecordingStateChanged(object sender, EventArgs e) {
			this.AppendMessage("MacroRecordingStateChanged: " + editor.MacroRecording.State);

			switch (editor.MacroRecording.State) {
				case MacroRecordingState.Recording:
					messagePanel.Text = "Macro recording is active";
					recordMacroToolStripButton.Image = Resources.IconMacroRecordingStop16;
					recordMacroToolStripButton.ToolTipText = "Stop Recording";
					pauseRecordingToolStripButton.Checked = false;
					pauseRecordingToolStripButton.ToolTipText = "Pause Recording";
					break;
				case MacroRecordingState.Paused:
					messagePanel.Text = "Macro recording is paused";
					pauseRecordingToolStripButton.Checked = true;
					pauseRecordingToolStripButton.ToolTipText = "Resume Recording";
					break;
				default:
					messagePanel.Text = "Ready";
					recordMacroToolStripButton.Image = Resources.IconMacroRecordingRecord16;
					recordMacroToolStripButton.ToolTipText = "Record Macro";
					pauseRecordingToolStripButton.Checked = false;
					pauseRecordingToolStripButton.ToolTipText = "Pause Recording";
					break;
			}

			var view = editor.ActiveView;
			runMacroToolStripButton.Enabled = EditorCommands.RunMacro.CanExecute(view);
			recordMacroToolStripButton.Enabled = EditorCommands.ToggleMacroRecording.CanExecute(view);
			pauseRecordingToolStripButton.Enabled = EditorCommands.PauseResumeMacroRecording.CanExecute(view);
			cancelMacroToolStripButton.Enabled = EditorCommands.CancelMacroRecording.CanExecute(view);

			runRecordedMacroToolStripMenuItem.Enabled = runMacroToolStripButton.Enabled;
			recordMacroToolStripMenuItem.Enabled = recordMacroToolStripButton.Enabled;
			recordMacroToolStripMenuItem.Text = recordMacroToolStripButton.Text;
			pauseRecordingToolStripMenuItem.Enabled = pauseRecordingToolStripButton.Enabled;
			pauseRecordingToolStripMenuItem.Text = pauseRecordingToolStripButton.Text;
			cancelRecordingToolStripMenuItem.Enabled = cancelMacroToolStripButton.Enabled;
		}

		/// <summary>
		/// Occurs after a brief delay following any document text, parse data, or view selection update, allowing consumers to update the user interface during an idle period.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains data related to this event.</param>
		private void OnSyntaxEditorUserInterfaceUpdate(object sender, EventArgs e) {
			// If there is a pending parse data change...
			if (hasPendingParseData) {
				// Clear flag
				hasPendingParseData = false;

				var parseData = editor.Document.ParseData as ILLParseData;
				if (parseData != null) {
					if (editor.Document.CurrentSnapshot.Length < 10000) {
						// Show the AST
						if (parseData.Ast != null)
							astOutputEditor.Text = parseData.Ast.ToTreeString(0);
						else
							astOutputEditor.Text = null;
					}
					else
						astOutputEditor.Text = "(Not displaying large AST for performance reasons)";

					// Output errors
					this.RefreshErrorList(parseData.Errors);
				}
				else {
					// Clear UI
					astOutputEditor.Text = null;
					this.RefreshErrorList(null);
				}
			}
		}
		
		/// <summary>
		/// Occurs when the incremental search mode of an <see cref="ITextView"/> is activated or deactivated.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="EditorViewSelectionEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewIsIncrementalSearchActiveChanged(object sender, TextViewEventArgs e) {
			IEditorView editorView = e.View as IEditorView;
			if ((editorView != null) && (!editorView.IsIncrementalSearchActive)) {
				// Incremental search is now deactivated
				messagePanel.Text = "Ready";
			}
		}
		
		/// <summary>
		/// Occurs when a search operation occurs in a view.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorViewSearchEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewSearch(object sender, EditorViewSearchEventArgs e) {
			// If an incremental search was performed...
			if (e.ResultSet.OperationType == SearchOperationType.FindNextIncremental) {
				// Show a statusbar message
				bool hasFindText = !String.IsNullOrEmpty(e.ResultSet.Options.FindText);
				bool notFound = (hasFindText) && (e.ResultSet.Results.Count == 0);
				string notFoundMessage = (notFound ? " (not found)" : String.Empty);
				messagePanel.Text = "Incremental Search: " + e.ResultSet.Options.FindText + notFoundMessage;
			}
		}

		/// <summary>
		/// Occurs when the <c>SyntaxEditor.ViewSelectionChanged</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">An <see cref="EditorViewSelectionEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewSelectionChanged(object sender, EditorViewSelectionEventArgs e) {
			// Quit if this event is not for the active view
			if (!e.View.IsActive)
				return;

			// Update line, col, and character display
			linePanel.Text = String.Format("Ln {0}", e.CaretPosition.DisplayLine);
			columnPanel.Text = String.Format("Col {0}", e.CaretDisplayCharacterColumn);
			characterPanel.Text = String.Format("Ch {0}", e.CaretPosition.DisplayCharacter);
		}
		
		/// <summary>
		/// Occurs when the <c>SyntaxEditor.ViewSplitAdded</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewSplitAdded(object sender, EventArgs e) {
			this.AppendMessage("ViewSplitAdded");
		}
		
		/// <summary>
		/// Occurs when the <c>SyntaxEditor.ViewSplitMoved</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewSplitMoved(object sender, EventArgs e) {
			this.AppendMessage("ViewSplitMoved");
		}
		
		/// <summary>
		/// Occurs when the <c>SyntaxEditor.ViewSplitRemoved</c> event occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorViewSplitRemoved(object sender, EventArgs e) {
			this.AppendMessage("ViewSplitRemoved");
		}
		
		/// <summary>
		/// Opens a file.
		/// </summary>
		private void OpenFile() {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Code files (*.cs;*.vb;*.js;*.json;*.py;*.xml;*.txt)|*.cs;*.vb;*.js;*.json;*.py;*.xml;*.txt|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					this.OpenFile(Path.GetFileName(dialog.FileName), stream);
				}
			}
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="stream">The <see cref="Stream"/> to load.</param>
		private void OpenFile(string filename, Stream stream) {
			// Load the file
			if (stream != null)
				editor.Document.LoadFile(stream, Encoding.UTF8);
			else
				editor.Document.SetText(null);

			// Set the filename
			editor.Document.FileName = filename;
		}
		
		/// <summary>
		/// Opens a VS Settings file.
		/// </summary>
		private void OpenVSSettingsFile() {
			// Show a file open dialog
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.Multiselect = false;
			dialog.Filter = "Visual Studio Settings files (*.vssettings)|*.vssettings|All files (*.*)|*.*";
			if (dialog.ShowDialog() == DialogResult.OK) {
				// Open a document
				using (Stream stream = dialog.OpenFile()) {
					// Read the file
					AmbientHighlightingStyleRegistry.Instance.ImportHighlightingStyles(stream);
				}
			}
		}

		/// <summary>
		/// Refreshes the list.
		/// </summary>
		/// <param name="errors">The error collection.</param>
		private void RefreshErrorList(IEnumerable<IParseError> errors) {
			errorListView.Items.Clear();

			if (errors != null) {
				foreach (var error in errors) {
					var item = new ListViewItem(new string[] { 
						error.PositionRange.StartPosition.DisplayLine.ToString(), error.PositionRange.StartPosition.DisplayCharacter.ToString(), error.Description
					});
					item.Tag = error;
					errorListView.Items.Add(item);
				}
			}
		}

		/// <summary>
		/// Sets the color scheme to be used for the editor.
		/// </summary>
		/// <param name="colorSchemeType">The color scheme type.</param>
		private void SetColorScheme(WindowsColorSchemeType colorSchemeType) {

			// Create the appropriate renderer for the color scheme type
			var renderer = ((colorSchemeType == WindowsColorSchemeType.MetroLight) || (colorSchemeType == WindowsColorSchemeType.MetroDark))
				? new MetroSyntaxEditorRenderer(colorSchemeType)
				: new SyntaxEditorRenderer();

			// Configure the editor with the per-instance renderer
			editor.Renderer = renderer;

			// Ensure symbol selector is refreshed
			symbolSelector.Invalidate();

			// Update colors on this control to be consistent with the color scheme
			var colorScheme = renderer.ColorScheme;
			editorPanel.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			editor.BackColor = colorScheme.GetKnownColor(KnownColor.Window);
			editor.ForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);

			// Configure global image set and highlighting style registry for light/dark theme
			SyntaxEditorHelper.UpdateImageSetForThemeChange(colorScheme);
			SyntaxEditorHelper.UpdateHighlightingStyleRegistryForThemeChange(colorScheme);

			// Update the check status of menu items
			bool isDarkTheme = colorScheme.IsDarkColorScheme();
			lightThemeToolStripMenuItem.Checked = !isDarkTheme;
			darkThemeToolStripMenuItem.Checked = isDarkTheme;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Notifies the UI that it has been loaded.
		/// </summary>
		public void NotifyLoaded() {
			editor.Focus();
		}

		/// <summary>
		/// Notifies the UI that it has been unloaded.
		/// </summary>
		public void NotifyUnloaded() {
			// Clear .NET Languages Add-on project assembly references when the sample unloads
			cSharpProjectAssembly.AssemblyReferences.Clear();
			vbProjectAssembly.AssemblyReferences.Clear();

			// Restore SyntaxEditor image set and highlighting style registry to match the global configuration
			SyntaxEditorHelper.UpdateImageSetForThemeChange(UIRendererManager.ColorScheme);
			SyntaxEditorHelper.UpdateHighlightingStyleRegistryForThemeChange(UIRendererManager.ColorScheme);
		}

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale control fonts
				var manualFontControls = new Control[] {
					astOutputEditor,
					errorListView,
					eventsListBox,
					menuStrip,
					mainToolStrip,
					statusStrip,
					symbolSelector
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);

				// Manually scale the buttons/images on the tool strip
				mainToolStrip.SuspendLayout();
				mainToolStrip.ImageScalingSize = DpiHelper.RescaleSize(mainToolStrip.ImageScalingSize, deviceDpiOld, deviceDpiNew);
				var imageButtonSize = DpiHelper.ScaleSize(new Size(23, 22), DpiHelper.GetDpiScale(deviceDpiNew));
				foreach (var toolStripItem in mainToolStrip.Items) {
					if (toolStripItem is ToolStripButton toolStripButton) {
						if (toolStripButton.DisplayStyle == ToolStripItemDisplayStyle.Image) {
							toolStripButton.AutoSize = false;
							toolStripButton.Size = imageButtonSize;
						}
					}
				}
				mainToolStrip.ResumeLayout();
			}

			DpiHelper.RescaleListViewColumns(errorListView, deviceDpiOld, deviceDpiNew);

		}

	}

}
