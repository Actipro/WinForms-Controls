using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Controls.Navigation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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
			foreach (FieldInfo fieldInfo in typeof(WindowsColorSchemeType).GetFields()
				.Where(x => x.IsLiteral)
				.OrderBy(x => x.Name)) {

				// Ignore items that are not browsable
				if ((fieldInfo.GetCustomAttribute<EditorBrowsableAttribute>()?.State ?? EditorBrowsableState.Always) == EditorBrowsableState.Never)
					continue;

				var name = fieldInfo.Name;

				// Ignore special "WindowsDefault" that just resolves as one of the other types
				if (((WindowsColorSchemeType)fieldInfo.GetValue(fieldInfo.Name)) == WindowsColorSchemeType.WindowsDefault)
					continue;

				rendererDropDownList.Items.Add(name);
			}
			rendererDropDownList.Items.Add("Custom");

			// Pre-select the type that is the current windows default
			rendererDropDownList.SelectedIndex = rendererDropDownList.Items.IndexOf(WindowsColorScheme.DefaultColorSchemeType.ToString());

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
			// Determine the selected color scheme type
			var selectedColorSchemeTypeName = rendererDropDownList.SelectedItem.ToString();
			WindowsColorSchemeType? colorSchemeType = (selectedColorSchemeTypeName == "Custom")
				? null
				: (WindowsColorSchemeType)Enum.Parse(typeof(WindowsColorSchemeType), selectedColorSchemeTypeName, ignoreCase: true);

			// Update the navigationbar renderer
			if (!colorSchemeType.HasValue) {
				navigationBar.Renderer = customNavigationBarRenderer;
			}
			else {
				switch (colorSchemeType.Value) {
					case WindowsColorSchemeType.MetroDark:
					case WindowsColorSchemeType.MetroLight:
					case WindowsColorSchemeType.VisualStudioBlue:
						navigationBar.Renderer = new MetroNavigationBarRenderer(colorSchemeType.Value);
						break;
					case WindowsColorSchemeType.OfficeClassicBlack:
					case WindowsColorSchemeType.OfficeClassicBlue:
					case WindowsColorSchemeType.OfficeClassicSilver:
						navigationBar.Renderer = new OfficeClassicNavigationBarRenderer(colorSchemeType.Value);
						break;
					default:
						navigationBar.Renderer = new OfficeLunaNavigationBarRenderer(colorSchemeType.Value);
						break;
				}
			}
			rendererPropertyGrid.SelectedObject = navigationBar.Renderer;

			// Sync up all panels
			allFoldersNavigationBarPanel.Renderer = navigationBar.Renderer;
			changeNavigationBarPanel.Renderer = navigationBar.Renderer;
			eventsNavigationBarPanel.Renderer = navigationBar.Renderer;

			// Update form background and tabstrip renderer
			var colorScheme = navigationBar.Renderer.ColorScheme;
			if (navigationBar.Renderer is MetroNavigationBarRenderer) {
				if (colorSchemeType.HasValue && colorSchemeType.Value == WindowsColorSchemeType.VisualStudioBlue)
					tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioToolWindowTabStripRenderer(colorScheme) {  AreImagesVisible = true };
				else
					tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroToolWindowTabStripRenderer(colorScheme) {  AreImagesVisible = true };
			}
			else if (navigationBar.Renderer is OfficeLunaNavigationBarRenderer) {
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(colorScheme) { AreImagesVisible = true };
			}
			else {
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicToolWindowTabStripRenderer() { AreImagesVisible = true };
			}

			// Customize key controls based on color scheme to render better in light/dark themes
			ThemeHelper.ApplyComponentColors(this, colorScheme, recurseChildren: true);

			// Force the back color of this sample to match the theme instead of generic "control" control
			this.BackColor = (colorScheme.ColorSchemeType == WindowsColorSchemeType.VisualStudioBlue)
				? colorScheme.GetKnownColor(KnownColor.AppWorkspace)
				: colorScheme.FormBackGradientBegin;

			// Theme the splitters to match the background (transparent not supported)
			vSplitter.BackColor = this.BackColor;
			vSplitter2.BackColor = this.BackColor;
			hSplitter.BackColor = this.BackColor;

			// For this sample the panel will have a dark background and cannot have default control text foreground on these controls
			rendererLabel.ForeColor = preventSelectionChangesCheckBox.ForeColor = (colorSchemeType == WindowsColorSchemeType.OfficeClassicBlack)
				? Color.White
				: colorScheme.GetKnownColor(KnownColor.ControlText);
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
