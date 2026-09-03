using ActiproSoftware.Extensions;
using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Bars;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Reflection;

#if NETFRAMEWORK || NET10_0_OR_GREATER
// Avoid ambiguity with System.Windows.Forms.StatusBar from .NET Framework or .NET 10+
using StatusBar = ActiproSoftware.UI.WinForms.Controls.Bars.StatusBar;
#endif

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features;

/// <summary>
/// A form to test the <c>Bar</c> controls.
/// </summary>
public partial class MainForm : Form {

	private BarCustomizeForm? _customizeForm;
	private bool _showDarkThemeDisclaimer = true;

	private const string WindowActivateCategory = "WindowActivate";

	// Application modes can be used to only show certain toolbars when a certain mode is selected.
	//   The following constants correspond to values in the BarManager.Modes property.
	private const string TextEditorMode = "Text Editor";
	private const string RichTextEditorMode = "Rich Text Editor";

	// --------------------------------------------------------------------------------------------------
	// NESTED TYPES
	// --------------------------------------------------------------------------------------------------

	#region BarFormContext Class

	/// <summary>
	/// Provides a simple class to keep context.
	/// </summary>
	internal class BarFormContext {
		internal ActiproSoftware.UI.WinForms.Controls.Docking.DockManager? DockManager;
		internal MainForm? Form;
		internal int DocumentIndex = 1;
	}

	#endregion

	#region TextDocumentWindowBase Class

	/// <summary>
	/// Represents a base text <see cref="DocumentWindow"/>.
	/// </summary>
	internal abstract class TextDocumentWindowBase : ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow {

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public TextDocumentWindowBase(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename)
			: base(dockManager, filename, Path.GetFileName(filename)) {

			FileName = filename;
			Image = ActiproSoftware.SampleBrowser.Resources.IconTextDocument16;
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// The <see cref="TextBoxBase"/> wrapped by this document window.
		/// </summary>
		internal TextBoxBase TextBox
			=> (TextBoxBase)Controls[0];

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Processes the <c>Edit.Copy</c> command.
		/// </summary>
		public void ProcessEditCopy()
			=> TextBox.Copy();

		/// <summary>
		/// Processes the <c>Edit.Cut</c> command.
		/// </summary>
		public void ProcessEditCut()
			=> TextBox.Cut();

		/// <summary>
		/// Processes the <c>Edit.Delete</c> command.
		/// </summary>
		public void ProcessEditDelete()
			=> TextBox.SelectedText = string.Empty;

		/// <summary>
		/// Processes the <c>Edit.Paste</c> command.
		/// </summary>
		public void ProcessEditPaste()
			=> TextBox.Paste();

		/// <summary>
		/// Processes the <c>Edit.QuickFind</c> command.
		/// </summary>
		/// <param name="findText">The text to find.</param>
		public abstract void ProcessEditQuickFind(string findText);

		/// <summary>
		/// Processes the <c>Edit.SelectAll</c> command.
		/// </summary>
		public void ProcessEditSelectAll()
			=> TextBox.SelectAll();

		/// <summary>
		/// Processes the <c>Edit.Undo</c> command.
		/// </summary>
		public void ProcessEditUndo()
			=> TextBox.Undo();

	}

	#endregion

	#region RichTextDocumentWindow Class

	/// <summary>
	/// Represents a rich text <see cref="DocumentWindow"/>.
	/// </summary>
	internal class RichTextDocumentWindow : TextDocumentWindowBase {

		// --------------------------------------------------------------------------------------------------
		// NESTED TYPES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Represents a <see cref="TextBox"/> to be used on a <see cref="RichTextDocumentWindow"/>.
		/// </summary>
		private class RichTextDocumentTextBox : RichTextBox {

			private const int WM_CONTEXTMENU = 0x007B;

			// --------------------------------------------------------------------------------------------------
			// OBJECT
			// --------------------------------------------------------------------------------------------------

			/// <summary>
			/// Initializes an instance of the class.
			/// </summary>
			public RichTextDocumentTextBox() {
				BorderStyle = BorderStyle.None;
				HideSelection = false;
				Multiline = true;
				ScrollBars = RichTextBoxScrollBars.ForcedBoth;
				Dock = DockStyle.Fill;
			}

			// --------------------------------------------------------------------------------------------------
			// NON-PUBLIC PROCEDURES
			// --------------------------------------------------------------------------------------------------

			/// <summary>
			/// Resolves the <c>MainForm</c> that is hosting this control.
			/// </summary>
			private MainForm? ResolveMainForm() {
				if (Parent is TextDocumentWindowBase parent)
					return parent.DockManager?.HostContainerControl?.FindForm() as MainForm;
				return null;
			}

			// --------------------------------------------------------------------------------------------------
			// PUBLIC PROCEDURES
			// --------------------------------------------------------------------------------------------------

			/// <inheritdoc/>
			protected override void OnSelectionChanged(EventArgs e) {
				// Call the base method
				base.OnSelectionChanged(e);

				// Update format command states
				ResolveMainForm()?.UpdateFormatCommandStates();
			}

			/// <inheritdoc/>
			protected override void OnStyleChanged(EventArgs e) {
				// Call the base method
				base.OnStyleChanged(e);

				// Update format command states
				ResolveMainForm()?.UpdateFormatCommandStates();
			}

			/// <inheritdoc/>
			protected override void OnTextChanged(EventArgs e) {
				// Call the base method
				base.OnTextChanged(e);

				// Flag as modified
				if (Parent is ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow)
					documentWindow.Modified = true;

				// Update the position statusbar panel
				ResolveMainForm()?.UpdatePositionStatusBarPanel();
			}

			/// <inheritdoc/>
			protected override void WndProc(ref Message m) {
				if (m.Msg == WM_CONTEXTMENU) {
					// Show a custom edit popup menu
					if (ResolveMainForm() is { } mainForm)
						mainForm.barManager.PopupMenus["Text Document Context"]?.Show(this, MousePosition, isClientLocation: false);
				}
				else {
					// Call the base method
					base.WndProc(ref m);
				}
			}
		}

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public RichTextDocumentWindow(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename) : base(dockManager, filename) {
			Image = ActiproSoftware.SampleBrowser.Resources.IconRichTextDocument16;

			var textBox = new RichTextDocumentTextBox {
				Parent = this // Parenting the control will add it as first child
			};

			if (File.Exists(filename))
				textBox.LoadFile(filename);
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// The <c>RichTextBox</c> wrapped by this document window.
		/// </summary>
		internal RichTextBox RichTextBox
			=> (RichTextBox)TextBox;

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <inheritdoc/>
		public override void ProcessEditQuickFind(string findText) {
			int index = RichTextBox.Find(findText, TextBox.SelectionStart + TextBox.SelectionLength, TextBox.TextLength, RichTextBoxFinds.None);
			if (index != -1) {
				TextBox.Select(index, findText.Length);
				TextBox.Focus();
			}
			else
				MessageBox.Show(string.Format("The text '{0}' was not found.", findText), "Quick Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Processes the <c>Format.AlignCenter</c> command.
		/// </summary>
		public void ProcessFormatAlignCenter()
			=> RichTextBox.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;

		/// <summary>
		/// Processes the <c>Format.AlignLeft</c> command.
		/// </summary>
		public void ProcessFormatAlignLeft()
			=> RichTextBox.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;

		/// <summary>
		/// Processes the <c>Format.AlignRight</c> command.
		/// </summary>
		public void ProcessFormatAlignRight()
			=> RichTextBox.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;

		/// <summary>
		/// Processes the <c>Format.BulletedList</c> command.
		/// </summary>
		public void ProcessFormatBulletedList()
			=> RichTextBox.SelectionBullet = !RichTextBox.SelectionBullet;

		/// <summary>
		/// Processes the <c>Format.FontSize</c> command.
		/// </summary>
		public void ProcessFormatFontSize() {
			// Get the BarManager from the main form
			var mainForm = (MainForm?)DockManager?.HostContainerControl?.FindForm();
			if (mainForm?.barManager is not { } barManager)
				return;

			// Get the Format.FontSize command
			if (barManager.Commands["Format.FontSize"] is not BarComboBoxCommand command)
				return;

			// Get the font size
			if (!int.TryParse(command.ControlValue, out var fontSize))
				fontSize = 10;

			// Change the font
			var previousFont = RichTextBox.SelectionFont ?? SystemFonts.DefaultFont;
			RichTextBox.SelectionFont = new Font(previousFont.FontFamily, fontSize);

			// Update the font size on the command
			command.ControlValue = fontSize.ToString();
		}

		/// <summary>
		/// Processes the <c>Format.Indent</c> command.
		/// </summary>
		public void ProcessFormatIndent()
			=> RichTextBox.SelectionIndent += 20;

		/// <summary>
		/// Processes the <c>Format.Outdent</c> command.
		/// </summary>
		public void ProcessFormatOutdent()
			=> RichTextBox.SelectionIndent = (RichTextBox.SelectionIndent - 20).ClampToNonnegative();
	}

	#endregion

	#region TextDocumentWindow Class

	/// <summary>
	/// Represents a text <see cref="DocumentWindow"/>.
	/// </summary>
	internal class TextDocumentWindow : TextDocumentWindowBase {

		// --------------------------------------------------------------------------------------------------
		// NESTED TYPES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Represents a <see cref="TextBox"/> to be used on a <see cref="TextDocumentWindow"/>.
		/// </summary>
		private class TextDocumentTextBox : TextBox {

			private const int WM_CONTEXTMENU = 0x007B;

			// --------------------------------------------------------------------------------------------------
			// OBJECT
			// --------------------------------------------------------------------------------------------------

			/// <summary>
			/// Initializes an instance of the class.
			/// </summary>
			public TextDocumentTextBox() {
				Font = new Font("Courier New", 10);
				HideSelection = false;
				Multiline = true;
				ScrollBars = ScrollBars.Both;
				Dock = DockStyle.Fill;
			}

			// --------------------------------------------------------------------------------------------------
			// NON-PUBLIC PROCEDURES
			// --------------------------------------------------------------------------------------------------

			/// <summary>
			/// Resolves the <c>MainForm</c> that is hosting this control.
			/// </summary>
			private MainForm? ResolveMainForm() {
				if (Parent is TextDocumentWindowBase parent)
					return parent.DockManager?.HostContainerControl?.FindForm() as MainForm;
				return null;
			}

			// --------------------------------------------------------------------------------------------------
			// PUBLIC PROCEDURES
			// --------------------------------------------------------------------------------------------------

			/// <inheritdoc/>
			protected override void OnTextChanged(EventArgs e) {
				// Call the base method
				base.OnTextChanged(e);

				// Flag as modified
				if (Parent is ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow)
					documentWindow.Modified = true;

				// Update the position statusbar panel
				ResolveMainForm()?.UpdatePositionStatusBarPanel();
			}

			/// <inheritdoc/>
			protected override void WndProc(ref Message m) {
				if (m.Msg == WM_CONTEXTMENU) {
					// Show a custom edit popup menu
					if (ResolveMainForm() is { } mainForm)
						mainForm.barManager.PopupMenus["Text Document Context"]?.Show(this, MousePosition, isClientLocation: false);
				}
				else {
					// Call the base method
					base.WndProc(ref m);
				}
			}
		}

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public TextDocumentWindow(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename) : base(dockManager, filename) {
			var textBox = new TextDocumentTextBox {
				Parent = this // Parenting the control will add it as first child
			};

			if (File.Exists(filename)) {
				var reader = new StreamReader(filename);
				textBox.Text = reader.ReadToEnd();
				reader.Close();
			}
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <inheritdoc/>
		public override void ProcessEditQuickFind(string findText) {
			if (string.IsNullOrEmpty(findText))
				return;

			var text = string.Empty;
			if ((TextBox.SelectionStart + TextBox.SelectionLength + 1) < TextBox.Text.Length)
				text = TextBox.Text.Substring(TextBox.SelectionStart + TextBox.SelectionLength + 1);
			int index = text.IndexOf(findText);
			if (index == -1)
				index = TextBox.Text.IndexOf(findText);

			if (index != -1) {
				TextBox.Select(index, findText.Length);
				TextBox.Focus();
			}
			else
				MessageBox.Show(string.Format("The text '{0}' was not found.", findText), "Quick Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	#endregion

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

		// Create a context and store it in the BarManager's Tag property
		var context = new BarFormContext {
			DockManager = dockManager,
			Form = this
		};
		barManager.Tag = context;

		// Initialize the toolbar drop-down list
		foreach (var toolBar in barManager.DockableToolBars) {
			var index = toolBarPropertiesPropertyGridComboBox.Items.Add(toolBar.Key);
			if (toolBar.Key == "Standard")
				toolBarPropertiesPropertyGridComboBox.SelectedIndex = index;
		}
		if (toolBarPropertiesPropertyGridComboBox.SelectedIndex == -1)
			toolBarPropertiesPropertyGridComboBox.SelectedIndex = 0;

		// Configure the default MenuFactory to use Bars controls
		var originalMenuFactory = MenuFactory.Current;
		MenuFactory.Current = new BarsMenuFactory(barManager);
		FormClosed += (_, _) => {
			// Restore the original menu factory when this form closes
			MenuFactory.Current = originalMenuFactory;
		};
	}

	// --------------------------------------------------------------------------------------------------
	// COMMAND PROCESSING PROCEDURES
	// --------------------------------------------------------------------------------------------------

	// IMPORTANT NOTE: The commands used by this sample, when clicked, will invoke one of these methods
	//   using reflection where each method is named "Process[FullName]" where spaces and dot (.) are
	//   removed from the "FullName" (e.g., the "Edit.Copy" command will be "EditCopy", so it will
	//   execute the command "ProcessEditCopy").

	/// <summary>
	/// Processes the <c>Edit.Copy</c> command.
	/// </summary>
	public void ProcessEditCopy()
		=> SelectedTextDocumentWindow?.ProcessEditCopy();

	/// <summary>
	/// Processes the <c>Edit.Cut</c> command.
	/// </summary>
	public void ProcessEditCut()
		=> SelectedTextDocumentWindow?.ProcessEditCut();

	/// <summary>
	/// Processes the <c>Edit.Delete</c> command.
	/// </summary>
	public void ProcessEditDelete()
		=> SelectedTextDocumentWindow?.ProcessEditDelete();

	/// <summary>
	/// Processes the <c>Edit.Paste</c> command.
	/// </summary>
	public void ProcessEditPaste()
		=> SelectedTextDocumentWindow?.ProcessEditPaste();

	/// <summary>
	/// Processes the <c>Edit.QuickFind</c> command.
	/// </summary>
	public void ProcessEditQuickFind() {
		if ((barManager.Commands["Edit.QuickFind"] is BarTextBoxCommand command) && (command.ControlValue is { } findText))
			SelectedTextDocumentWindow?.ProcessEditQuickFind(findText);
	}

	/// <summary>
	/// Processes the <c>Edit.SelectAll</c> command.
	/// </summary>
	public void ProcessEditSelectAll()
		=> SelectedTextDocumentWindow?.ProcessEditSelectAll();

	/// <summary>
	/// Processes the <c>Edit.Undo</c> command.
	/// </summary>
	public void ProcessEditUndo()
		=> SelectedTextDocumentWindow?.ProcessEditUndo();

	/// <summary>
	/// Processes the <c>File.Exit</c> command.
	/// </summary>
	private void ProcessFileExit()
		=> Close(); // Close the form

	/// <summary>
	/// Processes the <c>File.Close</c> command.
	/// </summary>
	private void ProcessFileClose()
		=> dockManager.SelectedDocument?.Close(); // Close the selected document

	/// <summary>
	/// Processes the <c>File.LoadLayout</c> command.
	/// </summary>
	private void ProcessFileLoadLayout() {
		// Show the dialog
		using var openFileDialog = new OpenFileDialog() {
			Filter = "XML Bar Layout Files (*.xml)|*.xml",
			FileName = "BarLayout.xml"
		};
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Load the layout
		barManager.LoadBarLayoutFromFile(openFileDialog.FileName);
	}

	/// <summary>
	/// Processes the <c>File.New</c> command.
	/// </summary>
	private void ProcessFileNew()
		=> ProcessFileNewTextDocument();

	/// <summary>
	/// Processes the <c>File.NewRichTextDocument</c> command.
	/// </summary>
	private void ProcessFileNewRichTextDocument() {
		// Get the next document index from the context
		var documentIndex = ((BarFormContext)barManager.Tag!).DocumentIndex++;

		// Create a new document window
		var documentWindow = CreateRichTextDocumentWindow($"Document{documentIndex}.rtf");

		// Activate the document
		documentWindow.Activate();
	}

	/// <summary>
	/// Processes the <c>File.NewTextDocument</c> command.
	/// </summary>
	private void ProcessFileNewTextDocument() {
		// Get the next document index from the context
		var documentIndex = ((BarFormContext)barManager.Tag!).DocumentIndex++;

		// Create a new document window
		var documentWindow = CreateTextDocumentWindow($"Document{documentIndex}.txt");

		// Activate the document
		documentWindow.Activate();
	}

	/// <summary>
	/// Processes the <c>File.Open</c> command.
	/// </summary>
	private void ProcessFileOpen() {
		// Show the dialog
		using var openFileDialog = new OpenFileDialog {
			Filter = "Rich Text Files (*.rtf;*.doc)|*.rtf;*.doc|Text Files (*.txt)|*.txt",
			FileName = string.Empty
		};
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Open the text document
		ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow;
		switch (Path.GetExtension(openFileDialog.FileName).ToLower()) {
			case ".doc":
			case ".rtf":
				documentWindow = CreateRichTextDocumentWindow(openFileDialog.FileName);
				break;
			default:
				documentWindow = CreateTextDocumentWindow(openFileDialog.FileName);
				break;
		}

		// Reset the modified indicator after text is loaded
		documentWindow.Modified = false;

		// Activate the document
		documentWindow.Activate();
	}

	/// <summary>
	/// Processes the <c>File.SaveLayout</c> command.
	/// </summary>
	private void ProcessFileSaveLayout() {
		// Show the dialog
		using var saveFileDialog = new SaveFileDialog {
			Filter = "XML Bar Layout Files (*.xml)|*.xml",
			FileName = "BarLayout.xml"
		};
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Save the layout
		barManager.SaveBarLayoutToFile(saveFileDialog.FileName, isComplete: false);
	}

	/// <summary>
	/// Processes the <c>Format.AlignCenter</c> command.
	/// </summary>
	public void ProcessFormatAlignCenter()
		=> SelectedRichTextDocumentWindow?.ProcessFormatAlignCenter();

	/// <summary>
	/// Processes the <c>Format.AlignLeft</c> command.
	/// </summary>
	public void ProcessFormatAlignLeft()
		=> SelectedRichTextDocumentWindow?.ProcessFormatAlignLeft();

	/// <summary>
	/// Processes the <c>Format.AlignRight</c> command.
	/// </summary>
	public void ProcessFormatAlignRight()
		=> SelectedRichTextDocumentWindow?.ProcessFormatAlignRight();

	/// <summary>
	/// Processes the <c>Format.BulletedList</c> command.
	/// </summary>
	public void ProcessFormatBulletedList()
		=> SelectedRichTextDocumentWindow?.ProcessFormatBulletedList();

	/// <summary>
	/// Processes the <c>Format.FontSize</c> command.
	/// </summary>
	public void ProcessFormatFontSize()
		=> SelectedRichTextDocumentWindow?.ProcessFormatFontSize();

	/// <summary>
	/// Processes the <c>Format.Indent</c> command.
	/// </summary>
	public void ProcessFormatIndent()
		=> SelectedRichTextDocumentWindow?.ProcessFormatIndent();

	/// <summary>
	/// Processes the <c>Format.Outdent</c> command.
	/// </summary>
	public void ProcessFormatOutdent()
		=> SelectedRichTextDocumentWindow?.ProcessFormatOutdent();

	/// <summary>
	/// Processes the <c>Help.About</c> command.
	/// </summary>
	private void ProcessHelpAbout()
		=> SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com");

	/// <summary>
	/// Processes the <c>Tools.ChordKey1</c> command.
	/// </summary>
	private void ProcessToolsChordKey1()
		=> MessageBox.Show("Chord key 1 has a chord-based keyboard shortcut.", "Chord", MessageBoxButtons.OK, MessageBoxIcon.Information);

	/// <summary>
	/// Processes the <c>Tools.ChordKey2</c> command.
	/// </summary>
	private void ProcessToolsChordKey2()
		=> MessageBox.Show("Chord key 2 has a chord-based keyboard shortcut.", "Chord", MessageBoxButtons.OK, MessageBoxIcon.Information);

	/// <summary>
	/// Processes the <c>Help.Contents</c> command.
	/// </summary>
	private void ProcessHelpContents()
		=> SampleBrowser.Program.LaunchProductHelp();

	/// <summary>
	/// Processes the <c>Tools.ToggleFindButtonEnabledState</c> command.
	/// </summary>
	private void ProcessToolsToggleFindButtonEnabledState() {
		if (barManager.Commands["Edit.Find"] is { } command)
			command.Enabled = !command.Enabled;
	}

	/// <summary>
	/// Processes the <c>Tools.Customize</c> command.
	/// </summary>
	private void ProcessToolsCustomize()
		=> barManager.CustomizeMode = BarCustomizeMode.DialogCustomize;

	/// <summary>
	/// Processes the <c>View.ClearEventLog</c> command.
	/// </summary>
	private void ProcessViewClearEventLog()
		=> eventsListBox.Items.Clear();

	/// <summary>
	/// Processes the <c>View.MdiChildCloseButtonVisibility</c> command.
	/// </summary>
	private void ProcessViewMdiChildCloseButtonVisibility() {
		if (barManager.Commands["View.MdiChildCloseButtonVisibility"] is BarButtonCommand command)
			barManager.MdiChildCloseButtonVisible = command.Checked;
	}

	/// <summary>
	/// Processes the <c>View.MdiChildMinimizeButtonVisibility</c> command.
	/// </summary>
	private void ProcessViewMdiChildMinimizeButtonVisibility() {
		if (barManager.Commands["View.MdiChildMinimizeButtonVisibility"] is BarButtonCommand command)
			barManager.MdiChildMinimizeButtonVisible = command.Checked;
	}

	/// <summary>
	/// Processes the <c>View.MdiChildRestoreButtonVisibility</c> command.
	/// </summary>
	private void ProcessViewMdiChildRestoreButtonVisibility() {
		if (barManager.Commands["View.MdiChildRestoreButtonVisibility"] is BarButtonCommand command)
			barManager.MdiChildRestoreButtonVisible = command.Checked;
	}

	/// <summary>
	/// Processes the <c>View.RendererCustomGreen</c> command.
	/// </summary>
	private void ProcessViewRendererCustomGreen() {
		// Create a new color scheme
		var scheme = new WindowsColorScheme("Green", WindowsColorSchemeType.LunaBlue, UIColor.FromWebColor("#155E2F").ToColor());

		// Update all the control-specific renderers in this sample to use a renderer based on the color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(scheme);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(scheme);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(scheme);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(scheme);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererCustomTan</c> command.
	/// </summary>
	private void ProcessViewRendererCustomTan() {
		// Create a new color scheme
		var scheme = new WindowsColorScheme("Tan", WindowsColorSchemeType.LunaBlue, Color.Tan);

		// Update all the control-specific renderers in this sample to use a renderer based on the color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(scheme);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(scheme);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(scheme);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(scheme);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererMetroDark</c> command.
	/// </summary>
	private void ProcessViewRendererMetroDark() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new MetroBarRenderer(WindowsColorSchemeType.MetroDark);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDockRenderer(WindowsColorSchemeType.MetroDark);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDocumentWindowTabStripRenderer(WindowsColorSchemeType.MetroDark);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroToolWindowTabStripRenderer(WindowsColorSchemeType.MetroDark);
		statusBar.Renderer = new MetroStatusBarRenderer(WindowsColorSchemeType.MetroDark);

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererMetroLight</c> command.
	/// </summary>
	private void ProcessViewRendererMetroLight() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new MetroBarRenderer(WindowsColorSchemeType.MetroLight);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDockRenderer(WindowsColorSchemeType.MetroLight);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDocumentWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroToolWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
		statusBar.Renderer = new MetroStatusBarRenderer(WindowsColorSchemeType.MetroLight);

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeLunaBlue</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeLunaBlue() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.LunaBlue);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.LunaBlue);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.LunaBlue);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.LunaBlue);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeLunaOliveGreen</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeLunaOliveGreen() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.LunaOliveGreen);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.LunaOliveGreen);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.LunaOliveGreen);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.LunaOliveGreen);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeLunaSilver</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeLunaSilver() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.LunaSilver);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.LunaSilver);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.LunaSilver);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.LunaSilver);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeWindowsClassic</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeWindowsClassic() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.WindowsClassic);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicToolWindowTabStripRenderer();
		statusBar.Renderer = new WindowsClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeClassicBlack</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeClassicBlack() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.OfficeClassicBlack);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.OfficeClassicBlack);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicBlack);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicBlack);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeClassicBlue</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeClassicBlue() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.OfficeClassicBlue);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.OfficeClassicBlue);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicBlue);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicBlue);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererOfficeClassicSilver</c> command.
	/// </summary>
	private void ProcessViewRendererOfficeClassicSilver() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.OfficeClassicSilver);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDockRenderer(WindowsColorSchemeType.OfficeClassicSilver);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicDocumentWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicSilver);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(WindowsColorSchemeType.OfficeClassicSilver);
		statusBar.Renderer = new OfficeClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererWindowsClassic</c> command.
	/// </summary>
	private void ProcessViewRendererWindowsClassic() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new WindowsClassicBarRenderer();
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.WindowsClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.WindowsClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.WindowsClassicToolWindowTabStripRenderer();
		statusBar.Renderer = new WindowsClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererVisualStudioClassic</c> command.
	/// </summary>
	private void ProcessViewRendererVisualStudioClassic() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new OfficeClassicBarRenderer(WindowsColorSchemeType.VisualStudioClassic);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicToolWindowTabStripRenderer();
		statusBar.Renderer = new VisualStudioClassicStatusBarRenderer();

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.RendererVisualStudioBlue</c> command.
	/// </summary>
	private void ProcessViewRendererVisualStudioBlue() {
		// Update all the control-specific renderers in this sample to use a renderer based on the specified color scheme
		barManager.Renderer = new VisualStudioBarRenderer(WindowsColorSchemeType.VisualStudioBlue);
		dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioDockRenderer(WindowsColorSchemeType.VisualStudioBlue);
		dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioDocumentWindowTabStripRenderer(WindowsColorSchemeType.VisualStudioBlue);
		dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioToolWindowTabStripRenderer(WindowsColorSchemeType.VisualStudioBlue);
		statusBar.Renderer = new MetroStatusBarRenderer(WindowsColorSchemeType.VisualStudioBlue);

		OnRendererChanged();
	}

	/// <summary>
	/// Processes the <c>View.AnimatedStatusBarIcon</c> command.
	/// </summary>
	private void ProcessViewAnimatedStatusBarIcon() {
		if ((statusBar.Panels["AnimatedIcon"] is { } animatedIconPanel) && (barManager.Commands["View.AnimatedStatusBarIcon"] is BarButtonCommand command))
			animatedIconPanel.Visible = command.Checked;
	}

	/// <summary>
	/// Processes the <c>Window.MdiStyleStandard</c> command.
	/// </summary>
	private void ProcessWindowMdiStyleStandard()
		=> dockManager.DocumentMdiStyle = ActiproSoftware.UI.WinForms.Controls.Docking.DocumentMdiStyle.Standard;

	/// <summary>
	/// Processes the <c>Window.MdiStyleTabbed</c> command.
	/// </summary>
	private void ProcessWindowMdiStyleTabbed()
		=> dockManager.DocumentMdiStyle = ActiproSoftware.UI.WinForms.Controls.Docking.DocumentMdiStyle.Tabbed;

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates a new document window for rich text files.
	/// </summary>
	/// <param name="filename">The name of the file.</param>
	private RichTextDocumentWindow CreateRichTextDocumentWindow(string filename) {
		// Create a new document window
		var documentWindow = new RichTextDocumentWindow(dockManager, filename);

		// Apply the current renderer color scheme to the new window
		var colorScheme = barManager.RendererResolved.ResolvedColorScheme();
		ThemeHelper.ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);

		return documentWindow;
	}

	/// <summary>
	/// Creates a new document window for plain text files.
	/// </summary>
	/// <param name="filename">The name of the file.</param>
	private TextDocumentWindow CreateTextDocumentWindow(string filename) {
		// Create a new document window
		var documentWindow = new TextDocumentWindow(dockManager, filename);

		// Apply the current renderer color scheme to the new window
		var colorScheme = barManager.RendererResolved.ResolvedColorScheme();
		ThemeHelper.ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);

		return documentWindow;
	}

	/// <summary>
	/// Logs an event in the events listbox.
	/// </summary>
	/// <param name="eventMessage">The event message to log.</param>
	private void LogEvent(string eventMessage) {
		if (!string.IsNullOrWhiteSpace(eventMessage))
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(eventMessage);
	}

	/// <summary>
	/// Occurs when a <see cref="BarCommand"/> is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerClipboardChanged(object sender, EventArgs e) {
		LogEvent(nameof(BarManager.ClipboardChanged));

		// Update the enabled state of the Paste command based on whether there is text data on the clipboard
		UpdateEditPasteEnabledState();
	}

	/// <summary>
	/// Occurs when a <see cref="BarCommand"/> is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCommandClick(object sender, BarCommandLinkEventArgs e) {
		LogEvent(string.Format("{0}: FullName={1}", nameof(BarManager.CommandClick), e.Command?.FullName));

		// Ignore any command that is already handled
		if (e.Handled)
			return;

		// Ignore event if a command is not defined
		if (e.Command is not { } command)
			return;

		if ((command.Category == WindowActivateCategory) && (command.Tag is ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow tabbedMdiWindow)) {
			// Activate the TabbedMdiWindow in the Tag
			tabbedMdiWindow.Activate();
			return;
		}

		// Execute an appropriate ProcessXXX method, if available
		// IMPORTANT NOTE: This uses reflection to decide how to process the commands... alternatively use a switch statement like below
		string processMethodName = "Process" + command.FullName.Replace(" ", string.Empty).Replace(".", string.Empty);
		var processMethodInfo = GetType().GetMethod(processMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (processMethodInfo is not null) {
			try {
				processMethodInfo.Invoke(this, parameters: []);
			}
			catch (Exception ex) {
				if (ex.InnerException is not null)
					MessageBox.Show("An exception occurred:\r\n" + ex.InnerException.Message, "Exception Occurred in Client Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		else
			MessageBox.Show(this, string.Format("The command '{0}' has not been implemented for this sample.", command.FullName), "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);

		// Alternative approach to reflection for switching on which command was clicked
		/*
		switch (e.Command.FullName) {
			case "File.Exit":
				ProcessFileExit();
				break;
			// NOTE: Implement other command handling code here
		}
		*/
	}

	/// <summary>
	/// Occurs when a <see cref="BarCommand"/> that causes a popup is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCommandPopup(object sender, BarCommandLinkEventArgs e) {
		//LogEvent(string.Format("{0}: FullName={1}", nameof(BarManager.CommandPopup), e.Command?.FullName));

		switch (e.Command?.FullName) {
			case "Window.WindowList": {
				// Populate the command with the list of open windows
				var command = (BarExpanderButtonCommand)e.Command;
				command.CommandLinks.Clear();
				foreach (var tabbedMdiWindow in dockManager.ActiveDocuments) {
					// Define the text used to represent the document in the active documents list
					var text = tabbedMdiWindow.Text;
					if (tabbedMdiWindow is ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow)
						text = documentWindow.FileName + (documentWindow.Modified ? "*" : string.Empty);

					// Create a command link to active the window that will be stored on the Tag of the link
					var commandLink = new BarButtonLink(
						category: WindowActivateCategory,
						name: string.Empty,
						text,
						tabbedMdiWindow.ImageIndex,
						checkable: true,
						isChecked: (dockManager.SelectedDocument == tabbedMdiWindow)
					);
					commandLink.Command.Tag = tabbedMdiWindow;

					// Add the command link to the list of expander links
					command.CommandLinks.Add(commandLink);
				}
				break;
			}
		}
	}

	/// <summary>
	/// Occurs when a <see cref="BarCommand"/> should be updated.  
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCommandUpdate(object sender, BarCommandLinkEventArgs e) {
		// NOTE: Update commands here if the command update timer is active
	}

	/// <summary>
	/// Occurs when a <see cref="CommandLink"/> is first dropped from the Customize dialog, allowing for initial customization.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCustomizeCommandLinkCreated(object sender, BarCommandLinkEventArgs e) {
		LogEvent(string.Format("{0}: FullName={1}", nameof(BarManager.CustomizeCommandLinkCreated), e.Command?.FullName));
	}

	/// <summary>
	/// Occurs when the <see cref="CustomizeMode"/> property is changed, indicating to start or end customize mode.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCustomizeModeChanged(object sender, EventArgs e) {
		LogEvent(string.Format("{0}: {1}", nameof(BarManager.CustomizeModeChanged), barManager.CustomizeMode));

		// If entering dialog customize mode and the built-in customize form is not enabled...
		if ((!barManager.BuiltInCustomizeDialogEnabled) && (barManager.CustomizeMode == BarCustomizeMode.DialogCustomize)) {

			// Create a customize form (if not already created)
			_customizeForm ??= new BarCustomizeForm(barManager) { Owner = this };

			// Show the customize form
			_customizeForm.Show();
		}
		else {
			// Remove the customize form reference
			_customizeForm = null;
		}
	}

	/// <summary>
	/// Occurs when the <see cref="CustomizeSelectedCommandLink"/> property is changed, while in customize mode.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerCustomizeSelectedCommandLinkChanged(object sender, BarCommandLinkEventArgs e) {
		// Update the customize form with the selection change
		_customizeForm?.UpdateSelectedCommandLink(e.CommandLink);
	}

	/// <summary>
	/// Occurs when a possible shortcut key is typed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerKeyTyped(object sender, BarKeyTypedEventArgs e) {
		if (e.ChordKey != Keys.None) {
			if (e.Key != Keys.None) {
				if (e.Command is not null) {
					// Log event
					LogEvent(string.Format(
						"{0} (Chord shortcut): FullName={1}{2}",
						nameof(BarManager.KeyTyped),
						e.Command.FullName,
						e.Cancel ? " (Key is disabled)" : string.Empty
					));

					// Reset statusbar
					SetStatusMessagePanelText("Ready");
				}
				else {
					// Log event
					LogEvent($"{nameof(BarManager.KeyTyped)} (No chord sequence matched)");

					// Update statusbar
					SetStatusMessagePanelText(string.Format(
						"The key combination ({0}, {1}) is not a command.",
						BarKeyboardShortcut.GetKeyString(e.ChordKey),
						BarKeyboardShortcut.GetKeyString(e.Key)
					));
				}
			}
			else {
				// Log event
				LogEvent($"{nameof(BarManager.KeyTyped)} (Chord started)");

				// Update statusbar
				SetStatusMessagePanelText(string.Format(
					"({0}) was pressed.  Waiting for second key of chord...",
					BarKeyboardShortcut.GetKeyString(e.ChordKey)
				));
			}
		}
		else {
			// Log event
			LogEvent(string.Format("{0} (Single-key shortcut): FullName={1}{2}",
				nameof(BarManager.KeyTyped),
				e.Command?.FullName,
				e.Cancel ? " (Key is disabled)" : string.Empty
			));

			// Reset statusbar
			SetStatusMessagePanelText("Ready");
		}

		// Helper method for setting statusbar text
		void SetStatusMessagePanelText(string text) {
			if (statusBar.Panels["Message"] is StatusBarLabelPanel labelPanel)
				labelPanel.Text = text;
		}
	}

	/// <summary>
	/// Occurs when a menu is torn-off to create a dockable toolbar.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerMenuTearOff(object sender, BarControlEventArgs e) {
		LogEvent(string.Format("{0}: {1}", nameof(BarManager.MenuTearOff), (e.BarControl as DockableToolBar)?.Key));
	}

	/// <summary>
	/// Occurs after the <see cref="BarManager.SelectedMode"/> property is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerSelectedModeChanged(object sender, EventArgs e) {
		var isGlobalMode = (barManager.SelectedMode is null);

		LogEvent(string.Format("{0}: {1}",
			nameof(BarManager.SelectedModeChanged),
			isGlobalMode ? "(Global)" : barManager.SelectedMode
		));

		// Core edit commands are available in either either text editor modes
		var isTextEditorMode = (barManager.SelectedMode == TextEditorMode || barManager.SelectedMode == RichTextEditorMode);
		barManager.Commands["File.Close"]!.Enabled = isTextEditorMode;
		barManager.Commands["File.Save"]!.Enabled = isTextEditorMode;
		barManager.Commands["File.SaveAs"]!.Enabled = isTextEditorMode;
		barManager.Commands["File.SaveAll"]!.Enabled = isTextEditorMode;
		barManager.Commands["File.Print"]!.Enabled = isTextEditorMode;
		barManager.Commands["File.PrintPreview"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.Undo"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.Redo"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.Cut"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.Copy"]!.Enabled = isTextEditorMode;
		UpdateEditPasteEnabledState(); // Edit.Paste
		barManager.Commands["Edit.Delete"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.SelectAll"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.Find"]!.Enabled = isTextEditorMode;
		barManager.Commands["Edit.QuickFind"]!.Enabled = isTextEditorMode;
		UpdateFormatCommandStates();
	}

	/// <summary>
	/// Occurs when the panel is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnBarManagerPropertyGridPanelResize(object sender, EventArgs e) {
		barManagerPropertyGrid.SuspendLayout();

		// Reset the Anchor that is only used to keep designer layout consistent
		barManagerPropertyGrid.Anchor = AnchorStyles.None;

		// Set the size/location of the PropertyGrid to be 1px bigger than the containing panel so the PropertyGrid border is not visible
		barManagerPropertyGrid.Location = new Point(-1, -1);
		barManagerPropertyGrid.Size = new Size(barManagerPropertyGridPanel.Width + 2, barManagerPropertyGridPanel.Height + 2);

		barManagerPropertyGrid.ResumeLayout();
	}

	/// <summary>
	/// Occurs when the value of the <see cref="DockManager.SelectedDocument"/> property changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerSelectedDocumentChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
		// Update the application mode
		UpdateApplicationMode();
		UpdateFormatCommandStates();
		UpdatePositionStatusBarPanel();
	}

	/// <summary>
	/// Invoked when the current renderer configuration is changed.
	/// </summary>
	private void OnRendererChanged() {
		// Get the new color scheme
		var colorScheme = barManager.RendererResolved.ResolvedColorScheme();

		// Update child controls to match the renderer's color scheme
		ThemeHelper.ApplyComponentColors(dockManager, colorScheme, recurseChildren: true);

		// Show disclaimer about dark color schemes
		if (_showDarkThemeDisclaimer && colorScheme.Intent.IsDarkColorScheme()) {
			_showDarkThemeDisclaimer = false;
			ThemeHelper.ShowDarkThemeDisclaimer();
		}
	}

	/// <summary>
	/// Occurs when a statusbar panel is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnStatusBarStatusBarPanelClick(object sender, StatusBarPanelMouseEventArgs e) {
		LogEvent(string.Format("{0}: {1} - {2} click(s) at {3}, {4}",
			nameof(StatusBar.StatusBarPanelClick),
			e.Panel.Key,
			e.Clicks,
			e.X,
			e.Y
		));

		switch (e.Panel.Key) {
			case "ToggleMarquee": {
				if (statusBar.Panels["Progress"] is StatusBarProgressBarPanel panel) {
					if (panel.Style != StatusBarProgressBarPanelStyle.Marquee) {
						panel.Text = "Marquee Mode";
						panel.Style = StatusBarProgressBarPanelStyle.Marquee;
					}
					else {
						panel.Style = StatusBarProgressBarPanelStyle.Continuous;
						panel.Text = "Processing - 40%";
						panel.Value = 40;
					}
				}
				break;
			}
		}
	}

	/// <summary>
	/// Occurs after the selected index is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarPropertiesPropertyGridComboBoxSelectedIndexChanged(object sender, EventArgs e) {
		var toolbarKey = toolBarPropertiesPropertyGridComboBox.Text;
		toolBarPropertiesPropertyGrid.SelectedObject = barManager.DockableToolBars[toolbarKey];
	}

	/// <summary>
	/// Occurs when the panel is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolBarPropertiesPropertyGridPanelResize(object sender, EventArgs e) {
		toolBarPropertiesPropertyGrid.SuspendLayout();

		// Reset the Anchor that is only used to keep designer layout consistent
		toolBarPropertiesPropertyGrid.Anchor = AnchorStyles.None;

		// Set the size/location of the PropertyGrid to be 1px bigger than the containing panel so the PropertyGrid border is not visible
		toolBarPropertiesPropertyGrid.Location = new Point(-1, -1);
		toolBarPropertiesPropertyGrid.Size = new Size(toolBarPropertiesPropertyGridPanel.Width + 2, toolBarPropertiesPropertyGridPanel.Height + 2);

		toolBarPropertiesPropertyGrid.ResumeLayout();
	}

	/// <summary>
	/// The <see cref="TextDocumentWindowBase"/> that is currently selected, if any.
	/// </summary>
	private TextDocumentWindowBase? SelectedTextDocumentWindow
		=> dockManager.SelectedDocument as TextDocumentWindowBase;

	/// <summary>
	/// The <see cref="RichTextDocumentWindow"/> that is currently selected, if any.
	/// </summary>
	private RichTextDocumentWindow? SelectedRichTextDocumentWindow
		=> dockManager.SelectedDocument as RichTextDocumentWindow;

	/// <summary>
	/// Updates the application mode.
	/// </summary>
	private void UpdateApplicationMode() {
		if (dockManager.SelectedDocument is TextDocumentWindow) {
			// In a text document window
			barManager.SelectedMode = TextEditorMode;
			return;
		}
		else if (dockManager.SelectedDocument is RichTextDocumentWindow) {
			// In a rich text document window
			barManager.SelectedMode = RichTextEditorMode;
			return;
		}

		// Set global mode (null)
		barManager.SelectedMode = null;
	}

	/// <summary>
	/// Update the enabled state of the Paste command based on whether there is text data on the clipboard.
	/// </summary>
	private void UpdateEditPasteEnabledState() {
		IDataObject? dataObject;
		try {
			// Work around for .NET framework bug that sometimes throw an exception the first time this is called
			dataObject = Clipboard.GetDataObject();
		}
		catch {
			try {
				// Try again
				dataObject = Clipboard.GetDataObject();
			}
			catch {
				// Give up
				return;
			}
		}
		if (barManager.Commands["Edit.Paste"] is { } command) {
			var isTextEditorMode = (barManager.SelectedMode == TextEditorMode || barManager.SelectedMode == RichTextEditorMode);
			command.Enabled = (isTextEditorMode) && (dataObject is not null) && (dataObject.GetDataPresent(DataFormats.Text));
		}
	}

	/// <summary>
	/// Update the states of the format commands.
	/// </summary>
	private void UpdateFormatCommandStates() {
		bool isRichTextEditorMode = (barManager.SelectedMode == RichTextEditorMode);

		barManager.Commands["Format.FontSize"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.AlignLeft"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.AlignCenter"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.AlignRight"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.BulletedList"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.Outdent"]!.Enabled = isRichTextEditorMode;
		barManager.Commands["Format.Indent"]!.Enabled = isRichTextEditorMode;

		if ((isRichTextEditorMode) && (SelectedRichTextDocumentWindow?.RichTextBox is { } richTextBox)) {
			// Format.FontSize
			if ((richTextBox.SelectionFont is { } selectionFont) && (barManager.Commands["Format.FontSize"] is BarComboBoxCommand fontSizeCommand))
				fontSizeCommand.ControlValue = selectionFont.SizeInPoints.ToString();

			// Format.AlignXXX
			string? alignCommandFullName = richTextBox.SelectionAlignment switch {
				System.Windows.Forms.HorizontalAlignment.Left => "Format.AlignLeft",
				System.Windows.Forms.HorizontalAlignment.Center => "Format.AlignCenter",
				System.Windows.Forms.HorizontalAlignment.Right => "Format.AlignRight",
				_ => null
			};
			if ((alignCommandFullName is not null) && (barManager.Commands["Format.AlignLeft"] is IBarCheckableCommand checkableCommand))
				barManager.SetCheckGroupValue("FormatAlign", checkableCommand);

			// Format.BulletedList
			if (barManager.Commands["Format.BulletedList"] is BarButtonCommand bulletedListCommand)
				bulletedListCommand.Checked = richTextBox.SelectionBullet;
		}
		else {
			// Format.BulletedList
			if (barManager.Commands["Format.BulletedList"] is BarButtonCommand bulletedListCommand)
				bulletedListCommand.Checked = false;
		}
	}

	/// <summary>
	/// Updates the position statusbar panel.
	/// </summary>
	private void UpdatePositionStatusBarPanel() {
		if (statusBar.Panels["Position"] is StatusBarLabelPanel labelPanel) {
			if (dockManager.SelectedDocument is TextDocumentWindowBase selectedTextDocument)
				labelPanel.Text = Math.Max(1, selectedTextDocument.TextBox.Lines.Length) + " line(s)";
			else
				labelPanel.Text = null;
		}
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void OnLoad(EventArgs e) {
		// Call the base method
		base.OnLoad(e);

		if (dockManager.DocumentWindows.Count == 0) {
			// Create a new MDI child form
			var documentWindow = CreateRichTextDocumentWindow("Intro.rtf");

			// Load RTF content
			documentWindow.RichTextBox.Rtf = ActiproSoftware.SampleBrowser.Resources.BarsDemoFeaturesIntro;

			// Reset the modified flag after loading
			documentWindow.Modified = false;

			// Activate the document
			documentWindow.Activate();
		}
	}

}
