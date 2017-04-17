using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.UtilTest
{
    [TestClass]
    public class ValidadorPatenteTest
    {
        private ValidadorPatente validador = new ValidadorPatente();

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputNull()
        {
            validador.Validar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputEmpty()
        {
            validador.Validar("");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestInputTrimEmpty()
        {
            validador.Validar("     ");
        }
        
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteLongitud()
        {
            validador.Validar("AA81596");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorEstructura()
        {
            validador.Validar("XX81X9");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestValidarPatenteErrorEstructura1()
        {
            validador.Validar("X08109");
        }

        [TestMethod]
        public void TestValidarPatentModerna()
        {
            validador.Validar("BBBB59");
        }

        [TestMethod]
        public void TestValidarPatenteAntigua()
        {
            validador.Validar("AA1122");
        }

        [TestMethod]
        public void TestValidarPatenteMoto()
        {
            validador.Validar("BCB235");
        }
    }
}
