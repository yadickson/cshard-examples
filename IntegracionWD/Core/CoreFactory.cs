﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.DataBase;

namespace IntegracionWD.Core
{
    public class CoreFactory
    {
        public static PersonaInterface createPersona()
        {
            return new PersonaImpl(DataBaseFactory.createPersonaDao());
        }

        public static VehiculoInterface createVehiculo()
        {
            return new VehiculoImpl(DataBaseFactory.createVehiculoDao());
        }

        public static TransitoInterface createTransito()
        {
            return new TransitoImpl(DataBaseFactory.createTransitoDao());
        }

        public static IdentificadorUnicoInterface createIdentificadorUnico()
        {
            return new IdentificadorUnicoImpl(DataBaseFactory.createIdentificadorUnicoDao());
        }
    }
}