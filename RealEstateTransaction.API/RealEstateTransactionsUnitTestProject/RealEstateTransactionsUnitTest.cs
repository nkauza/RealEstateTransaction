using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealEstateTransaction.Models;
using RealEstateTransaction.Service.Implementation;
using System;
using System.Collections.Generic;

namespace RealEstateTransactionsUnitTestProject
{
    [TestClass]
    public class RealEstateTransactionsUnitTest
    {
        [TestMethod]
        public void GetList_TestMethod()
        {
            List<Transaction> Transactions = new TransactionService().GetList();

            Assert.IsTrue(Transactions.Count > 0);
        }

        [TestMethod]
        public void UpdateList_TestMethod()
        {
            TransactionService _Service = new TransactionService();

            List<Transaction> Transactions = _Service.GetList();
            Transactions[0].street = "2090B Galeshewe Str";

            _Service.UpdateList(Transactions);
        }
    }
}
