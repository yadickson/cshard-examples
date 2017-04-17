using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using IntegracionWD.Domain;
using IntegracionWD.Core;
using Spring.Context;
using Spring.Context.Support;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para agregar personas")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Personas : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Personas));

        private PersonaInterface persona;

        public Personas()
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            this.persona = (PersonaInterface)applicationContext["persona"];
        }

        [WebMethod(Description = "Metodo para agregar personas")]
        public Respuesta AgregarPersona(DataPersona data)
        {
            new Security(this);
            log.Info("Agregar persona : " + data);
            return persona.AgregarPersona(data);
        }
    }
}
