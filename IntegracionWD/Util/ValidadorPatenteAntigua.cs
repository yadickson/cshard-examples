using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorPatenteAntigua : ValidadorInterface<string, string>
    {
        private List<string> listAntigua = new List<string>(Data.PATENTE_ANTIGUA);
        private ValidadorInterface<string, string> validadorLongitud;
        private ValidadorInterface<bool, string> validadorModulo;

        public ValidadorPatenteAntigua(ValidadorInterface<string, string> validadorLongitud,
            ValidadorInterface<bool, string> validadorModulo)
        {
            this.validadorLongitud = validadorLongitud;
            this.validadorModulo = validadorModulo;
        }

        public string Validar(string input)
        {
            string output = validadorLongitud.Validar(input);
            int pos = listAntigua.IndexOf(output.Substring(0, 2).ToUpper());

            if (pos == -1)
            {
                throw new BusinessException("Patente antigua no valida [" + input + "]", Errors.PATENTE_INCORRECTA);
            }

            string numero = (pos + 1).ToString() + output.Substring(2, 4);
            string patente = output.Substring(0, output.Length - 1);
            string dv = output.Substring(output.Length - 1);

            if (!validadorModulo.Validar(numero + dv))
            {
                throw new BusinessException("Digito verificador de patente antigua incorrecto [" + input + "]", Errors.PATENTE_DV_INCORRECTO);
            }

            return patente + Format.SEPARADOR_DV + dv.ToUpper();
        }

    }
}
