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
    public partial class ProductListForm : Form
    {
        public List<ProductColumns> ListProducts { get; set; }
        public List<BrandColumns> ListBrands { get; set; }
        public List<UnitColumns> ListUnits { get; set; }
        public List<CategoryColumns> ListCategories { get; set; }
        public List<SalePriceColumns> ListSalePrice { get; set; }


        public LoginColumns userdata { get; set; }
        public ProductListForm()
        {
            InitializeComponent();
        }

        private ProductRepo productRepository = new ProductRepo();
        private BrandRepo brandRepository = new BrandRepo();
        private UnitRepo unitRepository = new UnitRepo();
        private CategoryRepo categoryRepository = new CategoryRepo();
        private SalePriceRepo salePriceRepo = new SalePriceRepo();



        private void LoadData()
        {


            //if (userdata.user_role == "kasir")
            //{
            //    btadditem.Visible = false;
            //    btedititem.Visible = false;
            //    btdeleteitem.Visible = false;
            //    btunitmanage.Visible = false;
            //    btmanagebrand.Visible = false;
            //}

            try
            {
                ListBrands = brandRepository.GetAll().ToList();
                ListProducts = productRepository.GetAll().ToList();
                ListCategories = categoryRepository.GetAll().ToList();
                ListUnits = unitRepository.GetAll().ToList();
                var tempproductlist = new List<TempProdColumns>();

                if (ListProducts != null)
                {
                    foreach (var item in ListProducts)
                    {
                        var prodbrand = ListBrands.FirstOrDefault(x => x.brandid == item.brandid);
                        var prodcat = ListCategories.FirstOrDefault(x => x.catid == item.prodcat);
                        var produnit = ListUnits.FirstOrDefault(x => x.unitid == item.produnit);

                        var itemDetail = new TempProdColumns();
                        itemDetail.prodid = item.prodid;
                        itemDetail.brandid = item.brandid;
                        itemDetail.brand_name = prodbrand != null ? prodbrand.name : " - ";
                        itemDetail.name = item.name;
                        itemDetail.prodcat = item.prodcat;
                        itemDetail.prodcat_name = prodcat != null ? prodcat.name : " - ";
                        itemDetail.prodcode = item.prodcode;
                        itemDetail.produnit = item.produnit;
                        itemDetail.produnit_code = produnit != null ? produnit.unitcode : " - ";
                        itemDetail.purchaseprice = item.purchaseprice;
                        itemDetail.stocks = item.stocks;
                        itemDetail.barcodeno = item.barcodeno;
                        tempproductlist.Add(itemDetail);
                    }

                    gvproducts.Rows.Clear();


                    foreach (var item in tempproductlist.OrderBy(x => x.prodcat_name).ThenBy(x => x.brand_name).ThenBy(x => x.name))
                    {
                        gvproducts.Rows.Add(
                            item.prodid,
                            item.prodcat_name,
                            item.brand_name,
                            item.prodcode,
                            item.name,
                            item.produnit_code,
                            Utils.ToRupiah(item.purchaseprice),
                            item.barcodeno,
                            item.stocks
                            );
                    }
                }


                
                var cbData = ListBrands;
                cbData.Insert(0, new BrandColumns { brandid = -1, name = "--- Pilih Merek ---" });

                cbbrand.DataSource = new BindingSource(ListBrands, null);
                cbbrand.DisplayMember = "name";
                cbbrand.ValueMember = "brandid";

                var cbcatdata = ListCategories;
                cbcatdata.Insert(0, new CategoryColumns { catid = -1, name = "--- Pilih Kategori ---" });

                cbcategory.DataSource = new BindingSource(ListCategories, null);
                cbcategory.DisplayMember = "name";
                cbcategory.ValueMember = "catid";
            }
            catch (Exception ex)
            {
                var errMsg = "Details : " + ex.Message + Environment.NewLine + "Stacktrace : " + ex.StackTrace;
                MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbprodname.Focus();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            lbuser.Text = "Halo, " + userdata.fullname;
            LoadData();
        }

        private void btpurchase_Click(object sender, EventArgs e)
        {

        }

        private void btcategory_Click(object sender, EventArgs e)
        {
            var form = new CategoryListForm();
            form.userdata = userdata;
            Hide();
            form.ShowDialog();
            Show();
            LoadData();
        }

        private void btbrand_Click(object sender, EventArgs e)
        {
            var form = new BrandListForm();
            form.userdata = userdata;
            Hide();
            form.ShowDialog();
            Show();
            LoadData();
        }

        private void btunit_Click(object sender, EventArgs e)
        {
            var form = new UnitListForm();
            form.userdata = userdata;
            Hide();
            form.ShowDialog();
            Show();
            LoadData();
        }

        private void btsellingprice_Click(object sender, EventArgs e)
        {
            if (gvproducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Anda tidak bisa lanjut ke layar berikutnya, silahkan tambah baru barang");
            }
            else
            {
                var selectedRowId = (int)gvproducts.SelectedRows[0].Cells["id"].Value;
                var selectedSalePrice = salePriceRepo.GetById(selectedRowId);
                var selectedproduct = productRepository.GetById(selectedRowId);

                if(selectedSalePrice == null)
                {
                    var NewSalePrice = new SalePriceColumns();
                    NewSalePrice.prodid = selectedRowId;
                    NewSalePrice.created_by = userdata.username;

                    if(salePriceRepo.Add(NewSalePrice))
                    {
                        var newsaleprice = salePriceRepo.GetById(selectedRowId);
                        if (newsaleprice != null)
                        {
                            var form = new ManageSalePrice();
                            form.userdata = userdata;
                            form.SalePriceData = newsaleprice;
                            form.ProductData = selectedproduct;
                            form.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show("Error pada daftar harga jual");
                }
                else
                {
                    var form = new ManageSalePrice();
                    form.userdata = userdata;
                    form.SalePriceData = selectedSalePrice;
                    form.ProductData = selectedproduct;
                    form.ShowDialog();
                }
            }
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            int oritotalrow = gvproducts.Rows.Count;

            var form = new ManageProduct();
            form.userdata = userdata;
            form.ShowDialog();
            LoadData();

            int newtotalrow = gvproducts.Rows.Count;

            if (oritotalrow != newtotalrow)
            {
                var newProduct = new ProductColumns();
                newProduct = productRepository.GetByAny(1);
                int newId = newProduct.prodid;

                foreach (DataGridViewRow row in gvproducts.Rows)
                {
                    if (((int)row.Cells["id"].Value) == newId)
                    {
                        gvproducts.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }

        }

        private void gvproducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btedit.PerformClick();
        }

        private void btedit_Click(object sender, EventArgs e)
        {
            if (gvproducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada barang yang akan diubah");
            }
            else
            {
                var selectedRowId = (int)gvproducts.SelectedRows[0].Cells["id"].Value;
                //var id = Convert.ToInt32(gvproducts.Rows[gvproducts.CurrentCell.RowIndex].Cells["id"].Value);
                var product = ListProducts.FirstOrDefault(x => x.prodid == selectedRowId);
                if (product != null)
                {
                    var form = new ManageProduct();
                    form.Editmode = true;
                    form.ProductData = product;
                    form.userdata = userdata;
                    form.ShowDialog();

                    LoadData();

                    foreach (DataGridViewRow row in gvproducts.Rows)
                    {
                        if (((int)row.Cells["id"].Value) == selectedRowId)
                        {
                            gvproducts.Rows[row.Index].Selected = true;
                            break;
                        }
                    }

                    //var updatedProduct = ListProducts.FirstOrDefault(x => x.prodid == selectedRowId);
                    //var brand = ListBrands.FirstOrDefault(x => x.brandid == updatedProduct.brandid);
                    //var prodcat = ListCategories.FirstOrDefault(x => x.catid == updatedProduct.prodcat);
                    //var produnit = ListUnits.FirstOrDefault(x => x.unitid == updatedProduct.produnit);

                    //var currennindex = gvproducts.CurrentCell.RowIndex;

                    //gvproducts.Rows.RemoveAt(currennindex);
                    //gvproducts.Rows.Insert(currennindex,
                    //    updatedProduct.prodid,
                    //    prodcat != null ? prodcat.name : " - ",
                    //    brand != null ? brand.name : " - ",
                    //    updatedProduct.prodcode,
                    //    updatedProduct.name,
                    //    produnit != null ? produnit.unitcode : " - ",
                    //     Utils.ToRupiah(updatedProduct.purchaseprice),
                    //    updatedProduct.barcodeno,
                    //    updatedProduct.stocks);

                }
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (gvproducts.SelectedRows.Count == 0)
                MessageBox.Show("Tidak ada barang yang akan dihapus");
            else
            {

                //var id = Convert.ToInt32(gvproducts.Rows[gvproducts.CurrentCell.RowIndex].Cells["id"].Value);
                var selectedRowId = (int)gvproducts.SelectedRows[0].Cells["id"].Value;
                var selectedSalePrice = salePriceRepo.GetById(selectedRowId);

                if (selectedSalePrice == null)
                {
                    var form = new ConfirmationDialog();
                    form.Message = "Apa anda yakin menghapus barang terpilih?";
                    form.ShowDialog();

                    if (form.YES)
                    {

                        if (!productRepository.Delete(selectedRowId))
                            MessageBox.Show("Gagal menghapus barang");
                        LoadData();
                    }
                }
                else
                {
                    var form = new ConfirmationDialog();
                    form.Message = "Apa anda yakin menghapus barang terpilih?";
                    form.ShowDialog();

                    if (form.YES)
                    {

                        if (!productRepository.Delete2table(selectedRowId))
                            MessageBox.Show("Gagal menghapus barang");
                        LoadData();
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
            else if (keyData == Keys.F4)
            {
                btsellingprice.PerformClick();
            }
            else if (keyData == Keys.F5)
            {
                btunit.PerformClick();
            }
            else if (keyData == Keys.F6)
            {
                btbrand.PerformClick();
            }
            else if (keyData == Keys.F7)
            {
                btcategory.PerformClick();
            }
            else if (keyData == Keys.F8)
            {
                btpurchase.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
