using System;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Represents a web browser control.
	/// </summary>
	public partial class BrowserControl : UserControl {

		private ProductFamilyInfo familyInfo;
		private ProductItemInfo itemInfo;
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>BrowserControl </c> class.
		/// </summary>
		public BrowserControl() {
			InitializeComponent();
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the document has completed loading.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>WebBrowserDocumentCompletedEventArgs</c> that contains data related to the event.</param>
		private void OnWebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			// If this is a product family page, look for a samples list to replace
			if (familyInfo != null) {
				var samplesElement = webBrowser.Document.GetElementById("inject-samples");
				if (samplesElement != null) {
					var innerHtml = new StringBuilder();

					foreach (var group in familyInfo.GroupedItems) {
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
			else if (itemInfo != null) {
				var titleElement = webBrowser.Document.GetElementById("inject-title");
				if (titleElement != null)
					titleElement.InnerText = itemInfo.Title;

				var descriptionElement = webBrowser.Document.GetElementById("inject-description");
				if (descriptionElement != null)
					descriptionElement.InnerText = String.Format("{0}\r\n\r\nPlease use the 'Launch Sample' button below to open the sample in another window.", itemInfo.Description).Trim();

				var linkElement = webBrowser.Document.GetElementById("inject-launch-link");
				if (linkElement != null)
					linkElement.SetAttribute("href", String.Format("open://{0}", itemInfo.Path));
			}
		}

		/// <summary>
		/// Occurs when navigation is about to begin.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>WebBrowserNavigatingEventArgs</c> that contains data related to the event.</param>
		private void OnWebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e) {
			if (e.Url.OriginalString.StartsWith("sample://", StringComparison.OrdinalIgnoreCase)) {
				e.Cancel = true;

				var control = this.Parent;
				while (control != null) {
					var rootForm = control as RootForm;
					if (rootForm != null) {
						rootForm.NavigateToUrl(e.Url.OriginalString);
						break;
					}

					control = control.Parent;
				}
			}
			else if (e.Url.OriginalString.StartsWith("open://", StringComparison.OrdinalIgnoreCase)) {
				e.Cancel = true;

				var control = this.Parent;
				while (control != null) {
					var rootForm = control as RootForm;
					if (rootForm != null) {
						rootForm.OpenForm(e.Url.OriginalString);
						break;
					}

					control = control.Parent;
				}
			}
			else if (e.Url.OriginalString.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
				e.Url.OriginalString.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) {
				e.Cancel = true;

				// Force all links to open outside of the application
				Program.LaunchExternalBrowser(e.Url.OriginalString);
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Navigates to the specified URL.
		/// </summary>
		/// <param name="url">The URL to visit.</param>
		/// <param name="relatedInfo">The related <see cref="ProductFamilyInfo"/> or <see cref="ProductItemInfo"/>.</param>
		public void Navigate(string url, object relatedInfo) {
			this.familyInfo = relatedInfo as ProductFamilyInfo;
			this.itemInfo = relatedInfo as ProductItemInfo;

			webBrowser.Navigate(url);
		}

	}
}
