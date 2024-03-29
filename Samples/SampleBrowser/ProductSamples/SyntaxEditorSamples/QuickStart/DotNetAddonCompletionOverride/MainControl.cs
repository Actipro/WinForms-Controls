﻿using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DotNetAddonCompletionOverride {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl, IProductSample {

		// A project assembly (similar to a Visual Studio project) contains source files and assembly references for reflection
		private IProjectAssembly projectAssembly;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher and an ambient
			//   code repository within your application OnStartup code, and add related cleanup in your
			//   application OnExit code.  These steps are essential to having the add-on perform well.
			//

			// Initialize the project assembly (enables support for automated IntelliPrompt features)
			projectAssembly = new CSharpProjectAssembly("SampleBrowser");
			var assemblyLoader = new BackgroundWorker();
			assemblyLoader.DoWork += DotNetProjectAssemblyReferenceLoader;
			assemblyLoader.RunWorkerAsync();

			// Load the .NET Languages Add-on C# language and register the project assembly on it
			var language = new CSharpSyntaxLanguage();
			language.RegisterProjectAssembly(projectAssembly);
			codeEditor.Document.Language = language;

			// Override the completion provider with a custom one
			language.RegisterService<CSharpCompletionProvider>(new CustomCSharpCompletionProvider());
		}

		private void DotNetProjectAssemblyReferenceLoader(object sender, DoWorkEventArgs e) {
			// Add some common assemblies for reflection (any custom assemblies could be added using various Add overloads instead)
			SyntaxEditorHelper.AddCommonDotNetSystemAssemblyReferences(projectAssembly);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Notifies the UI that it has been loaded.
		/// </summary>
		public void NotifyLoaded() { }

		/// <summary>
		/// Notifies the UI that it has been unloaded.
		/// </summary>
		public void NotifyUnloaded() {
			// Clear .NET Languages Add-on project assembly references when the sample unloads
			projectAssembly.AssemblyReferences.Clear();
		}

	}
}
