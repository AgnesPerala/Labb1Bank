using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Labb1Bank.Factory;

namespace Labb1Bank
{
    // Singleton: säkerställer att endast en instans av ATM existerar
    public class ATM
    {
        private static ATM _instance;
        public List<Account> Accounts { get; private set; }

        private ATM()
        {
            Accounts = new List<Account>();
        }

        public static ATM Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ATM();
                }
                return _instance;
            }
        }

        public Account CreateAccount(string accountType, decimal initialBalance)
        {
            var account = AccountFactory.CreateAccount(accountType, initialBalance);
            Accounts.Add(account);
            return account;
        }

        public Account FindAccount(int accountNumber)
        {
            return Accounts.Find(account => account.AccountNumber == accountNumber);
        }
        
        public void TransferFunds(int fromAccountNumber, int toAccountNumber, decimal amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);

            if (fromAccount == null || toAccount == null)
            {
                throw new InvalidOperationException("One or both accounts not found.");
            }

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }

}
