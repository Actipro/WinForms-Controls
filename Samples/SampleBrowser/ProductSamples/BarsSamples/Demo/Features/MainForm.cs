using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Bars;
using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Controls.Extensions;

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features {

	/// <summary>
	/// A form to test the <c>Bar</c> controls.
	/// </summary>
	public partial class MainForm : System.Windows.Forms.Form {

		private BarCustomizeForm	customizeForm;
		private bool				showDarkThemeDisclaimer = true;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// INNER CLASSES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Provides a simple class to keep context.
		/// </summary>
		internal class BarFormContext {
			internal ActiproSoftware.UI.WinForms.Controls.Docking.DockManager		DockManager;
			internal MainForm										Form;
			internal int											DocumentIndex		= 1;
		}

		#region TextDocumentWindowBase Class

		/// <summary>
		/// Represents a base text <see cref="DocumentWindow"/>.
		/// </summary>
		internal abstract class TextDocumentWindowBase : ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow {

			/// <summary>
			/// Initializes a new instance of the <c>TextDocumentWindowBase</c> class. 
			/// </summary>
			public TextDocumentWindowBase(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename) : base(dockManager, filename, Path.GetFileName(filename), null, null) {
				this.FileName = filename;
				this.Image = ActiproSoftware.SampleBrowser.Resources.IconTextDocument16;
			}

			/// <summary>
			/// Gets the <see cref="TextBoxBase"/> wrapped by this document window.
			/// </summary>
			/// <value>The <see cref="TextBoxBase"/> wrapped by this document window.</value>
			internal TextBoxBase TextBox { 
				get {
					return (TextBoxBase)this.Controls[0];
				}
			}

			/// <summary>
			/// Processes the <c>Edit.Copy</c> command.
			/// </summary>
			public void ProcessEditCopy() {
				this.TextBox.Copy();
			}

			/// <summary>
			/// Processes the <c>Edit.Cut</c> command.
			/// </summary>
			public void ProcessEditCut() {
				this.TextBox.Cut();
			}

			/// <summary>
			/// Processes the <c>Edit.Delete</c> command.
			/// </summary>
			public void ProcessEditDelete() {
				this.TextBox.SelectedText = String.Empty;
			}

			/// <summary>
			/// Processes the <c>Edit.Paste</c> command.
			/// </summary>
			public void ProcessEditPaste() {
				this.TextBox.Paste();
			}

			/// <summary>
			/// Processes the <c>Edit.QuickFind</c> command.
			/// </summary>
			/// <param name="findText">The text to find.</param>
			public abstract void ProcessEditQuickFind(string findText);

			/// <summary>
			/// Processes the <c>Edit.SelectAll</c> command.
			/// </summary>
			public void ProcessEditSelectAll() {
				this.TextBox.SelectAll();
			}
			
			/// <summary>
			/// Processes the <c>Edit.Undo</c> command.
			/// </summary>
			public void ProcessEditUndo() {
				this.TextBox.Undo();
			}
		}

		#endregion

		#region RichTextDocumentWindow Class

		/// <summary>
		/// Represents a rich text <see cref="DocumentWindow"/>.
		/// </summary>
		internal class RichTextDocumentWindow : TextDocumentWindowBase {

			/// <summary>
			/// Represents a <see cref="TextBox"/> to be used on a <see cref="RichTextDocumentWindow"/>.
			/// </summary>
			private class RichTextDocumentTextBox : RichTextBox {
				const int WM_CONTEXTMENU = 0x007B;

				/// <summary>
				/// Initializes a new instance of the <c>RichTextDocumentTextBox</c> class. 
				/// </summary>
				public RichTextDocumentTextBox() {
					this.BorderStyle = BorderStyle.None;
					this.HideSelection = false;
					this.Multiline = true;
					this.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
					this.Dock = DockStyle.Fill;
				}

				/// <summary>
				/// Occurs when the selection is changed.
				/// </summary>
				/// <param name="e">Event arguments.</param>
				protected override void OnSelectionChanged(EventArgs e) {
					// Call the base method
					base.OnSelectionChanged(e);

					// Update format command states
					if (this.Parent != null) {
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.UpdateFormatCommandStates();
					}
				}

				/// <summary>
				/// Occurs when the <see cref="Style"/> property is changed.
				/// </summary>
				/// <param name="e">Event arguments.</param>
				protected override void OnStyleChanged(EventArgs e) {
					// Call the base method
					base.OnStyleChanged(e);

					// Update format command states
					if (this.Parent != null) {
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.UpdateFormatCommandStates();
					}
				}

				/// <summary>
				/// Occurs when the <see cref="Text"/> property is changed.
				/// </summary>
				/// <param name="e">Event arguments.</param>
				protected override void OnTextChanged(EventArgs e) {
					// Call the base method
					base.OnTextChanged(e);

					// Flag as modified
					((ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow)this.Parent).Modified = true;

					// Update the position statusbar panel
					if (this.Parent != null) {
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.UpdatePositionStatusBarPanel();
					}
				}

				/// <summary>
				/// Occurs when a message is sent to the control.
				/// </summary>
				/// <param name="m">Information about the message.</param>
				protected override void WndProc(ref Message m) {
					if (m.Msg == WM_CONTEXTMENU) {
						// Show a custom edit popup menu
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.barManager.PopupMenus["Text Document Context"].Show(this, Control.MousePosition, false);
					}
					else {
						// Call the base method
						base.WndProc(ref m);
					}
				}
			}

			/// <summary>
			/// Initializes a new instance of the <c>RichTextDocumentWindow</c> class. 
			/// </summary>
			public RichTextDocumentWindow(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename) : base(dockManager, filename) {
				this.Image = ActiproSoftware.SampleBrowser.Resources.IconRichTextDocument16;

				RichTextDocumentTextBox textBox = new RichTextDocumentTextBox();
				textBox.Parent = this;

				if (File.Exists(filename))
					textBox.LoadFile(filename);
			}

			/// <summary>
			/// Processes the <c>Edit.QuickFind</c> command.
			/// </summary>
			/// <param name="findText">The text to find.</param>
			public override void ProcessEditQuickFind(string findText) {
				int index = ((RichTextBox)this.TextBox).Find(findText, this.TextBox.SelectionStart + this.TextBox.SelectionLength, this.TextBox.TextLength, RichTextBoxFinds.None);
				if (index != -1) {
					this.TextBox.Select(index, findText.Length);
					this.TextBox.Focus();
				}
				else
					MessageBox.Show(this.FindForm(), String.Format("The text '{0}' was not found.", findText), "Quick Find",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			/// <summary>
			/// Processes the <c>Format.AlignCenter</c> command.
			/// </summary>
			public void ProcessFormatAlignCenter() {
				((RichTextBox)this.TextBox).SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			}

			/// <summary>
			/// Processes the <c>Format.AlignLeft</c> command.
			/// </summary>
			public void ProcessFormatAlignLeft() {
				((RichTextBox)this.TextBox).SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			}

			/// <summary>
			/// Processes the <c>Format.AlignRight</c> command.
			/// </summary>
			public void ProcessFormatAlignRight() {
				((RichTextBox)this.TextBox).SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;
			}

			/// <summary>
			/// Processes the <c>Format.BulletedList</c> command.
			/// </summary>
			public void ProcessFormatBulletedList() {
				((RichTextBox)this.TextBox).SelectionBullet = !((RichTextBox)this.TextBox).SelectionBullet;
			}

			/// <summary>
			/// Processes the <c>Format.FontSize</c> command.
			/// </summary>
			public void ProcessFormatFontSize() {
				MainForm barForm = (MainForm)this.DockManager.HostContainerControl.FindForm();

				// Get the font size
				int fontSize = 10;
				try { fontSize = Convert.ToInt32(((BarComboBoxCommand)barForm.barManager.Commands["Format.FontSize"]).ControlValue); } catch {}

				// Change the font
				((RichTextBox)this.TextBox).SelectionFont = new Font(((RichTextBox)this.TextBox).SelectionFont.FontFamily.Name, fontSize);

				// Update the font size
				((BarComboBoxCommand)barForm.barManager.Commands["Format.FontSize"]).ControlValue = fontSize.ToString();
			}

			/// <summary>
			/// Processes the <c>Format.Indent</c> command.
			/// </summary>
			public void ProcessFormatIndent() {
				((RichTextBox)this.TextBox).SelectionIndent += 20;
			}

			/// <summary>
			/// Processes the <c>Format.Outdent</c> command.
			/// </summary>
			public void ProcessFormatOutdent() {
				((RichTextBox)this.TextBox).SelectionIndent = Math.Max(0, ((RichTextBox)this.TextBox).SelectionIndent - 20);
			}
		}

		#endregion

		#region TextDocumentWindow Class

		/// <summary>
		/// Represents a text <see cref="DocumentWindow"/>.
		/// </summary>
		internal class TextDocumentWindow : TextDocumentWindowBase {

			/// <summary>
			/// Represents a <see cref="TextBox"/> to be used on a <see cref="TextDocumentWindow"/>.
			/// </summary>
			private class TextDocumentTextBox : TextBox {
				const int WM_CONTEXTMENU = 0x007B;

				/// <summary>
				/// Initializes a new instance of the <c>TextDocumentTextBox</c> class. 
				/// </summary>
				public TextDocumentTextBox() {
					this.Font = new Font("Courier New", 10);
					this.HideSelection = false;
					this.Multiline = true;
					this.ScrollBars = ScrollBars.Both;
					this.Dock = DockStyle.Fill;
				}

				/// <summary>
				/// Occurs when the <see cref="Text"/> property is changed.
				/// </summary>
				/// <param name="e">Event arguments.</param>
				protected override void OnTextChanged(EventArgs e) {
					// Call the base method
					base.OnTextChanged(e);

					// Flag as modified
					((ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow)this.Parent).Modified = true;

					// Update the position statusbar panel
					if (this.Parent != null) {
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.UpdatePositionStatusBarPanel();
					}
				}

				/// <summary>
				/// Occurs when a message is sent to the control.
				/// </summary>
				/// <param name="m">Information about the message.</param>
				protected override void WndProc(ref Message m) {
					if (m.Msg == WM_CONTEXTMENU) {
						// Show a custom edit popup menu
						MainForm barForm = (MainForm)((TextDocumentWindowBase)this.Parent).DockManager.HostContainerControl.FindForm();
						barForm.barManager.PopupMenus["Text Document Context"].Show(this, Control.MousePosition, false);
					}
					else {
						// Call the base method
						base.WndProc(ref m);
					}
				}
			}

			/// <summary>
			/// Initializes a new instance of the <c>TextDocumentWindow</c> class. 
			/// </summary>
			public TextDocumentWindow(ActiproSoftware.UI.WinForms.Controls.Docking.DockManager dockManager, string filename) : base(dockManager, filename) {
				TextDocumentTextBox textBox = new TextDocumentTextBox();
				textBox.Parent = this;

				if (File.Exists(filename)) {
					StreamReader reader = new StreamReader(filename);
					textBox.Text = reader.ReadToEnd();
					reader.Close();
				}
			}

			/// <summary>
			/// Processes the <c>Edit.QuickFind</c> command.
			/// </summary>
			/// <param name="findText">The text to find.</param>
			public override void ProcessEditQuickFind(string findText) {
				if (findText.Length == 0)
					return;

				string text = String.Empty;
				if (this.TextBox.SelectionStart + this.TextBox.SelectionLength + 1 < this.TextBox.Text.Length)
					text = this.TextBox.Text.Substring(this.TextBox.SelectionStart + this.TextBox.SelectionLength + 1);
				int index = text.IndexOf(findText);
				if (index == -1)
					index = this.TextBox.Text.IndexOf(findText);

				if (index != -1) {
					this.TextBox.Select(index, findText.Length);
					this.TextBox.Focus();
				}
				else
					MessageBox.Show(this.FindForm(), String.Format("The text '{0}' was not found.", findText), "Quick Find",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Creates an instance of the <c>BarForm</c> class.
		/// </summary>
		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Create a context and store it in the BarManager's Tag property
			BarFormContext context = new BarFormContext();
			context.DockManager = dockManager;
			context.Form		= this;
			barManager.Tag		= context;

			// Initialize the toolbar drop-down list
			foreach (DockableToolBar toolBar in barManager.DockableToolBars) {
				int index = toolBarPropertiesPropertyGridComboBox.Items.Add(toolBar.Key);
				if (toolBar.Key == "Standard")
					toolBarPropertiesPropertyGridComboBox.SelectedIndex = index;
			}
			if (toolBarPropertiesPropertyGridComboBox.SelectedIndex == -1)
				toolBarPropertiesPropertyGridComboBox.SelectedIndex = 0;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when a <see cref="BarCommand"/> is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_ClipboardChanged(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("ClipboardChanged");

			// Update the enabled state of the Paste command based on whether there is text data on the clipboard
			this.UpdateEditPasteEnabledState();
		}

		/// <summary>
		/// Occurs when a <see cref="BarCommand"/> is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CommandClick(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("CommandClick: FullName={0}", e.Command.FullName));

			if (e.Command.Category == "WindowActivate") {
				// Activate the TabbedMdiWindow in the Tag
				((ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow)e.Command.Tag).Activate();
				return;
			}

			// Execute an appropriate ProcessXXX method, if available
			//   (Note that this uses reflection to decide how to process the commands... alternatively use a switch statement like below)
			string processMethodName = "Process" + e.Command.FullName.Replace(" ", String.Empty).Replace(".", String.Empty);
			MethodInfo processMethodInfo = this.GetType().GetMethod(processMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (processMethodInfo != null) {
				try {
					processMethodInfo.Invoke(this, new object[] {});
				}
				catch (Exception ex) {
					if (ex.InnerException != null)
						MessageBox.Show("An exception occurred:\r\n" + ex.InnerException.Message, "Exception Occurred in Client Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
				MessageBox.Show(this, String.Format("The command '{0}' has not been implemented for this sample.", e.Command.FullName), "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// Alternative approach to reflection for switching on which command was clicked
			/*
			switch (e.Command.FullName) {
				case "File.Exit":
					this.ProcessFileExit();
					break;
				// NOTE: Implement other command handling code here
			}
			*/
		}

		/// <summary>
		/// Occurs when a <see cref="BarCommand"/> that causes a popup is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CommandPopup(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			// eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("CommandPopup: FullName={0}", e.Command.FullName));

			switch (e.Command.FullName) {
				case "Window.WindowList": {
					// Populate the command with the list of open windows
					BarExpanderButtonCommand command = (BarExpanderButtonCommand)e.Command;
					command.CommandLinks.Clear();
					foreach (ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindow tabbedMdiWindow in dockManager.ActiveDocuments) {
						string text = tabbedMdiWindow.Text;
						ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow = tabbedMdiWindow as ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow;
						if (documentWindow != null)
							text = documentWindow.FileName + (documentWindow.Modified ? "*" : String.Empty);
						BarButtonLink commandLink = new BarButtonLink("WindowActivate", String.Empty, text,
							tabbedMdiWindow.ImageIndex, true, true, (dockManager.SelectedDocument == tabbedMdiWindow), false);
						commandLink.Command.Tag = tabbedMdiWindow;
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
		/// <param name="e">Event arguments.</param>
		private void barManager_CommandUpdate(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			// NOTE: Update commands here if the command update timer is active
		}

		/// <summary>
		/// Occurs when a <see cref="CommandLink"/> is first dropped from the Customize dialog, allowing for initial customization.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CustomizeCommandLinkCreated(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("CustomizeCommandLinkCreated: FullName={0}", e.Command.FullName));
		}

		/// <summary>
		/// Occurs when the <see cref="CustomizeMode"/> property is changed, indicating to start or end customize mode.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CustomizeModeChanged(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("CustomizeModeChanged: {0}", barManager.CustomizeMode));
		
			// If entering dialog customize mode...
			if (!barManager.BuiltInCustomizeDialogEnabled 
				&& (barManager.CustomizeMode == BarCustomizeMode.DialogCustomize)) {
				// Create a customize form
				if (customizeForm == null) {
					customizeForm = new BarCustomizeForm(barManager);
					customizeForm.Owner = this;
				}

				// Show the customize form
				customizeForm.Show();
			}
			else {
				// Remove the customize form reference
				customizeForm = null;
			}
		}

		/// <summary>
		/// Occurs when the <see cref="CustomizeSelectedCommandLink"/> property is changed, while in customize mode.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CustomizeSelectedCommandLinkChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			// Update the customize form with the selection change
			if (customizeForm != null)
				customizeForm.UpdateSelectedCommandLink(e.CommandLink);		
		}

		/// <summary>
		/// Occurs when a possible shortcut key is typed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_KeyTyped(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarKeyTypedEventArgs e) {
			if (e.ChordKey != Keys.None) {
				if (e.Key != Keys.None) {
					if (e.Command != null) {
						eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("KeyTyped (Chord shortcut): FullName={0}{1}", 
							e.Command.FullName, (e.Cancel ? " (Key is disabled)" : String.Empty)));
						((StatusBarLabelPanel)statusBar.Panels["Message"]).Text = "Ready";
					}
					else {
						eventsListBox.SelectedIndex = eventsListBox.Items.Add("KeyTyped (No chord sequence matched)");
						((StatusBarLabelPanel)statusBar.Panels["Message"]).Text = String.Format("The key combination ({0}, {1}) is not a command.", 
							BarKeyboardShortcut.GetKeyString(e.ChordKey), BarKeyboardShortcut.GetKeyString(e.Key));
					}
				}
				else {
					eventsListBox.SelectedIndex = eventsListBox.Items.Add("KeyTyped (Chord started)");
					((StatusBarLabelPanel)statusBar.Panels["Message"]).Text = String.Format("({0}) was pressed.  Waiting for second key of chord...", 
						BarKeyboardShortcut.GetKeyString(e.ChordKey));
				}
			}
			else {
				eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("KeyTyped (Single-key shortcut): FullName={0}{1}", 
					e.Command.FullName, (e.Cancel ? " (Key is disabled)" : String.Empty)));
				((StatusBarLabelPanel)statusBar.Panels["Message"]).Text = "Ready";
			}
		}

		/// <summary>
		/// Occurs when a menu is torn-off to create a dockable toolbar.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_MenuTearOff(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarControlEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("MenuTearOff: {0}", ((DockableToolBar)e.BarControl).Key));
		}

		/// <summary>
		/// Occurs after the <see cref="BarManager.SelectedMode"/> property is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_SelectedModeChanged(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectedModeChanged: {0}", 
				(barManager.SelectedMode != null ? barManager.SelectedMode : "(Global)")));

			// Enable/disable edit commands			
			barManager.Commands["File.Close"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["File.Save"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["File.SaveAs"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["File.SaveAll"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["File.Print"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["File.PrintPreview"].Enabled	= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.Undo"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.Redo"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.Cut"].Enabled				= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.Copy"].Enabled			= (barManager.SelectedMode != null);		
			this.UpdateEditPasteEnabledState();
			barManager.Commands["Edit.Delete"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.SelectAll"].Enabled		= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.Find"].Enabled			= (barManager.SelectedMode != null);		
			barManager.Commands["Edit.QuickFind"].Enabled		= (barManager.SelectedMode != null);		
			this.UpdateFormatCommandStates();
		}

		/// <summary>
		/// Occurs when the panel is resized.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManagerPropertyGridPanel_Resize(object sender, EventArgs e) {
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
		/// <param name="e">Event arguments.</param>
		private void dockManager_SelectedDocumentChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabbedMdiWindowEventArgs e) {
			// Update the application mode
            this.UpdateApplicationMode();		
			this.UpdateFormatCommandStates();
			this.UpdatePositionStatusBarPanel();
		}

		/// <summary>
		/// Occurs when a statusbar panel is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void statusBar_StatusBarPanelClick(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.StatusBarPanelMouseEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("StatusBarPanelClick: {0} - {1} click(s) at {2}, {3}", 
				e.Panel.Key, e.Clicks, e.X, e.Y));

			switch (e.Panel.Key) {
				case "ToggleMarquee": {
					StatusBarProgressBarPanel panel = (StatusBarProgressBarPanel)statusBar.Panels["Progress"];
					if (panel.Style != StatusBarProgressBarPanelStyle.Marquee) {
						panel.Text = "Marquee Mode";
						panel.Style = StatusBarProgressBarPanelStyle.Marquee;
					}
					else {
						panel.Style = StatusBarProgressBarPanelStyle.Continuous;
						panel.Text = "Processing - 40%";
						panel.Value = 40;
					}
					break;
				}
			}		
		}

		/// <summary>
		/// Occurs after the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void toolBarPropertiesPropertyGridComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (barManager.DockableToolBars.Contains(toolBarPropertiesPropertyGridComboBox.Text))
				toolBarPropertiesPropertyGrid.SelectedObject = barManager.DockableToolBars[toolBarPropertiesPropertyGridComboBox.Text];
			else
				toolBarPropertiesPropertyGrid.SelectedObject = null;
		}

		/// <summary>
		/// Occurs when the panel is resized.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void toolBarPropertiesPropertyGridPanel_Resize(object sender, EventArgs e) {
			toolBarPropertiesPropertyGrid.SuspendLayout();

			// Reset the Anchor that is only used to keep designer layout consistent
			toolBarPropertiesPropertyGrid.Anchor = AnchorStyles.None;

			// Set the size/location of the PropertyGrid to be 1px bigger than the containing panel so the PropertyGrid border is not visible
			toolBarPropertiesPropertyGrid.Location = new Point(-1, -1);
			toolBarPropertiesPropertyGrid.Size = new Size(toolBarPropertiesPropertyGridPanel.Width + 2, toolBarPropertiesPropertyGridPanel.Height + 2);

			toolBarPropertiesPropertyGrid.ResumeLayout();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// COMMAND PROCESSING PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Processes the <c>Edit.Copy</c> command.
		/// </summary>
		public void ProcessEditCopy() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditCopy();
		}

		/// <summary>
		/// Processes the <c>Edit.Cut</c> command.
		/// </summary>
		public void ProcessEditCut() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditCut();
		}

		/// <summary>
		/// Processes the <c>Edit.Delete</c> command.
		/// </summary>
		public void ProcessEditDelete() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditDelete();
		}

		/// <summary>
		/// Processes the <c>Edit.Paste</c> command.
		/// </summary>
		public void ProcessEditPaste() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditPaste();
		}

		/// <summary>
		/// Processes the <c>Edit.QuickFind</c> command.
		/// </summary>
		public void ProcessEditQuickFind() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditQuickFind(((BarTextBoxCommand)barManager.Commands["Edit.QuickFind"]).ControlValue);
		}

		/// <summary>
		/// Processes the <c>Edit.SelectAll</c> command.
		/// </summary>
		public void ProcessEditSelectAll() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditSelectAll();
		}
		
		/// <summary>
		/// Processes the <c>Edit.Undo</c> command.
		/// </summary>
		public void ProcessEditUndo() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((TextDocumentWindowBase)dockManager.SelectedDocument).ProcessEditUndo();
		}

		/// <summary>
		/// Processes the <c>File.Exit</c> command.
		/// </summary>
		private void ProcessFileExit() {
			// Close the form
			this.Close();
		}

		/// <summary>
		/// Processes the <c>File.Close</c> command.
		/// </summary>
		private void ProcessFileClose() {
			// Close the selected document
			if (dockManager.SelectedDocument != null)
				dockManager.SelectedDocument.Close();
		}

		/// <summary>
		/// Processes the <c>File.LoadLayout</c> command.
		/// </summary>
		private void ProcessFileLoadLayout() {
			// Show the dialog
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "XML Bar Layout Files (*.xml)|*.xml";
			openFileDialog.FileName = "BarLayout.xml";
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			// Load the layout
			barManager.LoadBarLayoutFromFile(openFileDialog.FileName);
		}

		/// <summary>
		/// Processes the <c>File.New</c> command.
		/// </summary>
		private void ProcessFileNew() {
			this.ProcessFileNewTextDocument();
		}

		/// <summary>
		/// Processes the <c>File.NewRichTextDocument</c> command.
		/// </summary>
		private void ProcessFileNewRichTextDocument() {
			// Create a new document window
			var documentWindow = new MainForm.RichTextDocumentWindow(dockManager, "Document" + (((BarFormContext)barManager.Tag).DocumentIndex++) + ".rtf");

			// Apply the current color scheme to the new window
			var colorScheme = barManager.RendererResolved.ResolvedColorScheme();
			ThemeHelper.ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);

			// Activate the document
			documentWindow.Activate();
		}

		/// <summary>
		/// Processes the <c>File.NewTextDocument</c> command.
		/// </summary>
		private void ProcessFileNewTextDocument() {
			// Create a new document window
			var documentWindow = new MainForm.TextDocumentWindow(dockManager, "Document" + (((BarFormContext)barManager.Tag).DocumentIndex++) + ".txt");

			// Apply the current color scheme to the new window
			var colorScheme = barManager.RendererResolved.ResolvedColorScheme();
			ThemeHelper.ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);

			// Activate the document
			documentWindow.Activate();
		}

		/// <summary>
		/// Processes the <c>File.Open</c> command.
		/// </summary>
		private void ProcessFileOpen() {
			// Show the dialog
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Rich Text Files (*.rtf;*.doc)|*.rtf;*.doc|Text Files (*.txt)|*.txt";
			openFileDialog.FileName = String.Empty;
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			// Open the text document
			ActiproSoftware.UI.WinForms.Controls.Docking.DocumentWindow documentWindow;
			switch (Path.GetExtension(openFileDialog.FileName).ToLower()) {
				case ".doc":
				case ".rtf":
					documentWindow = new MainForm.RichTextDocumentWindow(dockManager, openFileDialog.FileName);
					break;
				default:
					documentWindow = new MainForm.TextDocumentWindow(dockManager, openFileDialog.FileName);
					break;
			}
			if (documentWindow != null) {
				// Apply the current color scheme to the window
				var colorScheme = barManager.RendererResolved.ResolvedColorScheme();
				ThemeHelper.ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);

				documentWindow.Modified = false;
				documentWindow.Activate();
			}
		}

		/// <summary>
		/// Processes the <c>File.SaveLayout</c> command.
		/// </summary>
		private void ProcessFileSaveLayout() {
			// Show the dialog
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML Bar Layout Files (*.xml)|*.xml";
			saveFileDialog.FileName = "BarLayout.xml";
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;
		
			// Save the layout
			barManager.SaveBarLayoutToFile(saveFileDialog.FileName, false);
		}

		/// <summary>
		/// Processes the <c>Format.AlignCenter</c> command.
		/// </summary>
		public void ProcessFormatAlignCenter() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatAlignCenter();
		}

		/// <summary>
		/// Processes the <c>Format.AlignLeft</c> command.
		/// </summary>
		public void ProcessFormatAlignLeft() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatAlignLeft();
		}

		/// <summary>
		/// Processes the <c>Format.AlignRight</c> command.
		/// </summary>
		public void ProcessFormatAlignRight() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatAlignRight();
		}

		/// <summary>
		/// Processes the <c>Format.BulletedList</c> command.
		/// </summary>
		public void ProcessFormatBulletedList() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatBulletedList();
		}

		/// <summary>
		/// Processes the <c>Format.FontSize</c> command.
		/// </summary>
		public void ProcessFormatFontSize() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatFontSize();
		}

		/// <summary>
		/// Processes the <c>Format.Indent</c> command.
		/// </summary>
		public void ProcessFormatIndent() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatIndent();
		}

		/// <summary>
		/// Processes the <c>Format.Outdent</c> command.
		/// </summary>
		public void ProcessFormatOutdent() {
			if (dockManager.SelectedDocument is RichTextDocumentWindow)
				((RichTextDocumentWindow)dockManager.SelectedDocument).ProcessFormatOutdent();
		}

		/// <summary>
		/// Processes the <c>Help.About</c> command.
		/// </summary>
		private void ProcessHelpAbout() {
			SampleBrowser.Program.LaunchExternalBrowser("https://www.actiprosoftware.com");
		}

		/// <summary>
		/// Processes the <c>Tools.ChordKey1</c> command.
		/// </summary>
		private void ProcessToolsChordKey1() {
			MessageBox.Show(this, "Chord key 1 has a chord-based keyboard shortcut.", "Chord", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Processes the <c>Tools.ChordKey2</c> command.
		/// </summary>
		private void ProcessToolsChordKey2() {
			MessageBox.Show(this, "Chord key 2 has a chord-based keyboard shortcut.", "Chord", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Processes the <c>Help.Contents</c> command.
		/// </summary>
		private void ProcessHelpContents() {
			SampleBrowser.Program.LaunchProductHelp();
		}

		/// <summary>
		/// Processes the <c>Tools.ToggleFindButtonEnabledState</c> command.
		/// </summary>
		private void ProcessToolsToggleFindButtonEnabledState() {
			barManager.Commands["Edit.Find"].Enabled = !barManager.Commands["Edit.Find"].Enabled;
		}

		/// <summary>
		/// Processes the <c>Tools.Customize</c> command.
		/// </summary>
		private void ProcessToolsCustomize() {
			barManager.CustomizeMode = BarCustomizeMode.DialogCustomize;
		}

		/// <summary>
		/// Processes the <c>View.ClearEventLog</c> command.
		/// </summary>
		private void ProcessViewClearEventLog() {
			eventsListBox.Items.Clear();
		}

		/// <summary>
		/// Processes the <c>View.MdiChildCloseButtonVisibility</c> command.
		/// </summary>
		private void ProcessViewMdiChildCloseButtonVisibility() {
			barManager.MdiChildCloseButtonVisible = ((BarButtonCommand)barManager.Commands["View.MdiChildCloseButtonVisibility"]).Checked;
		}

		/// <summary>
		/// Processes the <c>View.MdiChildMinimizeButtonVisibility</c> command.
		/// </summary>
		private void ProcessViewMdiChildMinimizeButtonVisibility() {
			barManager.MdiChildMinimizeButtonVisible = ((BarButtonCommand)barManager.Commands["View.MdiChildMinimizeButtonVisibility"]).Checked;
		}

		/// <summary>
		/// Processes the <c>View.MdiChildRestoreButtonVisibility</c> command.
		/// </summary>
		private void ProcessViewMdiChildRestoreButtonVisibility() {
			barManager.MdiChildRestoreButtonVisible = ((BarButtonCommand)barManager.Commands["View.MdiChildRestoreButtonVisibility"]).Checked;
		}
		
		/// <summary>
		/// Processes the <c>View.RendererCustomGreen</c> command.
		/// </summary>
		private void ProcessViewRendererCustomGreen() {
			var scheme = new WindowsColorScheme("Green", WindowsColorSchemeType.WindowsXPBlue, UIColor.FromWebColor("#155E2F").ToColor());
			barManager.Renderer = new Office2003BarRenderer(scheme);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(scheme);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(scheme);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(scheme);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererCustomTan</c> command.
		/// </summary>
		private void ProcessViewRendererCustomTan() {
			var scheme = new WindowsColorScheme("Tan", WindowsColorSchemeType.WindowsXPBlue, Color.Tan);
			barManager.Renderer = new Office2003BarRenderer(scheme);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(scheme);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(scheme);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(scheme);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererMetroDark</c> command.
		/// </summary>
		private void ProcessViewRendererMetroDark() {
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
			barManager.Renderer = new MetroBarRenderer(WindowsColorSchemeType.MetroLight);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDockRenderer(WindowsColorSchemeType.MetroLight);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroDocumentWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroToolWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
			statusBar.Renderer = new MetroStatusBarRenderer(WindowsColorSchemeType.MetroLight);
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2003Blue</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2003Blue() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.WindowsXPBlue);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.WindowsXPBlue);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPBlue);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPBlue);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2003OliveGreen</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2003OliveGreen() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.WindowsXPOliveGreen);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.WindowsXPOliveGreen);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPOliveGreen);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPOliveGreen);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2003Royale</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2003Royale() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.WindowsXPRoyale);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005ToolWindowTabStripRenderer();
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2003Silver</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2003Silver() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.WindowsXPSilver);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.WindowsXPSilver);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPSilver);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.WindowsXPSilver);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2003WindowsClassic</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2003WindowsClassic() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.WindowsClassic);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005ToolWindowTabStripRenderer();
			statusBar.Renderer = new VisualStudio2002StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2007Black</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2007Black() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.Office2007Black);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.Office2007Black);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.Office2007Black);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.Office2007Black);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2007Blue</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2007Blue() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.Office2007Blue);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.Office2007Blue);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.Office2007Blue);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.Office2007Blue);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererOffice2007Silver</c> command.
		/// </summary>
		private void ProcessViewRendererOffice2007Silver() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.Office2007Silver);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DockRenderer(WindowsColorSchemeType.Office2007Silver);
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003DocumentWindowTabStripRenderer(WindowsColorSchemeType.Office2007Silver);
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(WindowsColorSchemeType.Office2007Silver);
			statusBar.Renderer = new Office2003StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererVisualStudio2002</c> command.
		/// </summary>
		private void ProcessViewRendererVisualStudio2002() {
			barManager.Renderer = new VisualStudio2002BarRenderer();
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2002DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2002DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2002ToolWindowTabStripRenderer();
			statusBar.Renderer = new VisualStudio2002StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.RendererVisualStudio2005</c> command.
		/// </summary>
		private void ProcessViewRendererVisualStudio2005() {
			barManager.Renderer = new Office2003BarRenderer(WindowsColorSchemeType.VisualStudio2005);
			dockManager.DockRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DockRenderer();
			dockManager.TabbedMdiContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005DocumentWindowTabStripRenderer();
			dockManager.ToolWindowContainerTabStripRenderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005ToolWindowTabStripRenderer();
			statusBar.Renderer = new VisualStudio2005StatusBarRenderer();
			OnRendererChanged();
		}

		/// <summary>
		/// Processes the <c>View.AnimatedStatusBarIcon</c> command.
		/// </summary>
		private void ProcessViewAnimatedStatusBarIcon() {
			statusBar.Panels["AnimatedIcon"].Visible = ((BarButtonCommand)barManager.Commands["View.AnimatedStatusBarIcon"]).Checked;
		}

		/// <summary>
		/// Processes the <c>Window.MdiStyleStandard</c> command.
		/// </summary>
		private void ProcessWindowMdiStyleStandard() {
			dockManager.DocumentMdiStyle = ActiproSoftware.UI.WinForms.Controls.Docking.DocumentMdiStyle.Standard;
		}

		/// <summary>
		/// Processes the <c>Window.MdiStyleTabbed</c> command.
		/// </summary>
		private void ProcessWindowMdiStyleTabbed() {
			dockManager.DocumentMdiStyle = ActiproSoftware.UI.WinForms.Controls.Docking.DocumentMdiStyle.Tabbed;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Invoked when the current renderer configuration is changed.
		/// </summary>
		private void OnRendererChanged() {
			// Get the new color scheme
			var colorScheme = barManager.RendererResolved.ResolvedColorScheme();

			// Update child controls to match the renderer's color scheme
			ThemeHelper.ApplyComponentColors(dockManager, colorScheme, recurseChildren: true);

			// Show disclaimer about dark color schemes
			if (showDarkThemeDisclaimer && colorScheme.Intent.IsDarkColorScheme()) {
				showDarkThemeDisclaimer = false;
				ThemeHelper.ShowDarkThemeDisclaimer();
			}
		}

		/// <summary>
		/// Updates the application mode.
		/// </summary>
		private void UpdateApplicationMode() {
			if (dockManager.SelectedDocument != null) {
				if (dockManager.SelectedDocument is TextDocumentWindow) {
					// In a text document window
					barManager.SelectedMode = "Text Editor";
					return;
				}
				else if (dockManager.SelectedDocument is RichTextDocumentWindow) {
					// In a rich text document window
					barManager.SelectedMode = "Rich Text Editor";
					return;
				}
			}
			
			// Set global mode (null)
			barManager.SelectedMode = null;
		}

		/// <summary>
		/// Update the enabled state of the Paste command based on whether there is text data on the clipboard.
		/// </summary>
		private void UpdateEditPasteEnabledState() {
			IDataObject dataObject = null;
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
			barManager.Commands["Edit.Paste"].Enabled = (barManager.SelectedMode != null) && (dataObject.GetDataPresent(DataFormats.Text));		
		}

		/// <summary>
		/// Update the states of the format commands.
		/// </summary>
		private void UpdateFormatCommandStates() {
			bool isRichTextEditor = (barManager.SelectedMode == "Rich Text Editor");
			
			barManager.Commands["Format.FontSize"].Enabled = isRichTextEditor;
			barManager.Commands["Format.AlignLeft"].Enabled = isRichTextEditor;
			barManager.Commands["Format.AlignCenter"].Enabled = isRichTextEditor;
			barManager.Commands["Format.AlignRight"].Enabled = isRichTextEditor;
			barManager.Commands["Format.BulletedList"].Enabled = isRichTextEditor;
			barManager.Commands["Format.Outdent"].Enabled = isRichTextEditor;
			barManager.Commands["Format.Indent"].Enabled = isRichTextEditor;

			if ((isRichTextEditor) && (dockManager.SelectedDocument != null)) {
				RichTextBox richTextBox = (RichTextBox)((TextDocumentWindowBase)dockManager.SelectedDocument).TextBox;
				if (richTextBox.SelectionFont != null)
					((BarComboBoxCommand)barManager.Commands["Format.FontSize"]).ControlValue = richTextBox.SelectionFont.SizeInPoints.ToString();
				switch (richTextBox.SelectionAlignment) {
					case System.Windows.Forms.HorizontalAlignment.Left:
						barManager.SetCheckGroupValue("FormatAlign", (IBarCheckableCommand)barManager.Commands["Format.AlignLeft"]);
						break;
					case System.Windows.Forms.HorizontalAlignment.Center:
						barManager.SetCheckGroupValue("FormatAlign", (IBarCheckableCommand)barManager.Commands["Format.AlignCenter"]);
						break;
					case System.Windows.Forms.HorizontalAlignment.Right:
						barManager.SetCheckGroupValue("FormatAlign", (IBarCheckableCommand)barManager.Commands["Format.AlignRight"]);
						break;
				}
				((BarButtonCommand)barManager.Commands["Format.BulletedList"]).Checked = richTextBox.SelectionBullet;
			}
			else {
				barManager.SetCheckGroupValue("FormatAlign", null);
				((BarButtonCommand)barManager.Commands["Format.BulletedList"]).Checked = false;
			}
		}

		/// <summary>
		/// Updates the position statusbar panel.
		/// </summary>
		private void UpdatePositionStatusBarPanel() {
			if (dockManager.SelectedDocument is TextDocumentWindowBase)
				((StatusBarLabelPanel)statusBar.Panels["Position"]).Text = Math.Max(1, ((TextDocumentWindowBase)dockManager.SelectedDocument).TextBox.Lines.Length) + " line(s)";
			else
				((StatusBarLabelPanel)statusBar.Panels["Position"]).Text = null;
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the form is loaded.
		/// </summary>
		/// <param name="e">The <c>EventArgs</c> that contains data related to this event.</param>
		protected override void OnLoad(EventArgs e) {
			// Call the base method
			base.OnLoad(e);

			if (dockManager.DocumentWindows.Count == 0) {
				// Create a new MDI child form
				RichTextDocumentWindow documentWindow = new RichTextDocumentWindow(dockManager, "Intro.rtf"); 
				documentWindow.Activate();
				((RichTextBox)documentWindow.TextBox).Rtf = ActiproSoftware.SampleBrowser.Resources.BarsDemoFeaturesIntro;
				documentWindow.Modified = false;
			}
		}

	}
}
