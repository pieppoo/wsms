using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSMS_MASTER.Common;
using WSMS_MASTER.Models;
using WSMS_MASTER.Repositories;

namespace WSMS_MASTER.views
{
    public partial class ManageSalePrice : Form
    {
        public LoginColumns userdata { get; set; }
        public SalePriceColumns SalePriceData { get; set; }
        public ProductColumns ProductData { get; set; }
        public ManageSalePrice()
        {
            InitializeComponent();
        }

        private ProductRepo productRepo = new ProductRepo();
        private SalePriceRepo salePriceRepo = new SalePriceRepo();

        private void ManageSalePrice_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            tbprodname.Text = ProductData.name;
            tblevel1.Text = SalePriceData.price_1.ToString();
            tblevel2.Text = SalePriceData.price_2.ToString();
            tblevel3.Text = SalePriceData.price_3.ToString();
            tblevel4.Text = SalePriceData.price_4.ToString();
            tblevel5.Text = SalePriceData.price_5.ToString();
        }


        private void btsave_Click(object sender, EventArgs e)
        {
            var dataBefore = new SalePriceColumns();
            dataBefore.price_1 = SalePriceData.price_1;
            dataBefore.price_2 = SalePriceData.price_2;
            dataBefore.price_3 = SalePriceData.price_3;
            dataBefore.price_4 = SalePriceData.price_4;
            dataBefore.price_5 = SalePriceData.price_5;

            SalePriceData.price_1 = Utils.ToNumbers(tblevel1.Text); 
            SalePriceData.price_2 = Utils.ToNumbers(tblevel2.Text);
            SalePriceData.price_3 = Utils.ToNumbers(tblevel3.Text);
            SalePriceData.price_4 = Utils.ToNumbers(tblevel4.Text);
            SalePriceData.price_5 = Utils.ToNumbers(tblevel5.Text);

            bool havechanges = false;

            if(dataBefore.price_1 == SalePriceData.price_1 && dataBefore.price_2 == SalePriceData.price_2 && dataBefore.price_3 == SalePriceData.price_3 && dataBefore.price_4 == SalePriceData.price_4 && dataBefore.price_5 == SalePriceData.price_5)
            {
                havechanges = true;
            }

            if (havechanges)
            {
                MessageBox.Show("Tidak ada data yang anda ubah");
                SalePriceData.price_1 = dataBefore.price_1;
                SalePriceData.price_2 = dataBefore.price_2;
                SalePriceData.price_3 = dataBefore.price_3;
                SalePriceData.price_4 = dataBefore.price_4;
                SalePriceData.price_5 = dataBefore.price_5;

            }
            else if (salePriceRepo.Update(SalePriceData))
            {
                MessageBox.Show("Harga jual telah berhasil di ubah");
                Close();
            }
            else
            {
                MessageBox.Show("Harga jua gagal di ubah");
                SalePriceData.price_1 = dataBefore.price_1;
                SalePriceData.price_2 = dataBefore.price_2;
                SalePriceData.price_3 = dataBefore.price_3;
                SalePriceData.price_4 = dataBefore.price_4;
                SalePriceData.price_5 = dataBefore.price_5;

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
