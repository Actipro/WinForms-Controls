using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.Primitives;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging;

/// <summary>
/// Represents a default implementation of a collapsed region adornment.
/// </summary>
public partial class ElapsedTimeAdornment : UIElement {

	private readonly TagSnapshotRange<ElapsedTimeTag> _tagRange;

	private const float FontSizeAdjustment = 0.9f;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="tagRange">The tag range for which the adornment is displayed.</param>
	internal ElapsedTimeAdornment(TagSnapshotRange<ElapsedTimeTag> tagRange) {
		_tagRange = tagRange ?? throw new ArgumentNullException(nameof(tagRange));
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// The text that is displayed in the adornment.
	/// </summary>
	internal string Text
		=> _tagRange.Tag.TimeSpanText;

	/// <summary>
	/// The owner view.
	/// </summary>
	private EditorView? View
		=> this.FindLogicalAncestorOfType<EditorView>();

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

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
	protected override Size MeasureOverride(Graphics? g, Size availableSize) {
		var width = 0;

		var text = Text;
		if ((View is { } view) && (!string.IsNullOrEmpty(text)) && (g is not null)) {
			var baseFont = SystemFonts.MessageBoxFont ?? SystemFonts.DefaultFont;
			var fontFamily = baseFont.FontFamily;
			var fontSize = (float)Math.Round(view.DefaultFontSize * FontSizeAdjustment, MidpointRounding.AwayFromZero);

			using var font = new Font(fontFamily, fontSize, FontStyle.Regular);
			using var format = DrawingHelper.GetStringFormat();
			width = DrawingHelper.MeasureString(g, Text, font, format).Width;
		}

		return new Size(width, Height);
	}

	/// <summary>
	/// Occurs when rendering the control.
	/// </summary>
	/// <param name="e">The event data.</param>
	protected override void OnRender(PaintEventArgs e) {
		var bounds = Bounds;
		if ((bounds.Width > 2) && (bounds.Height > 2) && (e is not null)) {
			var text = Text;
			if ((View is { } view) && (!string.IsNullOrEmpty(text))) {
				var baseFont = SystemFonts.MessageBoxFont ?? SystemFonts.DefaultFont;
				var fontFamily = baseFont.FontFamily;
				var fontSize = (float)Math.Round(view.DefaultFontSize * FontSizeAdjustment, MidpointRounding.AwayFromZero);

				using var font = new Font(fontFamily, fontSize, FontStyle.Regular);
				using var format = DrawingHelper.GetStringFormat();
				DrawingHelper.DrawString(e.Graphics, text, font, Color.Gray, bounds, format);
			}
		}
	}

}
