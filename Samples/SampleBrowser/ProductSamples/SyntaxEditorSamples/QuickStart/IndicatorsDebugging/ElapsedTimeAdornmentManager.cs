using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Adornments.Implementation;
using System;
using System.Drawing;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging {

	/// <summary>
	/// Represents an adornment manager for a view that renders ealpsed times.
	/// </summary>
	public class ElapsedTimeAdornmentManager : IntraTextAdornmentManagerBase<IEditorView, ElapsedTimeTag> {

		private static AdornmentLayerDefinition layerDefinition = 
			new AdornmentLayerDefinition("ElapsedTime", new Ordering(AdornmentLayerDefinitions.TextForeground.Key, OrderPlacement.Before));

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes a new instance of the <c>IntraTextNoteAdornmentManager</c> class.
		/// </summary>
		/// <param name="view">The view to which this manager is attached.</param>
		public ElapsedTimeAdornmentManager(IEditorView view) : base(view, layerDefinition) {}
		
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
		protected override void AddAdornment(AdornmentChangeReason reason, ITextViewLine viewLine, TagSnapshotRange<ElapsedTimeTag> tagRange, TextBounds bounds) {
			if (tagRange == null)
				throw new ArgumentNullException("tagRange");

			// Create the adornment
			var adornment = new ElapsedTimeAdornment(tagRange);
			adornment.Height = bounds.Height;

			// Add the adornment to the layer
			this.AdornmentLayer.AddAdornment(reason, adornment, new Point(bounds.X + this.View.DefaultCharacterWidth, bounds.Y), tagRange.Tag.Key, null);
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
