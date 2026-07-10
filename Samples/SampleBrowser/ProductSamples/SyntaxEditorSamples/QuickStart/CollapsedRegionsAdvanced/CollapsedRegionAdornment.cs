using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.Primitives;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced;

/// <summary>
/// Represents a default implementation of a collapsed region adornment.
/// </summary>
public partial class CollapsedRegionAdornment : UIElement {

	private readonly TagSnapshotRange<CollapsedRegionTag> _tagRange;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="tagRange">The tag range for which the adornment is displayed.</param>
	internal CollapsedRegionAdornment(TagSnapshotRange<CollapsedRegionTag> tagRange) {
		// Initialize
		_tagRange = tagRange ?? throw new ArgumentNullException(nameof(tagRange));
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// The <see cref="TextSnapshotRange"/> for which the adornment is displayed.
	/// </summary>
	internal TextSnapshotRange SnapshotRange
		=> _tagRange.SnapshotRange;

	/// <summary>
	/// The text that is displayed in the adornment.
	/// </summary>
	internal string? Text
		=> _tagRange.Tag.Text;

	/// <summary>
	/// The owner view.
	/// </summary>
	private EditorView? View
		=> this.FindLogicalAncestorOfType<EditorView>();

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// The foreground color.
	/// </summary>
	public Color? Foreground { get; set; }

	/// <summary>
	/// The <see cref="Cursor"/> that should be used when the mouse is over the element at the specified <see cref="Point"/>.
	/// </summary>
	/// <param name="point">The <see cref="Point"/> to examine.</param>
	public override Cursor GetCursor(Point point)
		=> Cursors.Arrow;

	/// <summary>
	/// The adornment height.
	/// </summary>
	public int Height { get; set; }

	/// <summary>
	/// Measures the size required for the element and its child elements.
	/// </summary>
	/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
	/// <param name="availableSize">The available size.</param>
	/// <returns>The desired size.</returns>
	protected override Size MeasureOverride(Graphics? g, Size availableSize)
		=> new(Width, Height);

	/// <summary>
	/// Occurs when a mouse button is pressed.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnMouseDown(MouseEventArgs e) {
		if (e.Button == MouseButtons.Left) {
			if (View is { } view) {
				// Focus the view
				view.Focus();

				// Select the collapsed region
				view.Selection.SelectRange(SnapshotRange, SelectionModes.ContinuousStream);
			}
		}
	}

	/// <summary>
	/// Occurs when rendering the control.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnRender(PaintEventArgs e) {
		var bounds = Bounds;
		if ((bounds.Width > 2) && (bounds.Height > 2)) {
			var g = e.Graphics;

			var color = Foreground ?? Color.Gray;
			using (var pen = new Pen(color, 1)) {
				DrawingHelper.DrawRoundedRectangle(g, bounds, 2, 2, pen);
			}

			if ((View is { } view) && (!string.IsNullOrEmpty(Text))) {
				using var fontFamily = new FontFamily(view.DefaultFontFamilyName);
				using var font = new Font(fontFamily, view.DefaultFontSize, FontStyle.Regular);
				using var format = DrawingHelper.GetStringFormat(StringAlignment.Center, StringAlignment.Center);
				DrawingHelper.DrawString(g, Text!, font, color, bounds, format);
			}
		}
	}

	/// <summary>
	/// The adornment width.
	/// </summary>
	public int Width { get; set; }

	/// <summary>
	/// The Y-delta to apply for matching the baseline.
	/// </summary>
	public int YDelta { get; set; }

}
