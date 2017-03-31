using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFechaExpiracionLicencia : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Fecha expiracion de la licencia nula", Errors.FECHA_EXPIRACION_LICENCIA_NULL);
            ValidarVacio(input, out output, "Fecha expiracion de la licencia vacia", Errors.FECHA_EXPIRACION_LICENCIA_VACIO);

            if (!new ValidadorFecha().Validar(output))
            {
                throw new BusinessException("Fecha expiracion de la licencia incorrecta [" + input + "]", Errors.FECHA_EXPIRACION_LICENCIA_INCORRECTO);
            }

            return output;
        }
    }
}
