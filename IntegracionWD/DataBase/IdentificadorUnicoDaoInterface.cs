using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public interface IdentificadorUnicoDaoInterface
    {
        RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data);
    }
}
