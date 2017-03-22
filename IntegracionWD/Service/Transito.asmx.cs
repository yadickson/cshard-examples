using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IntegracionWD.Domain;
using IntegracionWD.Core;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Transito : System.Web.Services.WebService
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Transito));

        [WebMethod]
        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);
            return null; // ResponseFactory.CreateSuccessResponse("listo");
        }
    }
}
