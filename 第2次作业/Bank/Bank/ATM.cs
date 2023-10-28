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
            if (amount <= 0)
            {
                throw new ArgumentException("金额必须大于 0");
            }
            account.Deposit(amount);
            Balance += amount;
        }
        public void Withdraw(Account account, double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("金额必须大于 0");
            }
            if (Balance >= amount)
            {
                Random random = new Random();
                int badCashRate = random.Next(100);
                if (badCashRate <= 30)
                {
                    throw new BadCashException("钞票有问题");
                }
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
