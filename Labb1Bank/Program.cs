using Labb1Bank.Strategy;

namespace Labb1Bank
{ 
    
    // Designmönster implementerade:
    // 1. Singleton
    // 2. Factory Method
    // 3. Strategy
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm = ATM.Instance;
            Account savingsAccount = atm.CreateAccount("Savings", 500);
            Account currentAccount = atm.CreateAccount("Current", 1000);

            Console.WriteLine(savingsAccount);
            Console.WriteLine(currentAccount);

            ITransactionStrategy deposit = new DepositStrategy();
            ITransactionStrategy withdraw = new WithdrawStrategy();

            deposit.Execute(savingsAccount, 200);
            withdraw.Execute(currentAccount, 300);

            // Demonstrerar överföring mellan konton
            atm.TransferFunds(savingsAccount.AccountNumber, currentAccount.AccountNumber, 100);
            Console.WriteLine("After Transfer:");
            Console.WriteLine(savingsAccount);
            Console.WriteLine(currentAccount);

            // Visar transaktionshistorik
            Console.WriteLine("Transaction History for Savings Account:");
            foreach (var transaction in savingsAccount.TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
