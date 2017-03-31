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
    public class ValidadorFecha : ValidadorInterface<bool, string>
    {
        public bool Validar(string input)
        {
            string febrero = "(02)(0[1-9]|1[0-9]|2[0-8])";
            string febreroB = "(02)(29)";

            string meses30 = "(0[469]|11)(0[1-9]|[12][0-9]|30)";
            string meses31 = "(0[13578]|10|12)(0[1-9]|[12][0-9]|3[01])";

            string anio = "\\d{4}";
            string anioB = "(([02468][048]00)|([13579][26]00)|([0-9][0-9][0][48])|([0-9][0-9][2468][048])|([0-9][0-9][13579][26]))";

            string general = "^(" + anio + febrero + ")|(" + anio + meses30 + ")|(" + anio + meses31 + ")|(" + anioB + febreroB + ")$";
            return new Regex(general).Match(input).Success;
        }
    }
}
