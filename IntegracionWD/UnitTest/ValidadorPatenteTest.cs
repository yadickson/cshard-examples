﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.UnitTest
{
    [TestClass]
    public class ValidadorPatenteTest : ValidadorPatente
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputNull()
        {
            Validar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputEmpty()
        {
            Validar("");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputTrimEmpty()
        {
            Validar("     ");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteError()
        {
            Validar("AA8159-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorCodigoPatenteAntigua()
        {
            Validar("XX8159-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorPatenteModerna()
        {
            Validar("XXOO59-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric1()
        {
            Validar("BCBZXX-3");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric2()
        {
            Validar("BCBZ09-3");
        }

        [TestMethod]
        public void TestValidarPatente1()
        {
            string result = Validar("AA8159-5");
            string expected = "AA8159" + Messages.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente2()
        {
            string result = Validar("AA1111-2");
            string expected = "AA1111" + Messages.SEPARADOR_DV + "2";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente3()
        {
            string result = Validar("BBBB10-8");
            string expected = "BBBB10" + Messages.SEPARADOR_DV + "8";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente4()
        {
            string result = Validar("BCBC10-9");
            string expected = "BCBC10" + Messages.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente5()
        {
            string result = Validar("BCBP10-6");
            string expected = "BCBP10" + Messages.SEPARADOR_DV + "6";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente6()
        {
            string result = Validar("BCBR10-9");
            string expected = "BCBR10" + Messages.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente7()
        {
            string result = Validar("BCBS10-5");
            string expected = "BCBS10" + Messages.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        } 

        [TestMethod]
        public void TestValidarPatente8()
        {
            string result = Validar("BCBZ10-3");
            string expected = "BCBZ10" + Messages.SEPARADOR_DV + "3";
            Assert.AreEqual(expected, result);
        }
        
    }
}
