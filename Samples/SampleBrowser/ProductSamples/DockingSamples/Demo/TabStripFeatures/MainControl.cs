using System;
using System.Drawing;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.Products.Docking;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Drawing.Xaml;

namespace ActiproSoftware.ProductSamples.DockingSamples.Demo.TabStripFeatures {

	/// <summary>
	/// A sample to test the <c>TabStrip</c> control.
	/// </summary>
	public partial class MainControl : UserControl {

		private	readonly ITabStripRenderer customTabStripRenderer;

		/// <summary>
		/// Creates an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Make sure the options control is properly sized
			ResizeOptionsControl();

			// Store the current renderer from the designer as the custom renderer
			customTabStripRenderer = tabStrip.Renderer;

			// Select a renderer
			rendererDropDownList.SelectedIndex = 0;

			// Load a read-only context image for the second tab
			tabStripInfoTabStripPage.ContextImage = AssemblyInfo.Instance.GetImage(ImageResource.ContextReadOnly, DpiHelper.GetDpiScale(this));
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			SampleBrowser.Program.LaunchExternalBrowser(linkLabel.Text);
		}

		/// <summary>
		/// Occurs when the selected index is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnRendererDropDownListSelectedIndexChanged(object sender, EventArgs e) {
			switch (rendererDropDownList.Text) {
				case "Metro Light Document Window":
					tabStrip.Renderer = new MetroDocumentWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
					break;
				case "Metro Light Tool Window":
					tabStrip.Renderer = new MetroToolWindowTabStripRenderer(WindowsColorSchemeType.MetroLight);
					break;
				case "Metro Dark Document Window":
					tabStrip.Renderer = new MetroDocumentWindowTabStripRenderer(WindowsColorSchemeType.MetroDark);
					break;
				case "Metro Dark Tool Window":
					tabStrip.Renderer = new MetroToolWindowTabStripRenderer(WindowsColorSchemeType.MetroDark);
					break;
				case "Visual Studio Blue Document Window":
					tabStrip.Renderer = new VisualStudioDocumentWindowTabStripRenderer(WindowsColorSchemeType.VisualStudioBlue);
					break;
				case "Visual Studio Blue Tool Window":
					tabStrip.Renderer = new VisualStudioToolWindowTabStripRenderer(WindowsColorSchemeType.VisualStudioBlue);
					break;
				case "Visual Studio Classic Document Window":
					tabStrip.Renderer = new VisualStudioClassicDocumentWindowTabStripRenderer();
					break;
				case "Visual Studio Classic Tool Window":
					tabStrip.Renderer = new VisualStudioClassicToolWindowTabStripRenderer();
					break;
				case "Windows Classic Document Window":
					tabStrip.Renderer = new WindowsClassicDocumentWindowTabStripRenderer();
					break;
				case "Windows Classic Tool Window":
					tabStrip.Renderer = new WindowsClassicToolWindowTabStripRenderer();
					break;
				case "Office Classic Document Window":
					tabStrip.Renderer = new OfficeClassicDocumentWindowTabStripRenderer();
					break;
				case "Office Classic Tool Window":
					tabStrip.Renderer = new OfficeClassicToolWindowTabStripRenderer();
					break;
				default:
					tabStrip.Renderer = customTabStripRenderer;
					break;
			}
			rendererPropertyGrid.SelectedObject = tabStrip.Renderer;

			// Customize key controls based on color scheme to render better in light/dark themes
			var colorScheme = tabStrip.Renderer.ColorScheme;
			ThemeHelper.ApplyComponentColors(tabStrip, colorScheme, recurseChildren: true);
		}

		/// <summary>
		/// Occurs when a radio button is checked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabOverflowRadioButtonCheckedChanged(object sender, EventArgs e) {
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
		private void OnTabStripCommand(object sender, ActiproSoftware.UI.WinForms.Controls.Commands.CommandEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("Command: Name={0}", e.Command.Name));

			// If the options command is clicked
			if (e.Command == TabStrip.CloseCommand) {
				if (tabStrip.SelectedPage != null)
					tabStrip.Pages.Remove(tabStrip.SelectedPage);
			}
			else if (e.Command == TabStrip.OptionsCommand) {
				var menu = new ContextMenuStrip();
				foreach (TabStripPage page in tabStrip.Pages) {
					var menuItem = new ToolStripMenuItem(page.Text, page.GetImage(), new EventHandler(this.OnTabStripPageMenuItemClick));
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
		private void OnTabStripReselect(object sender, TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("Reselect: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs after the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripSelectionChanged(object sender, TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("SelectionChanged: Index={0}; Text={1}",
				tabStrip.SelectedIndex, (e.TabStripPage != null ? e.TabStripPage.Text : "<null>")));
		}

		/// <summary>
		/// Occurs before the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripSelectionChanging(object sender, TabStripPageCancelEventArgs e) {
			e.Cancel |= preventSelectionChangesCheckBox.Checked;

			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("SelectionChanging: Index={0}; Text={1}, Cancelled={2}",
				tabStrip.SelectedIndex, (tabStrip.SelectedPage != null ? tabStrip.SelectedPage.Text : "<null>"), e.Cancel));
		}

		/// <summary>
		/// Occurs when a tab needs a context menu displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripTabStripPageTabContextMenu(object sender, TabStripPageContextMenuEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("TabStripPageTabContextMenu: Index={0}; Text={1}", 
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs when a tab is double-clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripTabStripPageTabDoubleClick(object sender, TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("TabStripPageTabDoubleClick: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs when a tab is starting to be dragged.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripTabStripPageTabDragStart(object sender, TabStripPageEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(string.Format("TabStripPageTabDragStart: Index={0}; Text={1}",
				tabStrip.SelectedIndex, e.TabStripPage.Text));
		}

		/// <summary>
		/// Occurs before a tool tip is displayed for a tab and gives an opportunity to update the tab's tool tip text.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripTabStripPageTabToolTipDisplaying(object sender, TabStripPageEventArgs e) {
			// eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("TabStripPageTabToolTipDisplaying: Index={0}; Text={1}; ToolTipText={2}",
			//  	tabStrip.SelectedIndex, e.TabStripPage.Text, e.TabStripPage.ToolTipText));
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void OnTabStripPageMenuItemClick(object sender, EventArgs e) {
			tabStrip.SelectedPage = (TabStripPage)(((ToolStripItem)sender).Tag);
		}

		/// <summary>
		/// Resizes the control used to display options for the sample.
		/// </summary>
		private void ResizeOptionsControl() {
			// The options control is displayed within a SplitContainer having a fixed sized, so the splitter
			// position is adjusted to define the size of the options control
			var dpiScale = DpiHelper.GetDpiScale(DeviceDpi);
			rightOuterSplitContainer.SplitterDistance = DpiHelper.ScaleInt32(100, dpiScale);
		}


		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Provides constants for rescaling the control when a DPI change occurs.
		/// </summary>
		/// <param name="deviceDpiOld">The DPI value prior to the change.</param>
		/// <param name="deviceDpiNew">The DPI value after the change.</param>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			// Re-assign read-only context image for the second tab based on the new DPI
			tabStripInfoTabStripPage.ContextImage = AssemblyInfo.Instance.GetImage(ImageResource.ContextReadOnly, DpiHelper.GetDpiScale(deviceDpiNew));

			// Make sure the options control is resized for the new DPI
			ResizeOptionsControl();
		}

	}

}
