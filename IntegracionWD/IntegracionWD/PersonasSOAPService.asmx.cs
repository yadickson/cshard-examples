using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IntegracionWD
{
    [WebService(Namespace = "http://integracion.wd.cl/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class PersonasSOAPService : System.Web.Services.WebService, IPersonasService
    {

        [WebMethod]
        public string AgregarPersona()
        {
            return "AgregarPersona";
        }
    }
}
