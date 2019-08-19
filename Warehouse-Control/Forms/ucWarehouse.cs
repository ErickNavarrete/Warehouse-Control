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
using CrystalDecisions.CrystalReports.Engine;
using Warehouse_Control.Connection;
using Warehouse_Control.Util;

namespace Warehouse_Control.Forms
{
    public partial class ucWarehouse : UserControl
    {
        private tbValidators utils;
        private ConnectionDB db;
        private int id;

        public ucWarehouse()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;

            utils = new tbValidators();
            db = new ConnectionDB();
            utils.control_enable_all_textbox(this, false, true);
        }

        private void fillDgv(string searchValue = "")
        {
            dgvWarehouse.Rows.Clear();
            var datos = db.Warehouses.Where(x => x.id_district == 0);
            if (!string.IsNullOrEmpty(searchValue))
            {
                datos = datos.Where(x => x.name.Contains(searchValue) || x.address.Contains(searchValue));
            }

            foreach (var item in datos.ToList())
            {
                dgvWarehouse.Rows.Add(item.id, item.name, item.address);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            utils.control_enable_all_textbox(this, false, true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnSave.Text = "Guardar";

            utils.control_enable_all_textbox(this,true,true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!utils.requieredTextValidator(tbName, true))
            {
                return;
            }
            if (!utils.requieredTextValidator(tbAddress, true))
            {
                return;
            }

            if (btnSave.Text == "Guardar")
            { 
                var datos = db.Warehouses.FirstOrDefault(x => x.name == tbName.Text);
                if (datos != null)
                {
                    MessageBox.Show("Almacén existente", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbName.Focus();
                    return;
                }

                var warehouse = new Models.Warehouse
                {
                    name = tbName.Text,
                    address = tbAddress.Text,
                    id_district = 0
                };

                db.Warehouses.Add(warehouse);
                db.SaveChanges();
                MessageBox.Show("Almacén creado con éxito", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var datos2 = db.Warehouses.FirstOrDefault(x => x.name == tbName.Text && x.id == id);
                if (datos2 != null)
                {
                    MessageBox.Show("Almacén existente", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbName.Focus();
                    return;
                }

                var warehouseEdit = db.Warehouses.FirstOrDefault(x=> x.id == id);
                if (warehouseEdit != null)
                {
                    warehouseEdit.name = tbName.Text;
                    warehouseEdit.address = tbAddress.Text;

                    db.Entry(warehouseEdit).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Almacén actualizado con éxito", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            btnNew.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            utils.control_enable_all_textbox(this, false, true);
            fillDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillDgv(tbSearchValue.Text);
        }

        private void dgvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow != null)
            {
                int index = dgvWarehouse.CurrentRow.Index;
                id = (int)dgvWarehouse.Rows[index].Cells[0].Value;
                tbName.Text = dgvWarehouse.Rows[index].Cells[1].Value.ToString();
                tbAddress.Text = dgvWarehouse.Rows[index].Cells[1].Value.ToString();

                btnNew.Visible = true;
                btnEdit.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                utils.control_enable_all_textbox(this, false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnSave.Text = "Guardar Edición";

            utils.control_enable_all_textbox(this, true);
        }
    }
}
