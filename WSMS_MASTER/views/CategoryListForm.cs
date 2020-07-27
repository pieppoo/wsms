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
    public partial class CategoryListForm : Form
    {
        public LoginColumns userdata { get; set; }
        public List<CategoryColumns> ListCategories { get; set; }
        public List<ProductColumns> ListProducts { get; set; }

        public CategoryListForm()
        {
            InitializeComponent();
        }

        private CategoryRepo categoryRepository = new CategoryRepo();
        private ProductRepo productRepo = new ProductRepo();

        private void LoadData()
        {
            ListCategories = categoryRepository.GetAll();

            gvcategories.Rows.Clear();

            foreach (var item in ListCategories.OrderBy(x=> x.name))
            {

                gvcategories.Rows.Add(item.catid,
                    item.name,
                    item.remark);

            }

        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            LoadData();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            int oritotalrow = gvcategories.Rows.Count;

            var form = new ManageCategories();
            form.userdata = userdata;
            form.ShowDialog();
            LoadData();

            int newtotalrow = gvcategories.Rows.Count;

            if (oritotalrow != newtotalrow)
            {
                var newCats = new CategoryColumns();
                newCats = categoryRepository.GetByAny(1);
                int newId = newCats.catid;

                foreach (DataGridViewRow row in gvcategories.Rows)
                {
                    if (((int)row.Cells["id"].Value) == newId)
                    {
                        gvcategories.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (gvcategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada kategori yang akan diubah");
            }
            else
            {
                var selectedRowId = (int)gvcategories.SelectedRows[0].Cells["id"].Value;
                var cats = ListCategories.FirstOrDefault(x => x.catid == selectedRowId);

                if (selectedRowId == 1)
                    MessageBox.Show("Anda tidak dibenarkan mengubah kategori Lain-Lain");
                else if (cats != null)
                {
                    var form = new ManageCategories();
                    form.userdata = userdata;
                    form.Editmode = true;
                    form.CategoryData = cats;
                    form.ShowDialog();
                    LoadData();

                    foreach (DataGridViewRow row in gvcategories.Rows)
                    {
                        if (((int)row.Cells["id"].Value) == selectedRowId)
                        {
                            gvcategories.Rows[row.Index].Selected = true;
                            break;
                        }
                    }


                }
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (gvcategories.SelectedRows.Count == 0)
                MessageBox.Show("Tidak ada kategori yang akan dihapus");
            else
            {
                var selectedRowId = (int)gvcategories.SelectedRows[0].Cells["id"].Value;

                if (selectedRowId == 1)
                {
                    MessageBox.Show("Anda tidak dibenarkan menghapus kategori Lain-Lain");
                }
                else
                {
                    ListProducts = productRepo.GetAll();

                    var product = ListProducts.FirstOrDefault(x => x.prodcat == selectedRowId);

                    if (product == null)
                    {
                        var form = new ConfirmationDialog();
                        form.Message = "Apa anda yakin menghapus kategori terpilih?";
                        form.ShowDialog();

                        if (form.YES)
                        {
                            if (!categoryRepository.Delete(selectedRowId))
                                MessageBox.Show("Gagal menghapus kategori");
                            LoadData();
                        }
                    }
                    else
                        MessageBox.Show("Anda tidak dibenarkan menghapus kategori yang masih memiliki barang");

                }
            }
        }

        private void gvcategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btedit.PerformClick();
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
