using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_ShouldSetPropperValues()
        {
            string expectedName = "Gosho";
            decimal expectedBalance = 340.34m;
            var bankAccount = new BankAccount(expectedName, expectedBalance);

            Assert.AreEqual(expectedName, bankAccount.Name);
            Assert.AreEqual(expectedBalance, bankAccount.Balance);
        }

        [Test]
        [TestCase("1", 3450.34)]
        [TestCase("StringWithLenghtMoreThan25Symbols", 3450.34)]
        public void Constructor_ShoulThrowArgumentException_InvalidNameLength(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [Test]
        [TestCase("Gosho", -1)]
        [TestCase("Pesho", -5)]
        public void Constructor_ShouldThrowArgumentException_InvalidBalance(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Deposit_ShouldThrowInvalidOperationException_InvalidAmount(decimal amount)
        {
            string expectedName = "Gosho";
            decimal expectedBalance = 340.34m;

            var bankAccount = new BankAccount(expectedName, expectedBalance);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        [Test]
        public void Deposit_ShouldIncreaseBalance_ValidAmount()
        {
            string name  = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            bankAccount.Deposit(120);

            var expectedAmount = 460.34m;
            var actualAmount = bankAccount.Balance;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void Whithdraw_ShoudThrowInvalidOperationException_InvalidAmount()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var invalidAmount = -1;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
        }

        [Test]
        public void Whithdraw_ShoudThrowInvalidOperationException_InsufficientFunds()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var insufficientFunds = 500;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(insufficientFunds));
        }

        [Test]
        public void Whithdraw_ShoudDecreaseBalanceCorrectly()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var validAmount = 40.34m;

            bankAccount.Withdraw(validAmount);

            var expected = 300;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }
    }
}

//Ctor?set proper values
//Invalid name min length/max length
//Invalid balance
//Deposit invalid amounts
//deposit increases?
//withdraw invalid amount 0
//insufficient funds
//balance has decreased
//correct balance