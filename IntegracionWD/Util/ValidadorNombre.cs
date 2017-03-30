using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorNombre : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Nombre nulo", Errors.NOMBRE_NULL);
            ValidarVacio(input, out output, "Nombre vacio", Errors.NOMBRE_VACIO);
            return output;
        }
    }
}
