using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Exception;
using IntegracionWD.Core;
using IntegracionWD.Domain;
using IntegracionWD.DataBase;
using IntegracionWD.Constants;
using Moq;

namespace IntegracionWD.CoreTest
{
    [TestClass]
    public class IdentificadorTest
    {
        private IdentificadorInterface identificador;
        private Mock<ValidarDataInterface<DataIdentificador>> validador;
        private Mock<LoggerDaoInterface> loggerDao;
        private Mock<IdentificadorDaoInterface> identificadorDao;

        [TestInitialize()]
        public void Initialize()
        {
            validador = new Mock<ValidarDataInterface<DataIdentificador>>();
            loggerDao = new Mock<LoggerDaoInterface>();
            identificadorDao = new Mock<IdentificadorDaoInterface>();
            identificador = new IdentificadorImpl(validador.Object, identificadorDao.Object, loggerDao.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestAgregarIdentificadorFallaValidacion()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataIdentificador>())).Throws(new BusinessException("Validador error", "0001"));
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            RespuestaIdentificador response = identificador.ObtenerIdentificadorUnico(new DataIdentificador());

            validador.Verify(v => v.Validar(It.IsAny<DataIdentificador>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            identificadorDao.Verify(p => p.ObtenerIdentificadorUnico(It.IsAny<DataIdentificador>()), Times.Never());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_ERROR_CONSULTA;
            string mExpected = "Validador error";
            string csExpected = Business.SERVICIO_IDENTIFICADOR + "0001";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            identificadorDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarIdentificadorFallaDao()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataIdentificador>())).Returns(new DataIdentificador());
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            identificadorDao.Setup(p => p.ObtenerIdentificadorUnico(It.IsAny<DataIdentificador>())).Throws(new BusinessException("Dao error", "0002"));

            RespuestaIdentificador response = identificador.ObtenerIdentificadorUnico(new DataIdentificador());

            validador.Verify(v => v.Validar(It.IsAny<DataIdentificador>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            identificadorDao.Verify(p => p.ObtenerIdentificadorUnico(It.IsAny<DataIdentificador>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_ERROR_CONSULTA;
            string mExpected = "Dao error";
            string csExpected = Business.SERVICIO_IDENTIFICADOR + "0002";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            identificadorDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarIdentificadorCorrecto()
        {
            RespuestaIdentificador daoResponse = new RespuestaIdentificador();
            daoResponse.Codigo = "C";
            daoResponse.Mensaje = "M";
            daoResponse.CodigoServicio = "CS";
            daoResponse.Identificador = "0";

            validador.Setup(v => v.Validar(It.IsAny<DataIdentificador>())).Returns(new DataIdentificador());
            identificadorDao.Setup(p => p.ObtenerIdentificadorUnico(It.IsAny<DataIdentificador>())).Returns(daoResponse);

            RespuestaIdentificador response = identificador.ObtenerIdentificadorUnico(new DataIdentificador());

            validador.Verify(v => v.Validar(It.IsAny<DataIdentificador>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            identificadorDao.Verify(p => p.ObtenerIdentificadorUnico(It.IsAny<DataIdentificador>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = "C";
            string mExpected = "M";
            string csExpected = "CS";
            string iExpected = "0";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);
            Assert.AreEqual(iExpected, response.Identificador);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            identificadorDao.VerifyAll();
        }
    }
}
