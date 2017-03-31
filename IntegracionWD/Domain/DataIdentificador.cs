using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    public class DataIdentificador
    {
        private string tipo; // persona(P)/vehiculo(V)
        private string identificador; // RUT/Patente

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

    }
}
