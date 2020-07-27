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
    public partial class UnitListForm : Form
    {
        public List<UnitColumns> ListUnits { get; set; }
        public LoginColumns userdata { get; set; }
        public List<ProductColumns> ListProduct { get; set; }

        public UnitListForm()
        {
            InitializeComponent();
        }

        private UnitRepo unitRepository = new UnitRepo();
        private ProductRepo productRepo = new ProductRepo();

        private void LoadData()
        {
            ListUnits = unitRepository.GetAll();
            gvunit.Rows.Clear();
            

            foreach (var item in ListUnits.OrderBy(x => x.unitcode).ThenBy(x => x.name))
            {
                gvunit.Rows.Add(
                    item.unitid,
                    item.unitcode,
                    item.name,
                    item.remark);

                
            }
            
        }

        private void UnitListForm_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            LoadData();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            int oritotalrow = gvunit.Rows.Count;

            var form = new ManageUnit();
            form.userdata = userdata;
            form.ShowDialog();
            LoadData();

            int newtotalrow = gvunit.Rows.Count;

            if (oritotalrow != newtotalrow)
            {
                var newUnit = new UnitColumns();
                newUnit = unitRepository.GetByAny(1);
                int newId = newUnit.unitid;

                foreach (DataGridViewRow row in gvunit.Rows)
                {
                    if (((int)row.Cells["id"].Value) == newId)
                    {
                        gvunit.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (gvunit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada kemasan yang akan diubah");
            }
            else
            {
                var selectedRowId = (int)gvunit.SelectedRows[0].Cells["id"].Value;
                var selectedUnit = ListUnits.FirstOrDefault(x => x.unitid == selectedRowId);

                if (selectedRowId == 1)
                    MessageBox.Show("Anda tidak dibenarkan mengubah kemasan Lain-Lain");
                else if (selectedUnit != null)
                {
                    var form = new ManageUnit();
                    form.userdata = userdata;
                    form.Editmode = true;
                    form.UnitData = selectedUnit;
                    form.ShowDialog();
                    LoadData();

                    foreach (DataGridViewRow row in gvunit.Rows)
                    {
                        if (((int)row.Cells["id"].Value) == selectedRowId)
                        {
                            gvunit.Rows[row.Index].Selected = true;
                            break;
                        }
                    }


                }
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (gvunit.SelectedRows.Count == 0)
                MessageBox.Show("Tidak ada kemasan yang akan dihapus");
            else
            {
                var selectedRowId = (int)gvunit.SelectedRows[0].Cells["id"].Value;

                if (selectedRowId == 1)
                {
                    MessageBox.Show("Anda tidak dibenarkan menghapus kemasan Lain-Lain");
                }
                else
                {
                    ListProduct = productRepo.GetAll();

                    var existsinproduct = ListProduct.FirstOrDefault(x => x.produnit == selectedRowId);

                    if (existsinproduct == null)
                    {
                        var form = new ConfirmationDialog();
                        form.Message = "Apa anda yakin menghapus kemasan terpilih?";
                        form.ShowDialog();

                        if (form.YES)
                        {
                            if (!unitRepository.Delete(selectedRowId))
                                MessageBox.Show("Gagal menghapus kemasan");
                            LoadData();
                        }
                    }
                    else
                        MessageBox.Show("Anda tidak dibenarkan menghapus kemasan yang masih dipakai barang");

                }
            }
        }

        private void gvunit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
