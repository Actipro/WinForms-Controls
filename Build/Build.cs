using Microsoft.Win32;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using System;
using System.Linq;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

namespace ActiproSoftware.Tools.Builds {

	public partial class Build : NukeBuild {

		#region Parameters

		[Parameter("Configuration to build ('Debug' or 'Release')")]
		readonly Configuration Configuration = Configuration.Debug;

		[Secret]
		[Parameter("The license key to use")]
		readonly string LicenseKey = null;

		#endregion

		#region Solutions

		[Solution("Samples/SampleBrowser/SampleBrowser.sln")]
		readonly Solution SampleBrowserSolution;

		Solution[] SampleSolutions => new Solution[] { SampleBrowserSolution };  // MSBuild

		#endregion

		#region Core Build

		public Build() {
			NoLogo = true;
		}

		static int Main() {
			return Execute<Build>(b => b.IntegrationBuild);
		}

		#endregion

		#region Primary Targets

		Target IntegrationBuild => _ => _
			.DependsOn(Compile)
			.Executes();

		#endregion

		#region Licensing

		Target InstallLicense => _ => _
			.Unlisted()
			.Executes(() => {

				if ((!string.IsNullOrEmpty(LicenseKey)) && (LicenseKey.Length > 6)) {
					var majorVersion = int.Parse(LicenseKey.Substring(3, 2));
					var minorVersion = int.Parse(LicenseKey.Substring(5, 1));

					using (var key = Registry.LocalMachine.CreateSubKey($@"SOFTWARE\Actipro Software\WinForms Controls\{majorVersion}.{minorVersion}")) {
						key.SetValue("Licensee", "Actipro Customer");
						key.SetValue("LicenseKey", LicenseKey);
					}

					Logger.Normal("License key installed.");
				}
				else
					Logger.Normal("No license key installed.");

			});

		#endregion

		#region Compile Targets

		Target CompileSampleProjects => _ => _
			.Unlisted()
			.DependsOn(InstallLicense)
			.Executes(() => {

				foreach (var solution in SampleSolutions) {
					var project = solution.AllProjects.FirstOrDefault(p => (string.Compare(p.Name, solution.Name, StringComparison.OrdinalIgnoreCase) == 0));
					project.NotNull($"No project with name '{solution.Name}' found.");

					MSBuild(_ => _
						.SetProjectFile(project)
						.SetRestore(true)
						.SetConfiguration(Configuration)
						.SetVerbosity(MSBuildVerbosity.Minimal)
						.SetMaxCpuCount(Environment.ProcessorCount)
						.SetProperty("BuildInParallel", "true")
					);
					Logger.Normal();
				}

			});

		Target Compile => _ => _
			.Unlisted()
			.DependsOn(CompileSampleProjects)
			.Executes();

		#endregion

	}

}
