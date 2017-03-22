using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;

namespace IntegracionWD.Core
{
    public class ResponseFactory
    {
        public static Respuesta CreateSuccessResponse(string message)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Constants.CodeSuccess;
            response.Mensaje = message;
            return response;
        }

        public static Respuesta CreateErrorResponse(string message)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Constants.CodeError;
            response.Mensaje = message;
            return response;
        }
    }
}
