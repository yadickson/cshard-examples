using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorMarca : ValidadorBase
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
