using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class ATM
    {
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
}
