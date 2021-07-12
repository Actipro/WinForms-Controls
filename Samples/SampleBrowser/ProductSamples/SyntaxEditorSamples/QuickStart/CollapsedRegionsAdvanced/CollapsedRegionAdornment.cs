using System;
using System.Drawing;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Tagging;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Controls.Primitives;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CollapsedRegionsAdvanced {

	/// <summary>
	/// Represents a default implementation of a collapsed region adornment.
	/// </summary>
	public partial class CollapsedRegionAdornment : UIElement {
		
		private TagSnapshotRange<CollapsedRegionTag>	tagRange;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>CollapsedRegionAdornment</c> class.
		/// </summary>
		/// <param name="tagRange">The tag range for which the adornment is displayed.</param>
		internal CollapsedRegionAdornment(TagSnapshotRange<CollapsedRegionTag> tagRange) {
			if (tagRange == null)
				throw new ArgumentNullException("tagRange");

			// Initialize
			this.tagRange = tagRange;
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the <see cref="TextSnapshotRange"/> for which the adornment is displayed.
		/// </summary>
		/// <value>The <see cref="TextSnapshotRange"/> for which the adornment is displayed.</value>
		internal TextSnapshotRange SnapshotRange {
			get {
				return tagRange.SnapshotRange;
			}
		}
		
		/// <summary>
		/// Gets the text that is displayed in the adornment.
		/// </summary>
		/// <value>The text that is displayed in the adornment.</value>
		internal string Text {
			get {
				return tagRange.Tag.Text;
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
		/// Gets or sets the foreground color.
		/// </summary>
		/// <value>The foreground color.</value>
		public Color? Foreground { get; set; }

		/// <summary>
		/// Gets the <see cref="System.Windows.Forms.Cursor"/> that should be used when the mouse is over the element at the specified <see cref="Point"/>.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to examine.</param>
		/// <returns>The <see cref="System.Windows.Forms.Cursor"/> that should be used when the mouse is over the element at the specified <see cref="Point"/>.</returns>
		public override Cursor GetCursor(Point point) {
			return Cursors.Arrow;
		}
		
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
			return new Size(this.Width, this.Height);
		}
		
		/// <summary>
		/// Occurs when a mouse button is pressed.
		/// </summary>
		/// <param name="e">The <c>MouseEventArgs</c> that contains data related to this event.</param>
		protected override void OnMouseDown(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				var view = this.View;
				if (view != null) {
					// Focus the view
					view.Focus();

					// Select the collapsed region
					view.Selection.SelectRange(this.SnapshotRange, SelectionModes.ContinuousStream);
				}
			}
		}

		/// <summary>
		/// Occurs when rendering the control.
		/// </summary>
		/// <param name="e">The <c>PaintEventArgs</c> that contains data related to this event.</param>
		protected override void OnRender(PaintEventArgs e) {
			var bounds = this.Bounds;
			if ((bounds.Width > 2) && (bounds.Height > 2) && (e != null)) {
				var g = e.Graphics;

				var color = this.Foreground ?? Color.Gray;
				using (var pen = new Pen(color, 1)) {
					DrawingHelper.DrawRoundedRectangle(g, bounds, 2, 2, pen);
				}

				var view = this.View;
				if ((view != null) && (!string.IsNullOrEmpty(this.Text))) {
					using (var fontFamily = new FontFamily(view.DefaultFontFamilyName)) {
						using (var font = new Font(fontFamily, view.DefaultFontSize, FontStyle.Regular)) {
							using (var format = DrawingHelper.GetStringFormat(StringAlignment.Center, StringAlignment.Center, StringTrimming.None, false, false)) {
								DrawingHelper.DrawString(g, this.Text, font, color, bounds, format);
							}
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the adornment width.
		/// </summary>
		/// <value>The adornment width.</value>
		public int Width { get; set; }
		
		/// <summary>
		/// Gets or sets the Y-delta to apply for matching the baseline.
		/// </summary>
		/// <value>The Y-delta to apply for matching the baseline.</value>
		public int YDelta { get; set; }
		
	}

}
