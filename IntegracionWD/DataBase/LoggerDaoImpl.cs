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
    public class LoggerDaoImpl : CommonDao, LoggerDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoggerDaoImpl));

        private string storeProcedureName;
        private DataSourceInterface dataSource;

        public LoggerDaoImpl(string storeProcedureName, DataSourceInterface dataSource)
        {
            this.storeProcedureName = storeProcedureName;
            this.dataSource = dataSource;
        }

        public void Agregar(string message, string codigoServicio)
        {
            log.Info("Agregar mensaje de log : " + message + " - " + codigoServicio + " a: " + storeProcedureName);

            try
            {
                SqlConnection conn = dataSource.getConnection();
                SqlCommand cmd = dataSource.getCommand(storeProcedureName, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Entrada", SqlDbType.NVarChar).Value = message;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = codigoServicio;

                AgregarParametrosSalida(cmd);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                ValidarResultado(Errors.AGREGAR_LOG_DAO);
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible agregar mensaje log en base de datos", ex);
            }

        }

    }
}
