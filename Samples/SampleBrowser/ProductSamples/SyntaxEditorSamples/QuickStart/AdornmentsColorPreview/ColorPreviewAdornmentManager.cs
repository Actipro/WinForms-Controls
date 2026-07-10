using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsColorPreview;

/// <summary>
/// Represents an adornment manager for a view that makes a color preview box under colors.
/// </summary>
/// <param name="view">The view to which this manager is attached.</param>
public class ColorPreviewAdornmentManager(IEditorView view) : DecorationAdornmentManagerBase<IEditorView, ColorPreviewTag>(view, _layerDefinition) {

	private static readonly AdornmentLayerDefinition _layerDefinition = new("ColorPreview", new Ordering(AdornmentLayerDefinitions.TextForeground.Key, OrderPlacement.After));

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Occurs when the adornment needs to be drawn.
	/// </summary>
	/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
	/// <param name="adornment">The <see cref="IAdornment"/> to draw.</param>
	private void OnDrawAdornment(TextViewDrawContext context, IAdornment adornment) {
		var lineHeight = (int)Math.Round(2 * context.DpiScale, MidpointRounding.AwayFromZero);
		var bounds = new Rectangle(
			adornment.Location.X - context.View.ScrollState.HorizontalAmount,
			adornment.Location.Y + adornment.Size.Height - lineHeight,
			adornment.Size.Width,
			lineHeight
		);
		bounds.Offset(context.TextAreaBounds.Location);

		if (adornment.Tag is Color color)
			context.FillRectangle(bounds, color);
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<ColorPreviewTag> tagRange, TextBounds bounds) {
		// Add the adornment to the layer
		AdornmentLayer.AddAdornment(reason, OnDrawAdornment, bounds.Rect, tagRange.Tag.Color, viewLine, tagRange.SnapshotRange, TextRangeTrackingModes.ExpandBothEdges, removedCallback: null);
	}

	/// <inheritdoc/>
	protected override void OnClosed() {
		// Remove any remaining adornments
		AdornmentLayer.RemoveAllAdornments(AdornmentChangeReason.ManagerClosed);

		base.OnClosed();
	}

}
