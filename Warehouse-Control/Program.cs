﻿using System;
using System.Windows.Forms;
using Warehouse_Control.Forms;

namespace Warehouse_Control
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new scrDashBoard());
        }
    }
}
