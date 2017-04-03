using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorModelo : ValidadorBase
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
