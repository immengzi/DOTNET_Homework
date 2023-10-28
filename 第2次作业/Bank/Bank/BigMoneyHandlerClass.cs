using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BigMoneyHandlerClass
    {
        private BigMoney bigMoney;
        public BigMoneyHandlerClass(BigMoney bigMoney)
        {
            this.bigMoney = bigMoney;
            bigMoney.BigMoneyFetched += new BigMoney.BigMoneyHandler(Warn);
        }

        void Warn(object sender, BigMoneyArgs e)
        {
            MessageBox.Show("Big money is being fetched");
        }
    }
}
