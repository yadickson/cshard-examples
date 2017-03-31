using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;
using IntegracionWD.Domain;

namespace IntegracionWD.Util
{
    public class ValidadorTipoIdentificador : ValidadorInterface<DataIdentificador, DataIdentificador>
    {
        private ValidadorInterface<string, string> validadorTipo;
        private ValidadorInterface<string, string> validadorRUT;
        private ValidadorInterface<string, string> validadorPatente;

        public ValidadorTipoIdentificador(ValidadorInterface<string, string> validadorTipo,
            ValidadorInterface<string, string> validadorRUT,
            ValidadorInterface<string, string> validadorPatente)
        {
            this.validadorTipo = validadorTipo;
            this.validadorRUT = validadorRUT;
            this.validadorPatente = validadorPatente;
        }

        public DataIdentificador Validar(DataIdentificador input)
        {
            DataIdentificador output = new DataIdentificador();
            output.Tipo = validadorTipo.Validar(input.Tipo);

            if (Messages.CODIGO_TIPO_PERSONA.Equals(output.Tipo))
            {
                output.Identificador = validadorRUT.Validar(input.Identificador);
            }
            else
            {
                output.Identificador = validadorPatente.Validar(input.Identificador);
            }

            return output;
        }
    }
}
