namespace Bank
{
    public partial class Bank_Console : Form
    {
        public Bank_Console()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}