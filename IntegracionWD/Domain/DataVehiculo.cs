using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionWD.Domain
{
    [Serializable]
    public class DataVehiculo
    {
        private string patente;
        private string marca;
        private string modelo;
        private string anio;
        private string tipoVehiculo;
        private string contrato;
        private string razonSocial;
        private string fechaExpiracion;
        private string motivoRechazo;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public string Tipo_Vehiculo
        {
            get { return tipoVehiculo; }
            set { tipoVehiculo = value; }
        }

        public string Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        public string Razon_Social
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string Fecha_Expiracion
        {
            get { return fechaExpiracion; }
            set { fechaExpiracion = value; }
        }

        public string Motivo_Rechazo
        {
            get { return motivoRechazo; }
            set { motivoRechazo = value; }
        }
    }
}
