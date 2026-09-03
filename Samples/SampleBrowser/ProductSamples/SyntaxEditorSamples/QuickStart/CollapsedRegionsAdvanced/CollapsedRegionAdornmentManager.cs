using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced;

/// <summary>
/// Represents an adornment manager for a view that renders intra-text placeholders for collapsed regions.
/// </summary>
/// <param name="view">The view to which this manager is attached.</param>
public class CollapsedRegionAdornmentManager(IEditorView view)
	: IntraTextAdornmentManagerBase<IEditorView, CollapsedRegionTag>(view, AdornmentLayerDefinitions.CollapsedRegion, isForLanguage: false) {

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<CollapsedRegionTag> tagRange, TextBounds bounds) {
		if (tagRange is null)
			throw new ArgumentNullException(nameof(tagRange));

		// Create the adornment
		var adornment = new CollapsedRegionAdornment(tagRange) {
			Width = bounds.Width,
			Height = bounds.Height,
			YDelta = (int)Math.Round(viewLine.Baseline - tagRange.Tag.Baseline, MidpointRounding.AwayFromZero)
		};

		// Get brushes
		var registry = View.HighlightingStyleRegistry;
		var style = registry?[new BuiltInClassificationTypeProvider().CollapsedText];

		// Use the designated brush
		if ((style is not null) && (style.Foreground.HasValue))
			adornment.Foreground = style.Foreground;

		// Add the adornment
		AdornmentLayer.AddAdornment(reason, adornment, new Point(bounds.X, bounds.Y), tagRange.Tag.Key, removedCallback: null);
	}

	/// <inheritdoc/>
	protected override void OnClosed() {
		// Remove any remaining adornments
		AdornmentLayer.RemoveAllAdornments(AdornmentChangeReason.ManagerClosed);

		// Call the base method
		base.OnClosed();
	}

}
