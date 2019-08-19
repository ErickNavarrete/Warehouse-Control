﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Warehouse_Control.Connection;
using Warehouse_Control.Forms;
using Warehouse_Control.Models;
using Warehouse_Control.Util;

namespace Warehouse_Control
{
    public partial class scrLogin : MaterialForm
    {
        public scrDashBoard scrDashBoard;
        private bool flag = true;
        tbValidators util;
        ConnectionDB conn;
        private Users user;

        public scrLogin()
        {
            InitializeComponent();
            util = new tbValidators();
            conn = new ConnectionDB();
        }

        private void scrLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flag) return;
            Application.ExitThread();
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            flag = false;

            if (getUser())
            {
                scrDashBoard.id_user = user.Id;
                scrDashBoard.user_name = user.user;
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña es incorrecta", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private Boolean getUser()
        {
            user = conn.Users.FirstOrDefault(x => x.user == tbUser.Text && x.password == tbPassword.Text);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
