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
    public class ValidadorPatente : ValidadorBase, ValidadorInterface<string, string>
    {
        private ValidadorInterface<string, string> validadorLongitud;
        private ValidadorInterface<string, string> validadorAntiguo;
        private ValidadorInterface<string, string> validadorActual;

        public ValidadorPatente(ValidadorInterface<string, string> validadorLongitud,
            ValidadorInterface<string, string> validadorAntiguo,
            ValidadorInterface<string, string> validadorActual)
        {
            this.validadorLongitud = validadorLongitud;
            this.validadorAntiguo = validadorAntiguo;
            this.validadorActual = validadorActual;
        }

        public string Validar(string input)
        {
            string output = validadorLongitud.Validar(input);

            Regex rx = new Regex("^(\\w){2}(\\d){2}");
            Match m = rx.Match(output);

            if (m.Success)
            {
                output = validadorAntiguo.Validar(output);
            }
            else
            {
                output = validadorActual.Validar(output);
            }

            return output;
        }

    }
}
