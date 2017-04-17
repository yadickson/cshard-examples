using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using IntegracionWD.Exception;

namespace IntegracionWD.Service
{
    public class Security
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Security));
        public Security(WebService service)
        {
            log.Info("Usuario: " + service.User.Identity.Name);

#if !DEBUG
            if (!service.User.Identity.IsAuthenticated)
            {
                log.Error("Usuario no autenticado");
                throw new BusinessException("Usuario no autenticado", null);
            }
#endif
        }
    }
}
