namespace PalCSVKnitter
{
    public partial class PalCSVKnitterApp : Form
    {
        private bool freezeTab = true;
        private bool freezeEvents = false;
        private string path = "";
        private const string configFileName = @"\_palcsvknitter.config";
        private const string outputFolder = @"\_palcsvknitter-output";

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
                        btKnit.Enabled = true;

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
                        Dictionary<string, string> dic = AttemptReadConfig();
                        cbDataCount.Checked = cbStepCount.Checked = false;
                        if (dic.Count > 0)
                        {
                            MessageBox.Show("Found configuration file, using the stored config.");
                            if (dic["|DataCount"] == "True") cbDataCount.Checked = true;
                            if (dic["|StepCount"] == "True") cbStepCount.Checked = true;
                            dic.Remove("|DataCount");
                            dic.Remove("|StepCount");
                        }

                        // 4) Add all to the listbox.
                        for (int i = 0; i < palCSVs.Count; i++)
                        {
                            string name = palCSVs[i].GetFileName();
                            lbConfiguration.Items.Add(palCSVs[i]);
                            if (i < (palCSVs.Count - 1))
                            {
                                if (dic.ContainsKey(name))
                                {
                                    string[] data = dic[name].Split("|");
                                    lbConfiguration.Items.Add(new CSVKnitConfiguration(DateTime.Parse(data[0]), DateTime.Parse(data[1])));
                                }
                                else
                                    lbConfiguration.Items.Add(new CSVKnitConfiguration(palCSVs[i].last.GetDateTime()));
                            }
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
                MessageBox.Show("Something went wrong while loading :(. We're both sad this hapened!\nTech talk: " +
                                ex.Message + "\n\nTech details: \n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Tries to read the configfile. Stores the filenames and their two dates plus the 2 checkboxes.
        /// </summary>
        /// <returns>An empty dictionary if no config is found, else key value pairs.</returns>
        private Dictionary<string, string> AttemptReadConfig()
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string[] lines = System.IO.File.ReadAllLines(path + configFileName);
                string[] checkboxes = lines[1].Split("|");
                dic.Add("|DataCount", checkboxes[0]);
                dic.Add("|StepCount", checkboxes[1]);
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split("|", 2);
                    dic.Add(data[0], data[1]);
                }
                return dic;
            }
            catch
            {
                // Empty dictionary is returned.
                return new Dictionary<string, string>();
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
                using StreamWriter file = new(path + configFileName);
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

        /// <summary>
        /// This is where the magic happens. It saves one big CSV file.
        /// </summary>
        private void btKnit_Click(object sender, EventArgs e)
        {
            bool consecutiveStepCount = cbStepCount.Checked;
            bool consecutiveDataCount = cbDataCount.Checked;
            long startDataCount = 0, newDC = 0;
            long startStepCount = 0, newSC = 0;
            List<string> output = new List<string>();
            int count = lbConfiguration.Items.Count;
            string header = "\"Time\",\"DataCount (samples)\",\"Interval (s)\",\"ActivityCode (0=sedentary, 1=standing, 2=stepping)\",\"CumulativeStepCount\",\"Activity Score (MET.h)\",\"Sum(Abs(DiffX)\",\"Sum(Abs(DiffY)\",\"Sum(Abs(DiffZ)\"";
            output.Add(header); // Start with the header.

            // A few steps to be done:
            // 1) Create the output folder.
            // 2) Loop through the listbox and apply configs.
            // 3) Save strings to file.
            // 4) Profit!

            try
            {
                // 1) Create output folder.
                if (!Directory.Exists(path + outputFolder))
                    Directory.CreateDirectory(path + outputFolder);

                // 2) Run through all files and configurations. Minimum is 3 items.
                //    a) First do the top 2 items.
                //    b) Then step size 2 grab sets of: (config, file, config).
                //    c) Finally, the last 2 items.

                // 2.a) Top 2 items.
                PalCSVFile firstFile = (PalCSVFile)lbConfiguration.Items[0];
                CSVKnitConfiguration firstConfig = (CSVKnitConfiguration)lbConfiguration.Items[1];
                (newDC, newSC) = AppendCSVToList(firstFile, output, startDataCount, startStepCount,
                                                 stop: firstConfig.stop);
                if (consecutiveDataCount) startDataCount = newDC;
                if (consecutiveStepCount) startStepCount = newSC;

                // 2.b) Middle.
                for (int i = 1; i < count - 3; i += 2)
                {
                    CSVKnitConfiguration prevConfig = (CSVKnitConfiguration)lbConfiguration.Items[i + 0];
                    PalCSVFile file = (PalCSVFile)lbConfiguration.Items[i + 1];
                    CSVKnitConfiguration nextConfig = (CSVKnitConfiguration)lbConfiguration.Items[i + 2];
                    (newDC, newSC) = AppendCSVToList(file, output, startDataCount, startStepCount,
                                                     stop: nextConfig.stop, start: prevConfig.start);
                    if (consecutiveDataCount) startDataCount = newDC;
                    if (consecutiveStepCount) startStepCount = newSC;
                }

                // 2.c) Last 2 items.
                CSVKnitConfiguration lastConfig = (CSVKnitConfiguration)lbConfiguration.Items[count - 2];
                PalCSVFile lastFile = (PalCSVFile)lbConfiguration.Items[count - 1];
                (newDC, newSC) = AppendCSVToList(lastFile, output, startDataCount, startStepCount,
                                                 start: lastConfig.start);
                if (consecutiveDataCount) startDataCount = newDC;
                if (consecutiveStepCount) startStepCount = newSC;

                // 3) Save all to the file.
                string fileLocation = path + outputFolder + @"\KnittedAt" + DateTime.Now.ToString("yyyyMMddHHmm") + ".csv";
                System.IO.File.WriteAllLines(fileLocation, output);
                MessageBox.Show($"Saved {output.Count} lines in:\n{fileLocation}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while knitting :(. We're both sad this hapened!\nTech talk: " +
                                ex.Message + "\n\nTech details: \n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Adds the content of the file to the List of string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <param name="outList">The list to append to.</param>
        /// <param name="startDataCount">Value to append to the DataCount column.</param>
        /// <param name="startStepCount">Value to append to the StepCount column.</param>
        /// <param name="stop">Optional: when to stop.</param>
        /// <param name="start">Optional: when to start.</param>
        /// <returns>Tupil with the new max values.</returns>
        private (long, long) AppendCSVToList(PalCSVFile file, List<string> outList,
                                     long startDataCount, long startStepCount,
                                     DateTime? stop = null, DateTime? start = null)
        {
            (List<string> append, long dataCountMax, long stepCountMax) =
                file.ConvertToListString(startDataCount, startStepCount, stop, start);
            foreach (string line in append)
                outList.Add(line);
            return (dataCountMax, stepCountMax);
        }
    }
}