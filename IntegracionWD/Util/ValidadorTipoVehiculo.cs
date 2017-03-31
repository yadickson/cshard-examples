using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorTipoVehiculo : ValidadorBase, ValidadorInterface<string, string>
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Tipo de vehiculo nulo", Errors.TIPO_VEHICULO_NULL);
            ValidarVacio(input, out output, "Tipo de vehiculo vacio", Errors.TIPO_VEHICULO_VACIO);
            return output;
        }
    }
}
