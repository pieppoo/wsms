using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSMS_MASTER.Repositories;
using WSMS_MASTER.Models;
using System.Globalization;
using WSMS_MASTER.Common;
using WSMS_MASTER.views.Settings;

namespace WSMS_MASTER.views
{
    public partial class Login : Form
    {
        private LoginRepo loginRepository = new LoginRepo();
        public List<LoginColumns> LoginList { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btmasuk_Click(object sender, EventArgs e)
        {
            if (tbusername.Text != "")
            {
                if (tbpass.Text != "")
                {

                    LoginList = loginRepository.GetAll(tbusername.Text);

                    if (LoginList != null)
                    {
                        if (LoginList.Count > 0)
                        {
                            foreach (var item in LoginList)
                            {
                                if (item.status == "AK")
                                {
                                    if (item.password == tbpass.Text)
                                    {
                                        var login_info = new LoginColumns();
                                        login_info.userid = item.userid;
                                        login_info.password = tbpass.Text;
                                        login_info.username = tbusername.Text;
                                        login_info.last_login = DateTime.Now.ToString(Utils.DefaultDatetimeFormat);
                                        login_info.role = item.role;
                                        login_info.fullname = item.fullname;

                                        if (item.role =="KS")
                                        {
                                            if (loginRepository.Updatelastlogin(login_info))
                                            {
                                                var form = new MainPageCashier();
                                                form.userdata = login_info;
                                                Hide();
                                                form.ShowDialog();
                                                Close();
                                            }
                                            else
                                                MessageBox.Show("Ada error pada saat mengubah tanggal terakhir login");
                                        }
                                        else
                                        {
                                            if (loginRepository.Updatelastlogin(login_info))
                                            {
                                                var form = new MainPageAdmin();
                                                form.userdata = login_info;
                                                Hide();
                                                form.ShowDialog();
                                                Close();
                                            }
                                            else
                                                MessageBox.Show("Ada error pada saat mengubah tanggal terakhir login");
                                        }


                                    }
                                    else
                                        MessageBox.Show("Anda memasukkan kata sandi yang salah");
                                }
                                else
                                    MessageBox.Show("Pengguna ini sudah tidak aktif");
                            }
                        }
                        else
                            MessageBox.Show("Nama anda belum terdaftar");
                    }
                    else
                        MessageBox.Show("koneksi ke database mati");
                }
                else
                    MessageBox.Show("Anda belum memasukkan kata sandi");
            }
            else
                MessageBox.Show("Anda belum memasukkan nama");



        }

        private void Login_Activated(object sender, EventArgs e)
        {
            loginRepository = new LoginRepo();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btmasuk.PerformClick();
            }
        }

        private void llblSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Authentication();
            form.ShowDialog(this);
        }
    }
}

