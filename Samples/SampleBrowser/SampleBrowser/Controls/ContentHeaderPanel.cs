using ActiproSoftware.UI.WinForms.Drawing;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Represents the header panel.
	/// </summary>
	public class ContentHeaderPanel : Panel {

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public ContentHeaderPanel() {
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <inheritdoc/>
		protected override void OnPaintBackground(PaintEventArgs e) {
			var bounds = ClientRectangle;
			TwoColorLinearGradient.Draw(
				e.Graphics,
				bounds,
				bounds,
				startColor: Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC),
				endColor: Color.FromArgb(0xFF, 0x41, 0x9C, 0xEA),
				angle: 45,
				TwoColorLinearGradientStyle.Normal
			);
		}

	}

}
