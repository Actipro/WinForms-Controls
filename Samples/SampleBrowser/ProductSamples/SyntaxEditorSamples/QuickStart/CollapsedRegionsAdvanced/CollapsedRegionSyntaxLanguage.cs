using System;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced {
    
    /// <summary>
	/// Represents a syntax language definition that can collapse text regions.
    /// </summary>
    public class CollapsedRegionSyntaxLanguage : SyntaxLanguage {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <c>CollapsedRegionSyntaxLanguage</c> class.
		/// </summary>
		public CollapsedRegionSyntaxLanguage() : base("CollapsedRegion") {
			// Initialize this language from a language definition
			SyntaxEditorHelper.InitializeLanguageFromResourceStream(this, "CSharp.langdef");

			// Register a provider service that can create the custom adornment manager
			this.RegisterService(new AdornmentManagerProvider<CollapsedRegionAdornmentManager>(typeof(CollapsedRegionAdornmentManager)));

			// Register a tagger provider on the language as a service that can create CollapsedRegionTag objects
			this.RegisterService(new CodeDocumentTaggerProvider<CollapsedRegionTagger>(typeof(CollapsedRegionTagger)));

			// Register a quick info provider for collapsed regions
			this.RegisterService(new CollapsedRegionQuickInfoProvider());
		}
		
    }
	
}
