﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Constants
{
    public class Errors
    {
        public const string NOMBRE_NULL = "0001";
        public const string NOMBRE_VACIO = "0002";

        public const string APELLIDO_NULL = "0011";
        public const string APELLIDO_VACIO = "0012";

        public const string RUT_NULL = "0021";
        public const string RUT_VACIO = "0022";
        public const string RUT_SIN_DV = "0023";
        public const string RUT_DV_INCORRECTO = "0024";

        public const string TARJETA_NULL = "0031";
        public const string TARJETA_VACIO = "0032";

        public const string TIPO_PASE_NULL = "0041";
        public const string TIPO_PASE_VACIO = "0042";

        public const string RAZON_SOCIAL_NULL = "0051";
        public const string RAZON_SOCIAL_VACIO = "0052";

        public const string FECHA_EXPIRACION_TRABAJADOR_NULL = "0061";
        public const string FECHA_EXPIRACION_TRABAJADOR_VACIO = "0062";
        public const string FECHA_EXPIRACION_TRABAJADOR_INCORRECTO = "0063";

        public const string FECHA_EXPIRACION_LICENCIA_NULL = "0071";
        public const string FECHA_EXPIRACION_LICENCIA_VACIO = "0072";
        public const string FECHA_EXPIRACION_LICENCIA_INCORRECTO = "0073";

        public const string PATENTE_NULL = "0011";
        public const string PATENTE_VACIO = "0012";
        public const string PATENTE_LONGITUD_INCORRECTA = "0013";
        public const string PATENTE_INCORRECTA = "0014";
        public const string PATENTE_DV_INCORRECTO = "0015";
    }
}
