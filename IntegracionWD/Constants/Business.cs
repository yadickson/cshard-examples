using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Constants
{
    public class Business
    {
        public const string SERVICIO_PERSONAS = "WS-SP";
        public const string SERVICIO_VEHICULOS = "WS-SV";
        public const string SERVICIO_TRANSITO = "WS-ST";
        public const string SERVICIO_IDENTIFICADOR = "WS-SI";

        public const string SP_PERSONAS = "SP_INSERTAR_PERSONAS";
        public const string SP_VEHICULOS = "SP_INSERTAR_VEHICULOS";
        public const string SP_TRANSITO = "SP_CONSULTA_TRANSITO";
        public const string SP_IDENTIFICADOR = "SP_CONSULTA_IDENTIFICADOR";

        public const string SP_LOG_PERSONAS = "SP_INSERTAR_LOG_PERSONAS";
        public const string SP_LOG_VEHICULOS = "SP_INSERTAR_LOG_VEHICULOS";
        public const string SP_LOG_TRANSITO = "SP_INSERTAR_LOG_CONSULTA_TRANSITO";
        public const string SP_LOG_IDENTIFICADOR = "SP_INSERTAR_LOG_CONSULTA_IDENTIFICADOR";
    }
}
