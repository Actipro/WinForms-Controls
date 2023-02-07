using ActiproSoftware.SampleBrowser;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.DragAndDrop {

	/// <summary>
	/// Provides the main user control for this sample.
	/// </summary>
	public partial class MainControl : UserControl {

		private Rectangle		dragBoxFromMouseDown;
		private Control			dragSource;
		private object			dragSourceContext;
		private readonly bool	isViewInitialized;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the <c>MainControl</c> class.
		/// </summary>
		public MainControl() {
			InitializeComponent();

			// Load a language from a language definition
			editor.Document.Language = ActiproSoftware.ProductSamples.SyntaxEditorSamples.Common.SyntaxEditorHelper.LoadLanguageDefinitionFromResourceStream("CSharp.langdef");

			// Initialize the toolbox with snippets of text
			var textSnippets = new[] {
				new TextSnippet() { DisplayText = "Class", Snippet = "class ClassName {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Enum", Snippet = "enum EnumName {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "For Loop", Snippet = "for (var index = 0; index < count; index++) {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "For Loop (Reverse)", Snippet = "for (var index = count - 1; index >= 0; index--) {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Interface", Snippet = "interface InterfaceName {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Method", Snippet = "void MethodName() {\r\n\tthrow new NotImplementedException();\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Multi-Line Comment", Snippet = "/*\r\n * Multi-line comment\r\n */\r\n" },
				new TextSnippet() { DisplayText = "Namespace", Snippet = "namespace NamespaceName {\r\n\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Property", Snippet = "object PropertyName {\r\n\tget => throw new NotImplementedException();\r\n\tset => throw new NotImplementedException();\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Property (Read-Only)", Snippet = "object PropertyName {\r\n\tget => throw new NotImplementedException();\r\n}\r\n" },
				new TextSnippet() { DisplayText = "Region", Snippet = "#region\r\n\r\n#endregion\r\n" },
			};
			foreach (var textSnippet in textSnippets.OrderBy(x => x.DisplayText))
				toolboxListBox.Items.Add(textSnippet); //new ListViewItem(textSnippet.DisplayText) { Tag = textSnippet });

			// Configure drag sources
			ConfigureDragSource(toolboxListBox);
			ConfigureDragSource(stringDragSourceLabel);
			ConfigureDragSource(customDragSourceLabel);

			// Synchronize the current state of the view
			UpdateViewFromEditor();
			isViewInitialized = true;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		private void ConfigureDragSource(Control dragSource) {
			dragSource.MouseDown += this.OnDragSourceMouseDown;
			dragSource.MouseUp += this.OnDragSourceMouseUp;
			dragSource.MouseMove += this.OnDragSourceMouseMove;
		}

		/// <summary>
		/// Occurs when the Checked property of a CheckBox changes.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> for the event data.</param>
		private void OnCheckBoxCheckedChanged(object sender, EventArgs e) {
			if (isViewInitialized) {
				// Update the editor from the change in view state
				UpdateEditorFromView();

				// Enable/disable dependent controls
				overrideDragTextBox.Enabled = overrideDragCheckBox.Checked;
				overrideDropTextBox.Enabled = overrideDropCheckBox.Checked;
			}
		}

		/// <summary>
		/// Occurs when the a mouse button is pressed over a control.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="MouseEventArgs"/> for the event data.</param>
		private void OnDragSourceMouseDown(object sender, MouseEventArgs e) {

			// Reset drag source
			dragSource = null;

			if (sender is ListBox listBoxDragSource) {
				// Get the index of the item the mouse is below.
				int indexOfItemUnderMouseToDrag = listBoxDragSource.IndexFromPoint(e.X, e.Y);

				if (indexOfItemUnderMouseToDrag != ListBox.NoMatches) {
					// Record the drag source and index of the drag
					dragSource = listBoxDragSource;
					dragSourceContext = indexOfItemUnderMouseToDrag;
				}
			}
			else if (sender == stringDragSourceLabel || sender == customDragSourceLabel) {
				// Record the drag source
				dragSource = (Label)sender;
				dragSourceContext = null;
			}

			if (dragSource == null) {
				// Clear drag state if no valid source identified
				ResetDragSourceState();
			}
			else {
				// The DragSize is the distance the mouse must travel before a move
				// operation is treated like a drag event.
				Size dragSize = SystemInformation.DragSize;

				// Create a rectangle around the mouse position (with mouse being in the center) where
				// the mouse must exit in order to trigger the drag event.
				dragBoxFromMouseDown = new Rectangle(
					new Point(e.X - (dragSize.Width / 2),
						e.Y - (dragSize.Height / 2)),
					dragSize);
			}
		}

		/// <summary>
		/// Occurs when the a mouse is moved over a control.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="MouseEventArgs"/> for the event data.</param>
		private void OnDragSourceMouseMove(object sender, MouseEventArgs e) {
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {

				// Start drag if mouse has moved outside of the drag box
				if (dragSource != null &&
					dragBoxFromMouseDown != Rectangle.Empty &&
					!dragBoxFromMouseDown.Contains(e.X, e.Y)) {

					// Initialize the data object from the source
					IDataObject dataObject = null;
					if (dragSource is ListBox listBoxDragSource &&
						dragSourceContext is int indexOfItemUnderMouseToDrag) {
						//
						// Toolbox
						//
						
						// Initialize from the selected toolbox item
						if (listBoxDragSource.Items[indexOfItemUnderMouseToDrag] is TextSnippet textSnippet) {
							// Create DataObject using an explicit Text format
							dataObject = new DataObject(DataFormats.Text, textSnippet.Snippet);
						}
					}
					else if (dragSource == stringDragSourceLabel) {
						//
						// Custom string source
						//

						// Create DataObject directly from a string
						dataObject = new DataObject($"Custom String Generated at {DateTime.Now.ToShortTimeString()}");
					}
					else if (dragSource == customDragSourceLabel) {
						//
						// Custom object source
						//

						// Create DataObject from a custom object as long as the object can be serialized
						var customObject = new TextSnippet() { DisplayText = "Custom Object", Snippet = "This is the text of a custom TextSnippet object." };
						dataObject = new DataObject(customObject);
					}

					// Begin drag
					if (dataObject != null)
						dragSource.DoDragDrop(dataObject, DragDropEffects.Copy);

					ResetDragSourceState();
				}
			}
		}

		/// <summary>
		/// Occurs when the a mouse button is released over a control.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="MouseEventArgs"/> for the event data.</param>
		private void OnDragSourceMouseUp(object sender, MouseEventArgs e) {
			// Reset the drag state when button is raised
			ResetDragSourceState();
		}

		/// <summary>
		/// Occurs before text is cut or copied to the clipboard, and also before a drag occurs.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="CutCopyDragAction"/> event data.</param>
		private void OnEditorCutCopyDrag(object sender, CutCopyDragEventArgs e) {
			// NOTE: This event can be used to monitor drag operations and optionally override the text that is used
			Debug.WriteLine($"OnEditorCutCopyDrag; Action={e.Action}; Text={e.DataStore.GetText()}; HasHtmlData={e.DataStore.GetDataPresent(DataFormats.Html)}; HasRtfData={e.DataStore.GetDataPresent(DataFormats.Rtf)}");

			if (e.Action == CutCopyDragAction.Drag && overrideDragCheckBox.Checked) {
				// Override the default text with custom text
				e.DataStore.SetText(overrideDragTextBox.Text, DataStoreTextKind.Default);
			}
		}

		/// <summary>
		/// Occurs when a paste or drag/drop operation occurs over the control, allowing for customization of the text to be inserted.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="PasteDragDropEventArgs"/> event data.</param>
		private void OnEditorPasteDragDrop(object sender, PasteDragDropEventArgs e) {
			// NOTE: This event can be used to monitor drag operations and optionally override the text that is used
			Debug.WriteLine($"OnEditorPasteDragDrop; Action={e.Action}; Text={e.Text}; IDataObject={e.DataStore.ToDataObject()?.GetType().Name}");

			if (e.Action == PasteDragDropAction.DragDrop && cancelDropCheckBox.Checked) {
				// Cancel by coercing the effect
				e.DragEventArgs.Effect = DragDropEffects.None;
				MessageBox.Show("Drop Canceled");
				return;
			}

			if (overrideDropCheckBox.Checked) {
				// Override the dropped text with custom text
				e.Text = overrideDropTextBox.Text;

				// Make sure the effect indicates that copy is allowed (since text may not have been available when effects were initialized)
				if ((e.DragEventArgs.Effect == DragDropEffects.None) &&
					(e.DragEventArgs.AllowedEffect.HasFlag(DragDropEffects.Copy))) {
					e.DragEventArgs.Effect = DragDropEffects.Copy;
				}
			}
			else if (e.Text == null) {

				// NOTE: The PasteDragDropEventArgs.Text property is initialized to the text automatically extracted
				//		 from the drag source. If the property is NULL, that indicates the text could not be determined.
				//		 Custom drag sources can be analyzed here and their representative text assigned to the
				//		 PasteDragDropEventArgs.Text property to control the dropped text.

				if (e.DataStore.GetDataPresent(typeof(TextSnippet).FullName)) {
					//
					// Custom TextSnippet Object
					//
					var textSnippet = e.DataStore.GetData(typeof(TextSnippet).FullName) as TextSnippet;
					e.Text = textSnippet.Snippet;
					e.DragEventArgs.Effect = DragDropEffects.Copy;
				}
				else if (e.DataStore.GetDataPresent(DataFormats.FileDrop)) {
					//
					// FileDrop
					//
					var allFiles = e.DataStore.GetData(DataFormats.FileDrop) as string[];
					if (allFiles != null && allFiles.Length == 1) {
						string filePath = allFiles[0];
						if (!string.IsNullOrWhiteSpace(filePath)) {
							if (e.Action == PasteDragDropAction.DragDrop) {
								try {
									if (editor.Document.IsReadOnly) {
										// Cancel the default drop behavior
										e.DragEventArgs.Effect = DragDropEffects.None;

										// Prompt to open the file to replace the current file
										if (DialogResult.Yes == MessageBox.Show($"Do you want open the file '{Path.GetFileName(filePath)}'?", "Open File?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
											editor.Document.LoadFile(filePath);
										}
									}
									else {
										// Prompt to insert the context of the dropped file
										if (DialogResult.Yes == MessageBox.Show($"Do you want to insert the contents of the file '{Path.GetFileName(filePath)}'?", "Insert File Contents?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) {
											// Indicate the text to be inserted
											e.Text = File.ReadAllText(filePath);
											// The default effect for FileDrop is 'None', so assign an effect to allow the custom text to be inserted.
											e.DragEventArgs.Effect = DragDropEffects.Copy;
										}
									}
								}
								catch (Exception ex) {
									Debug.WriteLine(ex);
									MessageBox.Show("Error processing file.  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							else {
								// Customize the drag operation to indicate the 'Copy' effect will be used.
								e.DragEventArgs.Effect = DragDropEffects.Copy;
							}
						}
					}
				}
				else {
					//
					// Unknown Drag Source
					//
					IDataObject dataObject = e.DataStore.ToDataObject();
					var customData = $"Optionally build custom text to be inserted for any data source; SourceType={dataObject?.GetType().Name}";
					e.Text = customData;
				}
			}
		}

		/// <summary>
		/// Resets objects for managing drag and drop state.
		/// </summary>
		private void ResetDragSourceState() {
			dragBoxFromMouseDown = Rectangle.Empty;
			dragSource = null;
			dragSourceContext = null;
		}

		/// <summary>
		/// Updates the editor based on the current state of the view.
		/// </summary>
		private void UpdateEditorFromView() {
			editor.AllowDrag = allowDragCheckBox.Checked;
			editor.AllowDrop = allowDropCheckBox.Checked;
			editor.CanCutCopyDragWithHtml = populateWithHtmlCheckBox.Checked;
			editor.CanCutCopyDragWithRtf = populateWithRtfCheckBox.Checked;
			editor.IsDragDropTextReselectEnabled = shouldReselectTextAfterDropCheckBox.Checked;
			editor.Document.IsReadOnly = isDocumentReadOnlyCheckBox.Checked;
		}

		/// <summary>
		/// Updates the view based on the current state of the editor.
		/// </summary>
		private void UpdateViewFromEditor() {
			allowDragCheckBox.Checked = editor.AllowDrag;
			allowDropCheckBox.Checked = editor.AllowDrop;
			populateWithHtmlCheckBox.Checked = editor.CanCutCopyDragWithHtml;
			populateWithRtfCheckBox.Checked = editor.CanCutCopyDragWithRtf;
			shouldReselectTextAfterDropCheckBox.Checked = editor.IsDragDropTextReselectEnabled;
			isDocumentReadOnlyCheckBox.Checked = editor.Document.IsReadOnly;
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
					allowLabel,
					allowDragCheckBox,
					allowDropCheckBox,
					populateWithLabel,
					populateWithHtmlCheckBox,
					populateWithRtfCheckBox,
					overrideLabel,
					overrideDragCheckBox,
					overrideDragTextBox,
					overrideDropCheckBox,
					overrideDropTextBox,
					shouldReselectTextAfterDropCheckBox,
					cancelDropCheckBox,
					isDocumentReadOnlyCheckBox,
					stringDragSourceLabel,
					customDragSourceLabel,
					toolboxListBox,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);

				if (!Program.IsControlSizeScalingHandledByRuntime) {
					// Manually scale sizes
					var manualSizeControl = new Control[] {
						overrideDragTextBox,
						overrideDropTextBox
					};
					foreach (var control in manualSizeControl)
						control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
				}
			}

		}

	}

}

