using ActiproSoftware.Extensions;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// A <see cref="ListBox"/> that shows product samples.
	/// </summary>
	public class NavigationListBox : ListBox {

		private SizeF _scaleFactor;
		private int _borderThickness;
		private int _familyInfoHeight;
		private int _familyInfoTextIndent;
		private int _familySeparatorHeight;
		private Size _iconSize;
		private int _itemCategoryHeaderHeight;
		private int _itemInfoHeight;
		private int _itemInfoTextIndent;

		// --------------------------------------------------------------------------------------------------
		// OBJECT
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		public NavigationListBox() {
			// Initialize layout values at current DPI
			ScaleLayoutValuesForDpi(DpiHelper.GetDpiScale(DeviceDpi));

			// Set properties
			DrawMode = DrawMode.OwnerDrawVariable;

			// Set styles
			SetStyle(ControlStyles.ResizeRedraw, true);
		}

		// --------------------------------------------------------------------------------------------------
		// NON-PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <summary>
		/// Refreshes configuration based on current DPI settings.
		/// </summary>
		private void ScaleLayoutValuesForDpi(SizeF scaleFactor) {
			_scaleFactor = scaleFactor;

			_borderThickness = 1; // Borders currently do not support scaling
			_familyInfoHeight = DpiHelper.ScaleInt32(36, scaleFactor);
			_familyInfoTextIndent = DpiHelper.ScaleInt32(8, scaleFactor);
			_familySeparatorHeight = DpiHelper.ScaleInt32(16, scaleFactor);
			_iconSize = DpiHelper.ScaleSize(new Size(16, 16), scaleFactor);
			_itemCategoryHeaderHeight = DpiHelper.ScaleInt32(24, scaleFactor);
			_itemInfoHeight = DpiHelper.ScaleInt32(24, scaleFactor);
			_itemInfoTextIndent = DpiHelper.ScaleInt32(30, scaleFactor);
		}

		// --------------------------------------------------------------------------------------------------
		// PUBLIC PROCEDURES
		// --------------------------------------------------------------------------------------------------

		/// <inheritdoc/>
		protected override void OnDpiChangedAfterParent(EventArgs e) {
			base.OnDpiChangedAfterParent(e);

			// Items must be completely refreshed when DPI changes
			RefreshItems();
		}

		/// <inheritdoc/>
		protected override void OnDrawItem(DrawItemEventArgs e) {
			if ((e.Index < 0) || (e.Index >= Items.Count))
				return;

			var colorScheme = WindowsColorScheme.WindowsDefault;

			var selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

			// Get the info
			var itemInfo = Items[e.Index] as ProductItemInfo;
			var familyInfo = (itemInfo is not null ? null : Items[e.Index] as ProductFamilyInfo);

			// Determine bounds
			var separatorHeaderBounds = (itemInfo is not null)
				? itemInfo.IsCategoryHeaderRequired
					? new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, _itemCategoryHeaderHeight)
					: Rectangle.Empty
				: ((familyInfo is not null) && (!familyInfo.IsIntroduction))
					? new Rectangle(e.Bounds.Left, e.Bounds.Top + _familySeparatorHeight - _borderThickness, e.Bounds.Width, _borderThickness) // Only allocate enough space for the border
					: Rectangle.Empty
				;
			var selectableItemHeight = (itemInfo is not null ? _itemInfoHeight : _familyInfoHeight);
			var selectableBounds = new Rectangle(e.Bounds.Left, e.Bounds.Bottom - selectableItemHeight, e.Bounds.Width, selectableItemHeight);
			Rectangle textBounds;
			Size size;

			// Get a string format
			using (var format = DrawingHelper.GetStringFormat(StringAlignment.Near, StringAlignment.Center, StringTrimming.EllipsisCharacter)) {
				// Get the foreground text color
				var textColor = UIColor.FromMix(colorScheme.GetKnownColor(KnownColor.WindowText), colorScheme.GetKnownColor(KnownColor.Window), 0.25f).ToColor();

				// If there is a separator header...
				if (!separatorHeaderBounds.IsEmpty) {

					// Fill the background
					SolidColorBackgroundFill.Draw(e.Graphics, separatorHeaderBounds, UIColor.FromMix(colorScheme.GetKnownColor(KnownColor.Window), colorScheme.GetKnownColor(KnownColor.Control), 0.5f).ToColor());
					// Draw the separators
					Debug.Assert(_borderThickness == 1, "SimpleBorder.Draw only supports 1px borders");
					SimpleBorder.Draw(e.Graphics, separatorHeaderBounds, SimpleBorderStyle.Solid, colorScheme.GetKnownColor(KnownColor.ControlLight), Sides.Top | Sides.Bottom);

					// Draw the name
					if (itemInfo?.Category is not null) {
						textBounds = new Rectangle(
							separatorHeaderBounds.Left + DpiHelper.ScaleInt32(8, _scaleFactor),
							separatorHeaderBounds.Top + _borderThickness,
							separatorHeaderBounds.Width - _iconSize.Width,
							separatorHeaderBounds.Height
						);
						// Determine the font size relative to the configured font
						var fontSize = (float)Math.Floor(Font.Size * 0.9F); // 90% reduction in size since using all upper-case letters
						using var font = new Font(Font.FontFamily, fontSize);
						DrawingHelper.DrawString(e.Graphics, itemInfo.Category.ToUpperInvariant(), font, colorScheme.GetKnownColor(KnownColor.GrayText), textBounds, format);
					}
				}

				// Fill the selectable background
				if (selected) {
					MultiColorLinearGradient.Draw(e.Graphics, selectableBounds, selectableBounds,
						colorScheme.BarButtonHotBackGradientBegin,
						colorScheme.BarButtonHotBackGradientMiddle,
						colorScheme.BarButtonHotBackGradientEnd, 90);
					Debug.Assert(_borderThickness == 1, "SimpleBorder.Draw only supports 1px borders");
					SimpleBorder.Draw(e.Graphics, selectableBounds, SimpleBorderStyle.Solid, colorScheme.BarButtonHotBorder);
				}
				else
					SolidColorBackgroundFill.Draw(e.Graphics, selectableBounds, colorScheme.GetKnownColor(KnownColor.Window));

				// Draw icon
				if (itemInfo is not null) {
					var iconLocation = new Point(
						selectableBounds.Left + DpiHelper.ScaleInt32(10, _scaleFactor),
						selectableBounds.Top + (int)((selectableBounds.Height - _iconSize.Height) / 2.0).Round()
					);
					var iconBounds = new Rectangle(iconLocation, _iconSize);
					switch (itemInfo.Kind) {
						case ProductItemKind.DialogSample:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemDemo16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height);
							break;
						case ProductItemKind.Document:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemDocument16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height);
							break;
						case ProductItemKind.InlineSample:
							DrawingHelper.DrawImage(e.Graphics, Resources.ItemQuickStart16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height);
							break;
						case ProductItemKind.Tool:
							DrawingHelper.DrawImage(e.Graphics, Resources.IconTool16, iconBounds.Left, iconBounds.Top, iconBounds.Width, iconBounds.Height);
							break;
					}
				}

				int textPadding = DpiHelper.ScaleInt32(7, _scaleFactor);

				// Draw the blurb
				var indent = (itemInfo is not null ? _itemInfoTextIndent : _familyInfoTextIndent);
				textBounds = new Rectangle(
					selectableBounds.Left + indent,
					selectableBounds.Top + _borderThickness,
					Math.Max(textPadding, selectableBounds.Width - indent - textPadding),
					selectableBounds.Height
				);
				if ((itemInfo is not null) && (!string.IsNullOrEmpty(itemInfo.BlurbText))) {
					size = DrawingHelper.MeasureString(e.Graphics, itemInfo.BlurbText!, Font, format);
					DrawingHelper.DrawString(e.Graphics, itemInfo.BlurbText!, Font, colorScheme.GetKnownColor(KnownColor.Red), textBounds, format);
					textBounds.X += size.Width + textPadding;
				}

				// Draw the name
				if (itemInfo?.Title is not null)
					DrawingHelper.DrawString(e.Graphics, itemInfo.Title, Font, textColor, textBounds, format);
				else if (familyInfo?.Title is not null) {
					// Determine the font size relative to the configured font
					var fontSize = (Font.Size * 1.5F).Round(); // 50% bigger for heading
					using var font = new Font(Font.FontFamily, fontSize, FontStyle.Regular);
					textBounds = new Rectangle(
						textBounds.Left,
						selectableBounds.Top,
						Math.Max(textPadding, textBounds.Width - indent - textPadding),
						selectableBounds.Height
					);
					DrawingHelper.DrawString(e.Graphics, familyInfo.Title, font, textColor, textBounds, format);
				}
			}
		}

		/// <inheritdoc/>
		protected override void OnMeasureItem(MeasureItemEventArgs e) {
			if ((e.Index < 0) || (e.Index >= Items.Count))
				return;

			// Get the info
			if (Items[e.Index] is ProductItemInfo itemInfo)
				e.ItemHeight = (itemInfo.IsCategoryHeaderRequired ? _itemCategoryHeaderHeight : 0) + _itemInfoHeight;
			else if (Items[e.Index] is ProductFamilyInfo familyInfo)
				e.ItemHeight = (!familyInfo.IsIntroduction ? _familySeparatorHeight : 0) + _familyInfoHeight;
		}

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			// Update layout values based on new DPI
			ScaleLayoutValuesForDpi(DpiHelper.GetDpiScale(deviceDpiNew));
		}

	}

}
