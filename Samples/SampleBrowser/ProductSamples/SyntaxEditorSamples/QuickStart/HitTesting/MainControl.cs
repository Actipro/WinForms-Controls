using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Lexing;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Primitives;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Text;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.HitTesting {

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

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("Html.langdef");
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Returns the display name of the view's placement.
		/// </summary>
		/// <param name="view">The <see cref="IEditorView"/> to examine.</param>
		/// <returns>The display name of the view's placement.</returns>
		private string GetPlacementName(IEditorView view) {
			if (view.SyntaxEditor.HasHorizontalSplit) {
				// Horizontal split
				switch (view.Placement) {
					case EditorViewPlacement.Upper:
						return "upper";
					case EditorViewPlacement.Lower:
						return "lower";
				}
			}

			return "default";
		}

		/// <summary>
		/// Occurs when the mouse moves over the control.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorMouseMove(object sender, MouseEventArgs e) {
			IHitTestResult result = editor.HitTest(e.Location);
			this.UpdateHitTestInfo(result);
		}

		/// <summary>
		/// Occurs when the mouse leaves the control.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorMouseLeave(object sender, EventArgs e) {
			this.UpdateHitTestInfo(null);
		}

		/// <summary>
		/// Updates the hit test info.
		/// </summary>
		/// <param name="result">The hit test result.</param>
		private void UpdateHitTestInfo(IHitTestResult result) {
			var text = new StringBuilder();

			if (result != null) {
				text.AppendFormat("Snapshot version {0}{1}", result.Snapshot.Version.Number, Environment.NewLine);

				if (result.View != null)
					text.AppendFormat("Over '{0}' view{1}", this.GetPlacementName(result.View), Environment.NewLine);

				switch (result.Type) {
					case HitTestResultType.Splitter: {
							var splitter = result.VisualElement as EditorViewSplitter;
							if (splitter != null)
								text.AppendLine("Over view splitter");
							break;
						}
					case HitTestResultType.ViewMargin:
						text.AppendFormat("Over '{0}' margin{1}", result.ViewMargin.Key, Environment.NewLine);
						text.AppendFormat("Closest text position is ({0},{1}){2}", result.Position.Line, result.Position.Character, Environment.NewLine);
						break;
					case HitTestResultType.ViewScrollBarBlock:
						text.AppendLine("Over scroll bar block");
						break;
					case HitTestResultType.ViewScrollBarSplitter: {
							var splitter = result.VisualElement as ScrollBarSplitter;
							if (splitter != null)
								text.AppendLine("Over scroll bar splitter");
							break;
						}
					case HitTestResultType.ViewScrollBarTray:
						text.AppendLine("Over scroll bar tray (that can contain other controls like buttons)");
						break;
					case HitTestResultType.ViewTextArea:
						text.AppendFormat("Not directly over any view line or character{0}", Environment.NewLine);
						text.AppendFormat("Closest text position is ({0},{1}){2}", result.Position.Line, result.Position.Character, Environment.NewLine);
						break;
					case HitTestResultType.ViewTextAreaOverCharacter: {
							ITextSnapshotReader reader = result.GetReader();
							text.AppendFormat("Directly over offset {0} and text position ({1},{2}){3}", result.Offset, result.Position.Line, result.Position.Character, Environment.NewLine);
							text.AppendFormat("Directly over character '{0}'{1}", reader.Character, Environment.NewLine);

							IToken token = reader.Token;
							if (token != null) {
								text.AppendFormat("Directly over token '{0}' with range ({1},{2})-({3},{4}){5}", token.Key,
									token.StartPosition.Line, token.StartPosition.Character,
									token.EndPosition.Line, token.EndPosition.Character, Environment.NewLine);
								text.AppendFormat("Directly over token text '{0}'{1}", reader.TokenText, Environment.NewLine);
							}
							break;
						}
					case HitTestResultType.ViewTextAreaOverIntraTextSpacer:
						text.AppendFormat("Over spacer '{0}' on document line {1}{2}", result.IntraTextSpacerTag, result.Position.Line, Environment.NewLine);
						break;
					case HitTestResultType.ViewTextAreaOverLine:
						text.AppendFormat("Over whitespace at the end of document line {0}{1}", result.Position.Line, Environment.NewLine);
						break;
					default:
						if (result.VisualElement != null)
							text.AppendFormat("Over a '{0}' element{1}", result.VisualElement.GetType().FullName, Environment.NewLine);
						else
							text.AppendLine("No other hit test details available");
						break;
				}
			}
			else {
				text.AppendLine("Not over the SyntaxEditor");
			}

			resultsTextBox.Text = text.ToString();
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
					resultsTextBox
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

		}

	}
}
