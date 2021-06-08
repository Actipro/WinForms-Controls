using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides product data information.
	/// </summary>
	public class ProductData {

        private ObservableCollection<ProductFamilyInfo> productFamilies		= new ObservableCollection<ProductFamilyInfo>();
        
		private static ProductData instance;
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Loads product data.
		/// </summary>
		/// <returns>The loaded product data.</returns>
		private static ProductData Load() {
			var productData = new ProductData();

			var doc = XDocument.Parse(Resources.ProductData); 
			if ((doc != null) && (doc.Root != null) && (doc.Root.HasElements)) {
				// Loop through product families
				foreach (XElement productFamilyEl in doc.Root.Elements()) {
					var familyInfo = new ProductFamilyInfo();
					XAttribute attr;
					
					attr = productFamilyEl.Attribute(XName.Get("Path"));
					if (attr != null)
						familyInfo.Path = attr.Value;
							
					attr = productFamilyEl.Attribute(XName.Get("ShortTitle"));
					if (attr != null)
						familyInfo.ShortTitle = attr.Value;
					
					attr = productFamilyEl.Attribute(XName.Get("Title"));
					if (attr != null)
						familyInfo.Title = attr.Value;
					
					var el = productFamilyEl.Element(XName.Get("Items"));
					if (el != null) {
						foreach (var itemEl in el.Elements()) {
							var itemInfo = new ProductItemInfo();
							
							attr = itemEl.Attribute(XName.Get("BlurbText"));
							if (attr != null)
								itemInfo.BlurbText = attr.Value;
							
							attr = itemEl.Attribute(XName.Get("Category"));
							if (attr != null)
								itemInfo.Category = attr.Value;
							
							attr = itemEl.Attribute(XName.Get("Description"));
							if (attr != null)
								itemInfo.Description = attr.Value;
							
							attr = itemEl.Attribute(XName.Get("Kind"));
							if (attr != null)
								itemInfo.Kind = (ProductItemKind)Enum.Parse(typeof(ProductItemKind), attr.Value);
							
							attr = itemEl.Attribute(XName.Get("Path"));
							if (attr != null)
								itemInfo.Path = attr.Value;
							
							attr = itemEl.Attribute(XName.Get("Title"));
							if (attr != null)
								itemInfo.Title = attr.Value;
							
							familyInfo.Items.Add(itemInfo);
						}

						// Update the first item in each category
						foreach (var group in familyInfo.GroupedItems) {
							foreach (var itemInfo in group) {
								itemInfo.IsCategoryHeaderRequired = true;
								break;
							}
						}
					}

					productData.ProductFamilies.Add(familyInfo);
				}
			}

			return productData;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Returns the product family or item from a path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>The product family or item from a path.</returns>
		public object GetByPath(string path) {
			var itemInfo = (from family in productFamilies
							from item in family.Items
							where String.Compare(item.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							select item).FirstOrDefault();

			if ((itemInfo == null) && (this.ReleaseHistory != null)) {
				itemInfo = (from item in this.ReleaseHistory.Items
							where String.Compare(item.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							select item).FirstOrDefault();
			}

			if (itemInfo != null)
				return itemInfo;

			var familyInfo = (from family in productFamilies
							  where String.Compare(family.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							  select family).FirstOrDefault();

			return familyInfo;
		}

		/// <summary>
		/// Returns the next product family or item.
		/// </summary>
		/// <param name="current">The current product family or item.</param>
		/// <returns>The next product family or item.</returns>
		public object GetNext(object current) {
			int index;
			ProductFamilyInfo currentFamilyInfo;

			var currentItemInfo = current as ProductItemInfo;
			if (currentItemInfo != null) {
				currentFamilyInfo = currentItemInfo.ProductFamily;
				index = currentFamilyInfo.Items.IndexOf(currentItemInfo);
				if (index < currentFamilyInfo.Items.Count - 1)
					return currentFamilyInfo.Items[index + 1];
			}
			else {
				currentFamilyInfo = current as ProductFamilyInfo;
				if (currentFamilyInfo != null) {
					if (currentFamilyInfo.Items.Count > 0)
						return currentFamilyInfo.Items[0];
				}
			}

			index = productFamilies.IndexOf(currentFamilyInfo);
			if (index < productFamilies.Count - 1)
				return productFamilies[index + 1];

			return productFamilies[0];
		}

		/// <summary>
		/// Returns the previous product family or item.
		/// </summary>
		/// <param name="current">The current product family or item.</param>
		/// <returns>The previous product family or item.</returns>
		public object GetPrevious(object current) {
			int index;
			ProductFamilyInfo currentFamilyInfo;

			var currentItemInfo = current as ProductItemInfo;
			if (currentItemInfo != null) {
				currentFamilyInfo = currentItemInfo.ProductFamily;
				index = currentFamilyInfo.Items.IndexOf(currentItemInfo);
				if (index > 0)
					return currentFamilyInfo.Items[index - 1];
				else
					return currentFamilyInfo;
			}
			else {
				currentFamilyInfo = current as ProductFamilyInfo;
				if (currentFamilyInfo != null) {
					index = productFamilies.IndexOf(currentFamilyInfo);
					if (index > 0)
						currentFamilyInfo = productFamilies[index - 1];
					else
						currentFamilyInfo = productFamilies[productFamilies.Count - 1];

					return currentFamilyInfo.Items[currentFamilyInfo.Items.Count - 1];
				}
			}

			return productFamilies[0];
		}

		/// <summary>
		/// Gets the <see cref="ProductData"/> instance.
		/// </summary>
		/// <value>The <see cref="ProductData"/> instance.</value>
		public static ProductData Instance {
			get {
				if (instance == null)
					instance = Load();

				return instance;
			}
		}
		
        /// <summary>
        /// Gets the collection of product families.
        /// </summary>
        /// <value>The collection of product families.</value>
        public ObservableCollection<ProductFamilyInfo> ProductFamilies { 
            get {
                return productFamilies;
            }
        }
		
		/// <summary>
		/// Gets or sets the <see cref="ProductFamilyInfo"/> that contains release histories.
		/// </summary>
		/// <value>The <see cref="ProductFamilyInfo"/> that contains release histories.</value>
		public ProductFamilyInfo ReleaseHistory { get; set; }

	}

}
