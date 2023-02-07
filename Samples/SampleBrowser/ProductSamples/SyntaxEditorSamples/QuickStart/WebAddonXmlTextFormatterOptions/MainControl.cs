using ActiproSoftware.SampleBrowser;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Languages.Xml;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.UI.WinForms.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.WebAddonXmlTextFormatterOptions {

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
			
			//
			// NOTE: Make sure that you've read through the add-on language's 'Getting Started' topic
			//   since it tells you how to set up an ambient parse request dispatcher within your 
			//   application OnStartup code, and add related cleanup in your application OnExit code.  
			//   These steps are essential to having the add-on perform well.
			//
			
			// Load the syntax language
			editor.Document.Language = new XmlSyntaxLanguage();

			var formatter = (XmlTextFormatter)editor.Document.Language.GetTextFormatter();

			// Define available options
			var attributeSpacingModelOptions = Enum.GetValues(typeof(XmlAttributeSpacingMode)).OfType<object>().ToArray();
			attributeSpacingModeComboBox.Items.AddRange(attributeSpacingModelOptions);
			attributeSpacingModeComboBox.SelectedItem = XmlAttributeSpacingMode.NormalizeWhitespace;

			// Define available options
			var elementSpacingModelOptions = Enum.GetValues(typeof(XmlElementSpacingMode)).OfType<object>().ToArray();
			elementSpacingModeComboBox.Items.AddRange(elementSpacingModelOptions);
			elementSpacingModeComboBox.SelectedItem = XmlElementSpacingMode.NormalizeEmptyLines;

			this.UpdateTexTFormatter();
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// NON-PUBLIC PROCEDURES
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFormatDocumentButtonClick(object sender, EventArgs e) {
			editor.ActiveView.TextChangeActions.FormatDocument();
		}

		/// <summary>
		/// Occurs when the button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnFormatSelectionButtonClick(object sender, EventArgs e) {
			editor.ActiveView.TextChangeActions.FormatSelection();
		}
		
		/// <summary>
		/// Occurs when the selection changes in the combo box
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
		private void OnUpdateTextFormatter(object sender, EventArgs e) {
			this.UpdateTexTFormatter();
		}

		/// <summary>
		/// Updates the text formatter.
		/// </summary>
		private void UpdateTexTFormatter() {
			var formatter = (XmlTextFormatter)editor.Document.Language.GetTextFormatter();

			if (attributeSpacingModeComboBox.SelectedItem is XmlAttributeSpacingMode)
				formatter.AttributeSpacingMode = (XmlAttributeSpacingMode)attributeSpacingModeComboBox.SelectedItem;

			if (elementSpacingModeComboBox.SelectedItem is XmlElementSpacingMode)
				formatter.ElementSpacingMode = (XmlElementSpacingMode)elementSpacingModeComboBox.SelectedItem;

			int tagWrapLength;
			if ((!string.IsNullOrEmpty(tagWrapLengthTextBox.Text)) && (int.TryParse(tagWrapLengthTextBox.Text, out tagWrapLength)))
				formatter.TagWrapLength = tagWrapLength;
			else
				formatter.TagWrapLength = 0;
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
					attributeSpacingModeComboBox,
					attributeSpacingModeLabel,
					elementSpacingModeComboBox,
					elementSpacingModeLabel,
					formatDocumentButton,
					formatSelectionButton,              
					tagWrapLengthLabel,
					tagWrapLengthTextBox,
				};
				foreach (var control in manualFontControls)
					control.Font = DpiHelper.RescaleFont(control.Font, deviceDpiOld, deviceDpiNew);
			}

			if (!Program.IsControlSizeScalingHandledByRuntime) {
				// Manually scale sizes
				var manualSizeControl = new Control[] {
					attributeSpacingModeComboBox,
					elementSpacingModeComboBox,
					tagWrapLengthTextBox,
				};
				foreach (var control in manualSizeControl)
					control.Size = DpiHelper.RescaleSize(control.Size, deviceDpiOld, deviceDpiNew);
			}

		}

	}

}
