using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.TextStatistics {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Finalize initialization
			DpiHelper.RescaleListViewColumns(resultsListView, DpiHelper.DefaultDeviceDpi, DpiHelper.GetSystemDeviceDpi());

			// Update statistics
			this.UpdateStatistics();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs after the editor's document text has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorSnapshotChangedEventArgs"/> that contains the event data.</param>
		private void OnEditorDocumentTextChanged(object sender, EditorSnapshotChangedEventArgs e) {
			this.UpdateStatistics();
		}

		/// <summary>
		/// Updates statistics.
		/// </summary>
		private void UpdateStatistics() {
			resultsListView.Items.Clear();
			foreach (var statistic in editor.Document.CurrentSnapshot.GetTextStatistics().GetRawStatistics())
				resultsListView.Items.Add(new ListViewItem(new string[] { statistic.Description, statistic.StringValue }));
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale control fonts
				var manualFontControls = new Control[] {
					resultsLabel,
					resultsListView
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			DpiHelper.RescaleListViewColumns(resultsListView, deviceDpiOld, deviceDpiNew);

		}

	}

}
