using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;
using IntegracionWD.DataBase;

namespace IntegracionWD.Core
{
    public class TransitoImpl : TransitoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TransitoImpl));

        private ValidadorDataInterface<DataTransito> validador;
        private LoggerDaoInterface loggerDao;
        private TransitoDaoInterface transitoDao;

        public TransitoImpl(ValidadorDataInterface<DataTransito> validador, TransitoDaoInterface transitoDao, LoggerDaoInterface loggerDao)
        {
            this.validador = validador;
            this.transitoDao = transitoDao;
            this.loggerDao = loggerDao;
        }

        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);

            try
            {
                return transitoDao.ObtenerListadoTransito(validador.Validar(data));
            }
            catch (BusinessException ex)
            {
                log.Error("Error al consultar transito", ex);
                loggerDao.Agregar(ex.Message, Business.SERVICIO_TRANSITO + ex.Code);
                return ResponseFactory.CreateErrorTransitResponse(ex.Message, Business.SERVICIO_TRANSITO + ex.Code);
            }
        }
    }
}
