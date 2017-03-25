using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public class VehiculoDaoImpl : VehiculoDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VehiculoDaoImpl));

        private DataSourceInterface dataSource;

        public VehiculoDaoImpl(DataSourceInterface dataSource)
        {
            this.dataSource = dataSource;
        }

        public Respuesta AgregarVehiculo(DataVehiculo data)
        {
            log.Info("Agregar Vehiculo : " + data);
            return null;
        }
        // SqlConnection

    }
}
