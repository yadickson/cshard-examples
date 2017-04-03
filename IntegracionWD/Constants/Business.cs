﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionWD.Constants
{
    public class Business
    {
        public const string SERVICIO_PERSONAS = "WS-SP";
        public const string SERVICIO_VEHICULOS = "WS-SV";
        public const string SERVICIO_TRANSITO = "WS-ST";
        public const string SERVICIO_IDENTIFICADOR = "WS-SI";

        public const string SP_PERSONAS = "InsertarPersona";
        public const string SP_VEHICULOS = "InsertarVehiculo";
        public const string SP_TRANSITO = "ConsultaTransito";
        public const string SP_IDENTIFICADOR = "ConsultaIdentificador";

        public const string SP_LOG_PERSONAS = "InsertarLogPersonas";
        public const string SP_LOG_VEHICULOS = "InsertarLogVehiculos";
        public const string SP_LOG_TRANSITO = "InsertarLogConsultaTransito";
        public const string SP_LOG_IDENTIFICADOR = "InsertarLogConsultaIdentificador";
    }
}