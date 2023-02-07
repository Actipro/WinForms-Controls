using System;
using System.Drawing;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.AdornmentsColorPreview {

    /// <summary>
	/// Represents an adornment manager for a view that makes a color preview box under colors.
    /// </summary>
    public class ColorPreviewAdornmentManager : DecorationAdornmentManagerBase<IEditorView, ColorPreviewTag> {

		private static AdornmentLayerDefinition layerDefinition = 
			new AdornmentLayerDefinition("ColorPreview", new Ordering(AdornmentLayerDefinitions.TextForeground.Key, OrderPlacement.After));

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <c>ColorPreviewAdornmentManager</c> class.
		/// </summary>
		/// <param name="view">The view to which this manager is attached.</param>
		public ColorPreviewAdornmentManager(IEditorView view) : base(view, layerDefinition) {}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Occurs when the adornment needs to be drawn.
		/// </summary>
		/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
		/// <param name="adornment">The <see cref="IAdornment"/> to draw.</param>
		private void OnDrawAdornment(TextViewDrawContext context, IAdornment adornment) {
			var lineHeight = (int)Math.Round(2 * context.DpiScale, MidpointRounding.AwayFromZero);
			var bounds = new Rectangle(adornment.Location.X - context.View.ScrollState.HorizontalAmount, adornment.Location.Y + adornment.Size.Height - lineHeight, adornment.Size.Width, lineHeight);
			bounds.Offset(context.TextAreaBounds.Location);

			var color = (Color)adornment.Tag;
			context.FillRectangle(bounds, color);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Adds an adornment to the <see cref="AdornmentLayer"/>.
		/// </summary>
		/// <param name="reason">An <see cref="AdornmentChangeReason"/> indicating the add reason.</param>
		/// <param name="viewLine">The current <see cref="ITextViewLine"/> being examined.</param>
		/// <param name="tagRange">The <see cref="ITag"/> and the range it covers.</param>
		/// <param name="bounds">The text bounds in which to render an adornment.</param>
		protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<ColorPreviewTag> tagRange, TextBounds bounds) {
			// Add the adornment to the layer
			this.AdornmentLayer.AddAdornment(reason, OnDrawAdornment, bounds.Rect, tagRange.Tag.Color, viewLine, tagRange.SnapshotRange, TextRangeTrackingModes.ExpandBothEdges, null);
		}

		/// <summary>
		/// Occurs when the manager is closed and detached from the view.
		/// </summary>
		/// <remarks>
		/// Overrides should release any event handlers set up in the manager's constructor.
		/// </remarks>
		protected override void OnClosed() {
			// Remove any remaining adornments
			this.AdornmentLayer.RemoveAllAdornments(AdornmentChangeReason.ManagerClosed);
		
			// Call the base method
			base.OnClosed();
		}

    }
	
}
