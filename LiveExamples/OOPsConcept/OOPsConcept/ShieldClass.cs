using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
{
    using System;

   
        public class BankAccount
        {
            private decimal balance;

            
            public decimal Balance
            {
                get
                {
                   
                    return balance;
                }
            }

            
            public BankAccount(decimal initialBalance)
            {
                if (initialBalance < 0)
                {
                    throw new ArgumentException("Initial balance cannot be negative");
                }
                balance = initialBalance;
            }

           
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive");
                }
                balance += amount;
                Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");
            }

            
            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be positive");
                }

                if (amount > balance)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }

                balance -= amount;
                Console.WriteLine($"Withdrew: {amount}, New Balance: {balance}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                
                BankAccount account = new BankAccount(1000m);

                
                account.Deposit(500m);

               
                account.Withdraw(200m);

                
                try
                {
                    account.Withdraw(1500m);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                
                Console.WriteLine($"Current Balance: {account.Balance}");
            }
        }
    

}
