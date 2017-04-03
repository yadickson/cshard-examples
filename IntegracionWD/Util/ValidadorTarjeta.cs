using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorTarjeta: ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Tarjeta nula", Errors.TARJETA_NULL);
            ValidarVacio(input, out output, "Tarjeta vacia", Errors.TARJETA_VACIO);
            return output;
        }
    }
}
