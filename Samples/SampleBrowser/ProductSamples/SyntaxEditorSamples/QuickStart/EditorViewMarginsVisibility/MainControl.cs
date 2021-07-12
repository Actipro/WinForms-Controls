using ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common;
using ActiproSoftware.Text.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditorViewMarginsVisibility {

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

			// Initialize view based on default editor properties
			indicatorCheckBox.Checked = editor.IsIndicatorMarginVisible;
			lineNumberCheckBox.Checked = editor.IsLineNumberMarginVisible;
			outliningCheckBox.Checked = editor.IsOutliningMarginVisible;
			rulerCheckBox.Checked = editor.IsRulerMarginVisible;
			selectionCheckBox.Checked = editor.IsSelectionMarginVisible;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnIndicatorCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsIndicatorMarginVisible = indicatorCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnLineNumberCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsLineNumberMarginVisible = lineNumberCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnOutliningCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsOutliningMarginVisible = outliningCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnRulerCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsRulerMarginVisible = rulerCheckBox.Checked;
		}

		/// <summary>
		/// Occurs when the checkbox is checked or unchecked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSelectionCheckBoxCheckedChanged(object sender, EventArgs e) {
			editor.IsSelectionMarginVisible = selectionCheckBox.Checked;
		}

	}
}
