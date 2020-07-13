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
    public partial class ProductList : Form
    {
        public LoginColumns userdata { get; set; }
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
        }

        private void btpurchase_Click(object sender, EventArgs e)
        {

        }

        private void btcategory_Click(object sender, EventArgs e)
        {

        }

        private void btbrand_Click(object sender, EventArgs e)
        {

        }

        private void btunit_Click(object sender, EventArgs e)
        {

        }

        private void btsellingprice_Click(object sender, EventArgs e)
        {

        }

        private void btadd_Click(object sender, EventArgs e)
        {
            var form = new ManageProduct();
            form.userdata = userdata;
            form.ShowDialog();
            Show();
        }

        private void btedit_Click(object sender, EventArgs e)
        {

        }

        private void btdelete_Click(object sender, EventArgs e)
        {

        }

        private void picsearch_Click(object sender, EventArgs e)
        {

        }

        private void picrefresh_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                Close();
                return true;
            }
            else if (keyData == Keys.F1)
            {
                btpurchase.PerformClick();
            }
            else if (keyData == Keys.F2)
            {
                btcategory.PerformClick();
            }
            else if (keyData == Keys.F3)
            {
                btbrand.PerformClick();
            }
            else if (keyData == Keys.F4)
            {
                btunit.PerformClick();
            }
            else if (keyData == Keys.F5)
            {
                btsellingprice.PerformClick();
            }
            else if (keyData == Keys.F6)
            {
                btadd.PerformClick();
            }
            else if (keyData == Keys.F7)
            {
                btedit.PerformClick();
            }
            else if (keyData == Keys.F8)
            {
                btdelete.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
