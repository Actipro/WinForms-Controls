using ActiproSoftware.Extensions;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsCustom;

/// <summary>
/// Represents an <see cref="IIndicatorTag"/> that renders a custom indicator over a text range.
/// </summary>
public class CustomIndicatorTag : IndicatorClassificationTagBase {

	private static readonly ClassificationType _customIndicatorClassificationType = new("Custom Indicator");

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes the class.
	/// </summary>
	static CustomIndicatorTag() {
		// This sample assumes the editor will use the AmbientHighlightingStyleRegistry
		var registry = AmbientHighlightingStyleRegistry.Instance;

		// Configure light/dark color palettes with default colors
		var key = _customIndicatorClassificationType.Key;
		registry.LightColorPalette?.SetForeground(key, UIColor.FromWebColor("#004000"));
		registry.LightColorPalette?.SetBackground(key, UIColor.FromWebColor("#ebf1dd"));
		registry.DarkColorPalette?.SetForeground(key, UIColor.FromWebColor("#95db7d"));
		registry.DarkColorPalette?.SetBackground(key, UIColor.FromWebColor("#265e4d"));

		// Associate a default style with the classification type
		//   and the current color palette color will be automatically applied
		registry.Register(_customIndicatorClassificationType, new HighlightingStyle());
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	public override IClassificationType ClassificationType
		=> _customIndicatorClassificationType;

	/// <inheritdoc/>
	public override void DrawGlyph(TextViewDrawContext context, ITextViewLine viewLine, TagSnapshotRange<IIndicatorTag> tagRange, Rectangle bounds) {
		// Get the DPI scale (WinForms only)
		var scaleFactor = new SizeF(context.DpiScale, context.DpiScale);

		int minimumDiameter = 8;
		int maximumDiameter = DpiHelper.ScaleInt32(13, scaleFactor);
		int padding = DpiHelper.ScaleInt32(1, scaleFactor);
		int strokeWidth = DpiHelper.ScaleInt32(1, scaleFactor);

		var diameter = (Math.Min(bounds.Width, bounds.Height) - (2 * padding)).ClampToRange(minimumDiameter, maximumDiameter);

		var x = (int)(bounds.X + (bounds.Width - diameter) / 2.0);
		var y = (int)(bounds.Y + (bounds.Height - diameter) / 2.0);

		// Create a circle glyph that uses the same foreground/background colors as the highlighting style
		var key = _customIndicatorClassificationType.Key;
		var colorPalette = AmbientHighlightingStyleRegistry.Instance.CurrentColorPalette;
		context.FillEllipse(new Rectangle(x, y, diameter, diameter), colorPalette.GetBackground(key) ?? Color.FromArgb(0xff, 0x8a, 0xf3, 0x82));
		context.DrawEllipse(new Rectangle(x, y, diameter, diameter), colorPalette.GetForeground(key) ?? Color.FromArgb(0xff, 0x00, 0x40, 0x00), LineKind.Solid, strokeWidth);
	}

}
