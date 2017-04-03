using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionWD.Domain
{
    [Serializable]
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
