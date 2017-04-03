using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.DataBase;

namespace IntegracionWD.Core
{
    public class CoreFactory
    {
        public static PersonaInterface createPersona()
        {
            return new PersonaImpl(ValidadorFactory.createValidadorDataPersona(), DataBaseFactory.createPersonaDao(), DataBaseFactory.createLoggerPersonaDao());
        }

        public static VehiculoInterface createVehiculo()
        {
            return new VehiculoImpl(ValidadorFactory.createValidadorDataVehiculo(), DataBaseFactory.createVehiculoDao(), DataBaseFactory.createLoggerVehiculoDao());
        }

        public static TransitoInterface createTransito()
        {
            return new TransitoImpl(ValidadorFactory.createValidadorDataTransito(), DataBaseFactory.createTransitoDao(), DataBaseFactory.createLoggerTransitoDao());
        }

        public static IdentificadorInterface createIdentificador()
        {
            return new IdentificadorImpl(ValidadorFactory.createValidadorDataIdentificador(), DataBaseFactory.createIdentificadorDao(), DataBaseFactory.createLoggerIdentificadorDao());
        }
    }
}