namespace PalCSVKnitter
{
    partial class PalCSVKnitterApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLinksConfiguration = new System.Windows.Forms.GroupBox();
            this.tableLayoutLinksInGB = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutLinksBoven = new System.Windows.Forms.TableLayoutPanel();
            this.btOpenFolder = new System.Windows.Forms.Button();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.lbConfiguration = new System.Windows.Forms.ListBox();
            this.tableLayoutLinksOnder = new System.Windows.Forms.TableLayoutPanel();
            this.labelTip = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tableLayoutRechts = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxRechtsSelectedItem = new System.Windows.Forms.GroupBox();
            this.tabControlDetailEdit = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tableLayoutRechtsOnder = new System.Windows.Forms.TableLayoutPanel();
            this.btKnit = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.groupBoxLinksConfiguration.SuspendLayout();
            this.tableLayoutLinksInGB.SuspendLayout();
            this.tableLayoutLinksBoven.SuspendLayout();
            this.tableLayoutLinksOnder.SuspendLayout();
            this.tableLayoutRechts.SuspendLayout();
            this.groupBoxRechtsSelectedItem.SuspendLayout();
            this.tabControlDetailEdit.SuspendLayout();
            this.tableLayoutRechtsOnder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMain.Controls.Add(this.groupBoxLinksConfiguration, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutRechts, 1, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1556, 985);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // groupBoxLinksConfiguration
            // 
            this.groupBoxLinksConfiguration.AutoSize = true;
            this.groupBoxLinksConfiguration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLinksConfiguration.Controls.Add(this.tableLayoutLinksInGB);
            this.groupBoxLinksConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLinksConfiguration.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLinksConfiguration.Name = "groupBoxLinksConfiguration";
            this.groupBoxLinksConfiguration.Size = new System.Drawing.Size(927, 979);
            this.groupBoxLinksConfiguration.TabIndex = 0;
            this.groupBoxLinksConfiguration.TabStop = false;
            this.groupBoxLinksConfiguration.Text = "Configuration";
            // 
            // tableLayoutLinksInGB
            // 
            this.tableLayoutLinksInGB.AutoScroll = true;
            this.tableLayoutLinksInGB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutLinksInGB.ColumnCount = 1;
            this.tableLayoutLinksInGB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutLinksInGB.Controls.Add(this.tableLayoutLinksBoven, 0, 0);
            this.tableLayoutLinksInGB.Controls.Add(this.lbConfiguration, 0, 1);
            this.tableLayoutLinksInGB.Controls.Add(this.tableLayoutLinksOnder, 0, 2);
            this.tableLayoutLinksInGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutLinksInGB.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutLinksInGB.Name = "tableLayoutLinksInGB";
            this.tableLayoutLinksInGB.RowCount = 3;
            this.tableLayoutLinksInGB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutLinksInGB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tableLayoutLinksInGB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutLinksInGB.Size = new System.Drawing.Size(921, 941);
            this.tableLayoutLinksInGB.TabIndex = 0;
            // 
            // tableLayoutLinksBoven
            // 
            this.tableLayoutLinksBoven.AutoScroll = true;
            this.tableLayoutLinksBoven.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutLinksBoven.ColumnCount = 2;
            this.tableLayoutLinksBoven.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutLinksBoven.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutLinksBoven.Controls.Add(this.btOpenFolder, 0, 0);
            this.tableLayoutLinksBoven.Controls.Add(this.btSaveConfig, 1, 0);
            this.tableLayoutLinksBoven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutLinksBoven.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutLinksBoven.Name = "tableLayoutLinksBoven";
            this.tableLayoutLinksBoven.RowCount = 1;
            this.tableLayoutLinksBoven.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutLinksBoven.Size = new System.Drawing.Size(915, 59);
            this.tableLayoutLinksBoven.TabIndex = 0;
            // 
            // btOpenFolder
            // 
            this.btOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btOpenFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btOpenFolder.Location = new System.Drawing.Point(3, 3);
            this.btOpenFolder.Name = "btOpenFolder";
            this.btOpenFolder.Size = new System.Drawing.Size(451, 46);
            this.btOpenFolder.TabIndex = 0;
            this.btOpenFolder.Text = "Open Folder";
            this.btOpenFolder.UseVisualStyleBackColor = true;
            this.btOpenFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSaveConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.btSaveConfig.Location = new System.Drawing.Point(460, 3);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(452, 46);
            this.btSaveConfig.TabIndex = 1;
            this.btSaveConfig.Text = "Save Configuration";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            // 
            // lbConfiguration
            // 
            this.lbConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConfiguration.FormattingEnabled = true;
            this.lbConfiguration.ItemHeight = 32;
            this.lbConfiguration.Location = new System.Drawing.Point(3, 68);
            this.lbConfiguration.Name = "lbConfiguration";
            this.lbConfiguration.Size = new System.Drawing.Size(915, 709);
            this.lbConfiguration.TabIndex = 2;
            // 
            // tableLayoutLinksOnder
            // 
            this.tableLayoutLinksOnder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutLinksOnder.ColumnCount = 1;
            this.tableLayoutLinksOnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutLinksOnder.Controls.Add(this.labelTip, 0, 2);
            this.tableLayoutLinksOnder.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutLinksOnder.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutLinksOnder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutLinksOnder.Location = new System.Drawing.Point(3, 783);
            this.tableLayoutLinksOnder.Name = "tableLayoutLinksOnder";
            this.tableLayoutLinksOnder.RowCount = 3;
            this.tableLayoutLinksOnder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutLinksOnder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutLinksOnder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutLinksOnder.Size = new System.Drawing.Size(915, 155);
            this.tableLayoutLinksOnder.TabIndex = 3;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTip.Location = new System.Drawing.Point(3, 84);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(909, 71);
            this.labelTip.TabIndex = 4;
            this.labelTip.Text = "Tip: save your configuration so that it will be automatically\r\nloaded next time y" +
    "ou open this folder.\r\n";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(488, 36);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Consecutive Numbering for \"Data Count\"";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(614, 36);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Consecutive Numbering for \"Cumulative Step Count\"";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutRechts
            // 
            this.tableLayoutRechts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutRechts.ColumnCount = 1;
            this.tableLayoutRechts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutRechts.Controls.Add(this.groupBoxRechtsSelectedItem, 0, 0);
            this.tableLayoutRechts.Controls.Add(this.tableLayoutRechtsOnder, 0, 1);
            this.tableLayoutRechts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutRechts.Location = new System.Drawing.Point(936, 3);
            this.tableLayoutRechts.Name = "tableLayoutRechts";
            this.tableLayoutRechts.RowCount = 2;
            this.tableLayoutRechts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutRechts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutRechts.Size = new System.Drawing.Size(617, 979);
            this.tableLayoutRechts.TabIndex = 1;
            // 
            // groupBoxRechtsSelectedItem
            // 
            this.groupBoxRechtsSelectedItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRechtsSelectedItem.Controls.Add(this.tabControlDetailEdit);
            this.groupBoxRechtsSelectedItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRechtsSelectedItem.Location = new System.Drawing.Point(3, 3);
            this.groupBoxRechtsSelectedItem.Name = "groupBoxRechtsSelectedItem";
            this.groupBoxRechtsSelectedItem.Size = new System.Drawing.Size(611, 826);
            this.groupBoxRechtsSelectedItem.TabIndex = 0;
            this.groupBoxRechtsSelectedItem.TabStop = false;
            this.groupBoxRechtsSelectedItem.Text = "Selected Item";
            // 
            // tabControlDetailEdit
            // 
            this.tabControlDetailEdit.Controls.Add(this.tabDetails);
            this.tabControlDetailEdit.Controls.Add(this.tabEdit);
            this.tabControlDetailEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDetailEdit.Location = new System.Drawing.Point(3, 35);
            this.tabControlDetailEdit.Name = "tabControlDetailEdit";
            this.tabControlDetailEdit.SelectedIndex = 0;
            this.tabControlDetailEdit.Size = new System.Drawing.Size(605, 788);
            this.tabControlDetailEdit.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Location = new System.Drawing.Point(8, 46);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(589, 734);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // tabEdit
            // 
            this.tabEdit.Location = new System.Drawing.Point(8, 46);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(464, 734);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Edit";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutRechtsOnder
            // 
            this.tableLayoutRechtsOnder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutRechtsOnder.ColumnCount = 2;
            this.tableLayoutRechtsOnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutRechtsOnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutRechtsOnder.Controls.Add(this.btKnit, 1, 0);
            this.tableLayoutRechtsOnder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutRechtsOnder.Location = new System.Drawing.Point(3, 835);
            this.tableLayoutRechtsOnder.Name = "tableLayoutRechtsOnder";
            this.tableLayoutRechtsOnder.RowCount = 1;
            this.tableLayoutRechtsOnder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutRechtsOnder.Size = new System.Drawing.Size(611, 141);
            this.tableLayoutRechtsOnder.TabIndex = 1;
            // 
            // btKnit
            // 
            this.btKnit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btKnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btKnit.Location = new System.Drawing.Point(430, 3);
            this.btKnit.Name = "btKnit";
            this.btKnit.Size = new System.Drawing.Size(178, 135);
            this.btKnit.TabIndex = 2;
            this.btKnit.Text = "Knit!";
            this.btKnit.UseVisualStyleBackColor = true;
            // 
            // PalCSVKnitterApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 985);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "PalCSVKnitterApp";
            this.Text = "Wendy\'s Pal CSV Knitter App";
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.groupBoxLinksConfiguration.ResumeLayout(false);
            this.tableLayoutLinksInGB.ResumeLayout(false);
            this.tableLayoutLinksBoven.ResumeLayout(false);
            this.tableLayoutLinksOnder.ResumeLayout(false);
            this.tableLayoutLinksOnder.PerformLayout();
            this.tableLayoutRechts.ResumeLayout(false);
            this.groupBoxRechtsSelectedItem.ResumeLayout(false);
            this.tabControlDetailEdit.ResumeLayout(false);
            this.tableLayoutRechtsOnder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private GroupBox groupBoxLinksConfiguration;
        private TableLayoutPanel tableLayoutLinksInGB;
        private TableLayoutPanel tableLayoutRechts;
        private GroupBox groupBoxRechtsSelectedItem;
        private TabControl tabControlDetailEdit;
        private TabPage tabDetails;
        private TabPage tabEdit;
        private TableLayoutPanel tableLayoutLinksBoven;
        private Button btOpenFolder;
        private Button btSaveConfig;
        private ListBox lbConfiguration;
        private TableLayoutPanel tableLayoutRechtsOnder;
        private Button btKnit;
        private TableLayoutPanel tableLayoutLinksOnder;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label labelTip;
    }
}