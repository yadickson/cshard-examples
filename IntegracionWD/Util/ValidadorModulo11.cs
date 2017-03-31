using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Util
{
    public class ValidadorModulo11 : ValidadorInterface<bool, string>
    {
        public bool Validar(string input)
        {
            string data = input.Substring(0, input.Length - 1);
            string dv = input.Substring(input.Length - 1);

            return dv.ToUpper().Equals(GetDigitoVerificador(data));
        }

        public string GetDigitoVerificador(string data)
        {
            int mul = 2;
            int suma = 0;

            int longitud = data.Length;
            for (int i = longitud - 1; i >= 0; i--)
            {
                int dig = Convert.ToInt32(data.ElementAt(i)) - 48;
                suma += dig * mul;
                if (mul == 7)
                {
                    mul = 2;
                }
                else
                {
                    mul++;
                }
            }
            int resto = suma % 11;
            if (resto == 0)
            {
                return "0";
            }
            if (resto == 1)
            {
                return "K";
            }
            int r = 11 - resto;
            return r.ToString();
        }

    }
}
