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
    public partial class ReportListForm : Form
    {
        public LoginColumns userdata { get; set; }
        public ReportListForm()
        {
            InitializeComponent();
        }

        private void ManageReport_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
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
                btprodreport.PerformClick();
            }
            else if (keyData == Keys.F2)
            {
                btuserreport.PerformClick();
            }
            else if (keyData == Keys.F3)
            {
                btsuppreport.PerformClick();
            }
            else if (keyData == Keys.F4)
            {
                btpurchasereport.PerformClick();
            }
            else if (keyData == Keys.F5)
            {
                btsalereport.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
