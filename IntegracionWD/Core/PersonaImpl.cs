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

        private PersonaDaoInterface personaDao;

        public PersonaImpl(PersonaDaoInterface personaDao)
        {
            this.personaDao = personaDao;
        }

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);

            try
            {
                data.Nombre = new ValidadorNombre().Validar(data.Nombre);
                data.Apellido = new ValidadorApellido().Validar(data.Apellido);
                data.RUT = new ValidadorRUT().Validar(data.RUT);
                data.Tarjeta = new ValidadorTarjeta().Validar(data.Tarjeta);
                data.TipoPase = new ValidadorTipoPase().Validar(data.TipoPase);
                data.Contrato = new ValidadorContrato().Validar(data.Contrato);
                data.RazonSocial = new ValidadorRazonSocial().Validar(data.RazonSocial);
                data.FechaExpiracionTrabajador = new ValidadorFechaExpiracionTrabajador().Validar(data.FechaExpiracionTrabajador);
                data.MotivoRechazoTrabajor = new ValidadorMotivoRechazoTrabajor().Validar(data.MotivoRechazoTrabajor);
                data.FechaExpiracionLicencia = new ValidadorFechaExpiracionTrabajador().Validar(data.FechaExpiracionLicencia);
                data.MotivoRechazoLicencia = new ValidadorMotivoRechazoLicencia().Validar(data.MotivoRechazoLicencia);

                return personaDao.AgregarPersona(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar persona", ex);
                DataBaseFactory.createLoggerPersonaDao().Agregar(ex.Message, Business.SERVICIO_PERSONAS + ex.Code);
                return ResponseFactory.CreateErrorResponse(ex.Message, Business.SERVICIO_PERSONAS + ex.Code);
            }
        }
    }
}
