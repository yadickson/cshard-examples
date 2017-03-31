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
        private ValidadorInterface<DataIdentificador, DataIdentificador> validador;

        public ValidadorDataIdentificadorImpl(ValidadorInterface<DataIdentificador, DataIdentificador> validador)
        {
            this.validador = validador;
        }

        public DataIdentificador Validar(DataIdentificador data)
        {
            return validador.Validar(data);
        }
    }
}
