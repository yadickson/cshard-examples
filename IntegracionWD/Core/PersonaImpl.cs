using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;

namespace IntegracionWD.Core
{
    public class PersonaImpl : PersonaInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PersonaImpl));

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);

            try 
            {
                ValidadorNombre.Validar(data.Nombre);
                ValidadorApellido.Validar(data.Apellido);
                ValidadorRUT.Validar(data.RUT);
                ValidadorTarjeta.Validar(data.Tarjeta);

                return null;
            }
            catch (BusinessException ex)
            {
                log.Error("Error al agregar persona", ex);
                return ResponseFactory.CreateErrorResponse(ex.Message);
            }
        }
    }
}
