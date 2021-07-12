using ActiproSoftware.UI.WinForms.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {
	
	/// <summary>
	/// Represents the header panel.
	/// </summary>
	public class ContentHeaderPanel : Panel {
			
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>ContentHeaderPanel</c> class.
		/// </summary>
		public ContentHeaderPanel() {
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
		}
			
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the background is painted.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <c>PaintEventArgs</c> that contains data related to the event.</param>
		protected override void OnPaintBackground(PaintEventArgs e) {
			TwoColorLinearGradient.Draw(e.Graphics, this.ClientRectangle, this.ClientRectangle, Color.FromArgb(0xff, 0x00, 0x7a, 0xcc), Color.FromArgb(0xff, 0x41, 0x9c, 0xea), 45, TwoColorLinearGradientStyle.Normal);
		}

	}

}
