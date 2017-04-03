using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class DataTransito
    {
        private string fechaDesde;
        private string fechaHasta;
        private string tipo; // persona(P)/vehiculo(V)
        private string identificador; // RUT/Patente

        public string Fecha_Desde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        public string Fecha_Hasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
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
