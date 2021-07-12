using System;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Specifies the kind of product item.
	/// </summary>
	public enum ProductItemKind {

		/// <summary>
		/// None.
		/// </summary>
		None,

		/// <summary>
		/// An inline sample.
		/// </summary>
		InlineSample,

		/// <summary>
		/// A sample in a separate dialog.
		/// </summary>
		DialogSample,

		/// <summary>
		/// A tool.
		/// </summary>
		Tool,

		/// <summary>
		/// A document.
		/// </summary>
		Document,

	}

}
