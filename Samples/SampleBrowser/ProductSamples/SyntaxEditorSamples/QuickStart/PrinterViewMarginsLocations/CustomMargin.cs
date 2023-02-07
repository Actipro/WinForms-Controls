using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrinterViewMarginsLocations {

	/// <summary>
	/// Represents an implementation of a custom margin for an <see cref="IPrinterView"/>.
	/// </summary>
	public class CustomMargin : PrinterViewMarginBase {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>CustomMargin</c> class.
		/// </summary>
		/// <param name="view">The <see cref="IPrinterView"/> that will host the margin.</param>
		/// <param name="placement">The margin placement.</param>
		public CustomMargin(IPrinterView view, PrinterViewMarginPlacement placement) : base(view, "Custom", placement, new Ordering[] {
				new Ordering(PrinterViewMarginKeys.DocumentTitle, OrderPlacement.After),
				new Ordering(PrinterViewMarginKeys.LineNumber, OrderPlacement.After),
				new Ordering(PrinterViewMarginKeys.PageNumber, OrderPlacement.After),
				new Ordering(PrinterViewMarginKeys.WordWrapGlyph, OrderPlacement.After),
			}) {}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Draws the margin and its content.
		/// </summary>
		/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
		public override void Draw(TextViewDrawContext context) {
			if (context == null)
				throw new ArgumentNullException("context");

			var bounds = this.Bounds;
			
			// Draw a border
			switch (this.Placement) {
				case PrinterViewMarginPlacement.Bottom:
					context.DrawLine(new Point(bounds.X, bounds.Y), new Point(bounds.Right - 1, bounds.Y), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case PrinterViewMarginPlacement.Left:
					context.DrawLine(new Point(bounds.Right - 1, bounds.Y), new Point(bounds.Right - 1, bounds.Bottom - 1), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case PrinterViewMarginPlacement.Right:
					context.DrawLine(new Point(bounds.X, bounds.Y), new Point(bounds.X, bounds.Bottom - 1), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case PrinterViewMarginPlacement.Top:
					context.DrawLine(new Point(bounds.X, bounds.Bottom - 1), new Point(bounds.Right - 1, bounds.Bottom - 1), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
			}

			using (var layout = context.Canvas.CreateTextLayout("Margin placement: " + this.Placement, bounds.Width - 20, "Segoe UI", 8, SystemColors.ControlText)) {
				layout.TextWrapping = TextLayoutWrapping.Wrap;
				
				var x = bounds.X + 10;
				var y = bounds.Y + 3;
				foreach (var layoutLine in layout.Lines) {
					context.DrawText(new Point(x, y), layoutLine);
					y += layoutLine.Height;
				}
			}
		}
		
		/// <summary>
		/// Measures the size required for the element and its child elements.
		/// </summary>
		/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
		/// <param name="availableSize">The available size.</param>
		/// <returns>The desired size.</returns>
		protected override Size MeasureOverride(Graphics g, Size availableSize) {
			if (this.Visibility == Visibility.Collapsed)
				return new Size(0, 0);

			var scaleFactor = this.DpiScaleFactor;

			switch (this.Placement) {
				case PrinterViewMarginPlacement.Bottom:
				case PrinterViewMarginPlacement.Top:
					return new Size(availableSize.Width, (int)(20 * scaleFactor.Width));
				default:
					return new Size((int)(80 * scaleFactor.Height), availableSize.Height);
			}
		}

	}
}