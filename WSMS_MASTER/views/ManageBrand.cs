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
    public partial class ManageBrand : Form
    {
        public LoginColumns userdata { get; set; }
        public List<BrandColumns> ListBrands { get; set; }
        public bool Editmode { get; set; }
        public BrandColumns BrandData { get; set; }
        public ManageBrand()
        {
            InitializeComponent();
        }

        private BrandRepo brandRepository = new BrandRepo();

        private void ManageBrand_Load(object sender, EventArgs e)
        {

            if (Editmode)
            {
                lbtitle.Text = "UBAH DATA BRAND";
                tbbrandname.Text = BrandData.name;
                tbremark.Text = BrandData.remark;
              
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            ListBrands = brandRepository.GetAll();
            int samename = 0;

            if (Editmode)
            {
                foreach (var existingdetails in ListBrands)
                {
                    if (existingdetails.name == tbbrandname.Text && existingdetails.brandid != BrandData.brandid)
                    {
                        samename += 1;
                        break;
                    }
                }


                if (tbbrandname.Text == "")
                    MessageBox.Show("Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama brand yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else
                {
                    var BrandDataBefore = new BrandColumns();
                    BrandDataBefore.name = BrandData.name;
                    BrandDataBefore.remark = BrandData.remark;

                    BrandData.name = tbbrandname.Text;
                    BrandData.remark = tbremark.Text;
                    BrandData.updated_by = userdata.username;

                    bool havechanges = false;

                    if (BrandDataBefore.name == BrandData.name && BrandDataBefore.remark == BrandData.remark)
                    {
                        havechanges = true;
                    }


                    if (havechanges)
                    {
                        MessageBox.Show("Tidak ada data yang anda ubah");
                        BrandData.name = BrandDataBefore.name;
                        BrandData.remark = BrandDataBefore.remark;
                    }
                    else if (brandRepository.Update(BrandData))
                    {
                        MessageBox.Show("Data telah berhasil di ubah");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal di ubah");
                        BrandData.name = BrandDataBefore.name;
                        BrandData.remark = BrandDataBefore.remark;
                    }

                }
            }
            else
            {
                foreach (var existingdetails in ListBrands)
                {
                    if (existingdetails.name == tbbrandname.Text)
                    {
                        samename += 1;
                        break;
                    }

                }



                if (tbbrandname.Text == "")
                    MessageBox.Show(" Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama brand yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else
                {
                    var brand = new BrandColumns();

                    brand.name = tbbrandname.Text;
                    brand.remark = tbremark.Text;
                    brand.created_by = userdata.username;


                    if (brandRepository.Add(brand))
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
