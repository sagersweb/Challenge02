using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroyFillerupChallenge02
{
    public class CashRegister
    {
        public Dictionary<double, int> GetChange(double amount, List<double> denominationArray)
        {
            if (amount >= 0)
            {
                var retval = new Dictionary<double, int>();

                double amountRemaining = amount;

                denominationArray.ForEach(denom =>
                {
                    int moneyCount = 0;
                    amountRemaining = CalculateDenomination(denom, amountRemaining, out moneyCount);
                    retval.Add(denom, moneyCount);
                });

                return retval; 
            }
            else
            {
                throw new Exception("Amount must be greater than zero.");
            }
        }

        private static double CalculateDenomination(double denomination, double amount, out int moneyCount)
        {
            moneyCount = (int)(amount / denomination);
            var newAmount = (amount - (moneyCount * denomination));
            return newAmount;
        }
    }
}
