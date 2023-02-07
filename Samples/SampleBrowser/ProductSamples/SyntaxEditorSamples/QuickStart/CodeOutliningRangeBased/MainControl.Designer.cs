namespace ActiproSoftware.ProductSamples.SyntaxEditorSamples.QuickStart.CodeOutliningRangeBased {
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
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.outliningToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.collapseToDefinitionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllOutliningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleOutliningExpansionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleAllOutliningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopOutliningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopHidingCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAutomaticOutliningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyDefaultOutliningExpansionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.allowedModeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.activeModeValueToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleHighlightsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contentPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.editor);
            this.contentPanel.Controls.Add(this.mainToolStrip);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.TabIndex = 1;
            // 
            // editor
            // 
            this.editor.AllowDrop = true;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.IsLineNumberMarginVisible = true;
            this.editor.Location = new System.Drawing.Point(10, 35);
            this.editor.Name = "editor";
            this.editor.OverrideCursor = null;
            this.editor.PrintSettings.AreColumnGuidesVisible = false;
            this.editor.Size = new System.Drawing.Size(780, 555);
            this.editor.TabIndex = 1;
            this.editor.Text = resources.GetString("editor.Text");
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.outliningToolStripDropDownButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.allowedModeToolStripComboBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.activeModeValueToolStripLabel,
            this.toolStripSeparator3,
            this.toggleHighlightsToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(10, 10);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(780, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            this.mainToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnMainToolStripItemClicked);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(40, 22);
            this.openToolStripButton.Text = "Open";
            // 
            // outliningToolStripDropDownButton
            // 
            this.outliningToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.outliningToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseToDefinitionsMenuItem,
            this.expandAllOutliningMenuItem,
            this.hideSelectionMenuItem,
            this.toggleOutliningExpansionMenuItem,
            this.toggleAllOutliningMenuItem,
            this.stopOutliningMenuItem,
            this.stopHidingCurrentMenuItem,
            this.startAutomaticOutliningMenuItem,
            this.applyDefaultOutliningExpansionMenuItem});
            this.outliningToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("outliningToolStripDropDownButton.Image")));
            this.outliningToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.outliningToolStripDropDownButton.Name = "outliningToolStripDropDownButton";
            this.outliningToolStripDropDownButton.Size = new System.Drawing.Size(70, 22);
            this.outliningToolStripDropDownButton.Text = "Outlining";
            this.outliningToolStripDropDownButton.DropDownOpening += new System.EventHandler(this.OnOutliningToolStripButtonDropDownOpening);
            this.outliningToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnOutliningToolStripButtonDropDownItemClicked);
            // 
            // collapseToDefinitionsMenuItem
            // 
            this.collapseToDefinitionsMenuItem.Name = "collapseToDefinitionsMenuItem";
            this.collapseToDefinitionsMenuItem.Size = new System.Drawing.Size(256, 22);
            this.collapseToDefinitionsMenuItem.Text = "Collapse to Definitions";
            // 
            // expandAllOutliningMenuItem
            // 
            this.expandAllOutliningMenuItem.Name = "expandAllOutliningMenuItem";
            this.expandAllOutliningMenuItem.Size = new System.Drawing.Size(256, 22);
            this.expandAllOutliningMenuItem.Text = "Expand All Outlining";
            // 
            // hideSelectionMenuItem
            // 
            this.hideSelectionMenuItem.Name = "hideSelectionMenuItem";
            this.hideSelectionMenuItem.Size = new System.Drawing.Size(256, 22);
            this.hideSelectionMenuItem.Text = "Hide Selection";
            // 
            // toggleOutliningExpansionMenuItem
            // 
            this.toggleOutliningExpansionMenuItem.Name = "toggleOutliningExpansionMenuItem";
            this.toggleOutliningExpansionMenuItem.Size = new System.Drawing.Size(256, 22);
            this.toggleOutliningExpansionMenuItem.Text = "Toggle Outlining Expansion";
            // 
            // toggleAllOutliningMenuItem
            // 
            this.toggleAllOutliningMenuItem.Name = "toggleAllOutliningMenuItem";
            this.toggleAllOutliningMenuItem.Size = new System.Drawing.Size(256, 22);
            this.toggleAllOutliningMenuItem.Text = "Toggle All Outlining";
            // 
            // stopOutliningMenuItem
            // 
            this.stopOutliningMenuItem.Name = "stopOutliningMenuItem";
            this.stopOutliningMenuItem.Size = new System.Drawing.Size(256, 22);
            this.stopOutliningMenuItem.Text = "Stop Outlining";
            // 
            // stopHidingCurrentMenuItem
            // 
            this.stopHidingCurrentMenuItem.Name = "stopHidingCurrentMenuItem";
            this.stopHidingCurrentMenuItem.Size = new System.Drawing.Size(256, 22);
            this.stopHidingCurrentMenuItem.Text = "Stop Hiding Current";
            // 
            // startAutomaticOutliningMenuItem
            // 
            this.startAutomaticOutliningMenuItem.Name = "startAutomaticOutliningMenuItem";
            this.startAutomaticOutliningMenuItem.Size = new System.Drawing.Size(256, 22);
            this.startAutomaticOutliningMenuItem.Text = "Start Automatic Outlining";
            // 
            // applyDefaultOutliningExpansionMenuItem
            // 
            this.applyDefaultOutliningExpansionMenuItem.Name = "applyDefaultOutliningExpansionMenuItem";
            this.applyDefaultOutliningExpansionMenuItem.Size = new System.Drawing.Size(256, 22);
            this.applyDefaultOutliningExpansionMenuItem.Text = "Apply Default Outlining Expansion";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel1.Text = "Allowed mode:";
            // 
            // allowedModeToolStripComboBox
            // 
            this.allowedModeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allowedModeToolStripComboBox.Name = "allowedModeToolStripComboBox";
            this.allowedModeToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.allowedModeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.OnAllowedModeComboBoxSelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel2.Text = "Active mode:";
            // 
            // activeModeValueToolStripLabel
            // 
            this.activeModeValueToolStripLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.activeModeValueToolStripLabel.Name = "activeModeValueToolStripLabel";
            this.activeModeValueToolStripLabel.Size = new System.Drawing.Size(37, 22);
            this.activeModeValueToolStripLabel.Text = "Value";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleHighlightsToolStripButton
            // 
            this.toggleHighlightsToolStripButton.Checked = true;
            this.toggleHighlightsToolStripButton.CheckOnClick = true;
            this.toggleHighlightsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleHighlightsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toggleHighlightsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleHighlightsToolStripButton.Image")));
            this.toggleHighlightsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleHighlightsToolStripButton.Name = "toggleHighlightsToolStripButton";
            this.toggleHighlightsToolStripButton.Size = new System.Drawing.Size(183, 22);
            this.toggleHighlightsToolStripButton.Text = "Margin hover highlights enabled";
            this.toggleHighlightsToolStripButton.CheckedChanged += new System.EventHandler(this.OnHighlightsEnabledToggleButtonCheckedChanged);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.contentPanel);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel contentPanel;
		private UI.WinForms.Controls.SyntaxEditor.SyntaxEditor editor;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton outliningToolStripDropDownButton;
		private System.Windows.Forms.ToolStripMenuItem collapseToDefinitionsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expandAllOutliningMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hideSelectionMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toggleOutliningExpansionMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toggleAllOutliningMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopOutliningMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopHidingCurrentMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startAutomaticOutliningMenuItem;
		private System.Windows.Forms.ToolStripMenuItem applyDefaultOutliningExpansionMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox allowedModeToolStripComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripLabel activeModeValueToolStripLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toggleHighlightsToolStripButton;
	}
}
