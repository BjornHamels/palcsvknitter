namespace PalCSVKnitter
{
    public partial class PalCSVKnitterApp : Form
    {
        private bool freezeTab = true;

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
                        // All ok. Slected a folder. Three steps remain:
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
                    freezeTab = false;
                    tabControlDetailEdit.SelectTab(tabEdit);
                }
            }
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
    }
}