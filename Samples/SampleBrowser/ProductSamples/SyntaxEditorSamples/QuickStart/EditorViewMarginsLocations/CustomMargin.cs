using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using System;
using System.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsLocations {

	/// <summary>
	/// Represents an implementation of a custom margin for an <see cref="IEditorView"/>.
	/// </summary>
	public class CustomMargin : EditorViewMarginBase {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>CustomMargin</c> class.
		/// </summary>
		/// <param name="view">The <see cref="IEditorView"/> that will host the margin.</param>
		/// <param name="placement">The margin placement.</param>
		public CustomMargin(IEditorView view, EditorViewMarginPlacement placement) : base(view, "Custom", placement, new Ordering[] {
				new Ordering(EditorViewMarginKeys.Indicator, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.LineNumber, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.Selection, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.Ruler, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.WordWrapGlyph, OrderPlacement.After),
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
			
			// Fill the background
			context.FillRectangle(bounds, SystemBrushes.Control);
			
			// Draw a border
			switch (this.Placement) {
				case EditorViewMarginPlacement.FixedBottom:
				case EditorViewMarginPlacement.ScrollableBottom:
					context.DrawLine(new Point(bounds.X, bounds.Y), new Point(bounds.Right - 1, bounds.Y), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case EditorViewMarginPlacement.FixedLeft:
				case EditorViewMarginPlacement.ScrollableLeft:
					context.DrawLine(new Point(bounds.Right - 1, bounds.Y), new Point(bounds.Right - 1, bounds.Bottom - 1), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case EditorViewMarginPlacement.FixedRight:
				case EditorViewMarginPlacement.ScrollableRight:
					context.DrawLine(new Point(bounds.X, bounds.Y), new Point(bounds.X, bounds.Bottom - 1), SystemColors.ControlDark, LineKind.Solid, 1);
					break;
				case EditorViewMarginPlacement.FixedTop:
				case EditorViewMarginPlacement.ScrollableTop:
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

			var dpiScale = g.DpiX / 96.0f;

			switch (this.Placement) {
				case EditorViewMarginPlacement.FixedBottom:
				case EditorViewMarginPlacement.FixedTop:
				case EditorViewMarginPlacement.ScrollableBottom:
				case EditorViewMarginPlacement.ScrollableTop:
					return new Size(availableSize.Width, (int)(20 * dpiScale));
				case EditorViewMarginPlacement.ScrollableLeft:
				case EditorViewMarginPlacement.ScrollableRight:
					return new Size((int)(100 * dpiScale), availableSize.Height);
				default:
					return new Size((int)(80 * dpiScale), availableSize.Height);
			}
		}

	}
}