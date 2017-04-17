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
            ValidarLongitud(input, ipatente, out ipatente);
            ValidadorEstructura(input, ipatente);

            Regex rxAntigua = new Regex("^([A-Za-z]{2}[0-9]{4})$");
            Regex rxModerna = new Regex("^([A-Za-z]{4}[0-9]{2})$");

            if (rxAntigua.Match(ipatente).Success)
            {
                ValidarPatenteAntigua(input, ipatente);
            }
            else if (rxModerna.Match(ipatente).Success)
            {
                ValidarPatenteActual(input, ipatente, 4);
            }
            else
            {
                ValidarPatenteActual(input, ipatente, 3);
            }

            return ipatente;
        }

        protected void ValidarLongitud(string pInput, string input, out string output)
        {
            output = input.Replace("-", "").ToUpper();

            if (output.Length != 6)
            {
                throw new BusinessException("Patente con longitud incorrecta [" + pInput + "]", Errors.PATENTE_LONGITUD_INCORRECTA);
            }

        }

        protected void ValidadorEstructura(string pInput, string input)
        {
            Regex rx = new Regex("^(([A-Za-z]{2}[0-9]{4})|([A-Za-z]{3}[0-9]{3})|([A-Za-z]{4}[0-9]{2}))$");
            Match m = rx.Match(input);

            if (!m.Success)
            {
                throw new BusinessException("Patente no valida [" + pInput + "], se espera XX9999, XXXX99 o XXX999", Errors.PATENTE_INCORRECTA);
            }
        }

        protected void ValidarPatenteAntigua(string pInput, string input)
        {
            int pos = listAntigua.IndexOf(input.Substring(0, 2).ToUpper());

            if (pos == -1)
            {
                throw new BusinessException("Patente antigua no valida [" + pInput + "]", Errors.PATENTE_INCORRECTA);
            }
        }

        protected void ValidarPatenteActual(string pInput, string input, int size)
        {
            char[] letras = input.Substring(0, size).ToCharArray();

            foreach (char c in letras)
            {
                string caracter = c.ToString().ToUpper();
                int pos = listActual.IndexOf(caracter);

                if (pos == -1)
                {
                    throw new BusinessException("Patente no valida [" + pInput + "]", Errors.PATENTE_INCORRECTA);
                }
            }
        }
    }
}
