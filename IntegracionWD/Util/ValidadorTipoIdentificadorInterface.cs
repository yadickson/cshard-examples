﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public interface ValidadorTipoIdentificadorInterface
    {
        void Validar(string tipo, string data, out string otipo, out string odata);
    }
}
