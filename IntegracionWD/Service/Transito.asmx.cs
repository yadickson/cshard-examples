﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IntegracionWD.Domain;
using IntegracionWD.Core;
using Spring.Context;
using Spring.Context.Support;

namespace IntegracionWD.Service
{
    [WebService(Namespace = "http://integracion.wd.cl/", Description = "Web Service para obtener listado de transito")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Transito : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Transito));

        private TransitoInterface transito;

        public Transito()
        {
            IApplicationContext applicationContext = ContextRegistry.GetContext();
            this.transito = (TransitoInterface)applicationContext["transito"];
        }

        [WebMethod(Description = "Metodo para obtener listado de transito")]
        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);
            return transito.ObtenerListadoTransito(data);
        }
    }
}
