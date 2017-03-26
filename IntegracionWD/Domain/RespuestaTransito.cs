using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Model;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class RespuestaTransito
    {
        private string codigo;
        private string mensaje;
        private string codigoServicio;
        private List<Transito> listadoTransito;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string CodigoServicio
        {
            get { return codigoServicio; }
            set { codigoServicio = value; }
        }

        public List<Transito> ListadoTransito
        {
            get { return listadoTransito; }
            set { listadoTransito = value; }
        }
    }
}
