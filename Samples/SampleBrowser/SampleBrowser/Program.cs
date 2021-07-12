using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Contains the main entry point for the application.
	/// </summary>
	static class Program {

		private const string OnlineDocumentationUrl = "https://www.actiprosoftware.com/docs/controls/winforms/index";
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {

			InitializeSyntaxEditor();

			Application.ApplicationExit += OnApplicationApplicationExit;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new RootForm());

		}

		/// <summary>
		/// Performs various SyntaxEditor parser and add-on initializations.
		/// </summary>
		private static void InitializeSyntaxEditor() {
			// If using SyntaxEditor with languages that support syntax/semantic parsing, use this line at
			//   app startup to ensure that worker threads are used to perform the parsing
			ActiproSoftware.Text.Parsing.AmbientParseRequestDispatcherProvider.Dispatcher =
				new ActiproSoftware.Text.Parsing.Implementation.ThreadedParseRequestDispatcher();

			// Create SyntaxEditor .NET Languages Add-on ambient assembly repository, which supports caching of 
			//   reflection data and improves performance for the add-on...
			//   Be sure to replace the appDataPath with a proper path for your own application (if file access is allowed)
			var appDataPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
				"Actipro Software"), "WinForms SampleBrowser Assembly Repository");
			ActiproSoftware.Text.Languages.DotNet.Reflection.AmbientAssemblyRepositoryProvider.Repository =
				new ActiproSoftware.Text.Languages.DotNet.Reflection.Implementation.FileBasedAssemblyRepository(appDataPath);
			
			// Create SyntaxEditor Python Languages Add-on ambient pacakge repository, which supports caching of 
			//   reflection data... Be sure to replace the appDataPath with a proper path for your own application (if file access is allowed)
			appDataPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
				"Actipro Software"), "WinForms SampleBrowser Python Package Repository");
			ActiproSoftware.Text.Languages.Python.Reflection.AmbientPackageRepositoryProvider.Repository = 
				new ActiproSoftware.Text.Languages.Python.Reflection.Implementation.FileBasedPackageRepository(appDataPath);
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
		/// Launches the default browser and navigates to the specified URL.
		/// </summary>
		/// <param name="url">The URL.</param>
		public static void LaunchExternalBrowser(string url) {
			if (string.IsNullOrWhiteSpace(url))
				return;
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
			return System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
				FileName = fileName,
				UseShellExecute = true
			});
		}

	}

}
