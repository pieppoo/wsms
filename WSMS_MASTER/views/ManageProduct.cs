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
    public partial class ManageProduct : Form
    {
        public LoginColumns userdata { get; set; }
        public ManageProduct()
        {
            InitializeComponent();
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            
        }


    }
}
