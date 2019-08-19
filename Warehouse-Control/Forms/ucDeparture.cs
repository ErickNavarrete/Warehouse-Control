using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Models;
using Warehouse_Control.Connection;
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

        private void enable_fields(bool flag)
        {
            tbFolio2.Enabled = flag;
            tbSerie2.Enabled = flag;
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
            tbSerie2.Text = "";
            tbFolio2.Text = "";
            cbCellar.Text = "";
            cbDistrict.Text = "";
            cbWarehouse.Text = "";
            cbItem.Text = "";
            tbQuantity.Text = "";
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

        private void setDataItem(){
            cbItem.Items.Clear();
            var db = new ConnectionDB();
            var items = db.Items.ToList();

            foreach (var item in items) {
                cbItem.Items.Add(item.key);
            }
        }

        private void setDataDistrict() {
            cbDistrict.Items.Clear();
            var db = new ConnectionDB();
            var districts = db.Districts.ToList();

            foreach(var distrito in districts)
            {
                cbDistrict.Items.Add(distrito.district);
            }
        }

        private bool checkFieldsDEpartureDetail() {
            var validator = new tbValidators();
            return validator.requieredTextValidator(tbQuantity) && validator.cbRequiredValidator(cbItem);
        }

        private void fill_dgvDepartureDetails2() {
            var db = new ConnectionDB();
            dgvDepartureDetail2.Rows.Clear();
            foreach (var departure in departureList) {
                var item = db.Items.Where(x => x.id == departure.id_item).FirstOrDefault();
                dgvDepartureDetail2.Rows.Add(departure.id_item, item.key,departure.quantity);
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
            else {
                departures = db.Departures.Where(
                    x=> x.serie == searchValue ||
                    x.folio.ToString() == searchValue
                    ).ToList();
            }


            foreach (var departure in departures)
            {
                dgvDepartures.Rows.Add(departure.id,departure.serie, departure.folio, departure.date, departure.id_user, departure.id_warehouse, departure.id_cellar, departure.observation);
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
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!checkFieldsDEpartureDetail()) {
                return;
            }
            var db = new ConnectionDB();
            var data = db.Inventories.FirstOrDefault(x => x.id_warehouse == idWarehouse && x.id_item == idItem);

            int quantity = Convert.ToInt32(tbQuantity.Text); 
            if (data.quantity < quantity)
            {
                MessageBox.Show("Elementos insuficientes", "Control de inventarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var departureDetail = new DepartureDet {
                id_item = idItem,
                quantity = Convert.ToInt16( tbQuantity.Text)
            };
            departureList.Add(departureDetail);

            cbItem.Text = "";
            tbQuantity.Text = "";
            fill_dgvDepartureDetails2();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!checkFieldsDEpartureDetail()) {
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
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
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
            if (dgvDepartureDetail2.Rows.Count == 0) {
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
            var distrito = db.Districts.Where(x => x.district == current).FirstOrDefault();
            var warehouses = db.Warehouses.Where( x=> x.id_district == distrito.id).ToList();
            idDistrict = distrito.id;

            foreach (var wh in warehouses) {
                cbCellar.Items.Add(wh.name);
            }
        }

        private void CbCellar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var current = cbCellar.SelectedItem;
            var db = new ConnectionDB();
            var wh = db.Warehouses.Where(x => x.name == current).FirstOrDefault();
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
            .Where( z => z.departure.id == id).FirstOrDefault();

            var detailDeparture = db.DepartureDet.Where(x => x.id_departure == id).ToList();

            tbFolio1.Text = query.departure.folio.ToString();
            tbSerie1.Text = query.departure.serie;
            tbUser.Text = query.user.name;
            tbDate.Text = query.departure.date.ToString();
            tbCellar.Text = query.cellar.name;
            tbWarehouse.Text = query.warehouse.name;
            
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

            Departure departure       = new Departure();
            DepartureDet departureDet = new DepartureDet();

            departure.date         = DateTime.Now;
            departure.folio        = Convert.ToInt32(tbFolio2.Text);
            departure.id_cellar    = idCellar;
            departure.id_user      = idUser;
            departure.id_warehouse = idWarehouse;
            departure.observation  = tbObservations.Text;
            departure.serie        = tbSerie2.Text;
            db.Departures.Add(departure);
            db.SaveChanges();
            MessageBox.Show("Registro con éxito", "Salida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewRow item in dgvDepartureDetail2.Rows)
            {
                departureDet.id_departure = departure.id;
                departureDet.id_item = (int) item.Cells[0].Value;
                departureDet.quantity = (int) item.Cells[2].Value;
                db.DepartureDet.Add(departureDet);
                db.SaveChanges();
            }
        }
    }
}
