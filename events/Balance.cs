public class BankAccount
{
    public decimal Balance { get; private set; }
    public event Action<decimal> BalChanged;

    public void Deposit(decimal amount)
    {
        Balance += amount;
        OnBalanceChanged(Balance);
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            OnBalanceChanged(Balance);
        }
        else
        {
            Console.WriteLine("На балансе не хватает средств для выполнения функции Withdraw");
        }
    }

    private void OnBalanceChanged(decimal newBalance)
    {
        BalChanged?.Invoke(newBalance);
    }
}

public class Logger
{
    public Logger(BankAccount account)
    {
        account.BalChanged += LogBalanceChange;
    }

    private void LogBalanceChange(decimal newBalance)
    {
        File.AppendAllText("balance_log.txt", $"{DateTime.Now}: Balance changed to {newBalance:C}\n");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        Logger logger = new Logger(account);

        account.BalChanged += (newBalance) =>
        {
            Console.WriteLine($"Баланс изменен на {newBalance:C}");
        };

        account.Deposit(1000);
        account.Withdraw(500000);

        Console.ReadKey();
    }
}
