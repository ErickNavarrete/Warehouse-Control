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

            if (!requieredTextValidator(text))
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
            return flag;
        }

        public Boolean requieredTextValidator(TextBox text)
        {
            Boolean flag = true;

            if (string.IsNullOrEmpty(text.Text))
            {
                MessageBox.Show("Campo obligatorio", text.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                text.Focus();
                flag = false;
            }

            return flag;
        }

        public Boolean usernameValidator(TextBox text)
        {
            Boolean flag = true;
            String expresion = "^[A-Za-z][A-Za-z0-9]*$";

            if (!requieredTextValidator(text))
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
            return flag;
        }
    }
}
