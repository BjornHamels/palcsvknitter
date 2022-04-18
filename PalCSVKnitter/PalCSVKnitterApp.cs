namespace PalCSVKnitter
{
    public partial class PalCSVKnitterApp : Form
    {
        private bool freezeTab = true;
        private bool freezeEvents = false;
        private string path = "";

        public PalCSVKnitterApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user selected a folder to open. This populates the listbox with the CSV data.
        /// </summary>
        private void btOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {

                // Open Windows' Folder Browser Dialog.
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        // All ok. Slected a folder. Save if for saving the config.
                        path = fbd.SelectedPath;
                        btSaveConfig.Enabled = true;

                        // Three steps remain:
                        // 1) clear the content of the listbox.
                        // 2) add all CSV's to a list that is sorted on internal DateTime;
                        // 3) see if there is a saved configfile we can use for the gaps.
                        // 4) add them to the listbox.

                        // 1) Clear lisbox.
                        lbConfiguration.Items.Clear();

                        // 2) Read CSV's and add to listbox.
                        List<PalCSVFile> palCSVs = new();
                        string[] files = Directory.GetFiles(fbd.SelectedPath, "*.csv");
                        if (files.Length == 0)
                            MessageBox.Show("No CSV files found?");
                        foreach (string file in files)
                            palCSVs.Add(new PalCSVFile(file));
                        palCSVs.Sort();

                        // 3) Read potential configuration file.
                        // TODO: read config

                        // 4) Add all to the listbox.
                        for (int i = 0; i < palCSVs.Count; i++)
                        {
                            lbConfiguration.Items.Add(palCSVs[i]);
                            if (i < palCSVs.Count - 1)
                                lbConfiguration.Items.Add(new CSVKnitConfiguration(palCSVs[i].last.GetDateTime()));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Illegal folder selected?");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong :(. We're both sad this hapened!\nTech talk: " +
                                ex.Message + "\n\nTech details: \n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// The user clicked a line in the listbox. Either a PalCSVLine or a CSVKnitConfiguration.
        /// </summary>
        private void lbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!freezeEvents)
            {
                object obj = lbConfiguration.SelectedItem;
                if (obj != null)
                {
                    if (obj is PalCSVFile)
                    {
                        PopulateDetailTab((PalCSVFile)obj);
                        freezeTab = false;
                        tabControlDetailEdit.SelectTab(tabDetails);
                    }
                    else if (obj is CSVKnitConfiguration)
                    {
                        PopulateDetailTab((CSVKnitConfiguration)obj);
                        freezeTab = false;
                        tabControlDetailEdit.SelectTab(tabEdit);
                    }
                }
            }
        }

        /// <summary>
        /// Populates the labels with knit configuration details.
        /// </summary>
        /// <param name="cSVKnitConfiguration">The selected configuration line to give details on.</param>
        private void PopulateDetailTab(CSVKnitConfiguration cSVKnitConfiguration)
        {
            if (cSVKnitConfiguration.GetMode() == "Gap")
                rbModeGap.Select();
            else
                rbModeConcat.Select();
            dateTimePickerStop.Value = cSVKnitConfiguration.stop;
            dateTimePickerStart.Value = cSVKnitConfiguration.start;
            labelGapDurationValue.Text = cSVKnitConfiguration.GetGapMinutes().ToString() + " minutes";
        }

        /// <summary>
        /// Populates the labels with file details.
        /// </summary>
        /// <param name="palCSVFile">The selected CSV file to give details on.</param>
        private void PopulateDetailTab(PalCSVFile palCSVFile)
        {
            string activitiesSeen = "";
            labelFileNameValue.Text = palCSVFile.filename;
            labelLineCountValue.Text = $"{palCSVFile.lines.Count + 1}";
            labelFirstValue.Text = palCSVFile.first.GetDateTime().ToString("yyyy-MM-dd ddd @ HH:mm");
            labelLastValue.Text = palCSVFile.last.GetDateTime().ToString("yyyy-MM-dd ddd @ HH:mm");
            labelDataCountValue.Text = $"First: {palCSVFile.first.DataCount}\nLast: {palCSVFile.last.DataCount}";
            foreach (char c in palCSVFile.activitySeen.ToList())
                activitiesSeen += $"{c}, ";
            labelActivitiesValue.Text = activitiesSeen.Substring(0, activitiesSeen.Length - 2);
            labelStepCountValue.Text = $"First: {palCSVFile.first.CumulativeStepCount}\nLast: {palCSVFile.last.CumulativeStepCount}";
        }

        /// <summary>
        /// Prevents the tab from changing.
        /// Found: https://stackoverflow.com/questions/40630281/disable-switching-between-tabs-by-click-or-keys-in-tabcontrol
        /// </summary>
        private void tabControlDetailEdit_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = freezeTab;
            freezeTab = true;
        }

        /// <summary>
        /// Save the new stop date in the selected config.
        /// </summary>
        private void dateTimePickerStop_ValueChanged(object sender, EventArgs e)
        {
            CSVKnitConfiguration config = (CSVKnitConfiguration)lbConfiguration.SelectedItem;
            config.stop = dateTimePickerStop.Value;
            if (rbModeConcat.Checked)
                config.start = dateTimePickerStop.Value;
            labelGapDurationValue.Text = config.GetGapMinutes().ToString() + " minutes";
            UpdateSelectedToString();
        }

        /// <summary>
        /// Save the new start date in the selected config.
        /// </summary>
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            CSVKnitConfiguration config = (CSVKnitConfiguration)lbConfiguration.SelectedItem;
            config.start = dateTimePickerStart.Value;
            labelGapDurationValue.Text = config.GetGapMinutes().ToString() + " minutes";
            UpdateSelectedToString();
        }

        /// <summary>
        /// Enables / disables UI for Gap and configures selected config object.
        /// </summary>
        private void rbMode_CheckedChanged(object sender, EventArgs e)
        {
            CSVKnitConfiguration config = (CSVKnitConfiguration)lbConfiguration.SelectedItem;
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                if (radio.Text == "Gap")
                {
                    groupBoxStart.Visible = true;
                    groupBoxStop.Text = "Stop";
                }
                else
                {
                    groupBoxStart.Visible = false;
                    groupBoxStop.Text = "Stop/start";
                    config.start = config.stop;
                }
                UpdateSelectedToString();
            }
        }

        /// <summary>
        /// A ListBox caches the toString. This triggers the current item to be re-evaluated.
        /// </summary>
        private void UpdateSelectedToString()
        {
            freezeEvents = true;
            int i = lbConfiguration.SelectedIndex;
            lbConfiguration.Items[i] = lbConfiguration.Items[i];
            freezeEvents = false;
        }

        /// <summary>
        /// Saves a file with configuration to the same folder containing the configuration objects.
        /// </summary>
        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            if (lbConfiguration.Items.Count != 0)
            {
                using StreamWriter file = new(path + "\\_palcsvknitter.config");
                file.WriteLine("# https://github.com/BjornHamels/palcsvknitter");
                file.WriteLine($"{cbDataCount.Checked}|{cbStepCount.Checked}");

                string before = "";
                int configCount = 0;
                foreach (object obj in lbConfiguration.Items)
                {
                    if (obj is PalCSVFile)
                        before = ((PalCSVFile)obj).GetFileName();
                    if (obj is CSVKnitConfiguration)
                    {
                        CSVKnitConfiguration config = (CSVKnitConfiguration)obj;
                        file.WriteLine($"{before}|{config.stop}|{config.start}");
                        before = "";
                        configCount++;
                    }
                }
                MessageBox.Show($"Saved {configCount} configuration objects and 2 settings.");
            }
        }
    }
}