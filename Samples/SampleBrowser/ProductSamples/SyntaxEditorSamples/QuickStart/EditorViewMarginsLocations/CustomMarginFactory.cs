using System;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsLocations {

	/// <summary>
	/// A custom factory implementation that creates <see cref="IEditorViewMargin"/> objects for use within an <see cref="IEditorView"/>.
	/// </summary>
	public class CustomMarginFactory : IEditorViewMarginFactory {

		/// <summary>
		/// Creates the collection of <see cref="IEditorViewMargin"/> objects to place within a <see cref="IEditorView"/>.
		/// </summary>
		/// <param name="view">The <see cref="IEditorView"/> that will host the margins.</param>
		/// <returns>A <see cref="IEditorViewMarginCollection"/> containing the <see cref="IEditorViewMargin"/> objects that were created.</returns>
		public IEditorViewMarginCollection CreateMargins(IEditorView view) {
			IEditorViewMarginCollection margins = new EditorViewMarginCollection();

			// Add four margins in the scrollable area
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.ScrollableLeft));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.ScrollableTop));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.ScrollableRight));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.ScrollableBottom));

			// Add four margins in the fixed area
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.FixedLeft));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.FixedTop));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.FixedRight));
			margins.Add(new CustomMargin(view, EditorViewMarginPlacement.FixedBottom));

			return margins;
		}
		
	}
}
