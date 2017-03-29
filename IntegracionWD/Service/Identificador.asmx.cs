using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IntegracionWD.Domain;
using IntegracionWD.Core;
using Spring.Context;
using Spring.Context.Support;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para obtener identificador unico")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Identificador : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Identificador));

        private IdentificadorInterface identificadorUnico;

        public Identificador()
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            this.identificadorUnico = (IdentificadorInterface)applicationContext["identificador"];
        }

        [WebMethod(Description = "Metodo para obtener identificador unico")]
        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);
            return identificadorUnico.ObtenerIdentificadorUnico(data);
        }
    }
}
