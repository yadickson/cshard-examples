using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorPatente
    {
        private static List<string> listAntigua = new List<string>(Data.PATENTE_ANTIGUA);
        private static List<string> listActual = new List<string>(Data.PATENTE_ACTUAL);

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

            string patente = ipatente.Substring(0, ipatente.Length - 1).ToUpper();
            string dv = ipatente.Substring(ipatente.Length - 1);
            string numero = string.Empty;

            int aux;
            bool esPatenteAntigua = int.TryParse(patente.Substring(2, 2), out aux);

            if (esPatenteAntigua)
            {
                int pos = listAntigua.IndexOf(patente.Substring(0, 2).ToUpper());
                
                if (pos == -1)
                {
                    throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
                }

                numero = (pos + 1).ToString() + patente.Substring(2, 4);
            }
            else
            {
                char[] letras = patente.Substring(0, 4).ToCharArray();

                foreach (char c in letras)
                {
                    string caracter = c.ToString().ToUpper();
                    int pos = listActual.IndexOf(caracter);

                    if (pos == -1)
                    {
                        throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
                    }

                    numero += (pos + 1).ToString();
                }

                numero += patente.Substring(4, 2);

            }

            if (!new ValidadorModulo11().Validar(numero, dv))
            {
                throw new BusinessException("Digito verificador de patente incorrecto", Errors.PATENTE_DV_INCORRECTO);
            }

            return patente + Messages.SEPARADOR_DV + dv.ToUpper();
        }
    }
}
