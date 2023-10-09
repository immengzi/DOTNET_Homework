using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bank
{
    class ATM
    {
        BigMoneyArgs bigMoneyArgs = new BigMoneyArgs();
        // bigMoneyArgs.Handle();

        public int Id { get; set; }
        public int Balance { get; set; }
        public void Deposit(Account account,int amount)
        {
            account.Deposit(amount);
            Balance += amount;
        }
        public void Withdraw(Account account, int amount)
        {
            if (Balance >= amount)
            {
                account.Withdraw(amount);
                Balance -= amount;
            }
        }
    }
    class BigMoneyArgs
    {
        private Account account { get; set; }
        private int amount { get; set; }

        public event EventHandler BigMoneyFetched;
        internal void Handle()
        {
            EventArgs e = new EventArgs();
            BigMoneyFetched += Warn;
            BigMoneyFetched(amount, e);
        }
        void Warn(object sender, EventArgs e)
        {
            Console.WriteLine($"尊敬的 {account}，你要取走的数额大于 10000 元: {sender}");
        }
    }
}
