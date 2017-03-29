using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionWD.Domain;
using IntegracionWD.Util;

namespace IntegracionWD.Core
{
    public class ValidadorDataVehiculoImpl : ValidadorDataInterface<DataVehiculo>
    {
        public DataVehiculo Validar(DataVehiculo data)
        {
            DataVehiculo output = new DataVehiculo();

            output.Patente = new ValidadorPatente().Validar(data.Patente);
            output.Marca = new ValidadorMarca().Validar(data.Marca);
            output.Modelo = new ValidadorModelo().Validar(data.Modelo);
            output.Anio = new ValidadorAnioVehiculo().Validar(data.Anio);
            output.TipoVehiculo = new ValidadorTipoVehiculo().Validar(data.TipoVehiculo);
            output.Contrato = new ValidadorContrato().Validar(data.Contrato);
            output.RazonSocial = new ValidadorRazonSocial().Validar(data.RazonSocial);
            output.FechaExpiracion = new ValidadorFechaExpiracionVehiculo().Validar(data.FechaExpiracion);
            output.MotivoRechazo = new ValidadorMotivoRechazoVehiculo().Validar(data.MotivoRechazo);

            return output;
        }
    }
}
