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
        
        private VehiculoDaoInterface vehiculoDao;

        public VehiculoImpl(VehiculoDaoInterface vehiculoDao)
        {
            this.vehiculoDao = vehiculoDao;
        }

        public Respuesta AgregarVehiculo(DataVehiculo data)
        {
            log.Info("Agregar vehiculo : " + data);

            try
            {
                data.Patente = new ValidadorPatente().Validar(data.Patente);
                data.Marca = new ValidadorMarca().Validar(data.Marca);
                data.Modelo = new ValidadorModelo().Validar(data.Modelo);
                data.Anio = new ValidadorAnioVehiculo().Validar(data.Anio);
                data.TipoVehiculo = new ValidadorTipoVehiculo().Validar(data.TipoVehiculo);
                data.Contrato = new ValidadorContrato().Validar(data.Contrato);
                data.RazonSocial = new ValidadorRazonSocial().Validar(data.RazonSocial);
                data.FechaExpiracion = new ValidadorFechaExpiracionVehiculo().Validar(data.FechaExpiracion);
                data.MotivoRechazo = new ValidadorMotivoRechazoVehiculo().Validar(data.MotivoRechazo);

                return vehiculoDao.AgregarVehiculo(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar vehiculo", ex);
                return ResponseFactory.CreateErrorResponse(ex.Message, Business.SERVICIO_VEHICULOS + ex.Code);
            }
        }
    }
}
