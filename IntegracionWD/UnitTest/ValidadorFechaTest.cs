using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;

namespace IntegracionWD.UnitTest
{
    [TestClass]
    public class ValidadorFechaTest
    {
        private ValidadorFecha validador = new ValidadorFecha();

        [TestMethod]
        public void TestFechaVacia()
        {
            bool result = validador.Validar("");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaMesAnioError1()
        {
            bool result = validador.Validar("012017");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError2()
        {
            bool result = validador.Validar("201713");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError3()
        {
            bool result = validador.Validar("201700");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError4()
        {
            bool result = validador.Validar("20170101");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError5()
        {
            bool result = validador.Validar("201701");
            Assert.IsTrue(result);
        }
    }
}
