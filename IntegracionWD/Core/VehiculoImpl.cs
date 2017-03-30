using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;
using IntegracionWD.DataBase;

namespace IntegracionWD.Core
{
    public class VehiculoImpl : VehiculoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VehiculoImpl));

        private ValidadorDataInterface<DataVehiculo> validador;
        private LoggerDaoInterface loggerDao;
        private VehiculoDaoInterface vehiculoDao;

        public VehiculoImpl(ValidadorDataInterface<DataVehiculo> validador, VehiculoDaoInterface vehiculoDao, LoggerDaoInterface loggerDao)
        {
            this.validador = validador;
            this.vehiculoDao = vehiculoDao;
            this.loggerDao = loggerDao;
        }

        public Respuesta AgregarVehiculo(DataVehiculo data)
        {
            log.Info("Agregar vehiculo : " + data);

            try
            {
                return vehiculoDao.AgregarVehiculo(validador.Validar(data));
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar vehiculo", ex);
                loggerDao.Agregar(ex.Message, Business.SERVICIO_VEHICULOS + ex.Code);
                return ResponseFactory.CreateErrorResponse(ex.Message, Business.SERVICIO_VEHICULOS + ex.Code);
            }
        }
    }
}
