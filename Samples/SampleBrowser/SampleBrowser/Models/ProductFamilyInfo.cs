using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using ActiproSoftware.UI.WinForms;

namespace ActiproSoftware.SampleBrowser {
	
    /// <summary>
    /// Provides information about a product family.
    /// </summary>
    public class ProductFamilyInfo : ObservableObjectBase {
        
        private ObservableCollection<ProductItemInfo>			items					= new ObservableCollection<ProductItemInfo>();
		private IEnumerable<IGrouping<string, ProductItemInfo>>	groupedItems;
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ProductFamilyInfo"/> class.
		/// </summary>
		public ProductFamilyInfo() {
			items.CollectionChanged += OnItemsCollectionChanged;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the items collection has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="NotifyCollectionChangedEventArgs"/> that contains the event data.</param>
		private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
			// Clear the cached collections
			groupedItems = null;

			// Wire up the parent product family references
			if (e.NewItems != null) {
				foreach (var itemInfoObj in e.NewItems) {
					var itemInfo = itemInfoObj as ProductItemInfo;
					if (itemInfo != null)
						itemInfo.ProductFamily = this;
				}
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Gets or sets the blurb text.
		/// </summary>
		/// <value>The blurb text.</value>
		public string BlurbText { get; set; }

		/// <summary>
		/// Gets the <see cref="ProductItemInfo"/> object for a feature summary.
		/// </summary>
		/// <value>The <see cref="ProductItemInfo"/> object for a feature summary.</value>
		public ProductItemInfo FeatureSummary {
			get {
				return items.Where(i => i.Title == "Feature Summary").FirstOrDefault();
			}
		}
		
		/// <summary>
		/// Gets the collection of <see cref="ProductItemInfo"/> objects for all items.
		/// </summary>
		/// <value>The collection of <see cref="ProductItemInfo"/> objects for all items.</value>
		public IEnumerable<IGrouping<string, ProductItemInfo>> GroupedItems {
			get {
				if (groupedItems == null) {
					groupedItems = from i in items
							  group i by i.Category;
				}

				return groupedItems;
			}
		}

		/// <summary>
		/// Gets whether there is any blurb text.
		/// </summary>
		/// <value>
		/// <c>true</c> if there is any blurb text; otherwise, <c>false</c>.
		/// </value>
		public bool HasBlurbText {
			get {
				return !string.IsNullOrEmpty(this.BlurbText);
			}
		}

		/// <summary>
		/// Gets whether this is an introduction family.
		/// </summary>
		/// <value>
		/// <c>true</c> if this is an introduction family; otherwise, <c>false</c>.
		/// </value>
		public bool IsIntroduction {
			get {
				return this.Title == "Introduction";
			}
		}

        /// <summary>
        /// Gets the collection of items.
        /// </summary>
        /// <value>The collection of items.</value>
        public ObservableCollection<ProductItemInfo> Items { 
            get {
                return items;
            }
        }
		
        /// <summary>
        /// Gets or sets the path to load.
        /// </summary>
        /// <value>The path to load.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the short title.
        /// </summary>
        /// <value>The short title.</value>
        public string ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

    }

}
