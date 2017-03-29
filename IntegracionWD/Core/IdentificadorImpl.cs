﻿using System;
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

    public class IdentificadorImpl : IdentificadorInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorImpl));

        private LoggerDaoInterface loggerDao;
        private IdentificadorDaoInterface identificadorDao;

        public IdentificadorImpl(IdentificadorDaoInterface identificadorDao, LoggerDaoInterface loggerDao)
        {
            this.identificadorDao = identificadorDao;
            this.loggerDao = loggerDao;
        }

        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);

            try
            {
                string otipo;
                string odata;

                new ValidadorTipoIdentificador().Validar(data.Tipo, data.Identificador, out otipo, out odata);

                data.Tipo = otipo;
                data.Identificador = odata;

                return identificadorDao.ObtenerIdentificadorUnico(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al consultar identificador unico", ex);
                loggerDao.Agregar(ex.Message, Business.SERVICIO_IDENTIFICADOR + ex.Code);
                return ResponseFactory.CreateErrorIdentifyResponse(ex.Message, Business.SERVICIO_IDENTIFICADOR + ex.Code);
            }
        }
    }
}