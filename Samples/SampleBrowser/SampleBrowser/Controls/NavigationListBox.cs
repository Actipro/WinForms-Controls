using System;
using System.Drawing;
using System.Windows.Forms;
using ActiproSoftware.UI.WinForms.Drawing;

namespace ActiproSoftware.SampleBrowser {

	/// <summary>
	/// A <see cref="ListBox"/> that shows product samples.
	/// </summary>
	public class NavigationListBox : ListBox {
		
		private const int FamilyInfoHeight = 36;
		private const int FamilyInfoTextIndent = 8;
		private const int FamilySeparatorHeight = 16;
		private const int ItemCategoryHeaderHeight = 24;
		private const int ItemInfoHeight = 24;
		private const int ItemInfoTextIndent = 30;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes a new instance of the <c>NavigationListBox</c> class. 
		/// </summary>
		public NavigationListBox() {
			// Set properties
			this.DrawMode = DrawMode.OwnerDrawVariable;

			// Set styles
			this.SetStyle(ControlStyles.ResizeRedraw, true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Raises the <c>DrawItem</c> event.
		/// </summary>
		/// <param name="e">A <c>DrawItemEventArgs</c> that contains the event data.</param>
		protected override void OnDrawItem(DrawItemEventArgs e) {
			if ((e.Index < 0) || (e.Index >= this.Items.Count))
				return;

			var selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
			
			// Get the info
			var itemInfo = this.Items[e.Index] as ProductItemInfo;
			var familyInfo = (itemInfo != null ? null : this.Items[e.Index] as ProductFamilyInfo);

			// Determine bounds
			var separatorHeaderBounds = (itemInfo != null ?
				(itemInfo.IsCategoryHeaderRequired ? new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, ItemCategoryHeaderHeight) : Rectangle.Empty) :
				(!familyInfo.IsIntroduction ? new Rectangle(e.Bounds.Left, e.Bounds.Top + FamilySeparatorHeight - 1, e.Bounds.Width, 1) : Rectangle.Empty)
				);
			var selectableItemHeight = (itemInfo != null ? ItemInfoHeight : FamilyInfoHeight);
			var selectableBounds = new Rectangle(e.Bounds.Left, e.Bounds.Bottom - selectableItemHeight, e.Bounds.Width, selectableItemHeight);
			Rectangle textBounds;
			Size size;

			// Get a string format
			using (var format = DrawingHelper.GetStringFormat(StringAlignment.Near, StringAlignment.Center, StringTrimming.EllipsisCharacter, false, false)) {
				// Get the foreground text color
				var textColor = UIColor.FromMix(SystemColors.WindowText, SystemColors.Window, 0.25f).ToColor();

				// If there is a separator header...
				if (!separatorHeaderBounds.IsEmpty) {
					// Fill the background
					SolidColorBackgroundFill.Draw(e.Graphics, separatorHeaderBounds, UIColor.FromMix(SystemColors.Window, SystemColors.Control, 0.5f).ToColor());
					SimpleBorder.Draw(e.Graphics, separatorHeaderBounds, SimpleBorderStyle.Solid, SystemColors.ControlLight, Sides.Top | Sides.Bottom);

					// Draw the name
					if (itemInfo != null) {
						textBounds = new Rectangle(separatorHeaderBounds.Left + 8, separatorHeaderBounds.Top + 1, separatorHeaderBounds.Width - 16, separatorHeaderBounds.Height);
						using (var font = new Font(this.Font.FontFamily, 8f)) {
							DrawingHelper.DrawString(e.Graphics, itemInfo.Category.ToUpperInvariant(), font, SystemColors.GrayText, textBounds, format);
						}
					}
				}

				// Fill the selectable background
				if (selected) {
					MultiColorLinearGradient.Draw(e.Graphics, selectableBounds, selectableBounds, 
						WindowsColorScheme.WindowsDefault.BarButtonHotBackGradientBegin, WindowsColorScheme.WindowsDefault.BarButtonHotBackGradientMiddle,
						WindowsColorScheme.WindowsDefault.BarButtonHotBackGradientEnd, 90);
					SimpleBorder.Draw(e.Graphics, selectableBounds, SimpleBorderStyle.Solid, WindowsColorScheme.WindowsDefault.BarButtonHotBorder);
				}
				else
					SolidColorBackgroundFill.Draw(e.Graphics, selectableBounds, SystemColors.Window);

				// Draw icon
				if (itemInfo != null) {
					var iconBounds = new Rectangle(selectableBounds.Left + 10, selectableBounds.Top + (int)Math.Round((selectableBounds.Height - 16) / 2.0), 16, 16);
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

				// Draw the blurb
				var indent = (itemInfo != null ? ItemInfoTextIndent : FamilyInfoTextIndent);
				textBounds = new Rectangle(selectableBounds.Left + indent, selectableBounds.Top + 1, Math.Max(5, selectableBounds.Width - indent - 7), selectableBounds.Height);
				if ((itemInfo != null) && (!string.IsNullOrEmpty(itemInfo.BlurbText))) {
					size = DrawingHelper.MeasureString(e.Graphics, itemInfo.BlurbText, this.Font, format);
					DrawingHelper.DrawString(e.Graphics, itemInfo.BlurbText, this.Font, Color.Red, textBounds, format);
					textBounds.X += size.Width + 7;
				}

				// Draw the name
				if (itemInfo != null)
					DrawingHelper.DrawString(e.Graphics, itemInfo.Title, this.Font, textColor, textBounds, format);
				else if (familyInfo != null) {
					using (var font = new Font(this.Font.FontFamily, 14, FontStyle.Regular)) {
						textBounds = new Rectangle(textBounds.Left, selectableBounds.Top, Math.Max(7, textBounds.Width - indent - 7), selectableBounds.Height);
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
				e.ItemHeight = (itemInfo.IsCategoryHeaderRequired ? ItemCategoryHeaderHeight : 0) + ItemInfoHeight;
			else {
				var familyInfo = this.Items[e.Index] as ProductFamilyInfo;
				e.ItemHeight = (!familyInfo.IsIntroduction ? FamilySeparatorHeight : 0) + FamilyInfoHeight;
			}
		}

	}

}
