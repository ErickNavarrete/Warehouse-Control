﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Warehouse_Control.Connection;
using Warehouse_Control.Models;
using Warehouse_Control.Util;

namespace Warehouse_Control.Forms
{

    public partial class ucDeparture : UserControl

    {
        private int idDeparture;
        private int idDepartureDetail1;
        private int idDepartureDetail2;
        private int idItem;
        private int idCellar;
        private int idWarehouse;
        public int idUser;
        public int idDistrict;
        private int editIndex;
        private List<DepartureDet> departureList = new List<DepartureDet>();

        public ucDeparture()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            enable_fields(false);
        }

        #region Funciones

        public void permisos()
        {
            if (idUser != 1)
            {
                cmOpen.Visible = false;
            }
        }

        private void enable_fields(bool flag)
        {
            tbPerson.Enabled = flag;
            cbSerie.Enabled = flag;
            cbCellar.Enabled = flag;
            cbDistrict.Enabled = flag;
            cbItem.Enabled = flag;
            tbQuantity.Enabled = flag;
            dgvDepartureDetail2.Enabled = flag;
            cbWarehouse.Enabled = flag;
            tbObservations.Enabled = flag;
            btnAdd.Enabled = flag;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void clearFieldsTab2()
        {
            cbSerie.Text = "";
            cbCellar.Text = "";
            cbDistrict.Text = "";
            cbWarehouse.Text = "";
            cbItem.Text = "";
            tbQuantity.Text = "";
            tbPerson.Text = "";
            tbCurrentQuantity.Text = "";
            dgvDepartureDetail2.Rows.Clear(); departureList.Clear();
            idItem = 0;
            idDepartureDetail2 = 0;
        }

        private void clearFieldsTab1()
        {
            tbSerie1.Text = "";
            tbFolio1.Text = "";
            tbDate.Text = "";
            tbWarehouse.Text = "";
            tbUser.Text = "";
            tbCellar.Text = "";
            dgvDepartureDetail1.Rows.Clear();
        }

        private void setDataItem()
        {
            cbItem.Items.Clear();
            var db = new ConnectionDB();
            var items = db.Items.ToList();

            foreach (var item in items)
            {
                cbItem.Items.Add(item.key);
            }
        }

        private void setDataDistrict()
        {
            cbDistrict.Items.Clear();
            var db = new ConnectionDB();
            var districts = db.Districts.ToList();

            foreach (var distrito in districts)
            {
                cbDistrict.Items.Add(distrito.district);
            }
        }

        private bool checkFieldsDEpartureDetail()
        {
            var validator = new tbValidators();
            return validator.requieredTextValidator(tbQuantity) && validator.cbRequiredValidator(cbItem);
        }

        private void fill_dgvDepartureDetails2()
        {
            var db = new ConnectionDB();
            dgvDepartureDetail2.Rows.Clear();
            foreach (var departure in departureList)
            {
                var item = db.Items.Where(x => x.id == departure.id_item).FirstOrDefault();
                dgvDepartureDetail2.Rows.Add(departure.id_item, item.key, departure.quantity, departure.user);
            }
        }

        private void fill_dgvDepartures(string searchValue)
        {
            var db = new ConnectionDB();
            dgvDepartures.Rows.Clear();
            List<Departure> departures;
            if (string.IsNullOrEmpty(searchValue))
            {
                departures = db.Departures.ToList();
            }
            else
            {
                departures = db.Departures.Where(
                    x => x.serie == searchValue ||
                    x.folio.ToString() == searchValue
                    ).ToList();
            }


            foreach (var departure in departures)
            {
                var query = db.Departures.Join(db.Users, x => x.id_user, y => y.Id, (x, y) => new
                {
                    departure = x,
                    user = y,
                }).Join(db.Warehouses, x => x.departure.id_warehouse, y => y.id, (x, y) => new
                {
                    departure = x.departure,
                    user = x.user,
                    warehouse = y,
                }).Join(db.Warehouses, x => x.departure.id_cellar, y => y.id, (x, y) => new
                {
                    departure = x.departure,
                    user = x.user,
                    warehouse = x.warehouse,
                    cellar = y,
                }).Where(
                    x => x.departure.id == departure.id
                    ).FirstOrDefault();
                dgvDepartures.Rows.Add(departure.id, departure.serie, departure.folio, departure.date, query.user.name, query.warehouse.name, query.cellar.name, departure.observation);
            }
        }


        #endregion

        private void BtnNew_Click(object sender, EventArgs e)
        {
            enable_fields(true);
            btnNew.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            setDataItem();
            setDataDistrict();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            enable_fields(false);
            btnNew.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            clearFieldsTab2();
        }

        private void CbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbItem.Text;
            var db = new ConnectionDB();
            var item = db.Items.Where(x => x.key == selected).FirstOrDefault();
            idItem = item.id;

            var inventory = db.Inventories.Where(x => x.id_item == idItem).FirstOrDefault();
            if (inventory != null)
            {
                tbCurrentQuantity.Text = inventory.quantity.ToString();
            }
            else
            {
                tbCurrentQuantity.Text = "0";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!checkFieldsDEpartureDetail())
            {
                return;
            }
            var db = new ConnectionDB();
            var data = db.Inventories.FirstOrDefault(x => x.id_warehouse == idWarehouse && x.id_item == idItem);

            int quantity = Convert.ToInt32(tbQuantity.Text);
            if (data == null)
            {
                MessageBox.Show("Elementos insuficientes", "Control de inventarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (data.quantity < quantity)
            {
                MessageBox.Show("Elementos insuficientes", "Control de inventarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var departureDetail = new DepartureDet
            {
                id_item = idItem,
                quantity = Convert.ToInt16(tbQuantity.Text),
                user = tbPerson.Text,
            };
            departureList.Add(departureDetail);

            cbItem.Text = "";
            tbQuantity.Text = "";
            fill_dgvDepartureDetails2();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!checkFieldsDEpartureDetail())
            {
                return;
            }

            var currentDeparture = departureList[editIndex];

            currentDeparture.id_item = idItem;
            currentDeparture.quantity = Convert.ToInt16(tbQuantity.Text);
            fill_dgvDepartureDetails2();

            cbItem.Text = "";
            tbQuantity.Text = "";

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            departureList.RemoveAt(editIndex);
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            cbItem.Text = "";
            tbQuantity.Text = "";
            fill_dgvDepartureDetails2();
        }

        private void TbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Para permitir solo numeros
        }

        private void DgvDepartureDetail2_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDepartureDetail2.Rows.Count == 0)
            {
                return;
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            var index = dgvDepartureDetail2.CurrentRow.Index;
            var currentDeparture = departureList[index];
            editIndex = index;
            var db = new ConnectionDB();
            var item = db.Items.Where(x => x.id == currentDeparture.id_item).FirstOrDefault();

            idItem = item.id;
            cbItem.Text = item.key;
            tbQuantity.Text = currentDeparture.quantity.ToString();
        }

        private void CbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCellar.Text = "";
            cbCellar.Items.Clear();
            var current = cbDistrict.SelectedItem;
            var db = new ConnectionDB();
            var distrito = db.Districts.Where(x => x.district == current.ToString()).FirstOrDefault();
            var warehouses = db.Warehouses.Where(x => x.id_district == distrito.id).ToList();
            idDistrict = distrito.id;

            foreach (var wh in warehouses)
            {
                cbCellar.Items.Add(wh.name);
            }
        }

        private void CbCellar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var current = cbCellar.SelectedItem;
            var db = new ConnectionDB();
            var wh = db.Warehouses.Where(x => x.name == current.ToString()).FirstOrDefault();
            idCellar = wh.id;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            fill_dgvDepartures(tbSearch.Text);
            clearFieldsTab1();
        }

        private void DgvDepartures_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDepartures.Rows.Count == 0)
            {
                return;
            }
            var index = dgvDepartures.CurrentRow.Index;
            var id = Convert.ToInt16(dgvDepartures.Rows[index].Cells[0].Value.ToString());
            var db = new ConnectionDB();
            var query = db.Departures
                .Join(db.Users, x => x.id_user, y => y.Id, (x, y) => new
                {
                    departure = x,
                    user = y
                }).Join(db.Warehouses, x => x.departure.id_warehouse, y => y.id, (x, y) => new
                {
                    departure = x.departure,
                    user = x.user,
                    warehouse = y,
                }).Join(db.Warehouses, x => x.departure.id_cellar, y => y.id, (x, y) => new
                {
                    departure = x.departure,
                    user = x.user,
                    warehouse = x.warehouse,
                    cellar = y
                })
            .Where(z => z.departure.id == id).FirstOrDefault();

            var detailDeparture = db.DepartureDet.Where(x => x.id_departure == id).ToList();

            tbFolio1.Text = query.departure.folio.ToString();
            tbSerie1.Text = query.departure.serie;
            tbUser.Text = query.user.name;
            tbDate.Text = query.departure.date.ToString();
            tbCellar.Text = query.cellar.name;
            tbWarehouse.Text = query.warehouse.name;

            dgvDepartureDetail1.Rows.Clear();
            foreach (var detail in detailDeparture)
            {
                var name = db.Items.Where(x => x.id == detail.id_item).Select(x => x.key).FirstOrDefault();
                dgvDepartureDetail1.Rows.Add(detail.id, name, detail.quantity, detail.user);
            }

        }

        private void CbWarehouse_Click(object sender, EventArgs e)
        {
            cbWarehouse.Items.Clear();
            var db = new ConnectionDB();
            List<Warehouse> warehouse = db.Warehouses.Where(x => x.id_district == 0).ToList();

            foreach (var item in warehouse)
            {
                cbWarehouse.Items.Add(item.name);
            }

        }

        private void CbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new ConnectionDB();
            idWarehouse = db.Warehouses.Where(x => x.name == cbWarehouse.Text)
                .Select(x => x.id)
                .FirstOrDefault();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            var db = new ConnectionDB();

            Departure departure = new Departure();
            DepartureDet departureDet = new DepartureDet();

            if (dgvDepartureDetail2.Rows.Count == 0)
            {
                MessageBox.Show("Sin artículos por entregar", "Control Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            departure.date = DateTime.Now;
            departure.id_cellar = idCellar;
            departure.id_user = idUser;
            departure.id_warehouse = idWarehouse;
            departure.observation = tbObservations.Text;
            departure.serie = cbSerie.Text;
            departure.folio = Convert.ToInt32(tbFolio.Text);

            db.Departures.Add(departure);
            db.SaveChanges();
            MessageBox.Show("Registro con éxito", "Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewRow item in dgvDepartureDetail2.Rows)
            {

                departureDet.id_departure = departure.id;
                departureDet.id_item = (int)item.Cells[0].Value;
                departureDet.quantity = (int)item.Cells[2].Value;
                departureDet.user = (string)item.Cells[3].Value;
                db.DepartureDet.Add(departureDet);
                db.SaveChanges();
                var inventory = db.Inventories.FirstOrDefault(x => x.id_warehouse == idWarehouse
                                                                 && x.id_item == departureDet.id_item);
                if (inventory != null)
                {
                    inventory.quantity = inventory.quantity - departureDet.quantity;
                    db.Entry(inventory).State = EntityState.Modified;
                    db.SaveChanges();
                }

                var inventory_cellar =
                    db.Inventories.FirstOrDefault(x => x.id_warehouse == idCellar && x.id_item == departureDet.id_item);

                if (inventory_cellar != null)
                {
                    inventory_cellar.quantity = inventory_cellar.quantity + departureDet.quantity;
                    db.Entry(inventory_cellar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    inventory_cellar = new Inventory
                    {
                        id_item = departureDet.id_item,
                        id_warehouse = idCellar,
                        quantity = departureDet.quantity
                    };
                    db.Inventories.Add(inventory_cellar);
                    db.SaveChanges();
                }
            }
            fill_dgvDepartures("");
            enable_fields(false);
            btnNew.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            clearFieldsTab2();
        }

        private void CbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new ConnectionDB();
            var aux = db.Departures.Where(x => x.serie == cbSerie.Text).OrderByDescending(x => x.id).FirstOrDefault();
            if (aux == null)
            {
                tbFolio.Text = "1";
            }
            else
            {
                tbFolio.Text = (aux.folio + 1).ToString();
            }
        }

        private void CbSerie_Leave(object sender, EventArgs e)
        {
            var db = new ConnectionDB();
            var aux = db.Departures.Where(x => x.serie == cbSerie.Text).OrderByDescending(x => x.id).FirstOrDefault();
            if (aux == null)
            {
                tbFolio.Text = "1";
            }
            else
            {
                tbFolio.Text = (aux.folio + 1).ToString();
            }
        }

        private void AsignarEncargadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmOpen.Visible = false;
            cmCancel.Visible = true;
            btnEditPerson.Enabled = true;
            tbEditPerson.Enabled = true;
        }

        private void CancelarReasignaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmOpen.Visible = true;
            cmCancel.Visible = false;
            btnEditPerson.Enabled = false;
            tbEditPerson.Enabled = false;
        }

        private void BtnEditPerson_Click(object sender, EventArgs e)
        {
            if (dgvDepartureDetail1.Rows.Count == 0)
            {
                return;
            }
            var index = dgvDepartureDetail1.CurrentRow.Index;
            var id = Convert.ToInt32(dgvDepartureDetail1.Rows[index].Cells[0].Value.ToString());

            var db = new ConnectionDB();
            var detail = db.DepartureDet.Where(x => x.id == id).FirstOrDefault();
            detail.user = tbEditPerson.Text;

            db.Entry(detail).State = EntityState.Modified;
            db.SaveChanges();

            dgvDepartureDetail1.Rows.Clear();
            var details = db.DepartureDet.Where(x => x.id_departure == detail.id_departure).ToList();
            foreach (var detailDeparture in details)
            {
                var name = db.Items.Where(x => x.id == detail.id_item).Select(x => x.key).FirstOrDefault();
                dgvDepartureDetail1.Rows.Add(detailDeparture.id, name, detailDeparture.quantity, detailDeparture.user);
            }
        }

        private void cbCellar_Click(object sender, EventArgs e)
        {
            cbCellar.Text = "";
            cbCellar.Items.Clear();
            var current = cbDistrict.SelectedItem;
            var db = new ConnectionDB();
            var distrito = db.Districts.Where(x => x.district == current.ToString()).FirstOrDefault();
            var warehouses = db.Warehouses.Where(x => x.id_district == distrito.id).ToList();
            idDistrict = distrito.id;

            foreach (var wh in warehouses)
            {
                cbCellar.Items.Add(wh.name);
            }
        }

        private void cbItem_Click(object sender, EventArgs e)
        {
            setDataItem();
        }
    }
}
