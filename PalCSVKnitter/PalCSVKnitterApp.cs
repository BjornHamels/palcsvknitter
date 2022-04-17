namespace PalCSVKnitter
{
    public partial class PalCSVKnitterApp : Form
    {
        public PalCSVKnitterApp()
        {
            InitializeComponent();
        }

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
                        foreach (PalCSVFile palCSV in palCSVs)
                        {
                            lbConfiguration.Items.Add(palCSV);
                            lbConfiguration.Items.Add(" - dt: 1");
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
    }
}