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

    public class VehiculosSOAPService : System.Web.Services.WebService, IVehiculosService
    {

        [WebMethod]
        public string AgregarVehiculo()
        {
            return "AgregarVehiculo";
        }
    }
}
