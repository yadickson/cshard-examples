using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public interface LoggerDaoInterface
    {
        void Agregar(string message, string codigoServicio);
    }
}
