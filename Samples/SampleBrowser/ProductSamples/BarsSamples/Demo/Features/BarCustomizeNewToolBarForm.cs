using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ActiproSoftware.Products.Bars;
using ActiproSoftware.UI.WinForms.Controls.Bars;

namespace ActiproSoftware.ProductSamples.BarsSamples.Demo.Features {

	/// <summary>
	/// Provides a <see cref="Form"/> for entering data about a new toolbar.
	/// </summary>
	internal partial class BarCustomizeNewToolBarForm : System.Windows.Forms.Form {

		private BarManager	barManager;
		private string		existingToolbarName;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>BarCustomizeNewToolBarForm</c> class.
		/// </summary>
		/// <param name="barManager">The manager being edited.</param>
		/// <param name="text">The title bar text.</param>
		public BarCustomizeNewToolBarForm(BarManager barManager, string text) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Initialize parameters
			this.barManager = barManager;

			// Initialize the form
			this.Text = text;
			this.OnInitForm();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT CALLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the form needs to be initialized.
		/// </summary>
		private void OnInitForm() {
			// Find a default key
			for (int index = 1; index < int.MaxValue; index++) {
				string key = String.Format("Custom {0}", index);
				if (!barManager.DockableToolBars.Contains(key)) {
                    keyTextBox.Text = key;
					keyTextBox.SelectAll();
					break;
				}
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void okButton_Click(object sender, System.EventArgs e) {
			// Ensure that a key was entered
			if (this.ToolBarKey.Length == 0) {
				MessageBox.Show(this, "Please enter a name for the toolbar.", "Error");
				return;
			}

			// Ensure that the key doesn't already exist
			if ((existingToolbarName == null) || (this.ToolBarKey != existingToolbarName)) {
				if (barManager.DockableToolBars.Contains(this.ToolBarKey)) {
					MessageBox.Show(this, "A toolbar with that name already exists.  Please enter a different name.", "Error");
					return;
				}
			}

			// Close the form
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Gets or sets the toolbar key entered by the user.
		/// </summary>
		/// <value>The toolbar key entered by the user.</value>
		public string ToolBarKey {
			get {
				return keyTextBox.Text.Trim();
			}
			set {
				existingToolbarName = value;
				keyTextBox.Text = existingToolbarName;
				keyTextBox.SelectAll();
			}
		}

	}
}
