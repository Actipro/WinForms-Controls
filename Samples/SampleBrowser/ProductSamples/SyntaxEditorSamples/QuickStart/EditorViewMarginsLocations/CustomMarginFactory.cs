using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsLocations;

/// <summary>
/// A custom factory implementation that creates <see cref="IEditorViewMargin"/> objects for use within an <see cref="IEditorView"/>.
/// </summary>
public class CustomMarginFactory : IEditorViewMarginFactory {

	/// <inheritdoc cref="IEditorViewMarginFactory.CreateMargins"/>
	public IEditorViewMarginCollection CreateMargins(IEditorView view) {
		return new EditorViewMarginCollection {
			// Add four margins in the scrollable area
			new CustomMargin(view, EditorViewMarginPlacement.ScrollableLeft),
			new CustomMargin(view, EditorViewMarginPlacement.ScrollableTop),
			new CustomMargin(view, EditorViewMarginPlacement.ScrollableRight),
			new CustomMargin(view, EditorViewMarginPlacement.ScrollableBottom),

			// Add four margins in the fixed area
			new CustomMargin(view, EditorViewMarginPlacement.FixedLeft),
			new CustomMargin(view, EditorViewMarginPlacement.FixedTop),
			new CustomMargin(view, EditorViewMarginPlacement.FixedRight),
			new CustomMargin(view, EditorViewMarginPlacement.FixedBottom)
		};
	}

}
