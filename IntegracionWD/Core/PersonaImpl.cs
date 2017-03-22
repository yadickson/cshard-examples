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
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PersonaImpl));

        private PersonaDaoInterface personaDao = new PersonaDaoImpl();

        public PersonaImpl(PersonaDaoInterface personaDao)
        {
            this.personaDao = personaDao;
        }

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);

            try 
            {
                data.Nombre = ValidadorNombre.Validar(data.Nombre);
                data.Apellido = ValidadorApellido.Validar(data.Apellido);
                data.RUT = ValidadorRUT.Validar(data.RUT);
                data.Tarjeta = ValidadorTarjeta.Validar(data.Tarjeta);

                return personaDao.AgregarPersona(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar persona", ex);
                return ResponseFactory.CreateErrorResponse(Business.SERVICIO_PERSONAS + ex.Code);
            }
        }
    }
}
