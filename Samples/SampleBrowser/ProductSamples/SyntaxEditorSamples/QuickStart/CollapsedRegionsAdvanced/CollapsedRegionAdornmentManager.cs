using System;
using System.Drawing;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Highlighting;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced {
    
    /// <summary>
	/// Represents an adornment manager for a view that renders intra-text placeholders for collapsed regions.
    /// </summary>
    public class CollapsedRegionAdornmentManager : IntraTextAdornmentManagerBase<IEditorView, CollapsedRegionTag> {
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <c>CollapsedRegionAdornmentManager</c> class.
		/// </summary>
		/// <param name="view">The view to which this manager is attached.</param>
		public CollapsedRegionAdornmentManager(IEditorView view) : base(view, AdornmentLayerDefinitions.CollapsedRegion, false) {}

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
		protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<CollapsedRegionTag> tagRange, TextBounds bounds) {
			if (tagRange == null)
				throw new ArgumentNullException("tagRange");

			// Create the adornment
			var adornment = new CollapsedRegionAdornment(tagRange);
			adornment.Width = bounds.Width;
			adornment.Height = bounds.Height;
			adornment.YDelta = (int)Math.Round(viewLine.Baseline - tagRange.Tag.Baseline, MidpointRounding.AwayFromZero);
			
			// Get brushes
			IHighlightingStyleRegistry registry = this.View.HighlightingStyleRegistry;
			IHighlightingStyle style = (registry != null ? registry[new DisplayItemClassificationTypeProvider().CollapsedText] : null);

			// Use the designated brush
			if ((style != null) && (style.Foreground.HasValue))
				adornment.Foreground = style.Foreground;

			// Add the adornment
			this.AdornmentLayer.AddAdornment(reason, adornment, new Point(bounds.X, bounds.Y), tagRange.Tag.Key, null);
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
