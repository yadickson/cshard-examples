using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;
using Moq;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorPatenteAntiguaTest
    {
        private ValidadorInterface<string, string> validador;
        private Mock<ValidadorInterface<string, string>> validadorLongitud;
        private Mock<ValidadorInterface<bool, string>> validadorModulo;

        [TestInitialize()]
        public void Initialize()
        {
            validadorLongitud = new Mock<ValidadorInterface<string, string>>();
            validadorModulo = new Mock<ValidadorInterface<bool, string>>();
            validador = new ValidadorPatenteAntigua(validadorLongitud.Object, validadorModulo.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidadorLongitudFalla()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Throws(new BusinessException("Validador error", "0001"));
            validador.Validar("placa");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteError()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("AA81596");
            validadorModulo.Setup(v => v.Validar(It.IsAny<string>())).Returns(false);
            validador.Validar("AA8159-6");
        }

        [TestMethod]
        public void TestValidarPatente1()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("AA81595");
            validadorModulo.Setup(v => v.Validar(It.IsAny<string>())).Returns(true);
            string result = validador.Validar("AA8159-5");
            string expected = "AA8159" + Format.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorReal()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("AA8156");
            new ValidadorPatenteAntigua(validadorLongitud.Object, new ValidadorModulo11()).Validar("AA8159-6");
        }

        [TestMethod]
        public void TestValidarPatenteOk()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("AA11112");
            string result = new ValidadorPatenteAntigua(validadorLongitud.Object, new ValidadorModulo11()).Validar("AA1111-2");
            string expected = "AA1111" + Format.SEPARADOR_DV + "2";
            Assert.AreEqual(expected, result);
        }

    }
}
