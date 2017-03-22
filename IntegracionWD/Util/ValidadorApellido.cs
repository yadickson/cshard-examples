using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorApellido
    {
        public static string Validar(string input)
        {
            string apellido = input;

            if (apellido == null)
            {
                throw new BusinessException("Apellido nulo", Errors.APELLIDO_NULL);
            }

            apellido = input.Trim();

            if (apellido.Length == 0)
            {
                throw new BusinessException("Apellido vacio", Errors.APELLIDO_VACIO);
            }

            return apellido;
        }
    }
}
