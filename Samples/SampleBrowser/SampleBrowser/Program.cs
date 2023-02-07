#if DEBUG && MS_LOGGING
using ActiproSoftware.SampleBrowser.Logging;
using Microsoft.Extensions.Logging;
using LoggerFactory = ActiproSoftware.Products.Logging.LoggerFactory;
#endif

using ActiproSoftware.Products.Logging;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Contains the main entry point for the application.
	/// </summary>
	static class Program {

		private const string OnlineDocumentationUrl = "https://www.actiprosoftware.com/docs/controls/winforms/index";

		private static Logger logger;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			// Configure logging
			#if DEBUG && MS_LOGGING
			LoggerFactoryAdapter.Configure(builder => {
				builder.AddFilter("ActiproSoftware", Microsoft.Extensions.Logging.LogLevel.Warning);
				builder.AddDebugLogger();
			});
			#endif
			logger = LoggerFactory.DefaultInstance.CreateLogger(typeof(Program));

			InitializeSyntaxEditor();

			Application.ApplicationExit += OnApplicationApplicationExit;

			Application.EnableVisualStyles();

			#if NETCOREAPP
			// DpiAwareness in WinForms is a mixed experience but one that is improving with newer releases of .NET, especially
			// beginning with .NET 6.  While Actipro WinForms controls support per-monitor DPI awareness (PerMonitorV2), the
			// Sample Browser itself is not optimized for per-monitor DPI since the project must run consistently across multiple
			// .NET targets where each framework can exhibit slightly different behavior with automatic scaling of controls.
			//
			// "HighDpiMode.SystemAware" will scale controls based on the DPI of the primary monitor and is a highly consistent
			// experience when all monitors have the same DPI, but the operating system will perform bitmap scaling of the UI,
			// as appropriate, when displayed on a monitor whose DPI does not match the system DPI.
			//
			// The Sample Browser project can be changed to "HighDpiMode.PerMonitorV2" to evaluate the individual controls,
			// but some scaling issues may be present with the environment that hosts the controls for demonstration.
			//
			// NOTE: This method call is for .NET Core or .NET 5+ only.  To change DpiAwareness for .NET Framework, change the
			// "DpiAwareness" in "app.config".
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			#endif

			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new RootForm());

		}

		/// <summary>
		/// Performs various SyntaxEditor parser and add-on initializations.
		/// </summary>
		private static void InitializeSyntaxEditor() {
			logger?.LogInformation("Configuring SyntaxEditor ...");

			// If using SyntaxEditor with languages that support syntax/semantic parsing, use this line at
			//   app startup to ensure that worker threads are used to perform the parsing
			ActiproSoftware.Text.Parsing.AmbientParseRequestDispatcherProvider.Dispatcher =
				new ActiproSoftware.Text.Parsing.Implementation.ThreadedParseRequestDispatcher();
			logger?.LogDebug("AmbientParseRequestDispatcherProvider.Dispatcher = {0}", ActiproSoftware.Text.Parsing.AmbientParseRequestDispatcherProvider.Dispatcher?.GetType().FullName ?? "NULL");

			// Create SyntaxEditor .NET Languages Add-on ambient assembly repository, which supports caching of 
			//   reflection data and improves performance for the add-on...
			//   Be sure to replace the appDataPath with a proper path for your own application (if file access is allowed)
			var appDataPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
				"Actipro Software"), "WinForms SampleBrowser Assembly Repository");
			ActiproSoftware.Text.Languages.DotNet.Reflection.AmbientAssemblyRepositoryProvider.Repository =
				new ActiproSoftware.Text.Languages.DotNet.Reflection.Implementation.FileBasedAssemblyRepository(appDataPath);
			logger?.LogDebug(".NET Reflection Repository Path = {0}", appDataPath);

			// Create SyntaxEditor Python Languages Add-on ambient package repository, which supports caching of 
			//   reflection data... Be sure to replace the appDataPath with a proper path for your own application (if file access is allowed)
			appDataPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
				"Actipro Software"), "WinForms SampleBrowser Python Package Repository");
			ActiproSoftware.Text.Languages.Python.Reflection.AmbientPackageRepositoryProvider.Repository = 
				new ActiproSoftware.Text.Languages.Python.Reflection.Implementation.FileBasedPackageRepository(appDataPath);
			logger?.LogDebug("Python Package Repository Path = {0}", appDataPath);
		}

		/// <summary>
		/// Occurs when the application exits.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>EventArgs</c> that contains data related to this event.</param>
		private static void OnApplicationApplicationExit(object sender, EventArgs e) {
			// Shut down the SyntaxEditor ambient parse request dispatcher
			var dispatcher = ActiproSoftware.Text.Parsing.AmbientParseRequestDispatcherProvider.Dispatcher;
			if (dispatcher != null) {
				ActiproSoftware.Text.Parsing.AmbientParseRequestDispatcherProvider.Dispatcher = null;
				dispatcher.Dispose();
			}

			// Prune any SyntaxEditor .NET Languages Add-on cache data that is no longer valid
			var repository = ActiproSoftware.Text.Languages.DotNet.Reflection.AmbientAssemblyRepositoryProvider.Repository;
			if (repository != null)
				repository.PruneCache();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets if the current .NET run-time automatically handles the scaling of most control fonts.
		/// </summary>
		/// <value>
		/// <c>true</c> if the .NET run-time automatically handles the scaling of most control fonts;
		/// otherwise, <c>false</c> if manual scaling of some control fonts is necessary.
		/// </value>
		/// <remarks>For use with per-monitor DPI awareness.</remarks>
		/// <seealso cref="ActiproSoftware.UI.WinForms.Drawing.DpiHelper.RescaleFont(System.Drawing.Font, System.Drawing.SizeF, System.Drawing.SizeF)"/>
		public static bool IsControlFontScalingHandledByRuntime {
			get {
				// Most controls inherit the font of their parent, but some controls will often
				// define a different font. For instance, a "header label" might use a larger
				// font than normal or apply bold style.
				//
				// .NET Framework 4.8 and .NET Core consistently scale the fonts of controls
				// which define their own fonts, but .NET Framework 4.7.2 (and presumably
				// earlier versions) do not scale those fonts and manually scaling the font
				// is required for a consistent appearance at different DPI levels.
				#if NET48_OR_GREATER || NETCOREAPP
				return true;
				#else
				return false;
				#endif
			}
		}

		/// <summary>
		/// Gets if the current .NET run-time automatically handles the scaling of most control sizes.
		/// </summary>
		/// <value>
		/// <c>true</c> if the .NET run-time automatically handles the scaling of most control sizes;
		/// otherwise, <c>false</c> if manual scaling of some control sizes is necessary.
		/// </value>
		/// <remarks>For use with per-monitor DPI awareness.</remarks>
		/// <seealso cref="ActiproSoftware.UI.WinForms.Drawing.DpiHelper.RescaleSize(System.Drawing.Size, int, int)"/>
		public static bool IsControlSizeScalingHandledByRuntime {
			// .NET 6 started consistently scaling the size of controls with changes in DPI
			#if NET6_0_OR_GREATER
			get => true;
			#else
			get => false;
			#endif
		}

		/// <summary>
		/// Launches the default browser and navigates to the specified URL.
		/// </summary>
		/// <param name="url">The URL.</param>
		public static void LaunchExternalBrowser(string url) {
			if (string.IsNullOrWhiteSpace(url))
				return;
			logger?.LogDebug("Launch external browser :: {0}", url);
			if ((url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)) || (url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)))
				ShellExecute(url);
		}

		/// <summary>
		/// Launches the product's help file.
		/// </summary>
		public static void LaunchProductHelp() {
			// Try and find the documentation location in the registry
			string path = null;

			var version = ActiproSoftware.Products.Shared.AssemblyInfo.Instance.GetAssemblyVersion();
			var regKeyName = String.Format(@"SOFTWARE\Actipro Software\WinForms Controls\{0}.{1}\Installed", version.Major, version.Minor);
			var regKey = Registry.LocalMachine.OpenSubKey(regKeyName);
			if (regKey == null) {
				regKeyName = regKeyName.Replace(@"SOFTWARE\", @"SOFTWARE\WOW6432Node\");
				regKey = Registry.LocalMachine.OpenSubKey(regKeyName);
			}
			if (regKey != null) {
				path = regKey.GetValue("Path") as string;
				if (path != null)
					path = Path.Combine(path, @"Documentation\index.html");
				regKey.Close();
			}

			if (File.Exists(path)) {
				try {
					// Open the documentation
					ShellExecute(path);
				}
				catch (Exception ex) {
					MessageBox.Show(String.Format(CultureInfo.CurrentCulture, "The documentation file '{0}' was unable to be opened.  The error message was: {1}", path, ex.Message),
						"Documentation Not Opened", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else {
				// Open online documentation
				LaunchExternalBrowser(String.Format(@"{0}?v={1}.{2}", OnlineDocumentationUrl, version.Major, version.Minor));
			}
		}

		/// <summary>
		/// Uses the Windows shell to execute the given file name.
		/// </summary>
		/// <param name="fileName">The file name to execute.</param>
		public static System.Diagnostics.Process ShellExecute(string fileName) {
			logger?.LogDebug("ShellExecute :: {0}", fileName);
			return System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
				FileName = fileName,
				UseShellExecute = true
			});
		}

	}

}
