using ActiproSoftware.UI.WinForms;
using ActiproSoftware.UI.WinForms.Controls;
using ActiproSoftware.UI.WinForms.Controls.Docking;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.MarkupLabel;
using ActiproSoftware.UI.WinForms.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.SampleBrowser.Controls {

	// IMPLEMENTATION NOTE:
	//	This class is intended to demonstrate how IWindowsColorScheme could be utilized to extend a color scheme
	//	to non-Actipro controls. Many native controls cannot be properly themed by only changing color properties.

	/// <summary>
	/// Defines helper methods for working with themes.
	/// </summary>
	internal static class ThemeHelper {

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Applies scheme-appropriate colors to the children of an object.
		/// </summary>
		/// <param name="parent">The parent object to examine.</param>
		/// <param name="colorScheme">The color scheme to apply.</param>
		private static void ApplyChildrenColors(object parent, IWindowsColorScheme colorScheme) {
			var processedList = new ArrayList();
			if (parent is DockManager dockManager) {
				foreach (ToolWindow toolWindow in dockManager.ToolWindows)
					ApplyComponentColors(toolWindow, colorScheme, recurseChildren: true);
				foreach (DocumentWindow documentWindow in dockManager.DocumentWindows)
					ApplyComponentColors(documentWindow, colorScheme, recurseChildren: true);
			}
			else {
				if (parent is Control parentControl) {
					foreach (Control childControl in (System.Windows.Forms.Layout.ArrangedElementCollection)parentControl.Controls) {
						processedList.Add(childControl);
						ApplyComponentColors(childControl, colorScheme, recurseChildren: true);
					}
				}
				if ((parent is ILogicalTreeNode parentTreeNode) && (parentTreeNode.Children != null)) {
					foreach (ILogicalTreeNode childNode in parentTreeNode.Children) {
						if (processedList.Contains(childNode))
							continue;

						processedList.Add(childNode);
						if (childNode is Control childControl)
							ApplyComponentColors(childControl, colorScheme, recurseChildren: true);
						else
							ApplyChildrenColors(childNode, colorScheme);
					}
				}
			}
		}

		/// <summary>
		/// Gets if a control should be auto-themed.
		/// </summary>
		/// <param name="component">The control to test.</param>
		/// <returns><c>true</c> if the control can be auto-themed; otherwise, <c>false</c>.</returns>
		private static bool CanAutoThemeComponent(Component component) {
			if (component.GetType().FullName.StartsWith("ActiproSoftware.UI.WinForms.Controls")) {
				// Only select Actipro-based controls should be auto-themed
				if (component is MarkupLabel)
					return true;

				return false;
			}

			// Some native controls have limited theme support and look better without any theme applied
			if (component is TextBox textBox) {
				// Single-line text box will always have a white inner border and should not be themed,
				// but multi-line looks OK
				return textBox.Multiline;
			}
			else if (component is ComboBox) {
				// ComboBox has several theme inconsistencies, especially when using DropDownList
				return false;
			}

			// Allow other native controls to be themed
			return true;
		}

		/// <summary>
		/// Gets a common border color based on the given color scheme.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns>A <see cref="Color"/> populated with a common color for use with borders.</returns>
		private static Color GetCommonBorderColor(this IWindowsColorScheme colorScheme) {
			// High-contrast borders typically look better on light themes,
			// while low-contrast borders typically look better on dark themes
			return colorScheme.IsDarkColorScheme()
				? colorScheme.GetKnownColor(KnownColor.ControlLight)
				: colorScheme.GetKnownColor(KnownColor.ControlDark);
		}

		/// <summary>
		/// Gets a color to be used for an active link based on the given color scheme.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns>A <see cref="Color"/> populated with a color for use with active links.</returns>
		private static Color GetLinkActiveColor(this IWindowsColorScheme colorScheme) {
			// Dark scheme needs a more muted variant of the light theme color
			return colorScheme.IsDarkColorScheme()
				? Color.FromArgb(235, 117, 113)
				: colorScheme.GetKnownColor(KnownColor.Red);
		}

		/// <summary>
		/// Gets a color to be used for a disabled link based on the given color scheme.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns>A <see cref="Color"/> populated with a color for use with disabled links.</returns>
		private static Color GetLinkDisabledColor(this IWindowsColorScheme colorScheme) {
			return colorScheme.IsDarkColorScheme()
				? Color.FromArgb(122, 122, 122)
				: Color.FromArgb(133, 133, 133);
		}

		/// <summary>
		/// Gets a color to be used for a link in a normal state based on the given color scheme.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns>A <see cref="Color"/> populated with a color for use with a links in a normal state.</returns>
		private static Color GetLinkNormalColor(this IWindowsColorScheme colorScheme) {
			// Dark scheme needs a more muted variant of the light theme color
			return colorScheme.IsDarkColorScheme()
				? Color.FromArgb(10, 159, 235)
				: colorScheme.GetKnownColor(KnownColor.Blue);
		}

		/// <summary>
		/// Gets a color to be used for a visited link based on the given color scheme.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns>A <see cref="Color"/> populated with a color for use with visited links.</returns>
		private static Color GetLinkVisitedColor(this IWindowsColorScheme colorScheme) {
			// Dark scheme needs a more muted variant of the light theme color
			return colorScheme.IsDarkColorScheme()
				? Color.FromArgb(159, 122, 233)
				: colorScheme.GetKnownColor(KnownColor.Purple);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>Button</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetButtonColors(Button control, IWindowsColorScheme colorScheme) {
			// Only change the color of Flat buttons, otherwise OS chrome will impact the appearance.
			// Even flat buttons will still have a light-themed color on mouse over.
			if (control.FlatStyle == FlatStyle.Flat) {
				if (control.BackColor != Color.Transparent)
					control.BackColor = colorScheme.GetKnownColor(KnownColor.Window);
				control.ForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);
			}
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>DateTimePicker</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetDateTimePickerColors(DateTimePicker control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
			control.CalendarForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
			control.CalendarMonthBackground = colorScheme.GetKnownColor(KnownColor.Window);
			control.CalendarTitleBackColor = colorScheme.GetKnownColor(KnownColor.ActiveCaption);
			control.CalendarTitleForeColor = colorScheme.GetKnownColor(KnownColor.ActiveCaptionText);
			control.CalendarTrailingForeColor = colorScheme.GetKnownColor(KnownColor.GrayText);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>LinkLabel</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetLinkLabelColors(LinkLabel control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);

			control.ActiveLinkColor = colorScheme.GetLinkActiveColor();
			control.DisabledLinkColor = colorScheme.GetLinkDisabledColor();
			control.LinkColor = colorScheme.GetLinkNormalColor();
			control.VisitedLinkColor = colorScheme.GetLinkVisitedColor();
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>MarkupLabel</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetMarkupLabelColors(MarkupLabel control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);

			control.ActiveLinkColor = colorScheme.GetLinkActiveColor();
			control.LinkColor = colorScheme.GetLinkNormalColor();
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>MonthCalendar</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetMonthCalendarColors(MonthCalendar control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Window);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);
			control.TitleBackColor = colorScheme.GetKnownColor(KnownColor.ActiveCaption);
			control.TitleForeColor = colorScheme.GetKnownColor(KnownColor.ActiveCaptionText);
			control.TrailingForeColor = colorScheme.GetKnownColor(KnownColor.GrayText);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>ProgressBar</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetProgressBarColors(ProgressBar control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.Highlight);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>PropertyGrid</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetPropertyGridColors(PropertyGrid control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);

			control.CategoryForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
			control.CategorySplitterColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.CommandsActiveLinkColor = colorScheme.GetLinkActiveColor();
			control.CommandsBackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.CommandsBorderColor = colorScheme.GetCommonBorderColor();
			control.CommandsDisabledLinkColor = colorScheme.GetLinkDisabledColor();
			control.CommandsForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
			control.CommandsLinkColor = colorScheme.GetLinkNormalColor();
			control.DisabledItemForeColor = colorScheme.GetKnownColor(KnownColor.GrayText);
			control.HelpBackColor = colorScheme.GetKnownColor(KnownColor.Control);
			control.HelpBorderColor = colorScheme.GetCommonBorderColor();
			control.HelpForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
			control.LineColor = colorScheme.GetKnownColor(KnownColor.ScrollBar);
			control.SelectedItemWithFocusBackColor = colorScheme.GetKnownColor(KnownColor.Highlight);
			control.SelectedItemWithFocusForeColor = colorScheme.GetKnownColor(KnownColor.HighlightText);
			control.ViewBackColor = colorScheme.GetKnownColor(KnownColor.Window);
			control.ViewBorderColor = colorScheme.GetCommonBorderColor();
			control.ViewForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>ToolStrip</c> control (which includes <c>MenuStrip</c> and <c>StatusStrip</c>).
		/// </summary>
		/// <param name="toolStrip">The tool strip.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetToolStripColors(ToolStrip toolStrip, IWindowsColorScheme colorScheme) {
			toolStrip.Renderer = new ThemedToolStripProfessionalRenderer(colorScheme);
		}

		/// <summary>
		/// Sets scheme-appropriate colors on a <c>TreeView</c> control.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="colorScheme">The color scheme.</param>
		private static void SetTreeViewColors(TreeView control, IWindowsColorScheme colorScheme) {
			if (control.BackColor != Color.Transparent)
				control.BackColor = colorScheme.GetKnownColor(KnownColor.Window);
			control.ForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);
			control.LineColor = colorScheme.IsDarkColorScheme()
				? colorScheme.GetKnownColor(KnownColor.ControlDark)
				: colorScheme.GetKnownColor(KnownColor.Black);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Applies scheme-appropriate colors to a component and, optionally, it's children.
		/// </summary>
		/// <param name="baseComponent">The base control to be themed.</param>
		/// <param name="colorScheme">The color scheme to apply.</param>
		/// <param name="recurseChildren"><c>true</c> to recurse children of supported controls; otherwise, <c>false</c>.</param>
		public static void ApplyComponentColors(Component baseComponent, IWindowsColorScheme colorScheme, bool recurseChildren) {
			// Do not auto-theme Actipro controls
			if (CanAutoThemeComponent(baseComponent)) {

				if (baseComponent is Form) {
					// Do not theme a form directly since since children often inherit fore/back color
				}
				else if (baseComponent is Button button)
					SetButtonColors(button, colorScheme);
				else if (baseComponent is DateTimePicker dateTimePicker)
					SetDateTimePickerColors(dateTimePicker, colorScheme);
				else if (baseComponent is LinkLabel linkLabel)
					SetLinkLabelColors(linkLabel, colorScheme);
				else if (baseComponent is MarkupLabel markupLabel)
					SetMarkupLabelColors(markupLabel, colorScheme);
				else if (baseComponent is MonthCalendar monthCalendar)
					SetMonthCalendarColors(monthCalendar, colorScheme);
				else if (baseComponent is ProgressBar progressBar)
					SetProgressBarColors(progressBar, colorScheme);
				else if (baseComponent is PropertyGrid propertyGrid) {
					SetPropertyGridColors(propertyGrid, colorScheme);
					recurseChildren = false; // Always ignore children
				}
				else if (baseComponent is ToolStrip toolStrip)
					SetToolStripColors(toolStrip, colorScheme);
				else if (baseComponent is TreeView treeView)
					SetTreeViewColors(treeView, colorScheme);
				else if (baseComponent is Control control) {
					if (control is ComboBox
						|| control is ListBox
						|| control is ListView
						|| control is TextBoxBase
						|| control is UpDownBase) {

						// Generic window-based colors
						if (control.BackColor != Color.Transparent)
							control.BackColor = colorScheme.GetKnownColor(KnownColor.Window);
						control.ForeColor = colorScheme.GetKnownColor(KnownColor.WindowText);
					}
					else {
						// Generic control-based colors
						if (control.BackColor != Color.Transparent)
							control.BackColor = colorScheme.GetKnownColor(KnownColor.Control);
						control.ForeColor = colorScheme.GetKnownColor(KnownColor.ControlText);
					}
				}
			}

			// Optionally recurse child controls
			if (recurseChildren)
				ApplyChildrenColors(baseComponent, colorScheme);

		}

		/// <summary>
		/// Tests if the given color scheme is intended for darker colors.
		/// </summary>
		/// <param name="colorScheme">The color scheme to examine.</param>
		/// <returns><c>true</c> if the color scheme is intended for darker colors; otherwise, <c>false</c>.</returns>
		public static bool IsDarkColorScheme(this IWindowsColorScheme colorScheme) {
			return colorScheme.Intent.IsDarkColorScheme();
		}

		/// <summary>
		/// Displays a disclaimer to the end user about the limited ability to theme native controls for a dark theme.
		/// </summary>
		public static void ShowDarkThemeDisclaimer() {
			var text = "The dark theme in this demo is intended to illustrate the theming capabilities of Actipro products only as most native WinForms controls do not adapt well to a dark theme. This demo attempts to modify basic color properties of native controls to render better in a dark theme, but some elements (e.g., scrollbars, combo box, buttons) have limited support for custom colors.";
			MessageBox.Show(text, "Dark Theme with Native Controls", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}

}
