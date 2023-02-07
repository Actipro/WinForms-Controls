using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// A <see cref="ListBox"/> that shows product samples.
	/// </summary>
	public class NavigationListBox : ListBox {

		private SizeF scaleFactor;
		private int borderThickness;
		private int familyInfoHeight;
		private int familyInfoTextIndent;
		private int familySeparatorHeight;
		private Size iconSize;
		private int itemCategoryHeaderHeight;
		private int itemInfoHeight;
		private int itemInfoTextIndent;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>NavigationListBox</c> class. 
		/// </summary>
		public NavigationListBox() {
			// Initialize layout values at current DPI
			ScaleLayoutValuesForDpi(DpiHelper.GetDpiScale(this.DeviceDpi));

			// Set properties
			this.DrawMode = DrawMode.OwnerDrawVariable;

			// Set styles
			this.SetStyle(ControlStyles.ResizeRedraw, true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Refreshes configuration based on current DPI settings.
		/// </summary>
		private void ScaleLayoutValuesForDpi(SizeF scaleFactor) {
			this.scaleFactor = scaleFactor;

			borderThickness = 1; // Borders currently do not support scaling
			familyInfoHeight = DpiHelper.ScaleInt32(36, scaleFactor);
			familyInfoTextIndent = DpiHelper.ScaleInt32(8, scaleFactor);
			familySeparatorHeight = DpiHelper.ScaleInt32(16, scaleFactor);
			iconSize = DpiHelper.ScaleSize(new Size(16, 16), scaleFactor);
			itemCategoryHeaderHeight = DpiHelper.ScaleInt32(24, scaleFactor);
			itemInfoHeight = DpiHelper.ScaleInt32(24, scaleFactor);
			itemInfoTextIndent = DpiHelper.ScaleInt32(30, scaleFactor);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		protected override void OnDpiChangedAfterParent(EventArgs e) {
			base.OnDpiChangedAfterParent(e);

			// Items must be completely refreshed when DPI changes
			this.RefreshItems();
		}

		/// <summary>
		/// Raises the <c>DrawItem</c> event.
		/// </summary>
		/// <param name="e">A <c>DrawItemEventArgs</c> that contains the event data.</param>
		protected override void OnDrawItem(DrawItemEventArgs e) {
			if ((e.Index < 0) || (e.Index >= this.Items.Count))
				return;

			var colorScheme = WindowsColorScheme.WindowsDefault;

			var selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
			
			// Get the info
			var itemInfo = this.Items[e.Index] as ProductItemInfo;
			var familyInfo = (itemInfo != null ? null : this.Items[e.Index] as ProductFamilyInfo);

			// Determine bounds
			var separatorHeaderBounds = (itemInfo != null)
				? itemInfo.IsCategoryHeaderRequired 
					? new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, itemCategoryHeaderHeight) 
					: Rectangle.Empty
				: !familyInfo.IsIntroduction
					? new Rectangle(e.Bounds.Left, e.Bounds.Top + familySeparatorHeight - borderThickness, e.Bounds.Width, borderThickness) // Only allocate enough space for the border
					: Rectangle.Empty
				;
			var selectableItemHeight = (itemInfo != null ? itemInfoHeight : familyInfoHeight);
			var selectableBounds = new Rectangle(e.Bounds.Left, e.Bounds.Bottom - selectableItemHeight, e.Bounds.Width, selectableItemHeight);
			Rectangle textBounds;
			Size size;

			// Get a string format
			using (var format = DrawingHelper.GetStringFormat(StringAlignment.Near, StringAlignment.Center, StringTrimming.EllipsisCharacter, false, false)) {
				// Get the foreground text color
				var textColor = UIColor.FromMix(colorScheme.GetKnownColor(KnownColor.WindowText), colorScheme.GetKnownColor(KnownColor.Window), 0.25f).ToColor();

				// If there is a separator header...
				if (!separatorHeaderBounds.IsEmpty) {

					// Fill the background
					SolidColorBackgroundFill.Draw(e.Graphics, separatorHeaderBounds, UIColor.FromMix(colorScheme.GetKnownColor(KnownColor.Window), colorScheme.GetKnownColor(KnownColor.Control), 0.5f).ToColor());
					// Draw the separators
					Debug.Assert(borderThickness == 1, "SimpleBorder.Draw only supports 1px borders");
					SimpleBorder.Draw(e.Graphics, separatorHeaderBounds, SimpleBorderStyle.Solid, colorScheme.GetKnownColor(KnownColor.ControlLight), Sides.Top | Sides.Bottom);

					// Draw the name
					if (itemInfo != null) {
						textBounds = new Rectangle(separatorHeaderBounds.Left + DpiHelper.ScaleInt32(8, scaleFactor), separatorHeaderBounds.Top + borderThickness, separatorHeaderBounds.Width - iconSize.Width, separatorHeaderBounds.Height);
						// Determine the font size relative to the configured font
						var fontSize = (float)Math.Floor(this.Font.Size * 0.9F); // 90% reduction in size since using all upper-case letters
						using (var font = new Font(this.Font.FontFamily, fontSize)) {
							DrawingHelper.DrawString(e.Graphics, itemInfo.Category.ToUpperInvariant(), font, colorScheme.GetKnownColor(KnownColor.GrayText), textBounds, format);
						}
					}
				}

				// Fill the selectable background
				if (selected) {
					MultiColorLinearGradient.Draw(e.Graphics, selectableBounds, selectableBounds, 
						colorScheme.BarButtonHotBackGradientBegin,
						colorScheme.BarButtonHotBackGradientMiddle,
						colorScheme.BarButtonHotBackGradientEnd, 90);
					Debug.Assert(borderThickness == 1, "SimpleBorder.Draw only supports 1px borders");
					SimpleBorder.Draw(e.Graphics, selectableBounds, SimpleBorderStyle.Solid, colorScheme.BarButtonHotBorder);
				}
				else
					SolidColorBackgroundFill.Draw(e.Graphics, selectableBounds, colorScheme.GetKnownColor(KnownColor.Window));

				// Draw icon
				if (itemInfo != null) {
					var iconLocation = new Point(selectableBounds.Left + DpiHelper.ScaleInt32(10, scaleFactor), selectableBounds.Top + (int)Math.Round((selectableBounds.Height - iconSize.Height) / 2.0));
					var iconBounds = new Rectangle(iconLocation, iconSize);
					switch (itemInfo.Kind) {
						case ProductItemKind.DialogSample:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemDemo16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height, 1.0f, RotateFlipType.RotateNoneFlipNone);
							break;
						case ProductItemKind.Document:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemDocument16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height, 1.0f, RotateFlipType.RotateNoneFlipNone);
							break;
						case ProductItemKind.InlineSample:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemQuickStart16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height, 1.0f, RotateFlipType.RotateNoneFlipNone);
							break;
						case ProductItemKind.Tool:
							DrawingHelper.DrawImage(e.Graphics, Resources.IconTool16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height, 1.0f, RotateFlipType.RotateNoneFlipNone);
							break;
					}
				}

				int textPadding = DpiHelper.ScaleInt32(7, scaleFactor);

				// Draw the blurb
				var indent = (itemInfo != null ? itemInfoTextIndent : familyInfoTextIndent);
				textBounds = new Rectangle(selectableBounds.Left + indent,
					selectableBounds.Top + borderThickness,
					Math.Max(textPadding, selectableBounds.Width - indent - textPadding),
					selectableBounds.Height);
				if ((itemInfo != null) && (!string.IsNullOrEmpty(itemInfo.BlurbText))) {
					size = DrawingHelper.MeasureString(e.Graphics, itemInfo.BlurbText, this.Font, format);
					DrawingHelper.DrawString(e.Graphics, itemInfo.BlurbText, this.Font, colorScheme.GetKnownColor(KnownColor.Red), textBounds, format);
					textBounds.X += size.Width + textPadding;
				}

				// Draw the name
				if (itemInfo != null)
					DrawingHelper.DrawString(e.Graphics, itemInfo.Title, this.Font, textColor, textBounds, format);
				else if (familyInfo != null) {
					// Determine the font size relative to the configured font
					var fontSize = (float)Math.Round(this.Font.Size * 1.5F, MidpointRounding.AwayFromZero); // 50% bigger for heading
					using (var font = new Font(this.Font.FontFamily, fontSize, FontStyle.Regular)) {
						textBounds = new Rectangle(textBounds.Left,
							selectableBounds.Top,
							Math.Max(textPadding, textBounds.Width - indent - textPadding),
							selectableBounds.Height);
						DrawingHelper.DrawString(e.Graphics, familyInfo.Title, font, textColor, textBounds, format);
					}
				}
			}
		}

		/// <summary>
		/// Raises the <c>MeasureItem</c> event.
		/// </summary>
		/// <param name="e">A <c>MeasureItemEventArgs</c> that contains the event data.</param>
		protected override void OnMeasureItem(MeasureItemEventArgs e) {
			if ((e.Index < 0) || (e.Index >= this.Items.Count))
				return;

			// Get the info
			var itemInfo = this.Items[e.Index] as ProductItemInfo;
			if (itemInfo != null)
				e.ItemHeight = (itemInfo.IsCategoryHeaderRequired ? itemCategoryHeaderHeight : 0) + itemInfoHeight;
			else {
				var familyInfo = this.Items[e.Index] as ProductFamilyInfo;
				e.ItemHeight = (!familyInfo.IsIntroduction ? familySeparatorHeight : 0) + familyInfoHeight;
			}
		}

		/// <summary>
		/// Updates "constants" used for layout.
		/// </summary>
		/// <param name="deviceDpiOld">The DPI value prior to the change.</param>
		/// <param name="deviceDpiNew">The DPI value after the change.</param>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			// Update layout values based on new DPI
			ScaleLayoutValuesForDpi(DpiHelper.GetDpiScale(deviceDpiNew));
		}
	}

}
