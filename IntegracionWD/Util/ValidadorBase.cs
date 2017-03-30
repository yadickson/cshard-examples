using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorBase
    {
        protected void ValidarNulo(string input, string messageError, string codeError)
        {
            if (input == null)
            {
                throw new BusinessException(messageError, codeError);
            }
        }

        protected void ValidarVacio(string input, out string output, string messageError, string codeError)
        {
            output = input.Trim();

            if (output.Length == 0)
            {
                throw new BusinessException(messageError, codeError);
            }
        }
    }
}
