using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorTipo : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Tipo nulo", Errors.TIPO_NULL);
            ValidarVacio(input, out output, "Tipo vacio", Errors.TIPO_VACIO);

            output = output.ToUpper();

            if (!Messages.CODIGO_TIPO_PERSONA.Equals(output) && !Messages.CODIGO_TIPO_VEHICULO.Equals(output))
            {
                throw new BusinessException("Tipo incorrecto [" + input + "]", Errors.TIPO_INCORRECTO);
            }

            return output;
        }
    }
}
