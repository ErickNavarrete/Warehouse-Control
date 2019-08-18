using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Connection;
using Warehouse_Control.Models;
using Warehouse_Control.Util;

namespace Warehouse_Control.Forms
{
    public partial class ucDistrict : UserControl
    {
        private tbValidators utils;
        private int id_district;
        private int id;

        public ucDistrict()
        {
            InitializeComponent();
            utils = new tbValidators();
        }

        #region FUNCIONES

        public void fillDistrict()
        {
            ConnectionDB db = new ConnectionDB();
            cbDistrict.Items.Clear();

            var district = db.Districts.ToList();
            foreach (var item in district)
            {
                cbDistrict.Items.Add(item.district);
            }
        }

        private void enable_disable_fields(bool option)
        {
            cbDistrict.Enabled = option;
            tbWarehouseAddress.Enabled = option;
            tbWarehouseName.Enabled = option;
        }

        private void fill_dgv(string SearchValue)
        {
            ConnectionDB db = new ConnectionDB();
            dgvWarehouseDistrict.Rows.Clear();

            var data = db.Warehouses.Join(db.Districts, x => x.id_district, y => y.id, (x, y) => new
            {
                x.id,
                x.name,
                x.address,
                y.district,
                y.district_name
            });

            if (!string.IsNullOrEmpty(SearchValue))
            {
                data = data.Where(x => x.name.Contains(SearchValue) ||
                                       x.address.Contains(SearchValue) ||
                                       x.district.Contains(SearchValue) ||
                                       x.district_name.Contains(SearchValue));
            }

            foreach (var item in data.ToList())
            {
                dgvWarehouseDistrict.Rows.Add(item.id,
                    item.district,
                    item.district_name,
                    item.name,
                    item.address);
            }
        }

        private void clean_fields()
        {
            cbDistrict.Text = string.Empty;
            tbDistrictName.Text = string.Empty;
            tbWarehouseName.Text = string.Empty;
            tbWarehouseAddress.Text = string.Empty;
        }
        #endregion

        #region BOTONES
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            enable_disable_fields(true);
            btnSave.Text = "Guardar";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConnectionDB db = new ConnectionDB();
            if (!utils.requieredTextValidator(tbDistrictName)) return;
            if (!utils.requieredTextValidator(tbWarehouseName)) return;

            if (btnSave.Text == "Guardar")
            {
                Warehouse warehouse = new Warehouse
                {
                    id_district = id_district,
                    name = tbWarehouseName.Text,
                    address = tbWarehouseAddress.Text
                };

                db.Warehouses.Add(warehouse);
                db.SaveChanges();

                MessageBox.Show("Bodega registrada con éxito", "Control Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Warehouse warehouse_edit = db.Warehouses.FirstOrDefault(x => x.id == id);
                warehouse_edit.id_district = id_district;
                warehouse_edit.name = tbWarehouseName.Text;
                warehouse_edit.address = tbWarehouseAddress.Text;

                db.Entry(warehouse_edit).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Bodega actualizada con éxito", "Control Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            fill_dgv("");
            clean_fields();
            enable_disable_fields(false);

            btnNew.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = false;
        }

        private void dgvWarehouseDistrict_DoubleClick(object sender, EventArgs e)
        {
            if (dgvWarehouseDistrict.CurrentRow != null)
            {
                ConnectionDB db = new ConnectionDB();
                int index = dgvWarehouseDistrict.CurrentRow.Index;
                id = Convert.ToInt32(dgvWarehouseDistrict.Rows[index].Cells[0].Value);
                id_district = db.Warehouses.Where(x => x.id == id).Select(x => x.id_district).FirstOrDefault();

                cbDistrict.Text = dgvWarehouseDistrict.Rows[index].Cells[1].Value.ToString();
                tbDistrictName.Text = dgvWarehouseDistrict.Rows[index].Cells[2].Value.ToString();
                tbWarehouseName.Text = dgvWarehouseDistrict.Rows[index].Cells[3].Value.ToString();
                tbWarehouseAddress.Text = dgvWarehouseDistrict.Rows[index].Cells[4].Value.ToString();

                btnNew.Visible = true;
                btnCancel.Visible = false;
                btnSave.Visible = false;
                btnEdit.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = false;

            clean_fields();
            enable_disable_fields(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            enable_disable_fields(true);
            btnSave.Text = "Guardar Edición";
        }

        #endregion

        private void cbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectionDB db = new ConnectionDB();
            id_district = db.Districts.Where(x => x.district == cbDistrict.Text).Select(x => x.id).FirstOrDefault();
            tbDistrictName.Text = db.Districts.Where(x => x.district == cbDistrict.Text).Select(x => x.district_name).FirstOrDefault();
        }

    }
}
