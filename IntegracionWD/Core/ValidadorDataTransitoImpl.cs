using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Core
{
    public class ValidadorDataTransitoImpl : ValidarDataInterface<DataTransito>
    {
        public DataTransito Validar(DataTransito data)
        {
            DataTransito output = new DataTransito();

            output.FechaDesde = new ValidadorFechaDesde().Validar(data.FechaDesde);
            output.FechaHasta = new ValidadorFechaHasta().Validar(data.FechaHasta);

            if (output.FechaDesde.CompareTo(output.FechaHasta) <= 0)
            {
                output.FechaDesde = new ValidadorFechaDesde().Validar(output.FechaDesde);
                output.FechaHasta = new ValidadorFechaHasta().Validar(output.FechaHasta);
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

                output.Tipo = otipo;
                output.Identificador = odata;
            }

            return output;
        }
    }
}
