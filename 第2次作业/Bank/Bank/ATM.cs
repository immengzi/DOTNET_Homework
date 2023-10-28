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
        public ATM(double Balance) { this.Balance = Balance; }
        public int Id { get; set; }
        public double Balance { get; set; }
        public void Deposit(Account account, double amount)
        {
            account.Deposit(amount);
            Balance += amount;
        }
        public void Withdraw(Account account, double amount)
        {
            if (Balance >= amount)
            {
                account.Withdraw(amount);
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("ATM 机余额不足！");
            }
        }
    }
}
