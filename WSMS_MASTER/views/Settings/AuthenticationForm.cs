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
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals("admin123!"))
            {
                Close();
                var form = new Settings();
                form.ShowDialog(Parent);
            }
            else
            {
                MessageBox.Show("Sandi Salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                tbPassword.SelectAll();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSubmit.PerformClick();
        }
    }
}
