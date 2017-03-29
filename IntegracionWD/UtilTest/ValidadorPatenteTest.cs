using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorPatenteTest
    {
        private ValidadorPatente validador = new ValidadorPatente();

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
        public void TestValidarPatenteError()
        {
            validador.Validar("AA8159-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorCodigoPatenteAntigua()
        {
            validador.Validar("XX8159-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorPatenteModerna()
        {
            validador.Validar("XXOO59-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric1()
        {
            validador.Validar("BCBZXX-3");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric2()
        {
            validador.Validar("BCBZ09-3");
        }

        [TestMethod]
        public void TestValidarPatente1()
        {
            string result = validador.Validar("AA8159-5");
            string expected = "AA8159" + Format.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente2()
        {
            string result = validador.Validar("AA1111-2");
            string expected = "AA1111" + Format.SEPARADOR_DV + "2";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente3()
        {
            string result = validador.Validar("BBBB10-8");
            string expected = "BBBB10" + Format.SEPARADOR_DV + "8";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente4()
        {
            string result = validador.Validar("BCBC10-9");
            string expected = "BCBC10" + Format.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente5()
        {
            string result = validador.Validar("BCBP10-6");
            string expected = "BCBP10" + Format.SEPARADOR_DV + "6";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente6()
        {
            string result = validador.Validar("BCBR10-9");
            string expected = "BCBR10" + Format.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente7()
        {
            string result = validador.Validar("BCBS10-5");
            string expected = "BCBS10" + Format.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente8()
        {
            string result = validador.Validar("BCBZ10-3");
            string expected = "BCBZ10" + Format.SEPARADOR_DV + "3";
            Assert.AreEqual(expected, result);
        }

    }
}
