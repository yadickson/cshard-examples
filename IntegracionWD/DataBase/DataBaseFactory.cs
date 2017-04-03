using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Util;
using IntegracionWD.Constants;

namespace IntegracionWD.DataBase
{
    public class DataBaseFactory
    {
        public static DataSourceInterface createDataSource()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connectionString"];
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
            return new PersonaDaoImpl(Business.SP_PERSONAS, createDataSource());
        }

        public static VehiculoDaoInterface createVehiculoDao()
        {
            return new VehiculoDaoImpl(Business.SP_VEHICULOS, createDataSource());
        }

        public static IdentificadorDaoInterface createIdentificadorDao()
        {
            return new IdentificadorDaoImpl(Business.SP_IDENTIFICADOR, createDataSource());
        }

        public static TransitoDaoInterface createTransitoDao()
        {
            return new TransitoDaoImpl(Business.SP_TRANSITO, createDataSource());
        }
    }
}