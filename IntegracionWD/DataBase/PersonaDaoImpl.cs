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
    public class PersonaDaoImpl : CommonDao, PersonaDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PersonaDaoImpl));

        private DataSourceInterface dataSource;

        public PersonaDaoImpl(DataSourceInterface dataSource)
        {
            this.dataSource = dataSource;
        }

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);

            try
            {
                SqlConnection conn = dataSource.getConnection();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_PERSONAS", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = data.Nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar).Value = data.Apellido;
                cmd.Parameters.Add("@RUT", SqlDbType.NChar).Value = data.RUT;
                cmd.Parameters.Add("@Tarjeta", SqlDbType.NVarChar).Value = data.Tarjeta;
                cmd.Parameters.Add("@TipoPase", SqlDbType.NVarChar).Value = data.TipoPase;
                cmd.Parameters.Add("@Contrato", SqlDbType.NVarChar).Value = data.Contrato;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = data.RazonSocial;
                cmd.Parameters.Add("@FechaExpiracionTrabajador", SqlDbType.NChar).Value = data.FechaExpiracionTrabajador;
                cmd.Parameters.Add("@MotivoRechazoTrabajador", SqlDbType.NVarChar).Value = data.MotivoRechazoTrabajor;
                cmd.Parameters.Add("@FechaExpiracionLicencia", SqlDbType.NChar).Value = data.FechaExpiracionLicencia;
                cmd.Parameters.Add("@MotivoRechazoLicencia", SqlDbType.NVarChar).Value = data.MotivoRechazoLicencia;

                AgregarParametrosSalida(cmd);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ValidarResultado(Errors.AGREGAR_PERSONA_DAO);
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible agregar persona", ex);
                throw new BusinessException("No es posible agregar persona", Errors.AGREGAR_PERSONA_DAO, ex);
            }

            return ResponseFactory.CreateSuccessResponse("Se agregó la persona correctamente");
        }

    }
}
