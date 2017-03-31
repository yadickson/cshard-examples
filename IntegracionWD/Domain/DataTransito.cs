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
        private DataIdentificador tipoIdentificador;

        public string FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        public string FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }

        public DataIdentificador TipoIdentificador
        {
            get { return tipoIdentificador; }
            set { tipoIdentificador = value; }
        }
    }
}
