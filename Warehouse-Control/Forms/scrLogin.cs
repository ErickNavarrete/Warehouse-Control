using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Warehouse_Control.Forms;

namespace Warehouse_Control
{
    public partial class scrLogin : MaterialForm
    {
        public scrDashBoard scrDashBoard;
        private bool flag = true;
        public scrLogin()
        {
            InitializeComponent();
        }

        private void scrLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flag) return;
            Application.ExitThread();
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            scrDashBoard.id_user = 5;
            scrDashBoard.user_name = "PRUEBA";
            flag = false;
            this.Close();
        }
    }
}
