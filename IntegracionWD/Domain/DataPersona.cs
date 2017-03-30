using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class DataPersona
    {
        private string nombre;
        private string apellido;
        private string rut;
        private string tarjeta;
        private string tipoPase;
        private string contrato;
        private string razonSocial;
        private string fechaExpiracionTrabajador;
        private string motivoRechazoTrabajor;
        private string fechaExpiracionLicencia;
        private string motivoRechazoLicencia;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string RUT
        {
            get { return rut; }
            set { rut = value; }
        }

        public string Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }

        public string TipoPase
        {
            get { return tipoPase; }
            set { tipoPase = value; }
        }

        public string Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string FechaExpiracionTrabajador
        {
            get { return fechaExpiracionTrabajador; }
            set { fechaExpiracionTrabajador = value; }
        }

        public string MotivoRechazoTrabajor
        {
            get { return motivoRechazoTrabajor; }
            set { motivoRechazoTrabajor = value; }
        }

        public string FechaExpiracionLicencia
        {
            get { return fechaExpiracionLicencia; }
            set { fechaExpiracionLicencia = value; }
        }

        public string MotivoRechazoLicencia
        {
            get { return motivoRechazoLicencia; }
            set { motivoRechazoLicencia = value; }
        }
    }
}
