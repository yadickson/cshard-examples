using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Constants
{
    public class Errors
    {
        public const string NOMBRE_NULL = "000001";
        public const string NOMBRE_VACIO = "000002";

        public const string APELLIDO_NULL = "000011";
        public const string APELLIDO_VACIO = "000012";

        public const string RUT_NULL = "000021";
        public const string RUT_VACIO = "000022";
        public const string RUT_SIN_DV = "000023";
        public const string RUT_DV_INCORRECTO = "000024";

        public const string TARJETA_NULL = "000031";
        public const string TARJETA_VACIO = "000032";

        public const string TIPO_PASE_NULL = "000041";
        public const string TIPO_PASE_VACIO = "000042";

        public const string RAZON_SOCIAL_NULL = "000051";
        public const string RAZON_SOCIAL_VACIO = "000052";

        public const string FECHA_EXPIRACION_TRABAJADOR_NULL = "000061";
        public const string FECHA_EXPIRACION_TRABAJADOR_VACIO = "000062";
        public const string FECHA_EXPIRACION_TRABAJADOR_INCORRECTO = "000063";

        public const string FECHA_EXPIRACION_LICENCIA_NULL = "000071";
        public const string FECHA_EXPIRACION_LICENCIA_VACIO = "000072";
        public const string FECHA_EXPIRACION_LICENCIA_INCORRECTO = "000073";

        public const string MOTIVO_RECHAZO_TRABAJADOR_NULL = "000081";
        public const string MOTIVO_RECHAZO_TRABAJADOR_VACIO = "000082";

        public const string MOTIVO_RECHAZO_LICENCIA_NULL = "000091";
        public const string MOTIVO_RECHAZO_LICENCIA_VACIO = "000092";

        public const string PATENTE_NULL = "000101";
        public const string PATENTE_VACIO = "000102";
        public const string PATENTE_LONGITUD_INCORRECTA = "000103";
        public const string PATENTE_INCORRECTA = "000104";
        public const string PATENTE_DV_INCORRECTO = "000105";

        public const string MARCA_NULL = "000111";
        public const string MARCA_VACIO = "000112";

        public const string MODELO_NULL = "000121";
        public const string MODELO_VACIO = "000122";

        public const string ANIO_VEHICULO_NULL = "000131";
        public const string ANIO_VEHICULO_VACIO = "000132";
        public const string ANIO_VEHICULO_INCORRECTO = "000133";

        public const string TIPO_VEHICULO_NULL = "000141";
        public const string TIPO_VEHICULO_VACIO = "000142";

        public const string FECHA_EXPIRACION_VEHICULO_NULL = "000151";
        public const string FECHA_EXPIRACION_VEHICULO_VACIO = "000152";
        public const string FECHA_EXPIRACION_VEHICULO_INCORRECTO = "000153";

        public const string MOTIVO_RECHAZO_VEHICULO_NULL = "000161";
        public const string MOTIVO_RECHAZO_VEHICULO_VACIO = "000162";

        public const string TIPO_NULL = "000171";
        public const string TIPO_VACIO = "000172";
        public const string TIPO_INCORRECTO = "000173";

        public const string IDENTIFICADOR_INCORRECTO = "000181";

        public const string FECHA_DESDE_NULL = "000191";
        public const string FECHA_DESDE_VACIO = "000192";
        public const string FECHA_DESDE_INCORRECTO = "000193";

        public const string FECHA_HASTA_NULL = "000201";
        public const string FECHA_HASTA_VACIO = "000202";
        public const string FECHA_HASTA_INCORRECTO = "000203";

        public const string FECHA_DESDE_MENOR = "000211";

        public const string AGREGAR_PERSONA_DAO = "100001";
        public const string AGREGAR_VEHICULO_DAO = "100011";

    }
}
