using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Bank.Strategy
{
    public class DepositStrategy : ITransactionStrategy
    {
        public void Execute(Account account, decimal amount)
        {
            account.Deposit(amount);
        }
    }
}
