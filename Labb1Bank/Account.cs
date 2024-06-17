using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Bank
{
    public abstract class Account
    {
        private static int accountCounter = 1000;
        public int AccountNumber { get; private set; }
        public decimal Balance { get; protected set; }
        public List<string> TransactionHistory { get; private set; }

        public Account(decimal initialBalance)
        {
            AccountNumber = accountCounter++;
            Balance = initialBalance;
            TransactionHistory = new List<string>();
            AddTransaction("Account created with balance: " + initialBalance);
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            AddTransaction("Deposit: " + amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                AddTransaction("Withdraw: " + amount);
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds");
            }
        }
        private void AddTransaction(string transaction)
        {
            TransactionHistory.Add($"{DateTime.Now}: {transaction}");
        }

        public override string ToString()
        {
            return $"Account {AccountNumber}: Balance {Balance:C}";
        }
    }
}
