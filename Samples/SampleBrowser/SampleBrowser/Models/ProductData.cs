using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides product data information.
	/// </summary>
	public class ProductData {

		private static ProductData? _instance;

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Loads and returns the product data.
		/// </summary>
		private static ProductData Load() {
			var productData = new ProductData();

			var doc = XDocument.Parse(Resources.ProductData);
			if ((doc is not null) && (doc.Root is not null) && (doc.Root.HasElements)) {
				// Loop through product families
				foreach (XElement productFamilyEl in doc.Root.Elements()) {
					var familyInfo = new ProductFamilyInfo();
					XAttribute? attr;

					attr = productFamilyEl.Attribute(XName.Get("Path"));
					if (attr is not null)
						familyInfo.Path = attr.Value;

					attr = productFamilyEl.Attribute(XName.Get("ShortTitle"));
					if (attr is not null)
						familyInfo.ShortTitle = attr.Value;

					attr = productFamilyEl.Attribute(XName.Get("Title"));
					if (attr is not null)
						familyInfo.Title = attr.Value;

					var element = productFamilyEl.Element(XName.Get("Items"));
					if (element is not null) {
						foreach (var itemElement in element.Elements()) {
							var itemInfo = new ProductItemInfo();

							attr = itemElement.Attribute(XName.Get("BlurbText"));
							if (attr is not null)
								itemInfo.BlurbText = attr.Value;

							attr = itemElement.Attribute(XName.Get("Category"));
							if (attr is not null)
								itemInfo.Category = attr.Value;

							attr = itemElement.Attribute(XName.Get("Description"));
							if (attr is not null)
								itemInfo.Description = attr.Value;

							attr = itemElement.Attribute(XName.Get("IsPrivate"));
							if (attr is not null)
								itemInfo.IsPrivate = bool.Parse(attr.Value);

							attr = itemElement.Attribute(XName.Get("Kind"));
							if (attr is not null)
								itemInfo.Kind = (ProductItemKind)Enum.Parse(typeof(ProductItemKind), attr.Value);

							attr = itemElement.Attribute(XName.Get("Path"));
							if (attr is not null)
								itemInfo.Path = attr.Value;

							attr = itemElement.Attribute(XName.Get("Title"));
							if (attr is not null)
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

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Returns the product family or item from a path.
		/// </summary>
		/// <param name="path">The path.</param>
		public object? GetByPath(string path) {
			var itemInfo = (from family in ProductFamilies
							from item in family.Items
							where string.Compare(item.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							select item).FirstOrDefault();

			if ((itemInfo is null) && (ReleaseHistory is not null)) {
				itemInfo = (from item in ReleaseHistory.Items
							where string.Compare(item.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							select item).FirstOrDefault();
			}

			if (itemInfo is not null)
				return itemInfo;

			var familyInfo = (from family in ProductFamilies
							  where string.Compare(family.Path, path, StringComparison.OrdinalIgnoreCase) == 0
							  select family).FirstOrDefault();

			return familyInfo;
		}

		/// <summary>
		/// Returns the next product family or item.
		/// </summary>
		/// <param name="current">The current product family or item.</param>
		public object GetNext(object? current) {
			int index;
			ProductFamilyInfo? currentFamilyInfo;

			if (current is ProductItemInfo currentItemInfo) {
				currentFamilyInfo = currentItemInfo.ProductFamily;
				if (currentFamilyInfo is not null) {
					index = currentFamilyInfo.Items.IndexOf(currentItemInfo);
					if (index < currentFamilyInfo.Items.Count - 1)
						return currentFamilyInfo.Items[index + 1];
				}
			}
			else {
				currentFamilyInfo = current as ProductFamilyInfo;
				if (currentFamilyInfo is not null) {
					if (currentFamilyInfo.Items.Count > 0)
						return currentFamilyInfo.Items[0];
				}
			}

			if (currentFamilyInfo is not null) {
				index = ProductFamilies.IndexOf(currentFamilyInfo);
				if (index < ProductFamilies.Count - 1)
					return ProductFamilies[index + 1];
			}

			return ProductFamilies[0];
		}

		/// <summary>
		/// Returns the previous product family or item.
		/// </summary>
		/// <param name="current">The current product family or item.</param>
		public object GetPrevious(object? current) {
			int index;
			ProductFamilyInfo? currentFamilyInfo;

			if (current is ProductItemInfo currentItemInfo) {
				currentFamilyInfo = currentItemInfo.ProductFamily;
				if (currentFamilyInfo is not null) {
					index = currentFamilyInfo.Items.IndexOf(currentItemInfo);
					if (index > 0)
						return currentFamilyInfo.Items[index - 1];
					else
						return currentFamilyInfo;
				}
			}
			else {
				currentFamilyInfo = current as ProductFamilyInfo;
				if (currentFamilyInfo is not null) {
					index = ProductFamilies.IndexOf(currentFamilyInfo);
					if (index > 0)
						currentFamilyInfo = ProductFamilies[index - 1];
					else
						currentFamilyInfo = ProductFamilies[ProductFamilies.Count - 1];

					return currentFamilyInfo.Items[currentFamilyInfo.Items.Count - 1];
				}
			}

			return ProductFamilies[0];
		}

		/// <summary>
		/// The <see cref="ProductData"/> instance.
		/// </summary>
		public static ProductData Instance
			=> _instance ??= Load();

		/// <summary>
		/// The collection of product families.
		/// </summary>
		/// <value>The collection of product families.</value>
		public ObservableCollection<ProductFamilyInfo> ProductFamilies { get; } = [];

		/// <summary>
		/// The <see cref="ProductFamilyInfo"/> that contains release histories.
		/// </summary>
		public ProductFamilyInfo? ReleaseHistory { get; set; }

	}

}
