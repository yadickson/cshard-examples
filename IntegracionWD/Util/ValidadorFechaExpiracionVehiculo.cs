using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFechaExpiracionVehiculo : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Fecha expiracion del vehiculo nula", Errors.FECHA_EXPIRACION_VEHICULO_NULL);
            ValidarVacio(input, out output, "Fecha expiracion del vehiculo vacia", Errors.FECHA_EXPIRACION_VEHICULO_VACIO);

            if (!new ValidadorFecha().Validar(output))
            {
                throw new BusinessException("Fecha expiracion del vehiculo incorrecta", Errors.FECHA_EXPIRACION_VEHICULO_INCORRECTO);
            }

            return output;
        }
    }
}
