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
using System.Data.Entity;

namespace Warehouse_Control.Forms
{
    public partial class ucInputs : UserControl
    {
        private int idEntry;
        private int idEntryDetail1;
        private int idEntryDetail2;
        private int idItem;
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
            cbItem.Enabled = flag;
            tbQuantity.Enabled = flag;
            dgvEntryDetail2.Enabled = flag;
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
            dgvEntryDetail2.Rows.Clear(); entryList.Clear();
            idItem = 0;
            idEntryDetail2 = 0;
        }

        private void clearFieldsTab1()
        {
            tbSerie1.Text = "";
            tbFolio1.Text = "";
            tbDate.Text = "";
            tbWarehouse.Text = "";
            tbUser.Text = "";
            dgvEntryDetail1.Rows.Clear();
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

        private void fill_dgvEntryDetails2()
        {
            var db = new ConnectionDB();
            dgvEntryDetail2.Rows.Clear();
            foreach (var entry in entryList)
            {
                var item = db.Items.Where(x => x.id == entry.id_item).FirstOrDefault();
                dgvEntryDetail2.Rows.Add(entry.id_item, item.key, entry.quantity);
            }
        }

        private void fill_dgvEntries(string searchValue)
        {
            var db = new ConnectionDB();
            dgvEntries.Rows.Clear();
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
                var query = db.Entries.Join(db.Users, x => x.id_user, y => y.Id, (x, y) => new
                {
                    entry = x,
                    user = y,
                }).Join(db.Warehouses, x => x.entry.id_warehouse, y => y.id, (x, y) => new
                {
                    entry = x.entry,
                    user = x.user,
                    warehouse = y,
                }).Where(
                    x => x.entry.Id == entry.Id
                    ).FirstOrDefault();
                dgvEntries.Rows.Add(entry.Id, entry.serie, entry.folio, entry.date, query.user.name, query.warehouse.name, entry.observation);
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
            fill_dgvEntryDetails2();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!checkFieldsEntryDetail())
            {
                return;
            }

            var currentEntry = entryList[editIndex];

            currentEntry.id_item = idItem;
            currentEntry.quantity = Convert.ToInt16(tbQuantity.Text);
            fill_dgvEntryDetails2();

            cbItem.Text = "";
            tbQuantity.Text = "";

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            entryList.RemoveAt(editIndex);
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            cbItem.Text = "";
            tbQuantity.Text = "";
            fill_dgvEntryDetails2();
        }

        private void TbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Para permitir solo numeros
        }

        private void DgvEntryDetail2_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEntryDetail2.Rows.Count == 0)
            {
                return;
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            var index = dgvEntryDetail2.CurrentRow.Index;
            var currentEntry = entryList[index];
            editIndex = index;
            var db = new ConnectionDB();
            var item = db.Items.Where(x => x.id == currentEntry.id_item).FirstOrDefault();

            idItem = item.id;
            cbItem.Text = item.key;
            tbQuantity.Text = currentEntry.quantity.ToString();
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            fill_dgvEntries(tbSearch.Text);
            clearFieldsTab1();
        }

        private void DgvEntries_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEntries.Rows.Count == 0)
            {
                return;
            }
            var index = dgvEntries.CurrentRow.Index;
            var id = Convert.ToInt16(dgvEntries.Rows[index].Cells[0].Value.ToString());
            var db = new ConnectionDB();
            var query = db.Entries
                .Join(db.Users, x => x.id_user, y => y.Id, (x, y) => new
                {
                    entry = x,
                    user = y
                }).Join(db.Warehouses, x => x.entry.id_warehouse, y => y.id, (x, y) => new
                {
                    entry = x.entry,
                    user = x.user,
                    warehouse = y,
                })
            .Where(z => z.entry.Id == id).FirstOrDefault();

            var detailEntries = db.EntryDet.Where(x => x.id_entry == id).ToList();

            tbFolio1.Text = query.entry.folio.ToString();
            tbSerie1.Text = query.entry.serie;
            tbUser.Text = query.user.name;
            tbDate.Text = query.entry.date.ToString();
            tbWarehouse.Text = query.warehouse.name;

            dgvEntryDetail1.Rows.Clear();
            foreach (var detail in detailEntries)
            {
                var name = db.Items.Where(x => x.id == detail.id_item).Select(x => x.key).FirstOrDefault();
                dgvEntryDetail1.Rows.Add(detail.Id, name, detail.quantity);
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

            Entry entry = new Entry();
            EntryDet entryDet = new EntryDet();

            entry.date = DateTime.Now;
            entry.folio = Convert.ToInt32(tbFolio2.Text);
            entry.id_user = idUser;
            entry.id_warehouse = idWarehouse;
            entry.observation = tbObservations.Text;
            entry.serie = tbSerie2.Text;
            db.Entries.Add(entry);
            db.SaveChanges();
            MessageBox.Show("Registro con éxito", "Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewRow item in dgvEntryDetail2.Rows)
            {
                entryDet.id_entry = entry.Id;
                entryDet.id_item = (int)item.Cells[0].Value;
                entryDet.quantity = (int)item.Cells[2].Value;
                db.EntryDet.Add(entryDet);
                db.SaveChanges();

                var inventory = db.Inventories.Where(x => x.id_item == entryDet.id_item).FirstOrDefault();
                if (inventory == null)
                {
                    inventory = new Inventory()
                    {
                        id_item = entryDet.id_item,
                        id_warehouse = entry.id_warehouse,
                        quantity = entryDet.quantity,
                    };
                    db.Inventories.Add(inventory);
                    db.SaveChanges();
                }
                else {
                    inventory.quantity += entryDet.quantity;
                    db.Entry(inventory).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            fill_dgvEntries("");
            clearFieldsTab2();

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
    }
}
