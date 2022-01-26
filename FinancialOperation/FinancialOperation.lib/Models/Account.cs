using System;

namespace FinancialOperation.lib.Models
{
    internal class Account
    {
        private decimal _balance = 0;
        private decimal _fees = 0;
        private decimal _transferredToRecipient = 0;
        public Account()
        {
        }

        public void Payment(decimal amount)
        {
            // TODO : check wanted behavior on negative amount
            _balance += amount;
        }
        public void Refund(decimal amount)
        {
            // TODO : check wanted behavior on negative amount
            _balance -= amount;
        }
        public void TransactionFee(decimal amount)
        {
            // TODO : check wanted behavior on negative amount
            _balance -= amount;
            _fees += amount;
        }
        public void Payout()
        {
            _transferredToRecipient = _balance;
            _balance = 0;
        }

        public override string ToString() {
            return $"Balance: {_balance} euros{Environment.NewLine}" +
                $"Total fees: {_fees} euros{Environment.NewLine}" +
                $"Transferred to recipient: {_transferredToRecipient} euros";
        }
    }
}