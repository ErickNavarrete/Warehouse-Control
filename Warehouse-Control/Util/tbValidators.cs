using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Warehouse_Control.Util
{
    public class tbValidators
    {

        public Boolean emailValidator(TextBox text)
        {
            Boolean flag = true;
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (!requieredTextValidator(text, false))
            {
                flag = false;
            }

            if (Regex.IsMatch(text.Text, expresion))
            {
                if (Regex.Replace(text.Text, expresion, String.Empty).Length != 0)
                {
                    flag = false;
                }
            }
            else
            {
                MessageBox.Show("No es un email valido", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }
            return flag;
        }

        public Boolean requieredTextValidator(TextBox text, Boolean message = true)
        {
            Boolean flag = true;

            if (string.IsNullOrEmpty(text.Text))
            {
                if (message)
                {
                    MessageBox.Show("Campo obligatorio", text.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text.Focus();
                }
                flag = false;
            }

            return flag;
        }

        public Boolean usernameValidator(TextBox text)
        {
            Boolean flag = true;
            String expresion = "^[A-Za-z][A-Za-z0-9]*$";

            if (!requieredTextValidator(text, false))
            {
                flag = false;
            }

            if (Regex.IsMatch(text.Text, expresion))
            {
                if (Regex.Replace(text.Text, expresion, String.Empty).Length != 0)
                {
                    flag = false;
                }
            }
            else
            {
                MessageBox.Show("No es nombre de usuario valido, solo se permite número y letras sin espacios", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }
            return flag;
        }

        public bool cbRequiredValidator(ComboBox comboBox) {
            bool flag = true;
            if (string.IsNullOrEmpty(comboBox.Text)) {
                flag = false;
                MessageBox.Show("Campo obligatorio", comboBox.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox.Focus();
            }

            return flag;
        }


        public void control_enable_all_textbox(UserControl form, Boolean enable, Boolean clean = false)
        {
            foreach (Control control in form.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control controlGroup in ((GroupBox)control).Controls)
                    {
                        if (controlGroup is TextBox)
                        {
                            ((TextBox)controlGroup).Enabled = enable;

                            if (clean)
                            {
                                ((TextBox)controlGroup).Text = string.Empty;
                            }
                        }
                    }
                }

                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = enable;

                    if (clean)
                    {
                        ((TextBox)control).Text = string.Empty;
                    }
                }
                
            }
        }

        public void control_enable_all_buttons(UserControl form, Boolean enable)
        {
            form.Controls
                .OfType<Button>()
                .ToList()
                .ForEach(button => {
                    button.Enabled = enable;
                });
        }
    }
}
