using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.Core
{
    public class VehiculoImpl : VehiculoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VehiculoImpl));

        public Respuesta AgregarVehiculo(DataVehiculo data)
        {
            log.Info("Agregar vehiculo : " + data);
            return null;
        }
    }
}
