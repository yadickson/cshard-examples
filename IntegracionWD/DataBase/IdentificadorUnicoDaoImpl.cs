using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public class IdentificadorUnicoDaoImpl : IdentificadorUnicoDaoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorUnicoDaoImpl));

        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);
            return null;
        }
        // SqlConnection

    }
}
