using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionWD.Util
{
    public class ValidadorModulo11
    {
        public bool Validar(string rut, string dv)
        {
            return dv.ToUpper().Equals(GetDigitoVerificador(rut));
        }

        public string GetDigitoVerificador(string rut)
        {
            int mul = 2;
            int suma = 0;

            int longitud = rut.Length;
            for (int i = longitud - 1; i >= 0; i--)
            {
                int dig = Convert.ToInt32(rut[i]) - 48;
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
