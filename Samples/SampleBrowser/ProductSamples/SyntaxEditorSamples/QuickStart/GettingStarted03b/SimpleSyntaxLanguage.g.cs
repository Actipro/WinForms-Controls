namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted03b {
    using ActiproSoftware.Text;
    using ActiproSoftware.Text.Implementation;
    using ActiproSoftware.Text.Lexing;
    
    
    /// <summary>
    /// Represents a <c>Simple</c> syntax language definition.
    /// </summary>
    /// <remarks>
    /// This type was generated by the Actipro Language Designer tool v11.1.542.0 (http://www.actiprosoftware.com).
    /// Generated code is based on input created by Actipro Software LLC.
    /// Copyright (c) 2001-2024 Actipro Software LLC.  All rights reserved.
    /// </remarks>
    public partial class SimpleSyntaxLanguage : SyntaxLanguage {
        
        /// <summary>
        /// Initializes a new instance of the <c>SimpleSyntaxLanguage</c> class.
        /// </summary>
        public SimpleSyntaxLanguage() : 
                base("Simple") {

            // Create a classification type provider and register its classification types
            SimpleClassificationTypeProvider classificationTypeProvider = new SimpleClassificationTypeProvider();
            classificationTypeProvider.RegisterAll();

            // Register an ILexer service that can tokenize text
            this.RegisterService<ILexer>(new SimpleLexer(classificationTypeProvider));

            // Register an ICodeDocumentTaggerProvider service that creates a token tagger for
            //   each document using the language
            this.RegisterService(new SimpleTokenTaggerProvider(classificationTypeProvider));

            // Register an IExampleTextProvider service that provides example text
            this.RegisterService<IExampleTextProvider>(new SimpleExampleTextProvider());
        }
    }
}
