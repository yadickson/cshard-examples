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
    public class TransitoImpl : TransitoInterface
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TransitoImpl));

        private TransitoDaoInterface transitoDao;

        public TransitoImpl(TransitoDaoInterface transitoDao)
        {
            this.transitoDao = transitoDao;
        }

        public RespuestaTransito ObtenerListadoTransito(DataTransito data)
        {
            log.Info("Obtener listado transito : " + data);

            try
            {
                data.FechaDesde = new ValidadorFechaDesde().Validar(data.FechaDesde);
                data.FechaHasta = new ValidadorFechaHasta().Validar(data.FechaHasta);

                if (data.FechaDesde.CompareTo(data.FechaHasta) <= 0)
                {
                    data.FechaDesde = new ValidadorFechaDesde().Validar(data.FechaDesde);
                    data.FechaHasta = new ValidadorFechaHasta().Validar(data.FechaHasta);
                }
                else
                {
                    throw new BusinessException("Fecha desde mayor a fecha hasta [FechaDesde:" + data.FechaDesde + "][FechaHasta:" + data.FechaHasta + "]", Errors.FECHA_DESDE_MENOR);
                }

                if (data.Tipo != null || data.Identificador != null)
                {
                    string otipo;
                    string odata;

                    new ValidadorTipoIdentificador().Validar(data.Tipo, data.Identificador, out otipo, out odata);

                    data.Tipo = otipo;
                    data.Identificador = odata;
                }

                return transitoDao.ObtenerListadoTransito(data);
            }
            catch (BusinessException ex)
            {
                log.Error("Error al consultar transito", ex);
                DataBaseFactory.createLoggerTransitoDao().Agregar(ex.Message, Business.SERVICIO_TRANSITO + ex.Code);
                return ResponseFactory.CreateErrorTransitResponse(ex.Message, Business.SERVICIO_TRANSITO + ex.Code);
            }
        }
    }
}
