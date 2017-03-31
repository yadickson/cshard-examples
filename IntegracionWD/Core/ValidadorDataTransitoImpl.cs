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
    public class ValidadorDataTransitoImpl : ValidadorDataInterface<DataTransito>
    {
        private ValidadorInterface<string, string> validadorFechaDesde;
        private ValidadorInterface<string, string> validadorFechaHasta;
        private ValidadorInterface<DataIdentificador, DataIdentificador> validadorTipoIdentificador;

        public ValidadorDataTransitoImpl(ValidadorInterface<string, string> validadorFechaDesde,
            ValidadorInterface<string, string> validadorFechaHasta,
            ValidadorInterface<DataIdentificador, DataIdentificador> validadorTipoIdentificador)
        {
            this.validadorFechaDesde = validadorFechaDesde;
            this.validadorFechaHasta = validadorFechaHasta;
            this.validadorTipoIdentificador = validadorTipoIdentificador;
        }

        public DataTransito Validar(DataTransito data)
        {
            DataTransito output = new DataTransito();

            output.FechaDesde = validadorFechaDesde.Validar(data.FechaDesde);
            output.FechaHasta = validadorFechaHasta.Validar(data.FechaHasta);

            if (output.FechaDesde.CompareTo(output.FechaHasta) > 0)
            {
                throw new BusinessException("Fecha desde mayor a fecha hasta [FechaDesde:" + output.FechaDesde + "][FechaHasta:" + output.FechaHasta + "]", Errors.FECHA_DESDE_MENOR);
            }

            if (data.TipoIdentificador == null)
            {
                output.TipoIdentificador = data.TipoIdentificador = new DataIdentificador();
            }

            if (data.TipoIdentificador.Tipo != null || data.TipoIdentificador.Identificador != null)
            {
                output.TipoIdentificador = validadorTipoIdentificador.Validar(data.TipoIdentificador);
            }

            return output;
        }
    }
}
