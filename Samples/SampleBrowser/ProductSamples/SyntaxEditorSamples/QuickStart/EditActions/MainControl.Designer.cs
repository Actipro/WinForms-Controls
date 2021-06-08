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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.editor = new ActiproSoftware.UI.WinForms.Controls.SyntaxEditor.SyntaxEditor();
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.editActionsListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.builtInActionsLabel = new System.Windows.Forms.Label();
            this.customActionButtonsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.executeCustomActionButton = new System.Windows.Forms.Button();
            this.bindCustomActionButton = new System.Windows.Forms.Button();
            this.unbindCustomActionButton = new System.Windows.Forms.Button();
            this.customActionsDescriptionLabel = new System.Windows.Forms.Label();
            this.customActionsHeaderLabel = new System.Windows.Forms.Label();
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contentPanel.SuspendLayout();
            this.actionsPanel.SuspendLayout();
            this.customActionButtonsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.editor);
            this.contentPanel.Controls.Add(this.actionsPanel);
            this.contentPanel.Location = new System.Drawing.Point(10, 10);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(780, 580);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.editor.Size = new System.Drawing.Size(350, 580);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // actionsPanel
            // 
            this.actionsPanel.Controls.Add(this.editActionsListView);
            this.actionsPanel.Controls.Add(this.builtInActionsLabel);
            this.actionsPanel.Controls.Add(this.customActionButtonsFlowLayoutPanel);
            this.actionsPanel.Controls.Add(this.customActionsDescriptionLabel);
            this.actionsPanel.Controls.Add(this.customActionsHeaderLabel);
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionsPanel.Location = new System.Drawing.Point(350, 0);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.actionsPanel.Size = new System.Drawing.Size(430, 580);
            this.actionsPanel.TabIndex = 3;
            this.actionsPanel.Resize += new System.EventHandler(this.OnActionsPanelResize);
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
            this.editActionsListView.Location = new System.Drawing.Point(10, 105);
            this.editActionsListView.MultiSelect = false;
            this.editActionsListView.Name = "editActionsListView";
            this.editActionsListView.Size = new System.Drawing.Size(420, 465);
            this.editActionsListView.TabIndex = 1;
            this.editActionsListView.UseCompatibleStateImageBehavior = false;
            this.editActionsListView.View = System.Windows.Forms.View.Details;
            this.editActionsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnEditActionsListViewMouseDoubleClick);
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
            this.builtInActionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.builtInActionsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.builtInActionsLabel.Location = new System.Drawing.Point(10, 71);
            this.builtInActionsLabel.Name = "builtInActionsLabel";
            this.builtInActionsLabel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 4);
            this.builtInActionsLabel.Size = new System.Drawing.Size(261, 34);
            this.builtInActionsLabel.TabIndex = 4;
            this.builtInActionsLabel.Text = "Built-in Edit Actions (double-click to execute):";
            // 
            // customActionButtonsFlowLayoutPanel
            // 
            this.customActionButtonsFlowLayoutPanel.AutoSize = true;
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.executeCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.bindCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Controls.Add(this.unbindCustomActionButton);
            this.customActionButtonsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customActionButtonsFlowLayoutPanel.Location = new System.Drawing.Point(10, 37);
            this.customActionButtonsFlowLayoutPanel.Name = "customActionButtonsFlowLayoutPanel";
            this.customActionButtonsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.customActionButtonsFlowLayoutPanel.Size = new System.Drawing.Size(420, 34);
            this.customActionButtonsFlowLayoutPanel.TabIndex = 3;
            // 
            // executeCustomActionButton
            // 
            this.executeCustomActionButton.AutoSize = true;
            this.executeCustomActionButton.Location = new System.Drawing.Point(3, 6);
            this.executeCustomActionButton.Name = "executeCustomActionButton";
            this.executeCustomActionButton.Size = new System.Drawing.Size(96, 25);
            this.executeCustomActionButton.TabIndex = 0;
            this.executeCustomActionButton.Text = "Execute Action";
            this.executeCustomActionButton.UseVisualStyleBackColor = true;
            this.executeCustomActionButton.Click += new System.EventHandler(this.OnExecuteCustomActionButtonClick);
            // 
            // bindCustomActionButton
            // 
            this.bindCustomActionButton.AutoSize = true;
            this.bindCustomActionButton.Location = new System.Drawing.Point(105, 6);
            this.bindCustomActionButton.Name = "bindCustomActionButton";
            this.bindCustomActionButton.Size = new System.Drawing.Size(92, 25);
            this.bindCustomActionButton.TabIndex = 1;
            this.bindCustomActionButton.Text = "Bind to Ctrl+P";
            this.bindCustomActionButton.UseVisualStyleBackColor = true;
            this.bindCustomActionButton.Click += new System.EventHandler(this.OnBindCustomActionButtonClick);
            // 
            // unbindCustomActionButton
            // 
            this.unbindCustomActionButton.AutoSize = true;
            this.unbindCustomActionButton.Location = new System.Drawing.Point(203, 6);
            this.unbindCustomActionButton.Name = "unbindCustomActionButton";
            this.unbindCustomActionButton.Size = new System.Drawing.Size(93, 25);
            this.unbindCustomActionButton.TabIndex = 2;
            this.unbindCustomActionButton.Text = "Unbind Ctrl+P";
            this.unbindCustomActionButton.UseVisualStyleBackColor = true;
            this.unbindCustomActionButton.Click += new System.EventHandler(this.OnUnbindCustomActionButtonClick);
            // 
            // customActionsDescriptionLabel
            // 
            this.customActionsDescriptionLabel.AutoSize = true;
            this.customActionsDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customActionsDescriptionLabel.Location = new System.Drawing.Point(10, 19);
            this.customActionsDescriptionLabel.Name = "customActionsDescriptionLabel";
            this.customActionsDescriptionLabel.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.customActionsDescriptionLabel.Size = new System.Drawing.Size(887, 18);
            this.customActionsDescriptionLabel.TabIndex = 2;
            this.customActionsDescriptionLabel.Text = "This sample includes source code for a custom edit action that inserts <custom> t" +
    "ags around the selected text.  Use these buttons to work with the custom edit ac" +
    "tion.";
            // 
            // customActionsHeaderLabel
            // 
            this.customActionsHeaderLabel.AutoSize = true;
            this.customActionsHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customActionsHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customActionsHeaderLabel.Location = new System.Drawing.Point(10, 0);
            this.customActionsHeaderLabel.Name = "customActionsHeaderLabel";
            this.customActionsHeaderLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.customActionsHeaderLabel.Size = new System.Drawing.Size(115, 19);
            this.customActionsHeaderLabel.TabIndex = 0;
            this.customActionsHeaderLabel.Text = "Custom Edit Action:";
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 100;
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
            this.actionsPanel.ResumeLayout(false);
            this.actionsPanel.PerformLayout();
            this.customActionButtonsFlowLayoutPanel.ResumeLayout(false);
            this.customActionButtonsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.Panel actionsPanel;
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
	}
}
