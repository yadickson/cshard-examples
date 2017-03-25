using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IntegracionWD.DataBase
{
    public interface DataSourceInterface
    {
        SqlConnection getConnection();
    }
}
