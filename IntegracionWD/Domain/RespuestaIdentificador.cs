using System;
using System.Collections.Generic;
using System.Text;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class RespuestaIdentificador
    {
        private string codigo;
        private string mensaje;
        private string codigoServicio;
        private string identificador;

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

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }
    }
}
