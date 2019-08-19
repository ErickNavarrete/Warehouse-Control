using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Util;
using Warehouse_Control.Connection;
using Warehouse_Control.Models;

namespace Warehouse_Control.Forms
{
    public partial class ucInputs : UserControl
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
        private List<EntryDet> entryList = new List<EntryDet>();

        public ucInputs()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
        }

        #region Funciones

        private void enable_fields(bool flag)
        {
            tbFolio2.Enabled = flag;
            tbSerie2.Enabled = flag;
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
            cbWarehouse.Text = "";
            cbItem.Text = "";
            tbQuantity.Text = "";
            dgvDepartureDetail2.Rows.Clear(); entryList.Clear();
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

        private bool checkFieldsEntryDetail()
        {
            var validator = new tbValidators();
            return validator.requieredTextValidator(tbQuantity) && validator.cbRequiredValidator(cbItem);
        }

        private void fill_dgvDepartureDetails2()
        {
            var db = new ConnectionDB();
            dgvDepartureDetail2.Rows.Clear();
            foreach (var entry in entryList)
            {
                var item = db.Items.Where(x => x.id == entry.id_item).FirstOrDefault();
                dgvDepartureDetail2.Rows.Add(entry.Id, item.key, entry.quantity);
            }
        }

        private void fill_dgvDepartures(string searchValue)
        {
            var db = new ConnectionDB();
            dgvDepartures.Rows.Clear();
            List<Entry> entries;
            if (string.IsNullOrEmpty(searchValue))
            {
                entries = db.Entries.ToList();
            }
            else
            {
                entries = db.Entries.Where(
                    x => x.serie == searchValue ||
                    x.folio.ToString() == searchValue
                    ).ToList();
            }


            foreach (var entry in entries)
            {
                dgvDepartures.Rows.Add(entry.Id, entry.serie, entry.folio, entry.date, entry.id_user, entry.id_warehouse, entry.observation);
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
            var selected = cbItem.SelectedItem.ToString();
            var db = new ConnectionDB();
            var item = db.Items.Where(x => x.key == selected).FirstOrDefault();
            idItem = item.id;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!checkFieldsEntryDetail())
            {
                return;
            }

            var entryDetail = new EntryDet
            {
                id_item = idItem,
                quantity = Convert.ToInt16(tbQuantity.Text)
            };
            entryList.Add(entryDetail);

            cbItem.Text = "";
            tbQuantity.Text = "";
            fill_dgvDepartureDetails2();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!checkFieldsEntryDetail())
            {
                return;
            }

            var currentDeparture = entryList[editIndex];

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
            entryList.RemoveAt(editIndex);
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
            if (dgvDepartureDetail2.Rows.Count == 0)
            {
                return;
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            var index = dgvDepartureDetail2.CurrentRow.Index;
            var currentDeparture = entryList[index];
            editIndex = index;
            var db = new ConnectionDB();
            var item = db.Items.Where(x => x.id == currentDeparture.id_item).FirstOrDefault();

            idItem = item.id;
            cbItem.Text = item.key;
            tbQuantity.Text = currentDeparture.quantity.ToString();
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
                    entry = x,
                    user = y
                }).Join(db.Warehouses, x => x.entry.id_warehouse, y => y.id, (x, y) => new
                {
                    entry = x.entry,
                    user = x.user,
                    warehouse = y,
                }).Join(db.Warehouses, x => x.entry.id_cellar, y => y.id, (x, y) => new
                {
                    entry = x.entry,
                    user = x.user,
                    warehouse = x.warehouse,
                    cellar = y
                })
            .Where(z => z.entry.id == id).FirstOrDefault();

            var detailDeparture = db.EntryDet.Where(x => x.id_entry == id).ToList();

            tbFolio1.Text = query.entry.folio.ToString();
            tbSerie1.Text = query.entry.serie;
            tbUser.Text = query.user.name;
            tbDate.Text = query.entry.date.ToString();
            tbWarehouse.Text = query.warehouse.name;

        }

        private void CbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
