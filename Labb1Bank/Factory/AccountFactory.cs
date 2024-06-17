using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Bank.Factory
{
    // Factory Method: skapar olika typer av bankkonton
    public static class AccountFactory
    {
        public static Account CreateAccount(string accountType, decimal initialBalance)
        {
            switch (accountType)
            {
                case "Savings":
                    return new SavingsAccount(initialBalance);
                case "Current":
                    return new CurrentAccount(initialBalance);
                default:
                    throw new ArgumentException("Invalid account type");
            }
        }
    }

}
