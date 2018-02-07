using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;  

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Account hhh frozen")]
        public void Debit_AccountIsFrozen_BalanceIsNotUpdates()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();

            try
            {
                // act  
                account.Debit(debitAmount);
            }
            finally
            {
                //assert
                Assert.AreEqual(beginningBalance, account.Balance, "Account updated when frozen");
            }
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }  
    }
}
