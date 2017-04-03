using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace IntegracionWD.DataBase
{
    public interface DataSourceInterface
    {
        SqlConnection getConnection();

        SqlCommand getCommand(string storeProcedureName, SqlConnection conn);
    }
}
