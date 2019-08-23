using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse_Control.Util;
using Warehouse_Control.Connection;
using Warehouse_Control.Models;

namespace Warehouse_Control.Forms
{
    public partial class users : UserControl
    {
        tbValidators util;
        ConnectionDB conn;
        private int idUse = 0;
        private bool editable = false;
        public String nameUserLogged = "";

        public users()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible   = false;
            btnNew.Visible    = true;
            btnSearch.Visible = true;
            util = new tbValidators();
            util.control_enable_all_textbox(this, false);
            conn = new ConnectionDB();
        }

        private void define_active_buttons(Boolean enable)
        {
            btnCancel.Visible = !enable;
            btnSave.Visible = !enable;
            btnNew.Visible = enable;
            btnSearch.Visible = enable;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            util.control_enable_all_textbox(this,false, true);
            define_active_buttons(true);
            editable = false;
            idUse = 0;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            util.control_enable_all_textbox(this,true);
            define_active_buttons(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!verify_fields(true))
            {
                return;
            }

            if (!chkMailAndUser())
            {
                return;
            }

            if (tbPassword.Text != tbPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Control Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                return;
            }

            if (editable)
            {
                Users users = conn.Users.FirstOrDefault(x => x.Id == idUse);
                users.name  = tbName.Text;
                users.user  = tbUsername.Text;
                users.mail  = tbEmail.Text;
                users.phone = tbPhone.Text;
                if (nameUserLogged == "Admin")
                {
                    users.password = tbPassword.Text;
                }
                conn.Entry(users).State = EntityState.Modified;
                conn.SaveChanges();
                MessageBox.Show("Registro actualizado con éxito", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editable = false;
                idUse    = 0;
            }
            else
            {

                var user = new Users
                {
                    name = tbName.Text,
                    password = tbPassword.Text,
                    user = tbUsername.Text,
                    mail = tbEmail.Text,
                    phone = tbPhone.Text
                };

                conn.Users.Add(user);
                conn.SaveChanges();
                MessageBox.Show("Registro con éxito", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            util.control_enable_all_textbox(this, false, true);
            define_active_buttons(true);
            init_Datagrid();
        }

        public Boolean verify_fields(bool password = false)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control controlGroup in ((GroupBox)control).Controls)
                    {
                        if (controlGroup is TextBox)
                        {
                            if (password)
                            {
                                if ( (((TextBox)controlGroup)).Name == "tbPassword")
                                {
                                    continue;
                                }
                            }
                            if (!util.requieredTextValidator(((TextBox)controlGroup)))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            if (!util.emailValidator(tbEmail))
            {
                return false;
            }
            if (!util.usernameValidator(tbUsername))
            {
                return false;
            }

            if (!util.requieredTextValidator(tbPasswordConfirm))
            {
                return false;
            }
            return true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (util.requieredTextValidator(tbSearch.TextBox))
            {
                init_Datagrid(tbSearch.Text);
            }
        }

        public void init_Datagrid(String query = null)
        {
            dgvUsers.Rows.Clear();

            if (!string.IsNullOrEmpty(query))
            {
               var  data = conn.Users.Where(x => x.name.Contains(query) ||
                                             x.mail.Contains(query) ||
                                             x.phone.Contains(query) ||
                                             x.user.Contains(query)
                                        );

                foreach (var item in data)
                {
                    dgvUsers.Rows.Add(
                            item.Id,
                            item.name,
                            item.phone,
                            item.mail,
                            item.user
                        );
                }
            }
            else
            {
                var data = conn.Users.ToList();

                foreach (var item in data)
                {
                    dgvUsers.Rows.Add(
                            item.Id,
                            item.name,
                            item.phone,
                            item.mail,
                            item.user
                        );
                }
            }
        }

        private void DgvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int index    = dgvUsers.CurrentRow.Index;
                idUse        = (int) dgvUsers.Rows[index].Cells[0].Value;
                tbName.Text  = (string) dgvUsers.Rows[index].Cells[1].Value;
                tbPhone.Text = (string) dgvUsers.Rows[index].Cells[2].Value;
                tbEmail.Text = (string) dgvUsers.Rows[index].Cells[3].Value;
                tbUsername.Text  = (string) dgvUsers.Rows[index].Cells[4].Value;
                util.control_enable_all_textbox(this, true);

                if (nameUserLogged == "Admin")
                {
                    tbPassword.Text = getPassword();
                    tbPasswordConfirm.Text = getPassword();
                }
                else
                {
                    tbPassword.Enabled = false;
                    tbPasswordConfirm.Enabled = false;
                }

                define_active_buttons(false);
                editable = true;
            }
        }

        private String getPassword()
        {
            Users users = conn.Users.FirstOrDefault(x => x.Id == idUse);
            return users.password;
        }

        private Boolean chkMailAndUser()
        {
            Users users = conn.Users.FirstOrDefault( x => x.mail == tbEmail.Text || 
                                                       x.user == tbUsername.Text );
            
            if (users != null)
            {
                String campo = "";
                if (users.mail == tbEmail.Text)
                {
                    campo = "Correo electronico";
                    tbEmail.Focus();
                }
                else
                {
                    campo = "Usuario";
                    tbUsername.Focus();
                }

                MessageBox.Show("El campo ya existe en base de datos", campo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            tbPassword.PasswordChar = '\0';
        }

        private void pPasswordConfirm_MouseMove(object sender, MouseEventArgs e)
        {
            tbPasswordConfirm.PasswordChar = '\0';
        }

        private void pPasswordConfirm_MouseLeave(object sender, EventArgs e)
        {
            tbPasswordConfirm.PasswordChar = '*';
        }

        private void pPassword_MouseLeave(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }
    }
}
