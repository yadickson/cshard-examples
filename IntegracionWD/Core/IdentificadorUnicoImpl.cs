using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.Core
{

    public class IdentificadorUnicoImpl : IdentificadorUnicoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorUnicoImpl));

        public Respuesta ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);
            return null;
        }
    }
}
