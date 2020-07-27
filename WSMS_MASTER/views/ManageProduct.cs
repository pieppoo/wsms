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
    public partial class ManageProduct : Form
    {
        public LoginColumns userdata { get; set; }
        public List<BrandColumns> ListBrands { get; set; }
        public List<CategoryColumns> ListCategories { get; set; }
        public List<UnitColumns> ListUnits { get; set; }
        public List<ProductColumns> ListProducts { get; set; }
        public bool Editmode { get; set; }
        public ProductColumns ProductData { get; set; }



        public ManageProduct()
        {
            InitializeComponent();
        }

        private ProductRepo productRepository = new ProductRepo();
        private BrandRepo brandRepository = new BrandRepo();
        private UnitRepo unitRepository = new UnitRepo();
        private CategoryRepo categoryRepository = new CategoryRepo();

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            ListBrands = brandRepository.GetAll();
            ListCategories = categoryRepository.GetAll();
            ListUnits = unitRepository.GetAll();

            cbbrand.DataSource = new BindingSource(ListBrands, null);
            cbbrand.DisplayMember = "name";
            cbbrand.ValueMember = "brandid";

            cbcategory.DataSource = new BindingSource(ListCategories, null);
            cbcategory.DisplayMember = "name";
            cbcategory.ValueMember = "catid";

            cbunit.DataSource = new BindingSource(ListUnits, null);
            cbunit.DisplayMember = "name";
            cbunit.ValueMember = "unitid";

            if (Editmode)
            {
                lbtitle.Text = "UBAH DATA BARANG";
                cbcategory.SelectedValue = ProductData.prodcat;
                cbbrand.SelectedValue = ProductData.brandid;
                tbprodcode.Text = ProductData.prodcode;
                tbprodname.Text = ProductData.name;
                cbunit.SelectedValue = ProductData.produnit;
                tbpurchaseprice.Text = ProductData.purchaseprice.ToString();
                tbbarcodeno.Text = ProductData.barcodeno.ToString();
                
            }
                

        }

        private void btsave_Click(object sender, EventArgs e)
        {
            ListProducts = productRepository.GetAll();
            int samenameinsamebrand = 0;
            int samebarcodeno = 0;
            int sameprodcode = 0;

            if (Editmode)
            {
                foreach (var existingdetails in ListProducts)
                {
                    if (existingdetails.name == tbprodname.Text && existingdetails.brandid == (int)cbbrand.SelectedValue)
                    {
                        if (existingdetails.prodid != ProductData.prodid)
                        {
                            samenameinsamebrand += 1;
                            break;
                        }
                            
                    }

                    if (tbbarcodeno.Text == "")
                    {
                        samebarcodeno = 0;
                    }
                    else if (existingdetails.barcodeno == tbbarcodeno.Text)
                    {
                        if (existingdetails.prodid == ProductData.prodid)
                            samebarcodeno = 0;
                        else
                        {
                            samebarcodeno += 1;
                            break;
                        }
                        
                    }

                    if (existingdetails.prodcode == tbprodcode.Text)
                    {
                        if (existingdetails.prodid != ProductData.prodid)
                        {
                            sameprodcode += 1;
                            break;
                        }
                        
                    }

                    
                }


                if (tbprodname.Text == "" || tbprodcode.Text == "")
                    MessageBox.Show("Yang bertanda Bintang tidak boleh kosong");
                else if (samenameinsamebrand > 0)
                {
                    MessageBox.Show("Nama barang yang anda masukkan sudah terdaftar");
                    samenameinsamebrand = 0;
                }
                else if (sameprodcode > 0)
                {
                    MessageBox.Show("Kode barang yang anda masukkan sudah terdaftar");
                    sameprodcode = 0;
                }
                else if (samebarcodeno > 0)
                {
                    MessageBox.Show("Nomor barcode yang anda masukkan sudah terdaftar");
                    samebarcodeno = 0;
                }
                else if (tbpurchaseprice.Value == 0)
                    MessageBox.Show("Harga beli yang anda masukkan Rp 0, silahkan diganti");
                else
                {
                    var Productdatabefore = new ProductColumns();
                    Productdatabefore.prodcat = ProductData.prodcat;
                    Productdatabefore.brandid = ProductData.brandid;
                    Productdatabefore.prodcode = ProductData.prodcode;
                    Productdatabefore.name = ProductData.name;
                    Productdatabefore.produnit = ProductData.produnit;
                    Productdatabefore.purchaseprice = ProductData.purchaseprice;
                    Productdatabefore.barcodeno = ProductData.barcodeno;


                    ProductData.prodcat = (int)cbcategory.SelectedValue;
                    ProductData.brandid = (int)cbbrand.SelectedValue;
                    ProductData.prodcode = tbprodcode.Text;
                    ProductData.name = tbprodname.Text;
                    ProductData.produnit = (int)cbunit.SelectedValue;
                    ProductData.purchaseprice = Utils.ToNumbers(tbpurchaseprice.Text);
                    ProductData.barcodeno = tbbarcodeno.Text;
                    ProductData.updated_by = userdata.username;

                    bool havechanges = false;

                    if (Productdatabefore.prodcat == ProductData.prodcat && Productdatabefore.brandid == ProductData.brandid && Productdatabefore.prodcode == ProductData.prodcode && Productdatabefore.name == ProductData.name && Productdatabefore.produnit == ProductData.produnit && Productdatabefore.purchaseprice == ProductData.purchaseprice && Productdatabefore.barcodeno == ProductData.barcodeno)
                    {
                        havechanges = true;
                    }


                    if (havechanges)
                    {
                        MessageBox.Show("Tidak ada data yang anda ubah");
                        ProductData.prodcat = Productdatabefore.prodcat;
                        ProductData.brandid = Productdatabefore.brandid;
                        ProductData.prodcode = Productdatabefore.prodcode;
                        ProductData.name = Productdatabefore.name;
                        ProductData.produnit = Productdatabefore.produnit;
                        ProductData.purchaseprice = Productdatabefore.purchaseprice;
                        ProductData.barcodeno = Productdatabefore.barcodeno;
                    }
                    else if (productRepository.Update(ProductData))
                    {
                        MessageBox.Show("Data telah berhasil di ubah");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal di ubah");
                        ProductData.prodcat = Productdatabefore.prodcat;
                        ProductData.brandid = Productdatabefore.brandid;
                        ProductData.prodcode = Productdatabefore.prodcode;
                        ProductData.name = Productdatabefore.name;
                        ProductData.produnit = Productdatabefore.produnit;
                        ProductData.purchaseprice = Productdatabefore.purchaseprice;
                        ProductData.barcodeno = Productdatabefore.barcodeno;      
                    }
                        
                }

            }
            else
            {
                foreach (var existingdetails in ListProducts)
                {
                    if (existingdetails.name == tbprodname.Text && existingdetails.brandid == (int)cbbrand.SelectedValue)
                    {
                        samenameinsamebrand += 1;
                        break;
                    }

                    if (tbbarcodeno.Text == "")
                    {
                        samebarcodeno = 0;
                    }
                    else if (existingdetails.barcodeno == tbbarcodeno.Text)
                    {
                        samebarcodeno += 1;
                        break;
                    }

                    if (existingdetails.prodcode == tbprodcode.Text)
                    {
                        if (existingdetails.prodid != ProductData.prodid)
                        {
                            sameprodcode += 1;
                            break;
                        }
                            
                    }
                }



                if (tbprodname.Text == "" || tbprodcode.Text == "")
                    MessageBox.Show(" Yang bertanda Bintang tidak boleh kosong");
                else if (samenameinsamebrand > 0)
                {
                    MessageBox.Show("Nama barang yang anda masukkan sudah terdaftar");
                    samenameinsamebrand = 0;
                }
                else if (sameprodcode > 0)
                {
                    MessageBox.Show("Kode barang yang anda masukkan sudah terdaftar");
                    sameprodcode = 0;
                }
                else if (samebarcodeno > 0)
                {
                    MessageBox.Show("Nomor barcode yang anda masukkan sudah terdaftar");
                    samebarcodeno = 0;
                }
                else if (tbpurchaseprice.Value == 0)
                    MessageBox.Show("Harga beli yang anda masukkan Rp 0, silahkan diganti");
                else
                {
                    var product = new ProductColumns();

                    product.prodcat = (int)cbcategory.SelectedValue;
                    product.brandid = (int)cbbrand.SelectedValue;
                    product.prodcode = tbprodcode.Text;
                    product.name = tbprodname.Text;
                    product.produnit = (int)cbunit.SelectedValue;
                    product.purchaseprice = Utils.ToNumbers(tbpurchaseprice.Text);
                    product.barcodeno = tbbarcodeno.Text;
                    product.created_by = userdata.username;


                    if (productRepository.Add(product))
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
            if (keyData == (Keys.Enter))
            {
                btsave.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                if (MessageBox.Show("Apa Anda Yakin keluar tanpa menyimpan data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tbbarcodeno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
