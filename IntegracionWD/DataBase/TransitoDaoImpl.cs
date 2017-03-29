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
    public class TransitoDaoImpl : CommonDao, TransitoDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TransitoDaoImpl));

        private string storeProcedureName;
        private DataSourceInterface dataSource;

        public TransitoDaoImpl(string storeProcedureName, DataSourceInterface dataSource)
        {
            this.storeProcedureName = storeProcedureName;
            this.dataSource = dataSource;
        }

        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);

            List<Transito> listado = new List<Transito>();
            SqlDataReader reader;

            try
            {
                SqlConnection conn = dataSource.getConnection();
                SqlCommand cmd = new SqlCommand(storeProcedureName, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaDesde", SqlDbType.VarChar).Value = data.FechaDesde;
                cmd.Parameters.Add("@FechaHasta", SqlDbType.VarChar).Value = data.FechaHasta;
                cmd.Parameters.Add("@Identificador", SqlDbType.VarChar).Value = data.Identificador;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = data.Tipo;

                AgregarParametrosSalida(cmd);

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Transito consulta = new Transito();
                    consulta.Fecha = reader.GetString(0);
                    consulta.Sentido = reader.GetString(1);
                    consulta.PuntoDeControl = reader.GetString(2);
                    consulta.Tipo = reader.GetString(3);
                    consulta.Identificador = reader.GetString(4);
                    listado.Add(consulta);
                }

                conn.Close();
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible realizar la consulta de transito [FechaDesde:" + data.FechaDesde + "][FechaHasta:" + data.FechaHasta + "][Tipo:" + data.Tipo + "][Identificador:" + data.Identificador + "]", ex);
                throw new BusinessException("No es posible realizar la consulta de transito [FechaDesde:" + data.FechaDesde + "][FechaHasta:" + data.FechaHasta + "][Tipo:" + data.Tipo + "][Identificador:" + data.Identificador + "]", Errors.CONSULTA_TRANSITO_DAO, ex);
            }

            ValidarResultado(Errors.CONSULTA_TRANSITO_DAO);

            return ResponseFactory.CreateTransitoResponse(listado);
        }

    }
}
