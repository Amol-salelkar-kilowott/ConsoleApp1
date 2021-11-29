using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Amol", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(3500, DateTime.Now, "Shoes");
            Console.WriteLine(account.Balance);

            account.MakeDeposit(5000, DateTime.Now, "Gpay");
            Console.WriteLine(account.Balance);


            Console.WriteLine(account.GetAccountHistory());
        }
    }
}