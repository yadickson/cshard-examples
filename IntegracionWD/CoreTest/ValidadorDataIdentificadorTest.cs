using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Core;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using Moq;

namespace IntegracionWD.CoreTest
{
    [TestClass]
    public class ValidadorDataIdentificadorTest
    {
        private ValidadorDataInterface<DataIdentificador> validador;
        private Mock<ValidadorInterface<DataIdentificador, DataIdentificador>> validadorIdentificador;

        [TestInitialize()]
        public void Initialize()
        {
            validadorIdentificador = new Mock<ValidadorInterface<DataIdentificador, DataIdentificador>>();
            validador = new ValidadorDataIdentificadorImpl(validadorIdentificador.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidadorFalla()
        {
            validadorIdentificador.Setup(v => v.Validar(It.IsAny<DataIdentificador>())).Throws(new BusinessException("Validador error", "0001"));
            validador.Validar(new DataIdentificador());
        }

        [TestMethod]
        public void TestValidadorCorrecto()
        {
            validadorIdentificador.Setup(v => v.Validar(It.IsAny<DataIdentificador>())).Verifiable();
            validador.Validar(new DataIdentificador());
        }
    }
}
