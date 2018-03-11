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
        private static extern int SwapMouseButton(int swap);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            // 1 for left-handed
            // 0 for right-handed
            SwapMouseButton(1);
            // Udates the setting in the registry
            Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse").SetValue("SwapMouseButtons", 1);
            Application.Exit();
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            SwapMouseButton(0);
            Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse").SetValue("SwapMouseButtons", 0);
            Application.Exit();
        }

        private void btnRight_MouseOver(object sender, EventArgs e)
        {
            this.btnRight.BackColor = Color.Black;
            MessageBox.Show("Blabla");
        }

    }
}
