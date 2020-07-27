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

namespace WSMS_MASTER.views
{
    public partial class ManageCategories : Form
    {
        public bool Editmode { get; set; }
        public CategoryColumns CategoryData { get; set; }
        public LoginColumns userdata { get; set; }
        public List<CategoryColumns> ListCategory { get; set; }

        public ManageCategories()
        {
            InitializeComponent();
        }

        private CategoryRepo categoryRepo = new CategoryRepo();

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            if (Editmode)
            {
                lbtitle.Text = "UBAH DATA KATEGORI";
                tbcatname.Text = CategoryData.name;
                tbremark.Text = CategoryData.remark;
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            ListCategory = categoryRepo.GetAll();
            int samename = 0;

            if (Editmode)
            {
                foreach (var existingdetails in ListCategory)
                {
                    if (existingdetails.name == tbcatname.Text && existingdetails.catid != CategoryData.catid)
                    {
                        samename += 1;
                        break;
                    }
                }


                if (tbcatname.Text == "")
                    MessageBox.Show("Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else
                {
                    var CatDataBefore = new CategoryColumns();
                    CatDataBefore.name = CategoryData.name;
                    CatDataBefore.remark = CategoryData.remark;

                    CategoryData.name = tbcatname.Text;
                    CategoryData.remark = tbremark.Text;
                    CategoryData.updated_by = userdata.username;

                    bool havechanges = false;

                    if (CatDataBefore.name == CategoryData.name && CatDataBefore.remark == CategoryData.remark)
                    {
                        havechanges = true;
                    }


                    if (havechanges)
                    {
                        MessageBox.Show("Tidak ada data yang anda ubah");
                        CategoryData.name = CatDataBefore.name;
                        CategoryData.remark = CatDataBefore.remark;
                    }
                    else if (categoryRepo.Update(CategoryData))
                    {
                        MessageBox.Show("Data telah berhasil di ubah");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal di ubah");
                        CategoryData.name = CatDataBefore.name;
                        CategoryData.remark = CatDataBefore.remark;
                    }

                }
            }
            else
            {
                foreach (var existingdetails in ListCategory)
                {
                    if (existingdetails.name == tbcatname.Text)
                    {
                        samename += 1;
                        break;
                    }

                }

                if (tbcatname.Text == "")
                    MessageBox.Show(" Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else
                {
                    var cats = new CategoryColumns();

                    cats.name = tbcatname.Text;
                    cats.remark = tbremark.Text;
                    cats.created_by = userdata.username;


                    if (categoryRepo.Add(cats))
                    {
                        MessageBox.Show("Data baru telah berhasil di tambahkan");
                        Close();
                    }
                    else
                        MessageBox.Show("Data baru gagal ditambahkan");
                }

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("Apa Anda Yakin keluar tanpa menyimpan data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Close();
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                btsave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
