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
    public partial class users : UserControl
    {
        public users()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnSave.Visible   = false;
            btnNew.Visible    = true;
            btnSearch.Visible = true;

        }


        public void enable_textbox(Boolean enable)
        {
            tbName.Enabled     = enable;
            tbPhone.Enabled    = enable;
            tbEmail.Enabled    = enable;
            tbUsername.Enabled = enable;
            tbPassword.Enabled = enable;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            enable_textbox(false);
            btnCancel.Visible = false;
            btnSave.Visible   = false;
            btnNew.Visible    = true;
            btnSearch.Visible = true;


        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            enable_textbox(true);
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnNew.Visible = false;
            btnSearch.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (verify_fields())
            {
                return;
            }


        }

        public Boolean verify_fields()
        {
            Boolean flag = false;

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Campo obligatorio", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Focus();
                flag = true;
            }

            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                MessageBox.Show("Campo obligatorio", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPhone.Focus();
                flag = true;

            }

            //Valida campo de correo electronico
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                
            }

            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                MessageBox.Show("Campo obligatorio", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                flag = true;

            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Campo obligatorio", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                flag = true;

            }

            return flag;

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
