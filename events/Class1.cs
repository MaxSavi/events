//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace events2
//{
//    public class BankAccount
//    {
//        public decimal Balance { get; private set; }
//        public event Action<decimal> BalanceChanged;

//        public void Deposit(decimal amount)
//        {
//            Balance += amount;
//            OnBalanceChanged(Balance);
//        }

//        public void Withdraw(decimal amount)
//        {
//            if (amount <= Balance)
//            {
//                Balance -= amount;
//                OnBalanceChanged(Balance);
//            }
//            else
//            {
//                Console.WriteLine("Insufficient funds.");
//            }
//        }

//        private void OnBalanceChanged(decimal newBalance)
//        {
//            BalanceChanged?.Invoke(newBalance);
//        }
//    }

//    public class Logger
//    {
//        public Logger(BankAccount account)
//        {
//            account.BalanceChanged += LogBalanceChange;
//        }

//        private void LogBalanceChange(decimal newBalance)
//        {
//            File.AppendAllText("balance_log.txt", $"{DateTime.Now}: Balance changed to {newBalance:C}\n");
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            BankAccount account = new BankAccount();
//            Logger logger = new Logger(account);

//            account.BalanceChanged += (newBalance) =>
//            {
//                Console.WriteLine($"Balance changed to {newBalance:C}");
//            };

//            account.Deposit(1000m);
//            account.Withdraw(500m);

//            // Check the 'balance_log.txt' file for the logged balance changes.

//            Console.ReadKey(); // Для ожидания нажатия клавиши перед завершением приложения
//        }
//    }
//}
