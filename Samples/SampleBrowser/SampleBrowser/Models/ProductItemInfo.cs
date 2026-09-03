namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides information about a product item.
	/// </summary>
	public class ProductItemInfo {

		private string? _blurbText;

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public ProductItemInfo() { }

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// The blurb text.
		/// </summary>
		public string? BlurbText {
			get => _blurbText ?? (IsPrivate ? "Private!" : null);
			set => _blurbText = value;
		}

		/// <summary>
		/// The category.
		/// </summary>
		public string? Category { get; set; }

		/// <summary>
		/// The description.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Indicates whether this item should render a category header.
		/// </summary>
		/// <value>
		/// <c>true</c> if this item should render a category header; otherwise, <c>false</c>.
		/// </value>
		public bool IsCategoryHeaderRequired { get; set; }

		/// <summary>
		/// Indicates whether this item is a private item not intended for inclusion in public projects.
		/// </summary>
		public bool IsPrivate { get; set; }

		/// <summary>
		/// The <see cref="ProductItemKind"/> of item.
		/// </summary>
		public ProductItemKind Kind { get; set; }

		/// <summary>
		/// The next <see cref="ProductItemInfo"/>, if any.
		/// </summary>
		public ProductItemInfo? NextItem {
			get {
				if (ProductFamily is not null) {
					var index = ProductFamily.Items.IndexOf(this);
					if ((index != -1) && (index < ProductFamily.Items.Count - 1))
						return ProductFamily.Items[index + 1];
				}

				return null;
			}
		}

		/// <summary>
		/// The path to load.
		/// </summary>
		public string? Path { get; set; }

		/// <summary>
		/// The previous <see cref="ProductItemInfo"/>, if any.
		/// </summary>
		public ProductItemInfo? PreviousItem {
			get {
				if (ProductFamily is not null) {
					var index = ProductFamily.Items.IndexOf(this);
					if (index > 0)
						return ProductFamily.Items[index - 1];
				}

				return null;
			}
		}

		/// <summary>
		/// The <see cref="ProductFamilyInfo"/> that owns this item.
		/// </summary>
		public ProductFamilyInfo? ProductFamily { get; set; }

		/// <summary>
		/// The title.
		/// </summary>
		public string? Title { get; set; }

	}

}
