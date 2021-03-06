﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class Respuesta
    {
        private string codigo;
        private string mensaje;
        private string codigoServicio;

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
    }
}