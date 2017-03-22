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
    public class Personas : System.Web.Services.WebService
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Personas));

        [WebMethod]
        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);
            return ResponseFactory.CreateSuccessResponse("listo");
        }
    }
}
