﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Warehouse_Control.Forms
{
    public partial class scrDashBoard : MaterialForm
    {
        public int id_user;
        public string user_name;

        public scrDashBoard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red900, //Color dialog 
                Primary.Red900, //Color control buttons
                Primary.Blue400,
                Accent.LightBlue200,
                TextShade.WHITE
            );

            ucInventoryPanel1.principal = this;
            scrLogin scrLogin = new scrLogin {scrDashBoard = this};
            scrLogin.ShowDialog();
            lbUserName.Text = user_name;
        }

        #region FUNCIONES

        private void ButtonsConfig(string kind)
        {
            switch (kind)
            {
                case "Inventory":
                    this.ucInventoryPanel1.Visible = true;
                    btnDistrict.Location = new Point(5, 314);
                    btnReports.Location = new Point(5, 343);
                    break;
                default:
                    this.ucInventoryPanel1.Visible = false;
                    btnDistrict.Location = new Point(5, 64);
                    btnReports.Location = new Point(5, 93);
                    break;
            }
        }

        public void UserControlConfig(double id)
        {
            users1.Visible = false;
            ucPrincipal1.Visible = false;
            ucInventory1.Visible = false;
            ucItems1.Visible = false;
            ucDistrict1.Visible = false;
            ucDeparture1.Visible = false;
            ucReports1.Visible = false;
            ucInputs1.Visible = false;
            ucWarehouse1.Visible = false;

            switch (id)
            {
                case 1:
                    users1.Visible = true;
                    users1.init_Datagrid();
                    users1.nameUserLogged = user_name;
                    break;
                case 2.1:
                    ucItems1.Visible = true;
                    break;
                case 2.2:
                    ucWarehouse1.Visible = true;
                    break;
                case 2.3:
                    ucInventory1.Visible = true;
                    break;
                case 2.4:
                    ucInputs1.Visible = true;
                    break;
                case 2.5:
                    ucDeparture1.Visible = true;
                    ucDeparture1.idUser = id_user;
                    break;
                case 3:
                    ucDistrict1.Visible = true;
                    ucDistrict1.fillDistrict();
                    break;
                case 4:
                    ucReports1.Visible = true;
                    ucReports1.fillComboBoxUser();
                    break;
                default:
                    ucPrincipal1.Visible = true;
                    break;
            }
        }
        #endregion

        #region BUTTONS
        private void btnInventory_Click(object sender, EventArgs e)
        {
            ButtonsConfig("Inventory");
            UserControlConfig(0);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ButtonsConfig("");
            UserControlConfig(1);
        }

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            ButtonsConfig("");
            UserControlConfig(3);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ButtonsConfig("");
            UserControlConfig(4);
        }
        #endregion

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            scrLogin scrLogin = new scrLogin {scrDashBoard = this};
            scrLogin.ShowDialog();
            lbUserName.Text = user_name;
        }
    }
}
