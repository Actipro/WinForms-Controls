using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Docking;

namespace ActiproSoftware.ProductSamples.DockingSamples.Demo.DockingFeatures {

	/// <summary>
	/// A form to test the dock controls.
	/// </summary>
	public partial class MainForm : System.Windows.Forms.Form {

		private int documentWindowIndex = 1;
		private int toolWindowIndex		= 1;

		private bool ignoreModifiedDocumentClose = false;

		/// <summary>
		/// Creates an instance of the <c>DockForm</c> class.
		/// </summary>
		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Select the first item
			if (toolWindowPropertyGridComboBox.Items.Count > 0)
				toolWindowPropertyGridComboBox.SelectedIndex = 0;
			if (dockManagerPropertyGridComboBox.Items.Count > 0)
				dockManagerPropertyGridComboBox.SelectedIndex = 0;

			// Create documents
			this.CreateTextDocument(null, "This is a read-only document.  Notice the lock context image in the tab.", true).Activate();
			this.CreateTextDocument(null, null, false).Activate();

			// Set the size for screenshots
			// this.Size = new Size(408, 377);

		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when using tabbed MDI and the Active Files button is clicked, requesting a drop-down menu of open files.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_ActiveFilesContextMenu(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowContextMenuEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("ActiveFilesContextMenu");
		}

		/// <summary>
		/// Occurs before a tool window in auto-hide mode is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_AutoHideToolWindowDisplaying(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("AutoHideToolWindowDisplaying: Key={0}", e.TabbedMdiWindow.Key));
		}

		/// <summary>
		/// Occurs before a tool window in auto-hide mode is hidden.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_AutoHideToolWindowHiding(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("AutoHideToolWindowHiding: Key={0}", e.TabbedMdiWindow.Key));
		}

		/// <summary>
		/// Occurs as a tool window layout is being read, allowing for custom data to be loaded.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_LoadCustomToolWindowLayoutData(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.DockLoadCustomToolWindowLayoutDataEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("LoadCustomToolWindowLayoutData");		
		}

		/// <summary>
		/// Occurs when the selection changes on the Next Window Navigation form.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_NextWindowNavigationSelectionChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.NextWindowNavigationEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("NextWindowNavigationSelectionChanged: Key={0}", e.TabbedMdiWindow.Key));	
		}

		/// <summary>
		/// Occurs as a tool window layout is being written, allowing for custom data to be saved.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_SaveCustomToolWindowLayoutData(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.DockSaveCustomToolWindowLayoutDataEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("SaveCustomToolWindowLayoutData");
		}

		/// <summary>
		/// Occurs when the value of the <see cref="SelectedDocument"/> property changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_SelectedDocumentChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectedDocumentChanged: Key={0}", 
				(e.TabbedMdiWindow != null ? e.TabbedMdiWindow.Key : "<null>")));
		}

		/// <summary>
		/// Occurs after the selected tabbed MDI container is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_SelectedTabbedMdiContainerChanged(object sender, System.EventArgs e) {
			int selectedIndex = -1;
			if (dockManager.TabbedMdiRootContainer != null)
				selectedIndex = dockManager.TabbedMdiRootContainer.SelectedIndex;
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectedTabbedMdiContainerChanged: SelectedIndex={0}", selectedIndex));
		}

		/// <summary>
		/// Occurs after one or more tool windows are dragged by the user.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_ToolWindowDragged(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("ToolWindowDragged");

			// Update the status bar
			statusLabel.Text = "Ready";
		}

		/// <summary>
		/// Occurs before one or more tool windows are dragged by the user.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_ToolWindowDragging(object sender, System.ComponentModel.CancelEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("ToolWindowDragging: Cancel={0}", e.Cancel));

			// Update the status bar
			if (!e.Cancel)
				statusLabel.Text = "Hold down CTRL to prevent docking.  Point to title bar of destination window to tab-link.";
		}

		/// <summary>
		/// Occurs after tool window layout is loaded.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_ToolWindowLayoutLoaded(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("ToolWindowLayoutLoaded");
		}

		/// <summary>
		/// Occurs before tool window layout is loaded.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_ToolWindowLayoutLoading(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("ToolWindowLayoutLoading");
		}

		/// <summary>
		/// Occurs after a window is activated from an inactive state and is visible. 
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowActivated(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowActivated: Key={0}; Type={1}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType));
		}

		/// <summary>
		/// Occurs before a window is activated from an inactive state.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowActivating(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowActivating: Key={0}; Type={1}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType));
		}

		/// <summary>
		/// Occurs after a window is deactivated from an active state.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowClosed(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowClosed: Key={0}; Type={1}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType));
		}

		/// <summary>
		/// Occurs before a window is deactivated from an active state.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowClosing(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowClosingEventArgs e) {
			// If a document is being closed and it has been modified...
			if ((!ignoreModifiedDocumentClose) && (e.TabbedMdiWindow.DockObjectType == DockObjectType.DocumentWindow) && (((DocumentWindow)e.TabbedMdiWindow).Modified)) {
				if (MessageBox.Show(this, String.Format("The document '{0}' has been modified.  Would you like to close it without saving?", e.TabbedMdiWindow.Key),
					"Close Modified Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					e.Cancel = true;
			}

			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowClosing: Key={0}; Type={1}; Reason={2}; Cancel={3}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType, e.Reason, e.Cancel));
		}

		/// <summary>
		/// Occurs when a window needs a context menu displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowContextMenu(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowContextMenuEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowContextMenu: Key={0}; Type={1}; Source={2}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType, e.Source));
		}

		/// <summary>
		/// Occurs immediately after a window is created.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowCreated(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowCreated: Key={0}; Type={1}; CreationMethod={2}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType, e.TabbedMdiWindow.CreationMethod));

			// If the window is a tool window...
			if (e.TabbedMdiWindow is ToolWindow) {
				// Get the tool window
				ToolWindow toolWindow = (ToolWindow)e.TabbedMdiWindow;
				
				// Add the View menu item for the tool window
				var menuItem = new ToolStripMenuItem(toolWindow.Text, null, new EventHandler(this.viewToolWindowMenuItem_Click));
				menuItem.Tag = toolWindow;
				viewToolStripMenuItem.DropDownItems.Add(menuItem);

				// Add the tool window to the properties drop-down
				toolWindowPropertyGridComboBox.Items.Add(toolWindow);
			}
		}

		/// <summary>
		/// Occurs when a window is disposed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowDisposed(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowDisposed: Key={0}; Type={1}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType));

			// If the window is a tool window...
			if (e.TabbedMdiWindow is ToolWindow) {
				// Get the tool window
				ToolWindow toolWindow = (ToolWindow)e.TabbedMdiWindow;
				
				// Remove the View menu item for the tool window
				for (var index = 0; index < viewToolStripMenuItem.DropDownItems.Count; index++) {
					if (viewToolStripMenuItem.DropDownItems[index].Tag == toolWindow) {
						viewToolStripMenuItem.DropDownItems.RemoveAt(index);
						break;
					}
				}

				// Remove the tool window from the properties drop-down
				toolWindowPropertyGridComboBox.Items.Remove(toolWindow);
				if (toolWindowPropertyGridComboBox.SelectedIndex == -1)
					toolWindowPropertyGridComboBox.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Occurs when a window receives focus.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowFocused(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowFocused: Key={0}; Type={1}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType));
		}

		/// <summary>
		/// Occurs before the window is activated for the first time, allowing for lazy initialization of the window.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowInitializing(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowInitializing: Key={0}; Type={1}; CreationMethod={2}", 
				e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType, e.TabbedMdiWindow.CreationMethod));
		}

		/// <summary>
		/// Occurs before a tool tip is displayed for a window tab and gives an opportunity to update the windows's tool tip text.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManager_WindowTabToolTipDisplaying(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			// eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("WindowTabToolTipDisplaying: Key={0}; Type={1}; ToolTipText={2}", 
			// 	e.TabbedMdiWindow.Key, e.TabbedMdiWindow.DockObjectType, e.TabbedMdiWindow.ToolTipText));

			// Update the tool tip text
			if (e.TabbedMdiWindow.DockObjectType == DockObjectType.ToolWindow)
				e.TabbedMdiWindow.ToolTipText = e.TabbedMdiWindow.Text;
			else if (e.TabbedMdiWindow.DockObjectType == DockObjectType.DocumentWindow) {
				// The key of document windows in this sample is their filename
				e.TabbedMdiWindow.ToolTipText = e.TabbedMdiWindow.Key;

				// If the document is an Image, add extra info to the tip
				if ((e.TabbedMdiWindow.Controls.Count == 1) && (e.TabbedMdiWindow.Controls[0] is PictureBox)) {
					PictureBox pictureBox = (PictureBox)e.TabbedMdiWindow.Controls[0];
					e.TabbedMdiWindow.ToolTipText += String.Format("{0}Image Size: {1} x {2}", Environment.NewLine, pictureBox.Image.Width, pictureBox.Image.Height);
				}
			}
		}

		/// <summary>
		/// Occurs when the selected index changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void dockManagerPropertyGridComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			switch (dockManagerPropertyGridComboBox.SelectedIndex) {
				case 1:
					dockManagerPropertyGrid.SelectedObject = dockManager.DockRenderer;
					break;
				case 2:
					dockManagerPropertyGrid.SelectedObject = dockManager.ToolWindowContainerTabStripRenderer;
					break;
				case 3:
					dockManagerPropertyGrid.SelectedObject = dockManager.TabbedMdiContainerTabStripRenderer;
					break;
				default:
					dockManagerPropertyGrid.SelectedObject = dockManager;
					break;
			}
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editCopyMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).Copy();			
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editCutMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).Cut();			
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editDeleteMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).SelectedText = String.Empty;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editMenuItem_Popup(object sender, System.EventArgs e) {
			cutToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
			copyToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
			pasteToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
			deleteToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
			undoToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
			redoToolStripMenuItem.Enabled = this.IsTextDocumentSelected();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editPasteMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).Paste();			
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editRedoMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).Redo();			
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void editUndoMenuItem_Click(object sender, System.EventArgs e) {
			if (this.IsTextDocumentSelected())
				((RichTextBox)dockManager.SelectedDocument.Controls[0]).Undo();			
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileActivateAllInactiveToolWindowsMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.ActivateAllInactiveToolWindows();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileCloseAllToolWindowsMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.CloseAllActiveToolWindows(false);		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileCloseDocumentMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.Close();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileCreate3ToolWindowsInARowMenuItem_Click(object sender, System.EventArgs e) {
			// First tool window
			RichTextBox textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow firstToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);
            		
			// Second tool window
			textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow secondToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);
            		
			// Third tool window
			textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow thirdToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);

			// Update border styles
			this.UpdateChildControlBorderStyles();

			// Dock three in a row with the same size
			firstToolWindow.DockTo(dockManager, DockOperationType.LeftOuter);
			secondToolWindow.DockedSize = new Size(firstToolWindow.ToolWindowContainer.Width, (int)(0.667f * firstToolWindow.ToolWindowContainer.Height));
			secondToolWindow.DockTo(firstToolWindow, DockOperationType.BottomInner);
			thirdToolWindow.DockedSize = new Size(secondToolWindow.ToolWindowContainer.Width, (int)(0.5f * secondToolWindow.ToolWindowContainer.Height));
			thirdToolWindow.DockTo(secondToolWindow, DockOperationType.BottomInner);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileCreate3ToolWindowsAttachedMenuItem_Click(object sender, System.EventArgs e) {
			// First tool window
			RichTextBox textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow firstToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);
            		
			// Second tool window
			textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow secondToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);
            		
			// Third tool window
			textBox = new RichTextBox();
			textBox.Multiline = true;
			textBox.ScrollBars = RichTextBoxScrollBars.Both;
			textBox.Text = "Tool Window " + (toolWindowIndex++);
			ToolWindow thirdToolWindow = new ToolWindow(dockManager, textBox.Text, textBox.Text, null, textBox);

			// Update border styles
			this.UpdateChildControlBorderStyles();

			// Undock
			firstToolWindow.FloatingLocation = new Point(100, 100);
			firstToolWindow.FloatingSize = new Size(300, 200);
			firstToolWindow.Undock();
			secondToolWindow.DockTo(firstToolWindow, DockOperationType.Attach);
			thirdToolWindow.DockTo(firstToolWindow, DockOperationType.Attach);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileExitMenuItem_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileLoadToolWindowLayoutMenuItem_Click(object sender, System.EventArgs e) {
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
		/// <param name="e">Event arguments.</param>
		private void fileMenuItem_Popup(object sender, System.EventArgs e) {
			closeDocumentToolStripMenuItem.Enabled = (dockManager.SelectedDocument != null);
			saveDocumentToolStripMenuItem.Enabled = this.IsTextDocumentSelected();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileNewTextDocumentMenuItem_Click(object sender, System.EventArgs e) {
			switch (dockManager.DocumentMdiStyle) {
				case DocumentMdiStyle.ToolWindowInnerFill:
				case DocumentMdiStyle.None:
					MessageBox.Show(this, "No windows may be placed in the document area because the DockManager.DocumentMdiStyle property is set to ToolWindowInnerFill or None.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
			}

			// Create a document window
			this.CreateTextDocument(null, null, false).Activate();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileOpenDocumentMenuItem_Click(object sender, System.EventArgs e) {
			switch (dockManager.DocumentMdiStyle) {
				case DocumentMdiStyle.ToolWindowInnerFill:
				case DocumentMdiStyle.None:
					MessageBox.Show(this, "No windows may be placed in the document area because the DockManager.DocumentMdiStyle property is set to ToolWindowInnerFill or None.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
			}

			// Show the dialog
			openFileDialog.Filter = "All Documents (*.*)|*.*";
			openFileDialog.FileName = String.Empty;
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			// Get the text of the document
			StreamReader reader = File.OpenText(openFileDialog.FileName);
			string text = reader.ReadToEnd();
			reader.Close();

			// Create a document window
			this.CreateTextDocument(openFileDialog.FileName, text, false).Activate();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileSaveDocumentMenuItem_Click(object sender, System.EventArgs e) {
			if (!this.IsTextDocumentSelected())
				return;

			// Show the dialog
			saveFileDialog.Filter = "All Documents (*.*)|*.*";
			saveFileDialog.FileName = dockManager.SelectedDocument.Key;
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;
		
			// Write out the document
			StreamWriter writer = File.CreateText(saveFileDialog.FileName);
			writer.Write(((RichTextBox)dockManager.SelectedDocument.Controls[0]).Text);
			writer.Close();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void fileSaveToolWindowLayoutMenuItem_Click(object sender, System.EventArgs e) {
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
		/// <param name="e">Event arguments.</param>
		private void helpAboutMenuItem_Click(object sender, System.EventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com/products/controls/windowsforms");
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void helpWebSiteMenuItem_Click(object sender, System.EventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com");
		}

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void markupLabel_LinkClick(object sender, ActiproSoftware.UI.WinForms.Controls.MarkupLabel.MarkupLabelLinkClickEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("markupLabel_LinkClick: HREF={0}", e.Element.HRef));
			SampleBrowser.Program.LaunchExternalBrowser(e.Element.HRef);
		}
		
		/// <summary>
		/// Occurs when a toolbar button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void toolStripButton_Click(object sender, EventArgs e) {
			switch (((ToolStripItem)sender).Tag.ToString()) {
				case "NewTextDocument":
					newTextDocumentToolStripMenuItem.PerformClick();
					break;
				case "OpenDocument":
					openDocumentToolStripMenuItem.PerformClick();
					break;
				case "SaveDocument":
					saveDocumentToolStripMenuItem.PerformClick();
					break;
				case "Cut":
					cutToolStripMenuItem.PerformClick();
					break;
				case "Copy":
					copyToolStripMenuItem.PerformClick();
					break;
				case "Paste":
					pasteToolStripMenuItem.PerformClick();
					break;
				case "Delete":
					deleteToolStripMenuItem.PerformClick();
					break;
				case "Undo":
					undoToolStripMenuItem.PerformClick();
					break;
				case "Redo":
					redoToolStripMenuItem.PerformClick();
					break;
			}		
		}

		/// <summary>
		/// Occurs when the selected index changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void toolWindowPropertyGridComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            toolWindowPropertyGrid.SelectedObject = toolWindowPropertyGridComboBox.SelectedItem;		
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockGuideStyleMenuItem_Popup(object sender, System.EventArgs e) {
			dockGuideStyleNoneToolStripMenuItem.Checked = (dockManager.DockGuideStyle == DockGuideStyle.None);
			dockGuideStyleSunkenToolStripMenuItem.Checked = (dockManager.DockGuideStyle == DockGuideStyle.Sunken);
			dockGuideStyleRaisedToolStripMenuItem.Checked = (dockManager.DockGuideStyle == DockGuideStyle.Raised);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockGuideStyleNoneMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockGuideStyle = DockGuideStyle.None;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockGuideStyleRaisedMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockGuideStyle = DockGuideStyle.Raised;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockGuideStyleSunkenMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockGuideStyle = DockGuideStyle.Sunken;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockHintStyleMenuItem_Popup(object sender, System.EventArgs e) {
			dockHintStyleRubberBandHatchedToolStripMenuItem.Checked = (dockManager.DockHintStyle == DockHintStyle.RubberBandHatched);
			dockHintStyleTranslucentToolStripMenuItem.Checked = (dockManager.DockHintStyle == DockHintStyle.Translucent);		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockHintStyleRubberBandHatchedMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockHintStyle = DockHintStyle.RubberBandHatched;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewDockHintStyleTranslucentMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockHintStyle = DockHintStyle.Translucent;
		}
		
		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewMagnetismGapDistanceMenuItem_Click(object sender, EventArgs e) {
			magnetism0GapDistanceToolStripMenuItem.Checked = (sender == magnetism0GapDistanceToolStripMenuItem);
			magnetism1GapDistanceToolStripMenuItem.Checked = (sender == magnetism1GapDistanceToolStripMenuItem);
			magnetism2GapDistanceToolStripMenuItem.Checked = (sender == magnetism2GapDistanceToolStripMenuItem);
			
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
		/// <param name="e">Event arguments.</param>
		private void viewMagnetismSnapDistanceMenuItem_Click(object sender, EventArgs e) {
			magnetism0SnapDistanceToolStripMenuItem.Checked = (sender == magnetism0SnapDistanceToolStripMenuItem);
			magnetism5SnapDistanceToolStripMenuItem.Checked = (sender == magnetism5SnapDistanceToolStripMenuItem);
			magnetism10SnapDistanceToolStripMenuItem.Checked = (sender == magnetism10SnapDistanceToolStripMenuItem);
			
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
		/// <param name="e">Event arguments.</param>
		private void viewMenuItem_Popup(object sender, System.EventArgs e) {
			tabbedMDITabImagesVisibleToolStripMenuItem.Checked = dockManager.TabbedMdiTabImagesVisible;

			// Update the View menu item text for the tool window
			for (var index = 0; index < viewToolStripMenuItem.DropDownItems.Count; index++) {
				var toolWindow = viewToolStripMenuItem.DropDownItems[index].Tag as ToolWindow;
				if (toolWindow != null) {
					viewToolStripMenuItem.DropDownItems[index].Text = toolWindow.Text;
					viewToolStripMenuItem.DropDownItems[index].Image = toolWindow.GetImage();
				}
			}
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewNextWindowNavigationEnabledMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.NextWindowNavigationEnabled = !dockManager.NextWindowNavigationEnabled;
			nextWindowNavigationEnabledToolStripMenuItem.Checked = dockManager.NextWindowNavigationEnabled;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewNextWindowNavigationTypeMenuItem_Popup(object sender, System.EventArgs e) {
			nextWindowNavigationTypeToolAndDocumentWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.ToolAndDocumentWindow);
			nextWindowNavigationTypeToolWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.ToolWindow);
			nextWindowNavigationTypeDocumentWindowToolStripMenuItem.Checked = (dockManager.NextWindowNavigationType == NextWindowNavigationType.DocumentWindow);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewNextWindowNavigationTypeDocumentWindowMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.NextWindowNavigationType = NextWindowNavigationType.DocumentWindow;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewNextWindowNavigationTypeToolAndDocumentWindowMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.NextWindowNavigationType = NextWindowNavigationType.ToolAndDocumentWindow;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewNextWindowNavigationTypeToolWindowMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.NextWindowNavigationType = NextWindowNavigationType.ToolWindow;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererMenuItem_Popup(object sender, System.EventArgs e) {
			rendererMetroLightToolStripMenuItem.Checked = (dockManager.DockRenderer.GetType() == typeof(MetroLightDockRenderer));
			rendererOffice2003ToolStripMenuItem.Checked = (dockManager.DockRenderer.GetType() == typeof(Office2003DockRenderer));
			rendererVisualStudio2005ToolStripMenuItem.Checked = (dockManager.DockRenderer.GetType() == typeof(VisualStudio2005DockRenderer));
			rendererVisualStudio2005Beta2ToolStripMenuItem.Checked = (dockManager.DockRenderer.GetType() == typeof(VisualStudio2005Beta2DockRenderer));
			rendererVisualStudio2002ToolStripMenuItem.Checked = (dockManager.DockRenderer.GetType() == typeof(VisualStudio2002DockRenderer));
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererMetroLightMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new MetroLightDockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new MetroLightDocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new MetroLightToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererOffice2003MenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new Office2003DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new Office2003DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new Office2003ToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererOffice2003VisualStudio2005Beta2MenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new Office2003VisualStudio2005Beta2DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new Office2003DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new Office2003VisualStudio2005Beta2ToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererVisualStudio2002MenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new VisualStudio2002DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new VisualStudio2002DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new VisualStudio2002ToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererVisualStudio2005Beta2MenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new VisualStudio2005Beta2DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new VisualStudio2005DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new VisualStudio2005Beta2ToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewRendererVisualStudio2005MenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DockRenderer = new VisualStudio2005DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new VisualStudio2005DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new VisualStudio2005ToolWindowTabStripRenderer();
			this.UpdateChildControlBorderStyles();
			dockManagerPropertyGridComboBox_SelectedIndexChanged(dockManagerPropertyGridComboBox, EventArgs.Empty);
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewSplitterExtentMenuItem_Popup(object sender, System.EventArgs e) {
            splitterExtent3PixelsToolStripMenuItem.Checked = (dockManager.DockRenderer.SplitterExtent == 3);
            splitterExtent4PixelsToolStripMenuItem.Checked = (dockManager.DockRenderer.SplitterExtent == 4);
            splitterExtent5PixelsToolStripMenuItem.Checked = (dockManager.DockRenderer.SplitterExtent == 5);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewSplitterExtent3PixelsMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.DockRenderer is DockRenderer)
				((DockRenderer)dockManager.DockRenderer).SplitterExtent = 3;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewSplitterExtent4PixelsMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.DockRenderer is DockRenderer)
				((DockRenderer)dockManager.DockRenderer).SplitterExtent = 4;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewSplitterExtent5PixelsMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.DockRenderer is DockRenderer)
				((DockRenderer)dockManager.DockRenderer).SplitterExtent = 5;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewTabbedMDITabImagesVisibleMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TabbedMdiTabImagesVisible = !dockManager.TabbedMdiTabImagesVisible;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void viewToolWindowMenuItem_Click(object sender, System.EventArgs e) {
			ToolWindow toolWindow = (ToolWindow)((ToolStripItem)sender).Tag;
			toolWindow.Activate();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowActivateDocumentMenuItem_Click(object sender, System.EventArgs e) {
			TabbedMdiWindow tabbedMdiWindow = (TabbedMdiWindow)((ToolStripItem)sender).Tag;
			tabbedMdiWindow.Activate();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowAutoHideAllMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.AutoHideAllToolWindowsDockedInHost();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowAutoHideMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.FocusedToolWindow != null) {
				if (dockManager.FocusedToolWindow.ToolWindowContainer != null)
					dockManager.FocusedToolWindow.ToolWindowContainer.AutoHide();
				else
					dockManager.FocusedToolWindow.State = ToolWindowState.AutoHide;
			}
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowCascadeMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.CascadeDocuments();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowCloseAllDocumentsMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.CloseAllActiveDocuments(false);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowDockableMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.FocusedToolWindow != null) {
				switch (dockManager.FocusedToolWindow.State) {
					case ToolWindowState.DockableInsideHost:
					case ToolWindowState.DockableOutsideHost:
						break;
					default:
						if (dockManager.FocusedToolWindow.AutoHideContainer != null) {
							AutoHideTabGroupCollection tabGroups = dockManager.FocusedToolWindow.AutoHideContainer.AutoHideTabStripPanel.TabGroups;
							for (int index = tabGroups.Count - 1; index >=0; index--) {
								if (tabGroups[index].ContainsToolWindow(dockManager.FocusedToolWindow)) {
									tabGroups[index].ChangeAllToolWindowsToDockable();
									break;
								}
							}
						}
						else
							dockManager.FocusedToolWindow.State = ToolWindowState.DockableInsideHost;
						break;
				}
			}
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowFloatingMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.FocusedToolWindow != null)
				dockManager.FocusedToolWindow.State = ToolWindowState.Floating;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowHideMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.FocusedToolWindow != null)
				dockManager.FocusedToolWindow.Close();
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMDIStyleMenuItem_Popup(object sender, System.EventArgs e) {
			mdiStyleNoneToolStripMenuItem.Checked					= (dockManager.DocumentMdiStyle == DocumentMdiStyle.None);
			mdiStyleStandardToolStripMenuItem.Checked				= (dockManager.DocumentMdiStyle == DocumentMdiStyle.Standard);
			mdiStyleTabbedToolStripMenuItem.Checked					= (dockManager.DocumentMdiStyle == DocumentMdiStyle.Tabbed);
			mdiStyleToolWindowInnerFillToolStripMenuItem.Checked	= (dockManager.DocumentMdiStyle == DocumentMdiStyle.ToolWindowInnerFill);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMDIStyleNoneMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DocumentMdiStyle = DocumentMdiStyle.None;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMDIStyleStandardMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DocumentMdiStyle = DocumentMdiStyle.Standard;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMDIStyleTabbedMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DocumentMdiStyle = DocumentMdiStyle.Tabbed;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMDIStyleToolWindowInnerFillMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.DocumentMdiStyle = DocumentMdiStyle.ToolWindowInnerFill;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMenuItem_Popup(object sender, System.EventArgs e) {
			ToolWindow focusedToolWindow			= dockManager.FocusedToolWindow;
			floatingToolStripMenuItem.Enabled		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Floating));
			floatingToolStripMenuItem.Checked		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.Floating));
			dockableToolStripMenuItem.Enabled		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Dockable));
			dockableToolStripMenuItem.Checked		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.Dockable));
			tabbedDocumentToolStripMenuItem.Visible	= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.TabbedDocument));
			tabbedDocumentToolStripMenuItem.Enabled	= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.TabbedDocument));
			tabbedDocumentToolStripMenuItem.Checked	= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.TabbedDocument));
			autoHideToolStripMenuItem.Enabled		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.AutoHide));
			autoHideToolStripMenuItem.Checked		= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemChecked(TabbedMdiWindowContextMenuItemType.AutoHide));
			hideToolStripMenuItem.Enabled			= (focusedToolWindow != null) && (focusedToolWindow.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.Close));

			newHorizontalTabGroupToolStripMenuItem.Visible	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.NewHorizontalTabbedMdiContainer));
			newVerticalTabGroupToolStripMenuItem.Visible	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.NewVerticalTabbedMdiContainer));
			moveToNextTabGroupToolStripMenuItem.Visible		= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.MoveToNextTabbedMdiContainer));
			moveToPreviousTabGroupToolStripMenuItem.Visible	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemVisible(TabbedMdiWindowContextMenuItemType.MoveToPreviousTabbedMdiContainer));

			newHorizontalTabGroupToolStripMenuItem.Enabled	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.NewHorizontalTabbedMdiContainer));
			newVerticalTabGroupToolStripMenuItem.Enabled	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.NewVerticalTabbedMdiContainer));
			moveToNextTabGroupToolStripMenuItem.Enabled		= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.MoveToNextTabbedMdiContainer));
			moveToPreviousTabGroupToolStripMenuItem.Enabled	= (dockManager.SelectedDocument != null) && (dockManager.SelectedDocument.IsMenuItemEnabled(TabbedMdiWindowContextMenuItemType.MoveToPreviousTabbedMdiContainer));

			autoHideAllToolStripMenuItem.Visible			= dockManager.IsMenuItemVisible(DockManagerMenuItemType.AutoHideAll);

			cascadeToolStripMenuItem.Visible				= dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowCascade);
			tileHorizontallyToolStripMenuItem.Visible		= dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowTileHorizontally);
			tileVerticallyToolStripMenuItem.Visible			= dockManager.IsMenuItemVisible(DockManagerMenuItemType.WindowTileVertically);

			cascadeToolStripMenuItem.Enabled				= dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowCascade);
			tileHorizontallyToolStripMenuItem.Enabled		= dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowTileHorizontally);
			tileVerticallyToolStripMenuItem.Enabled			= dockManager.IsMenuItemEnabled(DockManagerMenuItemType.WindowTileVertically);

			closeAllDocumentsToolStripMenuItem.Visible		= dockManager.IsMenuItemVisible(DockManagerMenuItemType.CloseAllDocuments);
			windowsBarToolStripMenuItem.Visible				= (dockManager.ActiveDocuments.Count > 0);

			// Remove any existing active document menu items
			int documentMenuItemIndex = windowToolStripMenuItem.DropDownItems.IndexOf(windowsBarToolStripMenuItem) + 1;
			while (documentMenuItemIndex < windowToolStripMenuItem.DropDownItems.Count)
				windowToolStripMenuItem.DropDownItems.RemoveAt(documentMenuItemIndex);

			// Add the active document menu items
			documentMenuItemIndex = 1;
			foreach (TabbedMdiWindow tabbedMdiWindow in dockManager.ActiveDocuments) {
				// Get whether the tabbed MDI window has been modified
				bool modified = ((tabbedMdiWindow is DocumentWindow) && (((DocumentWindow)tabbedMdiWindow).Modified));

				// Add the menu item
				var menuItem = new ToolStripMenuItem(documentMenuItemIndex++ + " " + tabbedMdiWindow.Text + (modified ? "*" : String.Empty), null,
					new EventHandler(this.windowActivateDocumentMenuItem_Click)) { Tag = tabbedMdiWindow };
				if (tabbedMdiWindow == dockManager.SelectedDocument)
					menuItem.Checked = true;
				windowToolStripMenuItem.DropDownItems.Add(menuItem);
			}
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMoveToNextTabGroupMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.MoveToNextTabbedMdiContainer();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowMoveToPreviousTabGroupMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.MoveToPreviousTabbedMdiContainer();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowNewHorizontalTabGroupMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.MoveToNewHorizontalTabbedMdiContainer();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowNewVerticalTabGroupMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.MoveToNewVerticalTabbedMdiContainer();		
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTabbedDocumentMenuItem_Click(object sender, System.EventArgs e) {
			if (dockManager.FocusedToolWindow != null)
				dockManager.FocusedToolWindow.State = ToolWindowState.TabbedDocument;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTabbedMdiButtonsDropDownButtonMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.DropDownButton;
		}

		/// <summary>
		/// Occurs when the menu item is displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTabbedMdiButtonsMenuItem_Popup(object sender, System.EventArgs e) {
			tabbedMdiButtonsDropDownButtonToolStripMenuItem.Checked	= (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.DropDownButton);
			tabbedMdiButtonsNoneToolStripMenuItem.Checked			= (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.None);
			tabbedMdiButtonsScrollButtonsToolStripMenuItem.Checked	= (dockManager.TabbedMdiContainerButtonStyle == TabbedMdiContainerButtonStyle.ScrollButtons);
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTabbedMdiButtonsNoneMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.None;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTabbedMdiButtonsScrollButtonsMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TabbedMdiContainerButtonStyle = TabbedMdiContainerButtonStyle.ScrollButtons;
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTileHorizontallyMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TileDocumentsHorizontally();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void windowTileVerticallyMenuItem_Click(object sender, System.EventArgs e) {
			dockManager.TileDocumentsVertically();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void textBox_TextChanged(object sender, System.EventArgs e) {
			DocumentWindow documentWindow = ((RichTextBox)sender).Parent as DocumentWindow;
			if (documentWindow != null)
				documentWindow.Modified = ((RichTextBox)sender).Modified;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Creates a text document.
		/// </summary>
		/// <returns>The <see cref="DocumentWindow"/> that was created.</returns>
		private DocumentWindow CreateTextDocument(string fileName, string text, bool readOnly) {
			DocumentWindow documentWindow;

			// If the document is already open, show a message
			if (dockManager.DocumentWindows[fileName] != null) {
				dockManager.DocumentWindows[fileName].Activate();
				MessageBox.Show(this, String.Format("The file '{0}' is already open.", fileName), "File Already Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return dockManager.DocumentWindows[fileName];
			}

			// Determine the type of file
			string fileType = "Text";
			if (fileName != null) {
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

			switch (fileType) {
				case "Image": {
					// Create a PictureBox for the document
					PictureBox pictureBox = new PictureBox();
					pictureBox.Image = Image.FromFile(fileName);

					// Create the document window
					documentWindow = new DocumentWindow(dockManager, fileName, Path.GetFileName(fileName), 4, pictureBox);
					if (fileName != null) {
						documentWindow.FileName = fileName;
						documentWindow.FileType = String.Format("Image File (*{0})", Path.GetExtension(fileName).ToLower());
					}
					break;
				}
				default: {
					// Create a TextBox for the document
					RichTextBox textBox = new RichTextBox();
					textBox.Multiline = true;
					textBox.Font = new Font("Courier New", 10);
					textBox.BorderStyle = BorderStyle.None;
					textBox.HideSelection = false;
					textBox.ReadOnly = readOnly;	
					textBox.ScrollBars = RichTextBoxScrollBars.Both;
					textBox.WordWrap = false;

					// If no data was passed in, generate some
					if (fileName == null)
						fileName = String.Format("Document{0}.txt", documentWindowIndex++);
					if (text == null)
						text = "Visit our web site to learn more about Actipro WinForms Studio or our other controls:\r\nhttps://www.actiprosoftware.com/\r\n\r\nThis document was created at " + DateTime.Now.ToString() + ".";

					// Create the document window
					textBox.Text = text;
					textBox.TextChanged += new EventHandler(this.textBox_TextChanged);
					documentWindow = new DocumentWindow(dockManager, fileName, Path.GetFileName(fileName), 3, textBox);
					if (fileName != null) {
						documentWindow.FileName = fileName;
						documentWindow.FileType = String.Format("Text File (*{0})", Path.GetExtension(fileName).ToLower());
					}
					break;
				}
			}

			if (readOnly) {
				// Load a read-only context image 
				documentWindow.ContextImage = ActiproSoftware.Products.Docking.AssemblyInfo.Instance.GetImage(ActiproSoftware.Products.Docking.ImageResource.ContextReadOnly);
			}

			return documentWindow;
		}

		/// <summary>
		/// Returns whether the currently selected document is a text document.
		/// </summary>
		/// <returns>
		/// <c>true</c> if it is a document; otherwise, <c>false</c>.
		/// </returns>
		private bool IsTextDocumentSelected() {
			return ((dockManager.SelectedDocument != null) && (dockManager.SelectedDocument is DocumentWindow) && 
				(dockManager.SelectedDocument.Controls.Count == 1) && (dockManager.SelectedDocument.Controls[0] is RichTextBox));
		}

		/// <summary>
		/// Update the border styles of child controls.
		/// </summary>
		private void UpdateChildControlBorderStyles() {
			bool showBorders = (dockManager.DockRenderer.GetType() == typeof(VisualStudio2002DockRenderer));
			foreach (ToolWindow toolWindow in dockManager.ToolWindows) {
				bool changeToolWindowBorder = false;
				foreach (Control control in toolWindow.Controls) {
					if (control is TextBox) {
						((TextBox)control).BorderStyle = (showBorders ? BorderStyle.Fixed3D : BorderStyle.None);
						changeToolWindowBorder = true;
					}
					else if (control is RichTextBox) {
						((RichTextBox)control).BorderStyle = (showBorders ? BorderStyle.Fixed3D : BorderStyle.None);
						changeToolWindowBorder = true;
					}
					else if (control is ListBox) {
						((ListBox)control).BorderStyle = (showBorders ? BorderStyle.Fixed3D : BorderStyle.None);
						changeToolWindowBorder = true;
					}
				}	

				if (changeToolWindowBorder)
					toolWindow.Border = (showBorders ? null : new SimpleBorder(SimpleBorderStyle.Solid, SystemColors.ControlDark));
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Raises the <c>Closing</c> event.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnClosing(CancelEventArgs e) {
			// Call the base method
			base.OnClosing(e);

			if (!e.Cancel) {
				// Loop through and close all the documents and see if the cancel should be aborted
				for (int index = dockManager.DocumentWindows.Count - 1; index >= 0; index--) {
					// Activate the document window to examine
					DocumentWindow documentWindow = dockManager.DocumentWindows[0];
					documentWindow.Activate();

					// If a document is being closed and it has been modified...
					if (documentWindow.Modified) {
						if (MessageBox.Show(this, String.Format("The document '{0}' has been modified.  Would you like to close it without saving?", documentWindow.Key),
							"Close Modified Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
							e.Cancel = true;
							break;
						}
					}

					// Close the document window
					ignoreModifiedDocumentClose = true;
					documentWindow.Close();
					ignoreModifiedDocumentClose = false;
				}
			}
		}

	}
}
