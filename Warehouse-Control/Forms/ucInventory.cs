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

        }
    }
}
