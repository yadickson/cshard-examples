using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorMotivoRechazoTrabajor : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Motivo de rechazo del trabajador nula", Errors.MOTIVO_RECHAZO_TRABAJADOR_NULL);
            ValidarVacio(input, out output, "Motivo de rechazo del trabajador vacia", Errors.MOTIVO_RECHAZO_TRABAJADOR_VACIO);
            return output;
        }
    }
}
