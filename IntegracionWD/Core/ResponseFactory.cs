﻿using System;
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
        public static Respuesta CreateSuccessResponse(string message, string codigoServicio)
        {
            Respuesta response = new Respuesta();
            response.Codigo = Messages.CODIGO_ACEPTADO;
            response.Mensaje = message;
            response.CodigoServicio = codigoServicio;
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

        public static RespuestaIdentificador CreateErrorIdentifyResponse(string message, string codigoServicio)
        {
            RespuestaIdentificador response = new RespuestaIdentificador();
            response.Codigo = Messages.CODIGO_ERROR_CONSULTA;
            response.Mensaje = message;
            response.CodigoServicio = codigoServicio;
            response.Identificador = null;
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
