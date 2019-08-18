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
            btnDelete.Enabled = flag;
            btnEdit.Enabled = flag;
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
            dgvDepartureDetail2.Rows.Clear();
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
            departureList.Clear();
            idItem = 0;
            idDepartureDetail2 = 0;
        }

        private void setDataItem(){
            cbItem.Items.Clear();
            var db = new ConnectionDB();
            var items = db.Items.ToList();

            foreach (var item in items) {
                cbItem.Items.Add(item.key);
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
    }
}
