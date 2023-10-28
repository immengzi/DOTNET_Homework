using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BigMoneyArgs : EventArgs
    {
        public BigMoneyArgs(Account account, double amount)
        {
            this.account = account;
            this.amount = amount;
        }
        private Account account;
        private double amount;
    }
}
