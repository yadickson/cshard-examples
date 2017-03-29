using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.Core
{
    public interface IdentificadorInterface
    {
        RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data);
    }
}
