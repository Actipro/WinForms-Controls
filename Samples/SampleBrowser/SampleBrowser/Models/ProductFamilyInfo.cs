using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides information about a product family.
	/// </summary>
	public class ProductFamilyInfo : ObservableObjectBase {

		private IEnumerable<IGrouping<string?, ProductItemInfo>>? _groupedItems;

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public ProductFamilyInfo() {
			Items.CollectionChanged += OnItemsCollectionChanged;
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Occurs when the items collection has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event data.</param>
		private void OnItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
			// Clear the cached collections
			_groupedItems = null;

			// Wire up the parent product family references
			if (e.NewItems is { } newItems) {
				foreach (var itemInfo in newItems.OfType<ProductItemInfo>())
					itemInfo.ProductFamily = this;
			}
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// The blurb text.
		/// </summary>
		public string? BlurbText { get; set; }

		/// <summary>
		/// The <see cref="ProductItemInfo"/> object for a feature summary.
		/// </summary>
		public ProductItemInfo? FeatureSummary
			=> Items.FirstOrDefault(x => x.Title == "Feature Summary");

		/// <summary>
		/// The collection of <see cref="ProductItemInfo"/> objects for all items.
		/// </summary>
		public IEnumerable<IGrouping<string?, ProductItemInfo>> GroupedItems
			=> _groupedItems ??= Items.GroupBy(x => x.Category);

		/// <summary>
		/// Indicates whether there is any blurb text.
		/// </summary>
		/// <value>
		/// <c>true</c> if there is any blurb text; otherwise, <c>false</c>.
		/// </value>
		public bool HasBlurbText
			=> !string.IsNullOrEmpty(BlurbText);

		/// <summary>
		/// Indicates whether this is an introduction family.
		/// </summary>
		/// <value>
		/// <c>true</c> if this is an introduction family; otherwise, <c>false</c>.
		/// </value>
		public bool IsIntroduction
			=> Title == "Introduction";

		/// <summary>
		/// The collection of items.
		/// </summary>
		public ObservableCollection<ProductItemInfo> Items { get; } = [];

		/// <summary>
		/// The path to load.
		/// </summary>
		public string? Path { get; set; }

		/// <summary>
		/// The short title.
		/// </summary>
		public string? ShortTitle { get; set; }

		/// <summary>
		/// The title.
		/// </summary>
		public string? Title { get; set; }

	}

}
