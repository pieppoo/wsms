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
using WSMS_MASTER.views.Base;
using WSMS_MASTER.views;

namespace WSMS_MASTER.views
{
    public partial class ManagePassword : BaseForm
    {
        public LoginColumns userdata { get; set; }
        private LoginRepo loginRepository = new LoginRepo();
        public ManagePassword()
        {
            InitializeComponent();
        }
        private void ManagePassword_Load(object sender, EventArgs e)
        {
            lbname.Text = "Pengguna: " + userdata.fullname;
        }
        private void btchange_Click(object sender, EventArgs e)
        {
            if (tbnewpswd.Text == "" || tbnewpswdconfirm.Text == "")
                MessageBox.Show("Silahkan isi kedua box dengan kata sandi yang sama");
            else if (tbnewpswd.Text != tbnewpswdconfirm.Text)
                MessageBox.Show("Kedua kata sandi tidak sama");
            else
            {
                var logininfo = new LoginColumns();
                logininfo.userid = userdata.userid;
                logininfo.password = tbnewpswdconfirm.Text;

                if (loginRepository.updatepswd(logininfo))
                {
                    MessageBox.Show("Kata sandi anda telah berhasil diganti");
                    Close();
                }
                else
                    MessageBox.Show("error, Kata sandi tidak bisa diganti");

            }
        }

        private void tbnewpswdconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btchange.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("Apa Anda Yakin keluar tanpa menyimpan data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
