using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorAnioVehiculo : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Anio de vehiculo nulo", Errors.ANIO_VEHICULO_NULL);
            ValidarVacio(input, out output, "Anio de vehiculo vacio", Errors.ANIO_VEHICULO_VACIO);

            if (!new ValidadorAnio().Validar(output))
            {
                throw new BusinessException("Anio incorrecto", Errors.ANIO_VEHICULO_INCORRECTO);
            }

            return output;
        }
    }
}
