namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted04d {
    using ActiproSoftware.Text.Parsing;
    using ActiproSoftware.Text.Parsing.Implementation;
    using System;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Represents a compilation unit.
    /// </summary>
    /// <remarks>
    /// This type was generated by the Actipro Language Designer tool v11.1.544.0 (http://www.actiprosoftware.com).
    /// Generated code is based on input created by Actipro Software LLC.
    /// Copyright (c) 2001-2024 Actipro Software LLC.  All rights reserved.
    /// </remarks>
    public partial class CompilationUnit : AstNodeBase {
        
        /// <summary>
        /// Gets the members.
        /// </summary>
        private IList<FunctionDeclaration> membersValue;
        
        /// <summary>
        /// Gets the An integer value that identifies the type of AST node.
        /// </summary>
        /// <value>The An integer value that identifies the type of AST node.</value>
        public override Int32 Id {
            get {
                return SimpleAstNodeId.CompilationUnit;
            }
        }
        
        /// <summary>
        /// Gets the members.
        /// </summary>
        /// <value>The members.</value>
        public IList<FunctionDeclaration> Members {
            get {
                if ((this.membersValue == null)) {
                    this.membersValue = new List<FunctionDeclaration>();
                }
                return this.membersValue;
            }
        }
        
        /// <summary>
        /// Returns whether the <see cref="Members"/> collection property contains at least one item.
        /// </summary>
        /// <value><c>true</c> if there is at least one item in the collection; otherwise, <c>false</c>.</value>
        public Boolean HasMembers {
            get {
                if (((this.membersValue != null) 
                            && (this.membersValue.Count > 0))) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// Retrieves an <c>IEnumerator</c> object that can iterate the child <see cref="IAstNode"/> objects in this node.
        /// </summary>
        /// <returns>An <c>IEnumerator</c> object that can iterate the child <see cref="IAstNode"/> objects in this node.</returns>
        protected override IEnumerator<IAstNode> GetChildrenEnumerator() {
            IEnumerator<IAstNode> baseEnumerator = base.GetChildrenEnumerator();
            if ((baseEnumerator != null)) {
				while (baseEnumerator.MoveNext())
					yield return baseEnumerator.Current;
            }
            if ((this.membersValue != null)) {
				foreach (IAstNode membersValueItem in this.membersValue)
					if (membersValueItem != null) yield return membersValueItem;
            }
        }
    }
}
