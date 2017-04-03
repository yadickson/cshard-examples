using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorAnio
    {
        public bool Validar(string input)
        {
            string anio = "(19\\d{2})|(2\\d{3})";
            string general = "^(" + anio + ")$";
            return new Regex(general).Match(input).Success;
        }
    }
}
