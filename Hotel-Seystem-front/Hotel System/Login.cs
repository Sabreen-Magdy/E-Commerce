using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register secondForm = new Register();
            secondForm.ShowDialog();
            // Show the second form
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
