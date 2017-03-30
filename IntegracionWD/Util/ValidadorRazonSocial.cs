using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorRazonSocial : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Razon social nulo", Errors.RAZON_SOCIAL_NULL);
            ValidarVacio(input, out output, "Razon social vacio", Errors.RAZON_SOCIAL_VACIO);
            return output;
        }
    }
}
