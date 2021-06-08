using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ActiproSoftware.Text.Utility;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Margins;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsCustom {

	/// <summary>
	/// Represents an implementation of a custom margin for an <see cref="IEditorView"/>.
	/// </summary>
	public class CustomMargin : EditorViewMarginBase {
		
		private readonly int MinWidth = 36;
		private readonly Padding Padding = new Padding(4, 0, 2, 0);

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>EditorLineNumberMargin</c> class.
		/// </summary>
		/// <param name="view">The <see cref="IEditorView"/> that will host the margin.</param>
		public CustomMargin(IEditorView view) : base(view, "Custom", EditorViewMarginPlacement.ScrollableLeft,
			new Ordering[] {
				new Ordering(EditorViewMarginKeys.Indicator, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.LineNumber, OrderPlacement.After),
				new Ordering(EditorViewMarginKeys.Selection, OrderPlacement.After),
			}) {

			// Attach to events
			view.MarginsDestroyed += OnViewMarginsDestroyed;
			view.TextAreaLayout += OnViewTextAreaLayout;
		}


		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Returns the resolved font data.
		/// </summary>
		/// <param name="fontFamilyName">Returns the font family name.</param>
		/// <param name="fontSize">Returns the font size.</param>
		/// <param name="bold">Returns whether to use bold.</param>
		/// <param name="italic">Returns whether to use italic.</param>
		private void GetFontData(out string fontFamilyName, out float fontSize, out bool bold, out bool italic) {
			fontFamilyName = "Consolas";
			fontSize = 10;
			bold = false;
			italic = false;
		}

		/// <summary>
		/// Measures the margin width.
		/// </summary>
		/// <returns>The desired width.</returns>
		private int MeasureWidth() {
			using (var g = this.CreateGraphics()) {
				return this.MeasureWidth(g);
			}
		}

		/// <summary>
		/// Measures the margin width.
		/// </summary>
		/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
		/// <returns>The desired width.</returns>
		private int MeasureWidth(Graphics g) {
			// Get the largest possible character count text
			var lineText = View.CurrentSnapshot.Length.ToString(CultureInfo.CurrentCulture) + " chars";

			// Get the resolved font data
			string fontFamilyName;
			float fontSize;
			bool bold, italic;
			this.GetFontData(out fontFamilyName, out fontSize, out bold, out italic);
			var fontStyle = FontStyle.Regular | (italic ? FontStyle.Italic : FontStyle.Regular) | (bold ? FontStyle.Bold : FontStyle.Regular);

			// Measure the text
			int lineTextWidth;
			using (var font = new Font(fontFamilyName, fontSize, fontStyle)) {
				// Workaround for trailing space bug in MeasureText
				var fontHeight = font.GetHeight();
				var extraSpace = fontHeight / 2;
				lineTextWidth = (int)Math.Ceiling(g.MeasureString(lineText, font).Width - extraSpace);
			}

			// Calculate the margin width
			var marginWidth = (int)Math.Ceiling(Math.Max((double)this.MinWidth, this.Padding.Left + lineTextWidth + this.Padding.Right));

			return marginWidth;
		}

		/// <summary>
		/// Occurs when the view's margins are destroyed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnViewMarginsDestroyed(object sender, EventArgs e) {
			// Detach from events
			View.MarginsDestroyed -= OnViewMarginsDestroyed;
			View.TextAreaLayout -= OnViewTextAreaLayout;
		}
			
		/// <summary>
		/// Occurs when a view text area layout occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="TextViewTextAreaLayoutEventArgs"/> that contains the event data.</param>
		private void OnViewTextAreaLayout(object sender, TextViewTextAreaLayoutEventArgs e) {

			// If there was a snapshot change (i.e. something was edited to trigger the layout) and the margin is visible...
			if ((e != null) && (this.Visibility == UI.WinForms.Controls.Visibility.Visible)) {
				// Determine min width
				int digitCount = View.CurrentSnapshot.Length.ToString(CultureInfo.CurrentCulture).Length;

				// Get the formatted text
				string characterCount = digitCount.ToString(CultureInfo.CurrentCulture) + " chars";

				// Measure the width
				var marginWidth = this.MeasureWidth();

				// If the required margin width is different than the current margin width, invalidate the margin measure
				if (marginWidth != this.DesiredSize.Width)
					this.InvalidateMeasure();
			}

		}


		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Draws the margin and its content.
		/// </summary>
		/// <param name="context">The <see cref="TextViewDrawContext"/> to use for rendering.</param>
		public override void Draw(TextViewDrawContext context) {

			var marginBounds = context.Bounds;
			var canvas = context.Canvas;
			var padding = this.Padding.Right;

			// Fill the background
			var background = context.LineNumberMarginBackground;
			if (background != null)
				context.FillRectangle(marginBounds, background);

			using (var textBatch = canvas.CreateTextBatch()) {
				// Get the resolved font data
				string fontFamilyName;
				float fontSize;
				bool bold, italic;
				this.GetFontData(out fontFamilyName, out fontSize, out bold, out italic);

				var visibleViewLines = this.View.VisibleViewLines;
				foreach (var viewLine in visibleViewLines) {
					// Get the number of characters on the line
					string characterCount = viewLine.CharacterCount.ToString(CultureInfo.CurrentCulture) + " chars";

					if (!string.IsNullOrEmpty(characterCount)) {
						// Get the foreground
						var foreground = Color.Black;
						if (viewLine.CharacterCount > 60)
							foreground = Color.Red;
						else if (viewLine.CharacterCount > 40)
							foreground = Color.DarkGoldenrod;
						else if (viewLine.CharacterCount > 20)
							foreground = Color.DarkGreen;

						// Create a text layout
						using (var textLayout = canvas.CreateTextLayout(characterCount, 0, fontFamilyName, fontSize, foreground)) {
							if (bold)
								textLayout.SetFontWeight(0, characterCount.Length, FontWeights.Bold);
							if (italic)
								textLayout.SetFontStyle(0, characterCount.Length, FontStyles.Italic);

							// Use the same native renderer for all text for maximum efficiency
							textLayout.RunTextFormatter(textBatch);

							// Get the first line
							var firstLayoutLine = textLayout.Lines[0];

							// Draw the character count
							var y = marginBounds.Y + viewLine.TextBounds.Y + (int)Math.Round(viewLine.Baseline - firstLayoutLine.Baseline, MidpointRounding.AwayFromZero);
							context.DrawText(new Point(marginBounds.Right - firstLayoutLine.Width - padding, y), firstLayoutLine);
						}
					}
				}
			}
		}

		/// <summary>
		/// Measures the size required for the element and its child elements.
		/// </summary>
		/// <param name="g">The <c>Graphics</c> to use for measurement.</param>
		/// <param name="availableSize">The available size.</param>
		/// <returns>The desired size.</returns>
		protected override Size MeasureOverride(Graphics g, Size availableSize) {
			if (this.Visibility == UI.WinForms.Controls.Visibility.Collapsed)
				return new Size(0, 0);

			var dpiScale = g.DpiX / 96.0f;

			var width = MeasureWidth(g);
			return new Size((int)(width * dpiScale), availableSize.Height);
		}

	}

}