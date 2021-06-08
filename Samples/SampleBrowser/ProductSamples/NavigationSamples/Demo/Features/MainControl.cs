using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.UI.WinForms.Controls.Navigation;

namespace ActiproSoftware.ProductSamples.NavigationSamples.Demo.Features {

	/// <summary>
	/// A sample to test the <c>NavigationBar</c> control.
	/// </summary>
	public partial class MainControl : System.Windows.Forms.UserControl {

		private INavigationBarRenderer	customNavigationBarRenderer;

		/// <summary>
		/// Creates an instance of the <c>MainForm</c> class.
		/// </summary>
		public MainControl() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Store the current renderer from the designer as the custom renderer
			customNavigationBarRenderer = navigationBar.Renderer;

			// Populate the drop-down list
			string[] names = Enum.GetNames(typeof(WindowsColorSchemeType));
			foreach (string name in names)
				rendererDropDownList.Items.Add(name);
			rendererDropDownList.Items.Add("Custom");
			rendererDropDownList.SelectedIndex = rendererDropDownList.Items.IndexOf(WindowsColorSchemeType.MetroLight.ToString());

			// Expand all nodes
			mailTreeView.ExpandAll();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void loadLayoutButton_Click(object sender, EventArgs e) {
			// Show the dialog
			openFileDialog.Filter = "XML NavigationBar Layout Files (*.xml)|*.xml";
			openFileDialog.FileName = "NavBarLayout.xml";
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			// Load the layout
			navigationBar.LoadLayoutFromFile(openFileDialog.FileName);
		}

		/// <summary>
		/// Occurs when a <see cref="NavigationBar"/> needs a context menu displayed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_ContextMenuRequested(object sender, ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarContextMenuEventArgs e) {
			if (e.NavigationPane != null)
				eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("ContextMenuRequested: Source={0}; Index={1}; Text={2}; ButtonLocation={3}; Cancelled={4}", 
					e.Source, navigationBar.Panes.IndexOf(e.NavigationPane), e.NavigationPane.Text, e.NavigationPane.ButtonLocation, false));
			else
				eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("ContextMenuRequested: Source={0}; Cancelled={1}", e.Source, false));
		}
		
		/// <summary>
		/// Occurs when the value of the MaximumBarButtonCount has changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_MaximumBarButtonCountChanged(object sender, EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("MaximumBarButtonCountChanged");
		}

		/// <summary>
		/// Occurs before the <see cref="NavigationPane.Active"/> property on a <see cref="NavigationPane"/> changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_NavigationPaneActiveChanging(object sender, NavigationPaneCancelEventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("NavigationPaneActiveChanging: Index={0}; Text={1}; Cancelled={2}",
				navigationBar.Panes.IndexOf(e.NavigationPane), e.NavigationPane.Text, e.Cancel));
		}

		/// <summary>
		/// Occurs when the panes are reordered via the Navigation Bar Options dialog.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_NavigationPanesReordered(object sender, EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add("NavigationPanesReordered");
		}

		/// <summary>
		/// Occurs after the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_SelectionChanged(object sender, System.EventArgs e) {
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectionChanged: Index={0}; Text={1}",
				navigationBar.SelectedIndex, (navigationBar.SelectedPane != null ? navigationBar.SelectedPane.Text : "<null>")));
		}

		/// <summary>
		/// Occurs before the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void navigationBar_SelectionChanging(object sender, ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationPaneCancelEventArgs e) {
			e.Cancel = preventSelectionChangesCheckBox.Checked;

			eventsListBox.SelectedIndex = eventsListBox.Items.Add(String.Format("SelectionChanging: Index={0}; Text={1}, Cancelled={2}",
				navigationBar.SelectedIndex, (navigationBar.SelectedPane != null ? navigationBar.SelectedPane.Text : "<null>"), e.Cancel));
		}
		
		/// <summary>
		/// Occurs after the selection changes.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void rendererDropDownList_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Update the navigationbar renderer
			if (rendererDropDownList.SelectedItem.ToString() == "Custom")
				navigationBar.Renderer = customNavigationBarRenderer;
			else {
				WindowsColorSchemeType colorSchemeType = (WindowsColorSchemeType)Enum.Parse(typeof(WindowsColorSchemeType), rendererDropDownList.SelectedItem.ToString(), true);
				if (rendererDropDownList.SelectedItem.ToString().StartsWith("MetroLight"))
					navigationBar.Renderer = new MetroLightNavigationBarRenderer();
				else if (rendererDropDownList.SelectedItem.ToString().StartsWith("Office2007"))
					navigationBar.Renderer = new Office2007NavigationBarRenderer(colorSchemeType);
				else
					navigationBar.Renderer = new Office2003NavigationBarRenderer(colorSchemeType);
			}
			rendererPropertyGrid.SelectedObject = navigationBar.Renderer;

			// Sync up all panels
			allFoldersNavigationBarPanel.Renderer = navigationBar.Renderer;
			changeNavigationBarPanel.Renderer = navigationBar.Renderer;
			eventsNavigationBarPanel.Renderer = navigationBar.Renderer;
						
			// Update form background and tabstrip renderer
			if (navigationBar.Renderer is Office2003NavigationBarRenderer) {
				WindowsColorSchemeType colorSchemeType = ((Office2003NavigationBarRenderer)navigationBar.Renderer).BaseColorSchemeType;
				this.BackColor = WindowsColorScheme.GetColorScheme(colorSchemeType).FormBackGradientEnd;
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.Office2003ToolWindowTabStripRenderer(colorSchemeType);
			}
			else {
				this.BackColor = SystemColors.Control;
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudio2005ToolWindowTabStripRenderer();
			}
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void saveLayoutButton_Click(object sender, EventArgs e) {
			// Show the dialog
			saveFileDialog.Filter = "XML NavigationBar Layout Files (*.xml)|*.xml";
			saveFileDialog.FileName = "NavBarLayout.xml";
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;
		
			// Save the layout
			navigationBar.SaveLayoutToFile(saveFileDialog.FileName);
		}


	}
}
