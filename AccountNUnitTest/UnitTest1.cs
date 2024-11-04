using AccountNUnitTest.Controller;
using AccountNUnitTest.Exceptions;
using AccountNUnitTest.Models;
using System.Security.Principal;

namespace AccountNUnitTest
{
    public class Tests
    {
        AccountManager _accountManager;
        [SetUp]
        public void Setup()
        {
            _accountManager = new AccountManager();
        }

        [Test]
        [TestCase(101, 500)]
        public void DepositWithValidAmount_WhichIncreaseTheBalance(int number, double depositAmount)
        {
            // Arrange
            var account = _accountManager.GetAccountByNumber(number);
            double initialBalance = account.Balance;

            // Act
            _accountManager.Deposit(account,depositAmount);

            // Assert
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }

        [Test]
        [TestCase(101, -500)]
        public void DepositWithInvalidAmount_WhichGivesException(int number, double depositAmount)
        {
            var account = _accountManager.GetAccountByNumber(number);

            var exception = Assert.Throws<NegativeAmountException>(() => _accountManager.Deposit(account,depositAmount));
            Assert.AreEqual("Enter Positive amount for Deposit", exception.Message);
        }
        //1500
        [Test]
        [TestCase(101, 500)]
        public void WithdrawWithValidAmount_WhichReducesTheBalance(int number, double withdrawBalance)
        {
            var account = _accountManager.GetAccountByNumber(number);
            double initialBalance = account.Balance;
            
            bool check = _accountManager.WithDraw(account, withdrawBalance);

            Assert.AreEqual(initialBalance - withdrawBalance, account.Balance);
        }

        [Test]
        [TestCase(101, -500)]
        public void WithdrawWithInvalidAmount_WhichGivesException(int number, double withdrawAmount)
        {
            var account = _accountManager.GetAccountByNumber(number);

            var exception = Assert.Throws<NegativeAmountException>(() => _accountManager.WithDraw(account,withdrawAmount));
            Assert.AreEqual("Enter Positive amount For WithDraw", exception.Message);
        }

        [Test]
        [TestCase(102, 1000)]
        public void WithdrawWithInsufficientBalance(int number, double withdrawAmount)
        {


            // Act & Assert
            var account = _accountManager.GetAccountByNumber(number);
            var exception = Assert.Throws<InsufficientBalanceException>(() => _accountManager.WithDraw(account,withdrawAmount));
            Assert.AreEqual("Insufficient balance to withdraw the amount", exception.Message);


        }
        [Test]
        [TestCase(101,102,300)]
        public void DoesTransactionWithTwoAccount(int number1, int  number2, double amount)
        {
            var account1 = _accountManager.GetAccountByNumber(number1);
            double initialAccount1 = account1.Balance;
            var account2 = _accountManager.GetAccountByNumber(number2);
            double initialAccount2 = account2.Balance;

            _accountManager.Transaction(account1, account2, amount);

            Assert.AreEqual(account1.Balance, initialAccount1 - 300);
            Assert.AreEqual(account2.Balance, initialAccount2 + 300);
        }

        [Test]
        [TestCase(105)]
        public void CheckAccountExist(int number)
        {
            var exception = Assert.Throws<NoSuchAccountExistException>(() => _accountManager.GetAccountByNumber(number));
            Assert.AreEqual("No Such Account Exist", exception.Message);
        }



    }
}