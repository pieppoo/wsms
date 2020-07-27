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
    public partial class BrandListForm : Form
    {
        public List<BrandColumns> ListBrands { get; set; }
        public LoginColumns userdata { get; set; }
        public List<ProductColumns> ListProducts { get; set; }

        public BrandListForm()
        {
            InitializeComponent();
        }

        private BrandRepo brandRepository = new BrandRepo();
        private ProductRepo productRepo = new ProductRepo();

        private void BrandListForm_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            LoadData();
        }

        private void LoadData()
        {
            ListBrands = brandRepository.GetAll();

            gvbrand.Rows.Clear();


            foreach (var item in ListBrands.OrderBy(x => x.name))
            {

                gvbrand.Rows.Add(item.brandid,
                    item.name,
                    item.remark);

            }

        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (gvbrand.SelectedRows.Count == 0)
                MessageBox.Show("Tidak ada brand yang akan dihapus");
            else
            {
                //var id = Convert.ToInt32(gvbrand.Rows[gvbrand.CurrentCell.RowIndex].Cells["id"].Value);
                var selectedRowId = (int)gvbrand.SelectedRows[0].Cells["id"].Value;

                if (selectedRowId == 1)
                {
                    MessageBox.Show("Anda tidak dibenarkan menghapus brand Lain-Lain");
                }
                else
                {
                    ListProducts = productRepo.GetAll();

                    var product = ListProducts.FirstOrDefault(x => x.brandid == selectedRowId);

                    if(product == null)
                    {
                        var form = new ConfirmationDialog();
                        form.Message = "Apa anda yakin menghapus brand terpilih?";
                        form.ShowDialog();

                        if (form.YES)
                        {

                            if (!brandRepository.Delete(selectedRowId))
                                MessageBox.Show("Gagal menghapus brand");
                            LoadData();
                        }
                    }
                    else
                        MessageBox.Show("Anda tidak dibenarkan menghapus brand yang masih memiliki barang");

                }
            }
        }

        private void btedit_Click(object sender, EventArgs e)
        {

            if (gvbrand.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada brand yang akan diubah");
            }
            else
            {
                var selectedRowId = (int)gvbrand.SelectedRows[0].Cells["id"].Value;
                var brand = ListBrands.FirstOrDefault(x => x.brandid == selectedRowId);



                if (selectedRowId == 1)
                {
                    MessageBox.Show("Anda tidak dibenarkan mengubah brand Lain-Lain");
                }
                else if (brand != null)
                {
                    var form = new ManageBrand();
                    form.userdata = userdata;
                    form.Editmode = true;
                    form.BrandData = brand;
                    form.ShowDialog();

                    LoadData();

                    foreach (DataGridViewRow row in gvbrand.Rows)
                    {
                        if (((int)row.Cells["id"].Value) == selectedRowId)
                        {
                            gvbrand.Rows[row.Index].Selected = true;
                            break;
                        }
                    }

                }
            }
            
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            int oritotalrow = gvbrand.Rows.Count;

            var form = new ManageBrand();
            form.userdata = userdata;
            form.ShowDialog();
            LoadData();

            int newtotalrow = gvbrand.Rows.Count;

            if (oritotalrow != newtotalrow)
            {
                var newBrand = new BrandColumns();
                newBrand = brandRepository.GetByAny(1);
                int newId = newBrand.brandid;

                foreach (DataGridViewRow row in gvbrand.Rows)
                {
                    if (((int)row.Cells["id"].Value) == newId)
                    {
                        gvbrand.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }

        }

        private void picsearch_Click(object sender, EventArgs e)
        {

        }

        private void picrefresh_Click(object sender, EventArgs e)
        {

        }

        private void gvbrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btedit.PerformClick();
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
                btadd.PerformClick();
            }
            else if (keyData == Keys.F2)
            {
                btedit.PerformClick();
            }
            else if (keyData == Keys.F3)
            {
                btdelete.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
