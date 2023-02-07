namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.UndoRedo {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.upperLeftPanel = new System.Windows.Forms.Panel();
            this.redoStack = new System.Windows.Forms.ListBox();
            this.redoStackLabel = new System.Windows.Forms.Label();
            this.upperRightPanel = new System.Windows.Forms.Panel();
            this.undoStack = new System.Windows.Forms.ListBox();
            this.undoStackLabel = new System.Windows.Forms.Label();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.appendButton = new System.Windows.Forms.Button();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.upperLeftPanel.SuspendLayout();
            this.upperRightPanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // upperLeftPanel
            // 
            this.upperLeftPanel.Controls.Add(this.redoStack);
            this.upperLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperLeftPanel.Location = new System.Drawing.Point(13, 29);
            this.upperLeftPanel.Name = "upperLeftPanel";
            this.upperLeftPanel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.upperLeftPanel.Size = new System.Drawing.Size(384, 248);
            this.upperLeftPanel.TabIndex = 0;
            // 
            // redoStack
            // 
            this.redoStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redoStack.FormattingEnabled = true;
            this.redoStack.Location = new System.Drawing.Point(0, 0);
            this.redoStack.Name = "redoStack";
            this.redoStack.Size = new System.Drawing.Size(374, 248);
            this.redoStack.TabIndex = 6;
            this.redoStack.DoubleClick += new System.EventHandler(this.OnRedoStackListBoxDoubleClick);
            // 
            // redoStackLabel
            // 
            this.redoStackLabel.AutoSize = true;
            this.redoStackLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redoStackLabel.Location = new System.Drawing.Point(13, 10);
            this.redoStackLabel.Name = "redoStackLabel";
            this.redoStackLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.redoStackLabel.Size = new System.Drawing.Size(384, 16);
            this.redoStackLabel.TabIndex = 5;
            this.redoStackLabel.Text = "Redo Stack:";
            // 
            // upperRightPanel
            // 
            this.upperRightPanel.Controls.Add(this.undoStack);
            this.upperRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperRightPanel.Location = new System.Drawing.Point(403, 29);
            this.upperRightPanel.Name = "upperRightPanel";
            this.upperRightPanel.Size = new System.Drawing.Size(384, 248);
            this.upperRightPanel.TabIndex = 1;
            // 
            // undoStack
            // 
            this.undoStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoStack.FormattingEnabled = true;
            this.undoStack.Location = new System.Drawing.Point(0, 0);
            this.undoStack.Name = "undoStack";
            this.undoStack.Size = new System.Drawing.Size(384, 248);
            this.undoStack.TabIndex = 7;
            this.undoStack.DoubleClick += new System.EventHandler(this.OnUndoStackListBoxDoubleClick);
            // 
            // undoStackLabel
            // 
            this.undoStackLabel.AutoSize = true;
            this.undoStackLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoStackLabel.Location = new System.Drawing.Point(403, 10);
            this.undoStackLabel.Name = "undoStackLabel";
            this.undoStackLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.undoStackLabel.Size = new System.Drawing.Size(384, 16);
            this.undoStackLabel.TabIndex = 6;
            this.undoStackLabel.Text = "Undo Stack:";
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.editor, 2);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 338);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(774, 249);
            this.editor.TabIndex = 2;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // appendButton
            // 
            this.appendButton.AutoSize = true;
            this.appendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentTableLayoutPanel.SetColumnSpan(this.appendButton, 2);
            this.appendButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appendButton.Location = new System.Drawing.Point(13, 293);
            this.appendButton.Margin = new System.Windows.Forms.Padding(3, 13, 3, 13);
            this.appendButton.Name = "appendButton";
            this.appendButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.appendButton.Size = new System.Drawing.Size(774, 29);
            this.appendButton.TabIndex = 6;
            this.appendButton.Text = "Append text using a custom change type";
            this.appendButton.UseVisualStyleBackColor = true;
            this.appendButton.Click += new System.EventHandler(this.OnAppendButtonClick);
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.upperRightPanel, 1, 1);
            this.contentTableLayoutPanel.Controls.Add(this.upperLeftPanel, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.appendButton, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.undoStackLabel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.redoStackLabel, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 3);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 4;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.upperLeftPanel.ResumeLayout(false);
            this.upperRightPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel upperLeftPanel;
		private System.Windows.Forms.Panel upperRightPanel;
		private System.Windows.Forms.Label redoStackLabel;
		private System.Windows.Forms.Label undoStackLabel;
		private System.Windows.Forms.ListBox redoStack;
		private System.Windows.Forms.ListBox undoStack;
		private System.Windows.Forms.Button appendButton;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
