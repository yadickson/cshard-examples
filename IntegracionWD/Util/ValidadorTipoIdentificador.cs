using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Constants;

namespace IntegracionWD.Util
{
    public class ValidadorTipoIdentificador
    {
        public void Validar(string tipo, string data, out string otipo, out string odata)
        {
            otipo = new ValidadorTipo().Validar(tipo);

            if (Messages.CODIGO_TIPO_PERSONA.Equals(otipo))
            {
                odata = new ValidadorRUT().Validar(data);
            }
            else
            {
                odata = new ValidadorPatente().Validar(data);
            }
        }
    }
}
