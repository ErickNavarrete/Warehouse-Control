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

namespace Warehouse_Control.Forms
{
    public partial class ucInventory : UserControl
    {

        public ucInventory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConnectionDB db = new ConnectionDB();
            dgvInventory.Rows.Clear();
            if (string.IsNullOrEmpty(cbWarehouse.Text))
            {
                MessageBox.Show("Campo obligatorio", cbWarehouse.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbWarehouse.Focus();
                return;
            }

            var data = db.Inventory.Join(db.Items, x => x.id_item, y => y.id, (x, y) => new
            {
                x.id_warehouse,
                x.quantity,
                y.key,
                y.description
            }).Join(db.Warehouse, x=> x.id_warehouse, y=> y.id, (x, y) => new 
            {
                x.key,
                x.description,
                x.quantity,
                y.name
            }).Where(x=> x.name == cbWarehouse.Text);

            if (string.IsNullOrEmpty(tbSearchValue.Text))
            {
                data = data.Where(x => x.key.Contains(tbSearchValue.Text) ||
                                       x.description.Contains(tbSearchValue.Text));
            }

            foreach (var item in data.ToList())
            {
                dgvInventory.Rows.Add(item.key, item.description, item.quantity);
            }

        }
    }
}
