using AccountNUnitTest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNUnitTest.Models
{
    internal class Account
    {
        public static double DEFAULT_BALANCE = 500;
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        public Account(int accoutNo, string name, string bankName, double balance)
        {
            AccountNumber = accoutNo;
            AccountHolderName = name;
            BankName = bankName;
            Balance = balance;
            if (balance < DEFAULT_BALANCE)
            {
                Balance = DEFAULT_BALANCE;
            }

        }

        

        
        public override string ToString()
        {
            return $"Account Number : {AccountNumber}\n" +
                $"Account Holder Name : {AccountHolderName} \n" +
                $"Bank Name : {BankName} \n" +
                $"Balance : {Balance}";
        }
    }
}
