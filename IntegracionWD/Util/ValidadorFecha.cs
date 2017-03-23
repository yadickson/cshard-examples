using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorFecha
    {
        public bool Validar(string input)
        {
            Regex rx = new Regex("^(19|20)\\d\\d(0[1-9]|1[012])$");
            return rx.Match(input).Success;
        }
    }
}
