using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Constants
{
    public class Errors
    {
        public const string RUT_NULL = "0001";
        public const string RUT_VACIO = "0002";
        public const string RUT_SIN_DV = "0003";
        public const string RUT_DV_INCORRECTO = "0004";

        public const string PATENTE_NULL = "0011";
        public const string PATENTE_VACIO = "0012";
        public const string PATENTE_LONGITUD_INCORRECTA = "0013";
        public const string PATENTE_INCORRECTA = "0014";
        public const string PATENTE_DV_INCORRECTO = "0015";

        public const string NOMBRE_NULL = "0031";
        public const string NOMBRE_VACIO = "0032";

        public const string APELLIDO_NULL = "0041";
        public const string APELLIDO_VACIO = "0042";

    }
}
