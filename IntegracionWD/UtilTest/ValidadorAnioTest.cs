using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorAnioTest
    {
        private ValidadorAnio validador = new ValidadorAnio();

        [TestMethod]
        public void TestValidarAnioError1()
        {
            bool result = validador.Validar("abcd");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidarAnioError2()
        {
            bool result = validador.Validar("1234");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidarAnioError3()
        {
            bool result = validador.Validar("1899");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidarAnioError4()
        {
            bool result = validador.Validar("20000");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidarAnio1()
        {
            bool result = validador.Validar("1900");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidarAnio2()
        {
            bool result = validador.Validar("2999");
            Assert.IsTrue(result);
        }
    }
}
