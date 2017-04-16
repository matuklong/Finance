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
    public class TransactionTest
    {

        public TransactionTest()
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
        ///A test for Altera_Movimento
        ///</summary>
        [TestMethod()]
        public void Altera_MovimentoTest()
        {
            Transaction target = new Transaction();
            Decimal _Valor = 256.26m;
            DateTime _Dt_Movimento = new DateTime(2009, 02, 05);
            string _Descricao = "Descricao 1";

            bool _Creditado = false;
            bool _Capitalizacao = false;

            target.ChangeTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false);

            Assert.AreEqual(_Valor, target.TransactionValue, "TransactionValue");
            Assert.AreEqual(_Dt_Movimento, target.TransactionDate, "TransactionDate");
            Assert.AreEqual(_Descricao, target.TransactionDescription, "TransactionDescription");
            Assert.AreEqual(_Creditado, target.AccountTransfer, "AccountTransfer");
            Assert.AreEqual(_Capitalizacao, target.Capitalization, "Capitalization");

        }

        /// <summary>
        ///A test for MOVIMENTO Constructor
        ///</summary>
        [TestMethod()]
        public void MOVIMENTOConstructorTest()
        {
            Account _Contas = new Account();
            Decimal _Valor = 256.26m;
            DateTime _Dt_Movimento = new DateTime(2009, 02, 05);
            string _Descricao = "Descricao 1";
            bool _Creditado = false;
            bool _Capitalizacao = false;

            Transaction target = new Transaction(_Contas, _Valor, _Dt_Movimento, _Descricao, _Capitalizacao, _Creditado, null, AccountTest.UserId);

            Assert.AreEqual(_Contas, target.Account, "Account1");
            Assert.AreEqual(_Valor, target.TransactionValue, "TransactionValue1");
            Assert.AreEqual(_Dt_Movimento, target.TransactionDate, "TransactionDate1");
            Assert.AreEqual(_Descricao, target.TransactionDescription, "TransactionDescription1");
            Assert.AreEqual(_Creditado, target.AccountTransfer, "AccountTransfer1");
            Assert.AreEqual(_Capitalizacao, target.Capitalization, "Capitalization1");

            _Creditado = true;
            _Capitalizacao = true;


            target = new Transaction(_Contas, _Valor, _Dt_Movimento, _Descricao, _Capitalizacao, _Creditado, null, AccountTest.UserId);

            Assert.AreEqual(_Contas, target.Account, "Account2");
            Assert.AreEqual(_Valor, target.TransactionValue, "TransactionValue2");
            Assert.AreEqual(_Dt_Movimento, target.TransactionDate, "TransactionDate2");
            Assert.AreEqual(_Descricao, target.TransactionDescription, "TransactionDescription2");
            Assert.AreEqual(_Creditado, target.AccountTransfer, "AccountTransfer2");
            Assert.AreEqual(_Capitalizacao, target.Capitalization, "Capitalization2");


            // Assert.Inconclusive("TODO: Implement code to verify target");
        }



        [TestMethod()]
        public void MOVIMENTOClassifica_Tipo_MovimentoTest()
        {            /*
            Account _Contas = new Account();
            Decimal _Valor = 256.26m;
            DateTime _Dt_Movimento = new DateTime(2009, 02, 05);
            string _Descricao = "Descricao 1";
            bool _Capitalizacao = false;
            TransactionType Tp_Movimento;

            Transaction target = new Transaction(_Contas, _Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false, Tp_Movimento, AccountTest.UserId);

            Tp_Movimento = target.Classifica_Tipo_Movimento(Db.IDENTIFICACAO_MOVIMENTO);
            Assert.IsNull(Tp_Movimento);

            _Descricao = "RSHOP-BRASILIA PO01/09";
            target.ChangeTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false);
            Tp_Movimento = target.Classifica_Tipo_Movimento(Db.IDENTIFICACAO_MOVIMENTO);
            Assert.AreEqual(2, Tp_Movimento.ID_TIPO_MOVIMENTO);

            _Descricao = "CH COMPENSADO26/85";
            _Valor = -400;
            target.ChangeTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false);
            Tp_Movimento = target.Classifica_Tipo_Movimento(Db.IDENTIFICACAO_MOVIMENTO);
            Assert.AreEqual(5, Tp_Movimento.ID_TIPO_MOVIMENTO);

            _Descricao = "CH COMPENSADO45/65";
            _Valor = 400.01m;
            target.ChangeTransaction(_Valor, _Dt_Movimento, _Descricao, _Capitalizacao, false);
            Tp_Movimento = target.Classifica_Tipo_Movimento(Db.IDENTIFICACAO_MOVIMENTO);
            Assert.IsNull(Tp_Movimento);


            ///////////////////////////////////////////////
            // Teste para classificar todos os movimentos//
            ///////////////////////////////////////////////

            List<MOVIMENTO> _Lista_Movimentos = Db.MOVIMENTO.Where(x => x.TIPO_MOVIMENTO == null && !x.TRANSFERENCIA_CONTA).ToList<MOVIMENTO>();
            //List<MOVIMENTO> _Lista_Movimentos = Db.MOVIMENTO.Where(x => x.TIPO_MOVIMENTO == null && x.DT_MOVIMENTO > new DateTime(2009, 07, 01)).ToList<MOVIMENTO>();
            foreach (MOVIMENTO m in _Lista_Movimentos)
            {
                Tp_Movimento = m.Classifica_Tipo_Movimento(Db.IDENTIFICACAO_MOVIMENTO);
                if (m.TIPO_MOVIMENTO != Tp_Movimento)
                {
                    m.TIPO_MOVIMENTO = Tp_Movimento;
                    Db.SaveChanges();
                }
            }

            */
        }
    }
}
