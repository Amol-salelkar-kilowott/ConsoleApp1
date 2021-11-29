using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public int Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }
                return (int)balance;
            }




        }

        private static int accountNumberSeed = 987456321;

        private List<Transaction> allTransactions = new List<Transaction>();
        private object item;

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
