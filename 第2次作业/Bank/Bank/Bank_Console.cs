using System.Xml.Linq;

namespace Bank
{
    public partial class Bank_Console : Form
    {
        internal static List<Account> accounts = new List<Account>();

        public static bool IsAccountExist(string id)
        {
            return accounts.Any(account => account.Id == id);
        }

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
            Account account = accounts.Find(a => a.Id == id);
            string _password; // id 对应的账号的密码
            if (account == null)
            {
                MessageBox.Show("账号不存在");
                return;
            }
            else
            {
                _password = account.password;
                if (_password == password)
                {
                    MessageBox.Show("登录成功！");
                    ATM_Console atm_Console = new ATM_Console(account);
                    atm_Console.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string password = textBox3.Text;
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
            Account account = accounts.Find(a => a.Id == id);
            string _password; // id 对应的账号的密码
            if (account == null)
            {
                MessageBox.Show("账号不存在");
                return;
            }
            else
            {
                _password = account.password;
                if (_password == password)
                {
                    MessageBox.Show("登录成功！");
                    ATM_Console atm_Console = new ATM_Console(account);
                    atm_Console.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    return;
                }
            }
        }
    }
}