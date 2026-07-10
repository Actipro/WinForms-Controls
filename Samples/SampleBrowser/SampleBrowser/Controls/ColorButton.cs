using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// Represents a <see cref="Button"/> that selects colors.
	/// </summary>
	public class ColorButton : Button {

		private Color _color = Color.Red;
		private StandardColorPickerPopup? _dropDown;

		// --------------------------------------------------------------------------------------------------
		// EVENTS
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Occurs when the selected color is changed.
		/// </summary>
		[Category("Behavior")]
		[Description("Occurs when the selected color is changed.")]
		public event EventHandler? ColorChanged;

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public ColorButton() {
			// Initialize properties
			BackColor = SystemColors.Window;
			Text = null;
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Hides the color picker popup.
		/// </summary>
		private void HidePopup() {
			if (_dropDown is not null) {
				_dropDown.SelectedColorChanged -= OnDropDownSelectedColorChanged;
				_dropDown.Close();
				_dropDown = null;
			}

		}

		/// <summary>
		/// Occurs after the selected color is changed.
		/// </summary>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">The event data.</param>
		private void OnDropDownSelectedColorChanged(object? sender, EventArgs e)
			=> Color = ((StandardColorPickerPopup)sender!).SelectedColor;

		/// <summary>
		/// Shows the color picker popup.
		/// </summary>
		private void ShowPopup() {
			HidePopup();

			_dropDown = new StandardColorPickerPopup();
			_dropDown.SelectedColorChanged += OnDropDownSelectedColorChanged;

			// Show the dropdown
			_dropDown.DesktopLocation = PointToScreen(new Point(ClientRectangle.Left, ClientRectangle.Bottom));
			DpiAwareFormShowBehavior.ApplyTo(_dropDown);
			_dropDown.ShowPopup(owner: this, activate: true);
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// The <see cref="System.Drawing.Color"/> that is currently selected.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color Color {
			get => _color;
			set {
				// Quit if the same value is being set
				if (_color == value)
					return;

				// Set the new value
				_color = value;

				// Redraw
				Invalidate();

				// Raise an event
				OnColorChanged(EventArgs.Empty);
			}
		}

		/// <inheritdoc/>
		protected override void OnClick(EventArgs e) {
			ShowPopup();

			// Call the base method
			base.OnClick(e);
		}

		/// <summary>
		/// Raises the <see cref="ColorChanged"/> event.
		/// </summary>
		/// <param name="e">The event data.</param>
		/// <remarks>
		/// The <c>OnColorChanged</c> method also allows derived classes to handle the event without attaching a delegate. 
		/// This is the preferred technique for handling the event in a derived class.
		/// <para>
		/// When overriding <c>OnColorChanged</c> in a derived class, be sure to call the base class's 
		/// <c>OnColorChanged</c> method so that registered delegates receive the event.
		/// </para>
		/// </remarks>
		protected virtual void OnColorChanged(EventArgs e)
			=> ColorChanged?.Invoke(this, e);

		/// <inheritdoc/>
		protected override void OnPaint(PaintEventArgs e) {
			// Call the base method
			base.OnPaint(e);

			// Get the Graphics object
			var g = e.Graphics;

			// Handle scaling
			var scaleFactor = DpiHelper.GetDpiScale(this);

			// Fill the background
			g.FillRectangle(SystemBrushes.Window, ClientRectangle);

			// Draw border
			ControlPaint.DrawBorder3D(g, ClientRectangle, Border3DStyle.Sunken);

			// Set the glyph bounds
			var bounds = new Rectangle(
				ClientRectangle.Right - DpiHelper.ScaleInt32(19, scaleFactor),
				ClientRectangle.Top + 2,
				DpiHelper.ScaleInt32(17, scaleFactor),
				ClientRectangle.Height - 4
			);

			// If the button is pressed...
			int offset = 0;
			if ((MouseButtons == MouseButtons.Left) && (RectangleToScreen(ClientRectangle).Contains(MousePosition))) {
				g.FillRectangle(SystemBrushes.Control, bounds);
				g.DrawRectangle(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);
				offset = 1;
			}
			else {
				g.FillRectangle(SystemBrushes.Control, bounds);
				ControlPaint.DrawBorder3D(g, bounds, (Enabled ? Border3DStyle.Raised : Border3DStyle.RaisedInner));
			}

			// Draw the glyph
			int x = bounds.Left + offset + DpiHelper.ScaleInt32(5, scaleFactor);
			int y = bounds.Top + offset + ((bounds.Height - 4) / 2);
			var foregroundPen = (Enabled ? SystemPens.ControlText : SystemPens.GrayText);
			var foregroundBrush = (Enabled ? SystemBrushes.ControlText : SystemBrushes.GrayText);
			// M 0,0 L 6,0 L 3,3 Z
			var geometry = new GraphicsPath(
				[
					new PointF(0.0f, 0.0f),
					new PointF(6.0f, 0.0f),
					new PointF(3.0f, 3.0f)
				],
				[
					(byte)PathPointType.Start,
					(byte)PathPointType.Line,
					(byte)(PathPointType.Line | PathPointType.CloseSubpath)
				]
			);
			using (DrawingHelper.CreateTemporaryGraphicsState(g)) {
				g.TranslateTransform(x, y);
				g.ScaleTransform(scaleFactor.Width, scaleFactor.Height);

				// While it should be redundant, both fill and draw are required to get the triangle to render corners correctly
				g.FillPath(foregroundBrush, geometry);
				g.DrawPath(foregroundPen, geometry);
			}

			// Draw highlight
			if (Focused) {
				var textBounds = ClientRectangle;
				textBounds.Inflate(-3, -3);
				textBounds.Width = (bounds.Left - textBounds.Left - 1);
				g.FillRectangle(SystemBrushes.Highlight, textBounds);
			}

			// Set the color bounds
			bounds = ClientRectangle;
			bounds.Inflate(-4, -4);
			bounds.Width = bounds.Height;

			// Draw the color
			g.FillRectangle(new SolidBrush(_color), bounds);
			g.DrawRectangle(foregroundPen, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);

			// Get the color name
			var name = _color.R + ", " + _color.G + ", " + _color.B;
			if ((_color == Color.Empty) || (_color == Color.Transparent))
				name = "Automatic";
			else if (_color.IsNamedColor)
				name = _color.Name;

			// Draw color name
			using var format = new StringFormat(StringFormat.GenericTypographic);
			format.LineAlignment = StringAlignment.Center;
			bounds = new Rectangle(
				bounds.Right + DpiHelper.ScaleInt32(4, scaleFactor),
				ClientRectangle.Top,
				ClientRectangle.Width - bounds.Right - DpiHelper.ScaleInt32(20, scaleFactor),
				ClientRectangle.Height
			);
			g.DrawString(name, Font, (Enabled ? (Focused ? SystemBrushes.HighlightText : SystemBrushes.ControlText) : SystemBrushes.GrayText), bounds, format);

		}

		/// <inheritdoc/>
		protected override void OnResize(EventArgs e) {
			// Handle scaling
			var scaleFactor = DpiHelper.GetDpiScale(this);
			var standardHeight = DpiHelper.ScaleInt32(21, scaleFactor);

			// Ensure size
			if (Height != standardHeight) {
				Height = standardHeight;
				return;
			}

			// Call the base method
			base.OnResize(e);
		}

	}

}
