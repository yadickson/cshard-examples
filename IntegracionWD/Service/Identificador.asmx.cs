using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IntegracionWD.Domain;
using IntegracionWD.Core;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para obtener identificador unico")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Identificador : System.Web.Services.WebService
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Identificador));

        private IdentificadorUnicoInterface identificadorUnico = new IdentificadorUnicoImpl();

        public void SetIdentificadorUnico(IdentificadorUnicoInterface identificadorUnico)
        {
            this.identificadorUnico = identificadorUnico;
        }

        [WebMethod(Description = "Metodo para obtener identificador unico")]
        public Respuesta ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);
            return identificadorUnico.ObtenerIdentificadorUnico(data);
        }
    }
}
