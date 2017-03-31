using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class Transito
    {
        private string fecha;
        private string sentido;
        private string puntoDeControl;
        private DataIdentificador tipoIdentificador;

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

        public DataIdentificador TipoIdentificador
        {
            get { return tipoIdentificador; }
            set { tipoIdentificador = value; }
        }
    }
}
