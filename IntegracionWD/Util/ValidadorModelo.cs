using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorModelo : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Modelo nulo", Errors.MODELO_NULL);
            ValidarVacio(input, out output, "Modelo vacio", Errors.MODELO_VACIO);
            return output;
        }
    }
}
