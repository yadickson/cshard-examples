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

    public class IdentificadorImpl : IdentificadorInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorImpl));

        private ValidarDataInterface<DataIdentificador> validador;
        private LoggerDaoInterface loggerDao;
        private IdentificadorDaoInterface identificadorDao;

        public IdentificadorImpl(ValidarDataInterface<DataIdentificador> validador, IdentificadorDaoInterface identificadorDao, LoggerDaoInterface loggerDao)
        {
            this.validador = validador;
            this.identificadorDao = identificadorDao;
            this.loggerDao = loggerDao;
        }

        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);

            try
            {
                return identificadorDao.ObtenerIdentificadorUnico(validador.Validar(data));
            }
            catch (BusinessException ex)
            {
                log.Error("Error al consultar identificador unico", ex);
                loggerDao.Agregar(ex.Message, Business.SERVICIO_IDENTIFICADOR + ex.Code);
                return ResponseFactory.CreateErrorIdentifyResponse(ex.Message, Business.SERVICIO_IDENTIFICADOR + ex.Code);
            }
        }
    }
}
