using System.Drawing.Drawing2D;

namespace Hotel_Management_System
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
        }

       
    }
}
