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
    public class VehiculoTest
    {
        private VehiculoInterface vehiculo;
        private Mock<ValidadorDataInterface<DataVehiculo>> validador;
        private Mock<LoggerDaoInterface> loggerDao;
        private Mock<VehiculoDaoInterface> vehiculoDao;

        [TestInitialize()]
        public void Initialize()
        {
            validador = new Mock<ValidadorDataInterface<DataVehiculo>>();
            loggerDao = new Mock<LoggerDaoInterface>();
            vehiculoDao = new Mock<VehiculoDaoInterface>();
            vehiculo = new VehiculoImpl(validador.Object, vehiculoDao.Object, loggerDao.Object);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestAgregarVehiculoFallaValidacion()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataVehiculo>())).Throws(new BusinessException("Validador error", "0001"));
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            Respuesta response = vehiculo.AgregarVehiculo(new DataVehiculo());

            validador.Verify(v => v.Validar(It.IsAny<DataVehiculo>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            vehiculoDao.Verify(p => p.AgregarVehiculo(It.IsAny<DataVehiculo>()), Times.Never());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_RECHAZADO;
            string mExpected = "Validador error";
            string csExpected = Business.SERVICIO_VEHICULOS + "0001";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            vehiculoDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarVehiculoFallaDao()
        {
            validador.Setup(v => v.Validar(It.IsAny<DataVehiculo>())).Returns(new DataVehiculo());
            loggerDao.Setup(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            vehiculoDao.Setup(p => p.AgregarVehiculo(It.IsAny<DataVehiculo>())).Throws(new BusinessException("Dao error", "0002"));

            Respuesta response = vehiculo.AgregarVehiculo(new DataVehiculo());

            validador.Verify(v => v.Validar(It.IsAny<DataVehiculo>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            vehiculoDao.Verify(p => p.AgregarVehiculo(It.IsAny<DataVehiculo>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = Messages.CODIGO_RECHAZADO;
            string mExpected = "Dao error";
            string csExpected = Business.SERVICIO_VEHICULOS + "0002";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            vehiculoDao.VerifyAll();
        }

        [TestMethod]
        public void TestAgregarVehiculoCorrecto()
        {
            Respuesta daoResponse = new Respuesta();
            daoResponse.Codigo = "C";
            daoResponse.Mensaje = "M";
            daoResponse.CodigoServicio = "CS";

            validador.Setup(v => v.Validar(It.IsAny<DataVehiculo>())).Returns(new DataVehiculo());
            vehiculoDao.Setup(p => p.AgregarVehiculo(It.IsAny<DataVehiculo>())).Returns(daoResponse);

            Respuesta response = vehiculo.AgregarVehiculo(new DataVehiculo());

            validador.Verify(v => v.Validar(It.IsAny<DataVehiculo>()), Times.Once());
            loggerDao.Verify(l => l.Agregar(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            vehiculoDao.Verify(p => p.AgregarVehiculo(It.IsAny<DataVehiculo>()), Times.Once());

            Assert.IsNotNull(response);

            string cExpected = "C";
            string mExpected = "M";
            string csExpected = "CS";

            Assert.AreEqual(cExpected, response.Codigo);
            Assert.AreEqual(mExpected, response.Mensaje);
            Assert.AreEqual(csExpected, response.CodigoServicio);

            validador.VerifyAll();
            loggerDao.VerifyAll();
            vehiculoDao.VerifyAll();
        }
    }
}
