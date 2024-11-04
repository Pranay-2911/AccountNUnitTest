using AccountNUnitTest.Exceptions;
using AccountNUnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNUnitTest.Controller
{
    internal class AccountManager
    {
        List<Account> accounts = new List<Account>
        {
            new Account(101, "Pranay", "Axis", 5000),
            new Account(102, "Bhagwan", "BOB", 1000)
        };
        public double Default_Value = Account.DEFAULT_BALANCE;   

        public Account GetAccountByNumber(int number)
        {

            foreach (var account in accounts)
            {
                if (account.AccountNumber == number) return account;
            }
            throw new NoSuchAccountExistException("No Such Account Exist");
        }

        public void Deposit(Account account, double ammount)
        {
            if (ammount < 0)
            {
                throw new NegativeAmountException("Enter Positive amount for Deposit");
            }
            account.Balance += ammount;
        }

        public bool WithDraw(Account account, double amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException("Enter Positive amount For WithDraw");
            }
            if (account.Balance - amount < Default_Value)
            {
                throw new InsufficientBalanceException("Insufficient balance to withdraw the amount");
            }

            account.Balance -= amount;
            return true;
        }

        public void Transaction(Account account1, Account account2, double amount)
        {
            WithDraw(account1, amount);
            Deposit(account2, amount);
        }
    }
}
