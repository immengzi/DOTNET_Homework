namespace Bank
{
    public partial class Bank_Console : Form
    {
        public Bank_Console()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("�˺Ų���Ϊ��");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("���벻��Ϊ��");
                return;
            }
            else if (!InfoHolder.Info.Contains(id))
            {
                MessageBox.Show("�˺Ų�����");
                return;
            }
            else if (InfoHolder.Info.Contains(id) && InfoHolder.Info.Contains(password))
            {
                MessageBox.Show("��¼�ɹ���");
                ATM_Console atm_Console = new ATM_Console();
                atm_Console.Show();
            }
            else
            {
                MessageBox.Show("�������");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("�˺Ų���Ϊ��");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("���벻��Ϊ��");
                return;
            }
            else if (!InfoHolder.Info.Contains(id))
            {
                MessageBox.Show("�˺Ų�����");
                return;
            }
            else if (InfoHolder.Info.Contains(id) && InfoHolder.Info.Contains(password))
            {
                MessageBox.Show("��¼�ɹ���");
                ATM_Console atm_Console = new ATM_Console();
                atm_Console.Show();
            }
            else
            {
                MessageBox.Show("�������");
                return;
            }
        }
    }
}