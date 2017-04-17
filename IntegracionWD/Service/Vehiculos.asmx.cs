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
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para agregar vehiculos")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Vehiculos : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Vehiculos));

        private VehiculoInterface vehiculo;

        public Vehiculos()
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            this.vehiculo = (VehiculoInterface)applicationContext["vehiculo"];
        }

        [WebMethod(Description = "Metodo para agregar vehiculo")]
        public Respuesta AgregarVehiculo(DataVehiculo data)
        {
            new Security(this);
            log.Info("Agregar vehiculo : " + data);
            return vehiculo.AgregarVehiculo(data);
        }
    }
}
