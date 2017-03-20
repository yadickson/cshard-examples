using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IntegracionWD
{
    public class VehiculosRestService : IVehiculosRestService
    {
        public string CheckService()
        {
            return "ok";
        }

        public string AgregarVehiculo()
        {
            return "AgregarVehiculo";
        }
    }
}
