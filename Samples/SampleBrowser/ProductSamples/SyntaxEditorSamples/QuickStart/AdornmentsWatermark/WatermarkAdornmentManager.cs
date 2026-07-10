using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsWatermark;

/// <summary>
/// Represents an adornment manager for a view that makes a watermark effect on the text area.
/// </summary>
public class WatermarkAdornmentManager : AdornmentManagerBase<IEditorView> {

	private static readonly AdornmentLayerDefinition _layerDefinition = new("Watermark", new Ordering(AdornmentLayerDefinitions.Selection.Key, OrderPlacement.After));
	private readonly IAdornment _watermarkAdornment;

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="view">The view to which this manager is attached.</param>
	public WatermarkAdornmentManager(IEditorView view) : base(view, _layerDefinition) {
		// Only let this manager be active when the view has focus
		IsActive = view.HasFocus;

		// Create the watermark adornment
		_watermarkAdornment = CreateWatermarkAdornment();
	}

	// --------------------------------------------------------------------------------------------------
	// NON-PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Creates the watermark adornment.
	/// </summary>
	private IAdornment CreateWatermarkAdornment() {
		// Add the adornment to the layer
		return AdornmentLayer.AddAdornment(AdornmentChangeReason.Other, OnDrawAdornment, Rectangle.Empty, tag: null, removedCallback: null);
	}

	/// <summary>
	/// Occurs when the adornment needs to be drawn.
	/// </summary>
	/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
	/// <param name="adornment">The <see cref="IAdornment"/> to draw.</param>
	private void OnDrawAdornment(TextViewDrawContext context, IAdornment adornment) {
		var color = Color.FromArgb(0xff, 0xe8, 0xe8, 0xe8);
		using (var textLayout = context.Canvas.CreateTextLayout("Watermark", float.MaxValue, "Arial", fontSize: 82, color)) {
			var textLayoutLine = textLayout.Lines[0];
			var textAreaBounds = context.TextAreaBounds;
			var location = new Point(
				textAreaBounds.X + (textAreaBounds.Width - textLayoutLine.Width) / 2,
				textAreaBounds.Y + (textAreaBounds.Height - textLayoutLine.Height) / 2
			);
			context.DrawText(location, textLayoutLine);
		}
	}

	// --------------------------------------------------------------------------------------------------
	// PUBLIC PROCEDURES
	// --------------------------------------------------------------------------------------------------

	/// <inheritdoc/>
	protected override void OnClosed() {
		// Remove any remaining adornments
		AdornmentLayer.RemoveAllAdornments(AdornmentChangeReason.ManagerClosed);

		base.OnClosed();
	}

}
