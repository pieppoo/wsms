using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMS_MASTER.views.Settings
{
    public partial class Settings : Form
    {
        public string DefaultConnString
        {
            get
            {
                return "Server=localhost;Database=possystem;Uid=root;Pwd=admin123;";
            }
        }

        public Settings()
        {
            InitializeComponent();
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.connection_string))
            {
                tbConnectionString.Text = DefaultConnString;
            }
            else
            {
                tbConnectionString.Text = Properties.Settings.Default.connection_string;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.reportFolder = tbReportFolder.Text;
            Properties.Settings.Default.connection_string = tbConnectionString.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Setting telah disimpan", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
        }

        private void btnBrowseReportFolder_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbReportFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void tbConnectionString_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbReportFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbbrandname_Click(object sender, EventArgs e)
        {

        }


    }
}
