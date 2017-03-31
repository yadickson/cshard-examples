using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;
using Moq;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorPatenteTest
    {
        private ValidadorPatente validador;
        private Mock<ValidadorInterface<string, string>> validadorLongitud;
        private Mock<ValidadorInterface<string, string>> validadorAntiguo;
        private Mock<ValidadorInterface<string, string>> validadorActual;

        [TestInitialize()]
        public void Initialize()
        {
            validadorLongitud = new Mock<ValidadorInterface<string, string>>();
            validadorAntiguo = new Mock<ValidadorInterface<string, string>>();
            validadorActual = new Mock<ValidadorInterface<string, string>>();
            validador = new ValidadorPatente(validadorLongitud.Object, validadorAntiguo.Object, validadorActual.Object);
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
        public void TestPatenteAntiguaFalla()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BB00001");
            validadorAntiguo.Setup(v => v.Validar(It.IsAny<string>())).Throws(new BusinessException("Validador error", "0001"));

            validador.Validar("BB00001");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestPatenteActualFalla()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BBBB001");
            validadorActual.Setup(v => v.Validar(It.IsAny<string>())).Throws(new BusinessException("Validador error", "0001"));

            validador.Validar("BBBB001");
        }

        [TestMethod]
        public void TestPatenteAntiguaOk()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BB00001");
            validadorAntiguo.Setup(v => v.Validar(It.IsAny<string>())).Returns("123");

            string expected = validador.Validar("BB00001");
            Assert.AreEqual("123", expected);

            validadorLongitud.Verify(v => v.Validar(It.IsAny<string>()), Times.Once());
            validadorAntiguo.Verify(v => v.Validar(It.IsAny<string>()), Times.Once());
            validadorActual.Verify(v => v.Validar(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void TestPatenteActualOk()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BBBB001");
            validadorActual.Setup(v => v.Validar(It.IsAny<string>())).Returns("321");

            string expected = validador.Validar("BBBB001");
            Assert.AreEqual("321", expected);

            validadorLongitud.Verify(v => v.Validar(It.IsAny<string>()), Times.Once());
            validadorAntiguo.Verify(v => v.Validar(It.IsAny<string>()), Times.Never());
            validadorActual.Verify(v => v.Validar(It.IsAny<string>()), Times.Once());
        }

    }
}
