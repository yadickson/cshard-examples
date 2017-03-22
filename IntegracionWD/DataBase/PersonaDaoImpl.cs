using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.DataBase
{
    public class PersonaDaoImpl : PersonaDaoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PersonaDaoImpl));

        public Respuesta AgregarPersona(DataPersona data)
        {
            log.Info("Agregar persona : " + data);
            return null;
        }
        // SqlConnection

    }
}
