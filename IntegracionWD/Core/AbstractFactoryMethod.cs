using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.DataBase;

namespace IntegracionWD.Core
{
    public class AbstractFactoryMethod
    {
        public static PersonaInterface createPersona()
        {
            return new PersonaImpl(createPersonaDao());
        }

        public static VehiculoInterface createVehiculo()
        {
            return new VehiculoImpl(createVehiculoDao());
        }

        public static TransitoInterface createTransito()
        {
            return new TransitoImpl(createTransitoDao());
        }

        public static IdentificadorUnicoInterface createIdentificadorUnico()
        {
            return new IdentificadorUnicoImpl(createIdentificadorUnicoDao());
        }

        public static PersonaDaoInterface createPersonaDao()
        {
            return new PersonaDaoImpl();
        }

        public static VehiculoDaoInterface createVehiculoDao()
        {
            return new VehiculoDaoImpl();
        }

        public static IdentificadorUnicoDaoInterface createIdentificadorUnicoDao()
        {
            return new IdentificadorUnicoDaoImpl();
        }

        public static TransitoDaoInterface createTransitoDao()
        {
            return new TransitoDaoImpl();
        }
    }
}
