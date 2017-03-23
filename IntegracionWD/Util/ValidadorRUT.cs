using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorRUT : ValidadorBase
    {
        public string Validar(string input)
        {
            string irut;

            ValidarNulo(input, "RUT nulo", Errors.RUT_NULL);
            ValidarVacio(input, out irut, "RUT vacio", Errors.RUT_VACIO);
            ValidarLongitud(irut, out irut);

            string rut = irut.Substring(0, irut.Length - 1);
            string dv = irut.Substring(irut.Length - 1);

            if (!new ValidadorModulo11().Validar(rut, dv))
            {
                throw new BusinessException("Digito verificador de RUT incorrecto", Errors.RUT_DV_INCORRECTO);
            }

            return rut + Messages.SEPARADOR_DV + dv.ToUpper();
        }

        protected void ValidarLongitud(string input, out string output)
        {
            output = input.Replace(".", "");
            output = output.Replace("-", "");

            if (output.Length <= 1)
            {
                throw new BusinessException("RUT sin digito verificador", Errors.RUT_SIN_DV);
            }
        }
    }
}
