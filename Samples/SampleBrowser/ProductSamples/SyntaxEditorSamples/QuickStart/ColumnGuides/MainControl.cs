﻿using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.Rendering;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.ColumnGuides {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		
		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Configure column guides appropriate for COBOL
			editor.ColumnGuides = CreateCobolColumnGuides();

			// Initialize the UI to match the default editor properties
			areColumnGuidesVisibleCheckBox.Checked = editor.AreColumnGuidesVisible;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Creates a new <see cref="IColumnGuideCollection"/> populated with defaults for use with COBOL.
		/// </summary>
		/// <returns>A new <see cref="IColumnGuideCollection"/> instance.</returns>
		private IColumnGuideCollection CreateCobolColumnGuides() {
			return new ColumnGuideCollection() {
				CreateColumnGuide(6),	// Col   1-6 : Sequence Number
				CreateColumnGuide(7),	// Col     7 : Comment/Continuation
				CreateColumnGuide(11),	// Col  8-11 : Area A
				CreateColumnGuide(72),	// Col 12-72 : Area B
				CreateColumnGuide(80),	// Col 73-80 : Identification
			};
		}

		/// <summary>
		/// Creates a new <see cref="IColumnGuide"/> at the given column with formatting that is appropriate for COBOL.
		/// </summary>
		/// <param name="column">The column number.</param>
		/// <returns>A new <see cref="IColumnGuide"/> instance.</returns>
		private IColumnGuide CreateColumnGuide(int column) {
			// Initialize default values for the column guide
			var thickness = 1;
			var lineKind = LineKind.Solid;
			Color? color = null;

			// Customize settings for COBOL-Specific guides
			switch (column) {
				case 6:
				case 7:
					lineKind = LineKind.Dot;
					color = Color.Green;
					break;
				case 11:
					lineKind = LineKind.Dash;
					break;
				case 80:
					thickness = 2;
					color = Color.Red;
					break;
			}

			return new ColumnGuide(ColumnGuidePlacement.Column, column, lineKind, thickness, color);
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnAreColumnGuidesVisibleCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.AreColumnGuidesVisible = areColumnGuidesVisibleCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnResetColumnGuidesButtonClick(object sender, EventArgs e) {
			// Replace the current collection with a new collection using default values
			editor.ColumnGuides = CreateCobolColumnGuides();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnToggleColumnGuideButtonClick(object sender, EventArgs e) {
			// Determine the column where the caret is positioned
			var column = editor.ActiveView.Selection.CaretPosition.Character;

			// Attempt to locate an existing column guide at this position
			var columnGuide = editor.ColumnGuides.FirstOrDefault(cg => (cg.Placement == ColumnGuidePlacement.Column) && (cg.PlacementValue == column));

			if (columnGuide is null) {
				// Add new column guide
				columnGuide = CreateColumnGuide(column);
				editor.ColumnGuides.Add(columnGuide);
			}
			else {
				// Remove existing column guide
				editor.ColumnGuides.Remove(columnGuide);
			}

		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc/>
		protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew) {
			base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);

			if (!Program.IsControlFontScalingHandledByRuntime) {
				// Manually scale control fonts
				var manualFontControls = new Control[] {
					areColumnGuidesVisibleCheckBox,
					resetColumnGuidesButton,
					toggleColumnGuideButton
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
