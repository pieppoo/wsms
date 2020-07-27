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
    public partial class ManageUnit : Form
    {
        public bool Editmode { get; set; }
        public UnitColumns UnitData { get; set; }
        public LoginColumns userdata { get; set; }
        public List<UnitColumns> ListUnit { get; set; }
        public ManageUnit()
        {
            InitializeComponent();
        }

        private UnitRepo unitRepo = new UnitRepo();

        private void ManageUnit_Load(object sender, EventArgs e)
        {
            if (Editmode)
            {
                lbtitle.Text = "UBAH DATA KEMASAN";
                tbunitname.Text = UnitData.name;
                tbremark.Text = UnitData.remark;
                tbunitcode.Text = UnitData.unitcode;
            }
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            ListUnit = unitRepo.GetAll();
            int samename = 0;
            int samecode = 0;


            if (Editmode)
            {
                foreach (var existingdetails in ListUnit)
                {
                    if (existingdetails.name == tbunitname.Text && existingdetails.unitid != UnitData.unitid)
                    {
                        samename += 1;
                        break;
                    }
                    else if(existingdetails.unitcode == tbunitcode.Text && existingdetails.unitid != UnitData.unitid)
                    {
                        samecode += 1;
                        break;
                    }
                }


                if (tbunitcode.Text == "" || tbunitname.Text == "")
                    MessageBox.Show("Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else if (samecode > 0)
                {
                    MessageBox.Show("Kode yang anda masukkan sudah terdaftar");
                    samecode = 0;
                }
                else
                {
                    var DataBefore = new UnitColumns();
                    DataBefore.name = UnitData.name;
                    DataBefore.remark = UnitData.remark;
                    DataBefore.unitcode = UnitData.unitcode;

                    UnitData.name = tbunitname.Text;
                    UnitData.remark = tbremark.Text;
                    UnitData.updated_by = userdata.username;
                    UnitData.unitcode = tbunitcode.Text;

                    bool havechanges = false;

                    if (DataBefore.name == UnitData.name && DataBefore.remark == UnitData.remark && DataBefore.unitcode == UnitData.unitcode)
                    {
                        havechanges = true;
                    }


                    if (havechanges)
                    {
                        MessageBox.Show("Tidak ada data yang anda ubah");
                        UnitData.name = DataBefore.name;
                        UnitData.remark = DataBefore.remark;
                        UnitData.unitcode = DataBefore.unitcode;
                    }
                    else if (unitRepo.Update(UnitData))
                    {
                        MessageBox.Show("Data telah berhasil di ubah");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal di ubah");
                        UnitData.name = DataBefore.name;
                        UnitData.remark = DataBefore.remark;
                        UnitData.unitcode = DataBefore.unitcode;
                    }

                }
            }
            else
            {
                foreach (var existingdetails in ListUnit)
                {
                    if (existingdetails.name == tbunitname.Text)
                    {
                        samename += 1;
                        break;
                    }
                    else if (existingdetails.unitcode == tbunitcode.Text)
                    {
                        samecode += 1;
                    }

                }

                if (tbunitcode.Text == "" || tbunitname.Text == "")
                    MessageBox.Show(" Yang bertanda Bintang tidak boleh kosong");
                else if (samename > 0)
                {
                    MessageBox.Show("Nama yang anda masukkan sudah terdaftar");
                    samename = 0;
                }
                else if (samecode > 0)
                {
                    MessageBox.Show("Kemasan yang anda masukkan sudah terdaftar");
                    samecode = 0;
                }
                else
                {
                    var NewUnit = new UnitColumns();

                    NewUnit.name = tbunitname.Text;
                    NewUnit.remark = tbremark.Text;
                    NewUnit.created_by = userdata.username;
                    NewUnit.unitcode = tbunitcode.Text;


                    if (unitRepo.Add(NewUnit))
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
