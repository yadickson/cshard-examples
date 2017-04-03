using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;

namespace IntegracionWD.Core
{
    public interface PersonaInterface
    {
        Respuesta AgregarPersona(DataPersona data);
    }
}
