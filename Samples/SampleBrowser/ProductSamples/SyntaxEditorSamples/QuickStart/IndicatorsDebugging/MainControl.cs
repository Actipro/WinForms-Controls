using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet;
using ActiproSoftware.Text.Languages.DotNet.Reflection;
using ActiproSoftware.Text.Parsing;
using ActiproSoftware.Text.Parsing.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl, IProductSample {

		private TextSnapshotOffset currentStatementSnapshotOffset;

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

			// Register display item classification types (so breakpoint indicator styles are registered)
			new DisplayItemClassificationTypeProvider().RegisterAll();

			// Set the header/footer text to make the editor work as a method body
			editor.Document.SetHeaderAndFooterText("using System; using System.IO; private class Program { private void Execute() {\r\n", "\r\n}}");

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

			// Register an indicator quick info provider
			language.RegisterService(new IndicatorQuickInfoProvider());

			// Register an event sink that allows for handling of clicks in the indicator margin
			language.RegisterService(new DebuggingPointerInputEventSink());

			// Assign the language
			editor.Document.Language = language;
		}

		private void DotNetProjectAssemblyReferenceLoader(object sender, DoWorkEventArgs e) {
			// Add some common assemblies for reflection (any custom assemblies could be added using various Add overloads instead)
			SyntaxEditorHelper.AddCommonDotNetSystemAssemblyReferences(projectAssembly);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnClearBreakpointsToolStripButtonClick(object sender, EventArgs e) {
			// Clear breakpoints
			editor.Document.IndicatorManager.Breakpoints.Clear();

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnStartDebuggingToolStripButtonClick(object sender, EventArgs e) {
			// If starting debugging from a stopped state, begin looking at the document start
			if (currentStatementSnapshotOffset.IsDeleted)
				currentStatementSnapshotOffset = new TextSnapshotOffset(editor.ActiveView.CurrentSnapshot, 0);

			// Flag as debugging
			currentStatementSnapshotOffset = DebuggingHelper.SetCurrentStatement(editor.Document, currentStatementSnapshotOffset);
			stopDebuggingToolStripButton.Enabled = !currentStatementSnapshotOffset.IsDeleted;

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnStopDebuggingToolStripButtonClick(object sender, EventArgs e) {
			// Flag as not debugging
			currentStatementSnapshotOffset = DebuggingHelper.SetCurrentStatement(editor.Document, TextSnapshotOffset.Deleted);
			stopDebuggingToolStripButton.Enabled = false;

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnToggleBreakpointToolStripButtonClick(object sender, EventArgs e) {
			// Toggle a breakpoint
			DebuggingHelper.ToggleBreakpoint(editor.ActiveView.Selection.EndSnapshotOffset, true);

			// Focus the editor
			editor.Focus();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnToggleBreakpointEnabledToolStripButtonClick(object sender, EventArgs e) {
			// Get the breakpoints at the caret and toggle their enabled states
			var tagRanges = editor.Document.IndicatorManager.Breakpoints.GetInstances(new TextSnapshotRange(editor.ActiveView.Selection.EndSnapshotOffset));
			var count = 0;
			foreach (var tagRange in tagRanges) {
				if (editor.Document.IndicatorManager.Breakpoints.ToggleEnabledState(tagRange.Tag))
					count++;
			}

			if (count == 0)
				MessageBox.Show("No breakpoints were found at the caret.", "Toggle Breakpoint Enabled State", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			// Focus the editor
			editor.Focus();
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

		/// <summary>
		/// Occurs when the handle is created for the user control.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);

			BeginInvoke((Action)(() => {
				// Since we are initializing some default breakpoints, make sure the document parse completes in the worker thread first
				AmbientParseRequestDispatcherProvider.Dispatcher.WaitForParse(ParseRequest.GetParseHashKey(editor.Document));

				// Add some indicators (this is dispatched since this sample relies on the document's AST being available and parsing occurs asynchronously)
				DebuggingHelper.ToggleBreakpoint(new TextSnapshotOffset(editor.ActiveView.CurrentSnapshot, editor.ActiveView.CurrentSnapshot.Lines[19].StartOffset), true);
				DebuggingHelper.ToggleBreakpoint(new TextSnapshotOffset(editor.ActiveView.CurrentSnapshot, editor.ActiveView.CurrentSnapshot.Lines[23].StartOffset), false);
				DebuggingHelper.ToggleBreakpoint(new TextSnapshotOffset(editor.ActiveView.CurrentSnapshot, editor.ActiveView.CurrentSnapshot.Lines[28].StartOffset), true);
			}));
		}

	}
}
