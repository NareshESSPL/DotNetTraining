using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class InsufficientFundsException : Exception
    {
        public double CurrentBalance { get; }

        // Constructor with custom message and balance info
        public InsufficientFundsException(string message, double balance) : base(message)
        {
            CurrentBalance = balance;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Current Balance: {CurrentBalance:C}";
        }
    }

    class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Insufficient funds in the account.", Balance);
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawal successful! New balance: {Balance:C}");
        }
    }

    public class TestCustomException
    {
        public void Test()
        {
            BankAccount account = new BankAccount(500);

            try
            {
                account.Withdraw(100);  // Successful withdrawal
                account.Withdraw(600);  // This will trigger the custom exception
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
                Console.WriteLine($"Account Balance: {ex.CurrentBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }
    }

}
