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
    public class ValidadorPatenteActual : ValidadorInterface<string, string>
    {
        private List<string> listActual = new List<string>(Data.PATENTE_ACTUAL);

        private ValidadorInterface<string, string> validadorLongitud;
        private ValidadorInterface<bool, string> validadorModulo;

        public ValidadorPatenteActual(ValidadorInterface<string, string> validadorLongitud,
            ValidadorInterface<bool, string> validadorModulo)
        {
            this.validadorLongitud = validadorLongitud;
            this.validadorModulo = validadorModulo;
        }

        public string Validar(string input)
        {
            string output = validadorLongitud.Validar(input);

            string aux = string.Empty;
            char[] letras = output.Substring(0, 4).ToCharArray();
            string numeroFinal = output.Substring(4, 2);
            string patente = output.Substring(0, output.Length - 1);
            string dv = output.Substring(output.Length - 1);

            Regex rx = new Regex("\\d+");
            Match m = rx.Match(numeroFinal);

            if (!m.Success)
            {
                throw new BusinessException("Patente no valida [" + input + "]", Errors.PATENTE_INCORRECTA);
            }

            int nFinal = int.Parse(numeroFinal);

            if (nFinal < 10)
            {
                throw new BusinessException("Patente no valida [" + input + "]", Errors.PATENTE_INCORRECTA);
            }

            foreach (char c in letras)
            {
                string caracter = c.ToString().ToUpper();
                int pos = listActual.IndexOf(caracter);

                if (pos == -1)
                {
                    throw new BusinessException("Patente no valida [" + input + "]", Errors.PATENTE_INCORRECTA);
                }

                if (pos == 9)
                {
                    pos = -1;
                }
                if (pos >= 10)
                {
                    pos -= 9;
                }

                aux += (pos + 1).ToString();
            }

            if (!validadorModulo.Validar(aux + numeroFinal + dv))
            {
                throw new BusinessException("Digito verificador de patente actual incorrecto [" + input + "]", Errors.PATENTE_DV_INCORRECTO);
            }

            return patente + Format.SEPARADOR_DV + dv.ToUpper();
        }

    }
}
