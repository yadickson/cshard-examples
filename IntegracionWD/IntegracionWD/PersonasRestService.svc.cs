using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IntegracionWD
{
    public class PersonasRestService : IPersonasRestService
    {
        public string CheckService()
        {
            return "ok";
        }

        public string AgregarPersona()
        {
            return "AgregarPersona";
        }
    }
}
