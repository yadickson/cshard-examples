using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorPatente : ValidadorBase
    {
        private List<string> listAntigua = new List<string>(Data.PATENTE_ANTIGUA);
        private List<string> listActual = new List<string>(Data.PATENTE_ACTUAL);

        public string Validar(string input)
        {
            string ipatente;

            ValidarNulo(input, "Patente nula", Errors.PATENTE_NULL);
            ValidarVacio(input, out ipatente, "Patente vacia", Errors.PATENTE_VACIO);
            ValidarLongitud(ipatente, out ipatente);

            string patente = ipatente.Substring(0, ipatente.Length - 1).ToUpper();
            string dv = ipatente.Substring(ipatente.Length - 1);
            string numero;

            int aux;
            bool esPatenteAntigua = int.TryParse(patente.Substring(2, 2), out aux);

            if (esPatenteAntigua)
            {
                ValidarPatenteAntigua(patente, out numero);
            }
            else
            {
                ValidarPatenteActual(patente, out numero);
            }

            if (!new ValidadorModulo11().Validar(numero, dv))
            {
                throw new BusinessException("Digito verificador de patente incorrecto", Errors.PATENTE_DV_INCORRECTO);
            }

            return patente + Messages.SEPARADOR_DV + dv.ToUpper();
        }

        protected void ValidarLongitud(string input, out string output)
        {
            output = input.Replace("-", "");

            if (output.Length != 7)
            {
                throw new BusinessException("Patente con longitud incorrecta", Errors.PATENTE_LONGITUD_INCORRECTA);
            }

        }

        protected void ValidarPatenteAntigua(string input, out string output)
        {
            int pos = listAntigua.IndexOf(input.Substring(0, 2).ToUpper());

            if (pos == -1)
            {
                throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
            }

            output = (pos + 1).ToString() + input.Substring(2, 4);

        }

        protected void ValidarPatenteActual(string input, out string output)
        {
            output = string.Empty;
            char[] letras = input.Substring(0, 4).ToCharArray();
            string numeroFinal = input.Substring(4, 2);

            Regex rx = new Regex("\\d+");
            Match m = rx.Match(numeroFinal);

            if (!m.Success)
            {
                throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
            }

            int nFinal = int.Parse(numeroFinal);

            if (nFinal < 10)
            {
                throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
            }

            foreach (char c in letras)
            {
                string caracter = c.ToString().ToUpper();
                int pos = listActual.IndexOf(caracter);

                if (pos == -1)
                {
                    throw new BusinessException("Patente no valida", Errors.PATENTE_INCORRECTA);
                }

                if (pos == 9)
                {
                    pos = -1;
                }
                if (pos >= 10)
                {
                    pos -= 9;
                }

                output += (pos + 1).ToString();
            }

            output += numeroFinal;
        }
    }
}
