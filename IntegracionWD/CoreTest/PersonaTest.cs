using System;
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
    public class PersonaTest
    {
        private PersonaInterface persona;
        private Mock<ValidadorDataInterface<DataPersona>> validador;
        private Mock<LoggerDaoInterface> loggerDao;
        private Mock<PersonaDaoInterface> personaDao;

        [TestInitialize()]
        public void Initialize()
        {
            validador = new Mock<ValidadorDataInterface<DataPersona>>();
            loggerDao = new Mock<LoggerDaoInterface>();
            personaDao = new Mock<PersonaDaoInterface>();
            persona = new PersonaImpl(validador.Object, personaDao.Object, loggerDao.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestAgregarPersonaFallaValidacion()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataPersona>())).Throws(new BusinessException("Validador error", "0001"));
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            Respuesta response = persona.AgregarPersona(new DataPersona());

            validador.Verify(v => v.Validar(It.IsAny<DataPersona>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            personaDao.Verify(p => p.AgregarPersona(It.IsAny<DataPersona>()), Times.Never());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_RECHAZADO;
            string mExpected = "Validador error";
            string csExpected = Business.SERVICIO_PERSONAS + "0001";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            personaDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarPersonaFallaDao()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataPersona>())).Returns(new DataPersona());
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            personaDao.Setup(p => p.AgregarPersona(It.IsAny<DataPersona>())).Throws(new BusinessException("Dao error", "0002"));

            Respuesta response = persona.AgregarPersona(new DataPersona());

            validador.Verify(v => v.Validar(It.IsAny<DataPersona>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            personaDao.Verify(p => p.AgregarPersona(It.IsAny<DataPersona>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_RECHAZADO;
            string mExpected = "Dao error";
            string csExpected = Business.SERVICIO_PERSONAS + "0002";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            personaDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarPersonaCorrecto()
        {
            Respuesta daoResponse = new Respuesta();
            daoResponse.Codigo = "C";
            daoResponse.Mensaje = "M";
            daoResponse.CodigoServicio = "CS";

            validador.Setup(v => v.Validar(It.IsAny<DataPersona>())).Returns(new DataPersona());
            personaDao.Setup(p => p.AgregarPersona(It.IsAny<DataPersona>())).Returns(daoResponse);

            Respuesta response = persona.AgregarPersona(new DataPersona());

            validador.Verify(v => v.Validar(It.IsAny<DataPersona>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            personaDao.Verify(p => p.AgregarPersona(It.IsAny<DataPersona>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = "C";
            string mExpected = "M";
            string csExpected = "CS";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            personaDao.VerifyAll();
        }
    }
}
