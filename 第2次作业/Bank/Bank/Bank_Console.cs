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
                MessageBox.Show("账号不可为空");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不可为空");
                return;
            }
            else if (!InfoHolder.Info.Contains(id))
            {
                MessageBox.Show("账号不存在");
                return;
            }
            else if (InfoHolder.Info.Contains(id) && InfoHolder.Info.Contains(password))
            {
                MessageBox.Show("登录成功！");
                ATM_Console atm_Console = new ATM_Console();
                atm_Console.Show();
            }
            else
            {
                MessageBox.Show("密码错误");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("账号不可为空");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不可为空");
                return;
            }
            else if (!InfoHolder.Info.Contains(id))
            {
                MessageBox.Show("账号不存在");
                return;
            }
            else if (InfoHolder.Info.Contains(id) && InfoHolder.Info.Contains(password))
            {
                MessageBox.Show("登录成功！");
                ATM_Console atm_Console = new ATM_Console();
                atm_Console.Show();
            }
            else
            {
                MessageBox.Show("密码错误");
                return;
            }
        }
    }
}