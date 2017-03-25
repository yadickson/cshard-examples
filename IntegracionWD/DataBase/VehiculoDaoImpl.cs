using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;
using IntegracionWD.Domain;
using IntegracionWD.Exception;
using IntegracionWD.Util;
using System.Data.SqlClient;
using System.Data;

namespace IntegracionWD.DataBase
{
    public class VehiculoDaoImpl : CommonDao, VehiculoDaoInterface
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

            try
            {
                SqlConnection conn = dataSource.getConnection();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_VEHICULOS", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Patente", SqlDbType.NChar).Value = data.Patente;
                cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = data.Marca;
                cmd.Parameters.Add("@Modelo", SqlDbType.NVarChar).Value = data.Modelo;
                cmd.Parameters.Add("@Anio", SqlDbType.NChar).Value = data.Anio;
                cmd.Parameters.Add("@TipoVehiculo", SqlDbType.NVarChar).Value = data.TipoVehiculo;
                cmd.Parameters.Add("@Contrato", SqlDbType.NVarChar).Value = data.Contrato;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = data.RazonSocial;
                cmd.Parameters.Add("@FechaExpiracion", SqlDbType.NChar).Value = data.FechaExpiracion;
                cmd.Parameters.Add("@MotivoRechazo", SqlDbType.NVarChar).Value = data.MotivoRechazo;

                AgregarParametrosSalida(cmd);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ValidarResultado(Errors.AGREGAR_VEHICULO_DAO);
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible agregar vehículo", ex);
                throw new BusinessException("No es posible agregar vehículo", Errors.AGREGAR_VEHICULO_DAO, ex);
            }

            return ResponseFactory.CreateSuccessResponse("Se agregó el vehículo correctamente");
        }

    }
}
