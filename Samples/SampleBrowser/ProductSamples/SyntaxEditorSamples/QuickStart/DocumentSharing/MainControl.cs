using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.DotNet.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.Implementation;
using System.Reflection;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DocumentSharing;

/// <summary>
/// Provides the main user control for this sample.
/// </summary>
public partial class MainControl : UserControl {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	public MainControl() {
		InitializeComponent();

		// Configure the document language
		leftEditor.Document.Language = new CSharpSyntaxLanguage();

		// Assign the same document to the other
		rightEditor.Document = leftEditor.Document;

		// Use the default ambient highlighting style registry for the left editor
		var leftRegistry = AmbientHighlightingStyleRegistry.Instance;
		new BuiltInClassificationTypeProvider(leftRegistry).RegisterAll();
		new DotNetClassificationTypeProvider(leftRegistry).RegisterAll();

		// Create a custom highlighting style registry for the right editor
		var rightRegistry = new HighlightingStyleRegistry();
		new BuiltInClassificationTypeProvider(rightRegistry).RegisterAll();
		new DotNetClassificationTypeProvider(rightRegistry).RegisterAll();
		rightEditor.HighlightingStyleRegistry = rightRegistry;

		// Load a dark theme, which has some example pre-defined styles for some of the more common syntax languages,
		//   and use it to differentiate the right editor from the left.  This further demonstrates how even though
		//   the document is shared between the views, the views can be different.
		string path = SyntaxEditorHelper.ThemesPath + "Dark.vssettings";
		using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
		if (stream is not null)
			rightRegistry.ImportHighlightingStyles(stream);

	}

}
