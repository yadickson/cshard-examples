using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFechaDesde : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Fecha desde nula", Errors.FECHA_DESDE_NULL);
            ValidarVacio(input, out output, "Fecha desde vacia", Errors.FECHA_DESDE_VACIO);

            if (!new ValidadorFecha().Validar(output))
            {
                throw new BusinessException("Fecha desde es incorrecta [" + input + "]", Errors.FECHA_DESDE_INCORRECTO);
            }

            return output;
        }
    }
}
