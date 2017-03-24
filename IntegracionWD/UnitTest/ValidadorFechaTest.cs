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
            bool result = validador.Validar("01201701");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError2()
        {
            bool result = validador.Validar("20171301");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError3()
        {
            bool result = validador.Validar("20170031");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError4()
        {
            bool result = validador.Validar("20170132");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesError5()
        {
            bool result = validador.Validar("20171301");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesEnero()
        {
            bool result = validador.Validar("20160131");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFechaAnioMesFebrero1()
        {
            bool result = validador.Validar("20170230");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesFebrero2()
        {
            bool result = validador.Validar("20170231");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesFebreroBisiesto()
        {
            bool result = validador.Validar("20160229");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFechaAnioMesFebreroNoBisiesto()
        {
            bool result = validador.Validar("20170229");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMesMarzo1()
        {
            bool result = validador.Validar("20160331");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFechaAnioMesMarzo2()
        {
            bool result = validador.Validar("20160330");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFechaAnioMesMarzoError()
        {
            bool result = validador.Validar("20160332");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFechaAnioMes()
        {
            bool result = validador.Validar("20160201");
            Assert.IsTrue(result);
        }
    }
}
