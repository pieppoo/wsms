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

namespace WSMS_MASTER.views
{
    public partial class MainPageAdmin : Form
    {
        public LoginColumns userdata { get; set; }
        public MainPageAdmin()
        {
            InitializeComponent();
        }

        private void MainPageAdmin_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
        }

        private void btusermgt_Click(object sender, EventArgs e)
        {

        }
        private void btreport_Click(object sender, EventArgs e)
        {
            var form = new ReportList();
            form.userdata = userdata;
            Hide();
            form.ShowDialog();
            Show();
        }

        private void btwarehouse_Click(object sender, EventArgs e)
        {
            var form = new ProductList();
            form.userdata = userdata;
            Hide();
            form.ShowDialog();
            Show();
        }

        private void btsupplier_Click(object sender, EventArgs e)
        {

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
                btusermgt.PerformClick();
            }
            else if (keyData == Keys.F2)
            {
                btwarehouse.PerformClick();
            }
            else if (keyData == Keys.F3)
            {
                btsale.PerformClick();
            }
            else if (keyData == Keys.F4)
            {
                btcustomer.PerformClick();
            }
            else if (keyData == Keys.F5)
            {
                btsupplier.PerformClick();
            }
            else if (keyData == Keys.F6)
            {
                btdebt.PerformClick();
            }
            else if (keyData == Keys.F7)
            {
                btreport.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
