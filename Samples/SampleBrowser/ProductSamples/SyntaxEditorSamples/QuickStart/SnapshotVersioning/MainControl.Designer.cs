namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.SnapshotVersioning {
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
            this.topEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.topEditorLabel = new System.Windows.Forms.Label();
            this.heading3Label = new System.Windows.Forms.Label();
            this.heading2Label = new System.Windows.Forms.Label();
            this.heading1Label = new System.Windows.Forms.Label();
            this.bottomEditor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.bottomEditorLabel = new System.Windows.Forms.Label();
            this.snapshotListBox = new System.Windows.Forms.ListBox();
            this.snapshotLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contentTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topEditor
            // 
            this.topEditor.AllowDrop = true;
            this.topEditor.AreWordWrapGlyphsVisible = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.topEditor, 2);
            this.topEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topEditor.IsLineNumberMarginVisible = true;
            this.topEditor.Location = new System.Drawing.Point(13, 145);
            this.topEditor.Name = "topEditor";
            this.topEditor.OverrideCursor = null;
            this.topEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.topEditor.Size = new System.Drawing.Size(774, 203);
            this.topEditor.TabIndex = 3;
            this.topEditor.Text = resources.GetString("topEditor.Text");
            this.topEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            this.topEditor.DocumentTextChanged += new System.EventHandler<ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.EditorSnapshotChangedEventArgs>(this.OnTopEditorDocumentTextChanged);
            // 
            // topEditorLabel
            // 
            this.topEditorLabel.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.topEditorLabel, 2);
            this.topEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topEditorLabel.Location = new System.Drawing.Point(13, 112);
            this.topEditorLabel.Name = "topEditorLabel";
            this.topEditorLabel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 3);
            this.topEditorLabel.Size = new System.Drawing.Size(774, 30);
            this.topEditorLabel.TabIndex = 7;
            this.topEditorLabel.Text = "Edit Code to Create New Snapshots:";
            // 
            // heading3Label
            // 
            this.heading3Label.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.heading3Label, 2);
            this.heading3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading3Label.Location = new System.Drawing.Point(13, 74);
            this.heading3Label.Name = "heading3Label";
            this.heading3Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading3Label.Size = new System.Drawing.Size(774, 38);
            this.heading3Label.TabIndex = 6;
            this.heading3Label.Text = "Snapshots do their best to \"share\" common data, thereby reducing memory. Also whe" +
    "n snapshots are no longer referenced, they are garbage collected and the memory " +
    "used drops away.";
            // 
            // heading2Label
            // 
            this.heading2Label.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.heading2Label, 2);
            this.heading2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading2Label.Location = new System.Drawing.Point(13, 36);
            this.heading2Label.Name = "heading2Label";
            this.heading2Label.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.heading2Label.Size = new System.Drawing.Size(774, 38);
            this.heading2Label.TabIndex = 5;
            this.heading2Label.Text = resources.GetString("heading2Label.Text");
            // 
            // heading1Label
            // 
            this.heading1Label.AutoSize = true;
            this.contentTableLayoutPanel.SetColumnSpan(this.heading1Label, 2);
            this.heading1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading1Label.Location = new System.Drawing.Point(13, 10);
            this.heading1Label.Name = "heading1Label";
            this.heading1Label.Size = new System.Drawing.Size(774, 26);
            this.heading1Label.TabIndex = 4;
            this.heading1Label.Text = resources.GetString("heading1Label.Text");
            // 
            // bottomEditor
            // 
            this.bottomEditor.AllowDrop = true;
            this.bottomEditor.AreWordWrapGlyphsVisible = true;
            this.bottomEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomEditor.Document.IsReadOnly = true;
            this.bottomEditor.IsLineNumberMarginVisible = true;
            this.bottomEditor.Location = new System.Drawing.Point(247, 384);
            this.bottomEditor.Name = "bottomEditor";
            this.bottomEditor.OverrideCursor = null;
            this.bottomEditor.PrintSettings.AreColumnGuidesVisible = false;
            this.bottomEditor.Size = new System.Drawing.Size(540, 203);
            this.bottomEditor.TabIndex = 2;
            this.bottomEditor.WordWrapMode = ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.WordWrapMode.Word;
            // 
            // bottomEditorLabel
            // 
            this.bottomEditorLabel.AutoSize = true;
            this.bottomEditorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomEditorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomEditorLabel.Location = new System.Drawing.Point(247, 351);
            this.bottomEditorLabel.Name = "bottomEditorLabel";
            this.bottomEditorLabel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 3);
            this.bottomEditorLabel.Size = new System.Drawing.Size(540, 30);
            this.bottomEditorLabel.TabIndex = 8;
            this.bottomEditorLabel.Text = "Selected Snapshot Viewer:";
            // 
            // snapshotListBox
            // 
            this.snapshotListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapshotListBox.FormattingEnabled = true;
            this.snapshotListBox.Location = new System.Drawing.Point(0, 0);
            this.snapshotListBox.Name = "snapshotListBox";
            this.snapshotListBox.Size = new System.Drawing.Size(228, 203);
            this.snapshotListBox.TabIndex = 10;
            this.snapshotListBox.SelectedIndexChanged += new System.EventHandler(this.OnSnapshotListBoxSelectedIndexChanged);
            // 
            // snapshotLabel
            // 
            this.snapshotLabel.AutoSize = true;
            this.snapshotLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapshotLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapshotLabel.Location = new System.Drawing.Point(13, 351);
            this.snapshotLabel.Name = "snapshotLabel";
            this.snapshotLabel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 3);
            this.snapshotLabel.Size = new System.Drawing.Size(228, 30);
            this.snapshotLabel.TabIndex = 9;
            this.snapshotLabel.Text = "Snapshots:";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.contentTableLayoutPanel.Controls.Add(this.heading1Label, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.heading2Label, 0, 1);
            this.contentTableLayoutPanel.Controls.Add(this.heading3Label, 0, 2);
            this.contentTableLayoutPanel.Controls.Add(this.topEditorLabel, 0, 3);
            this.contentTableLayoutPanel.Controls.Add(this.topEditor, 0, 4);
            this.contentTableLayoutPanel.Controls.Add(this.snapshotLabel, 0, 5);
            this.contentTableLayoutPanel.Controls.Add(this.panel1, 0, 6);
            this.contentTableLayoutPanel.Controls.Add(this.bottomEditorLabel, 1, 5);
            this.contentTableLayoutPanel.Controls.Add(this.bottomEditor, 1, 6);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 7;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.snapshotListBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 203);
            this.panel1.TabIndex = 11;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentTableLayoutPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor bottomEditor;
		private System.Windows.Forms.Label heading3Label;
		private System.Windows.Forms.Label heading2Label;
		private System.Windows.Forms.Label heading1Label;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor topEditor;
		private System.Windows.Forms.Label topEditorLabel;
		private System.Windows.Forms.Label bottomEditorLabel;
		private System.Windows.Forms.ListBox snapshotListBox;
		private System.Windows.Forms.Label snapshotLabel;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
		private System.Windows.Forms.Panel panel1;
	}
}
