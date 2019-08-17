using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Warehouse_Control.Forms
{
    public partial class ucInventoryPanel : UserControl
    {
        public scrDashBoard principal;

        public ucInventoryPanel()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            principal.UserControlConfig(2.3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal.UserControlConfig(2.1);
        }
    }
}
