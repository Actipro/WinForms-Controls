using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.PrinterViewMarginsCustom;

/// <summary>
/// A custom factory implementation that creates <see cref="IPrinterViewMargin"/> objects for use within an <see cref="IPrinterView"/>.
/// </summary>
public class CustomMarginFactory : IPrinterViewMarginFactory {

	/// <inheritdoc cref="IPrinterViewMarginFactory.CreateMargins" />
	public IPrinterViewMarginCollection CreateMargins(IPrinterView view) {
		return new PrinterViewMarginCollection {
			new CustomMargin(view)
		};
	}

}
