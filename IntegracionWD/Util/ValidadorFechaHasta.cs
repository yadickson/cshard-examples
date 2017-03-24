using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFechaHasta : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Fecha hasta nula", Errors.FECHA_HASTA_NULL);
            ValidarVacio(input, out output, "Fecha hasta vacia", Errors.FECHA_HASTA_VACIO);

            if (!new ValidadorFecha().Validar(output))
            {
                throw new BusinessException("Fecha hasta es incorrecta", Errors.FECHA_HASTA_INCORRECTO);
            }

            return output;
        }
    }
}
