using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSMS_MASTER.Models;
using WSMS_MASTER.Repositories;
using WSMS_MASTER.views;

namespace WSMS_MASTER.views
{
    public partial class MainPageCashier : Form
    {
        public LoginColumns userdata { get; set; }
        public MainPageCashier()
        {
            InitializeComponent();
        }

        private void btchangepass_Click(object sender, EventArgs e)
        {
            var form = new ManagePassword();
            form.userdata = userdata;
            form.ShowDialog();
            Show();

        }
        private void btdebt_Click(object sender, EventArgs e)
        {

        }

        private void MainPageCashier_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            btchangepass.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("Apa Anda Yakin keluar dari sistem ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Close();
                return true;
            }
            else if (keyData == Keys.F1)
            {
                btchangepass.PerformClick();
            }
            else if (keyData == Keys.F2)
            {
                btsale.PerformClick();
            }
            else if (keyData == Keys.F3)
            {
                btdebt.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



    }
}
