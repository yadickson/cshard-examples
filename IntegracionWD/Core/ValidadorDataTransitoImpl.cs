using System;
using System.Collections.Generic;
using System.Text;
using IntegracionWD.Domain;
using IntegracionWD.Util;
using IntegracionWD.Exception;
using IntegracionWD.Constants;

namespace IntegracionWD.Core
{
    public class ValidadorDataTransitoImpl : ValidadorDataInterface<DataTransito>
    {
        public DataTransito Validar(DataTransito data)
        {
            DataTransito output = new DataTransito();

            output.Fecha_Desde = new ValidadorFechaDesde().Validar(data.Fecha_Desde);
            output.Fecha_Hasta = new ValidadorFechaHasta().Validar(data.Fecha_Hasta);

            if (output.Fecha_Desde.CompareTo(output.Fecha_Hasta) <= 0)
            {
                output.Fecha_Desde = new ValidadorFechaDesde().Validar(output.Fecha_Desde);
                output.Fecha_Hasta = new ValidadorFechaHasta().Validar(output.Fecha_Hasta);
            }
            else
            {
                throw new BusinessException("Fecha desde mayor a fecha hasta [FechaDesde:" + data.Fecha_Desde + "][FechaHasta:" + data.Fecha_Hasta + "]", Errors.FECHA_DESDE_MENOR);
            }

            if (data.Tipo != null || data.Identificador != null)
            {
                string otipo;
                string odata;

                new ValidadorTipoIdentificadorImpl().Validar(data.Tipo, data.Identificador, out otipo, out odata);

                output.Tipo = otipo;
                output.Identificador = odata;
            }

            return output;
        }
    }
}
