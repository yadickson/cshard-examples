using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Model
{
    [Serializable]
    public class Transito
    {
        private string fecha;
        private string sentido;
        private string puntoDeControl;
        private string tipo; // persona(P)/vehiculo(V)
        private string identificador; // RUT/Patente

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Sentido
        {
            get { return sentido; }
            set { sentido = value; }
        }

        public string PuntoDeControl
        {
            get { return puntoDeControl; }
            set { puntoDeControl = value; }
        }

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
