using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorFactory
    {
        public static ValidadorDataInterface<DataPersona> createValidadorDataPersona()
        {
            return new ValidadorDataPersonaImpl();
        }

        public static ValidadorDataInterface<DataVehiculo> createValidadorDataVehiculo()
        {
            return new ValidadorDataVehiculoImpl();
        }

        public static ValidadorDataInterface<DataTransito> createValidadorDataTransito()
        {
            return new ValidadorDataTransitoImpl();
        }
        public static ValidadorDataInterface<DataIdentificador> createValidadorDataIdentificador()
        {
            return new ValidadorDataIdentificadorImpl(new ValidadorTipoIdentificadorImpl());
        }
    }
}
