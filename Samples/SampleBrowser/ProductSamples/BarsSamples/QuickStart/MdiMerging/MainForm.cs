using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Controls.Bars;
using ActiproSoftware.UI.WinForms.Controls.Navigation;

namespace ActiproSoftware.ProductSamples.BarsSamples.QuickStart.MdiMerging {

	/// <summary>
	/// A form to test the <c>Bar</c> controls' MDI merging.
	/// </summary>
	public partial class MainForm : System.Windows.Forms.Form {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Creates an instance of the <c>MainForm</c> class.
		/// </summary>
		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Add a child form
			this.ProcessFileNew();
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when a <see cref="BarCommand"/> is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void barManager_CommandClick(object sender, ActiproSoftware.UI.WinForms.Controls.Bars.BarCommandLinkEventArgs e) {
			switch (e.Command.FullName) {
				case "File.Exit":
					this.Close();
					break;
				case "File.New":
					this.ProcessFileNew();
					break;
				default:
					MessageBox.Show(this, String.Format("The command '{0}' has not been implemented for this sample.", e.Command.FullName), "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON.PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Processes the <c>File.New</c> command.
		/// </summary>
		private void ProcessFileNew() {
			ChildForm childForm = new ChildForm(barManager);
			childForm.MdiParent = this;
			childForm.Show();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Raises the <c>MdiChildActivate</c> event.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnMdiChildActivate(EventArgs e) {
			// Call the base method.
			base.OnMdiChildActivate(e);

			// Merge or revert merge
			if (this.ActiveMdiChild is ChildForm) {
				ChildForm childForm = (ChildForm)this.ActiveMdiChild;
				BarManager.Merge(childForm.ToolBar, barManager.MenuBar, true);
			}
			else
				BarManager.RevertAllMerges(barManager.MenuBar);
		}


	}
}
