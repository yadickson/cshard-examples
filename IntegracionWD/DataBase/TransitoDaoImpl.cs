using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public class TransitoDaoImpl : TransitoDaoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TransitoDaoImpl));

        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);
            return null;
        }
        // SqlConnection

    }
}
