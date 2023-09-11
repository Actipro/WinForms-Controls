using ActiproSoftware.Text;
using ActiproSoftware.UI.WinForms.Controls.Extensions;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GoToLineOverlay {

	public partial class GoToLineOverlayPane : OverlayPaneBase {

		public const string	Key					= "GoToCustom";

		private const int	TextBoxWidth		= 50;
		private const int	InterControlMargin	= 3;

		private Button		goButton;
		private bool		isAttachedToViewEvents;
		private Label		lineNumberLabel;
		private TextBox		lineNumberTextBox;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// OBJECT
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Initializes an instance of the class.
		/// </summary>
		/// <param name="view">The editor view where the overlay pane will be displayed.</param>
		public GoToLineOverlayPane(IEditorView view)
			: base(Key, view) {

			this.SuspendLayout();
			try {
				// Use system font (so editor font isn't inherited) and scale to match the DPI of the editor
				this.Font = DpiHelper.AutoScaleFont(SystemFonts.DefaultFont, DpiHelper.GetDeviceDpi(view.SyntaxEditor));

				this.BackColor = ColorScheme.GetKnownColor(KnownColor.Control);
				this.ForeColor = ColorScheme.GetKnownColor(KnownColor.ControlText);
				this.Padding = new System.Windows.Forms.Padding(4);

				this.InitializeChildren();
			}
			finally {
				this.ResumeLayout();
			}

			AttachDetachViewEvents(attach: true);
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Performs layout of child controls.
		/// </summary>
		private void ArrangeChildren() {
			this.SuspendLayout();
			try {
				var padding = DpiHelper.AutoScalePadding(this.Padding, this.DpiScaleFactor);
				var interControlMargin = this.ScaleLogicalValue(InterControlMargin);
				var controlHeight = Math.Max(lineNumberTextBox.Height, goButton.Height);

				var lineNumberLabelYOffset = Math.Max(0, controlHeight - lineNumberLabel.Height) / 2;
				lineNumberLabel.SetBounds(padding.Left, padding.Top + lineNumberLabelYOffset, lineNumberLabel.Width, lineNumberLabel.Height);

				var lineNumberTextBoxYOffset = Math.Max(0, controlHeight - lineNumberTextBox.Height) / 2;
				lineNumberTextBox.SetBounds(lineNumberLabel.Right + interControlMargin, padding.Top + lineNumberTextBoxYOffset, this.ScaleLogicalValue(TextBoxWidth), lineNumberTextBox.Height);

				var goButtonYOffset = Math.Max(0, controlHeight - goButton.Height) / 2;
				goButton.SetBounds(lineNumberTextBox.Right + interControlMargin, padding.Top + goButtonYOffset, goButton.Width, goButton.Height);

			}
			finally {
				this.ResumeLayout();
			}
		}

		/// <summary>
		/// Attaches to or detaches from target view events.
		/// </summary>
		/// <param name="attach">Whether to attach to events.</param>
		private void AttachDetachViewEvents(bool attach) {
			if (TargetView == null)
				return;

			if (attach) {
				if (!isAttachedToViewEvents) {
					TargetView.SelectionChanged += OnViewSelectionChanged;
					TargetView.SyntaxEditor.ActiveViewChanged += this.OnSyntaxEditorActiveViewChanged;
					isAttachedToViewEvents = true;
				}
			}
			else {  // Detach
				if (isAttachedToViewEvents) {
					TargetView.SelectionChanged -= OnViewSelectionChanged;
					TargetView.SyntaxEditor.ActiveViewChanged -= this.OnSyntaxEditorActiveViewChanged;
					isAttachedToViewEvents = false;
				}
			}
		}

		/// <summary>
		/// Navigates the view to the line number defined in the view.
		/// </summary>
		private void GoToLine() {
			// Validate
			if (!int.TryParse(lineNumberTextBox.Text, out var lineNumber)
				|| !(1 <= lineNumber && lineNumber <= TargetView.CurrentSnapshot.Lines.Count)) {

				MessageBox.Show($"Please enter a valid line number (1-{TargetView.CurrentSnapshot.Lines.Count}).", "Invalid Line Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Set caret position (make zero-based)
			TargetView.Selection.CaretPosition = new TextPosition(lineNumber - 1, 0);
			TargetView.Scroller.ScrollLineToVisibleMiddle();

			// Close the pane
			this.Close();
		}

		/// <summary>
		/// Initializes the children.
		/// </summary>
		private void InitializeChildren() {
			lineNumberLabel = new Label() {
				Text = "Line number (1 - x)",
				AutoSize = true,
			};
			lineNumberTextBox = new TextBox();
			lineNumberTextBox.GotFocus += this.OnLineNumberTextBoxGotFocus;
			goButton = new Button() {
				Text = "Go",
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
			};

			this.Controls.Add(lineNumberLabel);
			this.Controls.Add(lineNumberTextBox);
			this.Controls.Add(goButton);
		}

		/// <summary>
		/// Occurs when the textbox gets focus.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnLineNumberTextBoxGotFocus(object sender, EventArgs e) {
			// Select all text when focused
			(sender as TextBox)?.SelectAll();
		}

		/// <summary>
		/// Occurs when the active view of SyntaxEditor has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorViewChangedEventArgs"/> that contains the event data.</param>
		private void OnSyntaxEditorActiveViewChanged(object sender, EditorViewChangedEventArgs e) {
			// Close the pane if the attached view is no longer active
			if (e.NewValue != TargetView)
				Close();
		}

		/// <summary>
		/// Occurs when the view's selection has changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EditorViewSelectionEventArgs"/> that contains the event data.</param>
		private void OnViewSelectionChanged(object sender, EditorViewSelectionEventArgs e) {
			// Close the pane any time selection changes
			this.Close();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <inheritdoc />
		public override void Activate() {
			base.Activate();

			// Define the range of valid lines
			lineNumberLabel.Text = $"Line number (1 - {TargetView.CurrentSnapshot.Lines.Count})";

			// Populate the textbox with the current line
			lineNumberTextBox.Text = TargetView.Selection.EndPosition.DisplayLine.ToString();
			lineNumberTextBox.Focus();

			// Must invalidate after changing the label text since it impacts the size of the control
			InvalidateMeasure();
			ArrangeChildren();
		}

		/// <inheritdoc />
		public override void Close() {
			// Detach from the view
			AttachDetachViewEvents(attach: false);

			base.Close();
		}

		/// <inheritdoc />
		protected override Size MeasureOverride(Graphics g, Size availableSize) {
			if (this.Width == 0 || !IsMeasureValid) {
				var padding = DpiHelper.AutoScalePadding(this.Padding, this.DpiScaleFactor);
				var interControlMargin = this.ScaleLogicalValue(InterControlMargin);
				var controlHeight = Math.Max(lineNumberTextBox.Height, goButton.Height);

				var width = padding.Horizontal + lineNumberLabel.Width + interControlMargin + this.ScaleLogicalValue(TextBoxWidth) + interControlMargin + goButton.Width;
				var height = padding.Top + controlHeight + padding.Bottom;

				return new Size(width, height);
			}
			else
				return new Size(this.Width, this.Height);
		}

		/// <inheritdoc/>
		protected override bool ProcessKeyDown(UI.WinForms.Input.ModifierKeys modifierKeys, Keys key) {
			switch (modifierKeys) {
				case UI.WinForms.Input.ModifierKeys.None:
				case UI.WinForms.Input.ModifierKeys.Shift:
					switch (key) {
						case Keys.Enter:
							// Go to line
							this.GoToLine();
							return true;

						case Keys.Tab:
							// Cycle focus within the pane
							if (lineNumberTextBox.Focused)
								goButton.Focus();
							else
								lineNumberTextBox.Focus();
							return true;
					}
					break;
			}

			return base.ProcessKeyDown(modifierKeys, key);
		}

		/// <summary>
		/// Shows the overlay pane within the specified <paramref name="view"/>.
		/// </summary>
		/// <param name="view">The editor view where the overlay pane will be displayed.</param>
		public static void Show(IEditorView view) {
			if (view is null)
				throw new ArgumentNullException(nameof(view));

			// Get or create the overlay pane
			var overlayPanes = view.OverlayPanes;
			var goToLinePane = overlayPanes[Key] as GoToLineOverlayPane;
			if (goToLinePane is null) {
				// Close any existing overlay panes before adding a new one
				overlayPanes.Clear();

				// Add a new overlay pane
				goToLinePane = new GoToLineOverlayPane(view);
				overlayPanes.Add(goToLinePane);
			}

			// Activate the pane to initialize the valid line range and focus the textbox
			goToLinePane.Activate();
		}

	}
}
