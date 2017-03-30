using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFechaExpiracionTrabajador : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Fecha expiracion del trabajador nula", Errors.FECHA_EXPIRACION_TRABAJADOR_NULL);
            ValidarVacio(input, out output, "Fecha expiracion del trabajador vacia", Errors.FECHA_EXPIRACION_TRABAJADOR_VACIO);

            if (!new ValidadorFecha().Validar(output))
            {
                throw new BusinessException("Fecha expiracion del trabajador incorrecta [" + input + "]", Errors.FECHA_EXPIRACION_TRABAJADOR_INCORRECTO);
            }

            return output;
        }
    }
}
