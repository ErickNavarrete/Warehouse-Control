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
using Warehouse_Control.PDF;
using Warehouse_Control.Util;

namespace Warehouse_Control.Forms
{
    public partial class ucReports : UserControl
    {
        private tbValidators utils;
        public ucReports()
        {
            InitializeComponent();
            utils = new tbValidators();
        }

        #region FUNCIONES

        public void fillComboBoxUser()
        {
            cbUser.Items.Clear();
            ConnectionDB db = new ConnectionDB();
            var data = db.Users.Select(x => x.name).ToList();

            foreach (var item in data)
            {
                cbUser.Items.Add(item.ToUpper());
            }

            cbUser.Items.Add("TODOS");
        }

        private void Query(int option)
        {
            ConnectionDB db = new ConnectionDB();
            crEntry crEntry = new crEntry();
            crDeparture crDeparture = new crDeparture();
            dsData dsData = new dsData();
            scrReports scrReports = new scrReports();

            int id_user = db.Users.Where(x => x.name == cbUser.Text).Select(x=> x.Id).FirstOrDefault();

            switch (option)
            {
                case 1:
                    #region ENTRADAS
                    var EntryHeader = db.Entry.Join(db.Users, x=> x.id_user,y=> y.Id,(x,y) => new
                    {
                        x.serie,
                        x.folio,
                        x.Id,
                        x.date,
                        x.id_user,
                        x.id_warehouse,
                        x.observation,
                        user_name = y.name
                    }).Join(db.Warehouses, x=> x.id_warehouse, y=> y.id,(x,y) => new
                    {
                        x.serie,
                        x.folio,
                        x.Id,
                        x.date,
                        x.id_user,
                        x.id_warehouse,
                        x.observation,
                        x.user_name,
                        warehouse_name = y.name
                    }).Where(x =>
                        DbFunctions.TruncateTime(x.date) >= DbFunctions.TruncateTime(dtpF1.Value) &&
                        DbFunctions.TruncateTime(x.date) <= DbFunctions.TruncateTime(dtpF2.Value));
                    if (cbUser.Text != "TODOS")
                    {
                        EntryHeader = EntryHeader.Where(x => x.id_user == id_user);
                    }

                    foreach (var Entry in EntryHeader.ToList())
                    {
                        dsData.dtHeaderEntry.AdddtHeaderEntryRow(Entry.serie, Entry.folio.ToString(), Entry.date.ToString("D"),Entry.user_name,Entry.warehouse_name,
                                                                Entry.observation,Entry.Id.ToString());
                        var EntryDetail = db.EntryDet.Join(db.Items, x => x.id_item, y => y.id, (x, y) => new
                        {
                            x.id_entry,
                            x.id_item,
                            x.quantity,
                            y.key,
                            y.description
                        }).Where(x=> x.id_entry == Entry.Id).ToList();

                        foreach (var item in EntryDetail)
                        {
                            dsData.dtDetailEntry.AdddtDetailEntryRow(item.key, item.description, item.quantity,
                                item.ToString());
                        }
                    }

                    crEntry.SetDataSource(dsData);
                    scrReports.crv.ReportSource = crEntry;

                    #endregion
                    break;
                case 2:
                    var DepartureHeader = db.Departure.Join(db.Users, x => x.id_user, y => y.Id, (x, y) => new
                    {
                        x.id,
                        x.id_user,
                        x.id_cellar,
                        x.id_warehouse,
                        x.serie,
                        x.folio,
                        x.date,
                        x.observation,
                        user_name = y.name
                    }).Join(db.Warehouses,x=> x.id_warehouse,y=> y.id,(x,y) => new
                    {
                        x.id,
                        x.id_user,
                        x.id_cellar,
                        x.id_warehouse,
                        x.serie,
                        x.folio,
                        x.date,
                        x.observation,
                        x.user_name,
                        warehouse_name = y.name
                    }).Join(db.Warehouses,x=> x.id_cellar, y=> y.id, (x,y) => new
                    {
                        x.id,
                        x.id_user,
                        x.id_cellar,
                        x.id_warehouse,
                        y.id_district,
                        x.serie,
                        x.folio,
                        x.date,
                        x.observation,
                        x.user_name,
                        x.warehouse_name,
                        cellar_name = y.name
                    }).Join(db.Districts, x=> x.id_district, y=> y.id,(x,y) => new
                    {
                        x.id,
                        x.id_user,
                        x.serie,
                        x.folio,
                        x.date,
                        x.observation,
                        x.user_name,
                        x.warehouse_name,
                        x.cellar_name,
                        y.district,
                        y.district_name
                    }).Where(x =>
                        DbFunctions.TruncateTime(x.date) >= DbFunctions.TruncateTime(dtpF1.Value) &&
                        DbFunctions.TruncateTime(x.date) <= DbFunctions.TruncateTime(dtpF2.Value));

                    if (cbUser.Text != "TODOS")
                    {
                        DepartureHeader = DepartureHeader.Where(x => x.id_user == id_user);
                    }

                    foreach (var Departure in DepartureHeader.ToList())
                    {
                        dsData.dtDepartureHeader.AdddtDepartureHeaderRow(Departure.id, Departure.serie,
                            Departure.folio.ToString(), Departure.user_name, Departure.warehouse_name,
                            Departure.cellar_name, Departure.observation, Departure.district, Departure.district_name,
                            Departure.date.ToString("D"));

                        var DepartureDetail = db.DepartureDet.Join(db.Items, x => x.id_item, y => y.id, (x, y) => new
                        {
                            x.id_departure,
                            x.quantity,
                            y.key,
                            y.description
                        }).ToList();

                        foreach (var item in DepartureDetail)
                        {
                            dsData.dtDepartureDetail.AdddtDepartureDetailRow(item.id_departure, item.key,
                                item.description, item.quantity);
                        }
                    }

                    crDeparture.SetDataSource(dsData);
                    scrReports.crv.ReportSource = crDeparture;
                    break;
            }

            scrReports.ShowDialog();
            dsData.Clear();
            crEntry.Close();
        }
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbKind.Text))
            {
                MessageBox.Show("Campo obligatorio", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKind.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbUser.Text))
            {
                MessageBox.Show("Campo obligatorio", "Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbUser.Focus();
                return;
            }

            switch (cbKind.Text)
            {
                case "Entradas":
                    Query(1);
                    break;
                case "Salidas":
                    Query(2);
                    break;
            }
        }
    }
}
