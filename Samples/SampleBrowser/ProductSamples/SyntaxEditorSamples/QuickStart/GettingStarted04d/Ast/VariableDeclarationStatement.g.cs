namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted04d {
    using ActiproSoftware.Text.Parsing;
    using System;
    
    
    /// <summary>
    /// Represents a variable declaration statement.
    /// </summary>
    /// <remarks>
    /// This type was generated by the Actipro Language Designer tool v11.1.544.0 (http://www.actiprosoftware.com).
    /// Generated code is based on input created by Actipro Software LLC.
    /// Copyright (c) 2001-2023 Actipro Software LLC.  All rights reserved.
    /// </remarks>
    public partial class VariableDeclarationStatement : Statement {
        
        /// <summary>
        /// Gets the name.
        /// </summary>
        private String nameValue;
        
        /// <summary>
        /// Gets the An integer value that identifies the type of AST node.
        /// </summary>
        /// <value>The An integer value that identifies the type of AST node.</value>
        public override Int32 Id {
            get {
                return SimpleAstNodeId.VariableDeclarationStatement;
            }
        }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name {
            get {
                return this.nameValue;
            }
            set {
                this.nameValue = value;
            }
        }
    }
}
