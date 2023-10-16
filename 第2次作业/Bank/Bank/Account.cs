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
        public int Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public int Balance { get; set; }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
        public virtual void Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }        
        }
    }

    class CreditAccount : Account
    {
        public int CreditLimit { get; set; }
        override public void Withdraw(int amount)
        {
            if (Balance + CreditLimit >= amount)
            {
                Balance -= amount;
            }
        }
    }
}
