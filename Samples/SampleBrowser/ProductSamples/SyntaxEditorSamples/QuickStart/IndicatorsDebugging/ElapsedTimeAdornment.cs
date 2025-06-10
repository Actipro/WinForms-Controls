using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Primitives;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.IndicatorsDebugging {

	/// <summary>
	/// Represents a default implementation of a collapsed region adornment.
	/// </summary>
	public partial class ElapsedTimeAdornment : UIElement {
		
		private TagSnapshotRange<ElapsedTimeTag>	tagRange;

		private const float FontSizeAdjustment = 0.9f;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>ElapsedTimeAdornment</c> class.
		/// </summary>
		/// <param name="tagRange">The tag range for which the adornment is displayed.</param>
		internal ElapsedTimeAdornment(TagSnapshotRange<ElapsedTimeTag> tagRange) {
			if (tagRange == null)
				throw new ArgumentNullException("tagRange");

			// Initialize
			this.tagRange = tagRange;
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the text that is displayed in the adornment.
		/// </summary>
		/// <value>The text that is displayed in the adornment.</value>
		internal string Text {
			get {
				return tagRange.Tag.TimeSpanText;
			}
		}

		/// <summary>
		/// Gets the owner view.
		/// </summary>
		/// <value>The owner view.</value>
		private EditorView View {
			get {
				return (EditorView)((IUIElement)this).FindAncestor(typeof(EditorView));
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Gets or sets the adornment height.
		/// </summary>
		/// <value>The adornment height.</value>
		public int Height { get; set; }
		
		/// <summary>
		/// Measures the size required for the element and its child elements.
		/// </summary>
		/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
		/// <param name="availableSize">The available size.</param>
		/// <returns>The desired size.</returns>
		protected override Size MeasureOverride(Graphics g, Size availableSize) {
			var width = 0;

			var view = this.View;
			var text = this.Text;
			if ((view != null) && (!string.IsNullOrEmpty(text))) {
				var fontFamily = SystemFonts.MessageBoxFont.FontFamily;
				var fontSize = (float)Math.Round(view.DefaultFontSize * FontSizeAdjustment, MidpointRounding.AwayFromZero);

				using (var font = new Font(fontFamily, fontSize, FontStyle.Regular)) {
					using (var format = DrawingHelper.GetStringFormat(StringAlignment.Near, StringAlignment.Center, StringTrimming.None, false, false)) {
						width = DrawingHelper.MeasureString(g, this.Text, font, format).Width;
					}
				}
			}

			return new Size(width, this.Height);
		}
		
		/// <summary>
		/// Occurs when rendering the control.
		/// </summary>
		/// <param name="e">The <c>PaintEventArgs</c> that contains data related to this event.</param>
		protected override void OnRender(PaintEventArgs e) {
			var bounds = this.Bounds;
			if ((bounds.Width > 2) && (bounds.Height > 2) && (e != null)) {
				var view = this.View;
				var text = this.Text;
				if ((view != null) && (!string.IsNullOrEmpty(text))) {
					var fontFamily = SystemFonts.MessageBoxFont.FontFamily;
					var fontSize = (float)Math.Round(view.DefaultFontSize * FontSizeAdjustment, MidpointRounding.AwayFromZero);

					using (var font = new Font(fontFamily, fontSize, FontStyle.Regular)) {
						using (var format = DrawingHelper.GetStringFormat(StringAlignment.Near, StringAlignment.Center, StringTrimming.None, false, false)) {
							DrawingHelper.DrawString(e.Graphics, text, font, Color.Gray, bounds, format);
						}
					}
				}
			}
		}
		
	}

}
