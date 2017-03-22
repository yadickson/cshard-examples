using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class Patente
    {
        public static string Validar(string input)
        {
            string ipatente = input;

            if (ipatente == null)
            {
                throw new BusinessException("Patente nula", Errors.PATENTE_NULL);
            }

            ipatente = input.Trim();

            if (ipatente.Length == 0)
            {
                throw new BusinessException("Patente vacia", Errors.PATENTE_VACIO);
            }

            ipatente = ipatente.Replace("-", "");

            if (ipatente.Length != 7)
            {
                throw new BusinessException("Patente con longitud incorrecta", Errors.PATENTE_LONGITUD_INCORRECTA);
            }

            string patente = ipatente.Substring(0, ipatente.Length - 1);
            string dv = ipatente.Substring(ipatente.Length - 1);

            if (!new ValidadorModulo11().Validar(patente, dv))
            {
                throw new BusinessException("Digito verificador de patente incorrecto", Errors.PATENTE_DV_INCORRECTO);
            }

            return patente + Messages.SEPARADOR_DV + dv.ToUpper();
        }
    }
}
