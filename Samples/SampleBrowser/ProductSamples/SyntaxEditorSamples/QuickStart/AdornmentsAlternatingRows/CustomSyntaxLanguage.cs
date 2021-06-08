using System;
using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsAlternatingRows {
    
    /// <summary>
	/// Represents a syntax language definition that renders backgrounds behind alternating rows.
    /// </summary>
    public class CustomSyntaxLanguage : SyntaxLanguage {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <c>CustomSyntaxLanguage</c> class.
		/// </summary>
		public CustomSyntaxLanguage() : base("CustomDecorator") {
			// Initialize this language from a language definition
			SyntaxEditorHelper.InitializeLanguageFromResourceStream(this, "CSharp.langdef");

			// Register a provider service that can create the custom adornment manager
			this.RegisterService(new AdornmentManagerProvider<AlternatingRowsAdornmentManager>(typeof(AlternatingRowsAdornmentManager)));
		}
		
    }
	
}
