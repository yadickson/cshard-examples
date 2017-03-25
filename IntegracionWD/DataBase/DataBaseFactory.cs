using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Util;
using IntegracionWD.Constants;

namespace IntegracionWD.DataBase
{
    public class DataBaseFactory
    {
        public static DataSourceInterface createDataSource()
        {
            string connectionString = new Properties().GetConnectionString();
            return new DataSourceImpl(connectionString);
        }

        public static LoggerDaoInterface createLoggerPersonaDao()
        {
            return new LoggerDaoImpl(Business.SP_LOG_PERSONAS, createDataSource());
        }

        public static LoggerDaoInterface createLoggerVehiculoDao()
        {
            return new LoggerDaoImpl(Business.SP_LOG_VEHICULOS, createDataSource());
        }

        public static LoggerDaoInterface createLoggerTransitoDao()
        {
            return new LoggerDaoImpl(Business.SP_LOG_TRANSITO, createDataSource());
        }

        public static LoggerDaoInterface createLoggerIdentificadorDao()
        {
            return new LoggerDaoImpl(Business.SP_LOG_IDENTIFICADOR, createDataSource());
        }

        public static PersonaDaoInterface createPersonaDao()
        {
            return new PersonaDaoImpl(createDataSource());
        }

        public static VehiculoDaoInterface createVehiculoDao()
        {
            return new VehiculoDaoImpl(createDataSource());
        }

        public static IdentificadorUnicoDaoInterface createIdentificadorUnicoDao()
        {
            return new IdentificadorUnicoDaoImpl(createDataSource());
        }

        public static TransitoDaoInterface createTransitoDao()
        {
            return new TransitoDaoImpl(createDataSource());
        }
    }
}
