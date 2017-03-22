using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IntegracionWD.Domain;
using IntegracionWD.Core;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para agregar personas")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Personas : System.Web.Services.WebService
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Personas));
        
        private PersonaInterface persona = new PersonaImpl();

        public void SetPersona(PersonaInterface persona)
        {
            this.persona = persona;
        }

        [WebMethod(Description = "Metodo para agregar personas")]
        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);
            return persona.AgregarPersona(data);
        }
    }
}
