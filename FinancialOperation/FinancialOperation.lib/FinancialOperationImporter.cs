using FinancialOperation.lib.Models;
using System;
using System.Globalization;

namespace FinancialOperation.lib
{
    public static class FinancialOperationImporter
    {
        /// <summary>
        /// Transform multiple operation as string to a report
        /// </summary>
        /// <param name="operations">string as "[Operation][amount]\n". Possible operations are P, R, F and L. Amount is optional with L</param>
        /// <returns>string containing Balance, Total fees and Transferred to recipient</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string Report(string operations)
        {
            var operationList = operations.Split("\n");
            Account account = new Account();
            foreach (var operation in operationList)
            {
                if (string.IsNullOrEmpty(operation))
                    continue;

                switch (operation[0])
                {
                    case 'P':
                        account.Payment(decimal.Parse(operation.Substring(1), CultureInfo.InvariantCulture));
                        break;
                    case 'R':
                        account.Refund(decimal.Parse(operation.Substring(1), CultureInfo.InvariantCulture));
                        break;
                    case 'F':
                        account.TransactionFee(decimal.Parse(operation.Substring(1), CultureInfo.InvariantCulture));
                        break;
                    case 'L':
                        account.Payout();
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown operation {operation[0]}");
                }
            }

            return account.ToString();
        }
    }
}
