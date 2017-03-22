using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.UnitTest
{
    [TestClass]
    public class ValidadorRUTTest : ValidadorRUT
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
        public void TestValidarRUTError()
        {
            Validar("123.456-1");
        }

        [TestMethod]
        public void TestValidarRUT()
        {
            string result = Validar("123.456-0");
            string expected = "123456" + Messages.SEPARADOR_DV + "0";
            Assert.AreEqual(expected, result);
        }

    }
}
