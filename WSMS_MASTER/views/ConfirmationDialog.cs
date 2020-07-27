using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMS_MASTER.views
{
    public partial class ConfirmationDialog : Form
    {
        public string Message
        {
            set
            {
                lbmessage.Text = value;
            }
        }
        public bool YES { get; set; }

        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            YES = false;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            YES = true;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                btnYes.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                btnNo.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
