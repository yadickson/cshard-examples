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
    public class TransitoTest
    {
        private TransitoInterface transito;
        private Mock<ValidarDataInterface<DataTransito>> validador;
        private Mock<LoggerDaoInterface> loggerDao;
        private Mock<TransitoDaoInterface> transitoDao;

        [TestInitialize()]
        public void Initialize()
        {
            validador = new Mock<ValidarDataInterface<DataTransito>>();
            loggerDao = new Mock<LoggerDaoInterface>();
            transitoDao = new Mock<TransitoDaoInterface>();
            transito = new TransitoImpl(validador.Object, transitoDao.Object, loggerDao.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestAgregarTransitoFallaValidacion()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataTransito>())).Throws(new BusinessException("Validador error", "0001"));
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            RespuestaTransito response = transito.ObtenerListadoTransito(new DataTransito());

            validador.Verify(v => v.Validar(It.IsAny<DataTransito>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            transitoDao.Verify(p => p.ObtenerListadoTransito(It.IsAny<DataTransito>()), Times.Never());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_ERROR_CONSULTA;
            string mExpected = "Validador error";
            string csExpected = Business.SERVICIO_TRANSITO + "0001";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            transitoDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarTransitoFallaDao()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataTransito>())).Returns(new DataTransito());
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            transitoDao.Setup(p => p.ObtenerListadoTransito(It.IsAny<DataTransito>())).Throws(new BusinessException("Dao error", "0002"));

            RespuestaTransito response = transito.ObtenerListadoTransito(new DataTransito());

            validador.Verify(v => v.Validar(It.IsAny<DataTransito>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            transitoDao.Verify(p => p.ObtenerListadoTransito(It.IsAny<DataTransito>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_ERROR_CONSULTA;
            string mExpected = "Dao error";
            string csExpected = Business.SERVICIO_TRANSITO + "0002";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            transitoDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarTransitoCorrecto()
        {
            RespuestaTransito daoResponse = new RespuestaTransito();
            daoResponse.Codigo = "C";
            daoResponse.Mensaje = "M";
            daoResponse.CodigoServicio = "CS";
            daoResponse.ListadoTransito = new List<Transito>();

            validador.Setup(v => v.Validar(It.IsAny<DataTransito>())).Returns(new DataTransito());
            transitoDao.Setup(p => p.ObtenerListadoTransito(It.IsAny<DataTransito>())).Returns(daoResponse);

            RespuestaTransito response = transito.ObtenerListadoTransito(new DataTransito());

            validador.Verify(v => v.Validar(It.IsAny<DataTransito>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            transitoDao.Verify(p => p.ObtenerListadoTransito(It.IsAny<DataTransito>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = "C";
            string mExpected = "M";
            string csExpected = "CS";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);
            Assert.IsNotNull(response.ListadoTransito);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            transitoDao.VerifyAll();
        }
    }
}
