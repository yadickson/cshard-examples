using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;

namespace IntegracionWD.UnitTest
{
    [TestClass]
    public class ValidadorModulo11Test
    {
        private ValidadorModulo11 validador = new ValidadorModulo11();

        [TestMethod]
        public void TestObtenerDV1()
        {
            string result = validador.GetDigitoVerificador("123456");
            string expected = "0";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObtenerDV2()
        {
            string result = validador.GetDigitoVerificador("11111111");
            string expected = "1";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObtenerDV3()
        {
            string result = validador.GetDigitoVerificador("97036000");
            string expected = "K";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestObtenerDV4()
        {
            string result = validador.GetDigitoVerificador("18159");
            string expected = "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidar_DV_Incorrecto()
        {
            Assert.IsFalse(validador.Validar("123456", "K"));
        }

        [TestMethod]
        public void TestValidar_DV_Correcto()
        {
            Assert.IsTrue(validador.Validar("123456", "0"));
        }

        [TestMethod]
        public void TestValidar_DV_Correcto2()
        {
            Assert.IsTrue(validador.Validar("121210", "9"));
        }

        [TestMethod]
        public void TestValidar_DV_Correcto3()
        {
            Assert.IsTrue(validador.Validar("121310", "5"));
        }

    }
}
