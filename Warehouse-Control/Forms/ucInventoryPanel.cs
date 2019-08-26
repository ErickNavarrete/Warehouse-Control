﻿using System;
using System.Windows.Forms;

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

        private void btnDepartures_Click(object sender, EventArgs e)
        {
            principal.UserControlConfig(2.5);
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            principal.UserControlConfig(2.2);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            principal.UserControlConfig(2.4);
        }
    }
}
