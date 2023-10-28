using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BigMoney
    {
        public delegate void BigMoneyHandler(object sender, BigMoneyArgs bm);
        public event BigMoneyHandler BigMoneyFetched;
        public void ActivateBigMoney(Account account, double amount)
        {
            BigMoneyArgs bigMoneyArgs = new BigMoneyArgs(account, amount);
            BigMoneyFetched(this, bigMoneyArgs);
        }
    }
}
