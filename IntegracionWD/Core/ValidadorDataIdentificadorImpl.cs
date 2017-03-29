using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataIdentificadorImpl : ValidarDataInterface<DataIdentificador>
    {
        public DataIdentificador Validar(DataIdentificador data)
        {
            DataIdentificador output = new DataIdentificador();

            string otipo;
            string odata;

            new ValidadorTipoIdentificador().Validar(data.Tipo, data.Identificador, out otipo, out odata);

            output.Tipo = otipo;
            output.Identificador = odata;

            return output;
        }
    }
}
