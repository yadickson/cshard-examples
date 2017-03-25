using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.UnitTest
{
    [TestClass]
    public class ValidadorRUTTest
    {
        private ValidadorRUT validador = new ValidadorRUT();

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputNull()
        {
            validador.Validar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputEmpty()
        {
            validador.Validar("");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputTrimEmpty()
        {
            validador.Validar("     ");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarRUTError()
        {
            validador.Validar("123.456-1");
        }

        [TestMethod]
        public void TestValidarRUT()
        {
            string result = validador.Validar("123.456-0");
            string expected = "123456" + Format.SEPARADOR_DV + "0";
            Assert.AreEqual(expected, result);
        }

    }
}
