namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.EditActions {
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
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.editActionsListView = new System.Windows.Forms.ListView();
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.builtInActionsLabel = new System.Windows.Forms.Label();
            this.customActionButtonsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.executeCustomActionButton = new System.Windows.Forms.Button();
            this.bindCustomActionButton = new System.Windows.Forms.Button();
            this.unbindCustomActionButton = new System.Windows.Forms.Button();
            this.customActionsDescriptionLabel = new System.Windows.Forms.Label();
            this.customActionsHeaderLabel = new System.Windows.Forms.Label();
            this.contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customActionButtonsFlowLayoutPanel.SuspendLayout();
            this.contentTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(13, 13);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.contentTableLayoutPanel.SetRowSpan(this.editor, 5);
            this.editor.Size = new System.Drawing.Size(384, 574);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // editActionsListView
            // 
            this.editActionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categoryColumnHeader,
            this.nameColumnHeader,
            this.keyColumnHeader});
            this.editActionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editActionsListView.FullRowSelect = true;
            this.editActionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.editActionsListView.HideSelection = false;
            this.editActionsListView.Location = new System.Drawing.Point(403, 152);
            this.editActionsListView.MultiSelect = false;
            this.editActionsListView.Name = "editActionsListView";
            this.editActionsListView.Size = new System.Drawing.Size(384, 435);
            this.editActionsListView.TabIndex = 1;
            this.editActionsListView.UseCompatibleStateImageBehavior = false;
            this.editActionsListView.View = System.Windows.Forms.View.Details;
            this.editActionsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnEditActionsListViewMouseDoubleClick);
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 150;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 210;
            // 
            // keyColumnHeader
            // 
            this.keyColumnHeader.Text = "Key";
            this.keyColumnHeader.Width = 50;
            // 
            // builtInActionsLabel
            // 
            this.builtInActionsLabel.AutoSize = true;
            this.builtInActionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.builtInActionsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.builtInActionsLabel.Location = new System.Drawing.Point(403, 115);
            this.builtInActionsLabel.Name = "builtInActionsLabel";
            this.builtInActionsLabel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 4);
            this.builtInActionsLabel.Size = new System.Drawing.Size(384, 34);
            this.builtInActionsLabel.TabIndex = 4;
            this.builtInActionsLabel.Text = "Built-in Edit Actions (double-click to execute):";
            // 
            // customActionButtonsFlowLayoutPanel
            // 
            this.customActionButtonsFlowLayoutPanel.AutoSize = true;
            this.customActionButtonsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.executeCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.bindCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.unbindCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customActionButtonsFlowLayoutPanel.Location = new System.Drawing.Point(403, 74);
            this.customActionButtonsFlowLayoutPanel.Name = "customActionButtonsFlowLayoutPanel";
            this.customActionButtonsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.customActionButtonsFlowLayoutPanel.Size = new System.Drawing.Size(384, 38);
            this.customActionButtonsFlowLayoutPanel.TabIndex = 3;
            // 
            // executeCustomActionButton
            // 
            this.executeCustomActionButton.AutoSize = true;
            this.executeCustomActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.executeCustomActionButton.Location = new System.Drawing.Point(3, 6);
            this.executeCustomActionButton.Name = "executeCustomActionButton";
            this.executeCustomActionButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.executeCustomActionButton.Size = new System.Drawing.Size(109, 29);
            this.executeCustomActionButton.TabIndex = 0;
            this.executeCustomActionButton.Text = "Execute Action";
            this.executeCustomActionButton.UseVisualStyleBackColor = true;
            this.executeCustomActionButton.Click += new System.EventHandler(this.OnExecuteCustomActionButtonClick);
            // 
            // bindCustomActionButton
            // 
            this.bindCustomActionButton.AutoSize = true;
            this.bindCustomActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bindCustomActionButton.Location = new System.Drawing.Point(118, 6);
            this.bindCustomActionButton.Name = "bindCustomActionButton";
            this.bindCustomActionButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.bindCustomActionButton.Size = new System.Drawing.Size(101, 29);
            this.bindCustomActionButton.TabIndex = 1;
            this.bindCustomActionButton.Text = "Bind to Ctrl+P";
            this.bindCustomActionButton.UseVisualStyleBackColor = true;
            this.bindCustomActionButton.Click += new System.EventHandler(this.OnBindCustomActionButtonClick);
            // 
            // unbindCustomActionButton
            // 
            this.unbindCustomActionButton.AutoSize = true;
            this.unbindCustomActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.unbindCustomActionButton.Location = new System.Drawing.Point(225, 6);
            this.unbindCustomActionButton.Name = "unbindCustomActionButton";
            this.unbindCustomActionButton.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.unbindCustomActionButton.Size = new System.Drawing.Size(102, 29);
            this.unbindCustomActionButton.TabIndex = 2;
            this.unbindCustomActionButton.Text = "Unbind Ctrl+P";
            this.unbindCustomActionButton.UseVisualStyleBackColor = true;
            this.unbindCustomActionButton.Click += new System.EventHandler(this.OnUnbindCustomActionButtonClick);
            // 
            // customActionsDescriptionLabel
            // 
            this.customActionsDescriptionLabel.AutoSize = true;
            this.customActionsDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customActionsDescriptionLabel.Location = new System.Drawing.Point(403, 29);
            this.customActionsDescriptionLabel.Name = "customActionsDescriptionLabel";
            this.customActionsDescriptionLabel.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.customActionsDescriptionLabel.Size = new System.Drawing.Size(384, 42);
            this.customActionsDescriptionLabel.TabIndex = 2;
            this.customActionsDescriptionLabel.Text = "This sample includes source code for a custom edit action that inserts <custom> t" +
    "ags around the selected text.  Use these buttons to work with the custom edit ac" +
    "tion.";
            // 
            // customActionsHeaderLabel
            // 
            this.customActionsHeaderLabel.AutoSize = true;
            this.customActionsHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customActionsHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customActionsHeaderLabel.Location = new System.Drawing.Point(403, 10);
            this.customActionsHeaderLabel.Name = "customActionsHeaderLabel";
            this.customActionsHeaderLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.customActionsHeaderLabel.Size = new System.Drawing.Size(384, 19);
            this.customActionsHeaderLabel.TabIndex = 0;
            this.customActionsHeaderLabel.Text = "Custom Edit Action:";
            // 
            // contentTableLayoutPanel
            // 
            this.contentTableLayoutPanel.ColumnCount = 2;
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contentTableLayoutPanel.Controls.Add(this.editActionsListView, 1, 4);
            this.contentTableLayoutPanel.Controls.Add(this.editor, 0, 0);
            this.contentTableLayoutPanel.Controls.Add(this.builtInActionsLabel, 1, 3);
            this.contentTableLayoutPanel.Controls.Add(this.customActionsHeaderLabel, 1, 0);
            this.contentTableLayoutPanel.Controls.Add(this.customActionButtonsFlowLayoutPanel, 1, 2);
            this.contentTableLayoutPanel.Controls.Add(this.customActionsDescriptionLabel, 1, 1);
            this.contentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.contentTableLayoutPanel.Name = "contentTableLayoutPanel";
            this.contentTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentTableLayoutPanel.RowCount = 5;
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
            this.customActionButtonsFlowLayoutPanel.ResumeLayout(false);
            this.customActionButtonsFlowLayoutPanel.PerformLayout();
            this.contentTableLayoutPanel.ResumeLayout(false);
            this.contentTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ListView editActionsListView;
		private System.Windows.Forms.Label customActionsHeaderLabel;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.ColumnHeader keyColumnHeader;
		private System.Windows.Forms.FlowLayoutPanel customActionButtonsFlowLayoutPanel;
		private System.Windows.Forms.Button executeCustomActionButton;
		private System.Windows.Forms.Button bindCustomActionButton;
		private System.Windows.Forms.Button unbindCustomActionButton;
		private System.Windows.Forms.Label customActionsDescriptionLabel;
		private System.Windows.Forms.Label builtInActionsLabel;
		private System.Windows.Forms.ColumnHeader categoryColumnHeader;
		private System.Windows.Forms.TableLayoutPanel contentTableLayoutPanel;
	}
}
