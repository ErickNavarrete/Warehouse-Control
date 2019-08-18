using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Connection;
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
            switch (option)
            {
                case 1:
                    
                    break;
                case 2:

                    break;
            }
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
