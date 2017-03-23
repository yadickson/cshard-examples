﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorApellido : ValidadorBase
    {
        public string Validar(string input)
        {
            string output;
            ValidarNulo(input, "Apellido nulo", Errors.APELLIDO_NULL);
            ValidarVacio(input, out output, "Apellido vacio", Errors.APELLIDO_VACIO);
            return output;
        }
    }
}
