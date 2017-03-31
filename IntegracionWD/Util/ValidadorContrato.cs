using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorContrato : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Contrato nulo", Errors.TIPO_PASE_NULL);
            ValidarVacio(input, out output, "Contrato vacio", Errors.TIPO_PASE_VACIO);
            return output;
        }
    }
}
