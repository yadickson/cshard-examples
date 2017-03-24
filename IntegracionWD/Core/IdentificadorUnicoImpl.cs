using System;
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

    public class IdentificadorUnicoImpl : IdentificadorUnicoInterface
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IdentificadorUnicoImpl));

        private IdentificadorUnicoDaoInterface identificadorUnicoDao;

        public IdentificadorUnicoImpl(IdentificadorUnicoDaoInterface identificadorUnicoDao)
        {
            this.identificadorUnicoDao = identificadorUnicoDao;
        }

        public RespuestaIdentificador ObtenerIdentificadorUnico(DataIdentificador data)
        {
            log.Info("Obtener identificador unico: " + data);

            try
            {
                string otipo;
                string odata;

                new ValidadorIdentificador().Validar(data.Tipo, data.Identificador, out otipo, out odata);

                data.Tipo = otipo;
                data.Identificador = odata;

                return identificadorUnicoDao.ObtenerIdentificadorUnico(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al consultar identificador unico", ex);
                return ResponseFactory.CreateErrorIdentifyResponse(Business.SERVICIO_IDENTIFICADOR + ex.Code);
            }
        }
    }
}
