using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.QuickStart.MdiMerging {

	/// <summary>
	/// A form to test the <c>Bar</c> controls' MDI merging.
	/// </summary>
	public partial class ChildForm : System.Windows.Forms.Form {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Creates an instance of the <c>ChildForm</c> class.
		/// </summary>
		/// <param name="barManager">The <see cref="BarManager"/> that is managing the commands.</param>
		public ChildForm(BarManager barManager) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// One way to implement MDI merging is to use a trick where we designed the commands for this toolbar 
			//   into a PopupMenu on the parent form, then clone the command links and 
			//   put them into our toolbar for the child
			toolBar.CommandLinks.AddRange(barManager.PopupMenus["ChildToolBar"].CommandLinks.CloneToArray());
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the <see cref="ToolBar"/> on the form.
		/// </summary>
		/// <value>The <see cref="ToolBar"/> on the form.</value>
		public ActiproSoftware.UI.WinForms.Controls.Bars.ToolBar ToolBar {
			get {
				return toolBar;
			}
		}

	}
}
