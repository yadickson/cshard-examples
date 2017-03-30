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
    public class PersonaImpl : PersonaInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PersonaImpl));

        private ValidadorDataInterface<DataPersona> validador;
        private LoggerDaoInterface loggerDao;
        private PersonaDaoInterface personaDao;

        public PersonaImpl(ValidadorDataInterface<DataPersona> validador, PersonaDaoInterface personaDao, LoggerDaoInterface loggerDao)
        {
            this.validador = validador;
            this.personaDao = personaDao;
            this.loggerDao = loggerDao;
        }

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);

            try
            {
                return personaDao.AgregarPersona(validador.Validar(data));
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar persona", ex);
                loggerDao.Agregar(ex.Message, Business.SERVICIO_PERSONAS + ex.Code);
                return ResponseFactory.CreateErrorResponse(ex.Message, Business.SERVICIO_PERSONAS + ex.Code);
            }
        }
    }
}
