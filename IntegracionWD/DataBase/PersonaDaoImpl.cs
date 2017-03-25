using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;
using IntegracionWD.Domain;
using IntegracionWD.Exception;
using System.Data.SqlClient;

namespace IntegracionWD.DataBase
{
    public class PersonaDaoImpl : PersonaDaoInterface
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
                conn.Open();
                
                conn.Close();
            }
            catch (System.Exception ex)
            {
                throw new BusinessException("No es posible agregar persona", Errors.AGREGAR_PERSONA_DAO, ex);
            }

            return null;
        }

    }
}
