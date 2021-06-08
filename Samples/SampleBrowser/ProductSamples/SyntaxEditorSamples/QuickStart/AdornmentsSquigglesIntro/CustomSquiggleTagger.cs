using System;
using System.Drawing;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsSquigglesIntro {
    
	/// <summary>
	/// Provides <see cref="ISquiggleTag"/> objects over text ranges.
	/// </summary>
	public class CustomSquiggleTagger : CollectionTagger<ISquiggleTag> {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes the <c>CustomSquiggleTagger</c> class.
		/// </summary>
		static CustomSquiggleTagger() {
			// Register the classification type for a warning that will render the squiggle in green
			AmbientHighlightingStyleRegistry.Instance.Register(ClassificationTypes.Warning, new HighlightingStyle(Color.Green));
		}

		/// <summary>
		/// Initializes a new instance of the <c>CustomSquiggleTagger</c> class.
		/// </summary>
		/// <param name="document">The document to which this manager is attached.</param>
		public CustomSquiggleTagger(ICodeDocument document) : 
			base("ActiproPatternBasedSquiggle", null, document, true) {}
		
	}

}
