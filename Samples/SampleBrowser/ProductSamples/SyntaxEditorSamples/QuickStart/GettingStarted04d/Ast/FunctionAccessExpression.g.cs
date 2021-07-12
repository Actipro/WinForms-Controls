namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GettingStarted04d {
    using ActiproSoftware.Text.Parsing;
    using System;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Represents a function access expression.
    /// </summary>
    /// <remarks>
    /// This type was generated by the Actipro Language Designer tool v11.1.544.0 (http://www.actiprosoftware.com).
    /// Generated code is based on input created by Actipro Software LLC.
    /// Copyright (c) 2001-2021 Actipro Software LLC.  All rights reserved.
    /// </remarks>
    public partial class FunctionAccessExpression : Expression {
        
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        private IList<Expression> argumentsValue;
        
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
                return SimpleAstNodeId.FunctionAccessExpression;
            }
        }
        
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public IList<Expression> Arguments {
            get {
                if ((this.argumentsValue == null)) {
                    this.argumentsValue = new List<Expression>();
                }
                return this.argumentsValue;
            }
        }
        
        /// <summary>
        /// Returns whether the <see cref="Arguments"/> collection property contains at least one item.
        /// </summary>
        /// <value><c>true</c> if there is at least one item in the collection; otherwise, <c>false</c>.</value>
        public Boolean HasArguments {
            get {
                if (((this.argumentsValue != null) 
                            && (this.argumentsValue.Count > 0))) {
                    return true;
                }
                else {
                    return false;
                }
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
            if ((this.argumentsValue != null)) {
				foreach (IAstNode argumentsValueItem in this.argumentsValue)
					if (argumentsValueItem != null) yield return argumentsValueItem;
            }
        }
    }
}
