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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.upperPanel = new System.Windows.Forms.Panel();
            this.upperLeftPanel = new System.Windows.Forms.Panel();
            this.redoStack = new System.Windows.Forms.ListBox();
            this.redoStackLabel = new System.Windows.Forms.Label();
            this.upperRightPanel = new System.Windows.Forms.Panel();
            this.undoStack = new System.Windows.Forms.ListBox();
            this.undoStackLabel = new System.Windows.Forms.Label();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.appendButton = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.upperLeftPanel.SuspendLayout();
            this.upperRightPanel.SuspendLayout();
            this.lowerPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.upperPanel);
            this.contentPanel.Controls.Add(this.lowerPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // upperPanel
            // 
            this.upperPanel.Controls.Add(this.upperLeftPanel);
            this.upperPanel.Controls.Add(this.upperRightPanel);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(780, 295);
            this.upperPanel.TabIndex = 7;
            // 
            // upperLeftPanel
            // 
            this.upperLeftPanel.Controls.Add(this.redoStack);
            this.upperLeftPanel.Controls.Add(this.redoStackLabel);
            this.upperLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upperLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.upperLeftPanel.Name = "upperLeftPanel";
            this.upperLeftPanel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.upperLeftPanel.Size = new System.Drawing.Size(395, 295);
            this.upperLeftPanel.TabIndex = 0;
            // 
            // redoStack
            // 
            this.redoStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redoStack.FormattingEnabled = true;
            this.redoStack.ItemHeight = 15;
            this.redoStack.Location = new System.Drawing.Point(0, 18);
            this.redoStack.Name = "redoStack";
            this.redoStack.Size = new System.Drawing.Size(385, 277);
            this.redoStack.TabIndex = 6;
            this.redoStack.DoubleClick += new System.EventHandler(this.OnRedoStackListBoxDoubleClick);
            // 
            // redoStackLabel
            // 
            this.redoStackLabel.AutoSize = true;
            this.redoStackLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.redoStackLabel.Location = new System.Drawing.Point(0, 0);
            this.redoStackLabel.Name = "redoStackLabel";
            this.redoStackLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.redoStackLabel.Size = new System.Drawing.Size(68, 18);
            this.redoStackLabel.TabIndex = 5;
            this.redoStackLabel.Text = "Redo Stack:";
            // 
            // upperRightPanel
            // 
            this.upperRightPanel.Controls.Add(this.undoStack);
            this.upperRightPanel.Controls.Add(this.undoStackLabel);
            this.upperRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.upperRightPanel.Location = new System.Drawing.Point(395, 0);
            this.upperRightPanel.Name = "upperRightPanel";
            this.upperRightPanel.Size = new System.Drawing.Size(385, 295);
            this.upperRightPanel.TabIndex = 1;
            // 
            // undoStack
            // 
            this.undoStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoStack.FormattingEnabled = true;
            this.undoStack.ItemHeight = 15;
            this.undoStack.Location = new System.Drawing.Point(0, 18);
            this.undoStack.Name = "undoStack";
            this.undoStack.Size = new System.Drawing.Size(385, 277);
            this.undoStack.TabIndex = 7;
            this.undoStack.DoubleClick += new System.EventHandler(this.OnUndoStackListBoxDoubleClick);
            // 
            // undoStackLabel
            // 
            this.undoStackLabel.AutoSize = true;
            this.undoStackLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.undoStackLabel.Location = new System.Drawing.Point(0, 0);
            this.undoStackLabel.Name = "undoStackLabel";
            this.undoStackLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.undoStackLabel.Size = new System.Drawing.Size(70, 18);
            this.undoStackLabel.TabIndex = 6;
            this.undoStackLabel.Text = "Undo Stack:";
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.editor);
            this.lowerPanel.Controls.Add(this.buttonPanel);
            this.lowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerPanel.Location = new System.Drawing.Point(0, 295);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(780, 285);
            this.lowerPanel.TabIndex = 6;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.AreWordWrapGlyphsVisible = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 48);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(780, 237);
            this.editor.TabIndex = 2;
            this.editor.Text = resources.GetString("editor.Text");
            this.editor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.appendButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.buttonPanel.Size = new System.Drawing.Size(780, 48);
            this.buttonPanel.TabIndex = 6;
            // 
            // appendButton
            // 
            this.appendButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appendButton.Location = new System.Drawing.Point(0, 10);
            this.appendButton.Name = "appendButton";
            this.appendButton.Size = new System.Drawing.Size(780, 28);
            this.appendButton.TabIndex = 6;
            this.appendButton.Text = "Append text using a custom change type";
            this.appendButton.UseVisualStyleBackColor = true;
            this.appendButton.Click += new System.EventHandler(this.OnAppendButtonClick);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            this.upperPanel.ResumeLayout(false);
            this.upperLeftPanel.ResumeLayout(false);
            this.upperLeftPanel.PerformLayout();
            this.upperRightPanel.ResumeLayout(false);
            this.upperRightPanel.PerformLayout();
            this.lowerPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.Panel lowerPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel upperPanel;
		private System.Windows.Forms.Panel upperLeftPanel;
		private System.Windows.Forms.Panel upperRightPanel;
		private System.Windows.Forms.Label redoStackLabel;
		private System.Windows.Forms.Label undoStackLabel;
		private System.Windows.Forms.ListBox redoStack;
		private System.Windows.Forms.ListBox undoStack;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button appendButton;
	}
}
