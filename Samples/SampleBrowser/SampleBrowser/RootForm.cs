using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// The root application form.
	/// </summary>
	public partial class RootForm : Form {

		private int currentNavigationListBoxSelectedIndex = -1;
		private const string ReadyText = "Ready";

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
			this.MinimumSize = new System.Drawing.Size(931, 686);

			// Respond to clicks on the version label for displaying diagnostic information
			versionStatusLabel.Click += this.OnVersionStatusLabelClick;

			// Configure font and auto-scale after initialization for best scaling experience
			this.Font = new Font("Segoe UI", 9F);
			this.AutoScaleDimensions = new SizeF(96F, 96F);
			this.AutoScaleMode = AutoScaleMode.Dpi;

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
	
			this.UpdatePrimaryStatus(ReadyText);
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
				url = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(appPath), @"..\..\.." + url));
			}

			// Navigate
			browser.Navigate(url, relatedInfo);
		}
		
		/// <summary>
		/// Loads a user control sample.
		/// </summary>
		/// <param name="type">The control type.</param>
		private void LoadUserControl(Type type) {
			var userControl = (UserControl)Activator.CreateInstance(type);
			userControl.SuspendLayout();
			userControl.Dock = DockStyle.Fill;

			if (DpiHelper.IsPerMonitorScalingRequired) {
				// This root form may have moved to a monitor with a different DPI than the system DPI, and that can
				// result in the default font being scaled. Descale the font back to the size for the system
				// DPI before adding to the root form or the user control may not scale correctly.
				var scaleFactor = DpiHelper.GetDeviceDpiChangeFactor(DpiHelper.GetSystemDeviceDpi(), DpiHelper.GetDeviceDpi(this));
				userControl.Font = DpiHelper.DescaleFont(this.Font, scaleFactor);
			}

			contentHostPanel.Controls.Add(userControl);
			userControl.ResumeLayout();

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

			this.UpdatePrimaryStatus("Copyright \u00A9 2002-2023 Actipro Software LLC");

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
			var path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(appPath), @".\..\..\..\SampleBrowser.sln"));
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
		/// Occurs when the status label is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to the event.</param>
		private void OnVersionStatusLabelClick(object sender, EventArgs e) {
			if (Control.ModifierKeys == Keys.Control) {
				// Generate diagnostic information to be displayed for debugging/support

				var sb = new StringBuilder();

				sb.AppendLine($"Runtime Framework: \t{System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");

				#if NETFRAMEWORK
				var targetFramework = Assembly.GetExecutingAssembly()
					.GetCustomAttributes<System.Runtime.Versioning.TargetFrameworkAttribute>()
					.SingleOrDefault()
					?.FrameworkDisplayName;
				if (!string.IsNullOrWhiteSpace(targetFramework))
					sb.AppendLine($"Target Framework:\t{targetFramework}");
				#endif

				sb.AppendLine($"DPI Awareness: \t\t{DpiHelper.GetDpiAwarenessDescription()}");
				sb.AppendLine($"Per-Monitor V2 DPI Aware: \t{DpiHelper.IsPerMonitorV2Aware}");
				sb.AppendLine($"Per-Monitor Scaling Req'd: \t{DpiHelper.IsPerMonitorScalingRequired}");
				sb.AppendLine($"Font Size: \t\t{this.Font.SizeInPoints}pt");
				sb.AppendLine($"Auto-Scale Mode: \t\t{this.AutoScaleMode} {this.AutoScaleDimensions}");

				sb.AppendLine($"Control DPI: \t\t{DpiHelper.GetDeviceDpi(this)} dpi @ {DpiHelper.GetDpiScale(this).Width * 100}%");
				sb.AppendLine($"System DPI: \t\t{DpiHelper.GetSystemDeviceDpi()} dpi @ {DpiHelper.GetSystemDpiScale().Width * 100}%");
				var screens = Screen.AllScreens;
				var currentScreen = Screen.FromControl(this);
				for (var i = 0; i < screens.Length; i++) {
					var screenDpi = DpiHelper.GetScreenDeviceDpi(screens[i]);
					sb.AppendLine($"Screen[{i}] DPI: \t\t{screenDpi} dpi @ {DpiHelper.GetDpiScale(screenDpi).Width * 100}%"
						+ (screens[i].Primary ? " (Primary)" : string.Empty)
						+ (screens[i].DeviceName == currentScreen?.DeviceName ? " (Current)" : String.Empty));
				}

				// Write to debug output
				Debug.WriteLine("**Diagnostic Information**\r\n" + sb.ToString());

				// Show details and optionally copy to clipboard
				if (DialogResult.Yes == MessageBox.Show(sb.ToString() + "\r\n\r\nCopy this information to the clipboard?", "Diagnostic Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
					Clipboard.SetText(sb.ToString());
			}
		}

		/// <summary>
		/// Updates the primary status.
		/// </summary>
		/// <param name="message">The message.</param>
		private void UpdatePrimaryStatus(string message) {
			primaryStatusLabel.Text = message ?? ReadyText;
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
		/// Occurs when the DPI of the device where the form is displayed changes.
		/// </summary>
		/// <param name="e">A <see cref="DpiChangedEventArgs" /> that contains the event data.</param>
		/// <remarks>This method should only be called when using per-monitor DPI awareness.</remarks>
		protected override void OnDpiChanged(DpiChangedEventArgs e) {
			base.OnDpiChanged(e);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale the font for the header label
				contentHeaderLabel.Font = DpiHelper.RescaleFont(contentHeaderLabel.Font, e.DeviceDpiOld, e.DeviceDpiNew);
			}

			// Allow loaded content to update layout
			if (contentHostPanel.Controls.Count > 0) {
				var contentControl = contentHostPanel.Controls[0];

				contentHostPanel.SuspendLayout();
				contentControl.SuspendLayout();

				// Remove/Add the control to force a layout update (Refresh/Invalidate had no effect)
				contentHostPanel.Controls.Remove(contentControl);
				contentHostPanel.Controls.Add(contentControl);

				contentControl.ResumeLayout();
				contentHostPanel.ResumeLayout();
			}

			// Perform layout to address issues with status bar not resizing
			this.PerformLayout();
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

					if (DpiHelper.IsPerMonitorScalingRequired) {
						form.StartPosition = FormStartPosition.CenterParent;

						#if !NET8_0_OR_GREATER
						// NOTE: This issue was fixed with .NET 8

						// This root form may have moved to a monitor with a different DPI than the system DPI, and that can
						// result in the default font being scaled. Descale the font back to the size for the system
						// DPI before assigning to the new form or the new form may not scale correctly.
						var scaleFactor = DpiHelper.GetDeviceDpiChangeFactor(DpiHelper.GetSystemDeviceDpi(), DpiHelper.GetDeviceDpi(this));
						form.Font = DpiHelper.DescaleFont(this.Font, scaleFactor);
						#endif

						// Show the form using special behavior to ensure proper DPI scaling
						DpiAwareFormShowBehavior.ApplyTo(form);
					}
					else {
						// FormStartPosition.CenterParent does not work reliably at non-standard DPI levels, so always manually
						// position the form to be centered on the parent.

						var formSize = form.Size;
						var targetBoundsForCenter = this.Bounds;

						form.StartPosition = FormStartPosition.Manual;
						form.Location = new Point(
							targetBoundsForCenter.Left + ((targetBoundsForCenter.Width - formSize.Width) / 2),
							targetBoundsForCenter.Top + ((targetBoundsForCenter.Height - formSize.Height) / 2));

					}

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
