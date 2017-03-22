using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Constants;

namespace IntegracionWD.Core
{
    public class ResponseFactory
    {
        public static Respuesta CreateSuccessResponse(string message)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = message;
            return response;
        }

        public static Respuesta CreateErrorResponse(string message)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = message;
            return response;
        }
    }
}
