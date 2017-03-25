using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IntegracionWD.DataBase
{
    public class DataSourceImpl : DataSourceInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataSourceImpl));

        private string connectionString;

        public DataSourceImpl(string connectionString)
        {
            log.Info("Connection String: " + connectionString);
            this.connectionString = connectionString;
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
