using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;
using Moq;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorPatenteActualTest
    {
        private ValidadorPatenteActual validador;
        private Mock<ValidadorInterface<string, string>> validadorLongitud;
        private Mock<ValidadorInterface<bool, string>> validadorModulo;

        [TestInitialize()]
        public void Initialize()
        {
            validadorLongitud = new Mock<ValidadorInterface<string, string>>();
            validadorModulo = new Mock<ValidadorInterface<bool, string>>();
            validador = new ValidadorPatenteActual(validadorLongitud.Object, validadorModulo.Object);
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
        public void TestValidarPatenteErrorPatenteModerna()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("XXOO596");
            validadorModulo.Setup(v => v.Validar(It.IsAny<string>())).Returns(false);
            validador.Validar("XXOO59-6");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric1()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBZXX3");
            validador.Validar("BCBZXX-3");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorNumeric2()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBZ093");
            new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBZ09-3");
        }

        [TestMethod]
        public void TestValidarPatente3()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BBBB108");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BBBB10-8");
            string expected = "BBBB10" + Format.SEPARADOR_DV + "8";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente4()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBC109");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBC10-9");
            string expected = "BCBC10" + Format.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente5()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBP106");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBP10-6");
            string expected = "BCBP10" + Format.SEPARADOR_DV + "6";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente6()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBR109");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBR10-9");
            string expected = "BCBR10" + Format.SEPARADOR_DV + "9";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente7()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBS105");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBS10-5");
            string expected = "BCBS10" + Format.SEPARADOR_DV + "5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente8()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("BCBZ103");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("BCBZ10-3");
            string expected = "BCBZ10" + Format.SEPARADOR_DV + "3";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestValidarPatente9()
        {
            validadorLongitud.Setup(v => v.Validar(It.IsAny<string>())).Returns("ZZZZ99K");
            string result = new ValidadorPatenteActual(validadorLongitud.Object, new ValidadorModulo11()).Validar("ZZZZ99-K");
            string expected = "ZZZZ99" + Format.SEPARADOR_DV + "K";
            Assert.AreEqual(expected, result);
        }

    }
}
