using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrinterViewMarginsCustom;

/// <summary>
/// Represents an implementation of a custom margin for an <see cref="IPrinterView"/>.
/// </summary>
public class CustomMargin : PrinterViewMarginBase {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="view">The <see cref="IPrinterView"/> that will host the margin.</param>
	public CustomMargin(IPrinterView view)
		: base(view, "Custom", PrinterViewMarginPlacement.Top, [new Ordering(PrinterViewMarginKeys.DocumentTitle, OrderPlacement.Before)]) { }

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Draws the margin and its content.
	/// </summary>
	/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
	public override void Draw(TextViewDrawContext context) {
		if (context is null)
			throw new ArgumentNullException(nameof(context));

		var bounds = Bounds;

		// Draw a border
		context.DrawLine(
			new Point(bounds.X, bounds.Bottom - 10),
			new Point(bounds.Right - 1, bounds.Bottom - 10),
			Color.Silver, LineKind.Solid, strokeWidth: 1
		);

		// Draw a logo
		var logoAreaWidth = 100;
		context.DrawImage(new Point(bounds.X + 25, bounds.Y), ActiproSoftware.SampleBrowser.Resources.CompanyLogoIcon48);

		var textBounds = new Rectangle(
			bounds.X + logoAreaWidth,
			bounds.Y,
			Math.Max(10, bounds.Width - logoAreaWidth),
			bounds.Height
		);
		var y = textBounds.Y;

		// Draw the document title
		var pageNumberText = string.Format("Page {0}", View.PageNumber);
		using (var layout = context.Canvas.CreateTextLayout(pageNumberText, textBounds.Width, "Segoe UI", 12, Color.Black)) {
			layout.SetFontWeight(0, pageNumberText.Length, FontWeights.Bold);
			layout.TextWrapping = TextLayoutWrapping.Wrap;

			foreach (var layoutLine in layout.Lines) {
				context.DrawText(new Point(textBounds.X, y), layoutLine);
				y += layoutLine.Height;
			}
		}

		// Draw the document title
		if (View.SyntaxEditor.PrintSettings?.DocumentTitle is { } documentTitle) {
			using (var layout = context.Canvas.CreateTextLayout(documentTitle, textBounds.Width, "Segoe UI", 10, Color.Gray)) {
				layout.TextWrapping = TextLayoutWrapping.Wrap;

				foreach (var layoutLine in layout.Lines) {
					context.DrawText(new Point(textBounds.X, y), layoutLine);
					y += layoutLine.Height;
				}
			}
		}
	}

	/// <summary>
	/// Measures the size required for the element and its child elements.
	/// </summary>
	/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
	/// <param name="availableSize">The available size.</param>
	/// <returns>The desired size.</returns>
	protected override Size MeasureOverride(Graphics? g, Size availableSize) {
		if (Visibility == Visibility.Collapsed)
			return Size.Empty;

		var scaleFactor = DpiScaleFactor;
		return new Size(availableSize.Width, (int)(80 * scaleFactor.Width));
	}

}
