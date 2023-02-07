using System;
using System.Drawing;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.WizardSamples.Demo.Features {

	/// <summary>
	/// Provides a base class for an object that can be used as a background fill.
	/// </summary>
	public class WindowsXPBackgroundFill : BackgroundFill {

		public const int BottomLabelHeight = 73;
		public const int SeparatorHeight = 2;

		/// <summary>
		/// Creates an exact duplicate of the <see cref="BackgroundFill"/> object.
		/// </summary>
		/// <returns>An exact duplicate of the <see cref="BackgroundFill"/> object.</returns>
		public override BackgroundFill Clone() {
			return new WindowsXPBackgroundFill();
		}

		/// <summary>
		/// Fills an area with the background fill.
		/// </summary>
		/// <param name="g">The <c>Graphics</c> object used to paint.</param>
		/// <param name="bounds">The bounds of the area to paint.</param>
		/// <param name="brushBounds">The reference bounds for the brush.</param>
		/// <param name="side">The side with which the background fill should be oriented.</param>
		/// <param name="scaleFactor">The factor of the scale transform to be applied where <see cref="SizeF.Width"/> is applied to the x-axis, and <see cref="SizeF.Height"/> is applied to the y-axis.</param>
		public override void DrawScaled(Graphics g, Rectangle bounds, Rectangle brushBounds, Sides side, SizeF scaleFactor) {
			// Fill in the background
			SolidColorBackgroundFill.Draw(g, brushBounds, Color.CornflowerBlue);

			// Draw a gradient circle
			var circleBounds = DpiHelper.ScaleRectangle(new Rectangle(-100, -125, 300, 300), scaleFactor);
			EllipseGradient.Draw(g, circleBounds, circleBounds,
				Color.FromArgb(192, 224, 242), Color.CornflowerBlue, Color.CornflowerBlue);

			// Draw a separator
			var separatorBounds = new Rectangle(brushBounds.Left,
				brushBounds.Bottom - DpiHelper.ScaleInt32((BottomLabelHeight + SeparatorHeight), scaleFactor),
				brushBounds.Width,
				DpiHelper.ScaleInt32(SeparatorHeight, scaleFactor));
			TwoColorLinearGradient.Draw(g, separatorBounds, separatorBounds, Color.FromKnownColor(KnownColor.CornflowerBlue), 
				Color.FromArgb(192, 224, 242), 0, TwoColorLinearGradientStyle.SigmaBellBump, 0.5f, 1);

			// Fill in a rectangle
			SolidColorBackgroundFill.Draw(g,
				new Rectangle(separatorBounds.Left,
					separatorBounds.Bottom,
					separatorBounds.Width,
					brushBounds.Height - separatorBounds.Bottom
				), Color.RoyalBlue);
		}
	}
}
