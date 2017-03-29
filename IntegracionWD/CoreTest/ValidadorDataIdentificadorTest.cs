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
        private Mock<ValidadorTipoIdentificadorInterface> validadorIdentificador;

        [TestInitialize()]
        public void Initialize()
        {
            validadorIdentificador = new Mock<ValidadorTipoIdentificadorInterface>();
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
            string otipo;
            string oiden;

            validadorIdentificador.Setup(v => v.Validar(It.IsAny<string>(), It.IsAny<string>(), out otipo, out oiden)).Throws(new BusinessException("Validador error", "0001"));
            validador.Validar(new DataIdentificador());
        }
    }
}
