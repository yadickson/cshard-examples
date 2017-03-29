using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataIdentificadorImpl : ValidadorDataInterface<DataIdentificador>
    {
        private ValidadorTipoIdentificadorInterface validador;

        public ValidadorDataIdentificadorImpl(ValidadorTipoIdentificadorInterface validador)
        {
            this.validador = validador;
        }

        public DataIdentificador Validar(DataIdentificador data)
        {
            DataIdentificador output = new DataIdentificador();

            string otipo;
            string odata;

            validador.Validar(data.Tipo, data.Identificador, out otipo, out odata);

            output.Tipo = otipo;
            output.Identificador = odata;

            return output;
        }
    }
}
