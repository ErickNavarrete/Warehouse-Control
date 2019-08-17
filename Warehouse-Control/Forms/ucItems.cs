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
    public partial class ucItems : UserControl
    {
        public ucItems()
        {
            InitializeComponent();
        }

        public void enable_textbox(Boolean enable) {
            tbName.Enabled = enable;
            tbDescription.Enabled = enable;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            enable_textbox(false);
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSearch.Visible = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            enable_textbox(true);
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnNew.Visible = false;
            btnSearch.Visible = false;
        }
    }
}
