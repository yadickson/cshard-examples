using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorNombre
    {
        public static string Validar(string input)
        {
            string nombre = input;

            if (nombre == null)
            {
                throw new BusinessException("Nombre nulo", Errors.NOMBRE_NULL);
            }

            nombre = input.Trim();

            if (nombre.Length == 0)
            {
                throw new BusinessException("Nombre vacio", Errors.NOMBRE_VACIO);
            }

            return nombre;
        }
    }
}
