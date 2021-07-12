using System;
using System.Drawing;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.WizardSamples.Demo.Features {

	/// <summary>
	/// Provides a base class for an object that can be used as a background fill.
	/// </summary>
	public class WindowsXPBackgroundFill : BackgroundFill {

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
		public override void Draw(Graphics g, Rectangle bounds, Rectangle brushBounds, Sides side) {
			// Fill in the background
			SolidColorBackgroundFill.Draw(g, brushBounds, Color.CornflowerBlue);

			// Draw a gradient circle
			EllipseGradient.Draw(g, new Rectangle(-100, -125, 300, 300), new Rectangle(-100, -125, 300, 300),
				Color.FromArgb(192, 224, 242), Color.CornflowerBlue, Color.CornflowerBlue);

			// Draw a separator
			Rectangle separatorBounds = new Rectangle(brushBounds.Left, brushBounds.Bottom - 75,
				brushBounds.Width, 2);
			TwoColorLinearGradient.Draw(g, separatorBounds, separatorBounds, Color.FromKnownColor(KnownColor.CornflowerBlue), 
				Color.FromArgb(192, 224, 242), 0, TwoColorLinearGradientStyle.SigmaBellBump, 0.5f, 1);

			// Fill in a rectangle
			SolidColorBackgroundFill.Draw(g, new Rectangle(separatorBounds.Left, separatorBounds.Bottom, 
				separatorBounds.Width, brushBounds.Height - separatorBounds.Bottom), Color.RoyalBlue);
		}
	}
}
