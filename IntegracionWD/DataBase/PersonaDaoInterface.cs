using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public interface PersonaDaoInterface
    {
        Respuesta AgregarPersona(DataPersona data);
    }
}
