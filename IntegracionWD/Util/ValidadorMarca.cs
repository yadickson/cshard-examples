using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorMarca : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Marca nulo", Errors.MARCA_NULL);
            ValidarVacio(input, out output, "Marca vacio", Errors.MARCA_VACIO);
            return output;
        }
    }
}
