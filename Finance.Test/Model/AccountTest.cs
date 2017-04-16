using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finance.Model.Model;

namespace Finance.Test.Model
{
    /// <summary>
    /// Summary description for AccountTest
    /// </summary>
    [TestClass]
    public class AccountTest
    {
        public const string UserId = "faf39f35-4e0a-4850-8461-a24077726114";

        public AccountTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        ///A test for NewAccount
        ///</summary>
        [TestMethod()]
        public void NewAccountTest()
        {
            string bankName = "033";
            string agency = "4521"; 
            string accountNumber = "048975-5"; 
            string description = "Conta Principal"; 
            Account target = new Account(bankName, agency, accountNumber, description, AccountTest.UserId);

            Assert.AreEqual(bankName, target.BankName, "BankName");
            Assert.AreEqual(agency, target.AccountAgency, "AccountAgency");
            Assert.AreEqual(accountNumber, target.AccountNumber, "AccountNumber");
            Assert.AreEqual(description, target.AccountDescription, "AccountDescription");
            Assert.AreEqual(0, target.BalanceValue, "BalanceValue");

        }

        /// <summary>
        ///A test for ChangeMoviment
        ///</summary>
        [TestMethod()]
        public void ChangeMovimentTest()
        {
            string bankName = "033";
            string agency = "4521";
            string accountNumber = "048975-5";
            string description = "Conta Principal";
            Account target = new Account(bankName, agency, accountNumber, description, AccountTest.UserId);


            Decimal value = 256.26m; 
            DateTime transactionDate = new DateTime(2009, 02, 05); 
            string TransactionDescription = "Descricao 1"; 
            bool AccountTransfer = false; 
            bool capitalization = false; 


            Transaction currentTransaction = target.NewTransaction(123.45m, new DateTime(2005, 10, 14), "TEste", false, false, null, AccountTest.UserId);
            currentTransaction = target.NewTransaction(12.45m, new DateTime(2005, 10, 14), "TEste", false, false, null, AccountTest.UserId);
            currentTransaction = target.NewTransaction(-98.95m, new DateTime(2005, 10, 14), "TEste", false, false, null, AccountTest.UserId);


            Transaction actualTransaction = target.ChangeMoviment(currentTransaction, value, transactionDate, TransactionDescription, capitalization, false);



            Assert.AreEqual(value, actualTransaction.TransactionValue, "TransactionValue");
            Assert.AreEqual(transactionDate, actualTransaction.TransactionDate, "TransactionDate");
            Assert.AreEqual(TransactionDescription, actualTransaction.TransactionDescription, "TransactionDescription");
            Assert.AreEqual(AccountTransfer, actualTransaction.AccountTransfer, "AccountTransfer");
            Assert.AreEqual(capitalization, actualTransaction.Capitalization, "Capitalization");

            Assert.AreEqual((123.45m + 12.45m - 98.95m) + 98.95m + 256.26m, target.BalanceValue);

        }

        /// <summary>
        ///A test for NewTransaction
        ///</summary>
        [TestMethod()]
        public void NewTransactionTest()
        {
            Account target = new Account();
            Decimal _Valor = 235.46m; 
            DateTime _Dt_Movimento = new DateTime(2009, 02, 05); 
            string _Descricao = "Descricao 1"; 
            bool _Capitalizacao = false; 

            Transaction actual;
            actual = target.NewTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false, null, AccountTest.UserId);
            Assert.AreEqual(_Valor, target.BalanceValue, "Validação 1");

            actual = target.NewTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false, null, AccountTest.UserId);
            Assert.AreEqual(_Valor * 2, target.BalanceValue, "Validação 2");


            actual = target.NewTransaction(-56.36m, _Dt_Movimento, _Descricao, _Capitalizacao, false, null, AccountTest.UserId);
            Assert.AreEqual((_Valor * 2) - 56.36m, target.BalanceValue, "Validação 3");

        }

        /// <summary>
        ///A test for RemoveTransaction
        ///</summary>
        [TestMethod()]
        public void RemoveTransaction()
        {
            Account target = new Account();
            Transaction currentTransaction = new Transaction();

            target.Transaction.Add(currentTransaction);
            target.Transaction.Add(new Transaction());
            Transaction actual = target.RemoveMoviment(currentTransaction);

            Assert.AreEqual(1, target.Transaction.Count);
        }
    }
}
