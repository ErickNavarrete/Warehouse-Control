using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Control.Forms
{
    public partial class ucWarehouse : UserControl
    {
        public ucWarehouse()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            enable_textbox(false);
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
        }

        public void enable_textbox(Boolean enable)
        {
            tbAddress.Enabled  = enable;
            tbName.Enabled     = enable;
            cbDistrict.Enabled = enable;
        }
    }
}
