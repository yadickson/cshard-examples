using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorMotivoRechazoVehiculo : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Motivo de rechazo del vehiculo nula", Errors.MOTIVO_RECHAZO_VEHICULO_NULL);
            ValidarVacio(input, out output, "Motivo de rechazo del vehiculo vacia", Errors.MOTIVO_RECHAZO_VEHICULO_VACIO);
            return output;
        }
    }
}
