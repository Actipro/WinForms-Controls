using ActiproSoftware.SampleBrowser.Controls;
using ActiproSoftware.UI.WinForms.Controls.Navigation;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Reflection;

namespace ActiproSoftware.ProductSamples.NavigationSamples.Demo.Features;

/// <summary>
/// A sample to test the <c>NavigationBar</c> control.
/// </summary>
public partial class MainControl : UserControl {

	private readonly INavigationBarRenderer? _customNavigationBarRenderer;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		// Store the current renderer from the designer as the custom renderer
		_customNavigationBarRenderer = navigationBar.Renderer;

		// Populate the drop-down list
		foreach (var fieldInfo in typeof(WindowsColorSchemeType).GetFields()
			.Where(x => x.IsLiteral)
			.OrderBy(x => x.Name)) {

			// Ignore items that are not browsable
			if ((fieldInfo.GetCustomAttribute<EditorBrowsableAttribute>()?.State ?? EditorBrowsableState.Always) == EditorBrowsableState.Never)
				continue;

			var name = fieldInfo.Name;

			// Ignore special "WindowsDefault" that just resolves as one of the other types
			if (((WindowsColorSchemeType)fieldInfo.GetValue(fieldInfo.Name)!) == WindowsColorSchemeType.WindowsDefault)
				continue;

			rendererDropDownList.Items.Add(name);
		}
		rendererDropDownList.Items.Add("Custom");

		// Pre-select the type that is the current windows default
		rendererDropDownList.SelectedIndex = rendererDropDownList.Items.IndexOf(WindowsColorScheme.DefaultColorSchemeType.ToString());

		// Expand all nodes
		mailTreeView.ExpandAll();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Logs an event in the events listbox.
	/// </summary>
	/// <param name="eventMessage">The event message to log.</param>
	private void LogEvent(string eventMessage) {
		if (!string.IsNullOrWhiteSpace(eventMessage))
			eventsListBox.SelectedIndex = eventsListBox.Items.Add(eventMessage);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnLoadLayoutButtonClick(object sender, EventArgs e) {
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
	/// <param name="e">The event data.</param>
	private void OnNavigationBarContextMenuRequested(object sender, ActiproSoftware.UI.WinForms.Controls.Navigation.NavigationBarContextMenuEventArgs e) {
		// No operation, but log the event
		if (e.NavigationPane is { } pane) {
			LogEvent(string.Format("{0}: Source={1}; Index={2}; Text={3}; ButtonLocation={4}; Cancelled={5}",
				nameof(NavigationBar.ContextMenuRequested),
				e.Source,
				navigationBar.Panes.IndexOf(pane),
				pane.Text,
				pane.ButtonLocation, e.Cancel
			));
		}
		else {
			LogEvent(string.Format("{0}: Source={1}; Cancelled={2}", nameof(NavigationBar.ContextMenuRequested), e.Source, e.Cancel));
		}
	}

	/// <summary>
	/// Occurs when the value of the MaximumBarButtonCount has changed.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnNavigationBarMaximumBarButtonCountChanged(object sender, EventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(NavigationBar.MaximumBarButtonCountChanged));
	}

	/// <summary>
	/// Occurs before the <see cref="NavigationPane.Active"/> property on a <see cref="NavigationPane"/> changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnNavigationBarNavigationPaneActiveChanging(object sender, NavigationPaneCancelEventArgs e) {
		// No operation, but log the event
		LogEvent(string.Format("{0}: Index={1}; Text={2}; Cancelled={3}",
			nameof(NavigationBar.NavigationPaneActiveChanging),
			navigationBar.Panes.IndexOf(e.NavigationPane!),
			e.NavigationPane?.Text,
			e.Cancel
		));
	}

	/// <summary>
	/// Occurs when the panes are reordered via the Navigation Bar Options dialog.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnNavigationBarNavigationPanesReordered(object sender, EventArgs e) {
		// No operation, but log the event
		LogEvent(nameof(NavigationBar.NavigationPanesReordered));
	}

	/// <summary>
	/// Occurs after the selection changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnNavigationBarSelectionChanged(object sender, EventArgs e) {
		LogEvent(string.Format("{0}: Index={1}; Text={2}",
			nameof(NavigationBar.SelectionChanged),
			navigationBar.SelectedIndex,
			navigationBar.SelectedPane?.Text ?? "<null>"
		));
	}

	/// <summary>
	/// Occurs before the selection changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnNavigationBarSelectionChanging(object sender, NavigationPaneCancelEventArgs e) {
		// Optionally cancel the selection change
		e.Cancel = preventSelectionChangesCheckBox.Checked;

		LogEvent(string.Format("{0}: Index={1}; Text={2}, Cancelled={3}",
			nameof(NavigationBar.SelectionChanging),
			navigationBar.SelectedIndex,
			navigationBar.SelectedPane?.Text ?? "<null>",
			e.Cancel
		));
	}

	/// <summary>
	/// Occurs after the selection changes.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnRendererDropDownListSelectedIndexChanged(object sender, EventArgs e) {
		// Determine the selected color scheme type
		var selectedColorSchemeTypeName = rendererDropDownList.SelectedItem?.ToString() ?? string.Empty;

		// Update the NavigationBar renderer
		if (!Enum.TryParse<WindowsColorSchemeType>(selectedColorSchemeTypeName, out var colorSchemeType)) {
			navigationBar.Renderer = _customNavigationBarRenderer;
		}
		else {
			switch (colorSchemeType) {
				case WindowsColorSchemeType.MetroDark:
				case WindowsColorSchemeType.MetroLight:
				case WindowsColorSchemeType.VisualStudioBlue:
					navigationBar.Renderer = new MetroNavigationBarRenderer(colorSchemeType);
					break;
				case WindowsColorSchemeType.OfficeClassicBlack:
				case WindowsColorSchemeType.OfficeClassicBlue:
				case WindowsColorSchemeType.OfficeClassicSilver:
					navigationBar.Renderer = new OfficeClassicNavigationBarRenderer(colorSchemeType);
					break;
				default:
					navigationBar.Renderer = new OfficeLunaNavigationBarRenderer(colorSchemeType);
					break;
			}
		}
		rendererPropertyGrid.SelectedObject = navigationBar.Renderer;

		// Sync up all panels
		allFoldersNavigationBarPanel.Renderer = navigationBar.Renderer;
		changeNavigationBarPanel.Renderer = navigationBar.Renderer;
		eventsNavigationBarPanel.Renderer = navigationBar.Renderer;

		// Update form background and tabstrip renderer
		var colorScheme = navigationBar.Renderer!.ColorScheme;
		if (navigationBar.Renderer is MetroNavigationBarRenderer) {
			if (colorSchemeType == WindowsColorSchemeType.VisualStudioBlue)
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioToolWindowTabStripRenderer(colorScheme) { AreImagesVisible = true };
			else
				tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.MetroToolWindowTabStripRenderer(colorScheme) { AreImagesVisible = true };
		}
		else if (navigationBar.Renderer is OfficeLunaNavigationBarRenderer)
			tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.OfficeClassicToolWindowTabStripRenderer(colorScheme) { AreImagesVisible = true };
		else
			tabStrip.Renderer = new ActiproSoftware.UI.WinForms.Controls.Docking.VisualStudioClassicToolWindowTabStripRenderer() { AreImagesVisible = true };

		// Customize key controls based on color scheme to render better in light/dark themes
		ThemeHelper.ApplyComponentColors(this, colorScheme, recurseChildren: true);

		// Force the back color of this sample to match the theme instead of generic "control" control
		BackColor = (colorScheme.ColorSchemeType == WindowsColorSchemeType.VisualStudioBlue)
			? colorScheme.GetKnownColor(KnownColor.AppWorkspace)
			: colorScheme.FormBackGradientBegin;

		// Theme the splitters to match the background (transparent not supported)
		vSplitter.BackColor = BackColor;
		vSplitter2.BackColor = BackColor;
		hSplitter.BackColor = BackColor;

		// For this sample the panel will have a dark background and cannot have default control text foreground on these controls
		rendererLabel.ForeColor = preventSelectionChangesCheckBox.ForeColor = (colorSchemeType == WindowsColorSchemeType.OfficeClassicBlack)
			? Color.White
			: colorScheme.GetKnownColor(KnownColor.ControlText);
	}

	/// <summary>
	/// Occurs when the button is clicked.
	/// </summary>
	/// <param name="sender">Sender of the event.</param>
	/// <param name="e">The event data.</param>
	private void OnSaveLayoutButtonClick(object sender, EventArgs e) {
		// Show the dialog
		saveFileDialog.Filter = "XML NavigationBar Layout Files (*.xml)|*.xml";
		saveFileDialog.FileName = "NavBarLayout.xml";
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			return;

		// Save the layout
		navigationBar.SaveLayoutToFile(saveFileDialog.FileName);
	}

}
