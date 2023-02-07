using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Represents a <see cref="Button"/> that selects colors.
	/// </summary>
	public class ColorButton : Button {

		private	Color							color			= Color.Red;
		private StandardColorPickerPopup		dropDown;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENTS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the selected color is changed.
		/// </summary>
		[
			Category("Behavior"),
			Description("Occurs when the selected color is changed.")
		]
		public event EventHandler ColorChanged;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>ColorButton</c> class.
		/// </summary>
		/// <remarks>
		/// The default constructor initializes all fields to their default values.
		/// </remarks>
		public ColorButton() {
			// Initialize properties
			this.BackColor = SystemColors.Window;
			this.Text = null;
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// EVENT HANDLERS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs after the selected color is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		private void dropDown_SelectedColorChanged(object sender, EventArgs e) {
			this.Color = dropDown.SelectedColor;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PRIVATE PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Hides the color picker popup.
		/// </summary>
		private void HidePopup() {
			if (dropDown != null) {
				dropDown.SelectedColorChanged -= new EventHandler(this.dropDown_SelectedColorChanged);
				dropDown.Close();
				dropDown = null;
			}

		}

		/// <summary>
		/// Shows the color picker popup.
		/// </summary>
		private void ShowPopup() {
			HidePopup();

			dropDown = new StandardColorPickerPopup();
			dropDown.SelectedColorChanged += new EventHandler(this.dropDown_SelectedColorChanged);

			// Show the dropdown
			dropDown.DesktopLocation = this.PointToScreen(new Point(this.ClientRectangle.Left, this.ClientRectangle.Bottom));
			DpiAwareFormShowBehavior.ApplyTo(dropDown);
			dropDown.ShowPopup(owner: this, activate: true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets or sets the <see cref="System.Drawing.Color"/> that is currently selected.
		/// </summary>
		/// <value>The <see cref="System.Drawing.Color"/> that is currently selected.</value>
		public Color Color {
			get {
				return color;
			}
			set {
				// Quit if the same value is being set
				if (color == value)
					return;

				// Set the new value
				color = value;

				// Redraw
				this.Invalidate();

				// Raise an event
				this.OnColorChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Raises the <c>Click</c> event.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// The <c>OnClick</c> method also allows derived classes to handle the event without attaching a delegate. 
		/// This is the preferred technique for handling the event in a derived class.
		/// <para>
		/// When overriding <c>OnClick</c> in a derived class, be sure to call the base class's <c>OnClick</c> 
		/// method so that registered delegates receive the event.
		/// </para>
		/// </remarks>
		protected override void OnClick(EventArgs e) {
			ShowPopup();

			// Call the base method
			base.OnClick(e);
		}

		/// <summary>
		/// Raises the <see cref="ColorChanged"/> event.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// The <c>OnColorChanged</c> method also allows derived classes to handle the event without attaching a delegate. 
		/// This is the preferred technique for handling the event in a derived class.
		/// <para>
		/// When overriding <c>OnColorChanged</c> in a derived class, be sure to call the base class's 
		/// <c>OnColorChanged</c> method so that registered delegates receive the event.
		/// </para>
		/// </remarks>
		protected virtual void OnColorChanged(EventArgs e) {
			this.ColorChanged?.Invoke(this, e);
		}

		/// <summary>
		/// Raises the <c>Paint</c> event.
		/// </summary>
		/// <param name="e">An <c>PaintEventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// The <c>OnPaint</c> method also allows derived classes to handle the event without attaching a delegate. 
		/// This is the preferred technique for handling the event in a derived class.
		/// <para>
		/// When overriding <c>OnPaint</c> in a derived class, be sure to call the base class's <c>OnPaint</c> 
		/// method so that registered delegates receive the event.
		/// </para>
		/// </remarks>
		protected override void OnPaint(PaintEventArgs e) {
			// Call the base method
			base.OnPaint(e);

			// Get the Graphics object
			Graphics g = e.Graphics;

			// Handle scaling
			var scaleFactor = DpiHelper.GetDpiScale(this);

			// Fill the background
			g.FillRectangle(SystemBrushes.Window, this.ClientRectangle);

			// Draw border
			ControlPaint.DrawBorder3D(g, this.ClientRectangle, Border3DStyle.Sunken);

			// Set the glyph bounds
			Rectangle bounds = new Rectangle(
				this.ClientRectangle.Right - DpiHelper.ScaleInt32(19, scaleFactor),
				this.ClientRectangle.Top + 2,
				DpiHelper.ScaleInt32(17, scaleFactor),
				this.ClientRectangle.Height - 4);

			// If the button is pressed...
			int offset = 0;
			if ((Control.MouseButtons == MouseButtons.Left) && (this.RectangleToScreen(this.ClientRectangle).Contains(Control.MousePosition))) {
				g.FillRectangle(SystemBrushes.Control, bounds);
                g.DrawRectangle(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);				
				offset = 1;
			}
			else {
				g.FillRectangle(SystemBrushes.Control, bounds);
				ControlPaint.DrawBorder3D(g, bounds, (this.Enabled ? Border3DStyle.Raised : Border3DStyle.RaisedInner));
			}

			// Draw the glyph
			int x = bounds.Left + offset + DpiHelper.ScaleInt32(5, scaleFactor);
			int y = bounds.Top + offset + (int)((bounds.Height - 4) / 2);
			var foregroundPen = (this.Enabled ? SystemPens.ControlText : SystemPens.GrayText);
			var foregroundBrush = (this.Enabled ? SystemBrushes.ControlText : SystemBrushes.GrayText);
			// M 0,0 L 6,0 L 3,3 Z
			var geometry = new GraphicsPath(
				new PointF[] {
					new PointF(0.0f, 0.0f),
					new PointF(6.0f, 0.0f),
					new PointF(3.0f, 3.0f)
				},
				new byte[] {
					(byte)PathPointType.Start,
					(byte)PathPointType.Line,
					(byte)(PathPointType.Line | PathPointType.CloseSubpath)
				}
			);
			using (DrawingHelper.CreateTemporaryGraphicsState(g)) {
				g.TranslateTransform(x, y);
				g.ScaleTransform(scaleFactor.Width, scaleFactor.Height);

				// While it should be redundant, both fill and draw are required to get the triangle to render corners correctly
				g.FillPath(foregroundBrush, geometry);
				g.DrawPath(foregroundPen, geometry);
			}

			// Draw highlight
			if (this.Focused) {
				Rectangle textBounds = this.ClientRectangle;
				textBounds.Inflate(-3, -3);
				textBounds.Width = (bounds.Left - textBounds.Left - 1);
				g.FillRectangle(SystemBrushes.Highlight, textBounds);
			}

			// Set the color bounds
			bounds = this.ClientRectangle;
			bounds.Inflate(-4, -4);
			bounds.Width = bounds.Height;

			// Draw the color
			g.FillRectangle(new SolidBrush(color), bounds);
			g.DrawRectangle(foregroundPen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);				

			// Get the color name
			string name = color.R + ", " + color.G + ", " + color.B;
			if ((color == Color.Empty) || (color == Color.Transparent))
				name = "Automatic";
			else if (color.IsNamedColor)
				name = color.Name;

			// Draw color name
			using (StringFormat format = new StringFormat(StringFormat.GenericTypographic)) {
				format.LineAlignment = StringAlignment.Center;
				bounds = new Rectangle(
					bounds.Right + DpiHelper.ScaleInt32(4, scaleFactor),
					this.ClientRectangle.Top,
					this.ClientRectangle.Width - bounds.Right - DpiHelper.ScaleInt32(20, scaleFactor),
					this.ClientRectangle.Height);
				g.DrawString(name, Font, (this.Enabled ? (this.Focused ? SystemBrushes.HighlightText : SystemBrushes.ControlText) : SystemBrushes.GrayText), bounds, format);
			}

		}

		/// <summary>
		/// Raises the <see cref="Resize"/> event.
		/// </summary>
		/// <param name="e">An <c>EventArgs</c> that contains the event data.</param>
		/// <remarks>
		/// The <c>OnResize</c> method also allows derived classes to handle the event without attaching a delegate. 
		/// This is the preferred technique for handling the event in a derived class.
		/// <para>
		/// When overriding <c>OnResize</c> in a derived class, be sure to call the base class's 
		/// <c>OnResize</c> method so that registered delegates receive the event.
		/// </para>
		/// </remarks>
		protected override void OnResize(EventArgs e) {
			// Handle scaling
			var scaleFactor = DpiHelper.GetDpiScale(this);
			var standardHeight = DpiHelper.ScaleInt32(21, scaleFactor);

			// Ensure size
			if (this.Height != standardHeight) {
				this.Height = standardHeight;
				return;
			}

			// Call the base method
			base.OnResize(e);
		}

	}

}
