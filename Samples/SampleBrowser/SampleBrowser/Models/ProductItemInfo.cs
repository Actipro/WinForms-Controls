using System.Linq;

namespace ActiproSoftware.SampleBrowser {
	
    /// <summary>
    /// Provides information about a product item.
    /// </summary>
    public class ProductItemInfo {
        	
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductItemInfo"/> class.
		/// </summary>
		public ProductItemInfo() {}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Gets or sets the blurb text.
		/// </summary>
		/// <value>The blurb text.</value>
		public string BlurbText { get; set; }
		
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

		/// <summary>
		/// Gets or sets whether this item should render a category header.
		/// </summary>
		/// <value>
		/// <c>true</c> if this item should render a category header; otherwise, <c>false</c>.
		/// </value>
		public bool IsCategoryHeaderRequired { get; set; }
		
		/// <summary>
		/// Gets or sets the <see cref="ProductItemKind"/> of item.
		/// </summary>
		/// <value>The <see cref="ProductItemKind"/> of item.</value>
		public ProductItemKind Kind { get; set; }

		/// <summary>
		/// Gets the next <see cref="ProductItemInfo"/>, if any.
		/// </summary>
		/// <value>The next <see cref="ProductItemInfo"/>, if any.</value>
		public ProductItemInfo NextItem {
			get {
				if (this.ProductFamily != null) {
					var index = this.ProductFamily.Items.IndexOf(this);
					if ((index != -1) && (index < this.ProductFamily.Items.Count - 1))
						return this.ProductFamily.Items[index + 1];
				}

				return null;
			}
		}
		
        /// <summary>
        /// Gets or sets the path to load.
        /// </summary>
        /// <value>The path to load.</value>
        public string Path { get; set; }

		/// <summary>
		/// Gets the previous <see cref="ProductItemInfo"/>, if any.
		/// </summary>
		/// <value>The previous <see cref="ProductItemInfo"/>, if any.</value>
		public ProductItemInfo PreviousItem {
			get {
				if (this.ProductFamily != null) {
					var index = this.ProductFamily.Items.IndexOf(this);
					if (index > 0)
						return this.ProductFamily.Items[index - 1];
				}

				return null;
			}
		}
		
		/// <summary>
		/// Gets or sets the <see cref="ProductFamilyInfo"/> that owns this item.
		/// </summary>
		/// <value>The <see cref="ProductFamilyInfo"/> that owns this item.</value>
		public ProductFamilyInfo ProductFamily { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

    }

}
