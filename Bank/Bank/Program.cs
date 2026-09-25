namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Yana", 100000);
            BankAccount account2 = new BankAccount("Alexander", 10);
            Console.WriteLine($"account {account.Balance} №{account.Number} {account.Owner}");
            Console.WriteLine($"account2 {account2.Balance} №{account2.Number} {account2.Owner}");

            account.MakeDeposit(2000000, DateTime.UtcNow, ":3");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(1000000, DateTime.UtcNow, ":(");
            Console.WriteLine(account.Balance);
            try
            {
                account2.MakeWithdrawal(1000, DateTime.UtcNow, ";;");

            }
            catch (InvalidOperationException e) { 
                Console.WriteLine(e.Message);
            }
        }
    }
}
