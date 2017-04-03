using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public interface ValidadorTipoIdentificadorInterface
    {
        void Validar(string tipo, string data, out string otipo, out string odata);
    }
}
