using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorMotivoRechazoLicencia : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Motivo de rechazo de la licencia nula", Errors.MOTIVO_RECHAZO_LICENCIA_NULL);
            ValidarVacio(input, out output, "Motivo de rechazo de la licencia vacia", Errors.MOTIVO_RECHAZO_LICENCIA_VACIO);
            return output;
        }
    }
}
