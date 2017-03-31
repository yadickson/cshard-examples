using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorPatenteLongitud : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;

            ValidarNulo(input, "Patente nula", Errors.PATENTE_NULL);
            ValidarVacio(input, out output, "Patente vacia", Errors.PATENTE_VACIO);

            output = input.Replace("-", "");

            if (output.Length != 7)
            {
                throw new BusinessException("Patente con longitud incorrecta [" + input + "]", Errors.PATENTE_LONGITUD_INCORRECTA);
            }

            return output.ToUpper();
        }
    }
}
