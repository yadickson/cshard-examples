using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class RespuestaTransito
    {
        private string codigo;
        private string mensaje;
        private ListadoTransito listadoTransito;

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

        public ListadoTransito ListadoTransito
        {
            get { return listadoTransito; }
            set { listadoTransito = value; }
        }
    }
}
