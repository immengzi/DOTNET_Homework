using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Bank
{
    internal class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public double Balance { get; set; }
        public Account(string id, string name, string password, int balance = 0)
        {
            this.Id = id;
            this.Name = name;
            this.password = password;
            this.Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            MessageBox.Show("存款成功！");
        }
        public virtual void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                MessageBox.Show("取款成功！");
            }
            else
            {
                MessageBox.Show("余额不足！");
            }
        }
    }

    class CreditAccount : Account
    {
        public int CreditLimit { get; set; }
        public CreditAccount(string id, string name, string password, int balance = 0, int creditLimit = 0) : base(id, name, password, balance)
        {
            this.CreditLimit = creditLimit;
        }        
        override public void Withdraw(double amount)
        {
            if (Balance + CreditLimit >= amount)
            {
                Balance -= amount;
                MessageBox.Show("取款成功！");
            }
            else
            {
                MessageBox.Show("余额不足！");
            }
        }
    }
}
