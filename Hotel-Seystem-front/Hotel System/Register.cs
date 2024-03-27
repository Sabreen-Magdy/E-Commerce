namespace Hotel_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login secondForm = new Login();
            secondForm.ShowDialog();
            // Show the second form
            this.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login secondForm = new Login();
            secondForm.ShowDialog();
            // Show the second form
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
