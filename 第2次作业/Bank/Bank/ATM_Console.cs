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

namespace Bank
{
    public partial class ATM_Console : Form
    {
        ATM atm = new ATM(500);
        private Account account;

        internal ATM_Console(Account _account)
        {
            InitializeComponent();
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
            if (radioButton2.Checked) { atm.Withdraw(account, amount); }
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            label1.Text = atm.Balance.ToString();
            label5.Text = account.Balance.ToString();
        }
    }
}
