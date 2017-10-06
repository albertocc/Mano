using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int SwapMouseButton(int bSwap);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRight_MouseDown(object sender, EventArgs e)
        {
            // Cambia
            SwapMouseButton(0);
            // Lo guarda en el registro
            Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse").SetValue("SwapMouseButtons", 0);
            // Muestra el actual en el registro (no cambia hasta cerrar sesion)
            MessageBox.Show(SystemInformation.MouseButtonsSwapped ? "1" : "0", "Right", MessageBoxButtons.OK);
            Application.Exit();
        }

        private void btnLeft_MouseDown(object sender, EventArgs e)
        {
            SwapMouseButton(1);
            // 1 es Left. 0 es Right.
            Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse").SetValue("SwapMouseButtons", 1);
            MessageBox.Show(SystemInformation.MouseButtonsSwapped ? "1" : "0", "Left", MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}
