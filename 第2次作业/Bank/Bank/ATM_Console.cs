using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank
{
    public partial class ATM_Console : Form
    {
        ATM atm = new ATM(500);
        private Account account;
        private BigMoney myBigMoney;
        private BigMoneyHandlerClass myBigMoneyHandler;

        internal ATM_Console(Account _account)
        {
            InitializeComponent();
            myBigMoney = new BigMoney();
            myBigMoneyHandler = new BigMoneyHandlerClass(myBigMoney);

            radioButton1.Checked = true;
            this.account = _account;
            label2.Text = "欢迎您，" + account.Name;
            label1.DataBindings.Add(new Binding("Text", atm, "Balance"));
            label5.DataBindings.Add(new Binding("Text", account, "Balance"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(textBox1.Text);
            if (radioButton1.Checked) { atm.Deposit(account, amount); }
            else
            {
                if (amount > 10000)
                {
                    myBigMoney.ActivateBigMoney(account, amount);
                }
                try
                {
                    atm.Withdraw(account, amount);
                }
                catch (BadCashException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            textBox1.Text = "";
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            label1.Text = atm.Balance.ToString();
            label5.Text = account.Balance.ToString();
        }
    }
}
