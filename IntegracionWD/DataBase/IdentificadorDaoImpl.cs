using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Constants;
using IntegracionWD.Domain;
using IntegracionWD.Exception;
using IntegracionWD.Util;
using System.Data.SqlClient;
using System.Data;

namespace IntegracionWD.DataBase
{
    public class IdentificadorDaoImpl : CommonDao, IdentificadorDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorDaoImpl));

        private string storeProcedureName;
        private DataSourceInterface dataSource;

        public IdentificadorDaoImpl(string storeProcedureName, DataSourceInterface dataSource)
        {
            this.storeProcedureName = storeProcedureName;
            this.dataSource = dataSource;
        }

        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);

            SqlParameter id = new SqlParameter("@Id", SqlDbType.VarChar);

            try
            {
                SqlConnection conn = dataSource.getConnection();
                SqlCommand cmd = dataSource.getCommand(storeProcedureName, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Identificador", SqlDbType.VarChar).Value = data.Identificador;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = data.Tipo;

                id.Direction = ParameterDirection.Output;
                id.Size = 20;
                cmd.Parameters.Add(id);

                AgregarParametrosSalida(cmd);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible consultar el identificador unico para [Tipo:" + data.Tipo + "][Identificador:" + data.Identificador + "]", ex);
                throw new BusinessException("No es posible consultar el identificador unico para [Tipo:" + data.Tipo + "][Identificador:" + data.Identificador + "]", Errors.CONSULTA_IDENTIFICADOR_DAO, ex);
            }

            ValidarResultado(Errors.CONSULTA_IDENTIFICADOR_DAO);

            return ResponseFactory.CreateIdentifyResponse("Identificador unico [Tipo:" + data.Tipo + "][Identificador:" + data.Identificador + "]", Convert.ToString(id.Value));
        }
    }
}
