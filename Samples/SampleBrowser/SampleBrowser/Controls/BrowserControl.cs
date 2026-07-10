using ActiproSoftware.UI.WinForms.Controls.Extensions;
using System;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Represents a web browser control.
	/// </summary>
	public partial class BrowserControl : UserControl {

		private ProductFamilyInfo? _familyInfo;
		private ProductItemInfo? _itemInfo;

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public BrowserControl() {
			InitializeComponent();
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Occurs when the document has completed loading.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event data.</param>
		private void OnWebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			// If this is a product family page, look for a samples list to replace
			if (_familyInfo is not null) {
				if (webBrowser.Document?.GetElementById("inject-samples") is { } samplesElement) {
					var innerHtml = new StringBuilder();

					foreach (var group in _familyInfo.GroupedItems) {
						innerHtml.AppendFormat("<h3>{0}</h3>", group.Key);
						innerHtml.Append("<div>");

						innerHtml.Append("<div style=\"width: 50%; display: inline-block; vertical-align: top;\">");
						innerHtml.Append("<ul>");
						var index = 0;
						foreach (var itemInfo in group) {
							if (index++ % 2 == 0)
								innerHtml.AppendFormat("<li><a href=\"sample://{1}\">{0}</a></li>", itemInfo.Title, itemInfo.Path);
						}
						innerHtml.Append("</ul>");
						innerHtml.Append("</div>");

						innerHtml.Append("<div style=\"width: 50%; display: inline-block; vertical-align: top;\">");
						innerHtml.Append("<ul>");
						index = 0;
						foreach (var itemInfo in group) {
							if (index++ % 2 == 1)
								innerHtml.AppendFormat("<li><a href=\"sample://{1}\">{0}</a></li>", itemInfo.Title, itemInfo.Path);
						}
						innerHtml.Append("</ul>");
						innerHtml.Append("</div>");

						innerHtml.Append("</div>");
					}

					samplesElement.InnerHtml = innerHtml.ToString();
				}
			}
			else if (_itemInfo is not null) {
				if ((_itemInfo.Title is not null) && (webBrowser.Document?.GetElementById("inject-title") is { } titleElement))
					titleElement.InnerText = _itemInfo.Title;

				if (webBrowser.Document?.GetElementById("inject-description") is { } descriptionElement)
					descriptionElement.InnerText = string.Format("{0}\r\n\r\nPlease use the 'Launch Sample' button below to open the sample in another window.", _itemInfo.Description).Trim();

				if (webBrowser.Document?.GetElementById("inject-launch-link") is { } linkElement)
					linkElement.SetAttribute("href", string.Format("open://{0}", _itemInfo.Path));
			}
		}

		/// <summary>
		/// Occurs when navigation is about to begin.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event data.</param>
		private void OnWebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e) {
			if (e.Url?.OriginalString is not { } originalUrlString)
				return;

			if (originalUrlString.StartsWith("sample://", StringComparison.OrdinalIgnoreCase)) {
				e.Cancel = true;
				this.FindAncestorOfType<RootForm>()?.NavigateToUrl(originalUrlString);
			}
			else if (originalUrlString.StartsWith("open://", StringComparison.OrdinalIgnoreCase)) {
				e.Cancel = true;
				this.FindAncestorOfType<RootForm>()?.OpenForm(originalUrlString);
			}
			else if (originalUrlString.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
				|| originalUrlString.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) {

				e.Cancel = true;

				// Force all links to open outside of the application
				Program.LaunchExternalBrowser(originalUrlString);
			}
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Navigates to the specified URL.
		/// </summary>
		/// <param name="url">The URL to visit.</param>
		/// <param name="relatedInfo">The related <see cref="ProductFamilyInfo"/> or <see cref="ProductItemInfo"/>.</param>
		public void Navigate(string url, object? relatedInfo) {
			_familyInfo = relatedInfo as ProductFamilyInfo;
			_itemInfo = relatedInfo as ProductItemInfo;

			webBrowser.Navigate(url);
		}

	}

}
