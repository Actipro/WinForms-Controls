using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.MarkupLabel;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.DockingSamples.Demo.DockingFeatures;

/// <summary>
/// A form to test the dock controls.
/// </summary>
public partial class MainForm : Form {

	private int _documentWindowIndex = 1;
	private int _toolWindowIndex = 1;

	private bool _showDarkThemeDisclaimer = true;
	private bool _ignoreModifiedDocumentClose = false;
	private bool _ignoreTextChangedEvent = false;

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainForm() {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		#if NETFRAMEWORK
		// 11/15/2023 - Workaround for issue detected on Win11 23H2 (OS Build 22635.2700) where the 'resize' event of the panel
		//   that contains these property grids was not being raised and, as a result, the property grid layout was incorrect until
		//   they were resized.  Could not reproduce on Win11 22H2.  Issue was not present on "netcoreapp3.1" or "net6.0-windows".
		ResizeDockManagerPropertyGrid();
		ResizeToolWindowPropertyGrid();
		#endif

		// Select the first item
		if (toolWindowPropertyGridComboBox.Items.Count > 0)
			toolWindowPropertyGridComboBox.SelectedIndex = 0;
		if (dockManagerPropertyGridComboBox.Items.Count > 0)
			dockManagerPropertyGridComboBox.SelectedIndex = 0;

		// Create documents
		CreateTextDocument(fileName: null, text: "This is a read-only document.  Notice the lock context image in the tab.", readOnly: true).Activate();
		CreateTextDocument(fileName: null, text: null, readOnly: false).Activate();

		// (For Internal Use) Set the size for screenshots
		// Size = new Size(408, 377);
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates a text document.
	/// </summary>
	/// <returns>The <see cref="DocumentWindow"/> that was created or the existing document if one was already open.</returns>
	private DocumentWindow CreateTextDocument(string? fileName, string? text, bool readOnly) {
		// NOTE: The full path of each document is stored as the DocumentWindow.Key

		// If the document is already open for the file, show a message
		if (dockManager.DocumentWindows[key: fileName] is { } existingDocumentWindow) {
			existingDocumentWindow.Activate();
			MessageBox.Show($"The file '{fileName}' is already open.", "File Already Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return existingDocumentWindow;
		}

		// Determine the type of file
		string fileType = "Text";
		if (fileName is not null) {
			switch (Path.GetExtension(fileName).ToLower()) {
				case ".bmp":
				case ".gif":
				case ".ico":
				case ".jpg":
				case ".png":
					fileType = "Image";
					readOnly = true;
					break;
			}
		}

		DocumentWindow documentWindow;
		switch (fileType) {
			case "Image": {
				if (fileName is null)
					throw new ArgumentNullException(nameof(fileName), "The file name must be provided for Image file types.");

				// Create a PictureBox for the document
				var pictureBox = new PictureBox {
					Image = Image.FromFile(fileName)
				};

				// Create the document window with the PictureBox as content
				documentWindow = new DocumentWindow(dockManager, key: fileName, text: Path.GetFileName(fileName), imageIndex: 4, childControl: pictureBox) {
					FileName = fileName,
					FileType = $"Image File (*{Path.GetExtension(fileName).ToLower()})"
				};
				break;
			}
			default: {
				// If no data was passed in, generate some
				fileName ??= $"Document{_documentWindowIndex++}.txt";
				text ??= $"Visit our web site to learn more about Actipro WinForms Studio or our other controls:\r\nhttps://www.actiprosoftware.com/\r\n\r\nThis document was created at {DateTime.Now}.";

				// Create a RichTextBox for the document
				var richTextBox = new RichTextBox {
					Multiline = true,
					Font = new Font("Courier New", 10),
					BorderStyle = BorderStyle.None,
					HideSelection = false,
					ReadOnly = readOnly,
					ScrollBars = RichTextBoxScrollBars.Both,
					Text = text,
					WordWrap = false
				};
				richTextBox.LinkClicked += OnTextBoxLinkClicked;
				richTextBox.TextChanged += OnTextBoxTextChanged;

				// Create the document window with the RichTextBox as content
				documentWindow = new DocumentWindow(dockManager, key: fileName, text: Path.GetFileName(fileName), imageIndex: 3, childControl: richTextBox) {
					FileName = fileName,
					FileType = $"Text File (*{Path.GetExtension(fileName).ToLower()})"
				};
				break;
			}
		}

		if (readOnly) {
			// Load and display a read-only context image for the document window
			var readOnlyContextMenu = ActiproSoftware.Properties.Docking.AssemblyInfo.Instance.GetImage(
				image: ActiproSoftware.Properties.Docking.ImageResource.ContextReadOnly,
				scaleFactor: DpiHelper.GetDpiScale(this)
			);
			documentWindow.ContextImage = readOnlyContextMenu;
		}

		return documentWindow;
	}

	/// <summary>
	/// Dynamically creates a new tool window capable of displaying rich text.
	/// </summary>
	/// <returns>The tool window that was created.</returns>
	private ToolWindow CreateTextToolWindow() {
		var key = "Tool Window " + (_toolWindowIndex++);

		// First tool window
		var richTextBox = new RichTextBox {
			Multiline = true,
			ScrollBars = RichTextBoxScrollBars.Both,
			Text = key + $" Created at {DateTime.Now}",
		};
		return new ToolWindow(dockManager, key, text: key, image: null, childControl: richTextBox);
	}

	/// <summary>
	/// Returns the <c>RichTextBox</c> control for the selected document if it is a text document.
	/// </summary>
	/// <returns>The selected <c>RichTextBox</c> control, or <c>null</c> if a text document is not selected.</returns>
	private RichTextBox? GetSelectedRichTextControl() {
		// Test if the content of the selected document is a RichTextBox
		if ((dockManager.SelectedDocument is DocumentWindow selectedDocument)
			&& (selectedDocument.Controls.Count == 1)) {

			return selectedDocument.Controls[0] as RichTextBox;
		}

		return null;
	}

	/// <summary>
	/// Handles the closing of a document.
	/// </summary>
	/// <param name="documentWindow">The document to examine.</param>
	/// <returns><c>true</c> if the document should be allowed to close; otherwise <c>false</c> to cancel closing the document.</returns>
	private bool HandleDocumentClosing(DocumentWindow documentWindow) {
		// Prompt the user to save changes to a modified document before closing
		if (documentWindow.Modified) {
			// NOTE: The full path of each document is stored as the DocumentWindow.Key
			var fileName = documentWindow.Key;
			var response = MessageBox.Show($"Do you want to save changes to '{fileName}'?", "Document Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
			switch (response) {
				case DialogResult.Yes:
					if (!PromptSaveDocument(documentWindow))
						return false; // Save dialog cancelled
					break;
				case DialogResult.Cancel:
					return false; // Save prompt cancelled
			}
			;
		}

		// Indicate OK to close document
		return true;
	}

	/// <summary>
	/// Returns whether the currently selected document is a text document.
	/// </summary>
	/// <param name="richTextBox">When a text document is selected, outputs the <c>RichTextBox</c> of the selected document.</param>
	/// <returns>
	/// <c>true</c> if it is a document; otherwise, <c>false</c>.
	/// </returns>
	private bool IsTextDocumentSelected() {
		// Test if the content of the selected document is a RichTextBox
		return GetSelectedRichTextControl() is not null;
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
	/// Occurs when using tabbed MDI and the Active Files button is clicked, requesting a drop-down menu of open files.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerActiveFilesContextMenu(object sender, TabbedMdiWindowContextMenuEventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(DockManager.ActiveFilesContextMenu));
	}

	/// <summary>
	/// Occurs before a tool window in auto-hide mode is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerAutoHideToolWindowDisplaying(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}", nameof(DockManager.AutoHideToolWindowDisplaying), e.TabbedMdiWindow?.Key));
	}

	/// <summary>
	/// Occurs before a tool window in auto-hide mode is hidden.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerAutoHideToolWindowHiding(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}", nameof(DockManager.AutoHideToolWindowHiding), e.TabbedMdiWindow?.Key));
	}

	/// <summary>
	/// Occurs as a tool window layout is being read, allowing for custom data to be loaded.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerLoadCustomToolWindowLayoutData(object sender, DockLoadCustomToolWindowLayoutDataEventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(DockManager.LoadCustomToolWindowLayoutData));
	}

	/// <summary>
	/// Occurs when the selection changes on the Next Window Navigation form.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerNextWindowNavigationSelectionChanged(object sender, NextWindowNavigationEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}", nameof(DockManager.NextWindowNavigationSelectionChanged), e.TabbedMdiWindow?.Key));
	}

	/// <summary>
	/// Occurs as a tool window layout is being written, allowing for custom data to be saved.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerSaveCustomToolWindowLayoutData(object sender, DockSaveCustomToolWindowLayoutDataEventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(DockManager.SaveCustomToolWindowLayoutData));
	}

	/// <summary>
	/// Occurs when the value of the <see cref="SelectedDocument"/> property changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerSelectedDocumentChanged(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}", nameof(DockManager.SelectedDocumentChanged), e.TabbedMdiWindow?.Key ?? "<null>"));
	}

	/// <summary>
	/// Occurs after the selected tabbed MDI container is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerSelectedTabbedMdiContainerChanged(object sender, EventArgs e) {
		// No operation, but log the event
		int selectedIndex = -1;
		if (dockManager.TabbedMdiRootContainer is { } tabbedMdiRootContainer)
			selectedIndex = tabbedMdiRootContainer.SelectedIndex;
		LogEvent(string.Format("{0}: SelectedIndex={1}", nameof(DockManager.SelectedTabbedMdiContainerChanged), selectedIndex));
	}

	/// <summary>
	/// Occurs after one or more tool windows are dragged by the user.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerToolWindowDragged(object sender, EventArgs e) {
		LogEvent(nameof(DockManager.ToolWindowDragged));

		// Reset the status bar
		statusLabel.Text = "Ready";
	}

	/// <summary>
	/// Occurs before one or more tool windows are dragged by the user.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerToolWindowDragging(object sender, CancelEventArgs e) {
		LogEvent(string.Format("{0}: Cancel={1}", nameof(DockManager.ToolWindowDragging), e.Cancel));

		// Update the status bar
		if (!e.Cancel)
			statusLabel.Text = "Hold down CTRL to prevent docking.  Point to title bar of destination window to link tabs.";
	}

	/// <summary>
	/// Occurs after tool window layout is loaded.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerToolWindowLayoutLoaded(object sender, EventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(DockManager.ToolWindowLayoutLoaded));
	}

	/// <summary>
	/// Occurs before tool window layout is loaded.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerToolWindowLayoutLoading(object sender, EventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(DockManager.ToolWindowLayoutLoading));
	}

	/// <summary>
	/// Occurs after a window is activated from an inactive state and is visible.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowActivated(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}", nameof(DockManager.WindowActivated), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType));
	}

	/// <summary>
	/// Occurs before a window is activated from an inactive state.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowActivating(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}", nameof(DockManager.WindowActivating), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType));
	}

	/// <summary>
	/// Occurs after a window is deactivated from an active state.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowClosed(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}", nameof(DockManager.WindowClosed), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType));
	}

	/// <summary>
	/// Occurs before a window is deactivated from an active state.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowClosing(object sender, TabbedMdiWindowClosingEventArgs e) {
		// If a document is being closed and it has been modified...
		if ((!_ignoreModifiedDocumentClose) && (e.TabbedMdiWindow is DocumentWindow documentWindow)) {
			if (!HandleDocumentClosing(documentWindow))
				e.Cancel = true;
		}

		LogEvent(string.Format("{0}: Key={1}; Type={2}; Reason={3}; Cancel={4}",
			nameof(DockManager.WindowClosing),
			e.TabbedMdiWindow?.Key,
			e.TabbedMdiWindow?.DockObjectType,
			e.Reason,
			e.Cancel
		));
	}

	/// <summary>
	/// Occurs when a window needs a context menu displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowContextMenu(object sender, TabbedMdiWindowContextMenuEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}; Source={3}",
			nameof(DockManager.WindowContextMenu),
			e.TabbedMdiWindow?.Key,
			e.TabbedMdiWindow?.DockObjectType,
			e.Source
		));
	}

	/// <summary>
	/// Occurs immediately after a window is created.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowCreated(object sender, TabbedMdiWindowEventArgs e) {
		LogEvent(string.Format("{0}: Key={1}; Type={2}; CreationMethod={3}",
			nameof(DockManager.WindowCreated),
			e.TabbedMdiWindow?.Key,
			e.TabbedMdiWindow?.DockObjectType,
			e.TabbedMdiWindow?.CreationMethod
		));

		// If the window is a tool window...
		if (e.TabbedMdiWindow is ToolWindow toolWindow) {
			// Create a menu item for the View menu that will activate the tool window
			var menuItem = new ToolStripMenuItem(toolWindow.Text, image: null, onClick: OnViewToolWindowMenuItemClick) {
				Tag = toolWindow // Associate the menu item with the tool window
			};

			// Insert the menu item at the top of the View menu, after any existing tool window menu items
			var lastToolWindowIndex = viewToolStripMenuItem.DropDownItems.OfType<ToolStripItem>().ToList().FindLastIndex(x => x.Tag is ToolWindow);
			viewToolStripMenuItem.DropDownItems.Insert(lastToolWindowIndex + 1, menuItem);

			// Add the tool window to the properties drop-down
			toolWindowPropertyGridComboBox.Items.Add(toolWindow);
		}
	}

	/// <summary>
	/// Occurs when a window is disposed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowDisposed(object sender, TabbedMdiWindowEventArgs e) {
		LogEvent(string.Format("{0}: Key={1}; Type={2}", nameof(DockManager.WindowDisposed), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType));

		// If the window is a tool window...
		if (e.TabbedMdiWindow is ToolWindow toolWindow) {
			// Remove the menu item from the View menu that activated the tool window
			for (var index = 0; index < viewToolStripMenuItem.DropDownItems.Count; index++) {
				if (viewToolStripMenuItem.DropDownItems[index].Tag == toolWindow) {
					viewToolStripMenuItem.DropDownItems.RemoveAt(index);
					break;
				}
			}

			// Remove the tool window from the properties drop-down
			toolWindowPropertyGridComboBox.Items.Remove(toolWindow);
			if ((toolWindowPropertyGridComboBox.SelectedIndex == -1) && (toolWindowPropertyGridComboBox.Items.Count > 0))
				toolWindowPropertyGridComboBox.SelectedIndex = 0;
		}
	}

	/// <summary>
	/// Occurs when a window receives focus.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowFocused(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}", nameof(DockManager.WindowFocused), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType));
	}

	/// <summary>
	/// Occurs before the window is activated for the first time, allowing for lazy initialization of the window.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowInitializing(object sender, TabbedMdiWindowEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Key={1}; Type={2}; CreationMethod={3}",
			nameof(DockManager.WindowInitializing),
			e.TabbedMdiWindow?.Key,
			e.TabbedMdiWindow?.DockObjectType,
			e.TabbedMdiWindow?.CreationMethod
		));
	}

	/// <summary>
	/// Occurs before a tool tip is displayed for a window tab and gives an opportunity to update the windows's tool tip text.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerWindowTabToolTipDisplaying(object sender, TabbedMdiWindowEventArgs e) {
		// LogEvent(string.Format("{0}: Key={1}; Type={2}; ToolTipText={3}", 
		// 	nameof(DockManager.WindowTabToolTipDisplaying), e.TabbedMdiWindow?.Key, e.TabbedMdiWindow?.DockObjectType, e.TabbedMdiWindow?.ToolTipText));

		// Quit if the tabbed MDi window is undefined
		if (e.TabbedMdiWindow is not { } tabbedMdiWindow)
			return;

		// Update the tool tip text
		if (tabbedMdiWindow.DockObjectType == DockObjectType.ToolWindow) {
			// Show the tool window text in the tool tip
			tabbedMdiWindow.ToolTipText = tabbedMdiWindow.Text;
		}
		else if (tabbedMdiWindow.DockObjectType == DockObjectType.DocumentWindow) {
			// The key of document window in this sample is document's file name
			var fileName = tabbedMdiWindow.Key;
			tabbedMdiWindow.ToolTipText = fileName;

			// If the document is an Image, add extra info to the tip
			if ((tabbedMdiWindow.Controls.Count == 1) && (tabbedMdiWindow.Controls[0] is PictureBox { Image: { } image }))
				tabbedMdiWindow.ToolTipText += string.Format("{0}Image Size: {1} x {2}", Environment.NewLine, image.Width, image.Height);
		}
	}

	/// <summary>
	/// Occurs when the selected index changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerPropertyGridComboBoxSelectedIndexChanged(object sender, EventArgs e) {
		dockManagerPropertyGrid.SelectedObject = dockManagerPropertyGridComboBox.SelectedIndex switch {
			1 => dockManager.DockRenderer,
			2 => dockManager.ToolWindowContainerTabStripRenderer,
			3 => dockManager.TabbedMdiContainerTabStripRenderer,
			_ => dockManager
		};
	}

	/// <summary>
	/// Occurs when the panel is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnDockManagerPropertyGridPanelResize(object sender, EventArgs e)
		=> ResizeDockManagerPropertyGrid();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditCopyMenuItemClick(object sender, EventArgs e)
		=> GetSelectedRichTextControl()?.Copy();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditCutMenuItemClick(object sender, EventArgs e)
		=> GetSelectedRichTextControl()?.Cut();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditDeleteMenuItemClick(object sender, EventArgs e) {
		if (GetSelectedRichTextControl() is { } richTextBox)
			richTextBox.SelectedText = string.Empty;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditMenuItemPopup(object sender, EventArgs e) {
		// Enable/disable the Edit menu items based on selection
		var isEnabled = IsTextDocumentSelected();
		cutToolStripMenuItem.Enabled = isEnabled;
		copyToolStripMenuItem.Enabled = isEnabled;
		pasteToolStripMenuItem.Enabled = isEnabled;
		deleteToolStripMenuItem.Enabled = isEnabled;
		undoToolStripMenuItem.Enabled = isEnabled;
		redoToolStripMenuItem.Enabled = isEnabled;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditPasteMenuItemClick(object sender, EventArgs e)
		=> GetSelectedRichTextControl()?.Paste();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditRedoMenuItemClick(object sender, EventArgs e)
		=> GetSelectedRichTextControl()?.Redo();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnEditUndoMenuItemClick(object sender, EventArgs e)
		=> GetSelectedRichTextControl()?.Undo();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileActivateAllInactiveToolWindowsMenuItemClick(object sender, EventArgs e)
		=> dockManager.ActivateAllInactiveToolWindows();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileCloseAllToolWindowsMenuItemClick(object sender, EventArgs e)
		=> dockManager.CloseAllActiveToolWindows(force: false);

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileCloseDocumentMenuItemClick(object sender, EventArgs e)
		=> dockManager.SelectedDocument?.Close();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileCreate3ToolWindowsInARowMenuItemClick(object sender, EventArgs e) {
		// Create three new tool window instances
		var firstToolWindow = CreateTextToolWindow();
		var secondToolWindow = CreateTextToolWindow();
		var thirdToolWindow = CreateTextToolWindow();

		// Update border styles
		UpdateChildControlBorderStyles();

		// Dock three in a row with the same size...

		// First tool window is docked left
		firstToolWindow.DockTo(dockManager, DockOperationType.LeftOuter);

		// Second tool window docked below the first tool window and will initially be 2/3rds the size of the first tool window
		//   making the first tool window 1/3rd of the available height
		secondToolWindow.DockedSize = new Size(firstToolWindow.ToolWindowContainer!.Width, (int)(0.667f * firstToolWindow.ToolWindowContainer.Height));
		secondToolWindow.DockTo(firstToolWindow, DockOperationType.BottomInner);

		// Third tool window docked below the second tool window at half the height of the second tool window which results in the
		//   second and third tool windows being 1/3rd of original available height
		thirdToolWindow.DockedSize = new Size(secondToolWindow.ToolWindowContainer!.Width, (int)(0.5f * secondToolWindow.ToolWindowContainer.Height));
		thirdToolWindow.DockTo(secondToolWindow, DockOperationType.BottomInner);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileCreate3ToolWindowsAttachedMenuItemClick(object sender, EventArgs e) {
		// Create three new tool window instances
		var firstToolWindow = CreateTextToolWindow();
		var secondToolWindow = CreateTextToolWindow();
		var thirdToolWindow = CreateTextToolWindow();

		// Update border styles
		UpdateChildControlBorderStyles();

		// Undock/float the first tool window
		var deviceDpi = DpiHelper.GetDeviceDpi(this);
		firstToolWindow.FloatingLocation = DpiHelper.ScalePoint(new Point(100, 100), deviceDpi);
		firstToolWindow.FloatingSize = DpiHelper.ScaleSize(new Size(300, 200), deviceDpi);
		firstToolWindow.Undock();

		// Attach the other tool windows to the first tool window
		secondToolWindow.DockTo(firstToolWindow, DockOperationType.Attach);
		thirdToolWindow.DockTo(secondToolWindow, DockOperationType.Attach);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileExitMenuItemClick(object sender, EventArgs e)
		=> Close();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileLoadToolWindowLayoutMenuItemClick(object sender, EventArgs e) {
		// Show the dialog
		openFileDialog.Filter = "XML Tool Window Layout Files (*.xml)|*.xml";
		openFileDialog.FileName = "TWLayout.xml";
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Load the layout
		dockManager.LoadToolWindowLayoutFromFile(openFileDialog.FileName);
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileMenuItemPopup(object sender, EventArgs e) {
		// "File > Close" requires a selected document
		closeDocumentToolStripMenuItem.Enabled = (dockManager.SelectedDocument is not null);

		// "File > Save" only supported by text documents in this sample
		saveDocumentToolStripMenuItem.Enabled = IsTextDocumentSelected();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileNewTextDocumentMenuItemClick(object sender, EventArgs e) {
		switch (dockManager.DocumentMdiStyle) {
			case DocumentMdiStyle.ToolWindowInnerFill:
			case DocumentMdiStyle.None:
				MessageBox.Show("No windows may be placed in the document area because the DockManager.DocumentMdiStyle property is set to ToolWindowInnerFill or None.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
		}

		// Create a document window
		CreateTextDocument(fileName: null, text: null, readOnly: false).Activate();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileOpenDocumentMenuItemClick(object sender, EventArgs e) {
		switch (dockManager.DocumentMdiStyle) {
			case DocumentMdiStyle.ToolWindowInnerFill:
			case DocumentMdiStyle.None:
				MessageBox.Show("No windows may be placed in the document area because the DockManager.DocumentMdiStyle property is set to ToolWindowInnerFill or None.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
		}

		// Show the dialog
		openFileDialog.Filter = "All Documents (*.*)|*.*";
		openFileDialog.FileName = string.Empty;
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Get the text of the document
		var reader = File.OpenText(openFileDialog.FileName);
		var text = reader.ReadToEnd();
		reader.Close();

		// Create a document window
		CreateTextDocument(openFileDialog.FileName, text, readOnly: false).Activate();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileSaveDocumentMenuItemClick(object sender, EventArgs e) {
		// Ignore if a text document is not selected (only text documents supported in this sample)
		if (!IsTextDocumentSelected())
			return;

		PromptSaveDocument((DocumentWindow)dockManager.SelectedDocument!);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnFileSaveToolWindowLayoutMenuItemClick(object sender, EventArgs e) {
		// Show the dialog
		saveFileDialog.Filter = "XML Tool Window Layout Files (*.xml)|*.xml";
		saveFileDialog.FileName = "TWLayout.xml";
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Save the layout
		dockManager.SaveToolWindowLayoutToFile(saveFileDialog.FileName);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnHelpAboutMenuItemClick(object sender, EventArgs e)
		=> SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com/products/controls/windowsforms");

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnHelpWebSiteMenuItemClick(object sender, EventArgs e)
		=> SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com");

	/// <summary>
	/// Occurs when the link is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnMarkupLabelLinkClick(object sender, ActiproSoftware.UI.WinForms.Controls.MarkupLabel.MarkupLabelLinkClickEventArgs e) {
		LogEvent(string.Format("{0}.{1}: HRef={2}", ((MarkupLabel)sender).Name, nameof(MarkupLabel.LinkClick), e.Element.HRef));
		if (e.Element.HRef is { } href)
			SampleBrowser.Program.LaunchExternalBrowser(href);
	}

	/// <summary>
	/// Invoked when the current renderer configuration is changed.
	/// </summary>
	private void OnRendererChanged() {
		// Changing themes can cause RichTextBox controls to report a TextChanged event
		_ignoreTextChangedEvent = true;
		try {
			UpdateChildControlBorderStyles();
			OnDockManagerPropertyGridComboBoxSelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);

			// Get the new color scheme
			var colorScheme = dockManager.DockRendererResolved.ResolvedColorScheme();

			// Update child controls to match the renderer's color scheme
			ThemeHelper.ApplyComponentColors(this, colorScheme, recurseChildren: true);

			// Explicitly set specific control themes
			markupLabelPanel.BackColor = markupLabel.BackColor = colorScheme.GetKnownColor(KnownColor.Window);

			// Show disclaimer about dark color schemes
			if (_showDarkThemeDisclaimer && colorScheme.Intent.IsDarkColorScheme()) {
				_showDarkThemeDisclaimer = false;
				ThemeHelper.ShowDarkThemeDisclaimer();
			}
		}
		finally {
			_ignoreTextChangedEvent = false;
		}
	}

	/// <summary>
	/// Occurs when a toolbar button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolStripButtonClick(object sender, EventArgs e) {
		var menuItem = ((ToolStripItem)sender).Tag?.ToString() switch {
			"NewTextDocument" => newTextDocumentToolStripMenuItem,
			"OpenDocument" => openDocumentToolStripMenuItem,
			"SaveDocument" => saveDocumentToolStripMenuItem,
			"Cut" => cutToolStripMenuItem,
			"Copy" => copyToolStripMenuItem,
			"Paste" => pasteToolStripMenuItem,
			"Delete" => deleteToolStripMenuItem,
			"Undo" => undoToolStripMenuItem,
			"Redo" => redoToolStripMenuItem,
			_ => null
		};
		menuItem?.PerformClick();
	}

	/// <summary>
	/// Occurs when the selected index changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolWindowPropertyGridComboBoxSelectedIndexChanged(object sender, EventArgs e) {
		toolWindowPropertyGrid.SelectedObject = toolWindowPropertyGridComboBox.SelectedItem;
	}

	/// <summary>
	/// Occurs when the panel is resized.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnToolWindowPropertyGridPanelResize(object sender, EventArgs e)
		=> ResizeToolWindowPropertyGrid();

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockGuideStyleMenuItemPopup(object sender, EventArgs e) {
		dockGuideStyleNoneToolStripMenuItem.Checked = (dockManager.DockGuideStyle == DockGuideStyle.None);
		dockGuideStyleModernToolStripMenuItem.Checked = (dockManager.DockGuideStyle == DockGuideStyle.Modern);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockGuideStyleNoneMenuItemClick(object sender, EventArgs e) {
		dockManager.DockGuideStyle = DockGuideStyle.None;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockGuideStyleModernMenuItemClick(object sender, EventArgs e) {
		dockManager.DockGuideStyle = DockGuideStyle.Modern;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockHintStyleMenuItemPopup(object sender, EventArgs e) {
		dockHintStyleRubberBandHatchedToolStripMenuItem.Checked = (dockManager.DockHintStyle == DockHintStyle.RubberBandHatched);
		dockHintStyleTranslucentToolStripMenuItem.Checked = (dockManager.DockHintStyle == DockHintStyle.Translucent);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockHintStyleRubberBandHatchedMenuItemClick(object sender, EventArgs e) {
		dockManager.DockHintStyle = DockHintStyle.RubberBandHatched;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewDockHintStyleTranslucentMenuItemClick(object sender, EventArgs e) {
		dockManager.DockHintStyle = DockHintStyle.Translucent;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewMagnetismGapDistanceMenuItemClick(object sender, EventArgs e) {
		// Only one option can be checked at a time
		magnetism0GapDistanceToolStripMenuItem.Checked = (sender == magnetism0GapDistanceToolStripMenuItem);
		magnetism1GapDistanceToolStripMenuItem.Checked = (sender == magnetism1GapDistanceToolStripMenuItem);
		magnetism2GapDistanceToolStripMenuItem.Checked = (sender == magnetism2GapDistanceToolStripMenuItem);

		// Update the magnetism gap distance
		if (magnetism0GapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismGapDistance = 0;
		else if (magnetism1GapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismGapDistance = 1;
		else if (magnetism2GapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismGapDistance = 2;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewMagnetismSnapDistanceMenuItemClick(object sender, EventArgs e) {
		// Only one option can be checked at a time
		magnetism0SnapDistanceToolStripMenuItem.Checked = (sender == magnetism0SnapDistanceToolStripMenuItem);
		magnetism5SnapDistanceToolStripMenuItem.Checked = (sender == magnetism5SnapDistanceToolStripMenuItem);
		magnetism10SnapDistanceToolStripMenuItem.Checked = (sender == magnetism10SnapDistanceToolStripMenuItem);

		// Update the magnetism snap distance
		if (magnetism0SnapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismSnapDistance = 0;
		else if (magnetism5SnapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismSnapDistance = 5;
		else if (magnetism10SnapDistanceToolStripMenuItem.Checked)
			dockManager.MagnetismSnapDistance = 10;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewMenuItemPopup(object sender, EventArgs e) {
		tabbedMDITabImagesVisibleToolStripMenuItem.Checked = dockManager.TabbedMdiTabImagesVisible;

		// Update the View menu item text for the tool window
		for (var index = 0; index < viewToolStripMenuItem.DropDownItems.Count; index++) {
			var viewToolWindowMenuItem = viewToolStripMenuItem.DropDownItems[index];
			if (viewToolWindowMenuItem.Tag is ToolWindow toolWindow) {
				viewToolWindowMenuItem.Text = toolWindow.Text;
				viewToolWindowMenuItem.Image = toolWindow.GetImage();
			}
		}
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewNextWindowNavigationEnabledMenuItemClick(object sender, EventArgs e) {
		dockManager.NextWindowNavigationEnabled = !dockManager.NextWindowNavigationEnabled;
		nextWindowNavigationEnabledToolStripMenuItem.Checked = dockManager.NextWindowNavigationEnabled;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewNextWindowNavigationTypeMenuItemPopup(object sender, EventArgs e) {
		nextWindowNavigationTypeToolAndDocumentWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.ToolAndDocumentWindow);
		nextWindowNavigationTypeToolWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.ToolWindow);
		nextWindowNavigationTypeDocumentWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.DocumentWindow);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewNextWindowNavigationTypeDocumentWindowMenuItemClick(object sender, EventArgs e) {
		dockManager.NextWindowNavigationType = NextWindowNavigationType.DocumentWindow;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewNextWindowNavigationTypeToolAndDocumentWindowMenuItemClick(object sender, EventArgs e) {
		dockManager.NextWindowNavigationType = NextWindowNavigationType.ToolAndDocumentWindow;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewNextWindowNavigationTypeToolWindowMenuItemClick(object sender, EventArgs e) {
		dockManager.NextWindowNavigationType = NextWindowNavigationType.ToolWindow;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererMenuItemPopup(object sender, EventArgs e) {
		if (dockManager.DockRenderer is { } dockRenderer) {
			rendererMetroDarkToolStripMenuItem.Checked = ((dockRenderer.GetType() == typeof(MetroDockRenderer)) && (dockRenderer.ColorScheme.BaseColorSchemeType == WindowsColorSchemeType.MetroDark));
			rendererMetroLightToolStripMenuItem.Checked = ((dockRenderer.GetType() == typeof(MetroDockRenderer)) && (dockRenderer.ColorScheme.BaseColorSchemeType == WindowsColorSchemeType.MetroLight));
			rendererOffice2003ToolStripMenuItem.Checked = (dockRenderer.GetType() == typeof(OfficeClassicDockRenderer));
			rendererVisualStudio2022BlueToolStripMenuItem.Checked = (dockRenderer.GetType() == typeof(VisualStudioDockRenderer) && (dockRenderer.ColorScheme.BaseColorSchemeType == WindowsColorSchemeType.VisualStudioBlue));
			rendererVisualStudio2005ToolStripMenuItem.Checked = (dockRenderer.GetType() == typeof(VisualStudioClassicDockRenderer));
			rendererVisualStudio2002ToolStripMenuItem.Checked = (dockRenderer.GetType() == typeof(WindowsClassicDockRenderer));
		}
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererMetroDarkToolStripMenuItemClick(object sender, EventArgs e) {
		var colorSchemeType = WindowsColorSchemeType.MetroDark;
		dockManager.DockRenderer = new MetroDockRenderer(colorSchemeType);
		dockManager.TabbedMdiContainerTabStripRenderer = new MetroDocumentWindowTabStripRenderer(colorSchemeType);
		dockManager.ToolWindowContainerTabStripRenderer = new MetroToolWindowTabStripRenderer(colorSchemeType);
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererMetroLightMenuItemClick(object sender, EventArgs e) {
		var colorSchemeType = WindowsColorSchemeType.MetroLight;
		dockManager.DockRenderer = new MetroDockRenderer(colorSchemeType);
		dockManager.TabbedMdiContainerTabStripRenderer = new MetroDocumentWindowTabStripRenderer(colorSchemeType);
		dockManager.ToolWindowContainerTabStripRenderer = new MetroToolWindowTabStripRenderer(colorSchemeType);
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererOffice2003MenuItemClick(object sender, EventArgs e) {
		dockManager.DockRenderer = new OfficeClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new OfficeClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new OfficeClassicToolWindowTabStripRenderer();
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererVisualStudio2002MenuItemClick(object sender, EventArgs e) {
		dockManager.DockRenderer = new WindowsClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new WindowsClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new WindowsClassicToolWindowTabStripRenderer();
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererVisualStudio2005MenuItemClick(object sender, EventArgs e) {
		dockManager.DockRenderer = new VisualStudioClassicDockRenderer();
		dockManager.TabbedMdiContainerTabStripRenderer = new VisualStudioClassicDocumentWindowTabStripRenderer();
		dockManager.ToolWindowContainerTabStripRenderer = new VisualStudioClassicToolWindowTabStripRenderer();
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewRendererVisualStudio2022BlueMenuItemClick(object sender, EventArgs e) {
		var colorSchemeType = WindowsColorSchemeType.VisualStudioBlue;
		dockManager.DockRenderer = new VisualStudioDockRenderer(colorSchemeType);
		dockManager.TabbedMdiContainerTabStripRenderer = new VisualStudioDocumentWindowTabStripRenderer(colorSchemeType);
		dockManager.ToolWindowContainerTabStripRenderer = new VisualStudioToolWindowTabStripRenderer(colorSchemeType);
		OnRendererChanged();
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewSplitterExtentMenuItemPopup(object sender, EventArgs e) {
		// Only one item can be checked at a time
		var dockRenderer = dockManager.DockRenderer;
		splitterExtent3PixelsToolStripMenuItem.Checked = (dockRenderer?.SplitterExtent == 3);
		splitterExtent4PixelsToolStripMenuItem.Checked = (dockRenderer?.SplitterExtent == 4);
		splitterExtent5PixelsToolStripMenuItem.Checked = (dockRenderer?.SplitterExtent == 5);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewSplitterExtent3PixelsMenuItemClick(object sender, EventArgs e) {
		if (dockManager.DockRenderer is DockRenderer dockRenderer)
			dockRenderer.SplitterExtent = 3;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewSplitterExtent4PixelsMenuItemClick(object sender, EventArgs e) {
		if (dockManager.DockRenderer is DockRenderer dockRenderer)
			dockRenderer.SplitterExtent = 4;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewSplitterExtent5PixelsMenuItemClick(object sender, EventArgs e) {
		if (dockManager.DockRenderer is DockRenderer dockRenderer)
			dockRenderer.SplitterExtent = 5;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewTabbedMDITabImagesVisibleMenuItemClick(object sender, EventArgs e) {
		dockManager.TabbedMdiTabImagesVisible = !dockManager.TabbedMdiTabImagesVisible;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnViewToolWindowMenuItemClick(object? sender, EventArgs e) {
		// This sample stores the associated ToolWindow for View menu items on the Tag
		if ((sender as ToolStripItem)?.Tag is ToolWindow toolWindow)
			toolWindow.Activate();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowActivateDocumentMenuItemClick(object? sender, EventArgs e) {
		// This sample stores the associated ToolWindow for View menu items on the Tag
		if ((sender as ToolStripItem)?.Tag is TabbedMdiWindow tabbedMdiWindow)
			tabbedMdiWindow.Activate();
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowAutoHideAllMenuItemClick(object sender, EventArgs e)
		=> dockManager.AutoHideAllToolWindowsDockedInHost();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowAutoHideMenuItemClick(object sender, EventArgs e) {
		if (dockManager.FocusedToolWindow is { } focusedToolWindow) {
			if (focusedToolWindow.ToolWindowContainer is { } toolWindowContainer) {
				// Hide all the tool windows in the container of the focused tool window
				toolWindowContainer.AutoHide();
			}
			else {
				// Hide just the focused tool window
				focusedToolWindow.State = ToolWindowState.AutoHide;
			}
		}
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowCascadeMenuItemClick(object sender, EventArgs e)
		=> dockManager.CascadeDocuments();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowCloseAllDocumentsMenuItemClick(object sender, EventArgs e)
		=> dockManager.CloseAllActiveDocuments(force: false);

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowDockableMenuItemClick(object sender, EventArgs e) {
		if (dockManager.FocusedToolWindow is { } focusedToolWindow) {
			switch (focusedToolWindow.State) {
				case ToolWindowState.DockableInsideHost:
				case ToolWindowState.DockableOutsideHost:
					// Already docked
					break;
				default:
					if (focusedToolWindow.AutoHideContainer is { } autoHideContainer) {
						// Dock all the tool windows in the auto-hide container of the focused tool window
						var autoHideTabGroups = autoHideContainer.AutoHideTabStripPanel!.TabGroups;
						for (var index = autoHideTabGroups.Count - 1; index >= 0; index--) {
							if (autoHideTabGroups[index].ContainsToolWindow(focusedToolWindow)) {
								autoHideTabGroups[index].ChangeAllToolWindowsToDockable();
								break;
							}
						}
					}
					else {
						// Dock just the focused tool window
						focusedToolWindow.State = ToolWindowState.DockableInsideHost;
					}
					break;
			}
		}
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowFloatingMenuItemClick(object sender, EventArgs e) {
		if (dockManager.FocusedToolWindow is { } focusedToolWindow)
			focusedToolWindow.State = ToolWindowState.Floating;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowHideMenuItemClick(object sender, EventArgs e)
		=> dockManager.FocusedToolWindow?.Close();

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMdiStyleMenuItemPopup(object sender, EventArgs e) {
		mdiStyleNoneToolStripMenuItem.Checked = (dockManager.DocumentMdiStyle == DocumentMdiStyle.None);
		mdiStyleStandardToolStripMenuItem.Checked = (dockManager.DocumentMdiStyle == DocumentMdiStyle.Standard);
		mdiStyleTabbedToolStripMenuItem.Checked = (dockManager.DocumentMdiStyle == DocumentMdiStyle.Tabbed);
		mdiStyleToolWindowInnerFillToolStripMenuItem.Checked = (dockManager.DocumentMdiStyle == DocumentMdiStyle.ToolWindowInnerFill);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMdiStyleNoneMenuItemClick(object sender, EventArgs e) {
		dockManager.DocumentMdiStyle = DocumentMdiStyle.None;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMdiStyleStandardMenuItemClick(object sender, EventArgs e) {
		dockManager.DocumentMdiStyle = DocumentMdiStyle.Standard;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMdiStyleTabbedMenuItemClick(object sender, EventArgs e) {
		dockManager.DocumentMdiStyle = DocumentMdiStyle.Tabbed;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMdiStyleToolWindowInnerFillMenuItemClick(object sender, EventArgs e) {
		dockManager.DocumentMdiStyle = DocumentMdiStyle.ToolWindowInnerFill;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMenuItemPopup(object sender, EventArgs e) {
		var focusedToolWindow = dockManager.FocusedToolWindow;
		floatingToolStripMenuItem.Enabled = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Floating));
		floatingToolStripMenuItem.Checked = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.Floating));
		dockableToolStripMenuItem.Enabled = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Dockable));
		dockableToolStripMenuItem.Checked = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.Dockable));
		tabbedDocumentToolStripMenuItem.Visible = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.TabbedDocument));
		tabbedDocumentToolStripMenuItem.Enabled = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.TabbedDocument));
		tabbedDocumentToolStripMenuItem.Checked = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.TabbedDocument));
		autoHideToolStripMenuItem.Enabled = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.AutoHide));
		autoHideToolStripMenuItem.Checked = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.AutoHide));
		hideToolStripMenuItem.Enabled = (focusedToolWindow is not null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Close));

		var selectedDocument = dockManager.SelectedDocument;

		newHorizontalTabGroupToolStripMenuItem.Visible = (selectedDocument is not null) && (selectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.NewHorizontalTabbedMdiContainer));
		newVerticalTabGroupToolStripMenuItem.Visible = (selectedDocument is not null) && (selectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.NewVerticalTabbedMdiContainer));
		moveToNextTabGroupToolStripMenuItem.Visible = (selectedDocument is not null) && (selectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.MoveToNextTabbedMdiContainer));
		moveToPreviousTabGroupToolStripMenuItem.Visible = (selectedDocument is not null) && (selectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.MoveToPreviousTabbedMdiContainer));

		newHorizontalTabGroupToolStripMenuItem.Enabled = (selectedDocument is not null) && (selectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.NewHorizontalTabbedMdiContainer));
		newVerticalTabGroupToolStripMenuItem.Enabled = (selectedDocument is not null) && (selectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.NewVerticalTabbedMdiContainer));
		moveToNextTabGroupToolStripMenuItem.Enabled = (selectedDocument is not null) && (selectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.MoveToNextTabbedMdiContainer));
		moveToPreviousTabGroupToolStripMenuItem.Enabled = (selectedDocument is not null) && (selectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.MoveToPreviousTabbedMdiContainer));

		autoHideAllToolStripMenuItem.Visible = dockManager.IsMenuItemVisible(DockManagerMenuItemType.AutoHideAll);

		cascadeToolStripMenuItem.Visible = dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowCascade);
		tileHorizontallyToolStripMenuItem.Visible = dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowTileHorizontally);
		tileVerticallyToolStripMenuItem.Visible = dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowTileVertically);

		cascadeToolStripMenuItem.Enabled = dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowCascade);
		tileHorizontallyToolStripMenuItem.Enabled = dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowTileHorizontally);
		tileVerticallyToolStripMenuItem.Enabled = dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowTileVertically);

		closeAllDocumentsToolStripMenuItem.Visible = dockManager.IsMenuItemVisible(DockManagerMenuItemType.CloseAllDocuments);
		windowsBarToolStripMenuItem.Visible = (dockManager.ActiveDocuments.Count > 0);

		// Remove any existing active document menu items
		var documentMenuItemIndex = windowToolStripMenuItem.DropDownItems.IndexOf(windowsBarToolStripMenuItem) + 1;
		while (documentMenuItemIndex < windowToolStripMenuItem.DropDownItems.Count)
			windowToolStripMenuItem.DropDownItems.RemoveAt(documentMenuItemIndex);

		// Add the active document menu items
		documentMenuItemIndex = 1;
		foreach (var tabbedMdiWindow in dockManager.ActiveDocuments) {
			// Build the menu item text
			var menuItemText = $"{documentMenuItemIndex++} {tabbedMdiWindow.Text}";

			// Add indicator for modified document windows
			if ((tabbedMdiWindow is DocumentWindow documentWindow) && (documentWindow.Modified))
				menuItemText += "*";

			// Create and add the menu item
			var menuItem = new ToolStripMenuItem(menuItemText, image: null, onClick: OnWindowActivateDocumentMenuItemClick) {
				Checked = (tabbedMdiWindow == dockManager.SelectedDocument),
				Tag = tabbedMdiWindow
			};
			windowToolStripMenuItem.DropDownItems.Add(menuItem);
		}
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMoveToNextTabGroupMenuItemClick(object sender, EventArgs e)
		=> dockManager.SelectedDocument?.MoveToNextTabbedMdiContainer();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowMoveToPreviousTabGroupMenuItemClick(object sender, EventArgs e)
		=> dockManager.SelectedDocument?.MoveToPreviousTabbedMdiContainer();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowNewHorizontalTabGroupMenuItemClick(object sender, EventArgs e)
		=> dockManager.SelectedDocument?.MoveToNewHorizontalTabbedMdiContainer();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowNewVerticalTabGroupMenuItemClick(object sender, EventArgs e)
		=> dockManager.SelectedDocument?.MoveToNewVerticalTabbedMdiContainer();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTabbedDocumentMenuItemClick(object sender, EventArgs e) {
		if (dockManager.FocusedToolWindow is { } focusedToolWindow)
			focusedToolWindow.State = ToolWindowState.TabbedDocument;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTabbedMdiButtonsDropDownButtonMenuItemClick(object sender, EventArgs e) {
		dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.DropDownButton;
	}

	/// <summary>
	/// Occurs when the menu item is displayed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTabbedMdiButtonsMenuItemPopup(object sender, EventArgs e) {
		tabbedMdiButtonsDropDownButtonToolStripMenuItem.Checked = (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.DropDownButton);
		tabbedMdiButtonsNoneToolStripMenuItem.Checked = (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.None);
		tabbedMdiButtonsScrollButtonsToolStripMenuItem.Checked = (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.ScrollButtons);
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTabbedMdiButtonsNoneMenuItemClick(object sender, EventArgs e) {
		dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.None;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTabbedMdiButtonsScrollButtonsMenuItemClick(object sender, EventArgs e) {
		dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.ScrollButtons;
	}

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTileHorizontallyMenuItemClick(object sender, EventArgs e)
		=> dockManager.TileDocumentsHorizontally();

	/// <summary>
	/// Occurs when the menu item is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnWindowTileVerticallyMenuItemClick(object sender, EventArgs e)
		=> dockManager.TileDocumentsVertically();

	/// <summary>
	/// Occurs when a link in the the textbox is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnTextBoxLinkClicked(object? sender, LinkClickedEventArgs e) {
		if (e.LinkText is { } linkText && linkText.StartsWith("http", StringComparison.OrdinalIgnoreCase))
			SampleBrowser.Program.LaunchExternalBrowser(linkText);
	}

	/// <summary>
	/// Occurs when the textbox text is changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnTextBoxTextChanged(object? sender, EventArgs e) {
		if (_ignoreTextChangedEvent)
			return;

		// Synchronize the document window "modified" indicator with the modified status of the RichTextBox
		if ((sender is RichTextBox richTextBox) && (richTextBox.Parent is DocumentWindow documentWindow))
			documentWindow.Modified = richTextBox.Modified;
	}

	/// <summary>
	/// Prompts the user to save a document.
	/// </summary>
	/// <param name="document">The document to be saved.</param>
	/// <returns><c>true</c> if the document was saved; otherwise <c>false</c> if the user canceled the operation.</returns>
	private bool PromptSaveDocument(DocumentWindow document) {
		// Show the dialog
		saveFileDialog.Filter = "All Documents (*.*)|*.*";
		saveFileDialog.FileName = document.Key;
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			return false;

		// Write out the document
		var writer = File.CreateText(saveFileDialog.FileName);
		writer.Write(((RichTextBox)document.Controls[0]).Text);
		writer.Close();

		return true;
	}

	private void ResizeDockManagerPropertyGrid()
		=> ResizePropertyGridWithinPanel(dockManagerPropertyGrid, dockManagerPropertyGridPanel);

	private void ResizeToolWindowPropertyGrid()
		=> ResizePropertyGridWithinPanel(toolWindowPropertyGrid, toolWindowPropertyGridPanel);

	private static void ResizePropertyGridWithinPanel(PropertyGrid propertyGrid, Panel panel) {
		propertyGrid.SuspendLayout();

		// Reset the Anchor that is only used to keep designer layout consistent
		propertyGrid.Anchor = AnchorStyles.None;

		// Set the size/location of the PropertyGrid to be 1px bigger than the containing panel so the PropertyGrid border is not visible
		propertyGrid.Location = new Point(-1, -1);
		propertyGrid.Size = new Size(panel.Width + 2, panel.Height + 2);

		propertyGrid.ResumeLayout();
	}

	/// <summary>
	/// Update the border styles of child controls.
	/// </summary>
	private void UpdateChildControlBorderStyles() {
		bool showBorders = (dockManager.DockRenderer?.GetType() == typeof(WindowsClassicDockRenderer));
		foreach (var toolWindow in dockManager.ToolWindows) {
			bool changeToolWindowBorder = false;
			foreach (var control in toolWindow.Controls) {
				if (control is TextBoxBase textBox) {
					textBox.BorderStyle = (showBorders ? BorderStyle.Fixed3D : BorderStyle.None);
					changeToolWindowBorder = true;
				}
				else if (control is ListBox listBox) {
					listBox.BorderStyle = (showBorders ? BorderStyle.Fixed3D : BorderStyle.None);
					changeToolWindowBorder = true;
				}
			}

			if (changeToolWindowBorder)
				toolWindow.Border = (showBorders ? null : new SimpleBorder(SimpleBorderStyle.Solid, SystemColors.ControlDark));
		}
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void OnDpiChanged(DpiChangedEventArgs e) {
		base.OnDpiChanged(e);

		// Re-assign read-only context images based on the new DPI
		foreach (var documentWindow in dockManager.DocumentWindows) {
			if (documentWindow.ContextImage is not null) {
				var updatedContextImage = ActiproSoftware.Properties.Docking.AssemblyInfo.Instance.GetImage(
					ActiproSoftware.Properties.Docking.ImageResource.ContextReadOnly,
					DpiHelper.GetDpiScale(e.DeviceDpiNew)
				);
				documentWindow.ContextImage = updatedContextImage;
			}
		}

		// Perform layout to invalidate dock controls
		PerformLayout();
	}

	/// <inheritdoc/>
	protected override void OnFormClosing(FormClosingEventArgs e) {
		// Call the base method 
		base.OnFormClosing(e);

		if (!e.Cancel) {
			// Loop through and close all the documents and see if the cancel should be aborted
			for (var index = dockManager.DocumentWindows.Count - 1; index >= 0; index--) {
				// Activate the document window to examine
				var documentWindow = dockManager.DocumentWindows[index];
				documentWindow.Activate();

				// Make sure the document can be closed
				if (!HandleDocumentClosing(documentWindow)) {
					e.Cancel = true;
					break;
				}

				// Close the document window
				_ignoreModifiedDocumentClose = true;
				documentWindow.Close();
				_ignoreModifiedDocumentClose = false;
			}
		}
	}

}
