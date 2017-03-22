using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorRUT
    {
        public static string Validar(string input)
        {
            string irut = input;

            if (irut == null)
            {
                throw new BusinessException("RUT nulo", Errors.RUT_NULL);
            }

            irut = input.Trim();

            if (irut.Length == 0)
            {
                throw new BusinessException("RUT vacio", Errors.RUT_VACIO);
            }

            irut = irut.Replace(".", "");
            irut = irut.Replace("-", "");

            if (irut.Length <= 1)
            {
                throw new BusinessException("RUT sin digito verificador", Errors.RUT_SIN_DV);
            }

            string rut = irut.Substring(0, irut.Length - 1);
            string dv = irut.Substring(irut.Length - 1);

            if (!new ValidadorModulo11().Validar(rut, dv))
            {
                throw new BusinessException("Digito verificador de RUT incorrecto", Errors.RUT_DV_INCORRECTO);
            }

            return rut + Messages.SEPARADOR_DV + dv.ToUpper();
        }
    }
}
