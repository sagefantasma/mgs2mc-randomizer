namespace MGS2_Randomizer
{
    partial class RandomizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomizationForm));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.restoreBaseGameButton = new System.Windows.Forms.Button();
            this.customSeedCheckbox = new System.Windows.Forms.CheckBox();
            this.seedUpDown = new System.Windows.Forms.NumericUpDown();
            this.customSeedLabel = new System.Windows.Forms.Label();
            this.executionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mgs2ExeTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.randomizeStartingItemsCheckbox = new System.Windows.Forms.CheckBox();
            this.allWeaponsWillSpawnCheckbox = new System.Windows.Forms.CheckBox();
            this.randomizeRationsCheckbox = new System.Windows.Forms.CheckBox();
            this.randomizeEFConnectingBridgeClaymores = new System.Windows.Forms.CheckBox();
            this.randomizeBombLocations = new System.Windows.Forms.CheckBox();
            this.randomizeAutomaticRewardsCheckbox = new System.Windows.Forms.CheckBox();
            this.restrictNikitaCheckbox = new System.Windows.Forms.CheckBox();
            this.seedAlwaysBeatableCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.seedUpDown)).BeginInit();
            this.executionFlowLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // randomizeButton
            // 
            this.randomizeButton.BackColor = System.Drawing.Color.IndianRed;
            this.randomizeButton.Location = new System.Drawing.Point(169, 29);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(160, 41);
            this.randomizeButton.TabIndex = 4;
            this.randomizeButton.Text = "Randomize Game Files";
            this.randomizeButton.UseVisualStyleBackColor = false;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // restoreBaseGameButton
            // 
            this.restoreBaseGameButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.restoreBaseGameButton.Location = new System.Drawing.Point(3, 29);
            this.restoreBaseGameButton.Name = "restoreBaseGameButton";
            this.restoreBaseGameButton.Size = new System.Drawing.Size(160, 41);
            this.restoreBaseGameButton.TabIndex = 3;
            this.restoreBaseGameButton.Text = "Restore to Vanilla State";
            this.restoreBaseGameButton.UseVisualStyleBackColor = false;
            this.restoreBaseGameButton.Click += new System.EventHandler(this.restoreBaseGameButton_Click);
            // 
            // customSeedCheckbox
            // 
            this.customSeedCheckbox.AutoSize = true;
            this.customSeedCheckbox.Location = new System.Drawing.Point(205, 5);
            this.customSeedCheckbox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.customSeedCheckbox.Name = "customSeedCheckbox";
            this.customSeedCheckbox.Size = new System.Drawing.Size(125, 17);
            this.customSeedCheckbox.TabIndex = 2;
            this.customSeedCheckbox.Text = "Enable Custom Seed";
            this.customSeedCheckbox.UseVisualStyleBackColor = true;
            this.customSeedCheckbox.CheckedChanged += new System.EventHandler(this.customSeedCheckbox_CheckedChanged);
            // 
            // seedUpDown
            // 
            this.seedUpDown.Enabled = false;
            this.seedUpDown.Location = new System.Drawing.Point(79, 3);
            this.seedUpDown.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.seedUpDown.Name = "seedUpDown";
            this.seedUpDown.Size = new System.Drawing.Size(120, 20);
            this.seedUpDown.TabIndex = 0;
            // 
            // customSeedLabel
            // 
            this.customSeedLabel.AutoSize = true;
            this.customSeedLabel.Location = new System.Drawing.Point(3, 6);
            this.customSeedLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.customSeedLabel.Name = "customSeedLabel";
            this.customSeedLabel.Size = new System.Drawing.Size(70, 13);
            this.customSeedLabel.TabIndex = 1;
            this.customSeedLabel.Text = "Custom Seed";
            this.customSeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // executionFlowLayoutPanel
            // 
            this.executionFlowLayoutPanel.Controls.Add(this.customSeedLabel);
            this.executionFlowLayoutPanel.Controls.Add(this.seedUpDown);
            this.executionFlowLayoutPanel.Controls.Add(this.customSeedCheckbox);
            this.executionFlowLayoutPanel.Controls.Add(this.restoreBaseGameButton);
            this.executionFlowLayoutPanel.Controls.Add(this.randomizeButton);
            this.executionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.executionFlowLayoutPanel.Location = new System.Drawing.Point(0, 246);
            this.executionFlowLayoutPanel.Name = "executionFlowLayoutPanel";
            this.executionFlowLayoutPanel.Size = new System.Drawing.Size(333, 71);
            this.executionFlowLayoutPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.mgs2ExeTextBox);
            this.flowLayoutPanel1.Controls.Add(this.browseButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 40);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "MGS2 Location:";
            // 
            // mgs2ExeTextBox
            // 
            this.mgs2ExeTextBox.Enabled = false;
            this.mgs2ExeTextBox.Location = new System.Drawing.Point(93, 3);
            this.mgs2ExeTextBox.Multiline = true;
            this.mgs2ExeTextBox.Name = "mgs2ExeTextBox";
            this.mgs2ExeTextBox.Size = new System.Drawing.Size(150, 33);
            this.mgs2ExeTextBox.TabIndex = 101;
            this.mgs2ExeTextBox.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.browseButton.Location = new System.Drawing.Point(249, 8);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 102;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.randomizeStartingItemsCheckbox);
            this.optionsGroupBox.Controls.Add(this.allWeaponsWillSpawnCheckbox);
            this.optionsGroupBox.Controls.Add(this.randomizeRationsCheckbox);
            this.optionsGroupBox.Controls.Add(this.randomizeEFConnectingBridgeClaymores);
            this.optionsGroupBox.Controls.Add(this.randomizeBombLocations);
            this.optionsGroupBox.Controls.Add(this.randomizeAutomaticRewardsCheckbox);
            this.optionsGroupBox.Controls.Add(this.restrictNikitaCheckbox);
            this.optionsGroupBox.Controls.Add(this.seedAlwaysBeatableCheckbox);
            this.optionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGroupBox.Location = new System.Drawing.Point(0, 40);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(333, 206);
            this.optionsGroupBox.TabIndex = 8;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // randomizeStartingItemsCheckbox
            // 
            this.randomizeStartingItemsCheckbox.AutoSize = true;
            this.randomizeStartingItemsCheckbox.Location = new System.Drawing.Point(4, 109);
            this.randomizeStartingItemsCheckbox.Name = "randomizeStartingItemsCheckbox";
            this.randomizeStartingItemsCheckbox.Size = new System.Drawing.Size(146, 17);
            this.randomizeStartingItemsCheckbox.TabIndex = 7;
            this.randomizeStartingItemsCheckbox.Text = "Randomize Starting Items";
            this.randomizeStartingItemsCheckbox.UseVisualStyleBackColor = true;
            this.randomizeStartingItemsCheckbox.CheckedChanged += new System.EventHandler(this.randomizeStartingItemsCheckbox_CheckedChanged);
            // 
            // allWeaponsWillSpawnCheckbox
            // 
            this.allWeaponsWillSpawnCheckbox.AutoSize = true;
            this.allWeaponsWillSpawnCheckbox.Location = new System.Drawing.Point(4, 63);
            this.allWeaponsWillSpawnCheckbox.Name = "allWeaponsWillSpawnCheckbox";
            this.allWeaponsWillSpawnCheckbox.Size = new System.Drawing.Size(142, 17);
            this.allWeaponsWillSpawnCheckbox.TabIndex = 6;
            this.allWeaponsWillSpawnCheckbox.Text = "All Weapons Will Spawn";
            this.allWeaponsWillSpawnCheckbox.UseVisualStyleBackColor = true;
            this.allWeaponsWillSpawnCheckbox.CheckedChanged += new System.EventHandler(this.allWeaponsWillSpawnCheckbox_CheckedChanged);
            // 
            // randomizeRationsCheckbox
            // 
            this.randomizeRationsCheckbox.AutoSize = true;
            this.randomizeRationsCheckbox.Checked = true;
            this.randomizeRationsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomizeRationsCheckbox.Location = new System.Drawing.Point(4, 86);
            this.randomizeRationsCheckbox.Name = "randomizeRationsCheckbox";
            this.randomizeRationsCheckbox.Size = new System.Drawing.Size(118, 17);
            this.randomizeRationsCheckbox.TabIndex = 5;
            this.randomizeRationsCheckbox.Text = "Randomize Rations";
            this.randomizeRationsCheckbox.UseVisualStyleBackColor = true;
            this.randomizeRationsCheckbox.CheckedChanged += new System.EventHandler(this.randomizeRationsCheckbox_CheckedChanged);
            // 
            // randomizeEFConnectingBridgeClaymores
            // 
            this.randomizeEFConnectingBridgeClaymores.AutoSize = true;
            this.randomizeEFConnectingBridgeClaymores.Location = new System.Drawing.Point(4, 178);
            this.randomizeEFConnectingBridgeClaymores.Name = "randomizeEFConnectingBridgeClaymores";
            this.randomizeEFConnectingBridgeClaymores.Size = new System.Drawing.Size(236, 17);
            this.randomizeEFConnectingBridgeClaymores.TabIndex = 4;
            this.randomizeEFConnectingBridgeClaymores.Text = "Randomize EF Connecting Bridge Claymores";
            this.randomizeEFConnectingBridgeClaymores.UseVisualStyleBackColor = true;
            this.randomizeEFConnectingBridgeClaymores.CheckedChanged += new System.EventHandler(this.randomizeEFConnectingBridgeClaymores_CheckedChanged);
            // 
            // randomizeBombLocations
            // 
            this.randomizeBombLocations.AutoSize = true;
            this.randomizeBombLocations.Location = new System.Drawing.Point(4, 155);
            this.randomizeBombLocations.Name = "randomizeBombLocations";
            this.randomizeBombLocations.Size = new System.Drawing.Size(335, 17);
            this.randomizeBombLocations.TabIndex = 3;
            this.randomizeBombLocations.Text = "Randomize Bomb Locations (Sensor A Does Not Reflect Position)";
            this.randomizeBombLocations.UseVisualStyleBackColor = true;
            this.randomizeBombLocations.CheckedChanged += new System.EventHandler(this.randomizeBombLocations_CheckedChanged);
            // 
            // randomizeAutomaticRewardsCheckbox
            // 
            this.randomizeAutomaticRewardsCheckbox.AutoSize = true;
            this.randomizeAutomaticRewardsCheckbox.Location = new System.Drawing.Point(4, 132);
            this.randomizeAutomaticRewardsCheckbox.Name = "randomizeAutomaticRewardsCheckbox";
            this.randomizeAutomaticRewardsCheckbox.Size = new System.Drawing.Size(290, 17);
            this.randomizeAutomaticRewardsCheckbox.TabIndex = 2;
            this.randomizeAutomaticRewardsCheckbox.Text = "Randomize Automatic Rewards(Does not include Cards)";
            this.randomizeAutomaticRewardsCheckbox.UseVisualStyleBackColor = true;
            this.randomizeAutomaticRewardsCheckbox.CheckedChanged += new System.EventHandler(this.randomizeAutomaticRewardsCheckbox_CheckedChanged);
            // 
            // restrictNikitaCheckbox
            // 
            this.restrictNikitaCheckbox.AutoSize = true;
            this.restrictNikitaCheckbox.Checked = true;
            this.restrictNikitaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.restrictNikitaCheckbox.Location = new System.Drawing.Point(4, 40);
            this.restrictNikitaCheckbox.Name = "restrictNikitaCheckbox";
            this.restrictNikitaCheckbox.Size = new System.Drawing.Size(139, 17);
            this.restrictNikitaCheckbox.TabIndex = 1;
            this.restrictNikitaCheckbox.Text = "Restrict Nikita to Shell 2";
            this.restrictNikitaCheckbox.UseVisualStyleBackColor = true;
            this.restrictNikitaCheckbox.CheckedChanged += new System.EventHandler(this.restrictNikitaCheckbox_CheckedChanged);
            // 
            // seedAlwaysBeatableCheckbox
            // 
            this.seedAlwaysBeatableCheckbox.AutoSize = true;
            this.seedAlwaysBeatableCheckbox.Checked = true;
            this.seedAlwaysBeatableCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.seedAlwaysBeatableCheckbox.Location = new System.Drawing.Point(4, 17);
            this.seedAlwaysBeatableCheckbox.Name = "seedAlwaysBeatableCheckbox";
            this.seedAlwaysBeatableCheckbox.Size = new System.Drawing.Size(132, 17);
            this.seedAlwaysBeatableCheckbox.TabIndex = 0;
            this.seedAlwaysBeatableCheckbox.Text = "Seed Always Beatable";
            this.seedAlwaysBeatableCheckbox.UseVisualStyleBackColor = true;
            this.seedAlwaysBeatableCheckbox.CheckedChanged += new System.EventHandler(this.seedAlwaysBeatableCheckbox_CheckedChanged);
            // 
            // RandomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 317);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.executionFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RandomizationForm";
            this.Text = "MGS2 Randomizer";
            ((System.ComponentModel.ISupportInitialize)(this.seedUpDown)).EndInit();
            this.executionFlowLayoutPanel.ResumeLayout(false);
            this.executionFlowLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.Button restoreBaseGameButton;
        private System.Windows.Forms.CheckBox customSeedCheckbox;
        private System.Windows.Forms.NumericUpDown seedUpDown;
        private System.Windows.Forms.Label customSeedLabel;
        private System.Windows.Forms.FlowLayoutPanel executionFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox randomizeStartingItemsCheckbox;
        private System.Windows.Forms.CheckBox allWeaponsWillSpawnCheckbox;
        private System.Windows.Forms.CheckBox randomizeRationsCheckbox;
        private System.Windows.Forms.CheckBox randomizeEFConnectingBridgeClaymores;
        private System.Windows.Forms.CheckBox randomizeBombLocations;
        private System.Windows.Forms.CheckBox randomizeAutomaticRewardsCheckbox;
        private System.Windows.Forms.CheckBox restrictNikitaCheckbox;
        private System.Windows.Forms.CheckBox seedAlwaysBeatableCheckbox;
        private System.Windows.Forms.TextBox mgs2ExeTextBox;
        private System.Windows.Forms.Button browseButton;
    }
}

