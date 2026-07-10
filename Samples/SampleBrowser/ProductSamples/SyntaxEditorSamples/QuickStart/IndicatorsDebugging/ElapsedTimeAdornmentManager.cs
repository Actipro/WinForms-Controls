using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging;

/// <summary>
/// Represents an adornment manager for a view that renders elapsed times.
/// </summary>
/// <param name="view">The view to which this manager is attached.</param>
public class ElapsedTimeAdornmentManager(IEditorView view) : IntraTextAdornmentManagerBase<IEditorView, ElapsedTimeTag>(view, _layerDefinition) {

	private static readonly AdornmentLayerDefinition _layerDefinition = new("ElapsedTime", new Ordering(AdornmentLayerDefinitions.TextForeground.Key, OrderPlacement.Before));

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<ElapsedTimeTag> tagRange, TextBounds bounds) {
		if (tagRange is null)
			throw new ArgumentNullException(nameof(tagRange));

		// Create the adornment
		var adornment = new ElapsedTimeAdornment(tagRange) {
			Height = bounds.Height
		};

		// Add the adornment to the layer
		AdornmentLayer.AddAdornment(reason, adornment, new Point(bounds.X + View.DefaultCharacterWidth, bounds.Y), tagRange.Tag.Key, removedCallback: null);
	}


	/// <inheritdoc/>
	protected override void OnClosed() {
		// Remove any remaining adornments
		AdornmentLayer.RemoveAllAdornments(AdornmentChangeReason.ManagerClosed);

		base.OnClosed();
	}

}
