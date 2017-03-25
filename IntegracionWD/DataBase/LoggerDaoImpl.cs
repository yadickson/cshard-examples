using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IntegracionWD.DataBase
{
    public class LoggerDaoImpl : LoggerDaoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoggerDaoImpl));

        private DataSourceInterface dataSource;

        public LoggerDaoImpl(DataSourceInterface dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Agregar(string message, string codigoServicio)
        {
            log.Info("Agregar mensaje de log : " + message + " - " + codigoServicio);

            try
            {
                SqlConnection conn = dataSource.getConnection();
                conn.Open();

                conn.Close();
            }
            catch (System.Exception ex)
            {
                log.Error("No es posible agregar mensaje log en base de datos", ex);
            }
        }

    }
}
