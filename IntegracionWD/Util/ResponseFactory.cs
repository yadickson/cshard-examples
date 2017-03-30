using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ResponseFactory
    {
        public static Respuesta CreateSuccessResponse(string message)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = message;
            response.CodigoServicio = null;
            return response;
        }

        public static Respuesta CreateErrorResponse(string message, string codigoServicio)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Messages.CODIGO_RECHAZADO;
            response.Mensaje = message;
            response.CodigoServicio = codigoServicio;
            return response;
        }

        public static RespuestaIdentificador CreateIdentifyResponse(string mensaje, string id)
        {
            RespuestaIdentificador response = new RespuestaIdentificador();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = mensaje;
            response.CodigoServicio = null;
            response.Identificador = id;
            return response;
        }

        public static RespuestaIdentificador CreateErrorIdentifyResponse(string message, string codigoServicio)
        {
            RespuestaIdentificador response = new RespuestaIdentificador();
            response.Codigo = Messages.CODIGO_ERROR_CONSULTA;
            response.Mensaje = message;
            response.CodigoServicio = codigoServicio;
            response.Identificador = null;
            return response;
        }

        public static RespuestaTransito CreateTransitoResponse(List<Transito> listado)
        {
            RespuestaTransito response = new RespuestaTransito();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = null;
            response.CodigoServicio = null;
            response.ListadoTransito = listado;
            return response;
        }

        public static RespuestaTransito CreateErrorTransitResponse(string message, string codigoServicio)
        {
            RespuestaTransito response = new RespuestaTransito();
            response.Codigo = Messages.CODIGO_ERROR_CONSULTA;
            response.Mensaje = message;
            response.CodigoServicio = codigoServicio;
            response.ListadoTransito = null;
            return response;
        }

    }
}
