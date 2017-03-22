using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class DataIdentificador
    {
        private string identificador { get; set; } // RUT/Patente
        private string tipo { get; set; } // persona/vehiculo
        
        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
