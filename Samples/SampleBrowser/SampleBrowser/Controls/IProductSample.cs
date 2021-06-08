namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Provides the base requirements of a product sample that has extended functionality.
	/// </summary>
	public interface IProductSample {
		
		/// <summary>
		/// Notifies the UI that it has been loaded.
		/// </summary>
		void NotifyLoaded();

		/// <summary>
		/// Notifies the UI that it has been unloaded.
		/// </summary>
		void NotifyUnloaded();
		
	}

}
