namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.GoToLineOverlay {
	partial class MainControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
			editor = new UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
			showOverlayPaneButton = new System.Windows.Forms.Button();
			contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			contentTableLayoutPanel.SuspendLayout();
			headerTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// editor
			// 
			editor.AllowDrop = true;
			editor.Dock = System.Windows.Forms.DockStyle.Fill;
			editor.IsLineNumberMarginVisible = true;
			editor.Location = new System.Drawing.Point(13, 56);
			editor.Name = "editor";
			editor.Size = new System.Drawing.Size(774, 531);
			editor.TabIndex = 1;
			editor.Text = resources.GetString("editor.Text");
			// 
			// showOverlayPaneButton
			// 
			showOverlayPaneButton.AutoSize = true;
			showOverlayPaneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			showOverlayPaneButton.Dock = System.Windows.Forms.DockStyle.Left;
			showOverlayPaneButton.Location = new System.Drawing.Point(3, 3);
			showOverlayPaneButton.Name = "showOverlayPaneButton";
			showOverlayPaneButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
			showOverlayPaneButton.Size = new System.Drawing.Size(219, 31);
			showOverlayPaneButton.TabIndex = 2;
			showOverlayPaneButton.Text = "Show 'Go To Line' Overlay (Ctrl+G)";
			showOverlayPaneButton.UseVisualStyleBackColor = true;
			showOverlayPaneButton.Click += this.OnShowOverlayPaneButtonClick;
			// 
			// contentTableLayoutPanel
			// 
			contentTableLayoutPanel.ColumnCount = 1;
			contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			contentTableLayoutPanel.Controls.Add(headerTableLayoutPanel, 0, 0);
			contentTableLayoutPanel.Controls.Add(editor, 0, 1);
			contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			contentTableLayoutPanel.Name = "contentTableLayoutPanel";
			contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
			contentTableLayoutPanel.RowCount = 2;
			contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
			contentTableLayoutPanel.TabIndex = 2;
			// 
			// headerTableLayoutPanel
			// 
			headerTableLayoutPanel.AutoSize = true;
			headerTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			headerTableLayoutPanel.ColumnCount = 3;
			headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			headerTableLayoutPanel.Controls.Add(showOverlayPaneButton, 2, 0);
			headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			headerTableLayoutPanel.Location = new System.Drawing.Point(13, 13);
			headerTableLayoutPanel.Name = "headerTableLayoutPanel";
			headerTableLayoutPanel.RowCount = 1;
			headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			headerTableLayoutPanel.Size = new System.Drawing.Size(774, 37);
			headerTableLayoutPanel.TabIndex = 3;
			// 
			// MainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(contentTableLayoutPanel);
			this.Name = "MainControl";
			this.Size = new System.Drawing.Size(800, 600);
			contentTableLayoutPanel.ResumeLayout(false);
			contentTableLayoutPanel.PerformLayout();
			headerTableLayoutPanel.ResumeLayout(false);
			headerTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Button showOverlayPaneButton;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
	}
}
