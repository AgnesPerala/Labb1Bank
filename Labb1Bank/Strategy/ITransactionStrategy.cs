using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1Bank.Strategy
{ 
    // Strategy: hanterar olika transaktionsstrategier
    public interface ITransactionStrategy
    {
        void Execute(Account account, decimal amount);
    }
}
