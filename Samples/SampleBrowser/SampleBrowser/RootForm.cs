using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// The root application form.
	/// </summary>
	public partial class RootForm : Form {

		private int currentNavigationListBoxSelectedIndex = -1;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NESTED TYPES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		#region CustomToolStripRenderer

		/// <summary>
		/// Renders a <see cref="ToolStrip"/> with a custom appearance.
		/// </summary>
		private class CustomToolStripRenderer : ToolStripProfessionalRenderer {
			
			/////////////////////////////////////////////////////////////////////////////////////////////////////
			// PUBLIC PROCEDURES
			/////////////////////////////////////////////////////////////////////////////////////////////////////
		
			/// <summary>
			/// Renders the background.
			/// </summary>
			/// <param name="e">The <c>ToolStripRenderEventArgs</c> that contains data related to the event.</param>
			protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) {
				SolidColorBackgroundFill.Draw(e.Graphics, e.AffectedBounds, UIColor.FromMix(SystemColors.Window, SystemColors.Control, 0.5f).ToColor());
			}

			/// <summary>
			/// Renders the border.
			/// </summary>
			/// <param name="e">The <c>ToolStripRenderEventArgs</c> that contains data related to the event.</param>
			protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
				SimpleBorder.Draw(e.Graphics, e.AffectedBounds, SimpleBorderStyle.Solid, SystemColors.ControlLight, Sides.Top | Sides.Bottom);
			}

		}

		#endregion

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>RootForm</c> class.
		/// </summary>
		public RootForm() {
			InitializeComponent();

			this.InitializeNavigation();
			this.InitializeSplitters();
			this.InitializeStatusBar();
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Clear the content host.
		/// </summary>
		private void ClearContentHost() {
			if (contentHostPanel.Controls.Count > 0) {
				// Notify samples that they are being unloaded when needed
				var sample = contentHostPanel.Controls[0] as IProductSample;
				if (sample != null)
					sample.NotifyUnloaded();

				contentHostPanel.Controls.Clear();
			}

	
			this.UpdatePrimaryStatus("Ready");
		}

		/// <summary>
		/// Initializes the navigation.
		/// </summary>
		private void InitializeNavigation() {
			navigationListBox.SelectedIndexChanged += this.OnNavigationListBoxSelectedIndexChanged;

			var data = ProductData.Instance;
			foreach (var familyInfo in data.ProductFamilies) {
				navigationListBox.Items.Add(familyInfo);

				foreach (var group in familyInfo.GroupedItems) {
					var groupNode = new TreeNode(group.Key);

					foreach (var itemInfo in group)
						navigationListBox.Items.Add(itemInfo);
				}
			}

			// Select the first node
			if (navigationListBox.Items.Count > 0)
				navigationListBox.SelectedIndex = 0;

			// Use a custom toolstrip renderer
			navigationToolStrip.Renderer = new CustomToolStripRenderer();

			// Set menu images
			navigateToBarsMenuItem.Image = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetImage("ProductBars16.png");
			navigateToDockingMenuItem.Image = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetImage("ProductDocking16.png");
			navigateToNavigationMenuItem.Image = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetImage("ProductNavigation16.png");
			navigateToSyntaxEditorMenuItem.Image = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetImage("ProductSyntaxEditor16.png");
			navigateToWizardMenuItem.Image = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetImage("ProductWizard16.png");
		}

		/// <summary>
		/// Initializes the splitters.
		/// </summary>
		private void InitializeSplitters() {
			var color = UIColor.FromMix(SystemColors.Control, SystemColors.ControlDark, 0.2f).ToColor();
			titleSplitter.BackColor = color;
			navigationSplitter.BackColor = color;
		}

		/// <summary>
		/// Initializes the status bar.
		/// </summary>
		private void InitializeStatusBar() {
			statusStrip.BackColor = Color.FromArgb(0xff, 0x00, 0x7a, 0xcc);
			statusStrip.ForeColor = Color.White;

			versionStatusLabel.Text = String.Format("{0} on {1}", this.ProductVersionText, this.BuildDateText);
		}

		/// <summary>
		/// Loads a browser with a URL.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <param name="relatedInfo">The related <see cref="ProductFamilyInfo"/> or <see cref="ProductItemInfo"/>.</param>
		private void LoadBrowser(string url, object relatedInfo) {
			// Create the browser
			var browser = new BrowserControl();
			browser.Dock = DockStyle.Fill;
			contentHostPanel.Controls.Add(browser);

			// Resolve relative paths
			if (url.StartsWith("/", StringComparison.Ordinal)) {
				var appPath = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase).LocalPath;
				url = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(appPath), @"..\..\.." + url));
			}

			// Navigate
			browser.Navigate(url, relatedInfo);
		}
		
		/// <summary>
		/// Loads a user control sample.
		/// </summary>
		/// <param name="type">The control type.</param>
		private void LoadUserControl(Type type) {
			var userControl = Activator.CreateInstance(type) as UserControl;
			userControl.Dock = DockStyle.Fill;
			contentHostPanel.Controls.Add(userControl);

			// Notify samples that they are being loaded when needed
			var sample = userControl as IProductSample;
			if (sample != null)
				sample.NotifyLoaded();
		}

		/// <summary>
		/// Navigates to the next item.
		/// </summary>
		private void NavigateToNext() {
			var next = ProductData.Instance.GetNext(navigationListBox.SelectedItem);
			navigationListBox.SelectedItem = next;
		}
		
		/// <summary>
		/// Navigates to the previous item.
		/// </summary>
		private void NavigateToPrevious() {
			var previous = ProductData.Instance.GetPrevious(navigationListBox.SelectedItem);
			navigationListBox.SelectedItem = previous;
		}

		/// <summary>
		/// Navigates to a product family.
		/// </summary>
		/// <param name="familyInfo">The <see cref="ProductFamilyInfo"/> to examine.</param>
		private void NavigateToProductFamily(ProductFamilyInfo familyInfo) {
			this.ClearContentHost();

			contentHeaderLabel.Text = familyInfo.Title;

			this.UpdatePrimaryStatus("Copyright \u00A9 2002-2021 Actipro Software LLC");

			if (familyInfo.Path.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
				this.LoadBrowser(familyInfo.Path, familyInfo);
		}
		
		/// <summary>
		/// Navigates to a product item.
		/// </summary>
		/// <param name="itemInfo">The <see cref="ProductItemInfo"/> to examine.</param>
		private void NavigateToProductItem(ProductItemInfo itemInfo) {
			this.ClearContentHost();

			contentHeaderLabel.Text = itemInfo.Title;

			var path = itemInfo.Path;
			this.UpdatePrimaryStatus(path);

			Type type = null;
			if (path.EndsWith("/", StringComparison.Ordinal)) {
				var typeNameBase = "ActiproSoftware" + path.Replace('/', '.');
				var typeName = typeNameBase + "MainForm";
				type = typeof(RootForm).Assembly.GetType(typeName, false, true);
				if (type != null) {
					// Show a launcher page for a sample with MainForm
					path = "/SampleBrowser/Documents/SampleLauncher.html";
				}
				else {
					// Get the MainControl
					typeName = typeNameBase + "MainControl";
					type = typeof(RootForm).Assembly.GetType(typeName, false, true);
				}
			}

			try {
				if (path.EndsWith(".html", StringComparison.OrdinalIgnoreCase)) {
					// Load a web page
					this.LoadBrowser(path, itemInfo);
					return;
				}
				else if (type != null) {
					// Load MainControl
					this.LoadUserControl(type);
					return;
				}
			}
			catch {}

			// Load an error web page
			this.LoadBrowser("/SampleBrowser/Documents/SampleError.html", null);
		}
		
		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnIntroductionToolStripButtonClick(object sender, EventArgs e) {
			this.NavigateToProductFamily(ProductData.Instance.ProductFamilies[0]);
		}

		/// <summary>
		/// Occurs when the navigation selection changes.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnNavigationListBoxSelectedIndexChanged(object sender, EventArgs e) {
			// Quit if no change
			var newSelectedIndex = navigationListBox.SelectedIndex;
			if (currentNavigationListBoxSelectedIndex == newSelectedIndex)
				return;

			currentNavigationListBoxSelectedIndex = newSelectedIndex;

			var itemInfo = navigationListBox.SelectedItem as ProductItemInfo;
			if (itemInfo != null)
				this.NavigateToProductItem(itemInfo);
			else {
				var familyInfo = navigationListBox.SelectedItem as ProductFamilyInfo;
				if (familyInfo != null)
					this.NavigateToProductFamily(familyInfo);
			}
		}
		
		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnNavigateToMenuItemClick(object sender, EventArgs e) {
			var menuItem = (ToolStripMenuItem)sender;
			var path = menuItem.Tag as string;
			var target = ProductData.Instance.GetByPath(path);
			navigationListBox.SelectedItem = target;
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnNextToolStripButtonClick(object sender, EventArgs e) {
			this.NavigateToNext();
		}
		
		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnOpenDocumentationMenuItemClick(object sender, EventArgs e) {
			Program.LaunchProductHelp();
		}

		/// <summary>
		/// Occurs when the menu item is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnOpenSampleProjectMenuItemClick(object sender, EventArgs e) {
			var appPath = Assembly.GetExecutingAssembly().Location;
			var path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(appPath), @".\..\..\..\SampleApplication-CSharp.sln"));
			if (File.Exists(path)) {
				// Open the solution
				Program.ShellExecute(path);
			}
			else
				MessageBox.Show("The solution was not found at '" + path + "'.  Please access it from your Windows Programs menu's group for this product instead.", "Solution Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnPreviousToolStripButtonClick(object sender, EventArgs e) {
			this.NavigateToPrevious();
		}

		/// <summary>
		/// Updates the primary status.
		/// </summary>
		/// <param name="message">The message.</param>
		private void UpdatePrimaryStatus(string message) {
			primaryStatusLabel.Text = message ?? "Ready";
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Gets the build date text.
		/// </summary>
		/// <value>The build date text.</value>
		public string BuildDateText {
			get {
				// Try to get the attribute
				var attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
				if (attr != null) {
					var index = attr.InformationalVersion.IndexOf(" - ");
					if (index != -1) {
						index += 3;
						return new DateTime(
							Convert.ToInt32(attr.InformationalVersion.Substring(index, 4)),
							Convert.ToInt32(attr.InformationalVersion.Substring(index + 4, 2)),
							Convert.ToInt32(attr.InformationalVersion.Substring(index + 6, 2))
							).ToShortDateString();
					}
				}
				
				return "(Unknown)";
			}
		}
		
		/// <summary>
		/// Navigates to a URL.
		/// </summary>
		public void NavigateToUrl(string url) {
			const string SamplePrefix = "sample://";
			if (url.StartsWith(SamplePrefix, StringComparison.OrdinalIgnoreCase)) {
				var path = url.Substring(SamplePrefix.Length);
				if (!path.StartsWith("/", StringComparison.Ordinal))
					path = "/" + path;

				var target = ProductData.Instance.GetByPath(path);
				navigationListBox.SelectedItem = target;
			}
		}
		
		/// <summary>
		/// Opens a form sample.
		/// </summary>
		public void OpenForm(string url) {
			const string OpenPrefix = "open://";
			if (url.StartsWith(OpenPrefix, StringComparison.OrdinalIgnoreCase)) {
				var path = url.Substring(OpenPrefix.Length);
				if (!path.StartsWith("/", StringComparison.Ordinal))
					path = "/" + path;

				var typeNameBase = "ActiproSoftware" + path.Replace('/', '.');
				var typeName = typeNameBase + "MainForm";
				var type = typeof(RootForm).Assembly.GetType(typeName, false, true);

				// Try to open MainForm
				var form = Activator.CreateInstance(type) as Form;
				if (form != null) {
					form.StartPosition = FormStartPosition.CenterScreen;
					form.Show(this);
				}
			}
		}

		/// <summary>
		/// Gets the product version text.
		/// </summary>
		/// <value>The product version text.</value>
		public string ProductVersionText {
			get {
				return "v" + ActiproSoftware.Products.Shared.AssemblyInfo.Instance.Version;
			}
		}

	}
}
