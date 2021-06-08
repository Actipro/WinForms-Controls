using System;
using System.Drawing;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.Products.Docking;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Docking;

namespace ActiproSoftware.ProductSamples.DockingSamples.Demo.TabStripFeatures {

	/// <summary>
	/// A sample to test the <c>TabStrip</c> control.
	/// </summary>
	public partial class MainControl : System.Windows.Forms.UserControl {

		private ITabStripRenderer	customTabStripRenderer;

		/// <summary>
		/// Creates an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Store the current renderer from the designer as the custom renderer
			customTabStripRenderer = tabStrip.Renderer;

			propertiesTabStrip.Renderer = new Office2003ToolWindowTabStripRenderer();
			if (propertiesTabStrip.Renderer is Office2003ToolWindowTabStripRenderer) {
				WindowsColorSchemeType colorSchemeType = ((Office2003ToolWindowTabStripRenderer)propertiesTabStrip.Renderer).BaseColorSchemeType;
				this.BackColor = WindowsColorScheme.GetColorScheme(colorSchemeType).FormBackGradientEnd;
			}
			else 
				this.BackColor = SystemColors.Control;

			// Select a renderer
			rendererDropDownList.SelectedIndex = 0;

			// Load a read-only context image for the second tab
			tabStripInfoTabStripPage.ContextImage = AssemblyInfo.Instance.GetImage(ImageResource.ContextReadOnly);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void linkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser(linkLabel.Text);
		}

		/// <summary>
		/// Occurs when the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void rendererDropDownList_SelectedIndexChanged(object sender, System.EventArgs e) {
            switch (rendererDropDownList.Text) {
				case "Metro Light Document Window":
					tabStrip.Renderer = new MetroLightDocumentWindowTabStripRenderer();
					break;
				case "Metro Light Tool Window":
					tabStrip.Renderer = new MetroLightToolWindowTabStripRenderer();
					break;
				case "Visual Studio 2005 Document Window":
					tabStrip.Renderer = new VisualStudio2005DocumentWindowTabStripRenderer();
					break;
				case "Visual Studio 2005 Tool Window":
					tabStrip.Renderer = new VisualStudio2005ToolWindowTabStripRenderer();
					break;
				case "Visual Studio 2005 Beta 2 Tool Window":
					tabStrip.Renderer = new VisualStudio2005Beta2ToolWindowTabStripRenderer();
					break;
				case "Visual Studio 2002 Document Window":
					tabStrip.Renderer = new VisualStudio2002DocumentWindowTabStripRenderer();
					break;
				case "Visual Studio 2002 Tool Window":
					tabStrip.Renderer = new VisualStudio2002ToolWindowTabStripRenderer();
					break;
				case "Office 2003 Document Window":
					tabStrip.Renderer = new Office2003DocumentWindowTabStripRenderer();
					break;
				case "Office 2003 Tool Window":
					tabStrip.Renderer = new Office2003ToolWindowTabStripRenderer();
					break;
				case "Office 2003 (based on Visual Studio 2005 Beta 2 style) Tool Window":
					tabStrip.Renderer = new Office2003VisualStudio2005Beta2ToolWindowTabStripRenderer();
					break;
				default:
					tabStrip.Renderer = customTabStripRenderer;
					break;
			}
			rendererPropertyGrid.SelectedObject = tabStrip.Renderer;
		}

		/// <summary>
		/// Occurs when a radio button is checked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabOverflowRadioButton_CheckedChanged(object sender, System.EventArgs e) {
			if (tabOverflowNoneRadioButton.Checked)
				tabStrip.TabOverflowStyle = TabStripTabOverflowStyle.None;
			else if (tabOverflowShrinkToFitRadioButton.Checked)
				tabStrip.TabOverflowStyle = TabStripTabOverflowStyle.ShrinkToFit;
			else if (tabOverflowScrollButtonsRadioButton.Checked)
				tabStrip.TabOverflowStyle = TabStripTabOverflowStyle.ScrollButtons;
		}

		/// <summary>
		/// Occurs when a <see cref="Command"/> is executed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_Command(object sender, ActiproSoftware.UI.WinForms.Controls.Commands.CommandEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("Command: Name={0}", e.Command.Name));

			// If the options command is clicked
			if (e.Command == TabStrip.CloseCommand) {
				if (tabStrip.SelectedPage != null)
					tabStrip.Pages.Remove(tabStrip.SelectedPage);
			}
			else if (e.Command == TabStrip.OptionsCommand) {
				var menu = new ContextMenuStrip();
				foreach (TabStripPage page in tabStrip.Pages) {
					var menuItem = new ToolStripMenuItem(page.Text, page.GetImage(), new EventHandler(this.tabStripPageMenuItem_Click));
					menuItem.Checked = (tabStrip.SelectedPage == page);
					menuItem.Tag = page;
					menu.Items.Add(menuItem);
				}

				TabStripButton button = tabStrip.GetButtonForCommand(e.Command);
				if (button != null)
					menu.Show(tabStrip, new Point(button.Bounds.Left, button.Bounds.Bottom));
			}
		}

		/// <summary>
		/// Occurs after the currently selected page is reselected.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_Reselect(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("Reselect: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs after the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_SelectionChanged(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectionChanged: Index={0}; Text={1}",
				tabStrip.SelectedIndex, (e.TabStripPage != null ? e.TabStripPage.Text : "<null>")));
		}

		/// <summary>
		/// Occurs before the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_SelectionChanging(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageCancelEventArgs e) {
			e.Cancel |= preventSelectionChangesCheckBox.Checked;

			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectionChanging: Index={0}; Text={1}, Cancelled={2}",
				tabStrip.SelectedIndex, (tabStrip.SelectedPage != null ? tabStrip.SelectedPage.Text : "<null>"), e.Cancel));
		}

		/// <summary>
		/// Occurs when a tab needs a context menu displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_TabStripPageTabContextMenu(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageContextMenuEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("TabStripPageTabContextMenu: Index={0}; Text={1}", 
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs when a tab is double-clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_TabStripPageTabDoubleClick(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("TabStripPageTabDoubleClick: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs when a tab is starting to be dragged.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_TabStripPageTabDragStart(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("TabStripPageTabDragStart: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs before a tool tip is displayed for a tab and gives an opportunity to update the tab's tool tip text.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStrip_TabStripPageTabToolTipDisplaying(object sender, ActiproSoftware.UI.WinForms.Controls.Docking.TabStripPageEventArgs e) {
			// eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("TabStripPageTabToolTipDisplaying: Index={0}; Text={1}; ToolTipText={2}",
			//  	tabStrip.SelectedIndex, e.TabStripPage.Text, e.TabStripPage.ToolTipText));
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void tabStripPageMenuItem_Click(object sender, System.EventArgs e) {
			tabStrip.SelectedPage = (TabStripPage)(((ToolStripItem)sender).Tag);
		}

	}

}
